using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchSound : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void clicked()
    {
        audioSource.Play();
    }
}

