using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

	//Components
    private PlayerActions playerActions;
	private Rigidbody2D rb;
	private IInteractable interactableInstance;
	private Animator animator;


	//Data
	private Vector2 movement;
	private bool interactPressed;
	private bool isFacingRight = true;
	[HideInInspector] public bool inventoryOpen = false;
	[HideInInspector] public bool canMove = true;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		playerActions = new PlayerActions();
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		playerActions.Enable();
	}

	private void Update()
	{
		Flip();
		PlayerInput();
		Animations();

		if(interactPressed)
			TryInteract();

		
	}

	private void FixedUpdate()
	{
		Move();
	}

	#region private functions
	private void PlayerInput()
	{
		if (canMove)
			movement = playerActions.Movement.Move.ReadValue<Vector2>();
		else
			movement = Vector2.zero;

		interactPressed = playerActions.Actions.Interact.WasPressedThisFrame();

		if (playerActions.Actions.Inventory.WasPressedThisFrame() && !inventoryOpen)
		{
			Inventory.instance.OpenInventory();
		}
	}

	private void Move()
	{
		rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
	}

	private void TryInteract()
	{
		if (interactableInstance != null)
			interactableInstance.Interact();
		
	}

	private void Animations()
	{
		animator.SetFloat("speed", movement.magnitude);

	}

	private void Flip()
	{
		if(isFacingRight && movement.x < 0f || !isFacingRight && movement.x > 0f)
		{
			isFacingRight = !isFacingRight;
			transform.Rotate(0f, 180f, 0f);
		}
	}

	#endregion

	#region public functions
	public void SetIInstance(IInteractable interactable)
	{
		interactableInstance = interactable;
	}

	public void ClearIInstance()
	{
		interactableInstance = null;
	}
	#endregion
}
