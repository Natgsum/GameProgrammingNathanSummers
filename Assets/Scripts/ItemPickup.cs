using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum Item { Health, Ammo, Parts }
    public Item item;
    public int itemAmount = 1;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();

        if (player != null)
        {
            switch (item)
            {
                case Item.Health:
                    player.GiveHealth(itemAmount);
                    Destroy(gameObject);
                    break;
                case Item.Ammo:
                    player.GiveAmmo(itemAmount);
                    Destroy(gameObject);
                    break;
                case Item.Parts:
                    player.GiveParts(itemAmount);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
