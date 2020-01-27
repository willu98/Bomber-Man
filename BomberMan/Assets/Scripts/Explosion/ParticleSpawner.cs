using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject particle; 
	public GameObject blackSmoke; 
	//bool start = true;
	float time = 0;

	void Start () 
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i <= 500; i++) 
		{

			Instantiate (particle, new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Quaternion (Random.Range(-360,360), Random.Range(-360,360),Random.Range(-360,360),Random.Range(-360,360)));
		}
		for (int i = 0; i <= 100; i++) 
		{

			Instantiate (blackSmoke, new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Quaternion (Random.Range(-360,360), Random.Range(-360,360),Random.Range(-360,360),Random.Range(-360,360)));
		}
		Destroy (gameObject); 
	}
	//public void explode()
	//{
		//time = time + Time.deltaTime;
		//if (start == true) 
		//{
			
			//start = false; 
		//}
	//}
}
