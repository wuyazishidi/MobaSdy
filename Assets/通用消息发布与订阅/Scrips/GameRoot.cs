/****************************************************
    文件：GameRoot.cs
	作者：Jwp
    邮箱: 2604591896@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour {
    public InfoWindow infoWindow;
    public PlayerWindow playerWindow;
    public SettingWindow settingWindow;

    PlayerInfoData pd;
    private void Awake() {
        
    }

    private void Start() {
        
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