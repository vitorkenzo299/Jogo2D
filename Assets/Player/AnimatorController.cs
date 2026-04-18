using UnityEngine;

namespace Player
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();

            if (animator == null)
                animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector2 dir = playerMovement.Direction;

            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Speed", dir.sqrMagnitude);

            if (dir != Vector2.zero)
            {
                animator.SetFloat("Horizontalidle", dir.x);
                animator.SetFloat("Verticalidle", dir.y);
            }
        }
    }
}