using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inter_Door : Interactable
{
    public TextMeshPro textMeshPro;
    public MeshRenderer meshRenderer;

    public GameObject planks;
    public string doorNumber;
    public bool isJammed;
    public void Start()
    {
        //20% chance to be jammed door
        isJammed = Random.Range(0, 5) == 0 ? true : false;
        
        
    }
    public override void Update()
    {
        base.Update();
        interactable = !isJammed;
        hoverText = isJammed ? $"Jammed Door" : hoverText;
        planks.SetActive(isJammed);
        textMeshPro.text = doorNumber;
    }
    public override void Interact()
    {
        GetComponent<BoxCollider>().enabled = false;
        FindObjectOfType<Spawner>().door++;
        FindObjectOfType<Spawner>().SpawnNewRoom();
        Destroy(planks);
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().sliding && isJammed)
            {
                Interact();
            }
        }

    }
}
