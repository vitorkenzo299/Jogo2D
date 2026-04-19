using UnityEngine;
using Enemy;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 2f;

    private Rigidbody2D rb;
    private Vector2 direction = Vector2.right;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        RotateToDirection();
    }

    private void FixedUpdate()
    {
        if (rb != null)
            rb.linearVelocity = direction * speed;
    }

    private void RotateToDirection()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            return;

        if (other.isTrigger)
            return;

        OrcHealth orc = other.GetComponentInParent<OrcHealth>();
        if (orc != null)
        {
            orc.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}