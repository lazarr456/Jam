using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public static CheckpointController instance;

    private Checkpoint[] checkpoints; // array of cps

    public Vector3 spawnPoint;


    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void deactivateCheckpoints() { // loop through all cps and reset
        for(int i = 0; i < checkpoints.Length; i++) {
            checkpoints[i].resetCheckpoint();
        }
    }


    public void setSpawnPoint(Vector3 newSpawnPoint) { // assign new spawn point - called/set in cp.cs
        spawnPoint = newSpawnPoint;
    }
}
