using UnityEngine;
using UnityEngine.UI;

public class I18NText : MonoBehaviour
{
	public string key;

	public void Start()
	{
		if (GetComponent<Text>() != null)
		{
			ReloadText();
		}
	}

	public void ReloadText()
	{
		GetComponent<Text>().text = Strings.Get(key);
	}
}