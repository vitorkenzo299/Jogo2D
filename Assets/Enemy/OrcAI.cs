using UnityEngine;

namespace Enemy
{
    public class OrcAI : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private Animator animator;

        private Rigidbody2D rb;
        private Transform player;
        private bool canSeePlayer;
        private Vector2 lastDirection;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            if (animator == null)
                animator = GetComponent<Animator>();

            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            Vector2 moveDirection = Vector2.zero;

            if (canSeePlayer && player != null)
            {
                moveDirection = (player.position - transform.position).normalized;
                rb.linearVelocity = moveDirection * speed;
                lastDirection = moveDirection;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }

            UpdateAnimator(moveDirection);
        }

        private void UpdateAnimator(Vector2 moveDirection)
        {
            if (animator == null) return;

            animator.SetFloat("HorizontalORC", moveDirection.x);
            animator.SetFloat("VerticalORC", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);

            Vector2 facingDirection = moveDirection != Vector2.zero ? moveDirection : lastDirection;

            animator.SetFloat("HorizontalidleORC", facingDirection.x);
            animator.SetFloat("VerticalidleORC", facingDirection.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.transform;
                canSeePlayer = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canSeePlayer = false;
                player = null;
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}