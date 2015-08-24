using UnityEngine;
using System.Collections;

public class MakeObject : MonoBehaviour {
	public GameObject tombstone;
	public int tombstonePrice;

	void Start(){
	}

	public void MakeTombstone(){
		Scorekeeper score = gameObject.GetComponent<Scorekeeper> ();
		if (score.CanBuy (tombstonePrice)) {
			score.AddScore (-tombstonePrice);
			Instantiate (tombstone);
		} else {
			Debug.Log ("Not enough money for a tombstone.");
		}
	}
}
