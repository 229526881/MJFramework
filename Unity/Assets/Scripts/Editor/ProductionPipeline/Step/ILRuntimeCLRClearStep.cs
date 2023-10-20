using System.IO;

namespace M.ProductionPipeline
{
    public class ILRuntimeCLRClearStep : IStep
    {
        public void Run()
        {
#if ILRuntime
            ILRuntimeCLRBinding.DeleteAllAndGenerateClrBindingByAnalysis();
#endif
        }

        public string EnterText()
        {
            return $"����ILRuntime CLR�� ��ʼ��";
        }

        public string ExitText()
        {
            return $"����ILRuntime CLR�� ������";
        }

        public bool IsTriggerCompile()
        {
            if (Directory.Exists(EditorConst.ILBINDING))
            {
                string[] files = System.IO.Directory.GetFiles(EditorConst.ILBINDING);

                return files.Length > 0;
            }

            return false;
        }
    }
}