using YooAsset;

namespace Model
{
    // Զ���ļ���ѯ������
    public class QueryHostServerFileServices : IRemoteServices
    {
        public string GetRemoteMainURL(string fileName)
        {
            return $"{Game.Instance.Scene.GetComponent<AssetsComponent>().HostServerURL}/{fileName}";
        }

        public string GetRemoteFallbackURL(string fileName)
        {
            return $"{Game.Instance.Scene.GetComponent<AssetsComponent>().HostServerURL}/{fileName}";
        }
    }
}