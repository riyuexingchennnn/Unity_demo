using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;//伤害值
    public APress AP;
    public CameraShake CS;
    public float startTime;//全靠自己调
    public float disTime;
    public float timeRate;
    private float Timer;
    [Header("=== 按键设置 ===")]
    public string KeyA = "j";

    private Animator anim;
    private PolygonCollider2D collider2D;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent;//这样写很危险，前提是只有一个父物体
        anim = player.gameObject.GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
        //collider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if ((Input.GetKey(KeyA) || AP.isPress) && Timer > timeRate)
        {
            anim.SetTrigger("Attack");//这是在any state里的
            //之后要返回到各个里面去的
            StartCoroutine(StartAttack());
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(disTime);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter");
        if (other.gameObject.CompareTag("Enemery"))
        {
            CS.Shake();
            other.GetComponent<Enemery>().TakeDamage(damage);
        }
    }
}
