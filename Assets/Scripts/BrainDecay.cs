using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrainDecay : MonoBehaviour {	
	public RawImage brainFull;
	private float amt = 1;
	private float time = 50;
	private Scorekeeper score;

	void Start(){
		score = GetComponent<Scorekeeper> ();
	}

	void Update () {
		if (score.GetScore () == 0) {
			amt = 1;
		} else {
			amt -= Time.deltaTime / time;
		}

		if (amt < 0) {
			score.AddScore (-1);
			amt = 1;
		}

		var rect = brainFull.uvRect;
		rect.height = amt;
		brainFull.uvRect = rect; 
		var scale = brainFull.rectTransform.localScale;
		scale.y = amt;
		brainFull.rectTransform.localScale = scale;
	}
}
