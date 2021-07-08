using UnityEngine;
using System.Collections;

public class FlowHandler : MonoBehaviour 
{
	public FlowModifier flowModifier;
	public IntVariable timeToReasign;

	public void PerformAModifier()
	{
		flowModifier.Performed = !flowModifier.Performed;
		StartCoroutine(Reasign());
	}

	private IEnumerator Reasign()
	{
		yield return new WaitForSeconds(timeToReasign.CurrentValue);
		flowModifier.Performed = !flowModifier.Performed;
	}
}