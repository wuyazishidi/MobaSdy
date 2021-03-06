/****************************************************
    文件：GameRoot.cs
	作者：Jwp
    邮箱: 2604591896@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class GameRoot : MonoBehaviour {
    public InfoWindow infoWindow;
    public PlayerWindow playerWindow;
    public SettingWindow settingWindow;

    EvtSvc evtSvc;
    PlayerInfoData pd;
    public static GameRoot Instance;
    private void Awake() {
        Instance = this;
        evtSvc = GetComponent<EvtSvc>();
        pd = new PlayerInfoData {
            name = "宝安大道小旋风",
            level = 666,
        };
    }

    private void Start() {

        SetInfoWndState();
        SetPlayerWndState();
        SetSettingWndState(false);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            evtSvc.SendEvt(EvtID.OntestLog);
        }
    }
    public EvtSvc GetEvtSvc() {
        return evtSvc;
    }

    public PlayerInfoData GetPlayerInfoData() {
        return pd;
    }

    public void SetInfoWndState(bool state=true) {
        infoWindow.gameObject.SetActive(state);
    }

    public void SetPlayerWndState(bool state = true) {
        playerWindow.gameObject.SetActive(state);
    }

    public void SetSettingWndState(bool state = true) {
        settingWindow.gameObject.SetActive(state);
    }
   
}

public class PlayerInfoData {
    public string name;
    public int level;
}