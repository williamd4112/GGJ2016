using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

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
    private int m_SelectMagic = 0;
    [SerializeField]
    private GameObject m_MagicCircleTemplate;
    [SerializeField]
    private GameObject m_MagicCircleIgnitionTemplate;
    [SerializeField]
    private GameObject m_IceMagicCircleTemplate;
    [SerializeField]
    private GameObject m_IceMagicCircleIgnitionTemplate;
    [SerializeField]
    private GameObject m_LightingtMagicCircleTemplate;
    [SerializeField]
    private GameObject m_LightingMagicCircleIgnitionTemplate;
    [SerializeField]
    private AudioClip m_MagicSound;

    [SerializeField]
    private float m_Speed = 2.2f;
    [SerializeField]
    private int m_NormalMagicConsume = 10;

    private ManaTank m_ManaTank;

    [SerializeField]
    private Character m_Character;
    private bool m_Attack = false;

    private bool m_SightScaleUp = false;

    private int floorMask;
    private float camRayLength = 1000f;

    // Use this for initialization
    void Start () {
        floorMask = LayerMask.GetMask("Floor");
        m_ManaTank = GetComponent<ManaTank>();
    }
	
    void FixedUpdate()
    {
        m_Character.Move(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), m_Attack);
        //m_Character.Move(Input.GetAxis("Horizontal"),
        //        Input.GetAxis("Vertical"), m_Attack);
        m_Attack = false;
    }

	// Update is called once per frame
	void Update () {

        //if (Input.GetMouseButton(0))
        //{
        //    genMagicalCircle(Input.mousePosition);
        //}

        int i = 0;
        foreach(Touch t in Input.touches)
        {
            Light light = m_Sight;
            float rate = m_SightScaleRate;
            float max = m_SightScaleUpRadius;
            float min = m_SightScaleDownRadius;

            if (t.phase == TouchPhase.Began)
            {
                if (i != 0)
                {
                    genMagicalCircle(t.position);
                    m_Attack = true;
                }
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
                if (m_MagicSound != null)
                    AudioSource.PlayClipAtPoint(m_MagicSound, transform.position);

                GameObject template = m_MagicCircleTemplate;
                GameObject ignition = m_MagicCircleIgnitionTemplate;
                switch(m_SelectMagic)
                {
                    case 0:
                        template = m_MagicCircleTemplate;
                        ignition = m_MagicCircleIgnitionTemplate;
                        break;
                    case 1:
                        template = m_IceMagicCircleTemplate;
                        ignition = m_IceMagicCircleIgnitionTemplate;
                        break;
                    case 2:
                        template = m_LightingtMagicCircleTemplate;
                        ignition = m_LightingMagicCircleIgnitionTemplate;
                        break;
                    default:
                        break;
                }

                GameObject dummy = GameObject.Instantiate(template, pos, transform.rotation) as GameObject;
                GameObject ignition_dummy = GameObject.Instantiate(ignition, pos, transform.rotation) as GameObject;
                Destroy(ignition_dummy, ignition_dummy.GetComponent<ParticleSystem>().duration);
                m_ManaTank.ChangeValue(-m_NormalMagicConsume);
            }
        }
    }

    void scaleLight(Light light, float rate, float target, bool immediate)
    {
        light.spotAngle = Mathf.Lerp(light.spotAngle, target, Time.deltaTime * rate);
    }

    public void SetMagic(int index)
    {
        m_SelectMagic = index % 3;
    }
}
