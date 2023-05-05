using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrelDestroy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject m_debris;
    [SerializeField]
    private MyRandomDrop m_radomDrop;
    private Object m_drop;
    
    

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
        if(collision.collider.tag == "TrowingAxe" )
        {

            try
            {

                m_drop = m_radomDrop.TakeRandomDrop();
                Instantiate(m_drop, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            }
            catch { Debug.Log("folder Drop vide"); }

           
            Instantiate(m_debris, transform.position,Quaternion.identity).transform.Rotate(new Vector3(-100,0,0));
            Destroy(collision.gameObject);
            Destroy(gameObject);
           
            
        }
        if (collision.collider.tag == "Player")
        {
            Instantiate(m_debris, transform.position, Quaternion.identity).transform.Rotate(new Vector3(-100, 0, 0));
            
            Destroy(gameObject);
            try
            {

                m_drop = m_radomDrop.TakeRandomDrop();
                Instantiate(m_drop, new Vector3(transform.position.x,transform.position.y + 1 ,transform.position.z), Quaternion.identity);
            }
            catch { Debug.Log("folder Drop vide"); }


        }
    }
}
