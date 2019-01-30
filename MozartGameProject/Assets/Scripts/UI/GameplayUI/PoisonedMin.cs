using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoisonedMin : MonoBehaviour
{
    public List<Sprite> NormalHearts  = new List<Sprite>();

    public Sprite GetHeartAt(ushort index)
    {
        return NormalHearts.ElementAt(index);
    }
}
