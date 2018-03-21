using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Again : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("scene_main");
    }
}
