using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
	[SerializeField] string sceneName;
	[SerializeField] string tagID;

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag(tagID) && PlayerMovement.hasKey){
			SceneManager.LoadScene(sceneName);
		}else if(collider.gameObject.CompareTag(tagID) && !PlayerMovement.hasKey){
			print("Please Collect the key to unlock the portal");
		}
	}
}
