using UnityEngine;
using System.Collections;

public class DeadIfSpike : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy (gameObject);
		}
	}
}
