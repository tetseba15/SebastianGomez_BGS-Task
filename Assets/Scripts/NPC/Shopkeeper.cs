using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
	private PlayerController playerController;

	public InventorySlot[] shopSlot;

	[Header("UI")]
	[SerializeField] private GameObject shopInventory;
	[SerializeField] private GameObject playerInventory;
	[SerializeField] private GameObject preview;
	[SerializeField] private GameObject playerInventoryCloseButton;

	private bool shopOpen = false;

	private void Awake()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	public void Interact()
	{

		if (!shopOpen)
		{
			shopOpen = true;
			playerController.canMove = false;

			shopInventory.SetActive(true);
			playerInventory.SetActive(true);
			preview.SetActive(true);
			playerInventoryCloseButton.SetActive(false);

			//for (int i = 0; i < shopSlot.Length; i++)
			//{
			//	InventorySlot slot = shopSlot[i];
			//	Item itemInSlot = slot.GetComponentInChildren<Item>();
			//	if (itemInSlot != null)
			//	{
			//		itemInSlot.Selled();
			//	}
			//}
		}
		else
		{
			shopOpen= false;
			playerController.canMove = true;

			shopInventory.SetActive(false);
			playerInventory.SetActive(false);
			preview.SetActive(false);
			playerInventoryCloseButton.SetActive(true);

		}

	}


	public void SellItem(Item item)
	{
		

		for (int i = 0; i < shopSlot.Length; i++)
		{
			InventorySlot slot = shopSlot[i];
			Item itemInSlot = slot.GetComponentInChildren<Item>();
			if (itemInSlot == null)
			{
				TransferItem(item, slot);
				PlayerStats.instance.AddMoney(item.price);
				return;
			}

		}
	}

	private void TransferItem(Item item, InventorySlot slot)
	{
		item.transform.SetParent(slot.transform, false);
		item.Selled();
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
