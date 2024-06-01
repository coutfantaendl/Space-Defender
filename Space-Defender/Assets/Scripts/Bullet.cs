using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
