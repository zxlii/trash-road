using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class LevelEditor : EditorWindow
{
    void OnGUI()
    {
        if (GUILayout.Button("生成场景"))
        {
            this.Close();
        }
    }
}
