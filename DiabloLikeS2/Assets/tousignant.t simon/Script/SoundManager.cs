using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_startGameSound;
    private Scene m_currentScene;
    private AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        m_currentScene = SceneManager.GetActiveScene();
        if(m_currentScene.name == "GameOver")
        {
            Destroy(gameObject);
        }
        
    }
    public void ButtonStartPress()
    {
        m_audioSource.PlayOneShot(m_startGameSound, 0.7F);
    }
}
