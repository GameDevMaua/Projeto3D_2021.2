using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
    public class PlayerCollisions : MonoBehaviour{

        public static event Action<GameObject> OnCarCollisionEvent;
        public static event Action<GameObject> OnStreetCollisionEvent;
        
        private static Dictionary<string, Action<GameObject>> _collisionDictionary = new Dictionary<string, Action<GameObject>> {
            {"Car", OnCarCollisionEvent},
            {"Street", OnStreetCollisionEvent}
        };
        
        private void OnCollisionEnter(Collision other) {
            string gameTag = other.gameObject.tag;
                if (_collisionDictionary.ContainsKey(gameTag)) 
                    _collisionDictionary[gameTag]?.Invoke(other.gameObject);
                
                else
                    print("Essa colisao nao esta no dicionario");
        }


        public static void SubscribeOnAEvent(string gametag, Action<GameObject> functionEvent) {
            _collisionDictionary[gametag] += functionEvent;
        }
        
        public static void UnsubscribeOnAEvent(string gametag, Action<GameObject> functionEvent) {
            _collisionDictionary[gametag] -= functionEvent;
        }
        
    }
}
