using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDifficulty : MonoBehaviour {
    public Text difficulty;
    public Slider diffSlider;

	void Start () {
        int x = DataPasser.difficulty;
        diffSlider.value = x;

        if (x == 0) {
            difficulty.text = "easy";
        } else if (x == 1) {
            difficulty.text = "medium";
        } else {
            difficulty.text = "hard";
        }
	}
}
