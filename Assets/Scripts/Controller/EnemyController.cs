using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class EnemyController : TankController
{
    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        levelController.Level = 1;
    }

    protected override TankInfo GetTankInfo(int level)
    {
        return DataManager.Instance.enemyVO.GetTankInfo(level);
    }

    protected override void OnDie()
    {
        Observer.Instance.Notify(TOPICNAME.ENEMY_DIE,this);
        Destroy(gameObject);
    }
}
