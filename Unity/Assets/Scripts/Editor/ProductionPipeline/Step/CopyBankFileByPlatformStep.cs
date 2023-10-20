using Model;
using UnityEditor;

namespace M.ProductionPipeline
{
    public class CopyBankFileByPlatformStep : IStep
    {
        public BuildTargetGroup buildTargetGroup;

        public void Run()
        {
            FileHelper.DelectDir(EditorConst.FMOD_BANKS_PATH);
#if UNITY_WEBGL
#else
        //FileUtil.ReplaceDirectory($"{EditorConst.AUDIO_PATH}{FMODUnity.Settings.Instance.PlayInEditorPlatform.BuildDirectory}/", EditorConst.FMOD_BANKS_PATH);
#endif
        }

        public string EnterText()
        {
            return $"���Ƶ�ǰƽ̨��Bank�ļ� ��ʼ��";
        }

        public string ExitText()
        {
            return $"���Ƶ�ǰƽ̨��Bank�ļ� ������";
        }

        public bool IsTriggerCompile()
        {
            return false;
        }
    }
}