using UnityEngine;

namespace Player{
    public class PlayerSingleton : Singleton<PlayerSingleton>{
        [SerializeField] private GameObject _target;

        [SerializeField] private float _lerpSpeed;
        [SerializeField] private float _maximumFuelInSeconds;
        

        
        public bool CanFly { get; set; }
        //todo: Tirar esse serialized field
        [SerializeField]
        private float _jetpackFuel; //esse serialized field é só pra debuggar, a ideia é tirar depois

        public float JetpackFuel {
            get => _jetpackFuel;
            set => _jetpackFuel = Mathf.Clamp(value, 0, _maximumFuelInSeconds);
        }

        private void CheckIfCanFly() {
            if (JetpackFuel > 0 ) {
                CanFly = true;
            }
            else {
                CanFly = false;
            }
        }
        
        
        private void Start() {
            JetpackFuel = _maximumFuelInSeconds;
        }

        private void FixedUpdate() {
            var targetPosition = _target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed);
            
            CheckIfCanFly();
            
            
            
        }
    }
}