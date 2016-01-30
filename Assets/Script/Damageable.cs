using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

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


	// Use this for initialization
	void Start () {
        if (m_OnHitEffect != null)
            m_OnHitEffect.SetActiveRecursively(false);
        m_Health = m_MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHit(int damageAmount)
    {
		if (isFirst) {
			isFirst = false;
			if (m_OnHitEffect != null) {
				m_OnHitEffect.SetActiveRecursively (true);
			}
			Debug.LogFormat ("{0} hit", gameObject);
			ChangeHealth (damageAmount);
			StartCoroutine ("Recover");
		}
    }

    public void OnDeath()
    {
        if(m_OnDeathEffect != null)
        {

        }
        Destroy(gameObject);
    }

    void ChangeHealth(int diff)
    {
        m_Health = Mathf.Clamp(m_Health + diff, 0, m_MaxHealth);
        Debug.Log(m_Health);
        if (m_Health <= 0)
            OnDeath();
    }

	IEnumerator Recover(){
		yield return new WaitForSeconds (recovTime);
		isFirst = true;
	}
}
