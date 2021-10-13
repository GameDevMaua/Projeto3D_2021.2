using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
    public class PlayerCollisions : MonoBehaviour{
        
        private static Dictionary<string, Action> _collisionDictionary = new Dictionary<string, Action> {
            {"Car", () => print("Colisao com um carro")},

            {"Teste", () => print("Colisao Teste")},
            

        };
        private void OnCollisionEnter(Collision other) {
            string gameTag = other.gameObject.tag;
            
                if (_collisionDictionary.ContainsKey(gameTag)) _collisionDictionary[gameTag]?.Invoke();
                else {
                    print("Essa colisao nao esta no dicionario");
                }
        }

        public void AddOnDictionary(string gameTag, Action funcAction) {
            if(!_collisionDictionary.ContainsKey(gameTag))  _collisionDictionary.Add(gameTag, funcAction);
            else {
                _collisionDictionary[gameTag] = funcAction;
            }
        }
        
        public void RemoveFromDictionary(string gameTag) {
            if(_collisionDictionary.ContainsKey(gameTag)) _collisionDictionary.Remove(gameTag);
        }
        
    }
}
