using UnityEngine;

namespace Vehicle_Manager
{
    public abstract class Spawner : MonoBehaviour
    {
        [HideInInspector] public Vector3 spawnerPosition;
        
        [SerializeField] private float cooldown;

        [SerializeField] protected LayerMask _layerMask;

        [SerializeField] protected float _safeZone;
        protected float lastSpawnTime;
        
        protected float zOffset;
        
        
        [SerializeField] protected float carVelocity;
        [SerializeField] protected float arrivalRange;
        [SerializeField] protected float maxDistanceBetweenCars;
        [SerializeField] protected float steeringForce;

        public Transform followTransform;
        protected Transform currentTransform;

        protected virtual void Start()
        {
            currentTransform = GetComponent<Transform>();
            
            zOffset = transform.position.z - followTransform.position.z;

        }

        protected virtual void SpawnNewVehicle() {
            lastSpawnTime = Time.time;
            VehicleManager.Instance.CreateNewVehicle(this, carVelocity, arrivalRange, maxDistanceBetweenCars, steeringForce);
        }
        protected abstract void CalculateNewPosition();
        private void Update()
        {
            CalculateNewPosition();
            if (CooldownIsOver()) {
                Physics.Raycast(transform.position - Vector3.forward * _safeZone, Vector3.forward, out var spawnerIsNotOnACar, _safeZone * 2, _layerMask);
                if(!spawnerIsNotOnACar.collider)
                    SpawnNewVehicle();
            }
        }
        private bool CooldownIsOver() => lastSpawnTime + cooldown<Time.time;

        private void OnDrawGizmos() {
            Color gizmosColor = Color.red;
            gizmosColor.a = 0.3f;
            Gizmos.color = gizmosColor;
            
            Gizmos.DrawCube(transform.position,Vector3.one * 1.3f);
        }
    }
}