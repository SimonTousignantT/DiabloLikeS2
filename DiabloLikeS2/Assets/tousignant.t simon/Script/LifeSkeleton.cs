using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class LifeSkeleton : MonoBehaviour
{
    [SerializeField]
    private SkeletonEnemi m_otherScript;
    private Camera m_mainCamera;
    private Ray m_customRay;
    private Animator m_animator;
    private Canvas m_healthBar;
    [SerializeField]
    private Image m_lifeBar;
    private float m_life;
    [SerializeField]
    private float m_maxLife = 100;
    private Vector3 m_position;
    private float m_dieChronos = 0;
    [SerializeField]
    private float m_dieTimer = 30;
    private Vector3 m_colliderScale;
    private GameObject m_player; 
    
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_animator = GetComponent<Animator>();
        m_life = m_maxLife;
        m_healthBar = gameObject.GetComponentInChildren<Canvas>();
        m_mainCamera = Camera.main;
        m_colliderScale = GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {

        m_lifeBar.fillAmount = m_life / m_maxLife;
        m_customRay = m_mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfos;
        if (Physics.Raycast(m_customRay, out hitInfos))
        {
            if (hitInfos.collider.gameObject == this.gameObject)
            {
                m_healthBar.gameObject.SetActive(true);

            }
            else
            {
                m_healthBar.gameObject.SetActive(false);
            }
        }
        if (m_life > 0)
        {
            m_otherScript.ImDead(false);
            m_position = transform.position;

        }
        if (m_life < 1)
        {
            Destroy(gameObject.GetComponent<Collider>());
            m_otherScript.ImDead(true);
            m_animator.SetBool("SkeletonDie", true);
            transform.position = m_position;
            m_healthBar.gameObject.SetActive(false);
            m_dieChronos += Time.deltaTime;
            gameObject.tag = "Debris";
            if (m_dieChronos > m_dieTimer)
            {
                if (GetComponent<NavMeshAgent>().stoppingDistance < GetComponent<NavMeshAgent>().remainingDistance)
                {
                    m_animator.SetTrigger("WakeUp");
                    m_animator.SetBool("SkeletonDie", false);
                    gameObject.tag = "Ennemi";
                    m_life = m_maxLife;
                    m_dieChronos = 0;
                    gameObject.AddComponent<BoxCollider>().size = m_colliderScale;
                }
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "TrowingAxe")
        {
            Destroy(collision.gameObject);
            m_life -= 10;
        }
    }


}
