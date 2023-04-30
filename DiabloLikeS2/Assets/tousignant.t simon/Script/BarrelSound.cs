using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_destroyMP3;
    private AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.PlayOneShot(m_destroyMP3, 0.7F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
