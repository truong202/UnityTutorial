using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MapInfo mapInfo = DataManager.Instance.mapVO.GetMapInfo(GlobalVar.currentMapLevel);
        GameObject prefabMap = Resources.Load<GameObject>(mapInfo.path);
        Instantiate(prefabMap);
        foreach (int level in mapInfo.enemies)
        {
            Vector3 pos = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
            Creater.Instance.CreateEnemy(pos, level);
        }

    }
}
