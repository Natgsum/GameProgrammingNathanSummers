# CameraLockTutorial
 Game Programming module tutorial 

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


