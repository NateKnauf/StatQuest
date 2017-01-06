using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public AudioClip clipJump;

	public float speed;
	public float jumpForce;
	bool fRight = true;

	Animator anim;

	bool grounded;
	public Transform gCheck;
	float gRadius = 0.2f;
	
	public LayerMask g;

	public float knockback;
	[SerializeField] float kbTimer;
	public bool isHurt = false;
	float t;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(t > 0){
			t -= Time.deltaTime;
			isHurt = true;
			anim.SetBool("Hurt", true);
			if(t <= 0){
				anim.SetBool("Hurt", false);
				isHurt = false;
			}
		}

		if(grounded && Input.GetButtonDown("Jump") && !isHurt){
			GetComponent<AudioSource>().PlayOneShot(clipJump);
			anim.SetBool("Grounded", false);
			grounded = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
		}
		
		if(Application.isMobilePlatform){
			if(CrossPlatformInputManager.GetAxisRaw("Vertical") < 0 && GetComponent<Rigidbody2D>().velocity.y > -jumpForce/2){
				//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpForce/2);
			}
		}else{
			if(Input.GetAxisRaw("Vertical") < 0 && GetComponent<Rigidbody2D>().velocity.y > -jumpForce/2){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpForce/2);
			}
		}
	}
	
	public void Jump(){
		if(grounded && !isHurt){
			GetComponent<AudioSource>().PlayOneShot(clipJump);
			anim.SetBool("Grounded", false);
			grounded = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
		}else if(GetComponent<Rigidbody2D>().velocity.y > -jumpForce/2){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpForce/2);
		}
	}

	void FixedUpdate () {
		//Define grounding and set animation parameters
		grounded = (Physics2D.OverlapCircle(gCheck.position, gRadius, g)) || (Physics2D.OverlapCircle(gCheck.position, gRadius, LayerMask.NameToLayer("Spikes")) && GetComponent<PlayerStats>().invuln);
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Y Speed", GetComponent<Rigidbody2D>().velocity.y);
		
		
		//Moving left-right and animation params
		float moveX;
		if(Application.isMobilePlatform){
			moveX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		}else{
			moveX = Input.GetAxisRaw("Horizontal");
		}

		if(!isHurt){
			anim.SetFloat("X Speed", Mathf.Abs(moveX));
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, GetComponent<Rigidbody2D>().velocity.y);
		}

		//flip for direction
		if(moveX > 0 && !fRight){
			Flip ();
		}else if(moveX < 0 && fRight){
			Flip ();
		}
	}
	//flip the character to reflect the facing direction
	void Flip(){
		fRight = !fRight;
		Vector3 s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

	public void KnockBack(bool canControl, bool enemyRight){
		if(canControl){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, knockback);
		}else if(!canControl && enemyRight){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback/2, knockback/2);
			t = kbTimer;
		}else if(!canControl && !enemyRight){
			GetComponent<Rigidbody2D>().velocity = new Vector2(knockback/2, knockback/2);
			t = kbTimer;
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		bool enemyRight;

		if(c.gameObject.transform.position.x < transform.position.x){
			enemyRight = false;
		}else{
			enemyRight = true;
		}

		if(c.gameObject.tag == "Enemy" && !GetComponent<PlayerStats>().invuln){
			GetComponent<PlayerStats>().TakeDamage(c.gameObject.GetComponent<EnemyHealth>().power);
			KnockBack(false, enemyRight);
		}

		if(c.gameObject.tag == "Spike Wall"){
			GetComponent<PlayerStats>().TakeDamage(10);
			isHurt = true;
			KnockBack(false, false);
		}
	}
}
