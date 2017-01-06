using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour {

	public AudioClip shot;
	public Transform arrowOrigin;
	public GameObject arrowObj;
	public float arrowSpeed;
	public int arrowPower;

	[SerializeField] bool facingLeft;
	//[SerializeField] float waitTimer;
	float t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < GameObject.Find("SpikeWall").transform.position.x + 0.85f){
			Destroy(gameObject);
		}

		if(t > 0){
			t -= Time.deltaTime;
		}

		if(t <= 0){
			LaunchArrow();
		}
	}

	void LaunchArrow(){
		Camera.main.GetComponent<AudioSource>().PlayOneShot(shot);
		GameObject arrow = (GameObject)Instantiate(arrowObj, arrowOrigin.position, Quaternion.identity);
		arrow.GetComponent<Arrow>().facingLeft = facingLeft;
		arrow.GetComponent<Arrow>().speed = 5F + PlayerPrefs.GetFloat("Difficulty")*5F;
		arrow.GetComponent<Arrow>().power = (int)( 1 + PlayerPrefs.GetFloat ("Difficulty")*2);

		t = 4F - PlayerPrefs.GetFloat("Difficulty")*3F;
	}
}
