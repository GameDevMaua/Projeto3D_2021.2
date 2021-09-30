using System;
using ExtensionMethods;
using UnityEngine;

namespace City_Generation
{
    public class Player : MonoBehaviour
    {
        private int lastStep;
        private CityGeneration _cityGeneration;

        public TileInfo test1;
        public TileInfo test2;
        private void Awake()
        {
            _cityGeneration = new CityGeneration(new GridTile(0,test1,test1,test1,Vector3.zero));
        }

        private void Update()
        {
            var position = transform.position;
            var size = 12;
            var currentStep = position.z.FloorGridClamp(size);
            if (lastStep != currentStep)
            { 
                print(currentStep);
                print(lastStep);
                print("--------");
                _cityGeneration.ReCalculateGeneration(currentStep-size*5,currentStep+size*5,size);
                lastStep = currentStep;
            }
        }
    }
}