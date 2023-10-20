using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace M.ProductionPipeline
{
    public class EnableUnity_Logs_ViewerStep : IStep
    {
        public void Run()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(EditorConst.GAME_UNITY);
            EditorApplication.ExecuteMenuItem("Tools/Reporter/Create");
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
        }

        public string EnterText()
        {
            return $"����Unity-Logs-Viewer ��ʼ��";
        }

        public string ExitText()
        {
            return $"����Unity-Logs-Viewer ������";
        }

        public bool IsTriggerCompile()
        {
            return false;
        }
    }
}