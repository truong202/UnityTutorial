using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class CreateController : MonoBehaviour
{
    public BulletController prefabBullet;

    public EnemyController prefabEnemy;

    public BulletController CreateBullet(Transform tranShoot)
    {
        BulletController bullet = PoolingObject.CreatePooling<BulletController>(prefabBullet);
        if (bullet != null)
        {
            bullet.count = 0;
            bullet.transform.position = tranShoot.position;
            bullet.transform.rotation = tranShoot.rotation;
            return bullet;
        }
        return Instantiate(prefabBullet, tranShoot.position, tranShoot.rotation);
    }

    public EnemyController CreateEnemy(Vector3 pos,int level)
    {
        EnemyController enemy = Instantiate(prefabEnemy,pos, prefabEnemy.transform.rotation);
        enemy.levelController.Level = level;
        return enemy;
    }
}

public class Creater : SingletonMonoBehaviour<CreateController>
{

}


