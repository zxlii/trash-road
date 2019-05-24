using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TestWindow : EditorWindow
{
    [MenuItem("Tools/All")]//在unity菜单Window下有MyWindow选项
    static void Init()
    {
        var win = EditorWindow.GetWindow<TestWindow>("tools");
        win.Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("生成场景"))
        {
            this.Close();
        }
    }
}
