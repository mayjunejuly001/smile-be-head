using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/SingleShotWeapon")]
public class WeaponSingleShot : WeaponData, IWeapon
{
    

    public bool TryFire(Transform firePoint, bool isFirePressed, bool isFireHeld)
    {
      
        if(fireMode == FireMode.Single && !isFirePressed)
        {
            return false;
        }

        if(fireMode == FireMode.Automatic && !isFireHeld)
        {
            return false;
        }

        Fire(firePoint);
        return true;
    }

    private void Fire(Transform firePoint)
    {
        if(bulletCount <= 1)
        {
            SpawnBullets(firePoint , firePoint.rotation);
        }
        else
        {
            float angleStep = spreadAngle / (bulletCount - 1);
            float startingAngle = -spreadAngle * 0.5f;

            for(int i = 0; i < bulletCount; i++)
            {
                float angle = startingAngle + (angleStep * i);
                Quaternion rotation = firePoint.rotation * Quaternion.Euler(0f, 0f, angle);
                SpawnBullets(firePoint , rotation);
            }

        }
            

    }

    private void SpawnBullets(Transform firePoint , Quaternion rotation)
    {
        Bullet bullet  = Instantiate(bulletPrefab, firePoint.position, rotation);

        bullet.Initialize(firePoint.right , bulletSpeed , bulletDamage);
    }
}
