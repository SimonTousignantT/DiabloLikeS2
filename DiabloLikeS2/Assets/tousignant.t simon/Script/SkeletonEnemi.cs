using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonEnemi : MonoBehaviour
{
    private GameObject m_player;
    private NavMeshAgent m_navAgent;
    private Animator m_animator;
    private float m_attackChonos = 1.5f;
    [SerializeField]
    private float m_attackSpeed = 1;
    private LifePlayer m_playerLife;
    [SerializeField]
    private float m_stoppingDistance = 2;
    private bool m_imAmDead = false;
    private bool m_event = false;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_animator = GetComponent<Animator>();
        m_navAgent = GetComponent<NavMeshAgent>();
        m_playerLife = GameObject.Find("Player").GetComponent<LifePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_event)
        {
            if (m_imAmDead == false)
            {
                GetComponent<NavMeshAgent>().SetDestination(m_player.transform.position);
                if (m_navAgent.remainingDistance < m_navAgent.stoppingDistance)
                {
                    m_animator.SetBool("SkeletonWalk", false);
                    m_animator.SetBool("SkeletonAttack", true);
                    m_attackChonos += Time.deltaTime;
                    if (m_attackChonos > m_attackSpeed)
                    {
                        m_playerLife.PlayerTakeDamage(10);
                        m_attackChonos = 0;
                        m_navAgent.stoppingDistance = 3f;
                    }

                }
                else
                {
                    m_attackChonos = 1.5f;
                    m_animator.SetBool("SkeletonWalk", true);
                    m_animator.SetBool("SkeletonAttack", false);
                    m_navAgent.stoppingDistance = 2;
                }
            }
        }
    }
    public void ImDead(bool imDead)
    {
        m_imAmDead = imDead;
    }
    public void EventTriger()
    {
        m_event = true;
    }
   
}
