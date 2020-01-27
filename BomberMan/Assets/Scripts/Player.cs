//Author: William Pu
//File Name: player.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This class manages the player and updates all
//             of the actions and movements of the player
//             of the player , the player has a controller and a 
//             movement class which
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //the players explosion
    public GameObject explosion;

    //the animator
    public Animator anim;

    //determines if the user's game is paused
    public bool IsPaused = false;
    //determines if the player is alive or not
    public bool IsPlayerActive = true;

    //the coordinates of the player on the board
    private Vector2 playerCoordinate;
    //the coordinate sof the bomb is ref to the game board
    private Vector2 bombCoordinates;

    //the input values  for the horizontal and vertical
    private float inputH;
    private float inputV;


    //INPUT
    //determines if the player is jumping
    private Controller controller;
    //determines if the left button is being clicked
    private bool isLeftMouseClick;
    //if both right buttons are being held down
    private bool isRightDown;
    //if both buttons are released
    private bool isReleased;



    //BOMB VARIABLES
    //the player bomb, the player only has one bomb
    private Bomb playerBomb;
    //determines if the player's bomb is activated
    private bool isBombActive;
    //the initial speed of the bomb
    private float bombInitialSpeed;
    //the increment at which the bomb speed is increased
    const float INCREMENT_BOMB_SPEED = 0.1f;
    //the maximum bomb speed
    const byte MAX_BOMB_SPEED = 5;
    //the bomb material
    public Material Metal;

    //const for zero
    const int NO_VALUE = 0;

    //the sensitivity of the rotation
    const float HORIZONTAL_SENSITIVITY = 2.0f;
    //the rotations of the player
    private float xRotation = NO_VALUE;


    //Text variables for UI
    public Text userScore;

    // Use this for initialization
    /// <summary>
    /// this subprogram initializes all the components 
    /// of the player before the game starts
    /// </summary>
    void Start()
    {
        //getting the player animator
        anim = GetComponent<Animator>();

        //initiallizing the controller
        controller = new Controller();

        //initial speed is set to 0
        bombInitialSpeed = NO_VALUE;
    }




    // Update is called once per frame
    /// <summary>
    /// updates the players actions and gets user input
    /// animates the player as well and moves the player
    /// and performs other actions based on user input
    /// </summary>
    void Update()
    {
        //CALCULATING THE PLAyers coordinates
        playerCoordinate.x = (int)(transform.position.x + 5);
        playerCoordinate.y = (int)(transform.position.z + 5);

        //rotating th eplayer model
        xRotation += HORIZONTAL_SENSITIVITY * Input.GetAxis("Mouse X");

        //transforming the roation of the user
        transform.eulerAngles = new Vector3(NO_VALUE, xRotation, NO_VALUE);

        //if the user presses p then the game is paused if the game is on
        //and vice versa
        if (Input.GetKeyDown(KeyCode.P))
        {
            IsPaused = !IsPaused;
        }


        //the player is only updated if the game is unppaused and the layer is still alive
        if (IsPlayerActive && !IsPaused)
        {
            //CHECKING FOR MOUSE INPUT
            //checking to see if both mouse buttons are being held down at the same time
            isRightDown = controller.ReturnMouseInput(true, false, false);

            //checking for left mouse clicking
            isLeftMouseClick = controller.ReturnMouseInput(false, true, false);

            //checking for the instant both mouse clicks are released at the same time
            isReleased = controller.ReturnMouseInput(false, false, true);


            //if both left and right buttons are being held down
            if (isRightDown && !isBombActive && bombInitialSpeed < MAX_BOMB_SPEED)
            {
                //the initial speed of the bomb is increased by 0.01 per frame
                bombInitialSpeed += INCREMENT_BOMB_SPEED;
            }



            //if the bomb is active then
            if (isBombActive)
            {
                //updating the bomb
                UpdateBomb();
            }



            //if the mous ebuttons are released then  and the bomb is not active
            if (isReleased && !isBombActive)
            {
                //a new bomb is genertaed by the player
                playerBomb = new Bomb(bombInitialSpeed, transform.position.x, transform.position.z, transform.position.y, xRotation, Metal, explosion);

                //updatingth bomb
                UpdateBomb();

                //the bomb speed starts at 0
                bombInitialSpeed = NO_VALUE;

            }



            //if the player presses space and if the player is not in the jumping mode already
            if (controller.UpdateKeyInput(KeyCode.Space, true) && !gameObject.GetComponent<Movement>().IsJumping)
            {
                //if space is pressed then the player jumps
                anim.Play("Jump", -1, NO_VALUE);
            }


            //getting horizontal and vertical input
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");

            //setting horizontal and vertical input for the animations
            anim.SetFloat("inputHorizontal", inputH);
            anim.SetFloat("inputVertical", inputV);


            GameObject.Find("Inventory_UI/Menu").

            //setting the player coordinates
            playerCoordinate = new Vector2(playerCoordinate.x, playerCoordinate.y);

        }
        //if the game is paused
        else if (IsPaused)
        {

        }
        //if the payer has died
        else if (!IsPlayerActive)
        {

        }
    }





    /// <summary>
    /// this subprogram updates the bomb that belongs to the player
    /// by calling the bomb update subprogrogram, alos determines if 
    /// the bomb is still active
    /// </summary>
    private void UpdateBomb()
    {
        //update the bomb
        playerBomb.Update();

        //checking to see if the bomb has exploded or not
        isBombActive = playerBomb.ReturnIsActive();

        //getting the bombs coordinates
        bombCoordinates = playerBomb.ReturnBombCoordinate();

        //if the bomb has exploded
        if (!isBombActive)
        {
            //going through each of the surrounding blocks of the bomb
            //going through each column around the bomb
            for (int column = (int)bombCoordinates.x - 1; column < (int)bombCoordinates.x + 2; column++)
            {

                //going through each row around the bomb
                for (int row = (int)bombCoordinates.y - 1; row < (int)bombCoordinates.y + 2; row++)
                {

                    //if the player is within the bomb blast radius
                    if (playerCoordinate == new Vector2(column, row))
                    {

                        //the player has died and can no lonhger play 
                        IsPlayerActive = false;


                        //calling the animation for the death of the player                                        
                        anim.Play("Dying", -1, 0f);

                    }
                }
            }
        }
    }


    /// <summary>
    /// returns the bombs x coordinate
    /// </summary>
    /// <returns>returns the bombs x coordinate</returns>
	public float ReturnBombX()
    {
        return playerBomb.transform.position.x;
    }


    /// <summary>
    /// returns thhe bombs z coordinate
    /// </summary>
    /// <returns>z coordinate is returned</returns>
	public float ReturnBombZ()
    {
        return playerBomb.transform.position.z;
    }



    //returns a bool for whether or not
    //the bomb is ticking or has exploded
    public bool ReturnIsBombActive()
    {
        return isBombActive;
    }
}
