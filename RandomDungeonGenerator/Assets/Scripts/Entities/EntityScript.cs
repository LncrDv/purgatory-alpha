using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    public string entityName;
    public GameObject player;
    public GameObject prefab;
    public int spawnedAtDoor;
    public Spawner spawner;
    

    // Start is called before the first frame update
    public virtual void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        prefab = gameObject;
    }

    public virtual void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= 300)
        {
            Destroy(gameObject);
        }
    }
}
