using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    [SerializeField]
    private Transform m_RefPlane;

    [SerializeField]
    private Light m_Sight;

    [SerializeField]
    private float m_SightScaleRate;

    [SerializeField]
    private float m_SightScaleUpRadius;

    [SerializeField]
    private float m_SightScaleDownRadius;

    [SerializeField]
    private GameObject m_MagicCircleTemplate;

    [SerializeField]
    private float m_Speed = 2.2f;
    [SerializeField]
    private int m_NormalMagicConsume = 10;

    private ManaTank m_ManaTank;

    private bool m_SightScaleUp = false;

    private int floorMask;
    private float camRayLength = 1000f;

    // Use this for initialization
    void Start () {
        floorMask = LayerMask.GetMask("Floor");
        m_ManaTank = GetComponent<ManaTank>();
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        foreach(Touch t in Input.touches)
        {
            Light light = m_Sight;
            float rate = m_SightScaleRate;
            float max = m_SightScaleUpRadius;
            float min = m_SightScaleDownRadius;

            if (t.phase == TouchPhase.Began)
            {
                if(i == 0)
                {
                    moveLight(light, t.position, (i == 1));
                }
                else if (i == 1)
                {
                    genMagicalCircle(t.position);
                }
            }
            else if(t.phase == TouchPhase.Moved)
            {
                if(i == 0)
                    moveLight(light, t.position, false);
            }
            else if (t.phase == TouchPhase.Stationary)
            {
                if (i == 0)
                {
                    m_SightScaleUp = true;
                }
            }
            else if(t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                if (i == 0)
                    m_SightScaleUp = false;
            }
            i++;
            i %= 2;
        }

        scaleLight(m_Sight, m_SightScaleRate, (m_SightScaleUp) ? m_SightScaleUpRadius : m_SightScaleDownRadius, !m_SightScaleUp);
    }

    void genMagicalCircle(Vector2 mousePos)
    {
        Ray camRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 pos = floorHit.point;
            pos.y = m_RefPlane.position.y + 0.4f;

            if (m_ManaTank.Value > m_NormalMagicConsume)
            {
                GameObject dummy = GameObject.Instantiate(m_MagicCircleTemplate, pos, transform.rotation) as GameObject;
                m_ManaTank.ChangeValue(-m_NormalMagicConsume);
            }
        }
    }

    void moveLight(Light light, Vector2 mousePos, bool isMagic)
    {
        Ray camRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            float originY = light.transform.position.y;
            Vector3 pos = floorHit.point;
            pos.y = originY;
            light.transform.position = Vector3.Lerp(light.transform.position, pos, Time.deltaTime * m_Speed);
        }
    }

    void scaleLight(Light light, float rate, float target, bool immediate)
    {
        if (immediate)
            light.range = target;
        else
            light.range = Mathf.Lerp(light.range, target, Time.deltaTime * rate);

        SphereCollider collider = light.GetComponent<SphereCollider>();
        if(collider != null)
        {
            collider.radius = light.range / 10;
        }
    }
}
