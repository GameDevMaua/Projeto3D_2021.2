using Input_Swipe;
using UnityEngine;

namespace Player{
    public class PlayerTarget : Singleton<PlayerTarget>{
        [SerializeField] private float _fowardVelocity;
        [SerializeField] private float _positionsOffset;


        private Vector3 _velocity;
        private float[] _horizontalPositionsArray;

        public int CurrentArrayPosition { get; set; } = 1;

        private void Start() {
            transform.parent = null;

            var middlePosition = transform.position.x;
            var rightPosition = middlePosition + _positionsOffset;
            var leftPosition = middlePosition - _positionsOffset;
            _horizontalPositionsArray = new[] {leftPosition, middlePosition, rightPosition};           
            
            _velocity = new Vector3(0, 0, _fowardVelocity);
            
            
        }

        private void Update() {
            transform.position += _velocity * Time.deltaTime;

        }

        public void Awake() {
            SwipeEventManager.LeftSwipeEvent += MoveLeft;
            SwipeEventManager.RightSwipeEvent += MoveRight;
        }


        [ContextMenu("Mover Direita")]
        public void MoveRight() {
            print("Direita");
            MoveTargetHorizontaly(1);
        }
        
        [ContextMenu("Mover Esquerda")]
        public void MoveLeft() {
            print("Esquerda");
            MoveTargetHorizontaly(-1);
        }
        public void MoveTargetHorizontaly(int direction) { //direction must be equals to -1 or 1;
            var canMove = ((CurrentArrayPosition + direction) >= 0 && (CurrentArrayPosition + direction) <= 2);
            if(canMove) {
                print("Andei");
                var newPosition = new Vector3(_horizontalPositionsArray[CurrentArrayPosition + direction],
                    transform.position.y, transform.position.z);
                transform.position = newPosition;
                CurrentArrayPosition += direction;
            }
        }
    }
}