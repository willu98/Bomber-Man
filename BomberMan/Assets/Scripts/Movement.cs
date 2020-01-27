//Author: William Pu
//File Name: Movement.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This class updates all the movement of the character using several
//             equations of physics
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    //determines how much is added to the coordinates
    private Vector3 addX;
    private Vector3 addY;
    private Vector3 addZ;

    //DETERMINES IF THE PLAYER IS JUMPING
    public bool IsJumping;

    //determines if the user is accelerating or deccelerating in the z or x direction
    private bool isAcceleratingZFwd;
    private bool isAcceleratingXFwd;
    private bool isAcceleratingZBack;
    private bool isAcceleratingXBack;

    ////the array for the velocities in all 3 directions
    private CalculateDisplacement[] calculateDisplacement = new CalculateDisplacement[3];

    //CONSTANT FOR GRAVITY
    const float GRAVITY = -9.81f;

    //acceration speeds ajnd decelleration speeds
    const float SIDE_WAYS_ACCELERATION = 1;
    const float SIDE_WAYS_DECCELERATION = 2;

    //THE INITIAL JUMPING VELOCITY
    const float INITIAL_JUMP_VELOCITY = 4.2f;

    //the max speed of the platyer
    const int MAX_SPEED = 2;

    //the maximum player velocity if they are travelling in the x or z dirction
    //a max velocity of 2 units/ sec
    const int MAX_HORIZONTAL_VELOCITY = 2;

    //constant for no value
    const int NO_VALUE = 0;

    //the controller
    private Controller controller;



    // Use this for initialization
    /// <summary>
    /// initializing all components of the players movement
    /// </summary>
    public void Start()
    {
        //initializing the diffrent displacement calculations, each one calculates displacement within a different plane
        //for vertical mvement
        calculateDisplacement[0] = new CalculateDisplacement(INITIAL_JUMP_VELOCITY);
        //for movement in the z direction
        calculateDisplacement[1] = new CalculateDisplacement(NO_VALUE);
        //for movement in the x direction
        calculateDisplacement[2] = new CalculateDisplacement(NO_VALUE);

        //initializing the controller
        controller = new Controller();

    }



    /// <summary>
    /// returns a boolean for if the player is in
    /// the jumping state or not
    /// </summary>
    /// <returns></returns>
    public bool ReturnIsJumping()
    {
        //returns the boolean for jumping
        return IsJumping;
    }




    // Update is called once per frame
    /// <summary>
    /// this subprogram updates the coordinates of the player in all 3 planes, z, x, and y
    /// this subprogram takes user input and moves the charcter using different equation of physics
    /// 
    /// </summary>
    public void Update()
    {

        //if the game is not paused and if the player is alive
        if (!gameObject.GetComponent<Player>().IsPaused && gameObject.GetComponent<Player>().IsPlayerActive)
        {
            //only checking for jumping input if the player is not in the air
            if (!IsJumping)
            {
                //checking user input for jump
                IsJumping = controller.UpdateKeyInput(KeyCode.Space, true);

                if (IsJumping)
                {
                    //call sfx
                }

                //getting input for the z direction
                isAcceleratingZFwd = controller.UpdateKeyInput(KeyCode.W, false);
                isAcceleratingZBack = controller.UpdateKeyInput(KeyCode.S, false);


                //getting input for the x direction
                isAcceleratingXFwd = controller.UpdateKeyInput(KeyCode.D, false);
                isAcceleratingXBack = controller.UpdateKeyInput(KeyCode.A, false);               
            }


            //getting the displavement of the player in both the x and z direction
            HorizontalDisplacement(isAcceleratingZFwd, isAcceleratingZBack, calculateDisplacement[1]);
            HorizontalDisplacement(isAcceleratingXFwd, isAcceleratingXBack, calculateDisplacement[2]);



            //if the player is above the ground
            if (IsJumping)
            {
                //updating the displace emnt of the user
                calculateDisplacement[0].Update(GRAVITY);

                //getting the adding y
                addY = new Vector3(NO_VALUE, calculateDisplacement[0].ReturnCoordinate(), NO_VALUE);

                //increasing the players coordinate in the y direction
                transform.position += addY;

                //determines if the user is still in the air
                IsJumping = calculateDisplacement[0].ReturnIsJumping(transform.position.y);
            }



            //getting the adding y
            addZ = new Vector3(NO_VALUE, NO_VALUE, calculateDisplacement[1].ReturnCoordinate());
            addX = new Vector3(calculateDisplacement[2].ReturnCoordinate(), NO_VALUE, NO_VALUE);


            //increasing the players coordinate in the y direction
            transform.position += addZ;
            transform.position += addX;
        }
    }





    /// <summary>
    /// Gets the horizontal displacement of the user, in the x or z directoin
    /// </summary>
    /// <param name="fwdAccel">determines if the player is acceleratig fwds</param>
    /// <param name="backAccel">determines if the player is accelerating backwards</param>
    /// <param name="displacementCalculator">which displacement calculator is being used</param>
    private void HorizontalDisplacement(bool fwdAccel, bool backAccel, CalculateDisplacement displacementCalculator)
    {

        //if the player is accelerating fwds and hasnt reached a max velocity of 2
        if (fwdAccel && displacementCalculator.ReturnVelocity() < MAX_SPEED)
        {
            //updating the displace emnt of the user
            displacementCalculator.Update(SIDE_WAYS_ACCELERATION);
        }
        else if (!fwdAccel && displacementCalculator.ReturnVelocity() > NO_VALUE && !IsJumping)
        {
            //updating the displace emnt of the user
            displacementCalculator.Update(-SIDE_WAYS_DECCELERATION);
        }



        //if the player is acceleratting backwards and they are moving less than the max speed
        if (backAccel && displacementCalculator.ReturnVelocity() > -MAX_SPEED)
        {
            //updating the displace emnt of the user
            displacementCalculator.Update(-SIDE_WAYS_ACCELERATION);
        }
        //if the player is not accelerating backwards anfd they are still moving, they are deccelrating
        else if (!backAccel && displacementCalculator.ReturnVelocity() < NO_VALUE && !IsJumping)
        {
            //updating the displace emnt of the user
            displacementCalculator.Update(SIDE_WAYS_DECCELERATION);
        }

    }

}