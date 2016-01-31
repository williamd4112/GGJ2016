using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Character : MonoBehaviour {

    [SerializeField]
    private float m_WalkSpeed = 3.0f;

    private Rigidbody m_Rigidbody;
    private Animator m_Animator;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Move(float h, float v, bool attack)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v).normalized,
            transform.up);
        Vector3 velocity = new Vector3(h, 0, v).normalized * m_WalkSpeed;
        m_Rigidbody.velocity = velocity;
        updateAnimator(h, v, attack);
    }

    private void updateAnimator(float h, float v, bool attack)
    {
        m_Animator.SetFloat("Speed", m_Rigidbody.velocity.magnitude);
        Debug.Log(m_Rigidbody.velocity.magnitude);
        m_Animator.SetBool("Attack", attack);
    }
}
