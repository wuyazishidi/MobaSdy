using System;
using UnityEngine;
public enum EvtID {

    None = 0,
    /// <summary>
    /// 当玩家改名时
    /// </summary>
    OnPlayerNameChange,
    /// <summary>
    /// 打印日志
    /// </summary>
    OntestLog,
}

public class EvtSvc:MonoBehaviour {
    PEMsger<EvtID> msger = new PEMsger<EvtID>();
    private void Awake() {
        msger.MsgerInit();
    }
    private void Update() {
        msger.MsgerTick();
    }

    private void OnDestroy() {
        msger.MsgerUnInit();
    }

    public void AddEvtListener(EvtID evt, Action<object, object> cb) {
        msger.AddMsgHandler(evt,cb);
    }
    public void RmvEvtListener(EvtID evt) {
        msger.RmvHandlerByMsgID(evt);
    }

    public void RmvTargetListener(object target) {
        msger.RmvHandlerByTarget(target);
    }

    public void SendEvt(EvtID evt, object param1=null, object param2=null) {
        msger.InvokeMsgHandler(evt,param1,param2);
    }

    public void SentEvtImmediately(EvtID evt, object param1, object param2) {
        msger.InvokeMsgHandlerImmediately(evt, param1, param2);
    }

}
