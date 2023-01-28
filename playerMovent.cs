using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovent : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float playerSpeed = 8f;
    public float jumpSpeed = 5f;
    public Transform groundCheck; 
    public LayerMask ground; //����ͼ��
    public float fallAddition=3.5f;  //����ӳ�
    public bool isGround;//������
    public float start_x;
    public float start_y;//��ʼ����


    private float movex;
    private bool isJump;   //��Ծ����
    //private bool facingRight = true;
    [SerializeField] private Transform killPoint;
    private enum playerStates { idle,run,jump,fall};
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        killPoint = transform.Find("killPoint");
    }

    
    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");   //-1~1
        isJump = Input.GetButtonDown("Jump");
        if (isGround && isJump)
        {
            //rb.velocity = Vector2.up * jumpSpeed;
            rb.AddForce(new Vector2(0, 350f));
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.15f, ground);//������
        playerAnimation();
        Move();
        enemy();
        
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Move()
    {
        rb.velocity = new Vector2(movex * playerSpeed, rb.velocity.y);
        
        Flip();
    }
    private void Jump()
    {
        if (rb.velocity.y < 0) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallAddition - 1) * Time.fixedDeltaTime;
        }
        /*if (!isGround && rb.velocity.x != 0)
        {
            rb.velocity -= new Vector2(2f, 0);
        }*/
    }
    private void Flip()
    {
        if (movex != 0)
        {
            transform.localScale = new Vector3(movex, 1, 1);
        }
    }
    private void playerAnimation()
    {
        playerStates states;
        if (Mathf.Abs(movex) > 0.1f&&isGround)
        {
            states = playerStates.run;
        }
        else
        {
            states = playerStates.idle;
        }
        if (!isGround)
        {
            if (rb.velocity.y > 0.1f)
            {
                states = playerStates.jump;
            }
            else
            {
                states = playerStates.fall;
            }
        }
        anim.SetInteger("state", (int)states);
    }
    
    private void enemy()
    {
       Collider2D enemy= Physics2D.OverlapCircle(killPoint.position, 0.15f, LayerMask.GetMask("enemy"));
        if (enemy == null)
        {
            return;
        }
        Destroy(enemy.gameObject);
        rb.velocity = new Vector2(rb.velocity.x, 0f);//���y���ٶ�
        rb.AddForce(new Vector2(0, 350f));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector2(start_x, start_y);
        }
    }

}

