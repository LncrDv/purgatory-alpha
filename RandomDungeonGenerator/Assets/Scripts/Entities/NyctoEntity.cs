using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NyctoEntity : EntityScript
{
    public AudioSource SFXPlayer;
    public AudioClip near, attack;

    public override void Start()
    {
        base.Start();
        SFXPlayer.enabled = false;
        transform.position -= new Vector3(spawner.spawnedRooms[spawnedAtDoor].GetComponent<Room>().roomSize.x * -5f, 0, 0);

    }
    public override void Update()
    {
        transform.LookAt(player.transform);
        if (spawner.door >= spawnedAtDoor)
        {
            
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider>().enabled = true;

            SFXPlayer.enabled = true;
            if(!SFXPlayer.isPlaying)
            {
                SFXPlayer.Play();
            }
            
            
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, player.GetComponent<PlayerMovement>().sprintSpeed * 2.5f * Time.deltaTime);
        }
        else
        {
            SFXPlayer.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.parent != null)
        {
            if(collision.transform.parent.GetComponent<PlayerMovement>() != null)
            {
                FindObjectOfType<PlayerHealthManager>().GetComponent<PlayerHealthManager>().KillPlayer(gameObject);
                Destroy(gameObject);
            }
            
        }
    }
}
