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

        yield return new WaitForSeconds(waitToRespawn);

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.updateHealthDisplay();
    }
}
