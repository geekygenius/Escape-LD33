using UnityEngine;
using System.Collections;

public class HealthTracker : MonoBehaviour {
	public float health = 1f;
	private float totalHealth;
	public Vector3 overlayOffset = new Vector3 (0f, -1f, 0f);
	public Texture rect;

	void Start(){
		totalHealth = health;
	}

	void ApplyDamage(float amt){
		health -= amt;

		if (health < 0) {
			Destroy (gameObject);
		}
	}

	void OnGUI(){
		var center = Util.WorldToScreen (transform.position + overlayOffset);
		center.y = Util.InvertY (center.y);
		GUI.DrawTexture(new Rect(new Vector2(center.x - 20,center.y),
		                          new Vector2(health/totalHealth*40,2)),rect);
	}
}
