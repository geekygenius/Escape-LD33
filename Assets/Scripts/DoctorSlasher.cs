using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class DoctorSlasher : MonoBehaviour {
	public float slashRadius = 2f;
	public float damage = .2f;
	public float cooldown = 1f;
	private float nextSlash;
	private GameObject target;
	private Animator animate;
	private NavMeshAgent agent;
	private AudioSource source;
	
	void Start(){
		animate = GetComponent<Animator> ();
		nextSlash = Time.time;
		
		agent = GetComponent<NavMeshAgent>();
		source = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (Time.time < nextSlash)
			return;
		
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, slashRadius);
		int i = 0;
		
		while (i < hitColliders.Length) {
			if (hitColliders[i].gameObject.CompareTag("Doctor")){
				target = hitColliders[i].gameObject;
				agent.SetDestination(target.transform.position);
				Invoke("DoSlash",21f/24f);
				animate.CrossFade("Attack",.1f);
				nextSlash = Time.time + cooldown;
				return;
			}
			i++;
		}
	}
	
	void DoSlash(){
		if (target) {
			Debug.Log ("Slash");
			target.SendMessage ("ApplyDamage", damage);
			source.Play();
		}
	}
}
