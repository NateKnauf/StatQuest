using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {

	public AudioClip clip;
	bool isOpen;
	bool opened;

	[SerializeField] GameObject door;
	[SerializeField] Sprite downSprite;
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy (gameObject);
		}

		if(!opened){
			if(isOpen){
				GetComponent<SpriteRenderer>().sprite = downSprite;
				opened = true;
				door.GetComponent<Door>().Open();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Player"){
			if(!c.GetComponent<PlayerMovement>().isHurt && !isOpen){
				isOpen = true;
				if(c.GetComponent<Rigidbody2D>().velocity.y < 0){
					c.GetComponent<PlayerMovement>().KnockBack(true, true);
				}
				Camera.main.GetComponent<AudioSource>().PlayOneShot(clip);
			}
		}
	}
}
