using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
public class PhotonController : PunBehaviour
{
    private void Start()
    {
        DataManager.Instance.LoadData();
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinRoom("Game");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("PlayerOnline", Vector3.zero, Quaternion.identity, 0);
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        base.OnPhotonJoinRoomFailed(codeAndMsg);
        PhotonNetwork.CreateRoom("Game");
    }
}
