/****************************************************
    文件：GameRoot.cs
	作者：Jwp
    邮箱: 2604591896@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
namespace TextureSwitchSprite {
    public class GameRoot : MonoBehaviour {
        public Texture2D texture2D;
        public RawImage raw1;
        public RawImage raw2;
        private void Start() {
            raw1.texture = texture2D;
            Texture2D tex = Texture2DSwitchSprite.CutTexture2D(texture2D, 430,670,140,140);
            raw2.texture = tex;
        }
    }
}
