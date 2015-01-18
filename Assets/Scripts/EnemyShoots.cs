using UnityEngine;
using System.Collections;

public class EnemyShoots : MonoBehaviour {
	private float reloadTime;
	public float timeToReload;
	public GameObject bulletPrefab;
	private Transform nozzle;
	private Transform turret;
	public float shootingRange;

	void Start () {
		reloadTime = 0;

		Transform[] transforms = this.gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transforms) 
		{
			if(t.gameObject.name == "Turret")
			{
				turret = t;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t;
			}
		}
	
	}

	void Update () {
		reloadTime += Time.deltaTime;
		if(reloadTime >= timeToReload)
		{
			CheckForPlayer();


		}
	
	}
	private void CheckForPlayer()
	{
		Ray myRay = new Ray ();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;

		RaycastHit hitInfo;

		if (Physics.Raycast (myRay, out hitInfo, shootingRange))
		{
			print(hitInfo.collider.gameObject.name);
			string hitObjectName = hitInfo.collider.gameObject.name;

			if(hitObjectName == "Tank")
			{
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
				reloadTime = 0;



			}
		}

	}
}