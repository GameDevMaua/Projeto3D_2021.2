using UnityEngine;
namespace Vehicle_Manager
{
    public class VehicleDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var gameObj = other.gameObject;
            var steeringBehaviour = gameObj.GetComponent<Steering_Behaviour>();
            if (steeringBehaviour != null)
            {
                VehicleManager.Instance.DestroyVehicle(gameObj);
            }
        }
    }
}