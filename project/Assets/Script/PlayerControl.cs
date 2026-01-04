using UnityEngine;
using System.Collections;

// public class PlayerControl : MonoBehaviour
// {
//     public float speed = 5f; // Player speed
//     private Rigidbody2D rb;
//     private Vector2 moveInput;

//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         // Read keyboard input (WASD / arrows)
//         float moveX = Input.GetAxisRaw("Horizontal");
//         float moveY = Input.GetAxisRaw("Vertical");

//         moveInput = new Vector2(moveX, moveY).normalized;
//     }

//     void FixedUpdate()
//     {
//         // Move the player
//         rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
//     }
// }


public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // Player speed
    public int facingDirection = 1;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    // public Animator anim;
    // Add a flag to stop movement temporarily
    [HideInInspector] public bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read keyboard input (WASD / arrows)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 || 
        horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        if (!canMove) return; // ignore input if movement is disabled

        // anim.SetFloat("horizontal", horizontal);
        // anim.SetFloat("vertical", vertical);

        moveInput = new Vector2(horizontal, vertical).normalized;
    }

    void FixedUpdate()
    {
        if (!canMove) return; // prevent movement
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    // Call this to disable movement for a delay
    public void DisableMovement(float delay)
    {
        StartCoroutine(EnableMovementAfterDelay(delay));
    }

    private IEnumerator EnableMovementAfterDelay(float delay)
    {
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Flip()
    {
        facingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}