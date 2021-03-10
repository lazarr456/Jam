using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use the ui elements of unity engine
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    public Image heart1, heart2, heart3;

    public Sprite heartFull, heartEmpty;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealthDisplay() {
        switch (PlayerHealthController.instance.currentHealth) {
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
}
