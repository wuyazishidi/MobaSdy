using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerWindow:MonoBehaviour {
    EvtSvc evtSvc;
    public Text txtplayerName;

    private PlayerInfoData pd;

    private void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();
        SetName();

        evtSvc = GameRoot.Instance.GetEvtSvc();
    }

    private void SetName() {
        txtplayerName.text = pd.name;
    }
}