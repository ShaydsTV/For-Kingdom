using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;

    public Rigidbody2D rigidboby2D;

    private Vector3 velocity = Vector3.zero;

    // State indicator
    private bool isJumping;
    private bool isGrounded;
    public bool isClimbing;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    private Vector3 targetVelocity;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerController in the scene.");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        Flip(rigidboby2D.velocity.x);
        float characterVelocity = Mathf.Abs(rigidboby2D.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxisRaw("Vertical") * climbSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        Move(horizontalMovement, verticalMovement);
    }

    void Move(float _horizontalMovement, float _verticalMovement)
    {

        // Move right/left
        targetVelocity = new Vector2(_horizontalMovement, rigidboby2D.velocity.y);
        rigidboby2D.velocity = Vector3.SmoothDamp(rigidboby2D.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rigidboby2D.AddForce(new Vector3(0f, jumpForce));
            isJumping = false;
        }

        // Move up/down
        if (isClimbing)
        { 
           targetVelocity = new Vector2(0, _verticalMovement);
           rigidboby2D.velocity = Vector3.SmoothDamp(rigidboby2D.velocity, targetVelocity, ref velocity, .05f);
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
