using UnityEngine;

public class PlayerController : MonoBehaviour, IAttack
{
    public static PlayerController instance;

    [SerializeField] float speed;
    [SerializeField] float move;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] string currentState;
    [SerializeField] float cooldown = 0.5f;


    [SerializeField] public bool isFacingRight = true;
    [SerializeField] bool isStriking = false;
    [SerializeField] bool isAttacking = false;
    [SerializeField] bool isCrouching = false;
    [SerializeField] bool isCrouchAttacking = false;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool isJumpAttacking = false;
    [SerializeField] bool isFlyingKick = false;

    [SerializeField] GameObject fireballPrefab;
    [SerializeField] Transform fireballPosition;
    [SerializeField] BulletController bullet;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    public int jumpCount = 0;

    public DamReceiver damReceiver;
    public PlayerStatus playerStatus;

    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        PlayerController.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        Flip();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isJumping)
            {
                FlyingKick();
            }
            else
            {
                Strike();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && bullet.fireTimer <= 0f)
        {
            if (isJumping)
            {
                JumpAttack();
            }
            else if (isCrouching)
            {
                CrouchAttack();
            }
            else
            {
                Attack();
                Fireball();
                bullet.fireTimer = bullet.fireRate;
            }
        }
        else
        {
            bullet.fireTimer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            Crouch();
        }
        else isCrouching = false;
    }

    private void FixedUpdate()
    {
        if (IsGround())
        {
            isJumping = false;
            if (isStriking)
            {
                PlayAnimationState("strike");
                Invoke(nameof(StopStrike), cooldown);
            }
            else if (isAttacking)
            {
                PlayAnimationState("attack");
                Invoke(nameof(StopAttack), 0.5f);
            }
            else
            {
                if (move != 0)
                {
                    PlayAnimationState("walk");
                    Move();
                }
                else if (isCrouching)
                {
                    if (isCrouchAttacking)
                    {
                        PlayAnimationState("crouch_attack");
                        Invoke(nameof(StopCrouchAttacking), cooldown);
                    }
                    else PlayAnimationState("crouch");
                }
                else
                {
                    PlayAnimationState("idle");
                }
            }
        }
        else
        {
            isJumping = true;
            if (isJumpAttacking)
            {
                PlayAnimationState("jump_attack");
                Invoke(nameof(StopJumpAttacking), cooldown);
            }
            else if (isFlyingKick)
            {
                PlayAnimationState("flying_kick");
                Invoke(nameof(StopFlyingKick), cooldown);
            }
            else
            {
                PlayAnimationState("jump");
            }
        }
    }



    bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
    void Crouch() => isCrouching = true;

    void CrouchAttack() => isCrouchAttacking = true;
    void StopCrouchAttacking() => isCrouchAttacking = false;

    void Attack() => isAttacking = true;

    void StopAttack() => isAttacking = false;

    void Strike() => isStriking = true;

    void StopStrike() => isStriking = false;

    private void Move() => rb.velocity = new Vector2(move * speed, rb.velocity.y);

    void Jump() => rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    void JumpAttack() => isJumpAttacking = true;
    void StopJumpAttacking() => isJumpAttacking = false;
    void FlyingKick() => isFlyingKick = true;
    void StopFlyingKick() => isFlyingKick = false;

    void OnAttackEventCallBack()
    {
        Debug.Log("OnAtaack");
    }


    void Flip()
    {
        if (isFacingRight && move > 0 || move < 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void PlayAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    public void Fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballPosition.position, fireballPosition.rotation);
        bullet = fireball.GetComponent<BulletController>();
        bullet.FacingRight(isFacingRight);
        PlayAnimationState("Fireball");
    }
    public void Blash()
    {

    }
}