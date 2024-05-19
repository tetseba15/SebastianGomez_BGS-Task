using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static PlayerStats instance;
	private TextMeshProUGUI cashAmountTMP;

	public int cash;

	private void Awake()
	{
		CheckInstance();

		cashAmountTMP = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
		
	}

	private void Update()
	{
		cashAmountTMP.text = "$" + cash.ToString();
	}

	private void CheckInstance()
	{
		if(instance != null)
		{
			Debug.LogError("More than one PlayerStats instance in scene");
			return;
		}
		else
		{
			instance = this;
		}
	}

	public void AddMoney(int money)
	{
		cash += money;
	}

	public void RemoveMoney(int money) 
	{  
		cash -= money; 
	}
}
