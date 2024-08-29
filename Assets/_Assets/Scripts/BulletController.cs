using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float lifeTime = 3f;
    public float fireTimer;
    public float fireRate = 0.5f;

    public Rigidbody2D rb;
    public bool isFacingRight;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void FacingRight(bool isFacing)
    {
        isFacingRight = !isFacing;
    }
    private void FixedUpdate()
    {
        if (isFacingRight)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -transform.right * speed;
        }
    }
}
