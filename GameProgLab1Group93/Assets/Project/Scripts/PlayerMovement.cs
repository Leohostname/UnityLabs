using UnityEngine;
using UnityEngine.InputSystem;

namespace Lab1
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
		[SerializeField] private float jumpForce = 5f;
        [SerializeField] private BoxCollider2D collider;

        private float colliderRadius;
		private float xMovement;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
			colliderRadius = GetComponent<BoxCollider2D>().size.y;
		}

		private void FixedUpdate()
        {
			rb.velocity = new(xMovement * speed, rb.velocity.y);
        }

		public void Move(InputAction.CallbackContext context)
        {
		    xMovement = context.ReadValue<Vector2>().x;
		}

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && collider.IsTouchingLayers())
            {
                rb.velocity = new(rb.velocity.x, jumpForce);
            }
        }
    }
}
