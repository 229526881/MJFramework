using Model;
using System.Text.RegularExpressions;
using UnityEditor;

namespace M.ProductionPipeline
{
    public class HotfixAnyStep : IStep
    {
        public void Run()
        {
            var text = System.Text.Encoding.UTF8.GetString(FileHelper.LoadFileByStream(EditorConst.UNITY_HOTFIX_ASMDEF));
            text = Regex.Replace(text, @"    ""includePlatforms"": \[\n        ""Editor""\n    \]", "    \"includePlatforms\": []");
            FileHelper.SaveFileByStream(EditorConst.UNITY_HOTFIX_ASMDEF, System.Text.Encoding.UTF8.GetBytes(text));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            UnityEditor.EditorApplication.UnlockReloadAssemblies();
            UnityEditor.EditorUtility.RequestScriptReload();
        }

        public string EnterText()
        {
            return $"修改Unity.Hotfix的Platforms为Any 开始！";
        }

        public string ExitText()
        {
            return $"修改Unity.Hotfix的Platforms为Any 结束！";
        }

        public bool IsTriggerCompile()
        {
            var text = System.Text.Encoding.UTF8.GetString(FileHelper.LoadFileByStream(EditorConst.UNITY_HOTFIX_ASMDEF));

            return Regex.IsMatch(text, @"    ""includePlatforms"": \[\n        ""Editor""\n    \]");
        }
    }
}