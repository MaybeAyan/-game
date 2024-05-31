using UnityEngine;

public class EnemyController:MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 60f;
    private Rigidbody2D rb;

    public float damage = 5.0f;
    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5.0f;

    public float knockBackTime = .5f;
    private float knockBackCounter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MoveTowardsPlayer();

        if (hitCounter > 0f)
        {
            hitCounter -=Time.deltaTime;
        }

        // 击退
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;
            if (moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2f;

            }

            if (knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
            }
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // 根据需要调整enemy的移动速度
            //transform.position += direction * Time.deltaTime * moveSpeed;
            rb.velocity = direction * moveSpeed;

            // 根据移动方向改变精灵图的方向
            if (direction.x > 0)
                transform.localScale = new Vector3(transform.position.x, transform.position.y, 1);
            else if (direction.x <= 0)
                transform.localScale = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0)
        {
            PlayerHealthController.Instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }

        DamageNumberContronller.Instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake,bool shouldKnockback)
    {
        TakeDamage(damageToTake);

        if (shouldKnockback)
        {
            knockBackCounter = knockBackTime;
        }
    }
}