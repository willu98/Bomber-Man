using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDesigner_UI : MonoBehaviour
{
	private GameObject levelDesignerObject;
	private LevelDesigner  levelDesigner;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		levelDesignerObject = GameObject.Find("GameBoard");
		levelDesigner = levelDesignerObject.GetComponent<LevelDesigner> ();
	}

	/// <summary>
	///When click the Brick button
	/// </summary>
	public void ClickBrickBtn () 
	{
		levelDesigner.SetSelectedType (levelDesigner.GetBrick());
		Debug.Log ("Brick Clicked ");
	}
	/// <summary>
	///When click the Wall button
	/// </summary>
	public void ClickWallBtn ()
	{
		levelDesigner.SetSelectedType (levelDesigner.GetWall());
		Debug.Log ("Wall Clicked ");
	}
	
	/// <summary>
	///When click the Player button
	/// </summary>
	public void ClickPlayerBtn()
	{
		levelDesigner.SetSelectedType (levelDesigner.GetPlayer());
		Debug.Log ("Player Clicked ");
	}
	
	/// <summary>
	///When click the Enemy button
	/// </summary>
	public void ClickEnemyBtn()
	{
		levelDesigner.SetSelectedType(levelDesigner.GetEnemy());
		Debug.Log ("Enemy Clicked ");
	}
	
	/// <summary>
	///When click the Back button
	/// </summary>
	public void ClickBackButton()
	{
		//change game state; 
		Debug.Log ("Back Clicked ");
	}

	/// <summary>
	/// Clicks the clear button.
	/// </summary>
	public void ClickClearButton()
	{
		levelDesigner.SetSelectedType (levelDesigner.GetNo_Value ());
		Debug.Log ("Clear Clicked");
	}

	/// <summary>
	/// click the save button
	/// </summary>
	public void ClickSaveButton(GameObject inputPanel)
	{
//        inputPanel.SetActive(true);
//		levelDesigner.save = true;
		levelDesigner.SaveData();
	}

//    /// <summary>
//    /// click the enter button
//    /// </summary>
//    /// <param name="inputField"></param>gameobject input field
//    /// <param name="inputPanel"></param>gameobject input panel
//    public void ClickEnterBtn(InputField inputField)
//	{
//		levelDesigner.SetFileName (inputField.text);//change the file name
//		inputField.text = "";
//		levelDesigner.InputPanel.SetActive (false);
//
//        //if statement that determine should the program load or save data
//		if (levelDesigner.save)
//        {
//            levelDesigner.SaveData();
//        }
//		else if (levelDesigner.load)
//        {
//            levelDesigner.LoadData();
//        }
//	}

	/// <summary>
	/// Clicks the load button.
	/// </summary>
    public void ClickLoadButton(GameObject inputPanel)
	{
//        inputPanel.SetActive(true);//display the input field
//        levelDesigner.load = true;
		levelDesigner.LoadData();
	}
}
