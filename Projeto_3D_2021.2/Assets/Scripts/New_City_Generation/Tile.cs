using ExtensionMethods;
using New_City_Generation;
using UnityEngine;

public class Tile{
    private Vector3 _position;
    private ScriptableTile _scriptableTile;
    private GameObject _gameObject;

    public ScriptableTile ScriptableTile {
        get => _scriptableTile; 
        set => _scriptableTile = value;
    }

    public GameObject TileGameObject {
        get => _gameObject;
        set => _gameObject = value;
    }
    
    public Tile(Vector3 position, ScriptableTile scriptableTile) {
        _position = position;
        _scriptableTile = scriptableTile;
        
       _gameObject = GameObject.Instantiate(_scriptableTile.buildingPrefab, _position, Quaternion.identity);
        
    }
    
    public ScriptableTile PickARandomFromPossiblesList() {
        return _scriptableTile.nextPossibles.GetRandom();
    }

    
}
