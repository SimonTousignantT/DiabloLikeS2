using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifePlayer : MonoBehaviour
{
    [SerializeField]
    private Image m_healthBar;
    [SerializeField]
    private float m_maxLife = 100;
    private float m_life;
    // Start is called before the first frame update
    void Start()
    {
        m_life = m_maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        m_healthBar.fillAmount = m_life/m_maxLife ;
        if(m_life < 1)
        {
            gameObject.GetComponent<PlayerMove>().Death();
        }
    }
    public void PlayerTakeDamage(float damage)
    {
        m_life -= damage;
    }
}
