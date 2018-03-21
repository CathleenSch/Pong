using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWinner : MonoBehaviour {
	public Text winnerText;
	// Use this for initialization
	void Start () {
		winnerText.text = ("Player " + DataPasser.winner + " won!");
	}
}
