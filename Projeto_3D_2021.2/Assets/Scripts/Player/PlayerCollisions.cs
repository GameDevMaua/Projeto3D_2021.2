using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
    public class PlayerCollisions : MonoBehaviour{

        public static event Action<GameObject> OnCarCollisionEvent;
        
        private static Dictionary<string, Action<GameObject>> _collisionDictionary = new Dictionary<string, Action<GameObject>> {
            {"Car", OnCarCollisionEvent}
        };
        
        private void OnCollisionEnter(Collision other) {
            string gameTag = other.gameObject.tag;
            
                if (_collisionDictionary.ContainsKey(gameTag))
                    _collisionDictionary[gameTag]?.Invoke(other.gameObject);
                
                else
                    print("Essa colisao nao esta no dicionario");
        }

        // public void AddOnDictionary(string gameTag, Action<GameObject> funcAction) {
        //     if(!_collisionDictionary.ContainsKey(gameTag))  
        //         _collisionDictionary.Add(gameTag, funcAction);
        //     
        //     else 
        //         _collisionDictionary[gameTag] = funcAction;
        //     
        // }
        //
        // public void RemoveFromDictionary(string gameTag) {
        //     if(_collisionDictionary.ContainsKey(gameTag)) 
        //         _collisionDictionary.Remove(gameTag);
        // }
        
    }
}
