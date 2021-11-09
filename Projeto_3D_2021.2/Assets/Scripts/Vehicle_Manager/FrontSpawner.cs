using UnityEngine;

namespace Vehicle_Manager
{
    public class FrontSpawner : Spawner
    {
        protected override void CalculateNewPosition()
        {
            var oldPosition = currentTransform.position;
            var cameraPosition = followTransform.position;

            var zOffset = cameraPosition.z + offset;
        
            var newPosition = new Vector3(oldPosition.x,oldPosition.y, zOffset);

            spawnerPosition = newPosition;
            currentTransform.position = newPosition;
        }
        

       protected override void SpawnNewVehicle() {
            lastSpawnTime = Time.time;
            VehicleManager.Instance.CreateNewVehicle(this, carVelocity, arrivalRange);
        }
        
    }
}