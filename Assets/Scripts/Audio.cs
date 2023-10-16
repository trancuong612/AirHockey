using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip PuckCollision;
    public AudioClip Goal;
    public AudioClip LostGame;
    public AudioClip WinGame;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }
       public void PlayLostGame()
    {
        audioSource.PlayOneShot(LostGame);
    }

    public void PlayWinGame()
    {
        audioSource.PlayOneShot(WinGame);
    }
}
