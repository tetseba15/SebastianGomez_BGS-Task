using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
	public static Text instance;

	[SerializeField] private GameObject textPanel;
	[SerializeField] private TextMeshProUGUI textOutput;


	private void Awake()
	{

		CheckInstance();
	}

	

	public void Prompt(string text)
	{
			StopAllCoroutines();

			StartCoroutine(PrintTextCoroutine(text));
		
	}

	private IEnumerator PrintTextCoroutine(string text)
	{

		textPanel.SetActive(true);
		textOutput.text = text;

		yield return new WaitForSeconds(3f);

		textPanel.SetActive(false);
	}
	private void CheckInstance()
	{
		if (instance != null)
		{
			Debug.LogError("More than one Text instance in scene");
			return;
		}
		else
		{
			instance = this;
		}
	}
}
