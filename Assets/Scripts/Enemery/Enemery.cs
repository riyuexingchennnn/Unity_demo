using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemery : MonoBehaviour
{
    private PlayerHealth PH;
    public GameObject bloodEffect;
    public GameObject dropCoin;
    public int HP;
    public int damage;
    public float flashTime;
    private SpriteRenderer SR;
    private Color originalColor;
    // Start is called before the first frame update
    public void Start()
    {
        //想要预制体，就要找名字
        PH = GameObject.Find("Player").GetComponent<PlayerHealth>();
        SR = GetComponent<SpriteRenderer>();
        originalColor = SR.color;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    //受击反馈
    public void TakeDamage(int damage)
    {
        HP -= damage;//这里是被玩家伤害
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if (HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(dropCoin, transform.position, Quaternion.identity);
        }
    }

    public void FlashColor(float time)
    {
        SR.color = Color.red;
        Invoke("ResetColor", time);
    }

    public void ResetColor()
    {
        SR.color = originalColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            PH.PlayerDamage(damage);
        }
    }
}