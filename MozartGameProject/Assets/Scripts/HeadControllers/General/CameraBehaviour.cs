using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject playerRef;
	public Transform hiddenObjectTarget;
	public SceneMovementController _SceneMovement;

    public float cameraSmotch;

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
		if (!CheckIfCanBeOrto() && CheckIfCanBeTracked())
		{
			CameraOnHiddenObjects();
			//Debug.Log("Hidden obj camera");
		}
		else if (!CheckIfCanBeOrto() && !CheckIfCanBeTracked())
		{
			CameraOnAdventure();
			TrackPlayer();
			cam.orthographicSize = 5f;
			cam.orthographic = true;
			//Debug.Log("Adventure camera");
		}
	}

	private void CameraOnAdventure()
	{
		//TODO fix camera after scene change
		sbyte offset = 50;
		if (playerRef.transform.hasChanged)
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
				new Vector3(playerRef.transform.position.x, playerRef.transform.position.y, playerRef.transform.position.z - offset),
				Time.deltaTime * cameraSmotch );
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
