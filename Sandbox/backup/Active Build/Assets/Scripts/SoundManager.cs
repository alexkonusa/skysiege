using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource audioClip;

    public void PlaySound(AudioClip clip)
    {

        audioClip.clip = clip;
        audioClip.Play();

    }
}
