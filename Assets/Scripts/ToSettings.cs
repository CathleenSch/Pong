using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSettings : MonoBehaviour {
    public void changeToSettings() {
        Debug.Log("Clicked");
        SceneManager.LoadScene("scene_settings");
    }
}
