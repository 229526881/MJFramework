using UnityEditor;

namespace M.ProductionPipeline
{
    public class OpenTTMiniGameStep : IStep
    {
        public void Run()
        {
            if (System.IO.Directory.Exists(EditorConst.BYTE_GAME_PATH_))
            {
                UnityEditor.FileUtil.ReplaceDirectory(EditorConst.BYTE_GAME_PATH_, EditorConst.BYTE_GAME_PATH);
                UnityEditor.FileUtil.DeleteFileOrDirectory(EditorConst.BYTE_GAME_PATH_);
            }
        }

        public string EnterText()
        {
            return $"��������С��Ϸ ��ʼ��";
        }

        public string ExitText()
        {
            return $"��������С��Ϸ ������";
        }

        public bool IsTriggerCompile()
        {
            return System.IO.Directory.Exists(EditorConst.BYTE_GAME_PATH_) || System.IO.Directory.Exists(EditorConst.STARK_MINI_UNITY_PATH_);
        }
    }
}