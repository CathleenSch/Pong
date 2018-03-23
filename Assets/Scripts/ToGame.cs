using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ToGame : MonoBehaviour{
    public void changeScene() {
        SceneManager.LoadScene("scene_main");
    }
}
