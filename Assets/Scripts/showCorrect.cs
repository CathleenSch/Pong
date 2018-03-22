using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCorrect : MonoBehaviour {
    public Text currentMaxScore;

	void Update () {
        currentMaxScore.text = DataPasser.maxScore.ToString();
	}
}
