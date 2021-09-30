using System.Collections.Generic;
using UnityEngine;

namespace City_Generation
{
    [CreateAssetMenu(fileName = "new_tile_info",menuName = "Create Tile Info")]
    public class TileInfo: ScriptableObject
    {
        public List<TileInfo> nextPossibles = new List<TileInfo>();
        public List<Vector3> propPositions = new List<Vector3>();
        public Mesh buildingMesh;
        public GameObject prefab;
        public Vector3 size;
       

        public GameObject InstantiateClone(Vector3 position)
        {
            GameObject clone = Instantiate(prefab,position,Quaternion.Euler(-90,0,0));
            return clone;
        }
        
        // public GameObject InstantiateClone(Vector3 position)
        // {
        //     GameObject gameObj = BuildingFactory.PoolOutGameObj();
        //     gameObj.transform.position = position;
        //     var meshRender = gameObj.GetComponent<MeshFilter>();
        //     meshRender.sharedMesh = buildingMesh;
        //     gameObj.SetActive(true);
        //     return gameObj;
        // }
    }
}