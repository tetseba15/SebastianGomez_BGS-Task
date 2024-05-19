using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

	[SerializeField] private string customText;
	[SerializeField] private int money = 50;

	private bool interacted = false;

	public void Interact()
	{
		

		if (!interacted)
		{
			interacted = true;
			Debug.Log(customText);
			PlayerStats.instance.AddMoney(money);
		}
		else
		{
			Debug.Log("Now it's empty...");
		}
		
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
