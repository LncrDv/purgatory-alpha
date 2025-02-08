using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Boombox : Interactable
{
    public override void Interact()
    {
        InventoryManager.Instance.AddItem(GetComponent<Item>());
        FindObjectOfType<MusicPlayer>().hasBoombox = true;
        gameObject.SetActive(false);
    }
}
