//Author: William Pu
//File Name: ChangeScene.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This class is an instance of a bomb and will
//             update the bombs movement and time remaining
//             and will complete diff actions depending on the 
//             the state of the bomb
using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    //the angle of trajectory of the bomb in radians, 25 degrees
    const float ANGLE_OF_TRAJECTORY_RAD = 0.4363323f;

    //the initial y velocities of the bomb
    private float initialYVelocity;

    //the horizontal velocity
    private float horizontalVelocity;
    //the initial and final horizontal in the x and z velocities of the bomb
    private float zVelocity;
    private float xVelocity;

    //the constant for gravity
    const float GRAVITY = -9.81f;

    //the timer for the bomb
    private float bombTime;

    //the max amount of time for the bomb is 5 seconds
    const float MAX_BOMB_TIME = 5;

    //const for zero
    const int NO_VALUE = 0;

    //the converter value for converting from degrees to radians
    const float CONVERT_TO_RAD = (Mathf.PI / 180f);


    //the change in displacement of the bomb
    //nin all three planes
    private Vector3 addBombX;
    private Vector3 addBombZ;
    private Vector3 addBombY;


    //creating a new bomb shape or sphere
	private GameObject bombSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //the bombs rigid body
    private Rigidbody bombBody;
    //the material renderer for the bomb
    private Renderer renderer;
    //the collider for the bomb
    private SphereCollider bombCollider;

    //a displacement calculator for the bomb in the y direction
    private CalculateDisplacement calculateY;

    //determines if the bomb is active
    private bool isBombActive;

    //the scaling of the bomb
    const float BOMB_SIZE = 0.5f;
    //the distance hte bomb is form the player
    const float DIS_FROM_PLAYER = 0.1f;

	//Used To Spawn Explosion
	private GameObject explosion1;

    //the coordinates of the bomb
    private Vector2 bombCoordinate;

    /// <summary>
    /// the constructor for the bomb, and initializing all components of the bomb
    /// </summary>
    /// <param name="initialVelocity">the initial velocity of hte bomb</param>
    /// <param name="currentX">the players x coordinate</param>
    /// <param name="currentZ">the players z coordinate</param>
    /// <param name="currentY">the players y coordinate</param>
    /// <param name="playerAngle">the angle in which the player is roated at</param>
    /// <param name="bombImg">the bomb material that is passe don from the player class/param>
	public Bomb(float initialVelocity, float currentX, float currentZ, float currentY, float playerAngle, Material bombImg, GameObject explosion)
    {
        //getting the cosine and sine of the player angle
        float sinePlayerAngle = Mathf.Sin(playerAngle * CONVERT_TO_RAD);
        float cosPlayerAngle = Mathf.Cos(playerAngle * CONVERT_TO_RAD);


        //the starting z and x coordinates of the bomb, so that the bomb is not in the player
        float initialBombX = (sinePlayerAngle * DIS_FROM_PLAYER) + currentX;
        float initialBombZ = (cosPlayerAngle * DIS_FROM_PLAYER) + currentZ;

        //the timer of the bob is set to zero
        bombTime = NO_VALUE;

        //the bomb is set to active
        isBombActive = true;

        //calculating the initial horizontal and y velocities of the player
        initialYVelocity = (Mathf.Cos(ANGLE_OF_TRAJECTORY_RAD) * initialVelocity);
        horizontalVelocity = (Mathf.Sin(ANGLE_OF_TRAJECTORY_RAD) * initialVelocity);

      
        //calculating the velocity of the bomb in the z direction
        xVelocity = (sinePlayerAngle * horizontalVelocity);
        //calculating the velocity of the bomb in the z direction
        zVelocity = (cosPlayerAngle * horizontalVelocity);        

        //initializing the y displacement calculator
        calculateY = new CalculateDisplacement(initialYVelocity);

        //scaling the bomb
        bombSphere.transform.localScale = new Vector3(BOMB_SIZE, BOMB_SIZE, BOMB_SIZE);

        //creating the location of the bomb suing the coordinates of the player
        bombSphere.transform.position = new Vector3(initialBombX, currentY + 0.4f, initialBombZ);

        //attaching a rigid body to the bomb
        bombBody = bombSphere.AddComponent<Rigidbody>();

        //attaching a collider for the bomb
        bombCollider = bombSphere.AddComponent<SphereCollider>();

        //getting the bomb sphre
        renderer = bombSphere.GetComponent<Renderer>();
    
        //applying the metal material to the bomb
        renderer.material = bombImg;

        //the bomb is set to neither kinematic and does not use
        //pre built gravity
        bombBody.isKinematic = false;
        bombBody.useGravity = false;

        //initializing the explosion for th ebomb
        explosion1 = explosion; 
    }


    // Use this for initialization
    void Start()
    {

    }




    /// <summary>
    /// returns a boolean based on whether or not the
    /// bomb is still active or not
    /// </summary>
    /// <returns>returns a true if the bomb has not exploded yet
    /// and a false if the bomb has exploded</returns>
    public bool ReturnIsActive()
    {
        //returning the state of the bomb
        return isBombActive;
    }



    /// <summary>
    /// returns the bombs coordinates, in refernce to the gsameboard
    /// </summary>
    /// <returns></returns>
    public Vector2 ReturnBombCoordinate()
    {
        //returning the bombs coordinates
        return bombCoordinate;
    }




    // Update is called once per frame
    /// <summary>
    /// THIS subprogram updates all aspects of the bomb is the bomb is still active
    /// otherwise the bomb is no longer active and that is returned to the player so
    /// a new bomb can be dropped
    /// </summary>
    public void Update()
    {
        //if the bomb has not exploded
        if (isBombActive)
        {            
            //getting the coordinates of bombis refernce to the gameboard
            bombCoordinate.x = (int)(bombSphere.transform.position.x + 5);
            bombCoordinate.y = (int)(bombSphere.transform.position.z + 5);


            //incrementing the bomb time
            bombTime += Time.deltaTime;



            //if the bomb has not come in contact with the floor yet
            if (bombSphere.transform.position.y >= 0.3f)
            {
                //updating the y component of the bomb
                calculateY.Update(GRAVITY);

                //getting the change in displacement of the bomb in the y direction
                addBombY = new Vector3(NO_VALUE, calculateY.ReturnCoordinate(), NO_VALUE);

                //calculating the chnage in displacement of the bomb
                addBombZ = new Vector3(NO_VALUE, NO_VALUE, (zVelocity * Time.deltaTime));

                //calculating the chnage in displacement of the bomb
                addBombX = new Vector3((xVelocity * Time.deltaTime), NO_VALUE, NO_VALUE);


                //changing the coordinates of the bomb
                bombSphere.transform.position += addBombY;
                bombSphere.transform.position += addBombZ;
                bombSphere.transform.position += addBombX;
            }
            else
            {
                //if the bomb has landed on the ground
                //freezing the position of the bomb
                bombBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

                //freezing the rotation of the bomb
                bombBody.freezeRotation = true;
            }



            //checking to see if the bomb is active
            if (bombTime >= MAX_BOMB_TIME)
            {
                //the bomb is no longer active
                isBombActive = false;
			
                //once the time surpasses the ttimer
                //the bomb is destroyed
                Destroy(bombSphere);

                //CALL PARTICLE SYSTEMM HERE
				Instantiate(explosion1,new Vector3(bombSphere.transform.position.x,bombSphere.transform.position.y,bombSphere.transform.position.z),new Quaternion(0,0,0,0));

                //BOOM SOUNDFX
            }


            //setting the bombs coordinate
            bombCoordinate = new Vector2(bombCoordinate.x, bombCoordinate.y); 
        }        
    }
}
