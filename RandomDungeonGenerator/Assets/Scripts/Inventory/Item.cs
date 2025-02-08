using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;

    [HideInInspector] public bool isEquipped;
    [HideInInspector] public int assignedSlot;

    private void Update()
    {
        isEquipped = InventoryManager.Instance.currentSelectedItemIndex == assignedSlot;
    }
}
