# 10/10/2023

Bullet was not moving when the left mouse button was pressed and was getting an error about having no rigidbody. Fix was to add a rigidbody to the bullet prefab.

# 10/10/2023

Bullet was falling to the ground soon after being fired. Fixed by disabling gravity on the bullet prefabs rigidbody causing it to fly straight until it hit an object.

# 17/10/2023

Instantiated bullet would fire in the wrong direction. I thought the issue had to do with instantiating the bullet with the wrong rotation but found that shootPoint object was rotated incorrectly on the x-axis.

# 24/10/2023

Was getting the error, object reference not set to an instance of an object, when the player touches an item pickup. The problem was the ItemPickup script not getting public variables from the PlayerInventory script. Fixed by adding public GameObject in ItemPickup script and adding the player to it in the inspector, then getting PlayerInventory script using GetComponent.

# 14/11/2023

The turret on the player tank would rotate when the player rotated the tank body making the turret not aim at the centre of the screen. The issue was due to using localRotation which made the turret be affected by the rotation of the player tank body. Fixed by changing localRotation to rotation making the turret not be affected by the rotation of the player tank body. 

# 14/11/2023

Could not use GetComponent on bullet script when trying to get PlayerManager and EnemyTurret scripts of the object that collided with bullet. The issue was that I thought OnCollision worked similarly to OnTrigger which does not require you to add .gameObject. Fixed by reading Unity documentation on Collider and Collision. Then making changes to my code by adding gameObject in between the parameter and GetComponent.

# 21/11/2023

The player was able to look under the ground and flip the camera from looking too high and too low which broke the turning of the players tank turret and caused it to be inverted. The solution was to put a limit on the camera y axis rotation. Implemented this by using Mathf.Clamp and setting a minimum and maximum value for the rotation on the y axis.

# 21/11/2023

The mouse cursor would go off the screen when looking around, so when the player tries to shoot it would click off the game. Fixed by using Cursor.lockState and locking the cursor to the centre of the screen allowing the player to look around and shoot without clicking off the game.
