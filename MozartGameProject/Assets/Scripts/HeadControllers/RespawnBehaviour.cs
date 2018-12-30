using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
	public GameObject player;
	public Transform _respawn;
	public GameObject hiddenSceneSpawnPref;

	private void Start()
	{
		if (player != null && hiddenSceneSpawnPref != null) return;
		
		player = GameObject.Find("Player").GetComponent<GameObject>();
		hiddenSceneSpawnPref = GameObject.Find("HiddenSceneSpawn").GetComponent<GameObject>();
	}

	public void SpawnToHiddenScene()
	{
		player.transform.position = hiddenSceneSpawnPref.transform.position;
	}
	
	public void SpawnToAdventure()
	{
		player.transform.position = _respawn.transform.position;
	}

	public void SetUpNewRespawn()
	{
		var respawnObj = new GameObject("RespawnAfterDungeon");
		respawnObj.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
		respawnObj.tag = "Adventure";
		
		if (SceneMovementController.currentScene != SceneMovementController.ScenesInGame.Adventure)
		{
			Instantiate(respawnObj);
		}
		_respawn = GameObject.Find(respawnObj.name).GetComponent<Transform>();
	}

	public void DeactivateSpawn()
	{
		_respawn.gameObject.SetActive(false);
		Destroy(_respawn);
	}

	public void SetRespawnTransform(Transform resp)
	{
		_respawn = resp;
	}
}
