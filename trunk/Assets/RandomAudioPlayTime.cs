using UnityEngine;
using System.Collections;

public class RandomAudioPlayTime : MonoBehaviour {

	bool accelerate = false;
	float minTime = 1f;
	float maxTime = 4f;
	RandomizeAudioSource randomize;

	// Use this for initialization
	void Start () {
		audio.volume = 0f;
		randomize = this.GetComponent<RandomizeAudioSource>();

		float randVal = Random.Range (minTime, maxTime);
		Invoke ("PlayAudio", randVal);
	}
	
	// Update is called once per frame
	void PlayAudio () {
		if (audio.volume < 1f)
		{
			audio.volume = 1f;
		}
		randomize.RandomizeAudio();
		audio.Play();

		float randVal = Random.Range (minTime, maxTime);

		if (accelerate)
		{
			randVal /= Mathf.Pow (Time.timeSinceLevelLoad, 4f);
		}
		Invoke ("PlayAudio", randVal);
	}
}
