using UnityEngine;
using System.Collections;

public class LightDamage : MonoBehaviour {

    private CamShake m_Shake;

    void Start()
    {
        m_Shake = Camera.main.GetComponent<CamShake>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Damageable d = other.gameObject.GetComponent<Damageable>();
            if (d != null)
            {
                d.OnHit(-10);
                m_Shake.ShakeAndBake();
                Debug.Log(other.gameObject);
            }
        }
    }
}
