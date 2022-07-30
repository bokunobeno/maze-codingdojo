using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
	private Transform _transform;
	[SerializeField] private float _speed = 0.2f;
	[SerializeField] private float _hight = 0.5f;
	[SerializeField] private string _tagID = "Player";
	private AudioSource _audioSource;
	private void Awake() {
		_transform = this.transform;
		_audioSource = GameObject.FindGameObjectWithTag("Coinz").GetComponent<AudioSource>();
	}
	void Update()
	{
		RotateCoin();
		CoinFloat();
	}
	public void RotateCoin(){
		_transform.Rotate(Vector3.forward, _speed);
	}
	public void CoinFloat(){
		_transform.position = new Vector3(_transform.position.x,Mathf.PingPong(_speed * Time.time * 2, _hight),_transform.position.z);
	}
	private void OnTriggerEnter(Collider _collider){
		if(_collider.gameObject.CompareTag(_tagID)){
			_audioSource.Play(0);
			Destroy(gameObject);
			PlayerMovement.money++;
			print("You have $" + PlayerMovement.money);
		}
	}
}
