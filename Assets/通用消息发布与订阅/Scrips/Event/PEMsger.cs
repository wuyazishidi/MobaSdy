using System;
using System.Collections.Generic;
public class PEMsger<T> {
    private static string m_lock = "PEMsger_lock";
    private Queue<MsgParams> msgQue = new Queue<MsgParams>();
    private PEMsgMap<T> evtMap = new PEMsgMap<T>();
    public void MsgerInit() {
        msgQue.Clear();
    }

    public void MsgerTick() {
        lock (m_lock) {
            while (msgQue.Count>0) {
                MsgParams data = msgQue.Dequeue();
                TriggerMsgHandler(data.GetMsgID(),data.GetParam1(),data.GEtParam2());
            }
        }
    }

    public void MsgerUnInit() { 
    
    }

    public void AddMsgHandler(T evt,Action<object,object>cb) {
        lock (m_lock) {
            evtMap.AddMsgHandler(evt,cb);
        }
    }

    public void RmvHandlerByMsgID(T id) {
        lock (m_lock) {
            evtMap.RmvMsgHandler(id);
        }
    }
    public void RmvHandlerByTarget(object target) {
        lock (m_lock) {
            evtMap.RmvTargetHandler(target);
        }
    }

    public void InvokeMsgHandler(T evt, object param1 = null, object param2 = null) {
        lock (m_lock) {
            msgQue.Enqueue(new MsgParams(evt,param1,param2));
        }
    }

    public void InvokeMsgHandlerImmediately(T evt, object param1 = null, object param2 = null) {
        TriggerMsgHandler(evt,param1,param2);
    }
    void TriggerMsgHandler(T t,object param1,object param2) {
        List<Action<object, object>> lst = evtMap.GetMsgAllHandler(t);
        if (lst != null) {
            for (int i = 0; i < lst.Count; i++) {
                lst[i](param1,param2);
            }
        }
    }

    class MsgParams {
        T m_t = default(T);//default(T)  如果是值类型，默认为0，如果是引用类型，默认为空
        object m_param1 = null;
        object m_param2= null;
        public MsgParams(T t, object param1, object param2) {
            m_t = t;
            m_param1 = param1;
            m_param2 = param2;
        }

        public T GetMsgID() {
            return m_t;
        }

        public object GetParam1() {
            return m_param1;
        }
        public object GEtParam2() {
            return m_param2;
        }
    }
}