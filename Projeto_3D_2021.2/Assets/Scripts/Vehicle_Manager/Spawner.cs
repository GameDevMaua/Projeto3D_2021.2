using System;
using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;

namespace Vehicle_Manager
{
    public abstract class Spawner : MonoBehaviour
    {
        [HideInInspector] public Vector3 spawnerPosition;
        
        [SerializeField] private float cooldown;
        [SerializeField] private float lastSpawnTime;
        [SerializeField] protected float offset;
        
        public Transform followTransform;
        protected Transform currentTransform;

        private void Start()
        {
            currentTransform = GetComponent<Transform>();
        }

        private void SpawnNewVehicle()
        {
            lastSpawnTime = Time.time;
            VehicleManager.Instance.CreateNewVehicle(this);
        }
        private protected abstract void CalculateNewPosition();
        private void Update()
        {
            CalculateNewPosition();
            if (CooldownIsOver())
            {
                SpawnNewVehicle();
            }
        }
        private bool CooldownIsOver() => lastSpawnTime + cooldown<Time.time;
    }
}