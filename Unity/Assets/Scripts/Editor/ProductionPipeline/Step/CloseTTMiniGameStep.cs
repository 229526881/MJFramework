using UnityEditor;

namespace M.ProductionPipeline
{
    public class CloseTTMiniGameStep : IStep
    {
        public void Run()
        {
            if (System.IO.Directory.Exists(EditorConst.BYTE_GAME_PATH))
            {
                UnityEditor.FileUtil.ReplaceDirectory(EditorConst.BYTE_GAME_PATH, EditorConst.BYTE_GAME_PATH_);
                UnityEditor.FileUtil.DeleteFileOrDirectory($"{EditorConst.BYTE_GAME_PATH}.meta");
                UnityEditor.FileUtil.DeleteFileOrDirectory(EditorConst.BYTE_GAME_PATH);
            }
        }

        public string EnterText()
        {
            return $"�رն���С��Ϸ ��ʼ��";
        }

        public string ExitText()
        {
            return $"�رն���С��Ϸ ������";
        }

        public bool IsTriggerCompile()
        {
            return System.IO.Directory.Exists(EditorConst.BYTE_GAME_PATH);
        }
    }
}