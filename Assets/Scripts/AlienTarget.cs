using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class AlienTarget : NetworkBehaviour {
	private NavMeshAgent agent;
	private Transform myTransform;
	private Transform targetTransform;
	private LayerMask raycastlayer;
	private float radious = 20f;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		myTransform = transform;
		raycastlayer = 1 << LayerMask.NameToLayer("Player");
	}
	private void FixedUpdate()
	{
		SearchForTarget();
		MoveToTarget();
	}
	
	void SearchForTarget(){
		if(!isServer){
			return;
		}
		if(targetTransform == null) {
			Collider[] hitCollider = Physics.OverlapSphere(myTransform.position, radious, raycastlayer);
			if(hitCollider.Length > 0) {
				int randomint = Random.Range(0, hitCollider.Length);
				targetTransform = hitCollider[randomint].transform;
			}
		}
		if(targetTransform != null && targetTransform.gameObject.active == false) {
			targetTransform = null;
		}

	}

	void MoveToTarget(){
		if(targetTransform != null && isServer) {
			SetNavDestination(targetTransform);
		}
	}
	void SetNavDestination(Transform dest) {
		agent.SetDestination(dest.position);
	}
}