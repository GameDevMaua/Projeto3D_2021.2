using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Vehicle_Manager
{
    public class VehicleManager : Singleton<VehicleManager>
    {
        private int _carQuantity = 0;
        private List<GameObject> _vehicleList = new List<GameObject>();
        [SerializeField] private GameObject vehiclePrefab;
    

        public void CreateNewVehicle(Spawner spawner)
        {
            var position = spawner.spawnerPosition;
            var vehicle = GameObject.Instantiate(vehiclePrefab,position,Quaternion.identity);
            _vehicleList.Add(vehicle);
            _carQuantity++;
        
            //todo : adicionar novas funcionalidades depois
        }

        public void DestroyVehicle(GameObject gameObj)
        {
            print(_vehicleList.Remove(gameObj));
            Destroy(gameObj);
            _carQuantity--;
        }
    }
}