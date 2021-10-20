using System.Collections.Generic;
using UnityEngine;

namespace New_City_Generation{
    public static class TileGroupObjectPooling{
        private static Queue<TileGroup> _tileGroupsQueue = new Queue<TileGroup>();

        public static void PoolInTileGroup(TileGroup tileGroup) {
            tileGroup.DeactivateTiles();
            _tileGroupsQueue.Enqueue(tileGroup);
        }

        public static TileGroup PoolOutTileGroup() {
            var recycledTile = _tileGroupsQueue.Dequeue();
            recycledTile.ActivateTiles();
            return recycledTile;
        }

        public static TileGroup CreateTileGroup(Vector3 middleTilePosition, int groupSize, TileGroup previousTileGroup = null, ScriptableTile leftTile = null, ScriptableTile middleTile = null, ScriptableTile rightTile = null) {
            if (previousTileGroup != null) return new TileGroup(middleTilePosition, previousTileGroup, groupSize);

            return new TileGroup(middleTilePosition, groupSize, leftTile, middleTile, rightTile);
        }
        
    }
}