using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyTurret enemy = collision.gameObject.GetComponent<EnemyTurret>();
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();

        if (enemy != null || player != null)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            else if (player != null)
            {
                player.TakeDamage(1);
            }
        }
        Destroy(gameObject);
    }
}
