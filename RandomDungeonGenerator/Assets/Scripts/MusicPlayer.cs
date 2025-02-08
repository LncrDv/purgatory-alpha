using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip VHSloading, destroyCassetteSFX, windSFX;
    public AudioClip[] SFXs;
    public bool canPlayMusic = true, canGlitch = true;

    public List<AudioClip> queue = new List<AudioClip>();
    public int queueIndex;

    public bool hasBoombox = false;

    private void Start()
    {
        queueIndex = -1;
        queue.Add(VHSloading);
        queue.Add(SFXs[Random.Range(0, SFXs.Length)]);
        audioPlayer.clip = null;
        audioPlayer.loop = false;
    }
    void Update()
    {
        if (queueIndex > queue.Count)
        {
            queueIndex = -1;
        }
        if(hasBoombox)
            PlayQueue();


        if(FindObjectOfType<Spawner>().door >= 5)
        {
            if(canPlayMusic)
            {
                canPlayMusic = false;
                audioPlayer.clip = null;
                ClearQueue();
                queue.Add(destroyCassetteSFX);
                queue.Add(windSFX);
            
            }
            audioPlayer.loop = (audioPlayer.clip == windSFX);


        }
    }

    void PlayQueue()
    {
        if(audioPlayer.isPlaying == false)
        {
            queueIndex++;
            audioPlayer.clip = queue[queueIndex];
            audioPlayer.Play();

        }

    }
    public void ClearQueue()
    {
        queue.Clear();
        queueIndex = -1;
    }
    public void GoToEndOfQueue()
    {
        audioPlayer.clip = null;
        queueIndex = queue.Count - 2;

    }
    public void DeleteLastSFX()
    {
        queue.RemoveAt(queue.Count-1);
    }
    public void ImmediatePlaySound(AudioClip sfx)
    {
        audioPlayer.Stop();
        audioPlayer.clip = sfx;
        audioPlayer.Play();
    }
}
