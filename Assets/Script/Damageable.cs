using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

    public delegate void DamageEvent();

    [SerializeField]
    private GameObject m_OnHitEffect;
    [SerializeField]
    private AudioClip m_OnHitSound;
    [SerializeField]
    private GameObject m_OnDeathEffect;
    [SerializeField]
    private AudioClip m_OnDeathSound;
	[SerializeField]
	private ParticleSystem m_HitPart;
    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int m_MaxHealth = 100;
	[SerializeField]
	private bool isFirst = true;
	[SerializeField]
	private float recovTime = 5.0f;

    private Hearts m_Heart;

    private DamageEvent m_DmgEvents;
    public void RegisterDamageEvent(DamageEvent e)
    {
        m_DmgEvents += e;
    }

    public void InvokeDamageEvent()
    {
        if (m_DmgEvents != null)
            m_DmgEvents.Invoke();
    }

	// Use this for initialization
	void Start () {
        m_Health = m_MaxHealth;
        m_Heart = GameObject.Find("Hearts").GetComponent<Hearts>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHit(int damageAmount)
    {
		if (isFirst) {
			isFirst = false;

            GameObject dummy = GameObject.Instantiate(m_OnHitEffect, transform.position, transform.rotation) as GameObject;
            Destroy(dummy, recovTime);

            AudioSource.PlayClipAtPoint(m_OnHitSound, transform.position);
            Camera.main.GetComponent<CamShake>().ShakeAndBake();
            ChangeHealth (damageAmount);
            InvokeDamageEvent();
			StartCoroutine ("Recover");
		}
    }

    public void OnDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if(Random.Range(0, 6) % 5 == 0)
            {
                m_Heart.Heal();
            }
            EnemyMaker.ReturnEnemy();
        }
		Hearts.Instance.GetScore ();
        Destroy(gameObject);
    }

    void ChangeHealth(int diff)
    {
        m_Health = Mathf.Clamp(m_Health + diff, 0, m_MaxHealth);
        if (m_Health <= 0)
            OnDeath();
    }

	IEnumerator Recover(){
		yield return new WaitForSeconds (recovTime);
		isFirst = true;
	}
}
