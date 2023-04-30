using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneActivate : MonoBehaviour
{
    [SerializeField]
    private Door m_doorScript;
    [SerializeField]
    private GameObject[] m_gameObjectNeedActivate;
    [SerializeField]
    private GameObject m_onContactWith;
    [SerializeField]
    private GameObject[] m_skeleton;
   
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == m_onContactWith.GetComponent<Collider>())
        {
            for (int i = 0; i < m_gameObjectNeedActivate.Length; i++)
            {
                m_gameObjectNeedActivate[i].SetActive(true);
            }
            m_doorScript.DoorEvent();
            for (int i = 0; i < m_skeleton.Length; i++)
            {
                m_skeleton[i].GetComponent<SkeletonEnemi>().EventTriger();
                m_skeleton[i].GetComponent<Animator>().SetTrigger("Event");
                
            }
            gameObject.SetActive(false);


        }
    }
}
