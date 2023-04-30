using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifePlayer : MonoBehaviour
{
    [SerializeField]
    private Image m_healthBar;
    [SerializeField]
    private Image m_interpolationOnDeath;
    [SerializeField]
    private float m_maxLife = 100;
    private float m_life;
    private float m_chronos;
    [SerializeField]
    private int m_timerLoadScene = 15;
    private float m_interpolationSpeed = 0.1f;
    [SerializeField]
    private AudioClip m_death;
    private AudioSource m_audioSource;
    private bool m_firstPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
        m_life = m_maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        m_healthBar.fillAmount = m_life/m_maxLife ;
        if(m_life < 1)
        {
            if(m_firstPlay)
            {
                m_audioSource.PlayOneShot(m_death, 0.7F);
                m_firstPlay = false;
            }
            gameObject.GetComponent<PlayerMove>().Death();
            m_chronos += Time.deltaTime;
            m_interpolationOnDeath.color = Color.Lerp(Color.clear, Color.black, m_interpolationSpeed += m_interpolationSpeed * Time.deltaTime);
            if (m_chronos > m_timerLoadScene)
            {
                SceneManager.LoadScene("GameOver");

            }

        }
    }
    public void PlayerTakeDamage(float damage)
    {
        m_life -= damage;
    }
}
