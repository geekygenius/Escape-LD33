using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Looooserr : MonoBehaviour {
	public Text loseText;

	void Update () {
		if (GameObject.FindWithTag ("Zombie") == null) {
			loseText.text = "You lose!\nRestart the game to try again.";
		}
	}
}
