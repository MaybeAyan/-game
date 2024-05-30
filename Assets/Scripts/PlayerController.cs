using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 60f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true; // 角色初始朝向
    private SpriteRenderer sp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // 获取玩家的输入
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // 获取水平轴（A/D键，左箭头/右箭头）
        float moveVertical = Input.GetAxisRaw("Vertical"); // 获取垂直轴（W/S键，上箭头/下箭头）

        // 根据输入计算移动方向
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        if (movement != Vector2.zero) {
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
            
        if (moveHorizontal > 0 && facingRight || moveHorizontal < 0 && !facingRight)
        {
           Flip();
        }

        // 移动角色
        MoveCharacter(movement);

    }

    void MoveCharacter(Vector2 direction)
    {
        // 更新Rigidbody位置
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight; // 改变朝向标志
        sp.flipX = !facingRight;
    }

    void OnCollsionEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") // 检查碰撞的对象是否为敌人
        {
            // 处理与敌人的碰撞逻辑
            Debug.Log("Player collided with Enemy!");
        }
    }

    public void Dead() {
        Destroy(gameObject);
    }
}
