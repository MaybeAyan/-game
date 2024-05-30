using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    public float damageAmount;

    public float lifeTime,growSpeed = 5f;

    private Vector2 targetSize;

    public bool shouldKnockBack;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,lifeTime);
        targetSize = transform.localScale;
        transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector2.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime<=0)
        {
            targetSize = Vector2.zero;
            if (transform.localScale.x == 0f) 
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount,shouldKnockBack);
        }
    }
}
