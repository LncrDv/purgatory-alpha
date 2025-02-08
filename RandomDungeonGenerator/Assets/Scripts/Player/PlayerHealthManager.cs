using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealthManager : MonoBehaviour
{
    public int health;
    public bool isDead=false;

    public GameObject jumpscareCanvas;
    public AudioClip attackSFX;

    public static PlayerHealthManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void KillPlayer(GameObject invoker)
    {
        isDead = true;
        FindObjectOfType<PlayerMovement>().GetComponentInChildren<MeshRenderer>().enabled = false;
        FindObjectOfType<PlayerMovement>().GetComponentInChildren<Collider>().enabled = false;
        FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().enableInput = false;
        Camera.main.transform.parent.GetComponent<MoveCamera>().enabled = false;
        Camera.main.GetComponent<PlayerCam>().enabled = false;
        Camera.main.AddComponent<Rigidbody>();
        Camera.main.GetComponent<Rigidbody>().drag = 3f;
        Camera.main.AddComponent<SphereCollider>();

        if (invoker.gameObject.GetComponent<EntityScript>() != null)
        {
            GetComponent<AudioSource>().clip = attackSFX;
            GetComponent<AudioSource>().Play();
            FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Stop();
            jumpscareCanvas.GetComponent<Image>().sprite = invoker.gameObject.GetComponent<SpriteRenderer>().sprite;
            jumpscareCanvas.SetActive(true);
            Invoke("QuitApp", GetComponent<AudioSource>().clip.length / 1.5f);
        }
    }
    public void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    
}
