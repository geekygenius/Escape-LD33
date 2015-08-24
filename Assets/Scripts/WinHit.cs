using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinHit : MonoBehaviour {
	public Text winText;

	void OnTriggerEnter(Collider other){
		Debug.Log (other.tag);
		if (other.CompareTag ("Zombie")) {
			winText.text = "Congratulations, you've escaped!\nNow go start the zombie apocalypse!";
		}
	}
}
