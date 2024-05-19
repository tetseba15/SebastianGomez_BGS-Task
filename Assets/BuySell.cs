using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySell : MonoBehaviour
{
	public static BuySell instance;

	//ublic int[] prices;
	private void Awake()
	{
		CheckInstance();
	}


	void Update()
    {
        
    }

	public void Buy(int price)
	{
		if (PlayerStats.instance.cash >= price)
			PlayerStats.instance.RemoveMoney(price);
		else
			Debug.Log("Not enough money!");
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
