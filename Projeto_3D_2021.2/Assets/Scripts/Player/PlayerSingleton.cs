using UnityEngine;

namespace Player{
    public class PlayerSingleton : Singleton<PlayerSingleton>{
        [SerializeField] private GameObject _target;
        
        private void Update() {
            var targetPosition = _target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        }
    }
}