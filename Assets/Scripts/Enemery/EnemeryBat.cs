using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeryBat : Enemery
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    private new void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }
    private new void Update()
    {
        base.Update();//调用父类
        //注意这里有moveTowards，外面必须有这个movePos的物体
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        float x = Random.Range(leftDownPos.position.x, rightUpPos.position.x);
        float y = Random.Range(rightUpPos.position.y, leftDownPos.position.y);
        return new Vector2(x,y);
    }
}
