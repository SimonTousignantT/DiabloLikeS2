using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class MyRandomDrop : MonoBehaviour
{
    
    private GameObject[] m_drop ;
    private string m_path = "Drop";
    // Start is called before the first frame update
    void Start()
    {
        m_drop = Resources.LoadAll<GameObject>(m_path);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public GameObject TakeRandomDrop()
    {
        return m_drop[Random.Range(0, m_drop.Length)];
    }
}
