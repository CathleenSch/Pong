using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMultiplayer : MonoBehaviour {
    public Toggle multiplayer;

	void Start () {
		if (DataPasser.multiplayer) {
            multiplayer.isOn = true;
        } else {
            multiplayer.isOn = false;
        }
	}
}
