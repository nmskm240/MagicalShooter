using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemySpawnBehaviour))]
public class EnemySpawnDrawer : PropertyDrawer
{
    public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
    {
        int fieldCount = 1;
        return fieldCount * EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty enemyProp = property.FindPropertyRelative("Enemy");

        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(singleFieldRect, enemyProp);
    }
}
