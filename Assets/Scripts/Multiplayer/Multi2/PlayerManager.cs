﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    GameObject controller;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        controller = PhotonNetwork.Instantiate(Path.Combine("Prefab", "Entities", "Pink_Monster"), Vector3.zero, Quaternion.identity, 0, new object[] { PV.ViewID });
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
