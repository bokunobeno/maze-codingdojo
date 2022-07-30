using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//First Person Camera
	private Camera _camera;
	[SerializeField] private Transform cameraTarget;
	[SerializeField] private bool invertMouse = false;
	private float verticalRotationLimit;
	[SerializeField] private float mouseSensetivity = 1;
	[SerializeField] private float lookUpConstraint;
	[SerializeField] private float lookDownConstraint;
	public static bool isFirstPerson = true;

	void Awake()
	{
		_camera = GetComponent<Camera>();
	}

	private void LateUpdate() {
		//Switch between first person and third person camera
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			FirstPersonMode();
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			ThirdPersonMode();
		}
		//Enable mouse-camera movement while in first person
		if(isFirstPerson){
			Vector2 _mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensetivity);
			float _rotationY = transform.rotation.eulerAngles.y + _mouseInput.x;
			float invert = (!invertMouse) ? -1 : 1f;
			verticalRotationLimit += (_mouseInput.y * invert);
			verticalRotationLimit = Mathf.Clamp(verticalRotationLimit, lookDownConstraint, lookUpConstraint);
			transform.rotation = Quaternion.Euler(0, _rotationY, 0);
			cameraTarget.rotation = Quaternion.Euler(verticalRotationLimit, cameraTarget.eulerAngles.y, cameraTarget.eulerAngles.z);
		}
	}
	private void FirstPersonMode(){
		//set camera to the player
		isFirstPerson = true;
		_camera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + 0.3f, cameraTarget.position.z);
		_camera.transform.rotation = cameraTarget.rotation;
	}

	private void ThirdPersonMode(){
		//rotate and position the camera to up-down 
		isFirstPerson = false;
		transform.position = new Vector3(0,transform.position.y ,0);
		transform.rotation = Quaternion.Euler(0, 0, 0);
		_camera.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
		_camera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + 2, cameraTarget.position.z);
	}
}
