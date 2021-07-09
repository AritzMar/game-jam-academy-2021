using UnityEngine;

internal interface IHiteable
{
	public void Hit(int damage, Vector3 position);
}