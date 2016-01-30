using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockFontText : MonoBehaviour {

	public Sprite[] numbers;
	public Sprite[] alphabets;
	public Sprite[] symbols;
	public string text;
	public GameObject characterPrefab;
	public float spacing = 30.0f;
	public bool center = false;

	private string textSnap = "";
	private bool centerSnap = false;

	void Start()
	{
	}

	void Update()
	{
		text = text.Trim ();
		if (textSnap != text || centerSnap != center) {
			textSnap = text;
			centerSnap = center;
			UpdateText();
		}
	}

	void UpdateText()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Destroy (transform.GetChild(i).gameObject);
		}
		for(int i = 0; i < text.Length; i++) {
			GameObject c = Instantiate(characterPrefab) as GameObject;
			c.GetComponent<RectTransform>().SetParent(transform);
			if(text[i] >= 'a' && text[i] <= 'z') {
				c.GetComponent<Image>().sprite = alphabets[text[i] - 'a'];
			}
			else if(text[i] >= 'A' && text[i] <= 'Z') {
				c.GetComponent<Image>().sprite = alphabets[text[i] - 'A'];
			}
			else if(text[i] >= '0' && text[i] <= '9') {
				c.GetComponent<Image>().sprite = numbers[text[i] - '0'];
			}
			else if(text[i] == '$') {
				c.GetComponent<Image>().sprite = symbols[0];
			}
			else if(text[i] == '-') {
				c.GetComponent<Image>().sprite = symbols[1];
			}
			else if(text[i] == '.') {
				c.GetComponent<Image>().sprite = symbols[2];
			}
			else if(text[i] == ':') {
				c.GetComponent<Image>().sprite = symbols[3];
			}
			else {
				c.GetComponent<Image>().color = new Color(1, 1, 1, 0);
			}

			if(center) {
				c.GetComponent<RectTransform>().anchoredPosition = new Vector3(-(text.Length - 1) / 2.0f * spacing + i * spacing, 0, 0);
			}
			else {
				c.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * spacing, 0, 0);
			}

			c.GetComponent<RectTransform>().localScale = Vector3.one;
		}
	}
}
