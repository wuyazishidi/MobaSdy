using UnityEngine;
using UnityEngine.UI;

public class SettingWindow:MonoBehaviour {
    EvtSvc evtSvc;
    PlayerInfoData pd;
    public Text txtSetName;
    void SetName() {
        txtSetName.text = pd.name;
    }
    private void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();
        SetName();
        evtSvc = GameRoot.Instance.GetEvtSvc();
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange, RefreshInfoName);
    }

    void RefreshInfoName(object param1,object param2) {
        SetName();
    }

    void TestLog(object param1,object param2) {
        Debug.Log("SettingWindow Log:"+param1.ToString());
    }

    public void ClickRenameBtn() {
        Debug.Log("Click RenameBtn");
        pd.name = "解放西路小旋风"+Random.Range(1,100);
        evtSvc.SendEvt(EvtID.OnPlayerNameChange);
    }

    public void ClickCloseBtn() {
        GameRoot.Instance.SetSettingWndState(false);
    }

    private void OnDisable() {
        evtSvc.RmvTargetListener(this);
    }
}
