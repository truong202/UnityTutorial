using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using LTAUnityBase.Base.Network;
using UnityEngine.Networking;
using SimpleJSON;
public class LearnUnity : MonoBehaviour
{
    
    
    void Start()
    {

        RestRequest request = new RestRequest("http://10.20.30.120:3000/test", UnityWebRequest.kHttpVerbPOST);
        JSONObject json = new JSONObject();
        json.Add("a", 1);
        json.Add("b", 2);
        request.AddBody(json.ToString());
        StartCoroutine(request.IeRequest(new ActionOnResponse(OnSuccess,OnError)));
    }

    void OnSuccess(string data)
    {
        Debug.Log(data);
    }

    void OnError(string error)
    {
        Debug.Log(error);
    }
}
