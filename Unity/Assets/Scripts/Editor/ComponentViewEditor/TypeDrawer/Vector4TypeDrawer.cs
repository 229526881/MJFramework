using System;
using UnityEditor;
using UnityEngine;

[TypeDrawer]
public class Vector4TypeDrawer : ITypeDrawer
{
    public bool HandlesType(Type type)
    {
        return type.FullName == typeof(Vector4).FullName;
    }

    public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target)
    {
        return EditorGUILayout.Vector4Field(memberName, (Vector4)value);
    }
}