using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
[AddComponentMenu("Camera-Control/CameraZoom")]
public class CamRotation : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField][Range(1, 10)] public float Speed = 4f;
    [SerializeField][Range(1, 10)] public float SpeedRotation = 5f;
    [SerializeField][Range(1, 10)] public float SpeedScroll = 5f;
    [SerializeField] private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * Speed * Time.fixedDeltaTime);

        if (Input.GetMouseButton(1))
        {
            this.transform.eulerAngles += SpeedRotation * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        }
       
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(0, -SpeedRotation * 23 * Time.deltaTime, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(0, SpeedRotation * 23 * Time.deltaTime, 0, Space.World);
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _cam.transform.localRotation.eulerAngles.x >= 45f)
        {
            _cam.transform.Rotate(Vector3.left * SpeedScroll, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && _cam.transform.localRotation.eulerAngles.x < 90f)
        {
            _cam.transform.Rotate(Vector3.right * SpeedScroll, Space.Self);
        }
    }

}
