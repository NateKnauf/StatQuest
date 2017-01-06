using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public int highscore;
	public int genAhead;
	public int chunkCount=10;
	public int lastChunk;
	public int lastlastChunk;

	public bool debug = false;

	public int gameState = 1;

	[SerializeField] GameObject deathScreen;
	[SerializeField] GameObject mainScreen;
	[SerializeField] GameObject gameScreen;
	[SerializeField] GameObject spikeWall;
	[SerializeField] Vector3 wallPos;

	[SerializeField] TextMesh scoreText;
	public float guiScale;

	public GUIStyle style;

	public bool firstTimePlaying = false;
	bool consent;
	float t;
	
	public float difficulty = 0F;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.F8)){
			//PlayerPrefs.SetInt("HasPlayedBefore", 0);
			//firstTimePlaying = true;
		}
		difficulty = PlayerPrefs.GetFloat("Difficulty");

		score = (int)Camera.main.transform.position.x;
		if(score > highscore){
			highscore = score;
		}

		scoreText.text = score.ToString();

		if(!debug){
			if(score+20 > genAhead){
				int selection = Random.Range(1,chunkCount+1);
				if(selection == lastChunk){
					selection += 1;
					if(selection>chunkCount){
						selection=1;
					}
				}
				if(selection == lastlastChunk){
					selection += 1;
					if(selection>chunkCount){
						selection=1;
					}
				}
				GameObject chunk = (GameObject) GameObject.Instantiate(Resources.Load ("Chunk" + selection.ToString()),new Vector3(genAhead,0,0),Quaternion.identity);
				genAhead += chunk.GetComponent<ChunkScript>().width;
				lastlastChunk = lastChunk;
				lastChunk = selection;
			}
		}else{
			difficulty = PlayerPrefs.GetFloat("Difficulty");
		}

	}

	void OnGUI(){
		if(gameState == 2){
			deathScreen.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
