using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	[SerializeField] bool isOpen = false;
	public bool big = false;
	float t = 0f;
	Vector3 origin;
	public Sprite openSprite;

	void Start(){
		origin = transform.position;
	}

	void Update(){
		if(isOpen){
			if(transform.childCount > 0){
				transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = openSprite;
			}
			if(big){
				if(t < 2){
					t += Time.deltaTime;
				}
			}else{
				if(t < 1){
					t += Time.deltaTime;
				}
			}
			transform.position = origin + new Vector3(0, t, 0);
		}

		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy (gameObject);
		}
	}

	public void Open(){
		isOpen = true;
	}
}
