using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	public InventorySlot[] inventorySlot;

	private PlayerController playerController;

	[Header("UI")]
	[SerializeField] private GameObject playerInventory;
	[SerializeField] private GameObject preview;

	public bool inventoryOpen = false;


	private void Awake()
	{
		CheckInstance();

		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

    
    public void AddItem(Item item)
	{
		if (item.price <= PlayerStats.instance.cash)
		{
			PlayerStats.instance.RemoveMoney(item.price);

			for (int i = 0; i < inventorySlot.Length; i++)
			{
				InventorySlot slot = inventorySlot[i];
				Item itemInSlot = slot.GetComponentInChildren<Item>();
				if (itemInSlot == null)
				{
					TransferItem(item, slot);
					return;
				}
			}
		}
		else
		{
			Text.instance.Prompt("Not enough money!");
		}
	}

	private void TransferItem(Item item, InventorySlot slot)
	{
		item.transform.SetParent(slot.transform, false);
		item.Buyed();
	}

	private void CheckInstance()
	{
		if (instance != null)
		{
			Debug.LogError("More than one Inventory instance in scene");
			return;
		}
		else
		{
			instance = this;
		}
	}

	#region UI

	public void OpenInventory()
	{
		if (!inventoryOpen)
		{
			inventoryOpen = true;
			playerController.canMove = false;

			playerInventory.SetActive(true);
			preview.SetActive(true);

			for (int i = 0; i < inventorySlot.Length; i++)
			{
				InventorySlot slot = inventorySlot[i];
				Item itemInSlot = slot.GetComponentInChildren<Item>();
				if (itemInSlot != null)
				{
					itemInSlot.Equip();
				}
			}
		}
		else
		{
			inventoryOpen = false;
			playerController.canMove = true;

			playerInventory.SetActive(false);
			preview.SetActive(false);

		}
	}

	public void SortSellInventory()
	{
		for (int i = 0; i < inventorySlot.Length; i++)
		{
			InventorySlot slot = inventorySlot[i];
			Item itemInSlot = slot.GetComponentInChildren<Item>();
			if (itemInSlot != null)
			{
				itemInSlot.Buyed();
			}
		}
	}

	#endregion
}
