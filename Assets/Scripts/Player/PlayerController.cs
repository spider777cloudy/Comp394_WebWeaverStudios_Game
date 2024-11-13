using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components.HP;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform m_attackPoint;

    private Animator m_animator;

    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();

        GetComponent<HPStats>().OnDeath += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timer that controls attack combo
        m_timeSinceAttack += Time.deltaTime;

        float inputX = Input.GetAxis("Horizontal");

        Vector3 attackPointFront = new Vector3(0.3f, 0, 0);
        Vector3 attackPointBack = new Vector3(-0.3f, 0, 0);

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            m_attackPoint.localPosition = attackPointFront;
        }

        else if (inputX < 0)
        {
            m_attackPoint.localPosition = attackPointBack;
        }


        if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f)
        {
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            m_animator.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }

    public void TakeDamageAnim()
    {
        m_animator.SetTrigger("Hurt");
    }

    void OnDeath()
    {
        m_animator.SetTrigger("Death");
    }

    void OnDestroy()
    {
        GetComponent<HPStats>().OnDeath -= OnDeath;
    }
}
