using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/CameraZoom")]
public class CamRotation : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField][Range(10, 100)] public float SpeedRotation = 50f;
    [SerializeField] public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //todo: move rotation change on right button and mouse
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(0, -SpeedRotation * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(0, SpeedRotation * Time.deltaTime, 0);
        }

       

    }
}
