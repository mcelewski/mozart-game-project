using UnityEngine;

public class NotesInfo : ItemInfo
{
    public bool isWhite;
    private Color color;

    public void SetInfo()
    {
        SetNameOf();
        SetProperColor();
    }

    void SetNameOf()
    {
        name = name.ToUpper();
    }

    void SetProperColor()
    {
        if(IsWhite())
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        else
            gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    bool IsWhite()
    {
        return isWhite;
    }
}
