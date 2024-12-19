using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public string text;
    public Text dialogBoxText;
    public GameObject dialogBoxImage;
    public GameObject implyBoxImage;
    public EPress EP;

    // Start is called before the first frame update
    void Start()
    {
        
        implyBoxImage.SetActive(false);
        dialogBoxImage.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {

            implyBoxImage.SetActive(true);

            if (Input.GetKey("e") || EP.isPress)
            {
                dialogBoxText.text = text;
                dialogBoxImage.SetActive(true);
                implyBoxImage.SetActive(false);
            }
            else
            {
                dialogBoxImage.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            implyBoxImage.SetActive(false);
            dialogBoxImage.SetActive(false);
        }
    }
}
