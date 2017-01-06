using UnityEngine;
using System.Collections;

public class ReplayHandler : MonoBehaviour {

	public bool firstTimePlaying = true;
	
	public float difficulty = 0F;
	
	private int desiredCodeLength = 14;
	private string code = "";
	private char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
	
	// Use this for initialization
	void Start () {
	
		/*if(PlayerPrefs.GetInt("HasPlayedBefore") == 1){
			firstTimePlaying = false;
			difficulty = PlayerPrefs.GetFloat("Difficulty");
		}else{
			PlayerPrefs.SetInt("HasPlayedBefore", 1);
			
			code = "";
			while(code.Length < desiredCodeLength) {
				code += characters[Random.Range(0, 61)];
			}
			Debug.Log("Random code: " + code);
			PlayerPrefs.SetString("Username", code);
			
			difficulty = Random.Range(0.0F, 10.0F);
			PlayerPrefs.SetFloat("Difficulty", difficulty);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.F8)){
			PlayerPrefs.SetInt("HasPlayedBefore", 0);
			//firstTimePlaying = true;
		}*/
	}
}
