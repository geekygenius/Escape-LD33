using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class ZombiePuncher : MonoBehaviour {
	public float punchRadius = .7f;
	public float damage = .4f;
	public float cooldown = .75f;
	private float nextPunch;
	private GameObject target;
	private Animator animate;
	private NavMeshAgent agent;
	private SteerForWander wander;
	private AudioSource source;

	void Start(){
		animate = GetComponent<Animator> ();
		nextPunch = Time.time;
		
		agent = GetComponent<NavMeshAgent>();
		wander = GetComponent<SteerForWander> ();
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		//Do we see a zombie?-
		bool zombieSeen = false;
		foreach (var zombie in GameObject.FindGameObjectsWithTag("Zombie")) {
			RaycastHit hit;
			if (!Physics.Linecast(transform.position, zombie.transform.position, out hit)) {
				Debug.Log ("Spotted");
				agent.SetDestination(zombie.transform.position);
				zombieSeen = true;				
				wander.enabled = false;
				break;
			}
		}

		if (!zombieSeen)
			wander.enabled = true;

		if (Time.time < nextPunch)
			return;

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, punchRadius);
		int i = 0;

		while (i < hitColliders.Length) {
			if (hitColliders[i].gameObject.CompareTag("Zombie")){
				target = hitColliders[i].gameObject;
				agent.SetDestination(target.transform.position);
				Invoke("DoPunch",15f/24f);
				animate.CrossFade("Punch",.1f);
				nextPunch = Time.time + cooldown;
				wander.enabled = false;
				return;
			}
			i++;
		}
	}

	void DoPunch(){
		if (target) {
			target.SendMessage ("ApplyDamage", damage);
			source.Play();
		}
	}
}
