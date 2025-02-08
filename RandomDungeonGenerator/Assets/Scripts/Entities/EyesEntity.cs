using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EyesEntity : EntityScript
{
    public AudioSource SFXPlayer;
    public AudioClip near, attack;
    public bool isAttacking = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        SFXPlayer.clip = near;
        SFXPlayer.loop = true;
        SFXPlayer.Play();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);



        if (Physics.Raycast(ray, out hit) && !isAttacking)
        {

            if (hit.collider.gameObject == gameObject)
            {

                isAttacking = true;
                GetComponent<Collider>().enabled = false;
                FindObjectOfType<PlayerHealthManager>().GetComponent<PlayerHealthManager>().KillPlayer(gameObject);
                Destroy(gameObject);

            }
        }
        transform.LookAt(player.transform);
    }
}
