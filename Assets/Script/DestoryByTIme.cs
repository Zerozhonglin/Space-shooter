using System.Collections;
using UnityEngine;
using  System.Collections.Generic;  

public class DestoryByTime : MonoBehaviour {
	public float lifetime;
	void Start(){
		DestroyObject (gameObject, lifetime);
	}
}