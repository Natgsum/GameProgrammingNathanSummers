using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretLook : MonoBehaviour
{
    private Vector2 turn;

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0,turn.x,0);
    }
}
