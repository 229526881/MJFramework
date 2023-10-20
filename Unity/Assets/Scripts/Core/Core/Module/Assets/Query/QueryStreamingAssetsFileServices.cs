using UnityEngine;
using YooAsset;

namespace Model
{
    // �����ļ���ѯ������
    public class QueryStreamingAssetsFileServices : IBuildinQueryServices
    {
        public bool QueryStreamingAssets(string packageName, string fileName)
        {
            //NLog.Log.Debug(FileHelper.RelativePath(Application.streamingAssetsPath, $"{buildinFolderName}/{packageName}/{fileName}"));
            //NLog.Log.Debug(Application.streamingAssetsPath);

#if UNITY_WEBGL
            return false;
#else
            // ע�⣺ʹ����BetterStreamingAssets�����ʹ��ǰ��Ҫ��ʼ���ò����
            string buildinFolderName = YooAssets.GetPackage(packageName).GetPackageBuildinRootDirectory();
            return BetterStreamingAssets.FileExists(FileHelper.RelativePath(Application.streamingAssetsPath, $"{buildinFolderName}/{packageName}/{fileName}"));
#endif
        }
    }
}