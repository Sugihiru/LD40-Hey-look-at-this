using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PositionManager
{
    static int widthRatio = 1920 / Screen.width;
    static int heightRatio = 1080 / Screen.height;

    static public Vector3 GetScreenPosition(Vector3 pos)
    {
        return new Vector3(pos.x / widthRatio, pos.y / heightRatio, pos.z);
    }
}
