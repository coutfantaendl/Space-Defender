using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFireTime = 0f;

    [SerializeField] private Transform SpawnShotPoint;

    private IWeapon weapon;
    private IInput input;

    private void Awake()
    {
        input = GetComponent<IInput>();
        weapon = GetComponent<IWeapon>();
    }

    private void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        Vector2 movement = input.GetMovementInput() * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void HandleShooting()
    {
        if(input.isShooting() && Time.time > nextFireTime )
        {
            weapon.Shoot(SpawnShotPoint);

            nextFireTime = Time.time + fireRate;
        }
    }
}
