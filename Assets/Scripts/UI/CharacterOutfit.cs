using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOutfit : MonoBehaviour
{
	[Header("Player sprites")]
	[SerializeField] private SpriteRenderer playerHood;

	[SerializeField] private SpriteRenderer playerTorso;
	[SerializeField] private SpriteRenderer playerPelvis;

	[SerializeField] private SpriteRenderer playerShoulderR;
	[SerializeField] private SpriteRenderer playerShoulderL;

	[SerializeField] private SpriteRenderer playerGloveL;
	[SerializeField] private SpriteRenderer playerGloveR;

	[SerializeField] private SpriteRenderer playerBootL;
	[SerializeField] private SpriteRenderer playerBootR;


	[Header("Player preview")]
	[SerializeField] private Image playerPreviewHood;

	[SerializeField] private Image playerPreviewTorso;
	[SerializeField] private Image playerPreviewPelvis;

	[SerializeField] private Image playerPreviewShoulderR;
	[SerializeField] private Image playerPreviewShoulderL;

	[SerializeField] private Image playerPreviewGloveL;
	[SerializeField] private Image playerPreviewGloveR;

	[SerializeField] private Image playerPreviewBootL;
	[SerializeField] private Image playerPreviewBootR;

    [Header("Hoods Options")]
    public List<Sprite> hoodOptions = new List<Sprite>();

	[Header("Torso Options")]
	public List<Sprite> torsoOptions = new List<Sprite>();
	public List<Sprite> pelvisOptions = new List<Sprite>();
	public List<Sprite> shoulderOptionsL = new List<Sprite>();
	public List<Sprite> shoulderOptionsR = new List<Sprite>();


	[Header("Gloves and boots Options")]
	public List<Sprite> glovesOptionsL = new List<Sprite>();
	public List<Sprite> glovesOptionsR = new List<Sprite>();

	public List<Sprite> bootsOptionsL = new List<Sprite>();
	public List<Sprite> bootsOptionsR = new List<Sprite>();

	//public List<Sprite> legsOptionsL = new List<Sprite>();
	//public List<Sprite> legsOptionsR = new List<Sprite>();


	//private int currentOption = 0;

	private void Awake()
	{
		
	}

	private void Update()
	{
		//if(Input.GetMouseButtonDown(0))
		//{
		//	ChangeHood(4);
		//}
	}

	public void ChangeHood(int index)
	{
		playerHood.sprite = hoodOptions[index];

		playerPreviewHood.sprite = hoodOptions[index];
	}

	public void ChangeTorso(int index)
	{
		playerTorso.sprite = torsoOptions[index];
		playerPelvis.sprite = pelvisOptions[index];
		playerShoulderL.sprite = shoulderOptionsL[index];
		playerShoulderR.sprite = shoulderOptionsR[index];

		playerPreviewTorso.sprite = torsoOptions[index];
		playerPreviewPelvis.sprite = pelvisOptions[index];
		playerPreviewShoulderL.sprite = shoulderOptionsL[index];
		playerPreviewShoulderR.sprite = shoulderOptionsR[index];
	}

	public void ChangeAccesories(int index)
	{
		playerGloveL.sprite = glovesOptionsL[index];
		playerGloveR.sprite = glovesOptionsR[index];
		playerBootL.sprite = bootsOptionsL[index];
		playerBootR.sprite = bootsOptionsR[index];

		playerPreviewGloveL.sprite = glovesOptionsL[index];
		playerPreviewGloveR.sprite = glovesOptionsR[index];
		playerPreviewBootL.sprite = bootsOptionsL[index];
		playerPreviewBootR.sprite = bootsOptionsR[index];
	}

	//   public void NextOption()
	//   {
	//       currentOption++;

	//       if(currentOption >= hoodOptions.Count)
	//           currentOption = 0;

	//       bodyPart.sprite = hoodOptions[currentOption];
	//   }

	//   public void PreviousOption()
	//   {
	//	currentOption--;

	//	if (currentOption <= 0)
	//		currentOption = hoodOptions.Count -1;

	//	bodyPart.sprite = hoodOptions[currentOption];
	//}
}
