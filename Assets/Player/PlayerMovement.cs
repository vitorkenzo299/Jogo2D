using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private AudioSource audioSource;
 
        [SerializeField] private float speed = 4f;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

            rb.gravityScale = 0f;
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            movement = Vector2.ClampMagnitude(movement, 1f);

            rb.linearVelocity = movement * speed;
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