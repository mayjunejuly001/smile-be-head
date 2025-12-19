using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
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
        ReadInput();
    }

    private void FixedUpdate()
    {
        ApplyInput();
    }

    private void ReadInput()
    {

        movement = inputActions.Player.Move.ReadValue<Vector2>().normalized;


    }

    private void ApplyInput()
    {
        rb.linearVelocity = movement * moveSpeed;
    }



}
