using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {
	void Update () {
		gameObject.transform.position = Util.MouseToWorld ();
		if (Input.GetMouseButtonDown (0)) {
			Destroy(this);
		}
	}
}
