using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class Test
{
    public int a;
    public int b;

    public override string ToString()
    {
        return a + " " + b;
    }
}


public class LearnUnity : MonoBehaviour
{
    
    
    void Start()
    {

        string json = Resources.Load<TextAsset>("Data/Test").text;

        Assembly assembly = Assembly.Load("Assembly-CSharp");

        Test data = (Test)JsonUtility.FromJson(json, assembly.GetType("Test"));
        Debug.Log(data.ToString());
    }


    ////// Update is called once per frame
    //void Update()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 0.5f);
    //    Debug.DrawRay(transform.position, Vector3.left, Color.red, 0.5f);
    //    if (hit.transform != null)
    //    {
    //        Debug.Log(hit.transform.gameObject.name);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("OnCollisionEnter2D " + collision.gameObject.name);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("OnCollisionExit2D " + collision.gameObject.name);
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("OnCollisionStay2D " + collision.gameObject.name);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerEnter2D " + collision.gameObject.name);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerExit2D " + collision.gameObject.name);
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerStay2D " + collision.gameObject.name);
    //}

}
