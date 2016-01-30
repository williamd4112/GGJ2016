using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightRangeMonitor : MonoBehaviour {

    [SerializeField]
    private Light m_Light;

    private Text m_Text;

	// Use this for initialization
	void Start () {
        m_Text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Text.text = (m_Light.range.ToString());
	}
}
