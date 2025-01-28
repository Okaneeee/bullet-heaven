using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Keybindings")]
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference resetPositionActionReference;
    [SerializeField] private InputActionReference boostActionReference;
    
    [Header("Movement")]
    public float speed = 10.0f;
    public float acceleration = 0.2f;
    public float maxSpeed = 30.0f;

    private void Start()
    {
        moveActionReference.action.Enable();
        resetPositionActionReference.action.Enable();
        boostActionReference.action.Enable();
    }

    void Update()
    {
        // Reset player position
        if (resetPositionActionReference.action.triggered)
        {
            transform.position = new Vector3(0, 1, 0);
        }
        
        // Boost player speed
        if (boostActionReference.action.IsPressed())
        {
            if (speed < maxSpeed) speed += acceleration;
        }
        else
        {
            speed = 10.0f;
        }
        
        // Move the player
        Vector2 moveInput = moveActionReference.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime);
        
        // Look at the move direction
        if (move != Vector3.zero)
        {
            GameObject playerModel = transform.GetChild(0).gameObject;
            playerModel.transform.rotation = Quaternion.LookRotation(move);
        }
    }
}
