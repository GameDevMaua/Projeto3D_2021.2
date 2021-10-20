using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

namespace New_City_Generation{ //este é o script que vai no player
    public class TileGrid : MonoBehaviour{
        [SerializeField] private int _groupListSize;
        [SerializeField] private ScriptableTile _firstLeftTile;
        [SerializeField] private ScriptableTile _firstMiddleTile;
        [SerializeField] private ScriptableTile _firstRightTile;

        private List<TileGroup> _tileGroupList = new List<TileGroup>();
        private int _currentPlayerGridPosition;
        private int _previousPlayerGridPosition;
        private Vector3 _worldPlayerPosition;
        private TileGroup _firstGroupEver;

        public event Action OnPlayerGridPositionUpdate;
        
        void Update() {
            CallEventOnPlayerGridPositionUpdate();
        }

        private void Start() {
            _firstGroupEver = //Criando o primeiro tile na unha
                new TileGroup(_worldPlayerPosition, 50, _firstLeftTile, _firstMiddleTile, _firstRightTile);
            
            InitializeTileGroups();
            
            _currentPlayerGridPosition = GetPositionInGrid(PlayerManager.Instance.transform.position);
            _previousPlayerGridPosition = _currentPlayerGridPosition;

            OnPlayerGridPositionUpdate += UpdateTileGroups;

        }

        private int GetPositionInGrid(Vector3 worldPosition) => Mathf.RoundToInt(worldPosition.z) / _tileGroupList[0].TileSize;

        private void CallEventOnPlayerGridPositionUpdate() {
            _currentPlayerGridPosition = GetPositionInGrid(PlayerManager.Instance.transform.position);
            
            if (_currentPlayerGridPosition <= _previousPlayerGridPosition) return;
            
            _previousPlayerGridPosition = _currentPlayerGridPosition;
            OnPlayerGridPositionUpdate?.Invoke();
        }


        private void UpdateTileGroups() { //esse método estará dentro do evento OnPlayerGridPositionUpdate
            
            TileGroup previousGroup = _tileGroupList[0];
            
            TileGroupObjectPooling.PoolInTileGroup(_tileGroupList[0]);
            _tileGroupList.RemoveAt(0);

            var newTileGroup = TileGroupObjectPooling.PoolOutTileGroup();
        
            newTileGroup.ChangeTilesBuildings(previousGroup);
            newTileGroup.SetGroupPosition(_tileGroupList.Last().MiddleTilePosition + Vector3.forward * _firstGroupEver.TileSize );
            
            _tileGroupList.Add(newTileGroup);
            
        }
        
        private void InitializeTileGroups() {
            _tileGroupList.Add(_firstGroupEver);  
            for (var i = 1; i < _groupListSize; i++) {
                Vector3 middlePosition = _worldPlayerPosition + (Vector3.forward * i * _firstGroupEver.TileSize);
               _tileGroupList.Add(TileGroupObjectPooling.CreateTileGroup(middlePosition, _firstGroupEver.TileSize,
                   _tileGroupList[i - 1]));
            }
        }
        
        
    }
}