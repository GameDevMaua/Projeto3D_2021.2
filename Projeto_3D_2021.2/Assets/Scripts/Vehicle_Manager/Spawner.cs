using System;
using UnityEditor;
using UnityEngine;

namespace Vehicle_Manager
{
    public abstract class Spawner : MonoBehaviour
    {
        [HideInInspector] public Vector3 spawnerPosition;
        
        [SerializeField] private float cooldown;
        protected float lastSpawnTime;
        [SerializeField] protected float offset;
        
        
        [SerializeField] protected float carVelocity;
        [SerializeField] protected float arrivalRange;

        public Transform followTransform;
        protected Transform currentTransform;

        protected virtual void Start()
        {
            currentTransform = GetComponent<Transform>();

            transform.position = followTransform.position + Vector3.down * 3; //esse 3 é um valor arbitrário. É só pra fazer com o que o spawner fique um pouco abaixo do player
            
        }

        protected virtual void SpawnNewVehicle()
        {
            lastSpawnTime = Time.time;
            VehicleManager.Instance.CreateNewVehicle(this, 5, 10f);
        } 
        protected abstract void CalculateNewPosition();
        private void Update()
        {
            CalculateNewPosition();
            if (CooldownIsOver())
            {
                SpawnNewVehicle();
            }
        }
        private bool CooldownIsOver() => lastSpawnTime + cooldown<Time.time;


        private void OnDrawGizmos() {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 colliderPosition = boxCollider.center + boxCollider.transform.position;
                Gizmos.DrawWireCube(colliderPosition, Vector3.one);
        }
    }
}