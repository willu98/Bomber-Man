using UnityEngine;
using System.Collections;

public class SmokeParticle : MonoBehaviour {

	// Use this for initialization
	float time = 0;

	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		time = time + Time.deltaTime;
		if(time < 0.39f)
		{
		transform.Translate (0, 0.02f, 0);
		transform.localScale += new Vector3 (0.015f, 0.015f, 0.015f);
		}	
		if(time >= 0.39f)
		{
			//transform.rotation = new Quaternion (Random.Range(0,40), Random.Range(0,40), Random.Range(0,40), Random.Range(0,40));
			//transform.Translate (0, 0.6f, 0);
			transform.Translate (0, 0.015f, 0);
			transform.localScale += new Vector3 (-0.01f, -0.01f, -0.01f);
			//transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
		}
		//if(time >= 1)
		//{
			//transform.Translate (0, 0.1f, 0);
			//transform.localScale += new Vector3 (-0.05f, -0.05f, -0.05f);
		//}
		if(time > 0.7f)
		{
			Destroy (gameObject);
		}

	}
}
