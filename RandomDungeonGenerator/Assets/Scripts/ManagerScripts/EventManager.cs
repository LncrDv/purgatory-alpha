using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("\n Global References \n")]
    private InventoryManager inventoryManager;
    [Header("\n Warehouse \n")]

    [Tooltip("Parent of the walls that are going to dissapear after the player picks up the lamp")]
    public GameObject tempWallParent;

    [Tooltip("Trigger used to check for the player in the maze")]
    public Transform mazeTrigger;

    [Tooltip("Bool to check if player has entered the maze, to prevent it from backtracking")]
    public bool playerInMaze = false;


    private void Start()
    {
        //Setting up the references
        inventoryManager = GetComponent<InventoryManager>();
    }
    void Update()
    {
        #region tempWallParent
        if (tempWallParent.activeInHierarchy && !playerInMaze)
        {
            if (inventoryManager.HasItem("Flashlight"))
            {
                tempWallParent.SetActive(false);
            }
        }
        if(mazeTrigger.GetComponent<Obj_PlayerTrigger>().hasCollided)
        {
            playerInMaze = true;
            FindObjectOfType<PlayerMovement>().SetToFastMovement();
        }
            
        if(playerInMaze)
        {
            tempWallParent.SetActive(true);
        }
        #endregion
    }
}
