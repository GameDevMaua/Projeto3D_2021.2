    using System;
    using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;
using UnityEngine;

namespace City_Generation
{
    public class CityGeneration
    {
        private Dictionary<int, GridTile> _currentTiles = new Dictionary<int, GridTile>();

        private GridTile defaultGridTile;

        public CityGeneration(GridTile defaultGridTile)
        {
            this.defaultGridTile = defaultGridTile;
        }
        
        public void ReCalculateGeneration(int from, int to, int size)
        {
            
            // Debug.Log(from);
            // Debug.Log(to);
            // Debug.Log(size);
            // Debug.Log("----------");
            
            //todo: Tentar tirar esses 3 loops pq assim fica zoado - Check
            var tilePositions = _currentTiles.Keys;

            int firstPositionInDicitionary = from;
            
            if (tilePositions.Count > 0)
            {
                firstPositionInDicitionary = tilePositions.Min();
            }

            for (int tilePosition = firstPositionInDicitionary; tilePosition < to; tilePosition += size){
                
                
                if (!_currentTiles.ContainsKey(tilePosition))
                {
                    Debug.Log($"criou na posição: {tilePosition}");
                    CreateTile(tilePosition);
                }
                
                var currentTile = _currentTiles[tilePosition];



                if (tilePosition < from || tilePosition > to)
                {
                    Debug.Log($"descriou na posição: {tilePosition}");
                    _currentTiles[tilePosition].DestroyGridTile();
                    _currentTiles.Remove(tilePosition);
                }
            }
                
            
            
        }

        private GridTile CreateTile(int currentIndex)
        {

            GridTile last = GetGridTile(currentIndex - 12);
            
            last ??= defaultGridTile;
            
            var center = last.roadBuildingInfo.nextPossibles.GetRandom();
            var right = last.roadBuildingInfo.nextPossibles.Intersect(center.nextPossibles).GetRandom();
            var left = last.roadBuildingInfo.nextPossibles.Intersect(center.nextPossibles).GetRandom();

            var position = GetPosition(last,12);
            
            var tile = new GridTile(currentIndex,center,right,left,position);

            _currentTiles.Add(currentIndex,tile);
            return tile;
        }

        private GridTile GetGridTile(int currentIndex)
        {
            if (_currentTiles.ContainsKey(currentIndex))
            {
                return _currentTiles[currentIndex];
            }

            return null;
        }

        private Vector3 GetPosition(GridTile lastTile,float size)
        {
            return lastTile.position + Vector3.forward * 12;
        }
    }
}