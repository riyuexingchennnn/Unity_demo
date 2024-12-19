using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeryMiniSnake : Enemery
{
    public Transform leftPos;
    public Transform rightPos;
    private Transform movePos;

    public float speed;
    public float startWaitTime;
    private float waitTime;
    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos = leftPos;
        Flip();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();//���ø���
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                movePos = (movePos == leftPos) ? rightPos : leftPos;
                Flip();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void Flip()
    {
        //����Ҳ��ת
        transform.localRotation = (movePos == rightPos) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
    }
}
