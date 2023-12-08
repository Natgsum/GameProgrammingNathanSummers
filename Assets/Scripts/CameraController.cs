using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float YMin = -25f;
    private float YMax = 25f;

    public Transform lookAt;

    public float distance = 10.0f;
    public float height = 3.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if(lookAt != null)
        {
            currentX += Input.GetAxis("Mouse X") * sensivity;
            currentY += Input.GetAxis("Mouse Y") * sensivity;

            currentY = Mathf.Clamp(currentY, YMin, YMax);

            Vector3 Direction = new Vector3(0, height, -distance);
            Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
            transform.position = lookAt.position + rotation * Direction;

            transform.LookAt(lookAt.position);
        }
    }
}
