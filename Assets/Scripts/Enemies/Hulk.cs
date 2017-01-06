using UnityEngine;
using System.Collections;

public class Hulk : MonoBehaviour {

	public float speed;
	public float spearSpeed;
	public int spearPower;
	public float gravity;
	public int power;
	public float accuracy;

	public Vector3 target;
	public GameObject spearObj;
	public Transform spearOrigin;
	public float spearFrequency;
	float t;
	float ft;

	Animator anim;

	bool fRight = true;
	float moveX;
	
	bool grounded;
	public Transform gCheck;
	float gRadius = 0.1f;
	
	public LayerMask g;

	void Start(){
		anim = GetComponentInChildren<Animator>();
		target = GameObject.FindGameObjectWithTag("Player").transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		speed = 1 + PlayerPrefs.GetFloat("Difficulty")*0.5F;
		power = (int)( 1 + PlayerPrefs.GetFloat ("Difficulty")*2);
		spearPower = (int)( 1 + PlayerPrefs.GetFloat ("Difficulty")*2);
		spearSpeed = 2.5F + PlayerPrefs.GetFloat("Difficulty")*5F;
		spearFrequency = 2F - PlayerPrefs.GetFloat("Difficulty")*1.5F;
		accuracy = 0.02F + PlayerPrefs.GetFloat("Difficulty")*0.08F;
		if(GameObject.FindGameObjectWithTag("Player") != null){
			target = Vector3.Lerp(target, GameObject.FindGameObjectWithTag("Player").transform.position, accuracy);
		}

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

		if(ft > 0){
			ft -= Time.deltaTime;
		}else{
			anim.SetBool("Firing", false);
		}
		
		if(t > 0){
			t -= Time.deltaTime;
		}else{
			if(fRight && transform.position.x-target.x < 0){
				anim.SetBool("Firing", true);
				ft = 0.35f;
				ThrowSpear();
			}else if(!fRight && transform.position.x-target.x > 0){
				anim.SetBool("Firing", true);
				ft = 0.35f;
				ThrowSpear();
			}
		}

		//Debug.Log (target);
	}
	
	void Flip(){
		fRight = !fRight;
		Vector3 s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

	void ThrowSpear(){

		GameObject spear = (GameObject)Instantiate(spearObj, spearOrigin.position, Quaternion.identity);
		spear.GetComponent<Rigidbody2D>().velocity = (target - spear.transform.position).normalized*spearSpeed;
		spear.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((target - spear.transform.position).y,(target - spear.transform.position).x)*180F/Mathf.PI+180F);
		spear.GetComponent<Spear>().power = spearPower;

		t = spearFrequency;
	}
}
