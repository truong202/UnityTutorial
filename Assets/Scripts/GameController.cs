using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using TMPro;
public class TOPICNAME
{
    public const string ENEMY_DIE = "Enemy_Die";
}

public class GameController : MonoBehaviour
{
    //[SerializeField]
    //TextMeshProUGUI txtScore;

    int score = 0;

    private void Awake()
    {
        //DataManager.Instance.LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DIE, OnEnemyDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnemyDie(object data)
    {
        score++;
        //txtScore.text = score.ToString();
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(TOPICNAME.ENEMY_DIE, OnEnemyDie);
    }
}
