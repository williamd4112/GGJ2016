using UnityEngine;
using System.Collections;

public class ManaTank : MonoBehaviour {

    [SerializeField]
    private int m_MaxValue = 100;
    public int MaxValue
    {
        get { return m_MaxValue; }
    }
    [SerializeField]
    private int m_InitValue = 100;

    private int m_Value;
    public int Value
    {
        get { return m_Value; }
    }

	// Use this for initialization
	void Start () {
        m_Value = m_InitValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeValue(int diff)
    {
        m_Value = Mathf.Clamp(m_Value + diff, 0, m_MaxValue);
    }

}
