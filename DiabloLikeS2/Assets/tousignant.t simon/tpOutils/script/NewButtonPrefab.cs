using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewButtonPrefab : MonoBehaviour
{

    private string m_pathFolder = "ButtonPrefab";
    private GraphicRaycaster m_graphicRaycaster;
    private CanvasScaler m_canvasScaler;
    private Button[] m_myButtonList;
    private Button m_myButton;
    private GameObject m_myCanvas;
    private GameObject m_eventSystem;
    private Camera m_camera;
    private Vector3 m_cameraPos;
    private float m_posX = 0;
    private float m_posY = 0;
    private float m_buttonSpeed = 50;
    [SerializeField]
    private int m_dropAnim = 200;
    [SerializeField]
    private Vector3 m_dropScale = new Vector3(25, 25, 25);
    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.name.Contains("Empty"))
        {
            m_myCanvas = GameObject.Find("Canvas");
            //////////////////////////////////////
            m_myButtonList = Resources.LoadAll<Button>(m_pathFolder);
            m_myButton = Instantiate(m_myButtonList[0]);
            m_myButton.transform.parent = m_myCanvas.transform;
            m_myButton.transform.position = Input.mousePosition;
            //////////////////////////////////sert a retir/ le mots (Clone) du nom
            m_myButton.GetComponentInChildren<Text>().text = gameObject.name.Remove(gameObject.name.Length - 7, 7);
            /////////////////
            m_camera = Camera.main;
            m_cameraPos = m_camera.transform.localPosition;
            gameObject.layer = LayerMask.NameToLayer("Drop");
           
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.transform.localScale = m_dropScale;
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, m_dropAnim, 0));
       
    }

    // Update is called once per frame
    void Update()
    {
        if (m_myButton)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                m_myButton.gameObject.SetActive(true);
            }
            else
            {
                m_myButton.gameObject.SetActive(false);
            }
            
            
            if(m_camera.transform.localPosition != m_cameraPos)
            {
                m_posY = m_camera.transform.localPosition.z - m_cameraPos.z;
                m_posX = m_camera.transform.localPosition.x - m_cameraPos.x ;
                m_myButton.transform.position += new Vector3((m_posX  * m_buttonSpeed * -1 )/ 2 , m_posY * m_buttonSpeed * -1 , 0);
            }
            
            m_cameraPos = m_camera.transform.localPosition;

        }

       if(!m_myButton )
        {
            Destroy(gameObject);
        }

    }
    





}
