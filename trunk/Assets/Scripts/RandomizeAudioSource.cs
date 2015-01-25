using UnityEngine;
using System.Collections;

public class RandomizeAudioSource : MonoBehaviour {

	public int totalClips = 4;
	public bool playOnRandomize = false;

	// Use this for initialization
	void Start() {
		RandomizeAudio();
	}

	public void RandomizeAudio () {
		string clipName = audio.clip.name;
		if (clipName.Length >= 7) {
			string end = clipName.Substring(clipName.Length - 7, 7);
			if (end == "(Clone)") {
				clipName = clipName.Substring(0, clipName.Length - 7);
			}
		}
		string newClipName = clipName.Substring(0,clipName.Length - 1) + Random.Range(1, 1 + totalClips);
		audio.clip = Instantiate(Resources.Load(newClipName)) as AudioClip;

		if (playOnRandomize)
		{
			audio.Play();
		}
	}
	
}
