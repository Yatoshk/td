using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForMainCamera : MonoBehaviour
{
    private Camera cam;
    [Header("Camera Settings")]
    [SerializeField][Range(10, 50)] public float ScroollSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if (cam.fieldOfView > 20 && cam.fieldOfView < 80)
        //{
        //    cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScroollSpeed;
        //    if (cam.fieldOfView <= 20)
        //        cam.fieldOfView = 21;
        //    if (cam.fieldOfView >= 80)
        //        cam.fieldOfView = 79;
        //}
    }
}