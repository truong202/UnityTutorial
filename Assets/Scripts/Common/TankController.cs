using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TankInfo
{
    public int damage;
    public int hp;
}

public abstract class TankController : MoveController,IHit
{

    public Transform gun;

    public Transform tranShoot;

    public Transform body;

    public HPController hpController;

    public LevelController levelController;

    public float damage;

    protected virtual void Awake()
    {
        hpController.onDie = OnDie;
        levelController.onLevelUp = OnLevelUp;
    }

    protected override void Move(Vector3 direction)
    {
        body.up = direction;
        base.Move(direction);
    }

    protected void RotateGun(Vector3 direction)
    {
        gun.up = direction;
    }

    protected void Shoot()
    {
        BulletController bullet = Creater.Instance.CreateBullet(tranShoot);
        bullet.damage = damage;
        Sound.Instance.PlaySound("laser_shot");
    }

    public void OnHit(float damage)
    {
        hpController.TakeDamage(damage);
    }

    protected abstract void OnDie();

    void OnLevelUp(int level)
    {
        TankInfo tankInfo = GetTankInfo(level);
        damage = tankInfo.damage;
        hpController.HP = tankInfo.hp;
        Sound.Instance.PlaySound("power_up_sound");
    }

    protected abstract TankInfo GetTankInfo(int level);

}
