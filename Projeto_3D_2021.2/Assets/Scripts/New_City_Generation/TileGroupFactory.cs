using UnityEngine;

namespace New_City_Generation{
    public class TileGroupFactory{
        public static TileGroup CreateTileGroup(Vector3 middleTilePosition, int groupSize, TileGroup previousTileGroup = null, ScriptableTile leftTile = null, ScriptableTile middleTile = null, ScriptableTile rightTile = null) {
            if (previousTileGroup != null) return new TileGroup(middleTilePosition, previousTileGroup, groupSize);

            return new TileGroup(middleTilePosition, groupSize, leftTile, middleTile, rightTile);
        }

        public static TileGroup[] CreateTileGroupsArray(int arraySize, Vector3 firstGroupPosition,int groupSize ,ScriptableTile firstLeftTile, ScriptableTile firstMiddleTile, ScriptableTile firstRightTile) {
            var groupArray = new TileGroup[arraySize];
            var firstGroupEver = CreateTileGroup(firstGroupPosition, groupSize,null ,firstLeftTile, firstMiddleTile,
                firstRightTile);
            groupArray[0] = firstGroupEver;
            
            for (var i = 1; i < arraySize; i++) {
                var groupPosition = firstGroupEver.MiddleTilePosition + Vector3.forward * groupSize * i;
                groupArray[i] = CreateTileGroup(groupPosition, firstGroupEver.TileSize, groupArray[i - 1]);
            }

            return groupArray;
        }
        
    }
}