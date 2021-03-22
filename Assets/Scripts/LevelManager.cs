using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToRespawn;

    public int coinsCollected;



    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void respawnPlayer() {
        StartCoroutine(respawnCo());
    }

    private IEnumerator respawnCo() { // coroutine (outside normal execution)

        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.playSFX(6); // after destroying player obj

        yield return new WaitForSeconds(waitToRespawn); // wait after death and respawn

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint; // set spawn point

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; // set hp and update hp displayed
        UIController.instance.updateHealthDisplay(); // update to full hp after death

        PlayerController.instance.gameObject.SetActive(true); // set player to active
    }
}
