using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSlimes : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
