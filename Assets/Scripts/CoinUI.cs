using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinUI : MonoBehaviour
{
    public int startCoin = 0;
    public int currentCoin;
    private Text cointext;
    // Start is called before the first frame update
    void Start()
    {
        currentCoin = startCoin;
        cointext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = currentCoin.ToString();
    }
}
