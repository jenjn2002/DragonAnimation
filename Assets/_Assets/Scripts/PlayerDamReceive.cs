using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceive : DamReceiver
{
    public PlayerController playerController;
    public override void Receive(int dam)
    {
        base.Receive(dam);
        if (this.CheckHp()) 
        { 
            this.playerController.playerStatus.CheckDead();
            UIManager.intstance.btnGameOver.SetActive(true);
        }

    }
}
