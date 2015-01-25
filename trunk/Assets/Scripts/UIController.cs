using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text timeText;
    private float timer;
    public bool progressTime = true;
	
	// Update is called once per frame
	void Update ()
    {
        if (progressTime)
        {
           timer += Time.deltaTime;
            var minutes = Mathf.Floor(timer / 60).ToString("00");
            var seconds = (timer % 60).ToString("00");

            timeText.text = minutes + " : " + seconds;
        }
	}
}
