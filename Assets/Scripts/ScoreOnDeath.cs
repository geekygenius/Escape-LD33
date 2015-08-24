using UnityEngine;
using System.Collections;

public class ScoreOnDeath : MonoBehaviour {
	public int points = 1;

	void OnDestroy(){
		if (GameObject.FindGameObjectWithTag ("GameController"))
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("AddScore", points);
	}
}
