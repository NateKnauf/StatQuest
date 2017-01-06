using UnityEngine;
using System.Collections;

public class ScreenPortionScript : MonoBehaviour {
	
	public float propX;
	public float propY;
	public bool square;
	
	// Use this for initialization
	void Start () {
		GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width*propX,Screen.height*propY);
		if(square){
			GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height*propY,Screen.height*propY);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
