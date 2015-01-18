using UnityEngine;
using System.Collections;

public class BaseRotateTurret : MonoBehaviour {

	private Transform[] transforms;
	protected Transform turret;
	protected Transform nozzle;
	protected Vector3 targetPos;

	protected virtual void Start () {

		bool turretFound = false;

		transforms = gameObject.GetComponentsInChildren<Transform> ();
		foreach(Transform t in transforms)
		{
			if(t.gameObject.name == "Turret")
			{
				turret = t;
				turretFound = true;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t;
			}
		}
		if (!turretFound) {
			print("No turret was found in the gameobject");
				}
	}

	protected virtual void Update () {
		turret.LookAt (targetPos);
	
	}
}
