using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 60f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true; // ��ɫ��ʼ����
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
        // ��ȡ��ҵ�����
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // ��ȡˮƽ�ᣨA/D�������ͷ/�Ҽ�ͷ��
        float moveVertical = Input.GetAxisRaw("Vertical"); // ��ȡ��ֱ�ᣨW/S�����ϼ�ͷ/�¼�ͷ��

        // ������������ƶ�����
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

        // �ƶ���ɫ
        MoveCharacter(movement);

    }

    void MoveCharacter(Vector2 direction)
    {
        // ����Rigidbodyλ��
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight; // �ı䳯���־
        sp.flipX = !facingRight;
    }

    void OnCollsionEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") // �����ײ�Ķ����Ƿ�Ϊ����
        {
            // ��������˵���ײ�߼�
            Debug.Log("Player collided with Enemy!");
        }
    }

    public void Dead() {
        Destroy(gameObject);
    }
}
