using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    static public Dictionary<Vector3, Tower> _towers = new Dictionary<Vector3, Tower>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (!checkModeBulid._active && Input.GetMouseButtonDown(0))
        {
            Tile.GetTileAtPosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)).SetActive();
            _towers.Remove(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
            Destroy(this.gameObject);
        }
    }

    static public Tower GetTileAtPosition(Vector3 pos)
    {
        if (_towers.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
