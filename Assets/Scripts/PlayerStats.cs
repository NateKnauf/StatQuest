using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public AudioClip clipHurt;
	public AudioClip clipDie;

	public bool invuln;
	public GameObject particles;

	[SerializeField] float invulnTimer;
	float t;

	[SerializeField] int health;

	[SerializeField] Texture2D[] hearts;

	GameController gc;

	bool dead;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindObjectOfType<GameController>();
		health = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if(t > 0){
			t -= Time.deltaTime;
			if(!dead){
				if(t%0.1F < 0.05F){
					GetComponent<SpriteRenderer>().enabled = false;
				}else{
					GetComponent<SpriteRenderer>().enabled = true;
				}
			}else{
				GetComponent<SpriteRenderer>().enabled = true;
			}
			if(t <= 0){
				GetComponent<SpriteRenderer>().enabled = true;
				invuln = false;
			}
		}

		if(transform.position.y <= -18f){
			Die ();
		}

		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Die();
		}

		if(Input.GetKeyDown(KeyCode.K)){
			Die ();
		}
	}

	public void TakeDamage(int damage){
		if(!invuln){
			health -= damage;

			if(health <= 0){
				health = 0;
				Die();
			}

			if(health > 6){
				health = 6;
			}

			if(damage > 0){
				GetComponent<AudioSource>().PlayOneShot(clipHurt);
				invuln = true;
				t = invulnTimer;
			}
		}
	}
	
	public void RestartGame(){
		if(dead){
			Application.LoadLevel(1);
		}
	}

	void Die(){
		if(!dead){
			GetComponent<AudioSource>().PlayOneShot(clipDie);
			health = 0;
			dead = true;
			GameObject.FindObjectOfType<GameController>().gameState = 2;
			Camera.main.GetComponent<CameraFollow>().target = Camera.main.GetComponent<CameraFollow>().empty.transform;
			Camera.main.GetComponent<CameraFollow>().staticMode = true;
			Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), Quaternion.identity);
			GetComponent<PlayerMovement>().enabled = false;
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<PlayerMovement>().knockback);
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<Animator>().SetBool("Hurt", true);
			GetComponent<Animator>().SetBool("Grounded", false);
		}
		//Destroy(gameObject);
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(-95, Screen.height - (6 + (8 * gc.guiScale)), 49 * gc.guiScale, 8 * gc.guiScale), hearts[health+4]);
	}
}
