using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private AudioSource shootSound;

    public void Shoot(Transform shootPoint)
    {
        GameObject bullet = Instantiate(BulletPrefab, shootPoint.position, shootPoint.rotation);

        shootSound.Play();
    }
}
