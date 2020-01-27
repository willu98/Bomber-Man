using UnityEngine;
using System;
using System.Collections;

public class LevelDesigner_ChangeBlock : MonoBehaviour 
{
	private LevelDesigner levelDesigner;

	//awake
	void Awake()
	{
		levelDesigner = GameObject.Find ("GameBoard").GetComponent<LevelDesigner> ();
	}

	//update per frame
	void Update()
	{
		Renderer renderer = gameObject.GetComponent<Renderer>();//simplify the color changing process

		if (levelDesigner.GetBlockType (Int32.Parse(gameObject.name.Substring (3, 1)), Int32.Parse(gameObject.name.Substring (1, 1))) == levelDesigner.GetBrick ()) 
		{
			renderer.material = levelDesigner.brickMaterial; //change the material of the cube to brick material
		}
		else if (levelDesigner.GetBlockType (Int32.Parse(gameObject.name.Substring (3, 1)), Int32.Parse(gameObject.name.Substring (1, 1))) == levelDesigner.GetWall()) 
		{
            renderer.material = levelDesigner.wallMaterial; //change the material of the cube to the wall material
		} 
		else if (levelDesigner.GetBlockType (Int32.Parse(gameObject.name.Substring (3, 1)), Int32.Parse(gameObject.name.Substring (1, 1))) == levelDesigner.GetPlayer() ) 
		{
			renderer.material = levelDesigner.playerMaterial;//change the block material to player material
		} 
		else if (levelDesigner.GetBlockType (Int32.Parse(gameObject.name.Substring (3, 1)), Int32.Parse(gameObject.name.Substring (1, 1))) == levelDesigner.GetEnemy()) 
		{
			renderer.material = levelDesigner.enemyMaterial;//change the cube material to enemy material
		}
		else if (levelDesigner.GetBlockType (Int32.Parse(gameObject.name.Substring (3, 1)), Int32.Parse(gameObject.name.Substring (1, 1))) == levelDesigner.GetNo_Value())
		{
			renderer.material = levelDesigner.emptyMaterial;//change the cube material to empty
		}
	}

	//when the mouse is click on the the cube object
	void OnMouseDown () 
	{
		if (levelDesigner.GetSelectedType () == levelDesigner.GetPlayer ()) 
		{  
			if (levelDesigner.GetNumOfPlayerBlock () < 4) 
			{
				if (levelDesigner.GetBlockType (Int32.Parse (gameObject.name.Substring (3, 1)), Int32.Parse (gameObject.name.Substring (1, 1))) != levelDesigner.GetPlayer ()) 
				{
					levelDesigner.SetNumOfPlayerBlock (levelDesigner.GetNumOfPlayerBlock () + 1);//increase the number of block that is player state
				}
				levelDesigner.SetBlockType (Int32.Parse (gameObject.name.Substring (3, 1)), //get the number of row
					Int32.Parse (gameObject.name.Substring (1, 1)), //get the number of coloumn
					levelDesigner.GetSelectedType ()); //get the current selectedType
			}
		} 
		else if (levelDesigner.GetBlockType (Int32.Parse (gameObject.name.Substring (3, 1)), Int32.Parse (gameObject.name.Substring (1, 1))) == levelDesigner.GetPlayer ()) 
		{
			levelDesigner.SetNumOfPlayerBlock (levelDesigner.GetNumOfPlayerBlock () - 1);//decrease the number of block that is player state
			//change the value in the 2d array that save the state of each block
			levelDesigner.SetBlockType (Int32.Parse (gameObject.name.Substring (3, 1)), //get the number of row
				Int32.Parse (gameObject.name.Substring (1, 1)), //get the number of coloumn
				levelDesigner.GetSelectedType ()); //get the current selectedType
		} 
		else 
		{
			//change the value in the 2d array that save the state of each block
			levelDesigner.SetBlockType (Int32.Parse (gameObject.name.Substring (3, 1)), //get the number of row
				Int32.Parse (gameObject.name.Substring (1, 1)), //get the number of coloumn
				levelDesigner.GetSelectedType ()); //get the current selectedType
		}

		Debug.Log ("click " + gameObject.name);
		Debug.Log ("R" + gameObject.name.Substring (3, 1) + "C" + gameObject.name.Substring (1, 1));
	}
}
