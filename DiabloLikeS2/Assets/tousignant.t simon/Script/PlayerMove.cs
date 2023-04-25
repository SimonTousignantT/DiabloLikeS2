using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Camera m_mainCamera;
    private Ray m_customRay;
    private Animator m_animator;
    private NavMeshAgent m_navAgent;
    private float m_chronosForCinematic = 0;
    [SerializeField]
    private int m_timerForCinematic = 10;
    [SerializeField]
    private int m_timerForWhereAmI = 5;
    [SerializeField]
    private AudioClip m_WhereAmI;
    private AudioSource m_audioSource;
    private bool m_isMyFirstAwake = true;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
        m_navAgent = gameObject.GetComponent<NavMeshAgent>();
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_chronosForCinematic += Time.deltaTime;
        if (m_chronosForCinematic > m_timerForWhereAmI)
        {
            if(m_isMyFirstAwake)
            { 
                m_audioSource.PlayOneShot(m_WhereAmI, 0.7F);
                m_isMyFirstAwake = false;
            }
           
        }
        if (m_chronosForCinematic > m_timerForCinematic)
        {
            if (Input.GetMouseButton(0))
            {
                m_animator.SetBool("walk", true);
                m_customRay = m_mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfos;
                if (Physics.Raycast(m_customRay, out hitInfos))
                {
                    m_navAgent.SetDestination(hitInfos.point);

                }
            }
            if (m_navAgent.remainingDistance < m_navAgent.stoppingDistance)
            {


                m_animator.SetBool("walk", false);
            }
        }
    }
}
