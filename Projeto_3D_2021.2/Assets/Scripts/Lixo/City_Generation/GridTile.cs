using UnityEngine;

namespace City_Generation
{
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
            
            // todo: calcular alguma forma para não spawnar no mesmo lugar 
            
            roadBuilding = center.InstantiateClone(position);
            rightBuilding = right.InstantiateClone(position); //position.x - size?
            leftBuilding = left.InstantiateClone(position); //position.x + size?

            this.position = position;
            size = center.size.z;
        }
        
        public void Recycle()
        {
            BuildingFactory.PoolInGameObj(leftBuilding);
            BuildingFactory.PoolInGameObj(roadBuilding);
            BuildingFactory.PoolInGameObj(rightBuilding);
        }

        public void DestroyGridTile()
        {
            
            GameObject.Destroy(leftBuilding);
            GameObject.Destroy(roadBuilding);
            GameObject.Destroy(rightBuilding);
        }
    }
}
