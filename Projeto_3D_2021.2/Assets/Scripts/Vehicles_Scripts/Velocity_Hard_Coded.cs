using UnityEngine;

public class Velocity_Hard_Coded : MonoBehaviour{
    private Rigidbody _rgb;

    [SerializeField] public Vector3 _velocity;
    private void Start() {
        _rgb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rgb.velocity = _velocity;
    }
}
