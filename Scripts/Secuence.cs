using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Secuence {

    public float secuenceTime;

    public abstract IEnumerator DoSecuence();
	
}
