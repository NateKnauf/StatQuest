using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public AudioClip death;
	public int power;
	public int enemyType;

	[SerializeField] GameObject goldParticles;
	[SerializeField] GameObject blackParticles;

	void Update(){
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Die ();
		}
	}

	public void Die(){
		Camera.main.GetComponent<AudioSource>().PlayOneShot(death);
		Instantiate(goldParticles, transform.position, Quaternion.identity);
		Instantiate(blackParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
