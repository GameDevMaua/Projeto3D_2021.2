using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle_Manager{
    public class CarCollisions : MonoBehaviour{
        
        public event Action<GameObject> OnCarCrashEvent;

        private Dictionary<string, Action<GameObject>> _collisionDictionary;


        private void Start() {
           _collisionDictionary = new Dictionary<string, Action<GameObject>> {
               {"Car", (GameObject otherCar) => {
                   OnCarCrashEvent?.Invoke(otherCar);
                   OnCarCrashed(otherCar);
               } }
               
            };
        }

        private void OnCollisionEnter(Collision other) {
            string gameTag = other.gameObject.tag;
            if (_collisionDictionary.ContainsKey(gameTag)) 
                _collisionDictionary[gameTag]?.Invoke(other.gameObject);
            
        }

        private void OnCarCrashed(GameObject otherCar) {
           Destroy(otherCar);
        }
        
    }
}