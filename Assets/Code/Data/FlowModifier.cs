using UnityEngine;

[CreateAssetMenu(fileName = "new FlowModifier", menuName = "GJ/Game/Flow Modifier")]
public class FlowModifier : ScriptableObject 
{
    [SerializeField] private bool performed = true;
    public bool Performed
    {
        get { return performed; }
        set { performed = value; }
    }
    
}