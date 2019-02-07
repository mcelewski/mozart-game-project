using UnityEngine;

public class HoldSceneLocation : MonoBehaviour 
{
	readonly Vector3 defLocation = new Vector3(3f,-13f,0f);

	void Start()
	{
		if (gameObject.transform.position != defLocation)
			gameObject.transform.position = defLocation;
	}
}
