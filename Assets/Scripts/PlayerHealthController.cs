using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength; // invinsibility after hit duration
    private float invincibleCounter; // count down to 0

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0) {
            //Time.deltaTime - 1/frameRate
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0) {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void dealDamage() {

        if (invincibleCounter <= 0) {

            currentHealth--;

            if (currentHealth <= 0) {
                currentHealth = 0;

                //gameObject.SetActive(false); moved to level manager
                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.respawnPlayer();
            } else {
                invincibleCounter = invincibleLength; 
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.7f); // displaying inv - set to transparent

                PlayerController.instance.knockBack();
                AudioManager.instance.playSFX(4);
            }

            UIController.instance.updateHealthDisplay();
        }
    }


    public void healPlayer() {
        currentHealth++;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        UIController.instance.updateHealthDisplay();
    }
}
