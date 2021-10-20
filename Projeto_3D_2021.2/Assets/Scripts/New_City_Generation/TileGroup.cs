using UnityEngine;

namespace New_City_Generation{
    public class TileGroup{
        private Vector3 _middleTilePosition;

        private Tile _middleTile;
        private Tile _leftTile;
        private Tile _rightTile;
        private int _aroundTilesOffset;
        
        
        public Vector3 MiddleTilePosition => _middleTilePosition;
        public Tile MiddleTile => _middleTile;  
        public Tile LeftTile => _leftTile;
        public Tile RightTile => _rightTile;
        public Tile[] TilesArray => new[] {_leftTile, _middleTile, _rightTile};
        public int TileSize => _aroundTilesOffset;
        
        public TileGroup(Vector3 middleTilePosition, TileGroup previousGroup, int aroundTilesOffset) {
            _middleTilePosition = middleTilePosition;
            
            _aroundTilesOffset = aroundTilesOffset;
            
            _middleTile = new Tile(_middleTilePosition,
                previousGroup._middleTile.PickARandomFromPossiblesList());

            
            var aroundTilesPositionOffsetVector = new Vector3(_aroundTilesOffset, 0, 0);

            
            var leftTilePosition = middleTilePosition - aroundTilesPositionOffsetVector;
            _leftTile = new Tile(leftTilePosition, previousGroup._leftTile.PickARandomFromPossiblesList());

            var rightTilePosition = middleTilePosition + aroundTilesPositionOffsetVector;
            _rightTile = new Tile(rightTilePosition, previousGroup._rightTile.PickARandomFromPossiblesList());
        }

        public TileGroup(Vector3 middleTilePosition, int aroundTilesOffset, ScriptableTile leftBuilding, ScriptableTile middleBuilding, ScriptableTile rightBuilding) {
            _middleTilePosition = middleTilePosition;

            _aroundTilesOffset = aroundTilesOffset;

            _middleTile = new Tile(_middleTilePosition, middleBuilding);

            var aroundTilesPositionOffsetVector = new Vector3(_aroundTilesOffset, 0, 0);
  
            var leftTilePosition = _middleTilePosition - aroundTilesPositionOffsetVector;
            _leftTile = new Tile(leftTilePosition, leftBuilding);

            var rightTilePosition = _middleTilePosition + aroundTilesPositionOffsetVector;
            _rightTile = new Tile(rightTilePosition, rightBuilding);
        }

        public void DestroyTiles() {
            foreach (var tile in TilesArray) {
                GameObject.Destroy(tile.TileGameObject);
            }
        }
        
        public void ActivateTiles() {
            foreach (var tile in TilesArray) {
                tile.TileGameObject.SetActive(true);
            }
        }

        public void SetGroupPosition(Vector3 newMiddlePosition) {
            TilesArray[0].TileGameObject.transform.position = newMiddlePosition - Vector3.left * _aroundTilesOffset;
            TilesArray[1].TileGameObject.transform.position = newMiddlePosition;
            TilesArray[2].TileGameObject.transform.position = newMiddlePosition + Vector3.left * _aroundTilesOffset;

            _middleTilePosition = newMiddlePosition;
        }
    }
}