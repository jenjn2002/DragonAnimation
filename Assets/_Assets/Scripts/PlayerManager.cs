using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instant{ get; set; }
    public PlayerController playerController;

    private void Awake()
    {
        PlayerManager.instant = this;
    }

    public Vector3 Position()
    {
        return this.transform.position;
    }
}
