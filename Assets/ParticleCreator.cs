using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCreator : MonoBehaviour {

	public ParticleSystem explosionParticleSystem;
	public ParticleSystem energyBlastParticleSystem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayExplosionAt(Vector3 explosionPosition)
	{
		var emitParams = new ParticleSystem.EmitParams
		{
			position = explosionPosition,
			applyShapeToPosition = true
		};
		explosionParticleSystem.Emit(emitParams, 150);
	}

	public void PlayEnergyBlastAt(Vector3 blastPosition)
	{
		var emitParams = new ParticleSystem.EmitParams
		{
			position = blastPosition,
			applyShapeToPosition = true
		};
		energyBlastParticleSystem.Emit(emitParams, 1);
	}
}
