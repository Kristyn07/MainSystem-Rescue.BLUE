using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetBandaging : MonoBehaviour
{//stage7 only
	private Animator Anim;
	[SerializeField] Bandage[] bandage;
	[SerializeField] BandageTask bandageTask;
	[Header("NarrowCravat")]
	[SerializeField] CravatNarrowFolding narrowfolding;
	[Header("SquareKNot")]
	[SerializeField] StepByStepBandaging squareKnot;

	[SerializeField] LineRenderer[] renderer;
	private void Start()
	{
		Anim = GetComponent<Animator>();
	}

	public void ResetNarrowFolding()
	{
		Anim.SetBool("Reset", false);
		foreach (Bandage bandaging in bandage)
		{
			bandaging.IsSuccess = false;
		}
		bandageTask.IsTaskCompleted = false;
		narrowfolding.isSuccess = false;
		RendererManipulataion();
	}

	public void ResetSquareKnot()
	{
		Anim.SetBool("Reset", false);
		foreach (Bandage bandaging in bandage)
		{
			bandaging.IsSuccess = false;
		}
		bandageTask.IsTaskCompleted = false;
		squareKnot.isSuccess = false;
		RendererManipulataion();
	}

	public void RendererManipulataion()
	{
		foreach (LineRenderer render in renderer)
		{
			render.positionCount = 2;

			// Set the positions of the LineRenderer
			render.SetPosition(0, new Vector3(0, 0, 0));
			render.SetPosition(1, new Vector3(1, 1, 1));
		}

		/*foreach (Bandage bandaging in bandage)
		{
			bandaging.IsSuccess = false;
		}*/
	}

	public void SquareknotDefaultBandagestep()
	{
		squareKnot.StepCounts = 0;
		squareKnot.BandageStep = 8;
		squareKnot.OffStep();
		Anim.SetBool("Reset", true);
		ResetSquareKnot();
		
	}

	public void NarrowDefaultBandagestep()
	{
		narrowfolding.BandageStep = 3;
		narrowfolding.StepCounts = 0;
		narrowfolding.OffStepNarrow();
		Anim.SetBool("Reset", true);
		ResetNarrowFolding();
	}
}