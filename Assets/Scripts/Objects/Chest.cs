using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

	[SerializeField] private string customText;
	[SerializeField] private int money = 50;

	public void Interact()
	{
		Debug.Log(customText);
		PlayerStats.instance.AddMoney(money);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerController>().SetIInstance(this);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerController>().ClearIInstance();
		}
	}
}
