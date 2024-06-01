using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] int damage;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
