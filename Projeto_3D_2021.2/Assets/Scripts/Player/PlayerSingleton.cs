﻿using UnityEngine;

namespace Player{
    public class PlayerSingleton : Singleton<PlayerSingleton>{
        [SerializeField] private GameObject _target;

        [SerializeField]
        private float _lerpSpeed;

        [SerializeField] private float _maximumFuelInSeconds;

        //todo: Tirar esse serialized field
        [SerializeField]
        private float _jetpackFuel; //esse serialized field é só pra debuggar, a ideia é tirar depois

        public float JetpackFuel {
            get => _jetpackFuel;

            set {
                if (value <= 0) _jetpackFuel = 0f;
                else if (value >= _maximumFuelInSeconds) _jetpackFuel = _maximumFuelInSeconds;
                else _jetpackFuel = value;
            }
        }


        private void Start() {
            JetpackFuel = _maximumFuelInSeconds;
        }

        private void Update() {
            var targetPosition = _target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed);
        }
    }
}