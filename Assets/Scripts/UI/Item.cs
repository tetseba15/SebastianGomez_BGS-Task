using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

	private GameObject buyButton;
	private GameObject sellButton;
    private GameObject equipButton;

	public int price;

	private void Awake()
	{
		buyButton = transform.GetChild(1).gameObject;
		sellButton = transform.GetChild(2).gameObject;
		equipButton = transform.GetChild(3).gameObject;
	}

	public void Buyed()
	{
		buyButton.SetActive(false);
		sellButton.SetActive(true);
		equipButton.SetActive(false);
	}

	public void Selled()
	{
		buyButton.SetActive(true);
		sellButton.SetActive(false);
		equipButton.SetActive(false);
	}

	public void Equip()
	{
		buyButton.SetActive(false);
		sellButton.SetActive(false);
		equipButton.SetActive(true);
	}
}
