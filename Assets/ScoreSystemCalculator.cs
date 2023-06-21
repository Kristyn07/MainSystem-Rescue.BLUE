using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreSystemCalculator : MonoBehaviour
{
    public int TotalScoreStage;
    public int GameplayScoreAdustment;//exploration and the area of Level 

    //FirstAidKit;
    [Header("----------First Aid Kit Puzzle----------")]
    [SerializeField] bool HasFirstAidKit;
    public int Score_FirstAidKit;

    [Header("Easy")]
    [SerializeField] bool Easy;
    [SerializeField] int EasyDefaultScorePerTask = 1000;
    [SerializeField] int EasyNumberOfTaskPerStage;

    [Header("Normal")]
    [SerializeField] bool Normal;
    [SerializeField] int NormalDefaultScorePerTask = 1500;
    [SerializeField] int NormalNumberOfTaskPerStage;

    [Header("Hard")]
    [SerializeField] bool Hard; //emergencykit
    [SerializeField] int HardDefaultScorePerTask = 2000 ;
    [SerializeField] int HardNumberOfTaskPerStage;

    [Header("Hard/wFilledTile")]
    [SerializeField] bool wFill_Hard;
    [SerializeField] int wFill_HardDefaultScorePerTask = 2500;
    [SerializeField] int wFill_HardNumberOfTaskPerStage;

    //Bandaging
    [Header("----------Bandaging----------")]
    [SerializeField] bool HasBandaging;
    public int Score_Bandaging;

    [Header("BandagingType")]
    [SerializeField] string[] BandagingTypeName;
    [SerializeField] int[] BandageTypeScore;

    [Header("Hands Off Computation Prep & SquareKnot")]
    [SerializeField] int[] TriangularBandageFoldingAndSquareKnotTotal; // do not touch

    [Header("Preparation")]
    [SerializeField] int CravatFoldDefaultScorePerFold = 100;
    [SerializeField] int[] FoldingCount;

    [Header("ClosingBandage")]
    [SerializeField] int SquareKnotDefault = 200;
    [SerializeField] bool[] HasSquareKnot;

    [Header("----------Fire Extinguisher----------")]
    [SerializeField] bool HasFireExtinguisher;
    public int Score_FireExtinguisher;
    [SerializeField] int FE_DefaultScorePerPASS;//oneoperation
    [SerializeField] int FE_NumberOfTaskPerStage;

    [Header("----------Matching Fire Type Puzzle----------")]
    [SerializeField] bool HasFireType;
    public int Score_FireType;
    [SerializeField] int FT_DefaultScore = 1100;
	[SerializeField] int FT_NumberOfTaskPerStage;

    [Header("----------Drop Cover Hold----------")]
    [SerializeField] bool HasDropCoverHold;
    public int Default_HealthBar;
    public int Score_DropCoverHold;
    [SerializeField] int DCH_DefaultScore = 3000;

    [Header("----------Identify Major Cause of Flood----------")]
    [SerializeField] bool HasMajorCauseOfFlood;
    public int Score_Flood;
    [SerializeField] int F_DefaultScore = 1100;
    [SerializeField] int F_NumberOfTaskPerStage;

    [Header("----------Waste ManageMent----------")]
    [SerializeField] bool HasWasteManagemetMN;
    public int Score_Waste;
    [SerializeField] int W_DefaultScorePerItem = 100;
    [SerializeField] int W_NumberOfWaste;

    [Header("----------Electric Device----------")]
    [SerializeField] bool HasElectricDevice;
    public int Score_Electrical;
    [SerializeField] int E_DefaultScorePerPlug = 100;
    [SerializeField] int E_NumberOfPlugNeeded;


    public void Awake()
	{
        TotalPossibleScoreGain();
    }

	//TotalScore
	public void TotalPossibleScoreGain()
	{
        FirstAidKitPuzzleCalcu();
        BandagingCalcu();
        FireExtinguisherCalcu();
        MatchingFireTypePuzzleCalcu();
        DropCoverHoldSurvivalCalcu();
        IdentifyMajorCauseOfFloodCalcu();
        CleaningWasteManagementCalcu();
        ElectricalDevicesCalcu();
        TotalScoreStage = (GameplayScoreAdustment
            + Score_FirstAidKit
            + Score_Bandaging
            + Score_FireExtinguisher
            + Score_FireType
            + Score_DropCoverHold
            + Score_Flood
            + Score_Waste
            + Score_Electrical);
	}


    //MiniGameCalculators
	public void FirstAidKitPuzzleCalcu()
	{
        if (HasFirstAidKit)
		{
			if (Easy) { Score_FirstAidKit += (EasyDefaultScorePerTask * EasyNumberOfTaskPerStage); }
            if (Normal) { Score_FirstAidKit += (NormalDefaultScorePerTask * NormalNumberOfTaskPerStage); }
            if (Hard) { Score_FirstAidKit += (HardDefaultScorePerTask * HardNumberOfTaskPerStage); }
            if (wFill_Hard) { Score_FirstAidKit += (wFill_HardDefaultScorePerTask * wFill_HardNumberOfTaskPerStage); }
		}
	}
    public void BandagingCalcu()
	{
        if (HasBandaging)
        {
            for (int x = 0; x < BandagingTypeName.Length; x++)
            {
                //Folding   
                TriangularBandageFoldingAndSquareKnotTotal[x] += (CravatFoldDefaultScorePerFold * FoldingCount[x]);
                //closing
                if (HasSquareKnot[x]) {
                    TriangularBandageFoldingAndSquareKnotTotal[x] += SquareKnotDefault; 
                }

                Score_Bandaging += (TriangularBandageFoldingAndSquareKnotTotal[x] + BandageTypeScore[x]);
                //Score_Bandaging += TriangularBandageFoldingTotal[x];
                //SquareKnot
                //if (HasSquareKnot[x]) {   }
                //BandadingType
                //Score_Bandaging += BandageTypeScore[x];

                //total
                //Score_Bandaging += (BandageTypeScore[x] + TriangularBandageFoldingTotal[x] );


            }

        }
	}
    public void FireExtinguisherCalcu()
	{
        if (HasFireExtinguisher)
        {
            Score_FireExtinguisher += (FE_DefaultScorePerPASS * FE_NumberOfTaskPerStage);
        }
	}
    public void MatchingFireTypePuzzleCalcu()
	{
		if (HasFireType)
		{
            Score_FireType += (FT_DefaultScore * FT_NumberOfTaskPerStage);
		}
	}
    public void DropCoverHoldSurvivalCalcu()
	{
        if (HasDropCoverHold)
		{
            Score_DropCoverHold += DCH_DefaultScore;
        }
        
    }
    public void IdentifyMajorCauseOfFloodCalcu()
	{
		if (HasMajorCauseOfFlood)
		{
            Score_Flood += (F_DefaultScore * F_NumberOfTaskPerStage);
        }
	}
    public void CleaningWasteManagementCalcu()
	{
        if (HasWasteManagemetMN)
        {
            Score_Waste += (W_DefaultScorePerItem * W_NumberOfWaste);
        }
    }

    public void ElectricalDevicesCalcu()
	{
        if (HasElectricDevice)
        {
            Score_Electrical += (E_DefaultScorePerPlug * E_NumberOfPlugNeeded);
        }
    }
    
    //add new calcu when a new game is added

}
