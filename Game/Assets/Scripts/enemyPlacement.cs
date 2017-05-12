using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlacement : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };
    [System.Serializable]
    public class Wave
    {
        public string Name;
        public Transform Enemy;
        public int Count;
        public float Rate;
    }
    public Wave[] Waves;
    public Transform[] SpawnPoints;
    private int NextWave = 0;
    private float WaveCountdown;
    private float SearchCountdown = 1f;
    public float TimeBetweenWaves = 1.5f;
    public SpawnState State = SpawnState.Counting;
    void Start()
    {
        WaveCountdown = TimeBetweenWaves;

    }
    void Update()
    {
        WaveCountdown -= Time.deltaTime;
        if (State == SpawnState.Waiting)
        {
            if (HasFired() == true)
            {
                //Give Player Points.
            }
            else
            {
                return;
            }
        }
        if (WaveCountdown <= 0)
        {
            if (State != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(Waves[NextWave]));
            }
        }
    }
    bool HasFired()
    {
        SearchCountdown -= Time.deltaTime;
        if (SearchCountdown <= 0f)
        {
            SearchCountdown = 1f;
            //If End of Blow Return True.
        }
        return false;
    }
    IEnumerator SpawnWave(Wave Wave)
    {
        State = SpawnState.Spawning;
        for (int i = 0; i < Wave.Count; i++)
        {
            SpawnEnemy(Wave.Enemy);
            yield return new WaitForSeconds(1f / Wave.Rate);
        }
        State = SpawnState.Waiting;
        yield break;
    }
    void SpawnEnemy(Transform Enemy)
    {
        //Spawn a Thing.
        Transform SP = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(Enemy, SP.position, SP.rotation);
    }
}
