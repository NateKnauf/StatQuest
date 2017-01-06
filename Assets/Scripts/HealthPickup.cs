using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public AudioClip pickup;

	public float prob;
	private float foundVal;

	[SerializeField] GameObject particles;
	bool isPickedUp;
	public int power;
	[SerializeField] Sprite empty;

	Animator anim;

	// Use this for initialization
	void Start () {
		foundVal = Random.Range(0F, 1F);
		anim = GetComponent<Animator>();
		transform.position -= new Vector3(0, 1/8F, 0);
	}
	
	// Update is called once per frame
	void Update () {
		power = 5;
		prob = PlayerPrefs.GetFloat("Difficulty")*0.75F;
		if(foundVal < prob){
			Destroy(gameObject);
		}
		anim.SetBool("PickedUp", isPickedUp);

		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy (gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D c){
		if(!isPickedUp){
			if(c.tag == "Player"){
				if(!c.GetComponent<PlayerStats>().invuln){
					Camera.main.GetComponent<AudioSource>().PlayOneShot(pickup);
					c.GetComponent<PlayerStats>().TakeDamage(-power);
					Instantiate(particles, transform.position, Quaternion.identity);
					GetComponent<SpriteRenderer>().sprite = empty;
					isPickedUp = true;
				}
			}
		}
	}
}
