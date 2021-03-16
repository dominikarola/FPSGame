﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
    

public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FPSController"), Vector3.zero, Quaternion.identity);
    }
}