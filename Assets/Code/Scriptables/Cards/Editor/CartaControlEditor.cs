using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CartaControl))]
public class CartaControlEditor : Editor
{
	SerializedProperty playerContainer;
	SerializedProperty bossContainer;
	SerializedProperty turnTime;

	private void OnEnable()
	{
		playerContainer = serializedObject.FindProperty("playerContainer");
		bossContainer = serializedObject.FindProperty("bossContainer");
		turnTime = serializedObject.FindProperty("turnTime");
	}

	public override void OnInspectorGUI()
	{
		CartaControl card = (CartaControl)target;
		
		serializedObject.Update();
		
		EditorGUILayout.PropertyField(playerContainer);
		EditorGUILayout.PropertyField(bossContainer);
		
		card.ControlType = (ControlType)EditorGUILayout.EnumPopup("ControlType", card.ControlType);
		
		if (card.ControlType == ControlType.AddTime)
			EditorGUILayout.PropertyField(turnTime);

		serializedObject.ApplyModifiedProperties();
		EditorUtility.SetDirty(card);

	}
}