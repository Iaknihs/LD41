﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public double gems;
	public double baseRate;

	public Text text;
	public Image pick;

	private LinkedList<int> collected;

	// Use this for initialization
	void Start () {
		collected = new LinkedList<int>();
	}
	
	// Update is called once per frame
	void Update () {
		gems += ((collected.Contains(35)?baseRate:0)) * Time.deltaTime;
		text.text = System.Convert.ToString (((float)((int)(gems*10)))/10);
		if (collected.Contains (35))
			pick.GetComponent<Image> ().color = Color.white;
	}

	public void addCollected(int itemID){
		collected.AddLast(itemID);
	}
}