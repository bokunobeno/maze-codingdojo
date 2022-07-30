using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingHazard : MonoBehaviour
{
	[SerializeField] Vector3 startingPoint;
	[SerializeField] Vector3 endingPoint;
	[SerializeField] float speed;
	[SerializeField] string sceneName;
	[SerializeField] string tagID;

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(startingPoint, endingPoint, Mathf.PingPong(Time.time * speed, 1));
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag(tagID)){
			SceneManager.LoadScene(sceneName);
		}
	}
}
