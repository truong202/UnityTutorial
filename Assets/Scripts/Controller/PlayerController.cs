using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class PlayerController : BasePlayerController
{
    FilterTargetController filterTarget;

    protected override void Awake()
    {
        base.Awake();
        filterTarget = GetComponent<FilterTargetController>();
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DIE, OnEnemyDie);
    }


    protected override void OnDie()
    {
        Debug.Log("OnDie");
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();

        /*  float horizontal = Input.GetAxis("Horizontal");
          float vertical = Input.GetAxis("Vertical");

          Vector3 direction = new Vector3(horizontal, vertical);
          Move(direction);
          //Transform target = TargetController.GetTarget(filterTarget);
          Vector3 gunDirection = Vector3.zero;
          //if (target == null)
          //{
          gunDirection = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

          //}
          //else
          //{
          //    gunDirection = transform.position - target.position;
          //}
          gunDirection.z = transform.position.z;
          RotateGun(gunDirection);
          if (Input.GetMouseButtonDown(0))
          {
              Shoot();
          }*/
    }

    void OnEnemyDie(object data)
    {
        EnemyController enemy = (EnemyController)data;
        levelController.CurrentValue += enemy.levelController.Level * 50;
    }


}

public class Player : SingletonMonoBehaviour<PlayerController>
{

}
