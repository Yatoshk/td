using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class buildSystem : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;

    Tile onMouse;
    Tile upper;

    void Start()
    {
       // Tile n = _gridManager.GetTileAtPosition(new Vector3(60, 0, -10));
       // Debug.Log($"{n}");
        //Debug.Log($"{_gridManager._x}");
        //onMouse = _gridManager.GetTileAtPosition(new UnityEngine.Vector3(60, 0, -10));
        //upper = _gridManager.GetTileAtPosition(new UnityEngine.Vector3(60, 0, -10 + 0.5f));
        //if (onMouse == null) { Debug.Log("yyr"); }
        //onMouse.SetActiveHighlite();
        //upper.SetActiveHighlite();
    }

    // Update is called once per frame
    void Update()
    {
        //onMouse = _gridManager.GetTileAtPosition(new UnityEngine.Vector3(60, 0, -10));
        //if (onMouse == null) { Debug.Log("yyr"); }
        //if (_gridManager != null) { Debug.Log($"{_gridManager._x}"); }
        //if (onMouse.b_highlight == true)
        //{
        //    onMouse._highlight.SetActive(true);
        //    upper._highlight.SetActive(true);
        //}
    }

}
