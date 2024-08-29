using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTimer;
    public float spawnDelay;
    public int enemyCount = 0;

    private void Awake()
    {
        enemyPrefab = GameObject.Find("Enemy");
        this.enemyPrefab.SetActive(false);
    }

    private void Update()
    {
        Spawn();
    }

    public virtual void Spawn()
    {
        if (PlayerController.instance.damReceiver.CheckHp()) return;
        if (enemyCount > 3) return;
        this.spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnDelay) return;
        spawnTimer = 0;
        GameObject enemy = Instantiate(enemyPrefab);
        enemyCount++;
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }
}
