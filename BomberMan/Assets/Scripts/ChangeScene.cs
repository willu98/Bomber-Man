//Author: William Pu
//File Name: ChangeScene.cs
//Project Name: Explode N' Go
//Craetion Date: December 17th, 2015
//Modification Date: Jan 20th, 2016
//Description: This program takes all button input form the user 
using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    //constant for the quit input
    const int QUIT = 5;

    // Update is called once per frame
    public void ChangeNewScene(int whichScene)
    {
        //if the quit button is clicked
        if (whichScene == QUIT)
        {
            //quit the game
            Application.Quit();
        }
        else
        {
            //changing the level/scene
            Application.LoadLevel(whichScene);
        }
    }
}
