using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Rooms \n")]
    public GameObject[] roomsPrefab;
    public Room[] roomsSpecs;
    public List<GameObject> spawnedRooms = new List<GameObject>();
    public int door;
    public int direction;

    private GameObject lastRoom;

    [Header("\n Entities \n")]

    /* OLD
    public GameObject[] entitiesPrefab;
    public Entity[] entitiesSpecs;
    public List<GameObject> spawnedEntities = new List<GameObject>();
    */

    public EntitySpawnRules[] entitySpawnRules;
    public List<GameObject> spawnedEntities = new List<GameObject>();

    public int chosenEntitySpawnRules;


    private void Start()
    {
        chosenEntitySpawnRules = Random.Range(0, entitySpawnRules.Length);
        door = -1;
        direction = 1;
        lastRoom = roomsPrefab[0];
        for(int i = 0; i < 5; i++)
            SpawnNewRoom();
    }
    private void Update()
    {

        if(door >= 10)
        {
            if (spawnedRooms[door - 10] != null)
            {
                Destroy(spawnedRooms[door - 10].gameObject);
            }

        }



    }

    private void SpawnEntity(GameObject entity)
    {
        Debug.Log("Spawned " + entity.name);
        var spawnedEntity = Instantiate(entity, new Vector3(lastRoom.transform.position.x, lastRoom.transform.position.y + lastRoom.GetComponent<Room>().doorOffset.y * 1.5f, lastRoom.transform.position.z), Quaternion.identity);
        spawnedEntity.GetComponent<EntityScript>().spawnedAtDoor = spawnedRooms.IndexOf(lastRoom);
        spawnedEntities.Add(spawnedEntity);
    }

    public void SpawnNewRoom()
    {
        int nextRoomIndex = Random.Range(0, roomsPrefab.Length);
        var nextRoomPrefab = roomsPrefab[nextRoomIndex];
        var nextRoomSpec = roomsSpecs[nextRoomIndex];
        var nextRoomSpawnPos = lastRoom.transform.position + new Vector3(
            -lastRoom.GetComponent<Room>().roomSize.x,
            lastRoom.GetComponent<Room>().doorOffset.y,
            0);

        var newRoom = Instantiate(nextRoomPrefab, nextRoomSpawnPos, Quaternion.identity);
        spawnedRooms.Add(newRoom);
        newRoom.GetComponent<Room>().door.doorNumber = spawnedRooms.IndexOf(newRoom).ToString();
        lastRoom = newRoom;

        /* OLD
        for (int e = 0; e < entitiesPrefab.Length; e++)
        {
            if (Random.Range(0, 100) <= entitiesSpecs[e].appearanceChance)
            {
                SpawnEntity(entitiesPrefab[e]);
                break;
            }
        }
        */

        foreach (SpawnRule _entity in entitySpawnRules[chosenEntitySpawnRules].spawnRules)
        {
            if (_entity.doorSpawn == spawnedRooms.IndexOf(newRoom))
            {
                //If the entity has to spawn in the current room
                SpawnEntity(_entity.entityScript.prefab);
            }
        }


    }
}
