using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWinner : MonoBehaviour {
	public Text winnerText;
	// Use this for initialization
	void Start () {
        if (DataPasser.multiplayer) {
		    winnerText.text = ("Player  " + DataPasser.winner + "  wins!");
        } else {
            if (DataPasser.winner == 1) {
                winnerText.text = ("You  lose!");
            } else {
                winnerText.text = ("You  win!");
            }
        }
	}
}
