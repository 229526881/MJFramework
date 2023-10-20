using M.ProductionPipeline;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;

namespace UnityToolbarExtender
{
    [InitializeOnLoad]
    public class SceneSwitchLeftButton
    {
        static SceneSwitchLeftButton()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            if (GUILayout.Button(new GUIContent("Compile", "����Unity���루F4��")))
            {
                Compile();
            }

            if (GUILayout.Button(new GUIContent("Refresh", "ˢ��Unity��F6��")))
            {
                Refresh();
            }

            if (GUILayout.Button(new GUIContent("ClearStep", "�����������ߣ�F7��")))
            {
                ClearStep();
            }
        }

        private static void Compile()
        {
            //ScriptCompileReloadTools.ManualReload();
            UnityEditor.EditorApplication.UnlockReloadAssemblies();
            UnityEditor.EditorUtility.RequestScriptReload();
            Debug.LogError("-----------------����Unity������ɣ�-----------------"); // MDEBUG:
        }

        [MenuItem("Edit/Refresh _F6")]
        private static void Refresh()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.LogError("-----------------ˢ��Unity��ɣ�-----------------"); // MDEBUG:
        }

        [MenuItem("Edit/ClearStep _F7")]
        private static void ClearStep()
        {
            StepSaveSettings.Clear();
            Debug.LogError("-----------------�����������ߣ�-----------------"); // MDEBUG:
        }
    }
}