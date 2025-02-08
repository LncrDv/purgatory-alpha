using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Flashlight : Interactable
{
    public override void Interact()
    {
        base.Interact();
        InventoryManager.Instance.AddItem(GetComponent<Item>());
        gameObject.SetActive(false);
    }
}
