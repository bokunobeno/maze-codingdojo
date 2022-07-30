using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
	[SerializeField] private string _tagID = "Player";
	private Transform _transform;
	[SerializeField] private float _speed = 0.2f;
	[SerializeField] private float _hight = 0.5f;

	private void Awake() {
		_transform = this.transform;
	}

	private void Update() {
		_transform.position = new Vector3(_transform.position.x,Mathf.PingPong(_speed * Time.time * 2, _hight),_transform.position.z);
	}
	private void OnTriggerEnter(Collider _collider){
		if(_collider.gameObject.CompareTag(_tagID)){
				Destroy(gameObject);
				PlayerMovement.hasKey = true;
				print("You got the key to the portal");
		}
	}
}
