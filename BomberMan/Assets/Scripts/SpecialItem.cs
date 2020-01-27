using UnityEngine;
using System.Collections;

public class SpecialItem
{
	private const int EXPLOSION_EXPAND = 1;
	private const int SHORTEN_DETONATION = 2;
	private const int SPEED_UP = 3;
	private const int JUMP = 4;
	private const int EXTRA_BOMB = 5;
	private const int GOD_MODE = 6;

	/// <summary>
	/// Gets the EXPLOSIO_EXPAN.
	/// </summary>
	/// <returns>EXPLOSION_EXPAND</returns>
	public int GetEXPLOSION_EXPAND()
	{
		return EXPLOSION_EXPAND;
	}

	/// <summary>
	/// Gets the SHORTE_DETONATIO.
	/// </summary>
	/// <returns>SHORTEN_DETONATION.</returns>
	public int GetSHORTEN_DETONATION()
	{
		return SHORTEN_DETONATION;
	}
		
	/// <summary>
	/// Gets the SPEED_UP
	/// </summary>
	/// <returns>SPEED_UP</returns>
	public int GetSPEED_UP()
	{
		return SPEED_UP;
	}

	/// <summary>
	/// Gets the JUMP.
	/// </summary>
	/// <returns>JUMP</returns>
	public int GetJUMP()
	{
		return JUMP;
	}

	/// <summary>
	/// Gets the EXTRA_BOMB.
	/// </summary>
	/// <returns>EXTRA_BOMB</returns>
	public int GetEXTRA_BOMB()
	{
		return EXTRA_BOMB;
	}

	/// <summary>
	/// Gets the GOD_MODE
	/// </summary>
	/// <returns>GOD_MODE</returns>
	public int GetGOD_MODE()
	{
		return GOD_MODE;
	}

	public void ItemFunction(int numOfItem)
	{
		switch (numOfItem)
		{
		case EXPLOSION_EXPAND:
			Debug.Log ("Explosion expand");
			break;
		case SHORTEN_DETONATION:
			Debug.Log ("Shorten detonation time");
			break;
		case SPEED_UP:
			Debug.Log ("Speed up");
			break;
		case JUMP:
			Debug.Log ("Jump ability");
			break;
		case EXTRA_BOMB:
			Debug.Log ("Extra bomb");
			break;
		case GOD_MODE:
			Debug.Log ("God mode enable");
			break;
		}
	}
}
