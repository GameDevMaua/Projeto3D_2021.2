using System.Collections.Generic;
using UnityEngine;

namespace City_Generation
{
    public static class BuildingFactory
    {
        private static Queue<GameObject> _gameObjPool = new Queue<GameObject>();
        
        public static GameObject PoolOutGameObj()
        {
            return _gameObjPool.Count == 0 ? new GameObject("New Pool Object") : _gameObjPool.Dequeue();
        }
        
        public static void PoolInGameObj(GameObject instance)
        {
            instance.SetActive(false);
            _gameObjPool.Enqueue(instance);
        }
    }
}