using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showInitialSpeed : MonoBehaviour {
    public Text currentInitialSpeed;

	void Update () {
        currentInitialSpeed.text = DataPasser.initialSpeed.ToString();
	}
}
