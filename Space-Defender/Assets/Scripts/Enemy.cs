using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float fireRate;
    [SerializeField] private int scoreValue;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
  
    private float speed = 2.2f;
    private int health = 1;
    private float nextFireTime = 0f;

    private IMovementPattern movementPattern;

    private bool isInitialize = false;

    public void Initialize(float Speed, int Health)
    {
        movementPattern = GetComponent<IMovementPattern>();

        speed = Speed;
        health = Health;

        isInitialize = true;
    }

    private void Update()
    {
        if (!isInitialize)
            return;

        Move();
        Shoot();
    }

    private void Move()
    {
        movementPattern.Move(transform, speed);
    }

    private void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            nextFireTime = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dead();

            collision.GetComponent<IDamageable>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

    private void Dead()
    {
        ScoreManager.Instance.AddScore(scoreValue);
    }
}
