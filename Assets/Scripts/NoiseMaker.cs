using UnityEngine;
using System.Collections;

public class NoiseMaker : MonoBehaviour {

	public AudioClip[] clips;
	
	public void PlayClip (int index) {
		GetComponent<AudioSource>().PlayOneShot(clips[index]);
	}
}
