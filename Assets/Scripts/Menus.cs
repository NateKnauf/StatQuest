using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour {
	
	[SerializeField] GameObject[] screens;
	public int state=0;
	
	private int desiredCodeLength = 14;
	private string code = "";
	private char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
	
	public float difficulty = 1F;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt("HasPlayedBefore", 0);
		/*if(PlayerPrefs.GetInt("HasPlayedBefore") == 0){
			PlayerPrefs.SetInt("SendingData", 1);
			PlayerPrefs.SetInt("HasPlayedBefore", 1);
			
			code = "";
			while(code.Length < desiredCodeLength) {
				code += characters[Random.Range(0, 61)];
			}
			Debug.Log("Random code: " + code);
			PlayerPrefs.SetString("Username", code);
			
			difficulty = Random.Range(0.0F, 1.0F);
			PlayerPrefs.SetFloat("Difficulty", difficulty);
			Debug.Log ("Difficulty is " + difficulty);

			PlayerPrefs.SetInt("HighScore", 0);
		}else{
			PlayerPrefs.SetInt("SendingData", 0);
			difficulty = PlayerPrefs.GetFloat("Difficulty");
			Debug.Log ("Difficulty is " + difficulty);
		}*/
		PlayerPrefs.SetFloat("Difficulty", 1F);
	}
	
	// Update is called once per frame
	void Update () {
		/*if(state == 0){
			if(Input.GetKeyDown(KeyCode.Space)){
				state++;
			}
		}else if(state == 1){
			if(Input.GetKeyDown(KeyCode.Space)){
				state++;
			}
		}else if(state == 2){
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel(1);
			}
		}

		if(Input.GetKeyDown(KeyCode.F8)){
			PlayerPrefs.SetInt("SendingData", 1);
			PlayerPrefs.SetInt("HasPlayedBefore", 0);
			
			code = "";
			while(code.Length < desiredCodeLength) {
				code += characters[Random.Range(0, 61)];
			}
			Debug.Log("Random code: " + code);
			PlayerPrefs.SetString("Username", code);
			
			difficulty = Random.Range(0.0F, 1.0F);
			PlayerPrefs.SetFloat("Difficulty", difficulty);
			Debug.Log ("Difficulty is " + difficulty);

			PlayerPrefs.SetInt("HighScore", 0);
		}

		for(int i=0;i<screens.Length;i++){
			screens[i].SetActive(false);
		}
		screens[state].SetActive(true);*/
	}
	
	public void StartGame(){
		Application.LoadLevel(1);
	}
}
