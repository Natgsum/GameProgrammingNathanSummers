# Pick Up Item Tutorial

This tutorial shows how to make an item that the player can pick up

## 1. Create a new scene

To begin this tutorial start by creating a new 2D scene.

Create a 2D Square Sprite and name it `Player`. Now add a `2D box collider` and add a tag to the object called `Player`

Make another 2D Square Sprite and name it `Pickup`. Add a `2D box collider` and tick `Is Trigger`.

## 2. Create a script

Create a script called `ItemPickUp` and drag it onto the square named Pickup.

In this script, we will make the player pick up an item when they come in contact with it and cause it to do something then remove the pickup so the player cannot pick it up again.

To begin we shall start by making an `enum` called `Item` then in between `{ }` add `Health. Ammo, Parts`. Now add `public Item item` after the enum.

    public enum Item {Health, Ammo, Parts}
    public Item item;

Now we will make the items do something when touched. We will do this by using `OnTriggerEnter2D`. First, make a `public void` and then put `OnTriggerEnter2D(Collider2D collision)`.

    private void OnTriggerEnter2D(Collider2D collision) {}

Inside the `{}` we will see if the player has come in contact with the item. Make an `if` statement that checks whether an object with the `tag Player` collides with the item.

    if (collision.gameObject.tag == "Player") {}

We will make a `switch` inside this if statement to see which pickup the player has touched and what should happen depending on what pickup it is. Inside switch we will add the three items we made previously, starting with `case Item.Health` then repeat this for the other two. We will also add `break` inside each of them.

    switch (item)
    {
        case Item.Health:
            break;
        case Item.Ammo:
            break;
        case Item.Parts:
            break;
    }

## 3. Creating player inventory
Next, we will add what will happen when these items are picked up. Start with making a new script called `PlayerInventory` and adding it to our player object. Inside this script, we will make three integer variables `Health, Ammo and Parts` you can then set the values of these to whatever you wish but for this tutorial, I will set health to 5, ammo to 100 and Parts to 0. 

    public int Health = 5;
    public int Ammo = 100;
    public int Parts = 0;

If we go back into our ItemPickup script and reference our `PlayerInventory` script

    private PlayerInventory playerInventory;

Next, we will make a public `GameObject` which is where we will put our player object that has the PlayerInventory script attached.

    public GameObject player;

Additionally, we will use `Start` to get the PlayerInventory script on our player game object.

    void Start()
    {
        playerInventory = player.GetComponent<PlayerInventory>();
    }

Now if we head back to our OnTriggerEnter2D we will add what we want to happen when our items are picked up. Inside `case Item.Health` we will make the players health `increase by 1` and then `destroy` the pickup.

    case Item.Health:
        playerInventory.Health = playerInventory.Health + 1;
        Destroy(gameObject);
        break;

We will now repeat this for the `Ammo and Parts`. I set `Ammo to increase by 5` and `Parts to increase by 1`. So in sum your ItemPickup script should look something like this.

    public enum Item {Health, Ammo, Parts}
    public Item item;
    private PlayerInventory playerInventory;
    public GameObject player;

    void Start()
    {
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (item)
            {
                case Item.Health:
                    playerInventory.Health = playerInventory.Health + 1;
                    Destroy(gameObject);
                    break;
                case Item.Ammo:
                    playerInventory.Ammo = playerInventory.Ammo + 5;
                    Destroy(gameObject);
                    break;
                case Item.Parts:
                    playerInventory.Parts = playerInventory.Parts + 1;
                    Destroy(gameObject);
                    break;
            }
        }
    }

Finally, if we go back into Unity and select our pick-up you will see that we can change which item the pick-up is and we also need to drag our player game object into the `Player` slot below our item selecter. With this, our player will now be able to pick up the item when their box collider comes into contact with the pickup's collider.
