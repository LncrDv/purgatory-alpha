using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class Interactable : MonoBehaviour
{

    public string hoverText;

    public KeyCode interactKey;

    public bool hovering = false;
    public bool interactable;

    public PlayerInteract playerInteract;

    public virtual void Update()
    {
        playerInteract = FindObjectOfType<PlayerInteract>();

        if(hovering)
        {
            
            OnHover();

        } else NotOnHover();

        if (playerInteract.objectInteractableScript != this)
        {
            hovering = false;
        }
    }

    public virtual void OnHover()
    {
       
    }
    public virtual void NotOnHover()
    {

    }
    public virtual void Interact()
    {

    }
}
