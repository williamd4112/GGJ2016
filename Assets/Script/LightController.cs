using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
    [SerializeField]
    private Transform m_RefPlane;

    [SerializeField]
    private Light m_Sight;
    [SerializeField]
    private Light m_Weapon;

    [SerializeField]
    private float m_SightScaleRate;
    [SerializeField]
    private float m_WeaponScaleRate;

    [SerializeField]
    private float m_SightScaleUpRadius;
    [SerializeField]
    private float m_WeaponScaleUpRadius;

    [SerializeField]
    private float m_SightScaleDownRadius;
    [SerializeField]
    private float m_WeaponScaleDownRadius;

    [SerializeField]
    private GameObject m_MagicCircleTemplate;
    private GameObject m_MagicCircleInstance = null;

    private bool m_SightScaleUp = false;
    private bool m_WeaponScaleUp = false;

    private int floorMask;
    private float camRayLength = 1000f;

    // Use this for initialization
    void Start () {
        floorMask = LayerMask.GetMask("Floor");
        m_Sight.enabled = false;
        m_Weapon.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        foreach(Touch t in Input.touches)
        {
            Light light = (i == 0) ? m_Sight : m_Weapon;
            float rate = (i == 0) ? m_SightScaleRate : m_WeaponScaleRate;
            float max = (i == 0) ? m_SightScaleUpRadius : m_WeaponScaleUpRadius;
            float min = (i == 0) ? m_SightScaleDownRadius : m_WeaponScaleDownRadius;

            if (t.phase == TouchPhase.Began)
            {
                light.enabled = true;
                moveLight(light, t.position, (i == 1));
            }
            else if (t.phase == TouchPhase.Stationary)
            {
                if (i == 0)
                {
                    m_SightScaleUp = true;
                }
                else
                {
                    m_WeaponScaleUp = true;
                    m_Weapon.gameObject.SetActiveRecursively(true);
                }
            }
            else if(t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                light.enabled = false;
                m_Weapon.gameObject.SetActiveRecursively(false);

                m_SightScaleUp = m_WeaponScaleUp = false; 
            }
            i++;
            i %= 2;
        }

        if(m_Weapon.enabled == false && m_MagicCircleInstance != null)
        {
            Destroy(m_MagicCircleInstance);
            m_MagicCircleInstance = null;
        }

        scaleLight(m_Sight, m_SightScaleRate, (m_SightScaleUp) ? m_SightScaleUpRadius : m_SightScaleDownRadius, !m_SightScaleUp);
        scaleLight(m_Weapon, m_WeaponScaleRate, (m_WeaponScaleUp) ? m_WeaponScaleUpRadius : m_WeaponScaleDownRadius, !m_WeaponScaleUp);
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
            light.transform.position = pos;

            if(m_MagicCircleInstance == null && isMagic)
                m_MagicCircleInstance = GameObject.Instantiate(m_MagicCircleTemplate, pos, transform.rotation) as GameObject;
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
