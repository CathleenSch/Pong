using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
	public Canvas menu;
	public Text text1;
	public Text text2;
	public static bool paused = false;

	void Start () {
		menu.enabled = false;
		text1.enabled = false;
		text2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			Debug.Log ("Escape pressed.");
			paused = togglePause();
            menu.enabled = true;
            text1.enabled = true;
            text2.enabled = true;
        }

		if (!paused) {
			menu.enabled = false;
			text1.enabled = false;
			text2.enabled = false;
		} else {
			menu.enabled = true;
			text1.enabled = true;
			text2.enabled = true;
		}
	}
	
	void onGUI() {
		if (paused) {
			menu.enabled = false;
			text1.enabled = false;
			text2.enabled = false;
		} else {
			menu.enabled = true;
			text1.enabled = true;
			text2.enabled = true;
		}
	}

	public static bool togglePause() {
		Debug.Log ("Time scale:  " + Time.timeScale);
		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
			return false;
		} else {
			Time.timeScale = 0f;
			return true;
		}
	}
}
