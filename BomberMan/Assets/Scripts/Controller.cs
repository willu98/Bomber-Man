//Author: William Pu
//File Name: ChangeScene.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This is the controller of the game and takes user input 
//             from both keyboard and mouse input. 
using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    /// <summary>
    /// this subprogram takes keyboard input from the user
    /// </summary>
    /// <param name="whichKey">the checked key to see if it was pressed on</param>
    /// <param name="oneInput">determines if the variable is determined by one press or continuous input</param>
    /// <returns>a true if the button is being pressed and a false if there is no key input</returns>
    public bool UpdateKeyInput(KeyCode whichKey, bool oneInput)
    {
        //for input that is only one key stroke
        if (oneInput)
        {

            //if the user presses a then the gamne unpauses
            if (Input.GetKeyDown(whichKey))
            {

                //returns true if the key was pressed
                return true;

            }
            else
            {

                //if any thing else
                return false;

            }

        }
        //if the commmand has continuous input
        else if (!oneInput)
        {

            //if the user presses a then the gamne unpauses
            if (Input.GetKey(whichKey))
            {

                //returns true if the key was pressed
                return true;

            }
            else
            {

                //if any thing else
                return false;

            }
        }


        //base case, returns true
        return true;
    }



    /// <summary>
    /// returns a boolean based on mouse input
    /// </summary>
    /// <returns>returns a true if any of the below mouse input statements are true, 
    /// otherwise a fals is returned</returns>
    public bool ReturnMouseInput(bool getBothDown, bool getLeft, bool getReleased)
    {
        //if both the right mouse buttons are being helkd down then
        if (Input.GetMouseButton(1) && getBothDown)
        {
            //return true
            return true;
        }
        else if (Input.GetMouseButtonDown(0) && getLeft)
        {
            //if the left mouse button is being cloicked then return true
            return true;
        }
        else if (Input.GetMouseButtonUp(1) && getReleased)
        {
            //if both the right mouse buttons are released then
            return true;
        }
        else
        {
            //if none of the above actions are completed then false is returned for input
            return false;
        }
    }
}
