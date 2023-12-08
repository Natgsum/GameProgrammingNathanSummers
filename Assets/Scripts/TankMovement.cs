using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 0.1f;
    public Transform[] points;
    private int current;

    private void Start()
    {
        current = 0;
    }

    private void Update()
    {
        Vector3 targetDir = points[current].position - transform.position;
        float turn = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turn, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
