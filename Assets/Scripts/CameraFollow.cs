using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public bool staticMode;
	public bool isSpikes;
	public bool smooth;
	public Transform target;
	public Transform empty;

	public float speed;

	public float dampTime = 0.15f;

	float timer=0F;
	
	// Update is called once per frame
	void Update(){
		Vector3 point = transform.position;

		speed = 1.25F + 1.25F*PlayerPrefs.GetFloat("Difficulty");
		point.x += speed * Time.deltaTime;


		if (target){
			if(!staticMode){
				if(smooth){
					transform.position = Vector3.Lerp(new Vector3(point.x, transform.position.y, point.z), new Vector3(point.x, Mathf.Clamp(target.position.y, -4, 100000)*0.66F + 1F*.33F, point.z), dampTime * Time.deltaTime);
				}else{
					transform.position = new Vector3(point.x, target.position.y, point.z);
				}
			}

		}	

		if(isSpikes){
			transform.position = point;
			timer += Time.deltaTime;
			if(timer < 1){
				transform.position += new Vector3(Time.deltaTime,0,0);
			}
		}
	}
}