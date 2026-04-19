using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private AudioSource audioSource;
        private Vector2 direction;
        private Vector2 lastDirection = Vector2.down;

        public Vector2 Direction => direction;

        [SerializeField] private float speed = 4f;
        [SerializeField] private Animator animator;

        private bool canTakeDamage = true;

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

            if (direction != Vector2.zero)
                lastDirection = direction;

            rb.linearVelocity = direction * speed;

            MoveAnimator(direction);
        }

        private void MoveAnimator(Vector2 moveDirection)
        {
            if (animator == null) return;

            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);

            animator.SetFloat("Horizontalidle", lastDirection.x);
            animator.SetFloat("Verticalidle", lastDirection.y);
        }

        public void TakeDamage()
        {
            if (!canTakeDamage) return;

            CenaGameOver.TakeDamage(1);

            animator.SetFloat("Horizontalidle", lastDirection.x);
            animator.SetFloat("Verticalidle", lastDirection.y);
            animator.SetTrigger("Hurt");

            StartCoroutine(DamageCooldown());
        }

        private IEnumerator DamageCooldown()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(0.7f);
            canTakeDamage = true;
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