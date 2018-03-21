using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour {
    public void ChangeToMenu() {
        SceneManager.LoadScene("scene_menu");
    }
}
