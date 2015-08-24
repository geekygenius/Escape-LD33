using UnityEngine;
using System.Collections;

public class AnimateSpeed : MonoBehaviour {
	public Animator animator;
	Vector3 lastPos;

	void FixedUpdate () {
		animator.SetFloat ("Speed", (gameObject.transform.position - lastPos).magnitude * 60);
		lastPos = gameObject.transform.position;
	}
}
