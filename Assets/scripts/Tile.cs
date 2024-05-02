using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private Tower _tower;
    [SerializeField] private GridManager _gridManager;


    static public Dictionary<Vector3, Tile> _tiles = new Dictionary<Vector3, Tile>();

    public bool _available = true;

    public int _gridX, _gridY;

    private Tile left;
    private Tile left_top;
    private Tile top;
    static public Location start = new Location(20, 6);
    static public Location goal = new Location(10, 30);
    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        left = GetTileAtPosition(new Vector3(this.transform.position.x - 0.5f, GridManager._y, this.transform.position.z));
        left_top = GetTileAtPosition(new Vector3(this.transform.position.x - 0.5f, GridManager._y, this.transform.position.z + 0.5f));
        

    }

    public void SetActive()
    {
        _available = true;
        left._available = true;
        left_top._available = true;
        top._available = true;
    }

    public void SetNonActive()
    {
        _available = false;
        left._available = false;
        left_top._available = false;
        top._available = false;
    }

    private void OnMouseOver()
    {
        top = GetTileAtPosition(new Vector3(this.transform.position.x, GridManager._y, this.transform.position.z + 0.5f));
        if (left != null && left_top != null && top != null)
        {
            if (checkModeBulid._active && _available && left._available && left_top._available && top._available)
            {
                _highlight.SetActive(true);
                left._highlight.SetActive(true);
                left_top._highlight.SetActive(true);
                top._highlight.SetActive(true);
            }


            if (checkModeBulid._active && Input.GetMouseButtonDown(0) && _available && left._available && left_top._available && top._available)
            {
                SetNonActive();
                if (PathFinding.GetPath(CreateGrid(), start, goal, _gridManager._width, _gridManager._height))
                {
                    var spawnedTower = Instantiate(_tower, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    Tower._towers[new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)] = spawnedTower;
                    spawnedTower.name = $"Tower {Tower._towers.Count}";
                }
                else
                {
                    SetActive();
                    Debug.Log("NO BUILD");
                }
            }
        }
    }
    private void OnMouseExit()
    {
        top = GetTileAtPosition(new Vector3(this.transform.position.x, GridManager._y, this.transform.position.z + 0.5f));
        if (left != null && left_top != null && top != null)
        {
            _highlight.SetActive(false);
            left._highlight.SetActive(false);
            left_top._highlight.SetActive(false);
            top._highlight.SetActive(false);
        }
    }



    static public Tile GetTileAtPosition(Vector3 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

    public static SquareGrid CreateGrid()
    {
        var grid = new SquareGrid(21, 31);
        for (int i = 0; i < 4; i++)
        {
            grid.walls.Add(new Location(i, 30));
        }
        for (int i = 16; i < 21; i++)
        {
             grid.walls.Add(new Location(i, 30));
        }
        for (int i = 0; i < 31; i++)
        {
            if (i != 4 && i != 5 && i != 6 && i != 7 && i != 8)
                grid.walls.Add(new Location(20, i));
        }
        foreach (var tile in _tiles)
        {
            if (!tile.Value._available) 
                grid.walls.Add(new Location(tile.Value._gridX, tile.Value._gridY));
        }
        return grid;
    }
}