using UnityEngine;
using UnityEngine.UI;

public class InfoWindow:MonoBehaviour {
    EvtSvc evtSvc;

    public Text txtInfoName;

    private PlayerInfoData pd;

    private void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();
        SetName();
        evtSvc = GameRoot.Instance.GetEvtSvc();
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange,RefreshInfoName);
    }

    private void OnDisable() {
        evtSvc.RmvTargetListener(this);
    }

    void SetName() {
        txtInfoName.text = pd.name;
    }

    public void ClickPlayerIcon() {
        GameRoot.Instance.SetSettingWndState();
    }

     void RefreshInfoName(object param1,object param2) {
        SetName();
    }
}
