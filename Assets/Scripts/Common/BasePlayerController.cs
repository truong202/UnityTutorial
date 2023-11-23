using System.Collections;
using UnityEngine;

public abstract class BasePlayerController : TankController
{

    private void Start()
    {
        levelController.CurrentValue = 0;
        levelController.Level = 1;
    }
    protected override TankInfo GetTankInfo(int level)
    {
        return DataManager.Instance.playerVO.GetTankInfo(level);
    }

    protected void OnUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);
        Vector3 gunDirection = Vector3.zero;
        gunDirection = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gunDirection.z = transform.position.z;
        RotateGun(gunDirection);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

}
