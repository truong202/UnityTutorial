using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Reflection;

public interface ItemEffect
{
    public object Info { set; }
    public void Active();
}

public class ItemController : MonoBehaviour
{
    public string ItemName;

    SubEffectInfo[] itemEffectInfos;

    // Start is called before the first frame update
    void Start()
    {
        JSONNode json = JSON.Parse(Resources.Load<TextAsset>("Data/Items/" + ItemName).text);
        JSONArray array = json["data"].AsArray;
        itemEffectInfos = Utils.GetSubEffectInfos(array);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,Player.Instance.transform.position)<=1f)
        {
            foreach (SubEffectInfo itemEffectInfo in itemEffectInfos)
            {
                ItemEffect itemEffect = (ItemEffect)Player.Instance.gameObject.AddComponent(itemEffectInfo.type);
                itemEffect.Info = itemEffectInfo.data;
                Debug.Log("Item Active");
                itemEffect.Active();
            }
            Destroy(this.gameObject);
        }
    }
}
