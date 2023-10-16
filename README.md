# CameraLockTutorial
This shows tutorial shows how to make a camera lockon to an object
## 1. Create a new scene
To begin this tutorial start by creating a new scene and name it `CameraLockOn`.

Create a 3D Cube and name it `Player`.

Repeat the above again and name this Cube `Enemy`.

Create a `Material` and name it `Green`. Then select the Material and change the `Albedo` to `Green`.

Repeat this step again and name this material `Red` and change its `Albedo` to `Red`.

Drag the `Green` material onto the `Player` Cube, and the `Red` material onto the `Enemy` Cube.

## 2. Create script

Create a new script called `LockOn` and drag it onto the `Main Camera`.

In this script we will make the Main Camera lock on and off of onto the nearest Enemy Cube 








using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float cameraSlack;
    public float cameraDistance;
    bool isLockedOn = false;
    public Transform noLock;


    private Vector3 pivotPoint;

    // Start is called before the first frame update
    void Start()
    {
        pivotPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = pivotPoint;
        Vector3 target = player.transform.position + Vector3.up;
        pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

        transform.position = pivotPoint;
        transform.LookAt((enemy.position + player.position) / 2);
        transform.position -= transform.forward * cameraDistance;
        if (Input.GetMouseButtonDown(0) && isLockedOn == true)
        {
            enemy = noLock.GetComponent<Transform>();
            isLockedOn = false;
            Debug.Log("Not Locked On");
        }
        else if (Input.GetMouseButtonDown(0) && isLockedOn == false)
        {
            enemy = FindClosestEnemy().GetComponent<Transform>();
            isLockedOn = true;
            Debug.Log("Locked On");
        }

    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closestEnemy = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject gameObject in gameObjects)
        {
            Vector3 difference = gameObject.transform.position - position;
            float currentDistance = difference.magnitude;
            if (currentDistance < distance)
            {
                closestEnemy = gameObject;
                distance = currentDistance;
            }
        }
        return closestEnemy;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    }

}


