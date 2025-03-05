using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Move Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 moveInput;

    [Header("Interact Variable")]
    [SerializeField] bool interact;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact)
        {
            interact = false;
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext contex)
    {
        if(contex.phase == InputActionPhase.Performed)
        {
            interact = true;
        }
    }

    private void TryInteract()
    {
        Debug.Log("Pressed Interact button");
    }
}
