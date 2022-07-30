using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Character Movemment
	[SerializeField] float _speed;
	private Rigidbody _rigidbody;
	//Coins
	public static int money = 0;
	public static bool hasKey = false;
	Camera _camera;


	private void Awake() {
		_rigidbody = GetComponent<Rigidbody>();
		_camera = Camera.main;
	}

	private void Update() {
		//Sprinting system
		if(Input.GetKey(KeyCode.LeftShift)){
			_speed = 7f;
		}else{
			_speed = 3f;
		}
	}

	void FixedUpdate()
	{
		//Movement physics with correct rotation
		Vector3 _movement = GetMovement();
		var rot = _camera.transform.rotation.eulerAngles;
		rot.x = 0f; // Remove rotation on X axis or it can slow the character down because they are trying to walk into the ground.
		Quaternion q = Quaternion.Euler(rot);
		rot = q * _movement;
		_rigidbody.velocity = rot * _speed;
	}	

	private Vector3 GetMovement(){
		float _horizontalAxis = Input.GetAxisRaw("Horizontal"); //get the left and right input(A-D or LeftArrow-RightArrow)
		float _verticalAxis = Input.GetAxisRaw("Vertical"); //get the forward and backward input(W-S or UpArrow-DowntArrow)
		Vector3 _movement =  new Vector3(_horizontalAxis, 0, _verticalAxis);
		if(_movement.magnitude > 1){
			_movement.Normalize();
		}
		return _movement;
	}
}
