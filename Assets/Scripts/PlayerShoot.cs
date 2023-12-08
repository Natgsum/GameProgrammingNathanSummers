using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public float fireRate = 1f;
    private float cooldown;
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
    }

    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= fireRate && Input.GetButtonDown("Fire1") && playerManager.ammo >= 1)
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            cooldown = 0;
            playerManager.ammo -= 1;
        }
    }

}
