﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowtrailController : MonoBehaviour {

	[SerializeField] private GameObject flowTrailPrefab = null;
	private List<Flowtrail> flowTrails = new List<Flowtrail>();
	[Range(1, 50)] [SerializeField] private int trailCount = 5;

	[Range(0.05f, 0.5f)] [SerializeField] private float trailWidth = 0.2f; public float TrailWidth { get { return trailWidth; } }
	[Range(0.02f, 1f)] [SerializeField] private float trailSpeed = 0.1f; public float TrailSpeed { get { return trailSpeed; } }
	[Range(0.1f, 1f)] [SerializeField] private float trailOrbitDist = 0.5f; public float TrailOrbitDist { get { return trailOrbitDist; } }


	
	private void Update() {
		while(flowTrails.Count < trailCount){
			Flowtrail newFlowtrail = Instantiate(flowTrailPrefab).GetComponent<Flowtrail>();
			flowTrails.Add(newFlowtrail);
			newFlowtrail.AssignToController(this);
		}

		while(flowTrails.Count > trailCount){
			int removeIndex = Random.Range(0, flowTrails.Count);
			Destroy(flowTrails[removeIndex]);
			flowTrails.RemoveAt(removeIndex);
		}
	} // End of Update().

} // End of FlowlineController.
