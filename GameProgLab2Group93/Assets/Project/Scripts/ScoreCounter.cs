using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField]
	private string cubeTag = "Key";

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(cubeTag))
		{
			SceneChanger.ChangeScene();
		}
	}
}
