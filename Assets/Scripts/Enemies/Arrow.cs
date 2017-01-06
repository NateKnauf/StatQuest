using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	[HideInInspector] public float speed;
	[HideInInspector] public int power;
	[HideInInspector] public bool facingLeft;

	[SerializeField] GameObject particles;

	// Use this for initialization
	void Start () {
		if(!facingLeft){
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(facingLeft){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}
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
			}
		}

		Instantiate(particles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
