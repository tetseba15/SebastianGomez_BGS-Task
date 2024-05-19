using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

	[SerializeField] private string customText;
	[SerializeField] private int money = 50;
	[SerializeField] private GameObject interactIcon;


	private bool interacted = false;

	public void Interact()
	{
		

		if (!interacted)
		{
			interacted = true;
			Text.instance.Prompt(customText);
			PlayerStats.instance.AddMoney(money);
		}
		else
		{
			Text.instance.Prompt("Now it's empty...");
		}

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
