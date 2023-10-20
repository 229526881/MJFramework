using UnityEditor;

namespace M.ProductionPipeline
{
    public class CloseBetterStreamingAssetsStep : IStep
    {
        public void Run()
        {
            if (System.IO.Directory.Exists(EditorConst.BETTER_STREAMING_ASSETS))
            {
                UnityEditor.FileUtil.ReplaceDirectory(EditorConst.BETTER_STREAMING_ASSETS, EditorConst.BETTER_STREAMING_ASSETS_);
                UnityEditor.FileUtil.DeleteFileOrDirectory($"{EditorConst.BETTER_STREAMING_ASSETS}.meta");
                UnityEditor.FileUtil.DeleteFileOrDirectory(EditorConst.BETTER_STREAMING_ASSETS);
            }
        }

        public string EnterText()
        {
            return $"�ر�BetterStreamingAssets ��ʼ��";
        }

        public string ExitText()
        {
            return $"�ر�BetterStreamingAssets ������";
        }

        public bool IsTriggerCompile()
        {
            return System.IO.Directory.Exists(EditorConst.BETTER_STREAMING_ASSETS);
        }
    }
}