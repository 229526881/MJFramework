using Model;
using UnityEditor;

namespace M.ProductionPipeline
{
    public class GenCodeJsonStep : IStep
    {
        public void Run()
        {
            FileHelper.DelectDir(EditorConst.JSON_CONFIG);
            EditorHelper.RunMyBat("gen_code_jsonһ������.bat", "../Excel/");
            UnityEditor.EditorApplication.UnlockReloadAssemblies();
            UnityEditor.EditorUtility.RequestScriptReload();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public string EnterText()
        {
            return $"����Excel����ͨ��ʽ ��ʼ��";
        }

        public string ExitText()
        {
            return $"����Excel����ͨ��ʽ ������";
        }

        public bool IsTriggerCompile()
        {
            return true;
        }
    }
}