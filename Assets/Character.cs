using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Character : MonoBehaviour {

    private Rigidbody m_Rigidbody;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Move(float h, float v, bool attack)
    {

    }

    private void updateAnimator(float h, float v, bool attack)
    {

    }
}
