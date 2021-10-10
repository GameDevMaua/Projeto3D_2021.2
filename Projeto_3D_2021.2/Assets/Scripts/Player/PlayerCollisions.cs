using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
    public class PlayerCollisions : MonoBehaviour{
        public Dictionary<string, Action> _collisionDictionary;
        
        private void OnCollisionEnter(Collision other) {
            string gameTag = other.gameObject.tag;
            
                if (_collisionDictionary.ContainsKey(gameTag)) _collisionDictionary[gameTag]?.Invoke();
                else {
                    print("Essa colisao nao esta no dicionario");
                }

        }


        private void Awake() {
            _collisionDictionary = new Dictionary<string, Action> {
                {"Car", () => print("Colisao com um carro")},

                {"Teste", () => print("Colisao Teste")},
                
                {"Predio", ()=> print("Colisao com um predio")}
                
                
            };
        }
    }
}
