using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class axeBoostAim : MonoBehaviour
{
    private float m_remainingDistance;
    private NavMeshAgent m_navAgent;
    // Start is called before the first frame update
    void Start()
    {
        m_navAgent = GetComponent<NavMeshAgent>();
        m_remainingDistance = m_navAgent.remainingDistance;
    }

    // Update is called once per frame
    void Update()
    {
      
      
    }
}
