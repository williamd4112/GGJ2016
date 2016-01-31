using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

    private Image m_Image;
    private float m_Low = 0.3f;
    private float m_High = 1.0f;

    [SerializeField]
    private float m_BlinkPeriod;

	// Use this for initialization
	void Start () {
        m_Image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
