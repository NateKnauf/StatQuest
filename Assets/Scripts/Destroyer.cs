using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	[SerializeField] float t = 1F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		t-=Time.deltaTime;
		if(t<0){
			Destroy(gameObject);
		}
	}
}
