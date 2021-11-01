using UnityEngine;


namespace Road
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}
