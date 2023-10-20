namespace M.ProductionPipeline
{
    public class ILRuntimeCLRBindingStep : IStep
    {
        public void Run()
        {
#if ILRuntime
            ILRuntimeCLRBinding.GenerateClrBindingByAnalysis();
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
            return false;
        }
    }
}