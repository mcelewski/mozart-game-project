using UnityEngine;

[CreateAssetMenu (fileName = "New Dungeon", menuName = "Active Objects/Dungeon to enter")]
public class ActiveDungeon : ScriptableObject
{
    public new string name;
    public Sprite icon;

    public void Print()
    {
        Debug.Log("Dungeon name: " + name +
                  "\tDungeon image: " + icon.name);
    }
}
