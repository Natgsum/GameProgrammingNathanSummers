using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 5;
    public int ammo = 50;
    public int parts = 0;

    public GameObject healthBar;
    public GameObject ammoBar;
    public GameObject partsBar;

    private void Update()
    {
        healthBar.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health.ToString();
        ammoBar.GetComponent<UnityEngine.UI.Text>().text = "Ammo: " + ammo.ToString();
        partsBar.GetComponent<UnityEngine.UI.Text>().text = "Parts: " + parts.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GiveHealth(int giveHealth)
    {
        health += giveHealth;
    }
    public void GiveAmmo(int giveAmmo)
    {
        ammo += giveAmmo;
    }
    public void GiveParts(int giveParts)
    {
        parts += giveParts;
    }
}
