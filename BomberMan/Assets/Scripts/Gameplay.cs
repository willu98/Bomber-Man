using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class Gameplay : MonoBehaviour 
{
    private string filePath;
	private string fileName = "dank";
    private StreamReader inFile;

    private const int BRICK = 1;
    private const int WALL = 2;
    private const int PLAYER = 3;
    private const int ENEMY = 4;
    private const int NO_VALUE = 0;

    private const int ROW = 10; //row of the gameboard
    private const int COLOUMN = 10; //coloumn of the gameboard

    private int[,] blockType = new int[ROW, COLOUMN];//2d array store all the block's type

    public Material brickMaterial;
    public Material wallMaterial;
    public Material enemyMaterial;
    public Material emptyMaterial;

    //use this before initialization
    void Awake ()
    {
        //set the location of all the save files
		filePath = System.Reflection.Assembly.GetExecutingAssembly ().CodeBase;
        filePath = Path.GetDirectoryName(filePath);
        Debug.Log(filePath);
        filePath = filePath.Substring(6);
        filePath = filePath + @"\SaveFile\" + fileName + ".txt";
    }

	// Use this for initialization
	void Start ()
    {
        LoadData();

        for (int rowCount = 9; rowCount >= 0; rowCount--) //for loop that loop through every value
        {
            for (int coloumnCount = 0; coloumnCount < COLOUMN; coloumnCount++)
            {
                Renderer renderer = GameObject.Find("GameBoard/C" + (coloumnCount + 1) + "/C" + coloumnCount + "R" + rowCount).GetComponent<Renderer>();
                if (blockType[rowCount,coloumnCount] == BRICK)
                {
                    renderer.material = brickMaterial; //change the material of the cube to brick material
                }
                else if (blockType[rowCount,coloumnCount] == WALL)
                {
                    renderer.material = wallMaterial; //change the material of the cube to the wall material
                }
                else if (blockType[rowCount,coloumnCount] == PLAYER)
                {
                }
                else if (blockType[rowCount,coloumnCount] == ENEMY)
                {
                    renderer.material = enemyMaterial;//change the cube material to enemy material
                }
                else if (blockType[rowCount,coloumnCount] == NO_VALUE)
                {
                    Destroy(GameObject.Find("GameBoard/C" + (coloumnCount+ 1) + "/C" + coloumnCount + "R" + rowCount));
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Fuck me");
        //}
	}

    /// <summary>
    /// Load the Data, use streamReader variable to open the txt file and use
    /// for loop statement to go through every value in the 2D array and get value from
    /// the txt file
    /// </summary>
    public void LoadData()
    {

        //try catch statement that will try to load the file
        try
        {
            inFile = File.OpenText(filePath); //open txt file

            for (int rowCount = 9; rowCount >= 0; rowCount--) //for loop that loop through every value
            {
                for (int coloumnCount = 0; coloumnCount < COLOUMN; coloumnCount++)
                {
                    blockType[rowCount, coloumnCount] = Int32.Parse(inFile.ReadLine());
                }
            }

            inFile.Close(); //close the loading operation
			Debug.Log("file Loaded");
        }
        catch (FileNotFoundException FNO)
        {
            Debug.Log(FNO);
        }
        catch (IOException IO)
        {
            Debug.Log(IO);
        }

        //load = false;
    }
}
