using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private AudioSource audioSource;
        private Vector2 direction;
        public Vector2 Direction => direction;

        [SerializeField] private float speed = 4f;
        [SerializeField] private Animator animator;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

            if (animator == null)
                animator = GetComponent<Animator>();

            rb.gravityScale = 0f;
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            direction = new Vector2(moveHorizontal, moveVertical);
            direction = Vector2.ClampMagnitude(direction, 1f);
            
            rb.linearVelocity = direction * speed;

            MoveAnimator(direction);
        }

        private void MoveAnimator(Vector2 moveDirection)
        {
            if (animator == null) return;

            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);

            if (moveDirection != Vector2.zero)
            {
                animator.SetFloat("Horizontalidle", moveDirection.x);
                animator.SetFloat("Verticalidle", moveDirection.y);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("coletaveis"))
            {
                CenaGameOver.Collect();
                audioSource.Play();
                Destroy(other.gameObject);
            }
        }
    }
}