using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    public void DropTake()
    {
        Debug.Log("PlayerTakeDrop");
        Destroy(gameObject);
    }
}
