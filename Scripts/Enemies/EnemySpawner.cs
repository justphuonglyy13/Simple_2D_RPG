using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SPAWN_STATE{
    SPAWNING,
    WAITING,
    COUNTING
}

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyWave{
        public string name;
        public Transform[] enemy;
        public int count;
        public float spawningRate;              //rate per second
    }

    public List<EnemyWave> enemyWaves = new List<EnemyWave>();

    [SerializeField]
    public Transform[] spawnPoints;
    private int nextWave;
    public float waveCooldown;
    public float waveCountdown;

    private float searchCountdown;

    private SPAWN_STATE spawnState = SPAWN_STATE.COUNTING;

    void Start() {
        if (spawnPoints.Length == 0) {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = waveCooldown;
    }

    void Update() {
        if (spawnState == SPAWN_STATE.WAITING) {
            //checking whether the enemies are still alive
            if (!isEnemyAlive()) {
                WaveComplete();
            }
            else return ;
        }

        if (waveCountdown <= 0) {
            if (spawnState != SPAWN_STATE.SPAWNING) {
                StartCoroutine(SpawnEnemyWave(enemyWaves[nextWave]));
            } 
        } else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveComplete() {
        Debug.Log("Wave completed!!!");
        spawnState = SPAWN_STATE.COUNTING;
        waveCountdown = waveCooldown;
        if (nextWave + 1 >= enemyWaves.Count) {
            nextWave = 0;
            Debug.Log("Completed all waves!!!");
        }

       nextWave++;
    }
 
    bool isEnemyAlive() {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }
        return true;  
    }

    IEnumerator SpawnEnemyWave(EnemyWave wave) {
        Debug.Log("Spawning wave: " + wave.name);
        spawnState = SPAWN_STATE.SPAWNING;
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy[Random.Range(0, wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / wave.spawningRate);            //Enemy spawning rate/ density
        }
        spawnState = SPAWN_STATE.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform enemy) {
        Debug.Log("Spawning Enemy" + enemy.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
