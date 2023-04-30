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
    [SerializeField]
    private float m_attackRange = 6;
    private GameObject m_ennemiTarget;
    private int m_isEnnemi = 0;
    [SerializeField]
    private GameObject m_trowingAxe;
    [SerializeField]
    private float m_attackSpeed = 1;
    private float m_chronosAttack = 0;
    [SerializeField]
    private float m_rotationSpeed = 15;
    private bool m_imAlive = true;
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
        if (m_imAlive)
        {
            m_chronosForCinematic += Time.deltaTime;
            if (m_chronosForCinematic > m_timerForWhereAmI)
            {
                if (m_isMyFirstAwake)
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
                    m_animator.SetBool("Attack", false);
                    m_customRay = m_mainCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfos;
                    if (Physics.Raycast(m_customRay, out hitInfos))
                    {
                        if (hitInfos.collider.gameObject.tag != "Ennemi")
                        {
                            m_navAgent.stoppingDistance = 2;
                            m_navAgent.SetDestination(hitInfos.point);
                            m_isEnnemi = 0;
                        }
                        else
                        {
                            m_navAgent.stoppingDistance = m_attackRange;
                            m_navAgent.SetDestination(hitInfos.point);
                            m_ennemiTarget = hitInfos.collider.gameObject;
                            m_isEnnemi += 1;

                        }

                    }
                }
                if (m_navAgent.remainingDistance < m_navAgent.stoppingDistance)
                {
                    if (m_ennemiTarget)
                    {
                        if (m_ennemiTarget.tag == "Ennemi")
                        {
                            if (m_isEnnemi > 1)
                            {
                                Vector3 direction = (m_ennemiTarget.transform.position - transform.position).normalized;
                                Quaternion lookRotation = Quaternion.LookRotation(direction);
                                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * m_rotationSpeed);

                                m_animator.SetBool("Attack", true);
                                m_chronosAttack += Time.deltaTime;
                                if (m_chronosAttack > m_attackSpeed)
                                {

                                    Instantiate(m_trowingAxe, gameObject.transform.position + m_navAgent.transform.forward * 2, Quaternion.identity).GetComponent<NavMeshAgent>().SetDestination(m_ennemiTarget.transform.position);
                                    m_chronosAttack = 0;

                                }

                            }
                        }
                        else
                        {
                            m_animator.SetBool("Attack", false);
                        }

                    }
                    else
                    {
                        m_animator.SetBool("Attack", false);
                    }

                    m_animator.SetBool("walk", false);
                }
            }
        }
    }
    public void Death()
    {
        m_imAlive = false;
        m_animator.SetBool("Death", true);
    }
}
