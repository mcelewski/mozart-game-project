using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
    [SerializeField] private ItemsID _itemsId;
    private void Start()
    {
        if (_itemsId == null)
            _itemsId = gameObject.GetComponent<ItemsID>();

        _itemsId.itemID = 2;
    }
}
