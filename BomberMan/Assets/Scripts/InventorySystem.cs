using UnityEngine;
using System.Collections;

public class InventorySystem : MonoBehaviour
{
	SpecialItem specialItem = new SpecialItem();

	private int [] item = new int[2];//array variable that store what item does the play has
	private int selectedItemSlot = FIRST_ITEM;//currently selected item
	private int currenNumOfItem = 0;//the current number of item the player is carrying

	private const int MAX_ITEM = 2;//the maximun item every player can have
	private const int FIRST_ITEM = 0;//the first item in the inventory
	private const int SECOND_ITEM = 1;//the second item in the inventory

	void Update()
	{
		if (selectedItemSlot == FIRST_ITEM)
		{
			GameObject.Find ("Inventory_UI/First_Item").transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			GameObject.Find ("Inventory_UI/Second_Item").transform.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
		} 
		else if (selectedItemSlot == SECOND_ITEM)
		{
			GameObject.Find ("Inventory_UI/First_Item").transform.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
			GameObject.Find ("Inventory_UI/Second_Item").transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}

        //if the player presses the Q button then you toggle between special items
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchItem();
        }
	}

	/// <summary>
	/// when Pick Up new item
	/// </summary>
	/// <param name="newItem">New item.</param>
	public void AquireItem(int newItem)
	{
		if (currenNumOfItem < MAX_ITEM)
		{
			if ((newItem - item[currenNumOfItem]) != 1 || (item[currenNumOfItem] - newItem) != 1) 
			{
				item [currenNumOfItem] = newItem;
				currenNumOfItem++;
			}
		}
	}

	/// <summary>
	/// Drop the item 
	/// </summary>
	public void DropItem()
	{
		if (currenNumOfItem != 0) 
		{
			item [selectedItemSlot] = 0;
		}
	}

	/// <summary>
	/// Switchs the item.
	/// </summary>
	public void SwitchItem()
	{
		selectedItemSlot = (selectedItemSlot + 1) % 2;
	}

	/// <summary>
	/// Uses the item.
	/// </summary>
	public void UseItem()
	{
		specialItem.ItemFunction (item [selectedItemSlot]);
	}
}
