using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using New_City_Generation;
using UnityEngine;

public class Tile{
    private Vector3 _position;
    private ScriptableTile _scriptableTile;

    public ScriptableTile ScriptableTile => _scriptableTile;
    public GameObject TileGameObject => _gameObject;

    private GameObject _gameObject;
    
    
    public Tile(Vector3 position, ScriptableTile scriptableTile) {
        _position = position;
        _scriptableTile = scriptableTile;
        
       _gameObject = GameObject.Instantiate(_scriptableTile.buildingPrefab, _position, Quaternion.identity);
        
    }

    public ScriptableTile PickARandomFromPossiblesList() {
        return _scriptableTile.nextPossibles.GetRandom();
    }

    public void SetScriptableTile(ScriptableTile scriptableTile) {
        _scriptableTile = scriptableTile;

        
    }
    
}
