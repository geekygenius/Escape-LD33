using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {
	public Text scoreboard;
	private int score = 0;

	void Start () {
		scoreboard.text = score.ToString ();
	}

	public void AddScore(int amt){
		score += amt;
		scoreboard.text = score.ToString();
	}

	public bool CanBuy(int amt){
		return score >= amt;
	}

	public int GetScore(){
		return score;
	}
}
