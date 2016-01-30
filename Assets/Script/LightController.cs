using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

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

        m_SightScaleUp = m_WeaponScaleUp = false;

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
                moveLight(light, t.position);
            }
            else if (t.phase == TouchPhase.Stationary)
            {
                if (i == 0) m_SightScaleUp = true;
                else m_WeaponScaleUp = true;
            }
            else if(t.phase == TouchPhase.Ended)
            {
                light.enabled = false;
            }

            if (light.enabled)
                scanAreaForDamage(light.transform.position, light.range);

            i++;
            i %= 2;

        }

        scaleLight(m_Sight, m_SightScaleRate, (m_SightScaleUp) ? m_SightScaleUpRadius : m_SightScaleDownRadius );
        scaleLight(m_Weapon, m_WeaponScaleRate, (m_WeaponScaleUp) ? m_WeaponScaleUpRadius : m_WeaponScaleDownRadius);
    }
    
    bool projectToPlane(Vector2 mousePos, out Vector2 projPos)
    {
        Ray camRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            projPos = floorHit.point;
            return true;
        }

        projPos = Vector2.zero;
        return false;
    }

    void moveLight(Light light, Vector2 mousePos)
    {
        Ray camRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            float originY = light.transform.position.y;
            Vector3 pos = floorHit.point;
            pos.y = originY;
            light.transform.position = pos;
        }
    }

    void scaleLight(Light light, float rate, float target)
    {
        light.range = Mathf.Lerp(light.range, target, Time.deltaTime * rate);
    }

    void scanAreaForDamage(Vector2 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.CompareTag("Enemy"))
            {
                Damageable d = hitColliders[i].gameObject.GetComponent<Damageable>();
                if (d != null)
                {
                    d.OnHit(-10);
                    Debug.Log(hitColliders[i].gameObject);
                }
            }

            i++;
        }
    }
}
