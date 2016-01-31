using UnityEngine;
using System.Collections;

public class LightDamage : MonoBehaviour {

    void Start()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Damageable d = other.gameObject.GetComponent<Damageable>();
            if (d != null)
            {
                d.OnHit(-10);
                Debug.Log(other.gameObject);
            }
        }
    }
}
