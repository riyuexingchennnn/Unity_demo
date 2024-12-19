using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer SR;
    private PlayerController PC;
    public int HP;
    public int blinks;
    public float time;
    public float hitBoxCdTime;
    private Animator anim;
    private ScreenFlash SF;
    private PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        SF = GetComponent<ScreenFlash>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }


    public void PlayerDamage(int damage)
    {
        HP -= damage;
        
        if (HP <= 0)
        {
            HP = 0;
            PC.enabled = false;
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.833f);
            
        }
        else
        {
            BlinkPlayer(blinks, time);
            SF.FlashScreen();
        }
        polygonCollider2D.enabled = false;
        StartCoroutine(ShowPlayerHitBox());  
    }


    //这是专门为刺弄的
    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        polygonCollider2D.enabled = true;
    }
    private void BlinkPlayer(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            SR.enabled = !SR.enabled;
            yield return new WaitForSeconds(seconds);
        }
        SR.enabled = true;
    }
}
