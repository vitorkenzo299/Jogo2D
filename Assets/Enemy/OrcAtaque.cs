using System.Collections;
using UnityEngine;
using Player;

public class OrcAttackTrigger : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1f;
    private bool canAttack = true;

    private Animator orcAnimator;

    private void Start()
    {
        orcAnimator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!canAttack) return;

        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                if (orcAnimator != null)
                    orcAnimator.SetTrigger("Ataque");

                playerMovement.TakeDamage();
                StartCoroutine(AttackCooldown());
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}