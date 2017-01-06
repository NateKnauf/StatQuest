using UnityEngine;
using System.Collections;

public class HSController : MonoBehaviour{

	
	public bool firstTimePlaying = true;
	private string secretKey = "BananaSplits"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "http://www.numeralien.com/addscore.php?"; //be sure to add a ? to your url
	//public string highscoreURL = "http://localhost/unity_test/display.php";
	//public bool allowQuitting = false;
	
	public float updateTime = 5F;
	private float sendTimer = 0F;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update(){
		if(PlayerPrefs.GetInt("SendingData") == 1){
			//Debug.Log ("Sendering");
			if(sendTimer>0){
				sendTimer -= Time.deltaTime;
			}else{
				sendTimer = updateTime;
				if(PlayerPrefs.GetInt("HighScore") != null){
				}else{					
				}
			}
		}
	}
	
	public void PostEm(string name, float difficulty, float time, int score){
		StartCoroutine(PostScores(name, difficulty, time, score));
	}
	
	
	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, float difficulty, float time, int score)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = MD5Test.Md5Sum(name + difficulty + time + score + secretKey);
		
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&difficulty=" + difficulty + "&time=" + time + "&score=" + score + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		
		//Debug.Log ("BUTT");
	}
	
	
}
