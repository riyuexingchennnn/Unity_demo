using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private GameObject Player;
    public Transform[] movePos;
    public float waitTime;
    public float speed;
    private int i;
    private float time;
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        i = 0;
        time = waitTime;
        playerDefTransform = Player.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (time < 0.0f)
            {
                i = (i == 0) ? 1 : 0;
                time = waitTime;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.CompareTag("Player") && other.GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
