using UnityEngine;
using System.Collections;

public class BrickSpawner : MonoBehaviour {

	public BrickScript[] brick;
	private  Quaternion NO_ROATION = new Quaternion (0, 0, 0, 0); 
	private bool runAnimiation = false;  
	//private  Vector3 objectPosition;  
	// Use this for initialization
	void Start () 
	{
		//objectPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Instantiate (brick[0], new Vector3 (transform.position.x,transform.position.y, transform.position.z), NO_ROATION);
		Instantiate (brick[1], new Vector3 (transform.position.x,transform.position.y, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[2] , new Vector3 (transform.position.x+0.5f,transform.position.y, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[3] , new Vector3 (transform.position.x + 0.5f,transform.position.y, transform.position.z), NO_ROATION);
		Instantiate (brick[4] , new Vector3 (transform.position.x,transform.position.y+0.33f, transform.position.z), NO_ROATION);
		Instantiate (brick[5] , new Vector3 (transform.position.x,transform.position.y+0.33f, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[6] , new Vector3 (transform.position.x+0.5f,transform.position.y+0.33f, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[7] , new Vector3 (transform.position.x + 0.5f,transform.position.y+0.33f, transform.position.z), NO_ROATION);
		Instantiate (brick[8] , new Vector3 (transform.position.x,transform.position.y+0.66f, transform.position.z), NO_ROATION);
		Instantiate (brick[9] , new Vector3 (transform.position.x,transform.position.y+0.66f, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[10] , new Vector3 (transform.position.x+0.5f,transform.position.y+0.66f, transform.position.z+0.5f), NO_ROATION);
		Instantiate (brick[11], new Vector3 (transform.position.x + 0.5f,transform.position.y+0.66f, transform.position.z), NO_ROATION);
		//Destroy (GameObject.Find ("Brick(Clone)")); 
		//Destroy (GameObject.Find ("Brick(Clone)"));

	}

	// Update is called once per frame
	void Update () 
	{
		//if (runAnimiation == true) 
		//{
	//		for (int i = 0; i < 12; i++) 
	//		{
	//			Destroy (GameObject.Find ("Brick(Clone)"));
	//			brick [i].StartExplosion (true); 
	//		}

	//		brick.StartExplosion (true); 
	//		Instantiate (brick[0], new Vector3 (transform.position.x,transform.position.y, transform.position.z), NO_ROATION);
	//		Instantiate (brick[1], new Vector3 (transform.position.x,transform.position.y, transform.position.z+0.5f), NO_ROATION);
	// 		Instantiate (brick[2] , new Vector3 (transform.position.x+0.5f,transform.position.y, transform.position.z+0.5f), NO_ROATION);
	//		Instantiate (brick[3] , new Vector3 (transform.position.x + 0.5f,transform.position.y, transform.position.z), NO_ROATION);
	//		Instantiate (brick[4] , new Vector3 (transform.position.x,transform.position.y+0.33f, transform.position.z), NO_ROATION);
	//		Instantiate (brick[5] , new Vector3 (transform.position.x,transform.position.y+0.33f, transform.position.z+0.5f), NO_ROATION);
	//		Instantiate (brick[6] , new Vector3 (transform.position.x+0.5f,transform.position.y+0.33f, transform.position.z+0.5f), NO_ROATION);
	//		Instantiate (brick[7], new Vector3 (transform.position.x + 0.5f,transform.position.y+0.33f, transform.position.z), NO_ROATION);
	//		Instantiate (brick[8] , new Vector3 (transform.position.x,transform.position.y+0.66f, transform.position.z), NO_ROATION);
	//		Instantiate (brick[9] , new Vector3 (transform.position.x,transform.position.y+0.66f, transform.position.z+0.5f), NO_ROATION);
	//		Instantiate (brick[10] , new Vector3 (transform.position.x+0.5f,transform.position.y+0.66f, transform.position.z+0.5f), NO_ROATION);
	//		Instantiate (brick[11] , new Vector3 (transform.position.x + 0.5f,transform.position.y+0.66f, transform.position.z), NO_ROATION);
	//		runAnimiation = false;
		//}
	}
	public void DestroyWall(bool start)
	{
		runAnimiation = start; 
	}
	public float returnX()
	{
		return transform.position.x;
	}
	public float returnZ()
	{
		return transform.position.z; 
	}
	public bool startExplosion()
	{
		return runAnimiation; 
	}
}
