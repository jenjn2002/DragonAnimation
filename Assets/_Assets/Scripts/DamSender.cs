using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamSender : MonoBehaviour
{
    protected EnemyController enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<EnemyController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamReceiver damReceiver = collision.GetComponent<DamReceiver>();
        if(damReceiver != null)
        {
            damReceiver.Receive(1);
            this.enemy.despawn.Despawner();
        }
    }
}
