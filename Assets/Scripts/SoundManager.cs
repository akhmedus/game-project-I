using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
            Destroy(gameObject);

    }
    public void PlaySound(AudioClip audioClip) 
    {
        audioSource.PlayOneShot(audioClip);
    }
}
