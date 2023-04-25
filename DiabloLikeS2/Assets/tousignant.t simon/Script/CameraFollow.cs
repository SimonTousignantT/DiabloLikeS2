using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private Vector3 m_offSet = new Vector3(5, 10, 5);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = m_player.transform.position + m_offSet;
    }
}
