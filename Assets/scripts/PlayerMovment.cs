using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float m_speed = 1f;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private float m_rotation = 1f;
    private Rigidbody2D m_PlayerRigidBody;
    private bool IsDead = false;


    void Start()
    {
        m_PlayerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var inputHorizontal = 0f;
        var inputVertical = 0f;
        if (!IsDead)
        {
            inputHorizontal = Input.GetAxis("Horizontal");
            inputVertical = Input.GetAxis("Vertical");
        }
        if (inputHorizontal != 0)
        {
            m_PlayerRigidBody.velocity = new Vector2(m_speed * inputHorizontal, m_PlayerRigidBody.velocity.y);
            transform.rotation = Quaternion.Euler(0, m_rotation * inputHorizontal, 0);
        }
        else
        {
            m_PlayerRigidBody.velocity = new Vector2(0, m_PlayerRigidBody.velocity.y);
        }

        if (inputVertical != 0)
        {
            m_PlayerRigidBody.velocity = new Vector2(m_PlayerRigidBody.velocity.x, m_speed * inputVertical);
        }
        else
        {
            m_PlayerRigidBody.velocity = new Vector2(m_PlayerRigidBody.velocity.x, 0);
        }


        if (IsDead)
        {
            Enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            EndPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            IsDead = true;
        }
    }
}
