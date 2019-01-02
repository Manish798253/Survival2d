using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class goli : MonoBehaviour {
	private float maxtime;float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log ("maxtime: " + maxtime);
		time = time + Time.deltaTime;
		if(time>=maxtime)
			Destroy(gameObject);
		
	}
	public void set(float max)
	{
		maxtime = max;	
	}
}
