using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class MovementUnits : MonoBehaviour
{
    [SerializeField] public GameObject _portal;
    [SerializeField] public float _speed;

    static public Dictionary<Location, Vector3> _locationsOfTile = new Dictionary<Location, Vector3>();

    private List<Vector3> _points = new List<Vector3>();

    private Vector3 _position;
    private int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        MakePath(Tile.start);
        _points.Add(_portal.transform.position);
        foreach (var p in _points)
            Debug.Log($"{p.x}, {p.y}, {p.z}");
    }

    // Update is called once per frame
    void Update()
    {
        _position = this.transform.position;
        this.transform.position = Vector3.MoveTowards(_position, _points[x], _speed * Time.deltaTime);

        if (_position == _points[x] && x != _points.Count - 1)
            x++;
        if (x > _points.Count - 1)
            OnTriggerEnter(_portal.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(this.gameObject);
    }

    private void MakePath(Location start)
    {
        var path = PathFinding.GetPathUnits(Tile.CreateGrid(), start, Tile.goal);
        foreach (var point in path)
        {
            Vector3 loc;
            _locationsOfTile.TryGetValue(point, out loc);
            _points.Add(loc);
            //Debug.Log($"{_locationsOfTile[point]}");
            //Debug.Log($"{point.x} {point.y}");
        }
    }
    private Location GetLocationTileAtPosition(Vector3 pos)
    {
        return new Location(0, 0);
    }
}