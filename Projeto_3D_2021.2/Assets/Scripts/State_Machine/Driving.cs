
using System;
using Player;
using UnityEngine;
using Vehicle_Manager;

namespace State_Machine{
    [Serializable]
    public class Driving : BaseState{

        public GameObject Car { get; set; }
        public CarCollisions CarCollision { get; set; }

        private Rigidbody rgbPlayerTarget;

        [SerializeField] private float _impulseForce;
        
        // public Driving(StateManager stateManager) : base(stateManager) {
        //     rgbPlayerTarget = PlayerTarget.Instance.GetComponent<Rigidbody>();
        // }

        public override void Inject(StateManager stateManager) {
            base.Inject(stateManager);
            
            rgbPlayerTarget = PlayerTarget.Instance.GetComponent<Rigidbody>();
        }

        public override void OnExecuteState()
        {
            Debug.LogWarning("criar uma action para quando estiver segurando na tela e conectar a função q vai atualizar a variavel InputManager.Instance.touchPosition");
            var touchPositionInfo = InputManager.Instance.touchPosition;
            PlayerTarget.Instance.MovePlayerByDeltaX(touchPositionInfo.deltaTouchPosition.x,touchPositionInfo.deltaTimeTouchPosition);

            Car.transform.position = PlayerSingleton.Instance.transform.position;

        }

        public override void OnStateEnter() {
            base.OnStateEnter();

            rgbPlayerTarget.useGravity = false;

            var rgbPlayerVelocity = rgbPlayerTarget.velocity;

            var rgbCar = Car.GetComponent<Rigidbody>();
            var rgbCarVelocity = rgbCar.velocity;
            
            rgbPlayerVelocity = new Vector3(rgbCarVelocity.x, 0f, rgbCarVelocity.z); //esse 20 é a velocidade frontal
            rgbPlayerTarget.velocity = rgbPlayerVelocity;


            var transform = PlayerSingleton.Instance.transform;
            transform.position = Car.transform.position;
            Car.transform.parent = transform;
            
            
            CarCollision.OnCarCrashEvent += OnCarCrashed;
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
            rgbPlayerTarget.useGravity = true;

            Car.transform.parent = null;
            
            rgbPlayerTarget.AddForce(Vector3.up * _impulseForce, ForceMode.Impulse);
            CarCollision.OnCarCrashEvent -= OnCarCrashed;
        }

        public override void OnSwipeUp() {
            Debug.Log("SwipeUp na classe Driving");
            //todo:Verificar se alterar para o estado caindo é a melhor opção
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }



        public void OnCarCrashed(GameObject otherCar) {
            //todo: aplicar força no singlenton do player
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }
    }
}