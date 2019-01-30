using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoisonedMax : MonoBehaviour
{
   public List<Sprite> PoisonetHearts  = new List<Sprite>();

   public Sprite GetHeartAt(ushort index)
   {
      return PoisonetHearts.ElementAt(index);
   }
}
