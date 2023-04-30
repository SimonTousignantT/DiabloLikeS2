using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_doorMP3;
    [SerializeField]
    private AudioClip m_door2MP3;
    private AudioSource m_audioSource;
    [SerializeField]
    private GameObject m_nextMap;
    private bool m_doorTriger = false;
    private float m_chronos = 0;
    private float m_timer = 0.1f;
    [SerializeField]
    private float m_doorSpeed = 2;
    private bool m_isFirstTriger = true;
    private float m_doorAngleOpen = 0;
    [SerializeField]
    private float m_doorAngleMax = 70;
    [SerializeField]
    private AudioClip m_candleActivationMP3;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_doorAngleOpen < 0)
        { m_doorTriger = false; }
        if (m_doorAngleOpen > m_doorAngleMax)
        { m_doorTriger = false; }
        if (m_doorTriger)
        {
            m_chronos += Time.deltaTime;
            if (m_chronos > m_timer)
            {


                transform.Rotate(new Vector3(0, m_doorSpeed, 0));
                m_doorAngleOpen += m_doorSpeed;


                m_chronos = 0;
                if (m_isFirstTriger)
                {
                    m_audioSource.PlayOneShot(m_doorMP3, 0.7F);
                    m_isFirstTriger = false;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject.GetComponent<Collider>());
            m_nextMap.SetActive(true);
            m_doorTriger = true;
        }
    }
    public void DoorEvent()
    {
        m_doorAngleMax += 2;
        m_doorSpeed = m_doorSpeed *- 2;
        m_doorTriger = true;
        m_audioSource.PlayOneShot(m_door2MP3, 0.7F);
        m_audioSource.PlayOneShot(m_candleActivationMP3, 4F);

    }
}
