using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject BulletPrefab;

    public void Shoot(Transform shootPoint)
    {
        GameObject bullet = Instantiate(BulletPrefab, shootPoint.position, shootPoint.rotation);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        
        if(bulletComponent == null )
        {
            bulletComponent = bullet.AddComponent<Bullet>();
        }
    }
}
