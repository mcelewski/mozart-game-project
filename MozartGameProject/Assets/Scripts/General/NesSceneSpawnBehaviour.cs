using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesSceneSpawnBehaviour : MonoBehaviour 
{
	private readonly Vector3 spawnPos = new Vector3(3f,-12f,-15f);

	private void Start ()
	{
		if (gameObject.transform.position != spawnPos)
			gameObject.transform.position = spawnPos;
	}
}
