using UnityEngine;
using System.Collections;

public class TextureTiling : MonoBehaviour {
	void Start(){
		var renderer = GetComponent<MeshRenderer> ();
		renderer.material.mainTextureScale = new Vector2(transform.localScale.x * 4,transform.localScale.z * 4);
	}
}	