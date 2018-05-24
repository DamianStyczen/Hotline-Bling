using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effects/New empty Effect")]
public class Effect : ScriptableObject {

    public int testint = 0;
	public virtual void Execute()
    {

    }
}
