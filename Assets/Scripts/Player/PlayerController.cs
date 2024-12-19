using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BPress BP;
    public JoyStickHandleLogic JSHL;
    [Header("=== ����ٶ� ===")]
    public float runSpeed;
    public float jumpSpeed;
    public float climbSpeed;

    [Header("=== �������� ===")]
    
    private Animator anim;
    private Rigidbody2D rigid;
    private float moveDir;
    private bool isRun;
    private bool isJump;
    private bool isGround;
    private bool isClimb;
    private bool isFall;
    private bool isLadder;
    private bool canDoubleJump;
    private BoxCollider2D feet;
    private float PlayerGravity;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlayerGravity = rigid.gravityScale;
        anim = GetComponent<Animator>();
        feet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update()�����滮����
        Run();
        CheckGrounded();
        CheckLadder();
        Jump();
        Fall();
        Climb();
        //Attack();
        //Debug.Log(Input.touchCount);//�ֻ���
    }

    //��ɫ���ҷ�ת
    private void Flip()
    {
        if (isRun)
        {
            if (moveDir > 0.001f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (moveDir < -0.001f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void Run()
    {
        moveDir = 0;
        //---------------PC��
        if (Input.GetAxis("Horizontal") != 0)
            moveDir = Input.GetAxis("Horizontal");

        //-------------Android��
        if (JSHL.moveInput.x != 0)
            moveDir = JSHL.moveInput.x;


        rigid.velocity = new Vector2(moveDir * runSpeed, rigid.velocity.y);
        isRun = (Mathf.Abs(moveDir) > 0.01f) ? true : false;
        anim.SetBool("Run", isRun);
        Flip();
    }
    private void Jump()
    {
        //��K��Ծ,��Ȼ�����Ӳ��ð�
        if (Input.GetKey("k") || BP.isPress)
        {          
            if (isGround)
            {
                rigid.velocity = Vector2.up * jumpSpeed;
                anim.SetBool("Jump", true);
                anim.SetBool("Climb", false);//��ÿһ�����ǽ��һ��bug
            }
            else
            {
                if (canDoubleJump && anim.GetBool("Fall"))
                {
                    canDoubleJump = false;
                    rigid.velocity = Vector2.up * jumpSpeed;
                    anim.SetBool("Jump", true);
                    //Debug.Log("DoubleJump");
                }
            }
        }
        isJump = anim.GetBool("Jump");
    }
    private void Fall()
    {
        //������� �Լ�����
        if (!isGround && rigid.velocity.y < 0.0f)
        {
            anim.SetBool("Jump", false);//��ÿһ�����ǽ��һ��bug
            anim.SetBool("Fall", true);//��ÿһ�����ǽ��һ��bug
            anim.SetBool("Run", false);//��ÿһ�����ǽ��һ��bug
        }
        isFall = anim.GetBool("Fall");
    }
    private void CheckGrounded()
    {
        isGround = feet.IsTouchingLayers(LayerMask.GetMask("Ground"))
                || feet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        if (isGround)
        {
            canDoubleJump = true;
        }
        //Debug.Log("isGround=" + isGround);
        if (isGround)
        {
            
            anim.SetBool("Fall", false);
        }
        anim.SetBool("Ground", isGround);
    }

    private void Climb()
    {
        if (isLadder)
        {
            float moveY = 0; 
            //-----------PC��
            if(Input.GetAxis("Vertical") != 0)
                moveY= Input.GetAxis("Vertical");

            //----------Android��
            if(JSHL.moveInput.y!=0)
                moveY = JSHL.moveInput.y;

            if (Mathf.Abs(moveY) > 0.5f)
            {
                //Debug.Log("Climb");
                anim.SetBool("Climb", true);
                anim.SetBool("Jump", false);//��ÿһ�����ǽ��һ��bug
                anim.SetBool("Fall", false);//��ÿһ�����ǽ��һ��bug
                rigid.gravityScale = 0.0f;
                rigid.velocity = new Vector2(rigid.velocity.x, moveY * climbSpeed);
            }
            else
            {
                anim.SetBool("Climb", false);
                if (isJump || isFall)
                {

                }
                else
                {  
                    anim.SetBool("Ground", true);
                    rigid.velocity = new Vector2(rigid.velocity.x, 0.0f);//ͣ��������
                }
            }
        }
        else
        {
            rigid.gravityScale = PlayerGravity;
            anim.SetBool("Climb", false);
        }
    }
    private void CheckLadder()
    {
        isLadder = feet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }
    //private void Attack()
    //{
    //    if (Input.GetKey(KeyA))
    //    {
    //        anim.SetTrigger("Attack");//������any state���
    //        //֮��Ҫ���ص���������ȥ��
    //    }
    //}
}
