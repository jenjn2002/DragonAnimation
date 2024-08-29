using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerController playerController;

    public virtual void CheckDead()
    {
        if(playerController.damReceiver.CheckHp()) this.Dead();
    }

    public virtual void Dead()
    {
        Debug.Log("dead");
    }
    
}
