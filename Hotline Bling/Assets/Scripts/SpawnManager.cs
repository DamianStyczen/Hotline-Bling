using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    enum stages { breakBetweenWaves, startOfWave, spawningEnemies, awaitEndOfWave}
    [SerializeField] stages stage = stages.awaitEndOfWave;
    public List<Wave> waves;
    public List<Vector3> spawnPoints;
    public GameObject enemy;
    public int enemiesAlive = 0;

    [SerializeField] float midWaveBreakTime = 5f;
    [SerializeField] float startOFWaveBreakTime = 2f;
    [SerializeField] int currentWave = 0;
    
    int enemiesSpawned = 0;
    float timer = 0f;

    

	// Use this for initialization
	void Start () {
        generateSpawnPoints();     
        
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (stage)
        {
            case stages.breakBetweenWaves:

                if (timer > midWaveBreakTime)
                {
                    enemiesSpawned = 0;
                    
                    stage = stages.startOfWave;
                    timer = 0;
                    getText(stage);
                }
                break;

            case stages.startOfWave:

                // DO SOME STARTOFWAVE STUFF
                if (timer > startOFWaveBreakTime)
                {
                    stage = stages.spawningEnemies;
                    timer = 0;
                }
                break;

            case stages.spawningEnemies:

                startSpawning();
                break;
            case stages.awaitEndOfWave:

                if (enemiesAlive <= 0)
                {
                    stage = stages.breakBetweenWaves;
                    timer = 0;
                    getText(stage);
                }
                break;

            default:
                Debug.Log("SpawnManager failed to update.");
                break;
        }
    }

    private void getText(stages stage)
    {
        switch (stage)
        {
            case stages.breakBetweenWaves:
                if (waves[currentWave].endOfWaveText == "")
                {
                    GameObject.Find("TextController").GetComponent<TextController>().generateText("", "Good job");
                }
                else GameObject.Find("TextController").GetComponent<TextController>().generateText("", waves[currentWave-1].endOfWaveText, 60, 40);
                break;
            case stages.startOfWave:
                if(waves[currentWave].startOfWaveText == "")
                {
                    GameObject.Find("TextController").GetComponent<TextController>().generateText("Wave " + (currentWave + 1));
                }
                else GameObject.Find("TextController").GetComponent<TextController>().generateText("Wave " + (currentWave + 1), waves[currentWave].startOfWaveText, 60, 40);
                break;
            case stages.spawningEnemies:
                break;
            case stages.awaitEndOfWave:                
                break;
            default:
                break;
        }
    }

    void startSpawning()
    {
        if (enemiesSpawned == 0)
        {
            spawnAnEnemy();
            timer = 0;
        }
        else if ((timer > waves[currentWave].spawnRate) && (enemiesSpawned < waves[currentWave].enemies))
        {
            spawnAnEnemy();
            timer = 0;
        }
        else if (enemiesSpawned >= waves[currentWave].enemies)
        {
            stage = stages.awaitEndOfWave;
            timer = 0;
            currentWave += 1;
            if (currentWave >= waves.Count) currentWave = waves.Count - 1;
        }
    }    

    private void generateSpawnPoints()
    {
        /// TOP
        spawnPoints.Add(new Vector3(10, 6, 0));
        spawnPoints.Add(new Vector3(5, 6, 0));
        spawnPoints.Add(new Vector3(0, 6, 0));
        spawnPoints.Add(new Vector3(-5, 6, 0));
        spawnPoints.Add(new Vector3(-10, 6, 0));
        /// BOTTOM
        spawnPoints.Add(new Vector3(-10, -6, 0));
        spawnPoints.Add(new Vector3(-5, -6, 0));
        spawnPoints.Add(new Vector3(0, -6, 0));
        spawnPoints.Add(new Vector3(5, -6, 0));
        spawnPoints.Add(new Vector3(10, -6, 0));
        /// LEFT
        spawnPoints.Add(new Vector3(-10, 3, 0));
        spawnPoints.Add(new Vector3(-10, 0, 0));
        spawnPoints.Add(new Vector3(-10, -3, 0));
        // RIGHT
        spawnPoints.Add(new Vector3(10, 3, 0));
        spawnPoints.Add(new Vector3(10, 0, 0));
        spawnPoints.Add(new Vector3(10, -3, 0));
    }    

    void spawnAnEnemy()
    {
        enemy.GetComponent<EnemyBehavior>().enemyScript = waves[currentWave].EnemyTypes[UnityEngine.Random.Range(0, waves[currentWave].EnemyTypes.Count)];

        Instantiate(enemy, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count - 1)], new Quaternion(0,0,0,0));
        
        enemiesSpawned += 1;
    }

}
