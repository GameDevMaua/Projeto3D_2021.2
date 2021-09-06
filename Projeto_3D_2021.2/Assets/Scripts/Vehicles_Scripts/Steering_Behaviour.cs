using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Steering_Behaviour : MonoBehaviour{
  [SerializeField] private float _minDistanceBetweenCars;
  [SerializeField] private float _arrivalRange;
  [SerializeField] private float _maxVelocity;
  [SerializeField] private float _steeringMaxMagnitude;
  [SerializeField] private LayerMask _layersToCheck;
  private Rigidbody _rgb;
  private Vector3 _targetPosition;

  private void Start() {
    _rgb = GetComponent<Rigidbody>();
  }

  private RaycastHit IsThereAObjectAhead(LayerMask layerMask, Vector3 direction, float distance) {

    Debug.DrawRay(transform.position, direction * distance, Color.yellow);

    Physics.Raycast(transform.position, direction, out var hit, distance, layerMask);

    return hit;

  }
  
  private Vector3 SetMagnitudeVector3(Vector3 inputVector, float newMagnitude) {
    var outputVector = inputVector.normalized;

    return outputVector * newMagnitude;
  }
  
  private Vector3 CalculateDesireVelocity(Vector3 targetObjectPosition) {
    
    var distanceToObject = Vector3.Distance(transform.position, targetObjectPosition);

    var isInArrivalBehaviourRange = distanceToObject <= _arrivalRange;
    
    var targetPosition = Vector3.ClampMagnitude(targetObjectPosition - transform.position, distanceToObject - _minDistanceBetweenCars);

    targetPosition += transform.position;

    var desiredVelocity = targetPosition - transform.position;
    
    if (isInArrivalBehaviourRange) 
       desiredVelocity = SetMagnitudeVector3(desiredVelocity, _maxVelocity*(distanceToObject/_arrivalRange));
    
    else 
      desiredVelocity = SetMagnitudeVector3(desiredVelocity, _maxVelocity);
    
    return desiredVelocity;

  }

  private Vector3 CalculateSteeringForce(Vector3 desiredVelocity) {
    //steering = desiredVelocity - velocity

    var steeringForce = desiredVelocity - _rgb.velocity;

    return Vector3.ClampMagnitude(steeringForce, _steeringMaxMagnitude);

  }

  private void SeekAndArriveBehaviour(Vector3 targetPosition) {
    var desiredVelocity = CalculateDesireVelocity(targetPosition);
    var steeringForce = CalculateSteeringForce(desiredVelocity);
   
    _rgb.AddForce(steeringForce);
    
  }

  private void MoveTowards(float velocity, Vector3 direction) {
    _rgb.velocity = SetMagnitudeVector3(direction, velocity);
  }

  private void FixedUpdate() {
    var carAhead = IsThereAObjectAhead(_layersToCheck, Vector3.forward, _minDistanceBetweenCars * 3);
    
    if (carAhead.collider)
      SeekAndArriveBehaviour(carAhead.point);
    
    else  
      MoveTowards(_maxVelocity, Vector3.forward);
    
  }
}
