using UnityEngine;

namespace Vehicle_Manager
{
    public class FrontSpawner : Spawner
    {
        protected override void CalculateNewPosition()
        {
            var oldPosition = currentTransform.position;
            var cameraPosition = followTransform.position;


            var newPosition = new Vector3(oldPosition.x,oldPosition.y, cameraPosition.z + zOffset);

            spawnerPosition = newPosition;
            currentTransform.position = newPosition;
            
            
        }
    }
}