using UnityEngine;
using System.Collections;

public class ZombieSelector : MonoBehaviour {
	private Vector3 mouseStart;
	public Texture selecitonTexture;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			mouseStart = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0)){
			var rect = GetSelectionRect();

			foreach (GameObject selector in GameObject.FindGameObjectsWithTag("Selectable")) {
				Vector2 screenPos = Util.WorldToScreen(selector.transform.position);
				screenPos.y = Util.InvertY(screenPos.y);
				selector.GetComponent<MeshRenderer>().enabled = rect.Contains(screenPos);
			}
		}
	}

	public void OnGUI(){
		if (!Input.GetMouseButton (0))
			return;
		GUI.DrawTexture (GetSelectionRect(),selecitonTexture);
	}

	public Rect GetSelectionRect(){	
		var position = new Vector2 (Mathf.Min (mouseStart.x, Input.mousePosition.x), Mathf.Min (Util.InvertY (mouseStart.y), Util.InvertY (Input.mousePosition.y)));
		var size = new Vector2 (Mathf.Abs (mouseStart.x - Input.mousePosition.x), Mathf.Abs (Util.InvertY (mouseStart.y) - Util.InvertY (Input.mousePosition.y)));
		
		return new Rect(position,size);
	}
}
