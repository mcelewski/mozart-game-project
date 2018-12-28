using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject playerRef;

	public static bool SetGameCamera { get; set; }

	private void Awake()
	{
		SetGameCamera = false;
		if (!gameObject.CompareTag("MainCamera"))
		Debug.Log("There is no camera at scene");
	}

	private void FixedUpdate()
	{
		SetCameraOrtoSize();
		gameObject.transform.LookAt(playerRef.transform.position);

		if (SetGameCamera && gameObject.transform.position.x >= playerRef.transform.position.x -5)
		{
			gameObject.transform.position = new Vector3(playerRef.transform.position.x * Time.deltaTime, 0,-150f);
		}

		if (SetGameCamera && gameObject.transform.position.y > playerRef.transform.position.y -2)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,playerRef.transform.position.y, gameObject.transform.position.z);
		}
	}

	private void SetCameraOrtoSize()
	{
		var cam = gameObject.GetComponent<Camera>();
		if (!SetGameCamera)
			cam.orthographicSize = 80f;
		else
			cam.orthographicSize = 5f;
	}
}
