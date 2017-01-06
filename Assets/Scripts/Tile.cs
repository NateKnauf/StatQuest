using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public AudioClip breakClip;

	bool left = false;
	bool right = false;
	bool top = false;
	bool down = false;

	public Sprite[] tiles;
	public LayerMask tileMask;

	public GameObject particles;

	// Use this for initialization
	void Start () {
		if(Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1f, tileMask)){
			left = true;
		}

		if(Physics2D.Raycast(transform.position, new Vector2(1, 0), 1f, tileMask)){
			right = true;
		}

		if(Physics2D.Raycast(transform.position, new Vector2(0, 1), 1f, tileMask)){
			top = true;
		}

		if(Physics2D.Raycast(transform.position, new Vector2(0, -1), 1f, tileMask)){
			down = true;
		}

		AssignTexture(GetID());
	}

	void Update(){
		if(GameObject.Find("SpikeWall") != null){
			float swX = GameObject.Find("SpikeWall").transform.position.x + 0.75f;

			if(transform.position.x <= swX){
				Kill ();
			}
		}
	}

	void AssignTexture(string id){
		switch(id){
		case "0000":
			GetComponent<SpriteRenderer>().sprite = tiles[14];
			break;

		case "1000":
			GetComponent<SpriteRenderer>().sprite = tiles[9];
			break;

		case "0100":
			GetComponent<SpriteRenderer>().sprite = tiles[7];
			break;

		case "0010":
			GetComponent<SpriteRenderer>().sprite = tiles[15];
			break;

		case "0001":
			GetComponent<SpriteRenderer>().sprite = tiles[3];
			break;

		case "1100":
			GetComponent<SpriteRenderer>().sprite = tiles[8];
			break;

		case "1010":
			GetComponent<SpriteRenderer>().sprite = tiles[12];
			break;

		case "0101":
			GetComponent<SpriteRenderer>().sprite = tiles[0];
			break;

		case "1001":
			GetComponent<SpriteRenderer>().sprite = tiles[2];
			break;

		case "1110":
			GetComponent<SpriteRenderer>().sprite = tiles[11];
			break;

		case "1101":
			GetComponent<SpriteRenderer>().sprite = tiles[1];
			break;

		case "1111":
			GetComponent<SpriteRenderer>().sprite = tiles[5];
			break;

		case "0111":
			GetComponent<SpriteRenderer>().sprite = tiles[4];
			break;

		case "1011":
			GetComponent<SpriteRenderer>().sprite = tiles[6];
			break;

		case "0011":
			GetComponent<SpriteRenderer>().sprite = tiles[13];
			break;

		case "0110":
			GetComponent<SpriteRenderer>().sprite = tiles[10];
			break;


		}
	}

	string GetID(){
		int c1 = BoolToInt(left);
		int c2 = BoolToInt(right);
		int c3 = BoolToInt(top);
		int c4 = BoolToInt(down);

		string s = c1.ToString() + c2.ToString() + c3.ToString() + c4.ToString();

		return s;
	}

	int BoolToInt(bool b){
		if(b){
			return 1;
		}else{
			return 0;
		}
	}

	void Kill(){
		Camera.main.GetComponent<AudioSource>().PlayOneShot(breakClip, 0.5f);
		Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f), Quaternion.identity);
		Destroy(gameObject);
	}
}
