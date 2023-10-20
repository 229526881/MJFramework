using Sirenix.OdinInspector;
using UnityEngine;

namespace Model
{
    public class InputManager : MonoBehaviour
    {
        public enum InputForcedModes
        {
            None,
            Mobile,
            Desktop
        }

        /// the possible kinds of control used for movement
        public enum MovementControls
        {
            Joystick,
            Arrows
        }

        [Tooltip("�����ѡ���Զ��ƶ���⣬�����Ĺ���Ŀ���� Android �� iOS ʱ�����潫�Զ��л����ƶ��ؼ��� ��������ʹ������������˵�ǿ���ƶ������棨���̡���Ϸ�ֱ����ؼ���\n" + "��ע�⣬���������Ҫ�ƶ��ؼ���/�� GUI�������Ҳ���Ե���������ֻ�轫����ڿյ� GameObject �� .")]
        public bool AutoMobileDetection = true;

        [Tooltip("ʹ������ǿ�����棨���̡����̣����ƶ���������ģʽ")]
        public InputForcedModes InputForcedMode;

        [Tooltip("���������ģ��ƶ��ؼ����ڱ༭��ģʽ�����أ����۵�ǰ����Ŀ�껹��ǿ��ģʽ")]
        public bool HideMobileControlsInEditor = false;

        [LabelText("ҡ����ʽ")]
        public MovementControls MovementControl = MovementControls.Joystick;
    }
}