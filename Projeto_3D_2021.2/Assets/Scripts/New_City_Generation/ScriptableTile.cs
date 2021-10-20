using System.Collections.Generic;
using UnityEngine;

namespace New_City_Generation{
    
    [CreateAssetMenu(fileName = "new_tile",menuName = "Create Scriptable Tile")]
    public class ScriptableTile : ScriptableObject{
        public List<ScriptableTile> nextPossibles = new List<ScriptableTile>();
        public List<Vector3> propPositions = new List<Vector3>();
        public Mesh buildingMesh;
        public GameObject buildingPrefab;
        public int size;
        
    }
}