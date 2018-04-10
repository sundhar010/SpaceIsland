using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AlienSpanner : NetworkBehaviour {

	// Use this for initialization
	public GameObject alienPrefab;
	public Transform[] alienSpawnPositions;

	public override void OnStartServer(){
		for(int i = 0; i < alienSpawnPositions.Length; i++) {
			GameObject alien = GameObject.Instantiate(alienPrefab, alienSpawnPositions[i].position, Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f) ) as GameObject;
			NetworkServer.Spawn(alien);
		}
	}
}
