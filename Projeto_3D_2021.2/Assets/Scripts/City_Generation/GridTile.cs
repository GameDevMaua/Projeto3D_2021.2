using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using ExtensionMethods;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;
using UnityEngineInternal;
using Random = UnityEngine.Random;

namespace ExtensionMethods
{
    public static class Extension
    {
        public static T GetRandom<T>(this IEnumerable<T> data)
        {
            var enumerable = data as T[] ?? data.ToArray();
            return enumerable.ElementAt(Random.Range(0, enumerable.Count()));
        }

        public static int FloorGridClamp(this float number, int gridSize)
        {
            return Mathf.FloorToInt(number / (float) gridSize) * gridSize;
        }
    }
}


namespace City_Generation
{

    public class player : MonoBehaviour
    {
        private int lastStep;
        private aaaa _aaaa;
        private void update()
        {
            var position = transform.position;
            var size = 2;
            var currentStep = position.z.FloorGridClamp(size);
            if (lastStep != currentStep)
            { 
                _aaaa.ReCalculateGeneration(lastStep-size*5,lastStep+size*5,size);
                lastStep = currentStep;
            }
        }
    }
    
    public class aaaa
    {
        private Dictionary<int, GridTile> _currentTiles = new Dictionary<int, GridTile>();
        public void ReCalculateGeneration(int from, int to, int size)
        {
            foreach (var tile in _currentTiles.Values)
            {
                tile.safe = false;
            }
            
            for (int i = from; i < to; i += size)
            {
                var tile = _currentTiles[i];
                if (tile is null)
                {
                    tile = CreateTile(i);
                }

                tile.safe = true;
            }

            foreach (var tile in _currentTiles.Values)
            {
                if (tile.safe == false)
                {
                    tile.Recycle();
                }
            }
        }
        private GridTile CreateTile(int currentIndex)
        {
            GridTile last = _currentTiles[currentIndex - 1];
            
            var center = last.roadBuildingInfo.nextPossibles.GetRandom();
            var right = last.roadBuildingInfo.nextPossibles.Intersect(center.nextPossibles).GetRandom();
            var left = last.roadBuildingInfo.nextPossibles.Intersect(center.nextPossibles).GetRandom();

            var size = center.size.z;
            var position = GetPosition(last,size);

            var tile = new GridTile(currentIndex,center,right,left,position);

            _currentTiles.Add(currentIndex,tile);
            return tile;
        }

        private Vector3 GetPosition(GridTile lastTile,float size)
        {
            return lastTile.position + Vector3.forward * (lastTile.size / 2f + size/2f);
        }
    }


    public class TileInfo: ScriptableObject
    {
        public List<TileInfo> nextPossibles = new List<TileInfo>();
        public Mesh buildingMesh;
        public Vector3 size;

        public GameObject InstantiateClone(Vector3 position)
        {
            GameObject gameObj = BuildingFactory.PoolOutGameObj();
            gameObj.transform.position = position;
            var meshRender = gameObj.GetComponent<MeshFilter>();
            meshRender.sharedMesh = buildingMesh;
            gameObj.SetActive(true);
            return gameObj;
        }
    }
    public class GridTile
    {
        public int index;
        
        public GameObject leftBuilding;
        public GameObject roadBuilding;
        public GameObject rightBuilding;

        public TileInfo leftBuildingInfo;
        public TileInfo roadBuildingInfo;
        public TileInfo rightBuildingInfo;

        public bool safe;
        public float size;
        public Vector3 position;

        public GridTile(int index, TileInfo center, TileInfo right, TileInfo left, Vector3 position)
        {
            this.index = index;
            roadBuildingInfo = center;
            rightBuildingInfo = right;
            leftBuildingInfo = left;

            roadBuilding = center.InstantiateClone(position);
            rightBuilding = right.InstantiateClone(position);
            leftBuilding = left.InstantiateClone(position);

            this.position = position;
            size = center.size.z;
        }
        
        public void Recycle()
        {
            BuildingFactory.PoolInGameObj(leftBuilding);
            BuildingFactory.PoolInGameObj(roadBuilding);
            BuildingFactory.PoolInGameObj(rightBuilding);
        }
    }
    
    public class BuildingFactory
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
