using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

	[SerializeField] Sprite[] sprites;
	public bool grass = false;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		if(grass){
			transform.position -= new Vector3(0, 2/16F,0);
		}
	}

	void Update(){
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy (gameObject);
		}
	}
}
