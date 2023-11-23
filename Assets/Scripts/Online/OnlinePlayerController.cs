using System.Collections;
using UnityEngine;

public class OnlinePlayerController : BasePlayerController
{
    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    protected override void OnDie()
    {
        Debug.Log("Die");
        PhotonNetwork.Destroy(photonView);
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            OnUpdate();
        }
    }
}