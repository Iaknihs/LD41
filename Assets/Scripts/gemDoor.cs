using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemDoor : MonoBehaviour {

	public GameObject controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.GetComponent<Score> ().gems > 1000000)
			Destroy (gameObject);
	}
}
