using System.IO;
using Model;
using UnityEditor;

namespace M.ProductionPipeline
{
    public class GenCodeBinStep : IStep
    {
        public void Run()
        {
            FileHelper.DelectDir(EditorConst.JSON_CONFIG);
            EditorHelper.RunMyBat("gen_code_binһ������.bat", "../Excel/");
            UnityEditor.EditorApplication.UnlockReloadAssemblies();
            UnityEditor.EditorUtility.RequestScriptReload();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public string EnterText()
        {
            return $"����Excel�������Ƹ�ʽ ��ʼ��";
        }

        public string ExitText()
        {
            return $"����Excel�������Ƹ�ʽ ������";
        }

        public bool IsTriggerCompile()
        {
            return true;
        }
    }
}