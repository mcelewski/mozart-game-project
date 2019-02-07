using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject playerRef;
	public Transform hiddenObjectTarget;
	public SceneMovementController _SceneMovement;

    public float cameraSmotch;

	void Start()
	{
		if (!gameObject.CompareTag("MainCamera"))
		Debug.Log("There is no camera at scene");
	}

	void Update()
	{
		CameraSetup();
	}
	
	void CameraSetup()
	{
		var cam = gameObject.GetComponent<Camera>();
		if (!CheckIfCanBeOrto() && CheckIfCanBeTracked())
		{
			CameraOnHiddenObjects();
			TrackPlayer(hiddenObjectTarget);
			//Debug.Log("Hidden obj camera");
		}
		else if (!CheckIfCanBeOrto() && !CheckIfCanBeTracked())
		{
			CameraOnAdventure();
			TrackPlayer(playerRef.transform);
			cam.orthographicSize = 5f;
			cam.orthographic = true;
			//Debug.Log("Adventure camera");
		}
	}

	void CameraOnAdventure()
	{
		sbyte offset = 50;
		if (playerRef.transform.hasChanged)
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
				new Vector3(playerRef.transform.position.x, playerRef.transform.position.y, playerRef.transform.position.z - offset),
				Time.deltaTime * cameraSmotch );
		}
	}

	void CameraOnHiddenObjects()
	{
		sbyte offset = 2;
		gameObject.transform.localPosition = new Vector3(hiddenObjectTarget.position.x +offset,
													hiddenObjectTarget.transform.position.y +offset,
													-50);
	}

	void CameraOnMOzartHero()
	{
		gameObject.transform.position = new Vector3(0,3,-10);
	}

	void TrackPlayer(Transform transform)
	{
		gameObject.transform.LookAt(transform);
	}
	
	bool CheckIfCanBeOrto()
	{
		return _SceneMovement.IsOnMozartHeroScene();
	}

	bool CheckIfCanBeTracked()
	{
		return _SceneMovement.IsOnHiddenObjectsScene();
	}

}
