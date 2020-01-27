using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	// Use this for initialization
	float xValue;
	private int position;
	float speed = 0;
	float zValue = 0;
	float aValue = 0;
	float yValue;
	float framesPassed = 0;
	private bool startExplosion = false; 
	public BrickSpawner brickSpawner; 

	void Start () 
	{
		speed = Random.Range (0.15f, 0.25f);
		zValue = Random.Range (-0.3f,0.3f);
		aValue = Random.Range (0.02f, 0.045f);
		yValue = transform.position.y;
		xValue = transform.position.x;
	}

	// Update is called once per frame
	void Update () 
	{
		if (brickSpawner.startExplosion() == true) 
		{
			framesPassed++;
			if (framesPassed > 30)
			{
				if (transform.position.y > -4) 
				{
					xValue = xValue + speed;
					transform.position = new Vector3 (xValue, yValue + (-aValue * Mathf.Pow (xValue - 7, 2) + 1), transform.position.z);
					transform.Translate (0, 0, zValue);
					transform.Rotate (Random.Range (0, 6), Random.Range (0, 6), Random.Range (0, 6));
				}
				else 
				{
					Destroy (gameObject);
				}

			}
		}
	}
	public void StartExplosion(bool explosionBool)
	{
		startExplosion = explosionBool; 
	}
}
