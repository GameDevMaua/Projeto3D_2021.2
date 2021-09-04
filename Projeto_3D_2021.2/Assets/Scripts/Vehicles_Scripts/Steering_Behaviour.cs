using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Steering_Behaviour : MonoBehaviour{
  [SerializeField] private float _minDistanceBetweenCars;
  [SerializeField] private float _arrivalRange;
  [SerializeField] private float _maxVelocty;
  [SerializeField] private float _steeringMaxMagnitude;
  [SerializeField] private LayerMask _layersToCheck;
  private Rigidbody _rgb;
  private Vector3 _targetPosition;

  private void Start() {
    _rgb = GetComponent<Rigidbody>();
  }

  private RaycastHit IsThereAObjectAhead(LayerMask layerMask, Vector3 direction, float distance) {

    Debug.DrawRay(transform.position, direction * distance, Color.yellow);

    RaycastHit hit;

    Physics.Raycast(transform.position, direction, out hit, distance, layerMask);

    return hit;

  }
  
  private Vector3 setMagnitudeVector3(Vector3 inputVector, float newMagnitude) {
    Vector3 outputVector = inputVector.normalized;

    return outputVector * newMagnitude;
  }
  
  private Vector3 CalculateDesireVelocity(Vector3 targetObjectPosition) {
    
    float distanceToObject = Vector3.Distance(transform.position, targetObjectPosition);

    bool isInArrivalBehaviourRange = distanceToObject <= _arrivalRange;
    
    Vector3 targetPosition = Vector3.ClampMagnitude(targetObjectPosition - transform.position, distanceToObject - _minDistanceBetweenCars);

    targetPosition += transform.position;
    
    
    if (isInArrivalBehaviourRange) {
      Vector3 desiredVelocity = setMagnitudeVector3(targetPosition - transform.position, _maxVelocty*(distanceToObject/_arrivalRange));
      return desiredVelocity;
    }
    else {
      Vector3 desiredVelocity = setMagnitudeVector3(targetPosition - transform.position, _maxVelocty);
      return desiredVelocity;
    }

  }

  private Vector3 CalculateSteeringForce(Vector3 desiredVelocity) {
    //steering = desiredVelocity - velocity

    Vector3 steeringForce = desiredVelocity - _rgb.velocity;

    return Vector3.ClampMagnitude(steeringForce, _steeringMaxMagnitude);

  }

  private void SeekAndArriveBehaviour(Vector3 targetPosition) {
    Vector3 desiredVelocity = CalculateDesireVelocity(targetPosition);
    Vector3 steeringForce = CalculateSteeringForce(desiredVelocity);
    _rgb.AddForce(steeringForce);
  }

  private void MoveTowards(float velocity, Vector3 direction) {
    _rgb.velocity = setMagnitudeVector3(direction, velocity);
  }

  private void FixedUpdate() {
    var carAhead = IsThereAObjectAhead(_layersToCheck, Vector3.forward, _minDistanceBetweenCars * 3);
    if (carAhead.collider) {
      SeekAndArriveBehaviour(carAhead.point);
    }
    else {
      MoveTowards(_maxVelocty, Vector3.forward);
    }
  }
}
