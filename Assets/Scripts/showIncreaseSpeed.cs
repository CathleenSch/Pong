using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showIncreaseSpeed : MonoBehaviour {
    public Toggle increaseSpeedToggle;

	void Start () {
		if (DataPasser.increaseSpeed) {
            increaseSpeedToggle.isOn = true;
        } else
        {
            increaseSpeedToggle.isOn = false;
        }
	}
}
