using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace M.ProductionPipeline
{
    public class ExportAllAssetCollectorStep : IStep
    {
        public void Run()
        {
            List<string> pathList = new List<string>();
            EditorHelper.GetAssetPath(pathList, EditorConst.ASSET_COLLECTOR);
            EditorHelper.GetAssetPath(pathList, EditorConst.UNIT_PREFAB_PATH);
            EditorHelper.GetAssetPath(pathList, EditorConst.ENVIRONMENT_PATH);

            for (int i = pathList.Count - 1; i >= 0; i--)
            {
                if (Path.GetFileNameWithoutExtension(pathList[i]).EndsWith("_AC"))
                {
                    AssetCollectorEditor.ExportAssetCollector(AssetDatabase.LoadAssetAtPath<Object>(pathList[i]));
                }
            }
        }

        public string EnterText()
        {
            return $"����������Դ�ռ��� ��ʼ��";
        }

        public string ExitText()
        {
            return $"����������Դ�ռ��� ������";
        }

        public bool IsTriggerCompile()
        {
            return false;
        }
    }
}