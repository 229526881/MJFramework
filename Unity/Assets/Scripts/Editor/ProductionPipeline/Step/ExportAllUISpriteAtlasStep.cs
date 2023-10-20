using UnityEditor;

namespace M.ProductionPipeline
{
    public class ExportAllUISpriteAtlasStep : IStep
    {
        public void Run()
        {
            SpriteAtlasEditor.ExportAllUISpriteAtlas(EditorConst.UI_SPRITE_ATLAS_SETTINGS);
            SpriteAtlasEditor.ExportAllUISpriteAtlas(EditorConst.UNIT_SPRITE_ATLAS_SETTINGS);
        }

        public string EnterText()
        {
            return $"��������UIͼ�� ��ʼ��";
        }

        public string ExitText()
        {
            return $"��������UIͼ�� ������";
        }

        public bool IsTriggerCompile()
        {
            return false;
        }
    }
}