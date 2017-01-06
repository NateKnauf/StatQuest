using UnityEngine;
using System.Collections;

public class Snail : MonoBehaviour {
	
	public float speed;
	public float gravity;
	public float power;

	bool fRight = true;
	float moveX;

	bool grounded;
	public Transform gCheck;
	float gRadius = 0.1f;
	
	public LayerMask g;

	// Update is called once per frame
	void FixedUpdate () {
		speed = 0.5F + PlayerPrefs.GetFloat("Difficulty")*1F;
		power = (int) 1 + PlayerPrefs.GetFloat ("Difficulty")*2;
		if(!grounded){
			Flip();
		}
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), 0.75f, g);
		if(hit.collider != null){
			Flip ();
		}
		
		if(fRight){
			moveX = speed;
		}else{
			moveX = -speed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, GetComponent<Rigidbody2D>().velocity.y);

		grounded = Physics2D.OverlapCircle(gCheck.position, gRadius, g);
		
		if(moveX > 0 && !fRight){
			Flip ();
		}else if(moveX < 0 && fRight){
			Flip ();
		}
	}
	
	void Flip(){
		fRight = !fRight;
		Vector3 s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}
