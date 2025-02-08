using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private GameObject playerGo;

    public Slider volumeSlider, FOVSlider, mouseSensitivitySlider;

    private void Start()
    {
        playerGo = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        if(!PlayerHealthManager.Instance.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
                playerGo.GetComponent<PlayerMovement>().enableInput = !GetComponent<Canvas>().enabled;
                Camera.main.GetComponent<PlayerCam>().enabled = !GetComponent<Canvas>().enabled;
                Cursor.lockState = GetComponent<Canvas>().enabled ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = GetComponent<Canvas>().enabled;
            }
        }
        

        ManageVolume();
        ManageFOV();
        ManageMouseSens();
    }

    void ManageVolume()
    {
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().volume = volumeSlider.value / 10;
    }
    void ManageFOV()
    {
        Camera.main.fieldOfView = FOVSlider.value;
    }
    void ManageMouseSens()
    {
        Camera.main.GetComponent<PlayerCam>().sensX = mouseSensitivitySlider.value;
        Camera.main.GetComponent<PlayerCam>().sensY = mouseSensitivitySlider.value;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
