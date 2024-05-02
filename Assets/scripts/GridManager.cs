using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int _width, _height;

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] public float _x, _z;
    [SerializeField] public static float _y = -7f;


    //private Dictionary<Vector3, bool> _tilesAvailable;

    void Start()
    {
        GenerateGrid();
        //foreach (var tile in Tile._tiles)
        //{
        //    Debug.Log($"{tile.Key}");
        //}
        //Tile n = Tile.GetTileAtPosition(new Vector3(60, 0, -10));
        //Debug.Log($"{n}");
    }

    private void Update()
    {
        
    }

    void GenerateGrid()
    {
        float x = 0, z = 0;
        for (int i = 0; i < _width; i++)
        {
            
            for (int j = 0; j < _height; j++)
            {
                if (i != _width - 1 && j != _height - 1)
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(x + _x, _y, z + _z), Quaternion.Euler(-90f, 0f, 0f));


                    spawnedTile.name = $"Tile {i} {j}";
                    spawnedTile._gridX = i;
                    spawnedTile._gridY = j;

                    var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                    spawnedTile.Init(isOffset);


                    Tile._tiles[new Vector3(x + _x, _y, z + _z)] = spawnedTile;
                    
                }
                MovementUnits._locationsOfTile[new Location(i, j)] = new Vector3(x + _x, _y + 0.25f, z + _z);
                z += 0.5f;
            }
            x += 0.5f;
            z = 0.0f;
        }
    }
}



