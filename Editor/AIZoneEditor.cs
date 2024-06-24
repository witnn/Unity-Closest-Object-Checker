using UnityEditor;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomEditor(typeof(AIZone))]
    public class AIZoneEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            AIZone aiZone = (AIZone) target;
            aiZone.targetTag = EditorGUILayout.TagField("Target Tag", aiZone.targetTag);
        }
    }
}