using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpawnOffset = 0.45f;
        [SerializeField] private float attackCooldown = 0.80f;

        private PlayerMovement playerMovement;
        private Vector2 lastDirection = Vector2.down;
        private bool canAttack = true;

        private void Start()
        {
            if (animator == null)
                animator = GetComponent<Animator>();

            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (playerMovement != null)
            {
                Vector2 dir = playerMovement.Direction;
                if (dir != Vector2.zero)
                    lastDirection = dir;
            }

            if (Input.GetMouseButtonDown(0) && canAttack)
            {
                Attack();
            }
        }

        private void Attack()
        {
            canAttack = false;

            if (animator != null)
            {
                animator.SetFloat("Horizontalidle", lastDirection.x);
                animator.SetFloat("Verticalidle", lastDirection.y);
                animator.SetTrigger("Ataque");
            }

            Vector2 dir = lastDirection.normalized;
            if (dir == Vector2.zero)
                dir = Vector2.down;

            Vector3 spawnPos = transform.position + new Vector3(dir.x, dir.y, 0f) * projectileSpawnOffset;

            GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
            Projectile projectile = proj.GetComponent<Projectile>();
            if (projectile != null)
                projectile.SetDirection(dir);

            StartCoroutine(AttackCooldownRoutine());
        }

        private IEnumerator AttackCooldownRoutine()
        {
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}