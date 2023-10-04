using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHPInfo
{
    public int hp;
}

public class EffectHPController : MonoBehaviour,ItemEffect
{
    public EffectHPInfo info;

    public object Info { set => info = (EffectHPInfo)value; }

    public void Active()
    {
        HPController hPController = GetComponentInChildren<HPController>();
        hPController.CurrentValue += info.hp;
        Destroy(this);
    }
}
