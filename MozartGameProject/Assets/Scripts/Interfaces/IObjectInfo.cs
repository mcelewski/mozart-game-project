using UnityEngine;

public interface IObjectInfo
{
    Vector3 CurrentObjectPosition();
    void Print();
    string[] GetItemInfo();
}
