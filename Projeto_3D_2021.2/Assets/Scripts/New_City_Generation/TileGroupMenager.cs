﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace New_City_Generation{ //este é o script que vai no player

    public class TileGroupMenager : MonoBehaviour{
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
            // transform.position += Vector3.forward * Time.deltaTime * 84;
        }

        private void Start() {
            
            InitializeTileGroups();
            
            _currentPlayerGridPosition = GetPositionInGrid(transform.position);
            _previousPlayerGridPosition = _currentPlayerGridPosition;

            OnPlayerGridPositionUpdate += UpdateTileGroups;
        }

        private int GetPositionInGrid(Vector3 worldPosition) => Mathf.RoundToInt(worldPosition.z) / _tileGroupList[0].TileSize;

        
        private void CallEventOnPlayerGridPositionUpdate() {
            _currentPlayerGridPosition = GetPositionInGrid(transform.position);
            
            if (_currentPlayerGridPosition <= _previousPlayerGridPosition) return;
            
            _previousPlayerGridPosition = _currentPlayerGridPosition;
            OnPlayerGridPositionUpdate?.Invoke();
        }

        
        private void UpdateTileGroups() { 
            
            TileGroup previousGroup = _tileGroupList[0];
            
            previousGroup.DestroyTiles();
            _tileGroupList.RemoveAt(0);

            var lastTileInList = _tileGroupList.Last();
            
            var newTilePosition = lastTileInList.MiddleTilePosition + Vector3.forward * lastTileInList.TileSize;
            var newTileGroup = TileGroupFactory.CreateTileGroup(newTilePosition,lastTileInList.TileSize , lastTileInList); //criando um novo tileGroup
        
            
            _tileGroupList.Add(newTileGroup);
            
        }

        private void InitializeTileGroups() {
           
            var firstGroupGeneration = TileGroupFactory.CreateTileGroupsArray(_groupListSize, _worldPlayerPosition, 50, _firstLeftTile, _firstMiddleTile, _firstRightTile);

            foreach (var tileGroup in firstGroupGeneration) {
                _tileGroupList.Add(tileGroup);
            }
        }
    }
}