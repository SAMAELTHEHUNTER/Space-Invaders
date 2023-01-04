using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invunrablitiy : MonoBehaviour
{
    private Animator m_HeroAnimator;
    [SerializeField] bool m_IsInvu = false;
    // Start is called before the first frame update
    void Start()
    {
        m_HeroAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_HeroAnimator.SetBool("IsInvunrable", true);
        }
        if (m_HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Invu"))
        {
            m_IsInvu = true;
            m_HeroAnimator.SetBool("IsInvunrable", false);
        }
        else 
        {
            m_IsInvu = false;
        }
    }
}
