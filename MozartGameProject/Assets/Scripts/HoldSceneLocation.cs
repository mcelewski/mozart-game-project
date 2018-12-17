using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSceneLocation : MonoBehaviour 
{
	private readonly Vector3 defLocation = new Vector3(3f,-13f,0f);

	private void Start()
	{
		if (gameObject.transform.position != defLocation)
			gameObject.transform.position = defLocation;
	}
}
