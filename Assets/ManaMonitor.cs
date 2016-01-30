using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaMonitor : MonoBehaviour {

    [SerializeField]
    private ManaTank m_ManaTank;

    private UIBarScript m_UIBar;

	// Use this for initialization
	void Start () {
        m_UIBar = GetComponent<UIBarScript>();
	}
	
	// Update is called once per frame
	void Update () {
        m_UIBar.NewValue = ((float)m_ManaTank.Value - 0) / (100.0f - 0.0f);
	}
}
