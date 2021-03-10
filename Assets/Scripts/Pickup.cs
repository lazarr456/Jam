using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isCoin;
    public bool isMirror;
    public bool isCollected;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isCollected) {
            if (isCoin) {
                LevelManager.instance.coinsCollected++;
                isCollected = true;
                Destroy(gameObject);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                AudioManager.instance.playSFX(1);

                UIController.instance.updateCoinCount();
            }

            if (isMirror) {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth) {
                    PlayerHealthController.instance.healPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    AudioManager.instance.playSFX(0);

                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
