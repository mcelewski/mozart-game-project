using UnityEngine;

[RequireComponent(typeof(ActiveDungeon))]
public class ActiveDungeonBehaviour : MonoBehaviour
{
    public ActiveDungeon dungeon;

    void Start()
    {
        if (dungeon.name == string.Empty ||
            dungeon.icon == null ||
            dungeon == null)
        {
            Debug.Log("No requierment items");
            gameObject.SetActive(false);
        }
        gameObject.name = dungeon.name;
        gameObject.GetComponent<SpriteRenderer>().sprite = dungeon.icon;
    }
}
