/****************************************************
    文件：Texture2DSwitchSprite.cs
	作者：Jwp
    邮箱: 2604591896@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class Texture2DSwitchSprite {

    public Texture2D texture2D;//如果直接将texture拖到场景h面板中，需要设置Advanced中Read/Write Enabled为勾选

    /// <summary>
    /// Sprite 转 Texture2D 1:1
    /// </summary>
    /// <param name="texture2D"></param>
    /// <returns></returns>
    public static Sprite Texture2DToSprite(Texture2D texture2D) {
        Sprite sp = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        return sp;
    }

    /// <summary>
    /// Sprite 转Texture2D 1:1
    /// </summary>
    /// <param name="sp"></param>
    /// <returns></returns>
    public static Texture2D SpriteToTexture2D(Sprite sp) {

        //sprite为图集中的某个子Sprite对象
        var texture2d = new Texture2D((int)sp.rect.width, (int)sp.rect.height);
        var pixels = sp.texture.GetPixels(
            (int)sp.textureRect.x,
            (int)sp.textureRect.y,
            (int)sp.textureRect.width,
            (int)sp.textureRect.height);
        texture2d.SetPixels(pixels);
        texture2d.Apply();
        return texture2d;
    }

    /// <summary>
    /// 克隆Texture2D   1：1
    /// </summary>
    /// <param name="oldTex"></param>
    /// <returns></returns>
    public static Texture2D Texture2DCopy(Texture2D oldTex) {
        //originTex为克隆对象
        Texture2D newTex;
        newTex = new Texture2D(oldTex.width, oldTex.height);
        Color[] colors = oldTex.GetPixels(0, 0, oldTex.width, oldTex.height);
        newTex.SetPixels(colors);
        newTex.Apply();//必须apply才生效
        return newTex;
    }

    /// <summary>
    /// 从Texture中截取一部分
    /// </summary>
    /// <param name="oldTex">要截取的Texture</param>
    /// <param name="width">截取的宽度</param>
    /// <param name="height">截取的高度</param>
    /// <param name="pixel_x">截取起始x坐标</param>
    /// <param name="pixel_y">截取起始y坐标</param>
    /// <returns></returns>
    public static Texture2D CutTexture2D(Texture2D oldTex,int pixel_x,int pixel_y,int width, int height) {
        Texture2D newTex = new Texture2D(width, height);
        Color[] colors = oldTex.GetPixels(pixel_x, pixel_y, width, height);
        newTex.SetPixels(colors);
        newTex.Apply();//必须apply才生效
        return newTex;
    }

}