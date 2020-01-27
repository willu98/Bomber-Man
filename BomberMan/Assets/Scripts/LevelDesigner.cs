using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class LevelDesigner : MonoBehaviour 
{
    //text object and its related variable
	private Text hudText;
	private Text messageText;
	private int numOfPlayerBlock;
	private int delayCount;
	private const int delay = 100;

    //each block type and currently selected type
    private int selecedType;
	private const int BRICK = 1;
	private const int WALL = 2;
	private const int PLAYER = 3;
	private const int ENEMY = 4;
	private const int NO_VALUE = 0;
	private const int MAX_PLAYER = 4;
	private const int ROW = 10; //row of the gameboard
	private const int COLOUMN = 10; //coloumn of the gameboard

	private int [,] blockType = new int[ROW, COLOUMN];//2d array store all the block's type

    //saving and loading related file
	private string filePath;
	private string fileName = "dank";
	private StreamWriter outFile;
	private StreamReader inFile;

    //block type material
	public Material brickMaterial;
    public Material wallMaterial;
    public Material playerMaterial;
    public Material enemyMaterial;
    public Material emptyMaterial;
	public GameObject InputPanel;
//	public bool save = false;
//	public bool load = false;

	// Use this for initialization
	void Start () 
	{
		numOfPlayerBlock = 0; //set the inital value for the number of player block
		hudText = GameObject.Find ("Level_Designer_UI/HUD_Message").GetComponent<Text> ();
		messageText = GameObject.Find ("Level_Designer_UI/Display_Message").GetComponent<Text> ();

		//set the location of all the save files
		filePath = System.Reflection.Assembly.GetExecutingAssembly ().CodeBase;
		filePath = Path.GetDirectoryName (filePath);
		filePath = filePath.Substring (6,21);
        filePath = filePath + @"\Assets\SaveFile\" + fileName + ".txt";
        Debug.Log(filePath);

		//set the inital value for the 2d array called blocktype
		for (int rowCount = 0; rowCount < ROW; rowCount ++) //for loop that loop through every value
		{
			for (int coloumnCount = 0; coloumnCount < COLOUMN; coloumnCount++)
			{
				blockType[rowCount,coloumnCount] = NO_VALUE;
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
        //display the text
		hudText.text = "Brick - breakable\nWall - harder to break\nPlayer - player inital spawn point\nEnemy - NPC inital Location";

        //if statement that determine when the text should disappear
		if (messageText.text != "") 
		{
			if (delay == delayCount)
			{
				delayCount = 0;
				messageText.text = "";
			}
			delayCount++;
		}
	}

	/// <summary>
	/// modifier for the variable selectedType
	/// </summary>
	/// <param name="newData">New data.</param> the new data
	public void SetSelectedType(int newData)
	{
		selecedType = newData;
	}

	/// <summary>
	/// modifier the variable numberOfPlayerBlock.
	/// </summary>
	/// <param name="newData">New data.</param> the new data
	public void SetNumOfPlayerBlock(int newData)
	{	
		numOfPlayerBlock = newData;
	}


	/// <summary>
	/// Sets the variable BlockType
	/// </summary>
	/// <param name="row">Row.</param>
	/// <param name="coloumn">Coloumn.</param>
	/// <param name="selectedType">Selected type.</param>
	public void SetBlockType (int row, int coloumn, int selectedType)
	{
		blockType [row, coloumn] = selecedType;
	}

    /// <summary>
    /// Sets the file Name
    /// </summary>
    /// <param name="newFileName"></param>// the new file name
    public void SetFileName(string newFileName)
    {
        fileName = newFileName;
        if (fileName != "")
        {
            filePath = filePath + @"\" + fileName + ".txt";
        }
        else
        {
            filePath = filePath + @"\map.txt";
        }
    }

	/// <summary>
	/// Gets the variable BlockType
	/// </summary>
	/// <returns>The block type.</returns>
	/// <param name="row">Row.</param>
	/// <param name="coloumn">Coloumn.</param>
	public int GetBlockType (int row, int coloumn)
	{
		return blockType [row, coloumn];
	}

	/// <summary>
	/// Gets the variable numberOfPlayerBlock.
	/// </summary>
	/// <returns>The number of player block.</returns>
	public int GetNumOfPlayerBlock()
	{
		return numOfPlayerBlock;
	}

	/// <summary>
	/// Gets the variable selectedType
	/// </summary>
	/// <returns>The selected type.</returns>
	public int GetSelectedType ()
	{
		return selecedType;
	}

	/// <summary>
	/// Gets the variable BRICK
	/// </summary>
	/// <returns>The brick.</returns>
	public int GetBrick()
	{
		return BRICK;
	}

	/// <summary>
	/// Gets the variable WALL.
	/// </summary>
	/// <returns>The wall.</returns>
	public int GetWall()
	{
		return WALL;
	}

	/// <summary>
	/// Gets the variable PLAYER.
	/// </summary>
	/// <returns>The player.</returns>
	public int GetPlayer()
	{
		return PLAYER;
	}

	/// <summary>
	/// Gets the ENEMY.
	/// </summary>
	/// <returns>The enemy.</returns>
	public int GetEnemy()
	{
		return ENEMY;
	}

	/// <summary>
	/// Gets the variable no_ value.
	/// </summary>
	/// <returns>The no_ value.</returns>
	public int GetNo_Value()
	{
		return NO_VALUE;
	}

	/// <summary>
	/// Gets the variable max player.
	/// </summary>
	/// <returns>The max player.</returns>
	public int GetMaxPlayer()
	{
		return MAX_PLAYER;
	}

	/// <summary>
	/// Gets the name of the file.
	/// </summary>
	/// <returns>The file name.</returns>
	public string GetFileName()
	{
		return fileName;
	}

	/// <summary>
	/// Saves the data. Using streamWriter variable to create text and edit the text file 
	/// and using a for loop to go through every value in the 2d array variable in blockType variable
	/// </summary>
	public void SaveData()
	{
        //display a text that wil promot the user to enter the name for the file the user about to save 
        messageText.text = "Please Enter the name for your file";

		//try catch statement that prevent the program from crashing and display error
		try
		{
			outFile = File.CreateText(filePath); //create the txt file
			for (int rowCount = 9; rowCount >= 0 ; rowCount --) //for loop that loop through every value
			{
				for (int coloumnCount = 0; coloumnCount < COLOUMN; coloumnCount++)
				{
					outFile.WriteLine(blockType[rowCount,coloumnCount]);
				}
			}
			outFile.Close(); //close all the stream writer operation

			messageText.text = "File Saved."; //display the operation message
		}
		catch (IOException ioE)//input and output exception
		{
			messageText.text = "ERROR! " + ioE;//display the operation message
		}
		catch (UnityException uE)//unity exception
		{
			messageText.text = "ERROR! " + uE;//display the operation message
		}
		//save = false;
	}

	/// <summary>
	/// Load the Data, use streamReader variable to open the txt file and use
	/// for loop statement to go through every value in the 2D array and get value from
	/// the txt file
	/// </summary>
	public void LoadData()
	{
        //display message that promt the user to enter the name they want to serach
        messageText.text = "Please Enter the file's name you want to load";

		//try catch statement that will try to load the file
		try
		{
			inFile = File.OpenText(filePath); //open txt file

			for (int rowCount = 9; rowCount >= 0 ; rowCount --) //for loop that loop through every value
			{
		 		for (int coloumnCount = 0; coloumnCount < COLOUMN; coloumnCount++)
				{
					blockType[rowCount,coloumnCount] = Int32.Parse(inFile.ReadLine ());
				} 
			}

			inFile.Close(); //close the loading operation

			messageText.text = fileName + "File Loaded."; //display the operation message
		}
		catch (FileNotFoundException)
		{
			messageText.text = "ERROR! File Not Found.";//display the operation message
		}
		catch (IOException ioE)
		{
			messageText.text = "ERROR! " + ioE;//display the operation message
		}

		//load = false;
	}
}
