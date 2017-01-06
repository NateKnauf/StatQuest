using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

	[HideInInspector] public int power;

	[SerializeField] GameObject particles;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 vectorToTarget = target - transform.position;
		//float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		//transform.rotation =  Quaternion.Euler(Mathf.Atan2(vectorToTarget.y, vectorToTarget.x,0,0);

		//transform.position = Vector3.MoveTowards(transform.position, target, speed);
	}

	void OnTriggerEnter2D(Collider2D c){
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

				Instantiate(particles, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}else if(c.gameObject.layer == LayerMask.NameToLayer("Tile")){
			
			Instantiate(particles, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
