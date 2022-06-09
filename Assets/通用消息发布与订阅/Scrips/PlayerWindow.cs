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
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange, RefreshPlayerName);

    }
    void RefreshPlayerName(object param1,object param2) {
        SetName();
    }

    private void SetName() {
        txtplayerName.text = pd.name;
    }
}