using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    private float m_chronos;
    [SerializeField]
    private int m_timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_chronos += Time.deltaTime;
        if(m_chronos > m_timer)
        {
            Destroy(gameObject);
        }
    }
}
