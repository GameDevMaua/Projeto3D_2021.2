using UnityEngine;

namespace Player{
    public class PlayerSingleton : Singleton<PlayerSingleton>{
        [SerializeField] private GameObject _target;

        [SerializeField]
        private float _lerpSpeed;
        private void Update() {
            var targetPosition = _target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed);
        }
    }
}