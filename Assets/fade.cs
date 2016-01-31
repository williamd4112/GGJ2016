using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fade : MonoBehaviour {

    private Text m_Text;

    [SerializeField]
    private float m_FadeSpeed = 1.8f;

	// Use this for initialization
	void Start () {
        m_Text = GetComponent<Text>();	 
	}
	
	// Update is called once per frame
	void Update () {
        float a = m_Text.color.a;
        a = Mathf.Lerp(a, 0, Time.deltaTime * m_FadeSpeed);
        Color c = m_Text.color;
        c.a = a;
        m_Text.color = c;
	}

}
