# 2D Shooting Tutorial

This tutorial shows you how to make a player shoot.

## 1. Create a new scene

To begin this tutorial start by creating a new 2D scene.

Create a 2D Square Sprite and name it `Player`. Now add a `2D box collider`.

Now repeat this but instead name `Enemy`.

## 2. Create script

Create a script called `Shoot` and drag it onto the `Player`.

In this script, we will make the player instantiate a bullet when they press a specific key.

To begin, make a public `Transform` called `shootingPoint` and a public `GameObject` called `bulletPrefab`.

    public Transform shootingPoint;
    public GameObject bulletPrefab;

Then inside `void Update` make an `if` statement to see whether the `space key` has been pressed.

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
        }
    }

Inside the `if` statement we will now `instantiate` our `bulletPrefab` from our `shootingPoint`.

    Instantiate(bulletPrefab. shootingPoint.position, transform.rotation);

Now go back into Unity and right click the `Player` object and select `Create Empty` then name it `ShootingPoint` and then drag it to the right side of the player like the picture below.

![Screenshot 2023-11-14 122419](https://github.com/Natgsum/GameProgrammingTutorials/assets/73436877/99457b2e-44cb-400e-b5b1-642f271c3e98)

Now drag ShootingPoint game object into `Shooting Point` on our Players script.

![Screenshot 2023-11-14 122650](https://github.com/Natgsum/GameProgrammingTutorials/assets/73436877/9efd125b-995c-4210-a3a2-92827bcf3319)

## 3. Creating the bullet

Create a 2D Circle Sprite and name it `bullet`, scale the object down to the size you with your bullet to be, I have gone with a scale of 0.15.

Add a `Rigidbody 2D` and set `Gravity Scale` to `0` and then add a `Circle Collider 2D` and tick `Is Trigger`. Finally, make the bullet a prefab by dragging it into the assets folder in the Project tab.

We can now delete the bullet in the scene and drag our bullet prefab onto our Players `Bullet Prefab` on the `Shoot` script

