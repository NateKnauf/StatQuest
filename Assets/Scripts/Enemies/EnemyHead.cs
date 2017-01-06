using UnityEngine;
using System.Collections;

public class EnemyHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		bool enemyRight;

		if(transform.position.x < c.transform.position.x){
			enemyRight = false;
		}else{
			enemyRight = true;
		}

		if(c.tag == "Player"){
			if(c.GetComponent<Rigidbody2D>().velocity.y < 0 && !c.GetComponent<PlayerMovement>().isHurt){
				GetComponentInParent<EnemyHealth>().Die();
				c.GetComponent<PlayerMovement>().KnockBack(true, enemyRight);
			}else{
				if(!c.GetComponent<PlayerStats>().invuln){
					c.GetComponent<PlayerStats>().TakeDamage(GetComponentInParent<EnemyHealth>().power);
					c.GetComponent<PlayerMovement>().KnockBack(false, enemyRight);
				}
			}
		}
	}
}
