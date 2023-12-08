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

We can now delete the bullet in the scene and drag our bullet prefab onto our Players `Bullet Prefab` on the `Shoot` script.

Now select our `Bullet` prefab in the assets folder and create a `script` called `Bullet`. In this script we will give the bullet a velocity when instantiated.

To start, make a `public float` called speed. and a `private Rigidbody2D` called rb.

    public float speed;
    private Rigidbody2D rb;

Then inside `void Start()` we will get the rigidbody of the bullet using `GetComponent`.

    rb = GetComponent<Rigidbody2D>();

Then set the `velocity` of `rb` to be the float `speed` multiplied by `transform.right`.

    rb.velocity = transform.right * speed;

## 4. Enemy Damage

On the `Enemy` game object create a new script called `Enemy` in this script we will give the enemy health and a way of taking damage.

Start off by making a `private int` called `health` and set to 5.

    private int health = 5;

Now we will make a function which will let the enemy take damage. Make a `public void` called `TakeDamage` and add an `int` parameter called `damage`.

    public void TakeDamage(int damage) {}

Inside this function we will `minus` the `damage` from the `health`. Then add an if statement for destroying the game object when the `health <= 0`.

    health -= damage;
    if (health <= 0)
    {
        Destroy(gameObject);
    }

Now head back into the `Bullet` script and at the end we will add an `OnTriggerEnter2D`.

    void OnTriggerEnter2D(Collider2D collision) {}

Inside this OnTriggerEnter2D we will get the `Enemy` script component from the object which the bullet touches. 

    Enemy enemy = collision.GetComponent<Enemy>();

And if the object we touch does have the `Enemy` script we will call the `TakeDamage` function.

    if (enemy != null)
    {
        enemy.TakeDamage(1);
    }

Finally, we will destroy the bullet game object.

    Destroy(gameObject);

In summary, your three scripts should look like the following

Bullet script:

    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject);
    }

Shoot script:

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            
        }
    }

Enemy script:

    private int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
