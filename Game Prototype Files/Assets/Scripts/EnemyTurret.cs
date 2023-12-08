using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private int health = 2;
    public Transform target;
    public Transform shootPoint;
    public GameObject bullet;
    public float turnSpeed = 1f;
    public float fireRate = 1f;
    private float cooldown;
    public bool playerSeen = false;

    private void OnTriggerStay(Collider collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();

        if (player != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            float turn = turnSpeed - Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, turn);

            playerSeen = true;

            if (cooldown >= fireRate)
            {
                Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                cooldown = 0;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();

        if (player != null)
        {
            playerSeen = false;
        }
    }

    void Update()
    {
        cooldown += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
