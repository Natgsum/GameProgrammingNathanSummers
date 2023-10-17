# Pick Up Item Tutorial

This tutorial shows how to make an item that the player is able to pick up

## 1. Create a new scene

To begin this tutorial start by creating a new 2D scene.

Create a 2D Square Sprite and name it `Player`. Now add a `2D box collider`.

Make another 2D Square Sprite and name it `Pickup`. And add a `2D box collider` and tick `Is Trigger`.

## 2. Create a script

Create a script called `ItemPickUp` and drag it onto the square named Pickup.

In this script we will make the player pick up and item when they come in contact with it and cause it to do something then remove the pickup so they player cannot pick it up again.







    public Item item;
    public enum Item {Health, Ammo, Parts}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (item)
            {
                case Item.Health:
                    Debug.Log("Health picked up");
                    Destroy(gameObject);
                    break;
                case Item.Ammo:
                    Debug.Log("Ammo picked up");
                    Destroy(gameObject);
                    break;
                case Item.Parts:
                    Debug.Log("Parts picked up");
                    Destroy(gameObject);
                    break;
            }
        }
    }
