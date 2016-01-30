﻿using UnityEngine;
using System.Collections;

public class PlayerDamageable : MonoBehaviour {

    [SerializeField]
    private GameObject m_OnHitEffect;
    [SerializeField]
    private AudioClip m_OnHitSound;
    [SerializeField]
    private GameObject m_OnDeadEffect;
    [SerializeField]
    private AudioClip m_OnDeadSound;
    [SerializeField]
    private Hearts m_Hearts;
    [SerializeField]
    private float m_HitDelay = 0.5f;

    private bool m_IsDamageable = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision other)
    {
        if(m_IsDamageable && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject);
            m_Hearts.Dmg();
            StartCoroutine(Countdown(m_HitDelay));
            m_IsDamageable = false;
        }
    }

    IEnumerator Countdown(float t)
    {
        yield return new WaitForSeconds(t);
        m_IsDamageable = true;
    }
}