using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	GameObject [] list;
	
	public CameraControl cameraControler;
	public GameObject[] listOfTargetGameObjects;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		listOfTargetGameObjects = GameObject.FindGameObjectsWithTag("Player");
		Transform[] listOfTargetTransform;
		listOfTargetTransform = new Transform[listOfTargetGameObjects.Length];
		int i = 0;
		foreach (GameObject target in listOfTargetGameObjects){
			listOfTargetTransform[i] = target.transform;
			i++;
		}
		cameraControler.m_Targets = listOfTargetTransform;
	}

}
