using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject playerRef;
	public Transform hiddenObjectTarget;
	public SceneMovementController _SceneMovement;

	private void Start()
	{
		if (!gameObject.CompareTag("MainCamera"))
		Debug.Log("There is no camera at scene");
	}

	private void Update()
	{
		CameraSetup();
	}
	
	private void CameraSetup()
	{
		var cam = gameObject.GetComponent<Camera>();
		
		if (CheckIfCanBeOrto() && !CheckIfCanBeTracked())
		{
			CameraOnMOzartHero();
			Debug.Log("Mozart hero camera");
			cam.orthographicSize = 80f;
			cam.orthographic = false;
		}
		else if (!CheckIfCanBeOrto() && CheckIfCanBeTracked())
		{
			CameraOnHiddenObjects();
			Debug.Log("Hidden obj camera");
		}
		else if (!CheckIfCanBeOrto() && !CheckIfCanBeTracked())
		{
			CameraOnAdventure();
			TrackPlayer();
			cam.orthographicSize = 5f;
			cam.orthographic = true;
			Debug.Log("Adventure camera");
		}
	}

	private void CameraOnAdventure()
	{
		//TODO fix camera after scene change
		if (gameObject.transform.position.x >= playerRef.transform.position.x -5)
		{
			gameObject.transform.position = new Vector3(
				playerRef.transform.position.x,
				0,
				-50f);
		}

		if (gameObject.transform.position.y > playerRef.transform.position.y -2)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,
				playerRef.transform.position.y,
				gameObject.transform.position.z);
		}
	}

	private void CameraOnHiddenObjects()
	{
		sbyte offset = 2;
		gameObject.transform.position = new Vector3(hiddenObjectTarget.position.x +offset,
													hiddenObjectTarget.transform.position.y +offset,
													-50);
	}

	private void CameraOnMOzartHero()
	{
		gameObject.transform.position = new Vector3(0,3,-10);
	}

	private void TrackPlayer()
	{
		gameObject.transform.LookAt(playerRef.transform.position);
	}
	
	private bool CheckIfCanBeOrto()
	{
		return _SceneMovement.IsOnMozartHeroScene();
	}

	private bool CheckIfCanBeTracked()
	{
		return _SceneMovement.IsOnHiddenObjectsScene();
	}

}
