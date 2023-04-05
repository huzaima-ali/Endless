using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMnager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float StartDelay = 2;
    public float RepeatRate = 2;
    private PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(PlayerControllerScript.gameover==false)
        {
            Instantiate(ObstaclePrefab, spawnPos, ObstaclePrefab.transform.rotation);
        }
        
    }
}
