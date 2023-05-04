using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
public class DropManager : EditorWindow
{
    private int m_emptyNb = 0;
    private GameObject m_myGameObject;
    private string m_itemName;
    private string m_pathFolder = "Assets/Resources/Drop/";
    private static DropManager m_window = null;
    private GameObject[] m_myPrefabList;
    private int m_prefabVarientNb;
    private string[] m_nameList;
    private GameObject m_selectedObjectPrefab;

    // Start is called before the first frame update
    [MenuItem("Window/WindowsDropCreator")]
    private static void DropCreator()
    {
        if (m_window == null)
        {
            m_window = GetWindow<DropManager>();
            m_window.titleContent = new GUIContent("Drop Creator");
        }

    }

    private void Update()
    {

    }

    private void OnGUI()
    {
        if (!Directory.Exists("Assets/Resources/Drop"))
        {
            if (!Directory.Exists("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }
            AssetDatabase.CreateFolder("Assets/Resources", "Drop");

        }
        if (!Directory.Exists("Assets/Resources/Prefab"))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "Prefab");
        }
        if (GUILayout.Button("add Empty drop"))
        {
            m_myGameObject = new GameObject();
            m_myGameObject.name = "Empty" + m_emptyNb;
            m_myGameObject.AddComponent<NewButtonPrefab>();
            ///le met dans asset puis le detruit
            PrefabUtility.SaveAsPrefabAsset(m_myGameObject, m_pathFolder + m_myGameObject.name + ".prefab");
            DestroyImmediate(m_myGameObject);
            m_emptyNb += 1;
        }
        if (GUILayout.Button("add my Drop Folder"))
        {

            m_myGameObject = new GameObject();
            m_myGameObject.name = m_itemName;
            m_myGameObject.AddComponent<NewButtonPrefab>();
            m_myGameObject.AddComponent<MeshRenderer>();
            m_myGameObject.GetComponent<MeshRenderer>().material = m_selectedObjectPrefab.GetComponent<MeshRenderer>().sharedMaterial;
            m_myGameObject.AddComponent<MeshFilter>();
            m_myGameObject.GetComponent<MeshFilter>().mesh = m_selectedObjectPrefab.GetComponent<MeshFilter>().sharedMesh;
            
            ///le met dans asset puis le detruit
            PrefabUtility.SaveAsPrefabAsset(m_myGameObject, m_pathFolder + m_myGameObject.name + ".prefab");
            DestroyImmediate(m_myGameObject);
        }
        GUILayout.Label("Name:");
        m_itemName = GUILayout.TextField(m_itemName);
        //////////////////////////
        m_myPrefabList = Resources.LoadAll<GameObject>("Prefab");
        m_nameList = new string[m_myPrefabList.Length];
        for (int i = 0; i < m_myPrefabList.Length; i++)
        {
            m_nameList[i] = m_myPrefabList[i].name;
        }
        m_prefabVarientNb = GUILayout.Toolbar(m_prefabVarientNb, m_nameList);
        m_selectedObjectPrefab = m_myPrefabList[m_prefabVarientNb];



    }


}
