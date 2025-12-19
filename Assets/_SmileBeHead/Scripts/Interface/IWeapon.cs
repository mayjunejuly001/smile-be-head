using UnityEngine;

public interface IWeapon
{
    bool TryFire(Transform firePoint, bool isFirePressed ,bool isFireHeld );

}
