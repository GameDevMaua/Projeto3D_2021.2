using UnityEngine;

namespace Vehicle_Manager
{
    public class BackSpawner : Spawner
    {
        private protected override void CalculateNewPosition()
        {
            var oldPosition = currentTransform.position;
            var cameraPosition = followTransform.position;

            var zOffset = cameraPosition.z - offset;
        
            var newPosition = new Vector3(oldPosition.x,oldPosition.y, zOffset);

            spawnerPosition = newPosition;
            currentTransform.position = newPosition;
        }
    }
}