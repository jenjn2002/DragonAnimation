using UnityEngine;

public class EnemyController : MonoBehaviour, IAttack
{
    public PlayerController playerController;
    public BulletController bullet;
    public float attackDelay = 1f;

    public Despawn despawn;
    public EnemySpawner enemySpawner;
    [SerializeField] GameObject fireballPrefab;
    public bool isAttacking = false;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    private void Update()
    {
        bullet.fireTimer += Time.deltaTime;

        if (GetDistance() < 3f && bullet.fireTimer <= bullet.fireRate)
        {
            Fireball();
        }

        if (bullet.fireTimer > bullet.fireRate)
        {
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    void ResetAttack()
    {
        bullet.fireTimer = 0f;
    }

    bool IsFacingRight()
    {
        return !(playerController.transform.position.x > transform.position.x);
    }

    float GetDistance()
    {
        return Vector3.Distance(transform.position, playerController.transform.position);
    }

    public void Blash()
    {

    }

    public void Fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        BulletController bullet = fireball.GetComponent<BulletController>();
        bullet.FacingRight(IsFacingRight());
        playerController.PlayAnimationState("Fireball");
        isAttacking = true;
    }

}
