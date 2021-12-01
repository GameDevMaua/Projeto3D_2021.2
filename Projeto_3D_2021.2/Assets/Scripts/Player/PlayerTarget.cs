using Input_Swipe;
using UnityEngine;

namespace Player{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTarget : Singleton<PlayerTarget>{
        [SerializeField] private float _fowardVelocity;
        [SerializeField] private float _positionsOffset;


        private Vector3 _velocity;
        private float[] _horizontalPositionsArray;

        private Rigidbody _rgb;

        [SerializeField] private float _maximumVerticalVel;

        private float _maximumVelocity;
        public int CurrentArrayPosition { get; set; } = 1;

        private void Start() {
            transform.parent = null;

            _rgb = GetComponent<Rigidbody>();
            
            _rgb.velocity = Vector3.forward * _fowardVelocity;
            
            
            var middlePosition = transform.position.x;
            var rightPosition = middlePosition + _positionsOffset;
            var leftPosition = middlePosition - _positionsOffset;
            _horizontalPositionsArray = new[] {leftPosition, middlePosition, rightPosition};
            
        }

        private void FixedUpdate() {
            var rgbVelocity = _rgb.velocity;
            
            var xVelSquared = Mathf.Pow(rgbVelocity.x, 2);
            var yVelSquared = Mathf.Pow(_maximumVerticalVel, 2);
            var zVelSquared = Mathf.Pow(rgbVelocity.z, 2);

            _maximumVelocity = Mathf.Sqrt(xVelSquared + yVelSquared + zVelSquared);
            
            _rgb.velocity = Vector3.ClampMagnitude(_rgb.velocity, _maximumVelocity);

        }

        // public void Awake() {
        //     SwipeEventManager.LeftSwipeEvent += MoveLeft;
        //     SwipeEventManager.RightSwipeEvent += MoveRight;
        // }


        [ContextMenu("Mover Direita")]
        public void MoveRight() {
            MoveTargetHorizontaly(1);
        }
        
        [ContextMenu("Mover Esquerda")]
        public void MoveLeft() {
            MoveTargetHorizontaly(-1);
        }
        public void MoveTargetHorizontaly(int direction) { //direction must be equals to -1 or 1;
            var canMove = ((CurrentArrayPosition + direction) >= 0 && (CurrentArrayPosition + direction) <= 2);
            if(canMove) {
                var newPosition = new Vector3(_horizontalPositionsArray[CurrentArrayPosition + direction],
                    transform.position.y, transform.position.z);
                transform.position = newPosition;
                CurrentArrayPosition += direction;
            }
        }
    }
}