using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private CoinUI coinUI; 
    // Start is called before the first frame update
    void Start()
    {
        coinUI = GameObject.Find("CoinText").GetComponent<CoinUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            coinUI.currentCoin++;
            Destroy(gameObject);
        }
    }
}
