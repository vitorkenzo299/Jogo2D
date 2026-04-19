using UnityEngine;

namespace Enemy
{
    public class OrcHealth : MonoBehaviour
    {
        [SerializeField] private int health = 1;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}