using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Text healthText;
    private int maxHP;
    public GameObject Player;
    private PlayerHealth PH;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        PH = Player.GetComponent<PlayerHealth>();
        maxHP = PH.HP;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)PH.HP / maxHP;
        healthText.text = PH.HP + "/" + maxHP;
    }
}
