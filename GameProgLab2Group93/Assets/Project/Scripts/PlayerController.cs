using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Transform cameraMovement;
	[SerializeField]
	private float cubeSpeed = 5;
	[SerializeField]
	private float heightOfJump = 1.5f;
	[SerializeField]
	private float speedOfFall = -3f;

	private CharacterController cube;
	private PlayerMovement playerMovement;
	private Vector3 playerSpeed;

	private void Awake()
	{
		cube = GetComponent<CharacterController>();
		playerMovement = new();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OnEnable()
	{
		playerMovement.Enable();
	}

	private void OnDisable()
	{
		playerMovement.Disable();
	}

	void Update()
	{
		var isGrounded = cube.isGrounded;
		if (playerSpeed.y < 0 && isGrounded)
		{
			playerSpeed.y = 0f;
		}

		Vector2 input = 
			playerMovement.Player.Movement.ReadValue<Vector2>();
		
		Vector3 movement = new(input.x, 0, input.y);
		movement = 
			cameraMovement.forward * movement.z +
			cameraMovement.right * movement.x;
		movement.y = 0f;

		cube.Move(cubeSpeed * Time.deltaTime * movement);

		if (playerMovement.Player.Jump.triggered && isGrounded)
		{
			playerSpeed.y += Mathf.Sqrt(heightOfJump *
				speedOfFall * Physics.gravity.y);
		}

		playerSpeed.y += Physics.gravity.y * Time.deltaTime;
		cube.Move(playerSpeed * Time.deltaTime);
	}
}
