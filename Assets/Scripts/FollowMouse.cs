using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class FollowMouse : MonoBehaviour {
	private NavMeshAgent agent;
	
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (1) && transform.FindChild("Selection").GetComponent<MeshRenderer>().enabled) {
			agent.SetDestination(Util.MouseToWorld());
		}
	}
}
