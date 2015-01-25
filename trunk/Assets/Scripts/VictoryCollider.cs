using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryCollider : MonoBehaviour {

	public Text winText, gnomeText;
	public string subtext1 = "With ";
	public string subtext2 = " gnomes saved!";
	private float timeToNextLevel = 3f;
	private int totalGnomes = 0;
	private bool winTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !winTriggered)
		{
			winText.gameObject.SetActive(true);
			gnomeText.gameObject.SetActive(true);
			gnomeText.text = subtext1 + totalGnomes + subtext2;
			Invoke ("NextLevel", timeToNextLevel);
			winTriggered = true;
		}

		if (other.tag == "Gnome")
		{
			totalGnomes++;
			gnomeText.text = subtext1 + totalGnomes + subtext2;
			other.collider.enabled = false;
		}
	}

	void NextLevel() {
		if (Application.loadedLevel < Application.levelCount - 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
