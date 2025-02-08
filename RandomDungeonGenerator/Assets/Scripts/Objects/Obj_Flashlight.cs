using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Flashlight : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void Update()
    {
        GetComponent<Light>().enabled = inventoryManager.HoldsItem("Flashlight");
    }
}
