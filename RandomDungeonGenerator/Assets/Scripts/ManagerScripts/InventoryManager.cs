using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform slotParent;
    public List<bool> occupiedSlots = new List<bool>();

    public KeyCode[] numberKeys;
    public int currentSelectedItemIndex;

    private void Start()
    {

        Instance = this;

        //Empty and set the lists to 9 items
        for (int i = 0; i < 9; i++)
        {
            items.Add(null);
            occupiedSlots.Add(false);
            slotParent.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        for(int i = 0; i < 9;i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                //Desequip item if pressed again
                if (currentSelectedItemIndex == i) currentSelectedItemIndex = -1;
                else currentSelectedItemIndex = i;
                
            }
        }
    }
    public void AddItem(Item newItem)
    {
        for(int slotsIndex = 0; slotsIndex < occupiedSlots.Count; slotsIndex++)
        {
            if(!occupiedSlots[slotsIndex])
            {
                occupiedSlots[slotsIndex] = true;
                items[slotsIndex] = newItem;
                items[slotsIndex].assignedSlot = slotsIndex;
                var child = slotParent.GetChild(slotsIndex).gameObject;
                child.SetActive(true);
                child.transform.Find("Sprite").GetComponent<Image>().sprite = newItem.itemSprite;
                break;
            } 
        }
        
    }
    public bool HasItem(string _itemName)
    {

        //Failsafe for empty inventory
        if (occupiedSlots[0] == false) return false;

        foreach (Item item in items)
        {
            if(item != null)
            {
                if(item.itemName == _itemName)
                return true;
            }
        }
        return false;
    }
    public Item GetItem(string _itemName)
    {
        if(HasItem(_itemName))
        {
            foreach (Item item in items)
            {
                if (item != null)
                {
                    if (item.itemName == _itemName)
                        return item;
                }
            }
            return null;
        }
        return null;
        
    }
    public int GetItemIndex(string _itemName)
    {
        if (HasItem(_itemName))
        {
            for (int i=0; i<items.Count; i++)
            {
                if (items[i] != null)
                {
                    if (items[i].itemName == _itemName)
                        return i;
                }
            }
            return -1;
        }
        return -1;

    }
    public bool HoldsItem(string _itemName)
    {
        if(HasItem(_itemName))
        {
            return currentSelectedItemIndex == GetItemIndex(_itemName);
            
        }
        return false;
    }

}
