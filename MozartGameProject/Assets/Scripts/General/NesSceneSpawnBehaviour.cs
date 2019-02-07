using UnityEngine;

public class NesSceneSpawnBehaviour : MonoBehaviour 
{
	readonly Vector3 spawnPos = new Vector3(3f,-12f,-15f);

	void Start ()
	{
		if (gameObject.transform.position != spawnPos)
			gameObject.transform.position = spawnPos;
	}
}
