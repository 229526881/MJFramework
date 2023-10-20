using System;
using UnityEditor;

[TypeDrawer]
public class StringTypeDrawer : ITypeDrawer
{
    public bool HandlesType(Type type)
    {
        return type.FullName == typeof(string).FullName;
    }

    public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target)
    {
        return EditorGUILayout.DelayedTextField(memberName, (string)value);
    }
}