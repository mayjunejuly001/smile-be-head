using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform weaponPivot;

    private Camera mainCamera;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        mainCamera = Camera.main;
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }   
    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        Vector2 mousePosition = inputActions.Player.Aim.ReadValue<Vector2>();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector2 direction = (mouseWorldPos - weaponPivot.position);
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponPivot.rotation = Quaternion.Euler(0, 0, angle);
    }
}
