using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(MusicPlayer))]
public class MusicPlayerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        MusicPlayer musicPlayer = (MusicPlayer)target;
        if(GUILayout.Button("Skip SFX"))
        {
            musicPlayer.audioPlayer.Stop();
            musicPlayer.audioPlayer.clip = null;

        }
        if (GUILayout.Button("Clear Queue"))
        {
            musicPlayer.ClearQueue();

        }
        if (GUILayout.Button("Go to end of Queue"))
        {
            musicPlayer.GoToEndOfQueue();

        }
        if (GUILayout.Button("Delete last SFX"))
        {
            musicPlayer.DeleteLastSFX();

        }

    }
}
[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerMovement playerMovement = (PlayerMovement)target;
        if (GUILayout.Button("Set to slow movement"))
        {
            playerMovement.walkSpeed = 3;
            playerMovement.sprintSpeed = 5;
            playerMovement.slideSpeed = 6;
            playerMovement.groundDrag = 7;
            playerMovement.crouchSpeed = 1;
            playerMovement.jumpForce = 8;

        }
        if (GUILayout.Button("Set to fast movement"))
        {
            playerMovement.walkSpeed = 12;
            playerMovement.sprintSpeed = 15;
            playerMovement.slideSpeed = 18;
            playerMovement.groundDrag = 5;
            playerMovement.crouchSpeed = 8;
            playerMovement.jumpForce = 16;

        }
    }

}
/*
[CustomEditor(typeof(InventoryManager))]
public class InventoryManagerCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        InventoryManager inventoryManager = (InventoryManager)target;
        if(GUILayout.Button("Add random item"))
        {
            inventoryManager.AddItem(new Item("PlaceHolder"));
        }
    }
}
*/

