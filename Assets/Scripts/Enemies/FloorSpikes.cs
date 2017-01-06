using UnityEngine;
using System.Collections;

public class FloorSpikes : MonoBehaviour {

	public int power;
	public GameObject particles;

	// Use this for initialization
	void Update () {
		power = (int) (1 + PlayerPrefs.GetFloat("Difficulty")*2);
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 1f){
			Die ();
		}
	}
	
	// Update is called once per frame
	void Die () {
		Instantiate(particles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnTriggerStay2D(Collider2D c){
		bool enemyRight;
		
		if(transform.position.x < c.transform.position.x){
			enemyRight = false;
		}else{
			enemyRight = true;
		}
		
		if(c.tag == "Player"){
			if(!c.GetComponent<PlayerStats>().invuln){
				c.GetComponent<PlayerStats>().TakeDamage(power);
				c.GetComponent<PlayerMovement>().KnockBack(false, enemyRight);
			}
		}
	}
}
