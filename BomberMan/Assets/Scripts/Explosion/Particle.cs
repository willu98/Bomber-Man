using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	// Use this for initialization
	float time = 0;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		time = time + Time.deltaTime;

		if (time <= 0.2f) 
		{
			transform.Translate (0, 0.06f, 0);
			transform.localScale += new Vector3 (0.012f, 0.012f, 0.012f);
		}
		if (time >= 0.2f) 
		{
			transform.Translate (0, 0.015f, 0);
			transform.localScale += new Vector3 (0.005f, 0.005f, 0.005f);
		}	
		if (time >= 0.3f) 
		{
			transform.localScale += new Vector3 (-0.015f, -0.015f, -0.015f);
		}	
		if (time >= 0.4f) 
		{
			Destroy (gameObject);
		}	
	}
}
