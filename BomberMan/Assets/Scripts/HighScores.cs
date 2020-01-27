//Author: William Pu
//File Name: ChangeScene.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This class takes all the score sof the layer and 
//             sorts them from greatets to least with a bubble sort algorithm
using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour
{
    //the numbered scores of the players
    int[] highScores;

    //the scores of the player with the name in front
    string[] scoresName;

    //the names of the players
    string[] names;

    //constant for zero
    const int NO_VALUE = 0;



    /// <summary>
    /// the constructor for the high score board
    /// </summary>
    /// <param name="highScores">the numbered high scores of the players</param>
    /// <param name="names">the names of the players</param>
    public HighScores(int[] highScores, string[] names)
    {
        //getting the high scores
        this.highScores = highScores;

        //getting the names of the players
        this.names = names;
    }




    // Use this for initialization
    void Start()
    {

    }


    //returns the sorted list of scores along with the names
    public string[] ReturnScoresWithNames()
    {
        return scoresName;
    }


    // Update is called once per frame
    /// <summary>
    /// sorting the scores and getting the sorted array
    /// </summary>
   public void Update()
    {
        //getting the sorted version of the scores
        SortScores();

        //going ythrough ecah name
        for (int i = NO_VALUE; i < names.Length; i++)
        {
            //cxreating the score name, what will be displayed to the user
            scoresName[i] = i + ". " + names[i] + ": " + highScores[i];
        }
    }






    /// <summary>
    /// this subprogram sorts a list of player scores
    /// given an array of scores and sorts them from 
    /// least to greatest
    /// </summary>
    private void SortScores()
    {

        //variable to hold onto the temporary score
        int tempScore;



        //holds the temp name of a player
        string tempName;



        //going throuhg ecah of the scores
        for (int i = NO_VALUE; i < highScores.Length; i++)
        {


            //going through each of the scores
            for (int j = NO_VALUE; j < highScores.Length; j++)
            {


                //if the currently checked score is larger than the other checked score
                if (highScores[i] < highScores[j])
                {

                    //temp score is equal to the currently checked score
                    tempScore = highScores[i];
                    //temp name is equal to the currently check name
                    tempName = names[i];


                    //the checked score is equal to the next check score
                    highScores[i] = highScores[j];
                    //the checked names is equal to the next check names
                    names[i] = names[j];


                    //the next score is equal to the tmep score
                    highScores[j] = tempScore;

                    //the next names is equal to the tmep names
                    names[j] = tempName;
                }


            }


        }


    }

}
