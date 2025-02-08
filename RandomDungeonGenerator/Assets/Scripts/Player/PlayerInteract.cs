using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject orientation;
    public GameObject targetObject;
    public TextMeshProUGUI interactText;
    public Interactable objectInteractableScript;

    public float interactRange = 2f;

    private void Update()
    {
        
        Ray ray = new Ray(orientation.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, interactRange))
        {
            
            if (hit.collider != null)
            {
                
                if (hit.collider.GetComponent<InteractableObject>() != null)
                {
                    
                    targetObject = hit.collider.gameObject;
                    objectInteractableScript = targetObject.GetComponent<InteractableObject>().interactable;
                    interactText.text = targetObject.GetComponent<InteractableObject>().interactable.hoverText;
                    objectInteractableScript.hovering = true;

                    if (Input.GetKeyDown(objectInteractableScript.interactKey) && objectInteractableScript.interactable)
                    {
                        objectInteractableScript.Interact();
                    }

                }
                else ResetValues();
                
            } else ResetValues();
        }
    }
    void ResetValues()
    {
        targetObject = null;
        objectInteractableScript = null;
        interactText.text = string.Empty;
    }
}
