using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySell : MonoBehaviour
{
	public static BuySell instance;

	private void Awake()
	{
		CheckInstance();
	}

	public void Buy(int price)
	{
		if (PlayerStats.instance.cash >= price)
		{
			PlayerStats.instance.RemoveMoney(price);

		}
		else
		{
			Debug.Log("Not enough money!");

		}
	}

	public void Sell(int price)
	{
		PlayerStats.instance.AddMoney(price);
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
