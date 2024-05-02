using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    [SerializeField] public GameObject _unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            Instantiate(_unit, new Vector3(89f, -6.75f, -40f), Quaternion.identity);
        }
    }
}
