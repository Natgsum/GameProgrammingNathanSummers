using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();

        if (player != null)
        {
            player.TakeDamage(2);
        }
        Destroy(gameObject);
    }
}
