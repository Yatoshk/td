using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForMainCamera : MonoBehaviour
{
    private Vector3 CameraPosition;
    private Camera cam;
    [Header("Camera Settings")]
    [SerializeField][Range(1, 10)] public float Speed = 10f;
    [SerializeField] public float Step = 200f;
    [SerializeField][Range(10, 50)] public float ScroollSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = this.transform.position;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.z += Speed / Step;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.z -= Speed / Step;
        }
        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= Speed / Step;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += Speed / Step;
        }
        if (cam.fieldOfView > 20 && cam.fieldOfView < 80)
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScroollSpeed;
            if (cam.fieldOfView <= 20)
                cam.fieldOfView = 21;
            if (cam.fieldOfView >= 80)
                cam.fieldOfView = 79;
        }

        this.transform.position = CameraPosition;
    }
}
