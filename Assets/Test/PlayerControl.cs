using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControl : NetworkBehaviour {

	// Use this for initialization
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			return;
		}
		float x = Input.GetAxis("Horizontal1") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical1") * Time.deltaTime * 3.0f;
		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);

		if(Input.GetKeyDown(KeyCode.Space)) {
			CmdFire();
		}

	}
	[Command]
	void CmdFire() {
		GameObject bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;
		NetworkServer.Spawn(bullet);
		Destroy(bullet,2);
	}
	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
