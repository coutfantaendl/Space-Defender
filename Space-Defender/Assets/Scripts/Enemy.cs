using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed;
    public int health;

    [SerializeField] private float fireRate;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    private float nextFireTime = 0f;

    private IMovementPattern movementPattern;

    private void Awake()
    {
        movementPattern = GetComponent<IMovementPattern>();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        movementPattern.Move(transform, speed);
    }

    private void Shoot()
    {
        if(Time.time > nextFireTime)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            nextFireTime = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("PlayerBullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}
