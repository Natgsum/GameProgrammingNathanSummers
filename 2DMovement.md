# 2D Movement Tutorial

This tutorial shows how to make 2d movement.

## 1. Create a new scene

To begin this tutorial start by creating a new 2D scene.

Create a 2D Square Sprite and name it `Player`. Now add a `2D Rigidbody` and a `2D box collider`.

Make another 2D Square Sprite and name it `Ground`. And add a `2D box collider`.

Drag the `Player` square above `Ground` square. Also scale the x axis of the square to allow our player square to be able to move around without without falling of easily.

## 2. Create script

Create a new script called `Movement` and drag it onto the `Player`.

In this script we will make the player square be able to move left and right and also flip the player when they move in a direction.

To begin we shall start by making `two private floats` called `playerInput` and `speed`. We will set `playerInput to 0` and `speed to 250`. The playerInput float will be used to store whether the player is holding down the movement button. The speed float will be used to determine how fast the player should move.

    private float playerInput = 0;
    private float speed = 250;

Then make a `private Rigidbody2D` called `rb`. This is how we get the rigidbody from the player object and how we will apply the movement force to the player.

    private Rigidbody2D rb;

Move down to where `void Start()` is and inside the `{ }` we will get the Rigidbody2D component from out player object.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

Move over to `void Update()` and inside `{ }` we will set playerInput to get the the input of the `Horizontal axis`

    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");
    }

## 3. Swap player sprite

When the player decides to move they will find that the player sprite wont turn around and so will end up walking backwards. To change this we will make a function called `SwapSprite()`. We will also call this function at the bottom of Update().

    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");

        SwapSprite();
    }

    void SwapSprite()
    {

    }

Inside `SwapSprite` we will make an if statement seeing whether the player is pressing the right movement button. If they are playerInput will be `> 0` and the player will be flipped to face the right.

    if (playerInput > 0)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

We will now make an else if statement that will do the same as above but instead see whether the player is pressing the left movement button. If they are playerInput will be `< 0` and the player will be flipped to face the left.

    else if (playerInput < 0)
    {
        transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

## 4. Moving the player

Lastly we will now make the character move. We will do this by setting the `velocity` of `rb` to the `playerInput * speed * Time.fixedDeltaTime` inside `FixedUpdate()`. We use Time.fixedDeltaTime as it is not frame rate dependent and so will not make the player mover at a different speed at different frame rates.

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerInput * speed * Time.fixedDeltaTime, 0);
    }

All together you final code should look like the below.

    private float playerInput = 0;
    private float speed = 250;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");

        SwapSprite();
    }

    void SwapSprite()
    {
        if (playerInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        else if (playerInput < 0)
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerInput * speed * Time.fixedDeltaTime, 0);
    }

