using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMaker : MonoBehaviour {

    public static Text m_WaveText;
    public static Text m_RemainText;

	public GameObject point1;
	public GameObject point2;

	public GameObject enemy;
    public GameObject[] enemies;

	float timelimit = 1f;
	float timecount;

    public static int enemyCount = 0;

    [SerializeField]
    private static int m_MaxEnemyCount = 60;

    private static int m_Wave = 0;
    private static float m_Period = 0.00001f;
    private static int m_PlayerKill = 0;
    private static int m_TargetToKill;

    private int select = 0;

    // Use this for initialization
    void Start () {
        m_WaveText = GameObject.Find("Wave").GetComponent<Text>();
        m_RemainText = GameObject.Find("Remain").GetComponent<Text>();

        timecount = 0;
        enemyCount = 0;

        m_Wave = 0;
        m_Period = 0.00001f;
        m_PlayerKill = 0;
        m_TargetToKill = (int)(Mathf.Pow(m_Wave++, 2)) + 5;

        m_WaveText.color = Color.white;
        m_WaveText.text = string.Format("Wave {0}",m_Wave + 1);
        m_RemainText.text = string.Format("{0} / {1}", m_PlayerKill, m_TargetToKill);
    }
	
	// Update is called once per frame
	void Update () {
		timecount += Time.deltaTime;
		if (timelimit - timecount <=  m_Period && enemyCount < m_TargetToKill) {
			float xpos = point1.transform.position.x + Random.value * (point2.transform.position.x - point1.transform.position.x);
			float zpos = point1.transform.position.z + Random.value * (point2.transform.position.z - point1.transform.position.z);
			Vector3 newpos = new Vector3 (xpos, 0, zpos);
			GameObject newenemy = Instantiate (enemies[select++], newpos, Quaternion.Euler (0, 0, 0)) as GameObject;
            select %= 2;
			timecount = 0;
            enemyCount++;
		}
	}

    public static void ReturnEnemy()
    {
        enemyCount = Mathf.Clamp(enemyCount - 1, 0, m_MaxEnemyCount);
        m_PlayerKill++;
 
        if(m_PlayerKill >= m_TargetToKill)
        {
            m_WaveText.color = Color.white;
            m_WaveText.text = string.Format("Wave {0}", m_Wave + 1);

            m_TargetToKill = (int)(Mathf.Pow(++m_Wave, 2)) + 5;
            m_PlayerKill = 0;
        }

        m_RemainText.text = string.Format("{0} / {1}", m_PlayerKill, m_TargetToKill);
    }
}
