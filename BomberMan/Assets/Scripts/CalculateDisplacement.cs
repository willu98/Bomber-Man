//Author: William Pu
//File Name: ChangeScene.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This is a displacement calculator that will calculate the 
//             displacement of the player along a single plane given the 
//             acceleration and initial velocity;
using UnityEngine;
using System.Collections;

public class CalculateDisplacement : MonoBehaviour
{
    //adding to the coordinate
    private float addCoordinate;

    //the final and initial velocities
    private float initialVelocity;
    private float finalVelocity;

    //determines the beginning speed of each type of move ment
    private float startSpeed;

    //cont for zero
    const int NO_VALUE = 0;




    /// <summary>
    /// constructor of the calculate displacement class of the player
    /// </summary>
    /// <param name="initialSpeed">the initial speed of the players movement</param>
    public CalculateDisplacement(float initialSpeed)
    {
        //getting the beginning speed of the player
        startSpeed = initialSpeed;

        //the players initial velocity is set to the starting velocity
        this.initialVelocity = startSpeed;
    }



    /// <summary>
    /// 
    /// </summary>
    public void Start()
    {
    }




    /// <summary>
    /// returns the velocity of the player
    /// </summary>
    /// <returns>a float value of the players speed or velocity</returns>
    public float ReturnVelocity()
    {
        //returning the velocity
        return initialVelocity;
    }





    /// <summary>
    /// returns the player's change in displacement
    /// </summary>
    /// <returns>the amount of displacement the player experiences</returns>
    public float ReturnCoordinate()
    {
        return addCoordinate;
    }




    /// <summary>
    /// determines if the player is in the jumping state or not
    /// if the player is in the air, they are in the jumping state, 
    /// otherwise they are not, also changes the initial jump speed 
    /// of the player once they land
    /// </summary>
    /// <param name="yCoordinate">the y coordinate of the player</param>
    /// <returns>a true if the player is still in the air and false if the player is on the floor</returns>
    public bool ReturnIsJumping(float yCoordinate)
    {
        //if the player is touching the ground
        if (yCoordinate <= NO_VALUE)
        {
            //resetting thejumping speed
            initialVelocity = startSpeed;

            //a false is returned
            return false;
        }
        else
        {
            //if the player is in the air then returns a true
            return true;
        }
    }




    // Update is called once per frame
    /// <summary>
    /// this subprogram calculates the displacement within a single frame given the acceleration
    /// </summary>
    /// <param name="acceleration"></param>
    public void Update(float acceleration)
    {
        //getting the final velocity
        finalVelocity = initialVelocity + (acceleration * Time.deltaTime);

        //the adding coordinate
        addCoordinate = ((finalVelocity + initialVelocity) / 2) * (Time.deltaTime);

        //the initial velocity is now equal to the final velocity
        initialVelocity = finalVelocity;

    }
}
