using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponData startingWeapon;
    [SerializeField] private Transform firePoint;

    private IWeapon currentWeapon;

    private float fireCooldown; 

    private void Start()
    {
        EquipWeapon(startingWeapon);
        fireCooldown = 0f;
    }

    private void Update()
    {
        fireCooldown -= Time.deltaTime;

        bool leftPressed = Mouse.current.leftButton.wasPressedThisFrame;
        bool leftHeld = Mouse.current.leftButton.isPressed;

   

        if (fireCooldown <= 0f)
        {
            if (currentWeapon.TryFire(firePoint, leftPressed, leftHeld))
            {
                fireCooldown = startingWeapon.fireRate;
            }

         
        }
    }

    public void EquipWeapon(WeaponData weapon)
    {
        startingWeapon = weapon;
        currentWeapon = weapon as IWeapon;
        fireCooldown = 0f; 
    }
}
