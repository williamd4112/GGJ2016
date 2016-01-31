using UnityEngine;
using System.Collections;

public class SkeletonHurt : MonoBehaviour {

    private Animator m_Animator;

	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
        GetComponent<Damageable>().RegisterDamageEvent(OnDamage);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDamage()
    {
        m_Animator.SetTrigger("Hurt");
    }
}
