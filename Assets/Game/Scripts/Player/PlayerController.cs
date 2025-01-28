using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Keybindings")]
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference dashActionReference;
    [SerializeField] private InputActionReference pauseActionReference;
    
    [Header("Movement")]
    public float speed = 10.0f;
    public float dashDistance = 10.0f;
    public float dashCooldown = 5.0f;
    private float _dashTimer;

    private void Start()
    {
        moveActionReference.action.Enable();
        pauseActionReference.action.Enable();
        dashActionReference.action.Enable();
    }

    void Update()
    {
        // Open pause menu
        if (pauseActionReference.action.triggered)
        {
            Debug.Log("Pause menu opened");
        }
        
        Vector2 moveInput = moveActionReference.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        
        // Boost player speed
        if (dashActionReference.action.IsPressed())
        {
            // When dash is pressed, give an impulse in the move direction
            if (_dashTimer <= 0)
            {
                transform.Translate(move * dashDistance, Space.World);
                _dashTimer = dashCooldown;
                StartCoroutine(ResetDashTimer());
            }
        }
        
        // Move the player
        transform.Translate(move * (speed * Time.deltaTime));
        
        // Look at the move direction
        if (move != Vector3.zero)
        {
            GameObject playerModel = transform.GetChild(0).gameObject;
            playerModel.transform.rotation = Quaternion.LookRotation(move);
        }
    }
    
    private IEnumerator ResetDashTimer()
    {
        yield return new WaitForSeconds(dashCooldown);
        _dashTimer = 0;
    }
}
