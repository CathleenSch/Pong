using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour {
    public void unpause() {
        pauseMenu.paused = pauseMenu.togglePause();
    }
}
