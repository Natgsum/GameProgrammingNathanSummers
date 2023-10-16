# CameraLockTutorial
This shows tutorial shows how to make a camera lockon to an object
## 1. Create a new scene
To begin this tutorial start by creating a new scene and name it `CameraLockOn`.

Create a 3D Cube and name it `Player`.

Repeat the above again and name this Cube `Enemy`.

Create a `Material` and name it `Green`. Then select the Material and change the `Albedo` to `Green`.

Repeat this step again and name this material `Red` and change its `Albedo` to `Red`.

Drag the `Green` material onto the `Player` Cube, and the `Red` material onto the `Enemy` Cube.

## 2. Create script

Create a new script called `LockOn` and drag it onto the `Main Camera`.

In this script we will make the Main Camera lock on and off of onto the nearest Enemy Cube when the left mouse button is pressed. We will make the script in two parts, first we will make the camera lock onto one target and later lock onto the closest target.

To begin we shall make `two public Transforms` called `player` and `enemy`. These variables will get the positions of the player and enemy.

    public Transform player;
    public Transform enemy;

Then make `two public floats` called `cameraSlack` and `cameraDistance`. These variables will dictate how much of a delay the camera has following the player and how far behind the player the camera is.

    public float cameraSlack;
    public float cameraDistance;

Lastly make a `private Vector3` and call it `pivotPoint`. This Vector3 will be used to make the camera follow the player.

    private Vector3 pivotPoint;

Now move over to where `void Start()` is and inside the `{ }` set `pivotPoint` to `transform.position`. This will get the current position of the camera when the scene starts.

    void Start()
    {
        pivotPoint = transform.position;
    }

Move over to `void Update()` and inside the `{ }` make a `Vector3` called `current` and set it to `pivotPoint`.

Make another `Vector3` called `target` and set it to `player.transform.position + Vector3.up`. This will get the location of the player and add 1 to the y axis.

Set pivotPoint to `Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack)`. This makes the camera move towards the player at a speed determined by cameraSlack.

    Vector3 current = pivotPoint;
    Vector3 target = player.transform.position + Vector3.up;
    pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

Set `transform.position` to `pivotPoint`. This sets the cameras position to pivotPoint.

    transform.position = pivotPoint;

Now we will make the camera look halfway between the player and the locked on enemy.

    transform.LookAt((enemy.position + player.position) / 2);

Set the cameras position `transform.position` to be behind the player at a distance set by cameraDistance.

    transform.position -= transform.forward * cameraDistance;

Now if we go back into unity we select the `Main Camera` and drag our objects into their respective variables and set our `Camera Slack` and `Camera Distance` to our desired delay and distance.

If we now press play and move the `Player Cube` around in scene view you will find that the camera is locked onto the `Enemy Cube`.

## 3. Adding locking on and off

We will now add a way for our player to lock on and off from the enemy.

Head back to the top of the script and add a new `public Transform` called `noLock`. This is the object our camera will look at when we are not locked on.

    public Transform nolock;

Go back to Unity and create an `empty` called `noLock` and position it infront of the `Player Cube`. Then select the `Main Camera` and drag noLock into the noLock Transform. Additionally if you dont want the player to start locked on to an enemy you can change the enemy Transform to noLock.

Make a `private bool` called `isLockedOn` and set it to `false`. This will be our way of telling if the player is locked onto an enemy or not.

    private bool isLockedOn = false;

Now start a new line at the bottom of our code in `void Update()` and make an `if` statement that sees if the `left mouse button` has been pressed and if the player is `locked on` to an enemy.

    if (Input.GetMouseButtonDown(0) && isLockedOn == true)
    {
    
    }

Inside this if statement we will set the `enemy` Transform to the `noLock` Transform. This will make our camera look at the empty noLock that we will create in unity in a bit.

    enemy = noLock.GetComponent<Transform>();

Then set `isLockedOn` to `false`. This will allow us to know that our player is not locked onto an enemy.

    isLockedOn = false;

We can also add `Debug.Log()` to be able to see when we are no longer locked onto an enemy.

    Debug.Log("Not Locked On");

Make an `else if` statement that sees if the `left mouse button` has been pressed and if the player is `not locked on` to an enemy.

    else if (Input.GetMouseButtonDown(0) && isLockedOn == false)
    {
    
    }

Inside this else if statement we will set the `enemy` Transform to the `enemy Cubes` Transform. This will make our camera lock on to the enemy Cube.

    enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();

Then set `isLockedOn` to `true`. This will allow us to know that our player is lockd onto an enemy.

    isLockedOn = true;

We can again add `Debug.Log()` to be able to see when we are locked onto an enemy.

    Debug.Log("Locked On");

At this point you should have code that looks some like this.

    public Transform player;
    public Transform enemy;
    public Transform noLock;
    public float cameraSlack;
    public float cameraDistance;
    private bool isLockedOn = false;


    private Vector3 pivotPoint;

    // Start is called before the first frame update
    void Start()
    {
        pivotPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = pivotPoint;
        Vector3 target = player.transform.position + Vector3.up;
        pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

        transform.position = pivotPoint;
        transform.LookAt((enemy.position + player.position) / 2);
        transform.position -= transform.forward * cameraDistance;
        if (Input.GetMouseButtonDown(0) && isLockedOn == true)
        {
            enemy = noLock.GetComponent<Transform>();
            isLockedOn = false;
            Debug.Log("Not Locked On");
        }
        else if (Input.GetMouseButtonDown(0) && isLockedOn == false)
        {
            //enemy = FindClosestEnemy().GetComponent<Transform>();
            enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
            isLockedOn = true;
            Debug.Log("Locked On");
        }

    }
    
## 4. Locking onto closest enemy

We will now add a way to lock onto the closet enemy when there are multiple enemies in a scene.

Create a function called `FindClosestEnemy`. This is where we will work out the closest enemy.

    public GameObject FindClosestEnemy()
    {

    }

Make a `list` of GameObjects called `gameObjects`. This is where we will store every game object with the tag enemy.

    GameObject[] gameObjects;

Add every GameObject with the tag `enemy` to `gameObjects`. This will add every enemy to our list from which we will calculate the closest.

    gameObjects = GameObject.FindGameObjectsWithTag("enemy");

Make a GameObject called `closestEnemy` and set it to `null`. This is where we will store the current closest enemy.

    GameObject closestEnemy = null;

Make a `float` called `distance` and set it to `Mathf.Infinity`. This will set out distance to the representation of infinity as any enemy found will be closer to the player than infinity.

    float distance = Mathf.Infinity;

Make a `Vector3` called `position` and set it to `transform.position`. This will get the position of our camera to be able to work out which enemy is closest.

    Vector3 position = transform.position;

Make a `foreach` loop which will go through all GameObjects in our gameObjects list. This will allow us to go through each GameObject store in our list to find out which one is closest.

    foreach (GameObject gameObject in gameObjects)
    {

    }

In this `foreach` loop make a `Vector3` called `difference` and set it to the `gameObject` position minus the cameras position. This will work out how far the enemy is from the camera.

    Vector3 difference = gameObject.transform.position - position;

Make a `float` called `currentDistance` and set it to the difference. This will save the current distance of the enemy object so we can compare other enemy object distances to it.

    float currentDistance = difference.magnitude;

Make an `if` statement to see wether the `currentDistance` is `< distance`. This will allows us to find out if one enemy object is closer than the current closest enemy object.

    if (currentDistance < distance)
    {

    }

Inside this `if` statement set `closestEnemy` to `gameObject` and set `distance` to `currentDistance`. This will set the new closest enemy object and set its distance to the camera as the new current smallest distance.

    closestEnemy = gameObject;
    distance = currentDistance;

Finally if we go outside after the `foreach` loop we will `return` `closestEnemy`

    return closestEnemy;

You code for this part should look like this.

    public GameObject FindClosestEnemy()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closestEnemy = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject gameObject in gameObjects)
        {
            Vector3 difference = gameObject.transform.position - position;
            float currentDistance = difference.magnitude;
            if (currentDistance < distance)
            {
                closestEnemy = gameObject;
                distance = currentDistance;
            }
        }
        return closestEnemy;
    }

Lastly if we go back up to our `else if` statement and change the line `enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();` to use our new `FindClosestEnemy` function.

    enemy = FindClosestEnemy().GetComponent<Transform>();

