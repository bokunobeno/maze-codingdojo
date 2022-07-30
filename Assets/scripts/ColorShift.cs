using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
	[SerializeField] private Gradient myGradient;
	[SerializeField] private float strobeDuration = 10f;
	[SerializeField] private Material sparklingMat;
	[SerializeField] private Material groundMat;
	[SerializeField] private Light playerLight;

	void Update()
	{
		float t = Mathf.PingPong(Time.time / strobeDuration, 1f);
		sparklingMat.SetColor("_InnerColor", myGradient.Evaluate(t));
		sparklingMat.SetColor("_OuterColor", myGradient.Evaluate(t)*20);
		groundMat.SetColor("_OuterColor", myGradient.Evaluate(t)*20);
		playerLight.color = myGradient.Evaluate(t);

		if(CameraController.isFirstPerson){
			groundMat.SetFloat("_FrenselPower", 5.0f);
		}else{
			groundMat.SetFloat("_FrenselPower", 1.3f);
		}
	}
}
