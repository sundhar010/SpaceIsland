using UnityEngine;
using UnityEngine.Networking;
public class NetworkManager_cam : NetworkManager {

	// Use this for initialization

	public GameObject sceneCamera;
	public float cameraRotationRadious = 24f;
	public float cameraRotationSpeed = 3f;
	private bool canRotate = true;

	private float rotation;
	
	public override void OnStartClient(NetworkClient client) {
		canRotate = false;
		sceneCamera.SetActive(false);
	}
	public override void OnStartHost() {
		canRotate = false;
		sceneCamera.SetActive(false);
	}
	public override void OnStopClient() {
		canRotate = true;
		sceneCamera.SetActive(true);
	}
	public override void OnStopHost() {
		canRotate = true;
		sceneCamera.SetActive(true);
	}
	void Update() {
		if(!canRotate) {
			return ;
		}

		rotation += cameraRotationSpeed *Time.deltaTime;
		if(rotation >= 360f) {
			rotation -= 360f;
		}
		sceneCamera.transform.position = Vector3.zero;
		sceneCamera.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
		sceneCamera.transform.Translate(0f,cameraRotationRadious, -cameraRotationRadious);
		sceneCamera.transform.LookAt(Vector3.zero);
	}
}
