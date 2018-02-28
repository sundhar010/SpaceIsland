using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other)
	{
		GameObject hit = other.gameObject;

		Health health = hit.GetComponent<Health>();
		
		if(health != null) {
		
			health.TakeDamage(10);
		
		}
		
		Destroy(gameObject);
	}
}
