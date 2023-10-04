using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public interface IHit
{
    void OnHit(float damage);
}

public class BulletController : MonoBehaviour
{

    public float damage;

    public int count = 0;

    // Update is called once per frame
    void Update()
    {
        if (count >= 100)
        {
            //Destroy(gameObject);
            PoolingObject.DestroyPooling<BulletController>(this);
            return;
        }
        count++;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up, 0.2f);
        if (hit.transform != null)
        {
            IHit iHit = hit.transform.parent.GetComponent<IHit>();
            if (iHit != null)
            {
                iHit.OnHit(damage);
                //Destroy(gameObject);
                PoolingObject.DestroyPooling<BulletController>(this);
                return;
            }

        }
        //Move(transform.up);
    }
}
