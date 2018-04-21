using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public double gems;
	public float shovelMult;
	public float pickMult;

	public Text text;
	public Image shovel;
	public Image pick;

	private LinkedList<int> collected;

	// Use this for initialization
	void Start () {
		collected = new LinkedList<int>();
	}
	
	// Update is called once per frame
	void Update () {
		gems += ((collected.First.Equals(null)?0.0:0.05)
			*(collected.Contains(35)?shovelMult:1.0)
			*(collected.Contains(40)?pickMult:1.0)) 
			* Time.deltaTime;
		text.text = System.Convert.ToString (((float)((int)(gems*10)))/10);
		if (collected.Contains (35))
			shovel.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (40))
			pick.GetComponent<Image> ().color = Color.white;
	}

	public void addCollected(int itemID){
		collected.AddLast(itemID);
	}
}
