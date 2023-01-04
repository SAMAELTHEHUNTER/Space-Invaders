using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private float m_ForceBullet;
    [SerializeField] private Vector3 m_Offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(m_BulletPrefab, transform.position + m_Offset, Quaternion.identity, transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_ForceBullet);
        }
    }
}
