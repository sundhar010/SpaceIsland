using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	// Use this for initialization
	public RectTransform healthbar;

	
	public const int maxHelth = 100;
	
	[SyncVar (hook = "onChangeHealth")]public int currentHelth = maxHelth;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	
	void Update () {
		
	}
	
	public void TakeDamage(int amount) {
	
		if(!isServer){
	
			return;
	
		}
	
		currentHelth -= amount;
	
		if(currentHelth <= 0) {
	
			currentHelth = maxHelth;
	
			//RPC call
	
			RpcRespawn();
	
		}
	
		healthbar.sizeDelta = new Vector2(currentHelth * 2, healthbar.sizeDelta.y);
	
	}
	void onChangeHealth(int health) {
		healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);
	}
	[ClientRpc]
	void RpcRespawn() {
		if(isLocalPlayer){
		transform.position = Vector3.zero;
		}
	}
}
