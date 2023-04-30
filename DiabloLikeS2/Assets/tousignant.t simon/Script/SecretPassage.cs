using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassage : MonoBehaviour
{
    private bool m_isActivate = false;
    [SerializeField]
    private GameObject m_door;
    private float m_chronos = 0;
    private float m_timer = 0.1f;
    [SerializeField]
    private float m_speed = 0.1f;
    private bool m_haveRotate = false;
    private float m_rotate = -10f;
    [SerializeField]
    private float m_mooveDownMax = 30;
    private float m_mooveDown = 0;
    [SerializeField]
    private float m_speedPassage = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isActivate)
        {
            m_chronos += Time.deltaTime;
            if(m_chronos > m_timer)
            {

                if (m_haveRotate == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, 0, m_rotate += m_rotate ));
                    m_haveRotate = true;
                }
                m_chronos = 0;
                m_door.transform.Translate(new Vector3(0, m_mooveDown  , 0));
                m_mooveDown -= Time.deltaTime * m_speedPassage;
            }
            if(m_door.transform.position.y * -1 > m_mooveDownMax  )
            {
                Destroy(m_door);
                m_isActivate = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            m_isActivate = true;
            Destroy(gameObject.GetComponent<Collider>());
        }
    }
}
