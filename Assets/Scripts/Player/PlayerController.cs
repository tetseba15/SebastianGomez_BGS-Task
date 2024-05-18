using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private PlayerActions playerActions;
	private Rigidbody2D rb;
	private IInteractable interactableInstance;

	private Vector2 movement;
	private bool interactPressed;

	private void Awake()
	{
		playerActions = new PlayerActions();
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		playerActions.Enable();
	}

	private void Update()
	{
		PlayerInput();

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
		movement = playerActions.Movement.Move.ReadValue<Vector2>();
		interactPressed = playerActions.Actions.Interact.WasPressedThisFrame();
	}

	private void Move()
	{
		rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
	}

	private void TryInteract()
	{
		if (interactableInstance != null)
			interactableInstance.Interact();
		else
			Debug.Log("Nothing close");
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
