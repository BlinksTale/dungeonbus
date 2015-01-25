using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryCollider : MonoBehaviour {

	public GameObject winObj;
	public Text gnomeText;
    private UIController uiController;
	private float timeToNextLevel = 3f;
	private int totalGnomes = 0;
	private bool winTriggered = false;

	// Use this for initialization
	void Start () {
        uiController = GameObject.FindWithTag("UI").GetComponent<UIController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !winTriggered)
		{
			winObj.SetActive(true);
            uiController.progressTime = false;
            uiController.timeText.gameObject.SetActive(true);
			gnomeText.gameObject.SetActive(true);
			gnomeText.text = "" + totalGnomes;
			Invoke ("NextLevel", timeToNextLevel);
			winTriggered = true;
		}

		if (other.tag == "Gnome")
		{
			totalGnomes++;
			gnomeText.text = "" + totalGnomes;
			other.collider.enabled = false;
		}
	}

	void NextLevel() {
		if (Application.loadedLevel < Application.levelCount - 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
