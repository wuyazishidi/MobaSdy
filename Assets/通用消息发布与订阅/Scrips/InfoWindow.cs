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
    }

    private void OnDisable() {
        
    }

    void SetName() {
        txtInfoName.text = pd.name;
    }

    void RefreshInfoName(object param1,object param2) {
        Debug.Log("InfoWindow Log:"+param1.ToString());
    }
}
