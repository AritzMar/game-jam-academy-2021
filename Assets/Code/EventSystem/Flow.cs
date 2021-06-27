using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new Flow", menuName = "GJ/Game/Flow")]
public class Flow : ScriptableObject 
{
    [SerializeField] private FlowModifier[] flowModifiers;
    
    public FlowModifier GetFlowModifierByName(string name)
    {
        FlowModifier modifier = Array.Find(flowModifiers, f => f.name == name);
        if(modifier != null)
            return modifier;
        else
            return null;
    }
}