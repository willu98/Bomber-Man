using UnityEngine;
using System.Collections;

public class DestractibleWall : MonoBehaviour {

	// Use this for initialization
	bool isWallDestroyed;
	float wallPositionX;
	float wallPositionZ;
	void Start () 
	{
		wallPositionX = transform.position.x;
		wallPositionZ = transform.position.z;
		isWallDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	public void destroyWall()
	{
		isWallDestroyed = true;
		// run wall destruction particle system
	}
	public void rebuildWall()
	{
		isWallDestroyed = false;
		//rebuild wall particleystem
	}
	public float returnX()
	{
		return wallPositionX;
	}
	public float returnZ()
	{
		return wallPositionZ; 
	}
	public bool IsWallDestroyed()
	{
		return isWallDestroyed;
	}
}
