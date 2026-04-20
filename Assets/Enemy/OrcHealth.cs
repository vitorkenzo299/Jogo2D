using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class OrcHealth : MonoBehaviour
    {
        [SerializeField] private int health = 1;
        [SerializeField] private Animator animator;
        [SerializeField] private float hurtLockTime = 0.2f;

        private OrcAI orcAI;
        private bool isHurt;

        private void Start()
        {
            if (animator == null)
                animator = GetComponent<Animator>();

            orcAI = GetComponent<OrcAI>();
        }

        public void TakeDamage(int damage)
        {
            if (isHurt) return;

            health -= damage;

            if (animator != null)
                animator.SetTrigger("Hurt");

            if (health <= 0)
            {
                EnemyManager.EnemyDied();
                Destroy(gameObject, 0.4f);
                return;
            }

            StartCoroutine(HurtCooldown());
        }

        private IEnumerator HurtCooldown()
        {
            isHurt = true;

            if (orcAI != null)
                orcAI.enabled = false;

            yield return new WaitForSeconds(hurtLockTime);

            if (orcAI != null)
                orcAI.enabled = true;

            isHurt = false;
        }
    }
}