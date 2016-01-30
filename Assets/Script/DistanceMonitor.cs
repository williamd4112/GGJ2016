using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceMonitor : MonoBehaviour {

    [SerializeField]
    private Transform m_Pos1;
    [SerializeField]
    private Transform m_Pos2;

    private Text m_Text;

	// Use this for initialization
	void Start () {
        m_Text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Text.text = (Vector3.Distance(m_Pos1.position, m_Pos2.position).ToString());
	}
}
