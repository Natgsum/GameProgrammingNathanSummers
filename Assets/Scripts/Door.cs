using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Opened");
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();

        if (player != null && playerManager.parts >= 5)
        {
            playerManager.parts -= 5;
            Destroy(gameObject);
        }
    }
}
