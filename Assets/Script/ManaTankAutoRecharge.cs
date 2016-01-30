using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ManaTank))]
public class ManaTankAutoRecharge : MonoBehaviour {

    [SerializeField]
    private int m_ChargeQuant = 5;
    [SerializeField]
    private float m_ChargePeriod = 0.2f;

    private ManaTank m_ManaTank;
    private bool m_Recharge = true;

	// Use this for initialization
	void Start () {
        m_ManaTank = GetComponent<ManaTank>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_Recharge)
        {
            StartCoroutine(Countdown(m_ChargePeriod));
            m_Recharge = false;
        }
	}
    
    IEnumerator Countdown(float t)
    {
        yield return new WaitForSeconds(t);
        m_ManaTank.ChangeValue(m_ChargeQuant);
        m_Recharge = true;
    }
}
