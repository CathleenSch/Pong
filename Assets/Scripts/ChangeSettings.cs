using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour {
    public Text settingMaxScore;
    public Text currentMaxScore;

    public Text settingInitialSpeed;
    public Text currentInitialSpeed;

    public Toggle increaseSpeedToggle;

    public Toggle multiplayerToggle;

    public Slider difficultySlider;
    public Text currentDifficulty;

    public int y = 0;
    public int x = 0;

    public void changeMaxScore() {
        x = int.Parse(settingMaxScore.text);
        DataPasser.maxScore = x;
        currentMaxScore.text = x.ToString();
    }

    public void changeInitialSpeed() {
        y = int.Parse(settingInitialSpeed.text);
        DataPasser.initialSpeed = y;
        currentInitialSpeed.text = y.ToString();
    }

    public void changeIncreaseSpeed() {
        DataPasser.increaseSpeed = increaseSpeedToggle.isOn;
    }

    public void changeMultiplayer() {
        DataPasser.multiplayer = multiplayerToggle.isOn;
    }

    public void changeDifficulty() {
        DataPasser.difficulty = (int) difficultySlider.value;
        if (DataPasser.difficulty == 0) {
            currentDifficulty.text = "easy";
        }
        else if (DataPasser.difficulty == 1) {
            currentDifficulty.text = "medium";
        }
        else {
            currentDifficulty.text = "hard";
        }
    }
}
