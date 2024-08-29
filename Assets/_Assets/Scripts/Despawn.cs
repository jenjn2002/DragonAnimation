using UnityEngine;

public class Despawn : MonoBehaviour
{
    public EnemyController enemyController;
    public virtual void Despawner()
    {
        Destroy(gameObject);
        enemyController.enemySpawner.enemyCount--;
    }
}
