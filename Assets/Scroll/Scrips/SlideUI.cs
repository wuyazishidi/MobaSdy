/****************************************************
    文件：NewBehaviourScript.cs
	作者：Jwp
    邮箱: 2604591896@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlideUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
    Vector2 startPos;
    Vector2 endPos;
    public Transform trans;
    Vector2 objStartPos;
    Vector2 originPos;
    bool isDrag = false;
    float width;
    float height;
    int count;
    private void Start() {
        width = GetComponent<RectTransform>().sizeDelta.x;
        height = GetComponent<RectTransform>().sizeDelta.y;
        count = trans.childCount;
        originPos = trans.position;
        for (int i = 0; i < trans.childCount; i++) {
            trans.GetChild(i).transform.localPosition = new Vector3(i*width,0,0);
        }
    }
    public void OnPointerDown(PointerEventData eventData) {
        startPos = eventData.position;
        objStartPos = trans.localPosition;
        isDrag = true;

    }

    public void OnDrag(PointerEventData eventData) {
        float v = eventData.position.x - startPos.x;
        Vector2 tempPos=objStartPos + new Vector2(v,0);
        tempPos.x = tempPos.x >= 0 ? 0 : tempPos.x;
        tempPos.x = tempPos.x <= -width * (count - 1) ? -width * (count - 1) : tempPos.x;
        trans.localPosition = tempPos;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isDrag = false;
        tranX = trans.localPosition.x;
        offect = (int)(Mathf.Abs(tranX) / width);
        offectX = Mathf.Abs(tranX) - offect * width;
    }
    float speed=1000;
    float tranX;
    int offect;
    float offectX;
    private void Update() {
        if (!isDrag) {
            if (offectX == 0 || trans.localPosition.x <= -width * (count - 1) || trans.localPosition.x>=0) return;
            if (offectX >=width / 2&& offectX<width) {
                offectX += Time.deltaTime * speed;
                trans.localPosition -= new Vector3(Time.deltaTime * speed,0,0);
            }
            else if(offectX < width / 2 && offectX >0) {
                offectX -= Time.deltaTime * speed;
                trans.localPosition += new Vector3(Time.deltaTime * speed, 0, 0);
            }
            else {
                Debug.Log("error");
            }
            

        }
    }
}