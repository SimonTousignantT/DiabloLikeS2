using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject m_debris;
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
            Instantiate(m_debris, transform.position,Quaternion.identity).transform.Rotate(new Vector3(-100,0,0));
            Destroy(collision.gameObject);
            Destroy(gameObject);
           
            
        }
        if (collision.collider.tag == "Player")
        {
            Instantiate(m_debris, transform.position, Quaternion.identity).transform.Rotate(new Vector3(-100, 0, 0));
            
            Destroy(gameObject);


        }
    }
}
