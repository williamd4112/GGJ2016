using UnityEngine;
using System.Collections;

public class MagicSlow : MonoBehaviour {

    [SerializeField]
    private GameObject m_Effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.Instantiate(m_Effect, other.transform.position, other.transform.rotation);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.speed = 0;
            }
        }

    }
}
