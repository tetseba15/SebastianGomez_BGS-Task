using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour, IInteractable
{

	[SerializeField] private string customText;
	[SerializeField] private GameObject interactIcon;


	public void Interact()
	{
			Text.instance.Prompt(customText);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			interactIcon.SetActive(true);
			collision.GetComponent<PlayerController>().SetIInstance(this);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			interactIcon.SetActive(false);
			collision.GetComponent<PlayerController>().ClearIInstance();
		}
	}
}
