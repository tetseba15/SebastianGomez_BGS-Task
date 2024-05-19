using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	public InventorySlot[] inventorySlot;

	
	private void Awake()
	{
		CheckInstance();
	}

    
    public void AddItem(Item item)
	{
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

	private void TransferItem(Item item, InventorySlot slot)
	{
		item.transform.SetParent(slot.transform, false);
	}

	private void CheckInstance()
	{
		if (instance != null)
		{
			Debug.LogError("More than one PlayerStats instance in scene");
			return;
		}
		else
		{
			instance = this;
		}
	}
}
