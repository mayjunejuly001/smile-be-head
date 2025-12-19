using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("Weapon Data")]
    public string weaponName;

    [Header("Firing")]
    public FireMode fireMode;
    public float fireRate;
    

    [Header("Bullet")]
    public Bullet bulletPrefab;
    public float bulletSpeed;
    public float bulletDamage;

    [Header("Multi Bullet and Angle")]
    [Range(1, 20)]
    public int bulletCount = 1;

    [Range(0f, 45f)]
    public float spreadAngle = 0f;

}
