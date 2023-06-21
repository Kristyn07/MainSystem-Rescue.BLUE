using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateObjectiveFirstAidKit : MonoBehaviour
{

    [Header("FirstTask_FirstAidKitAssembly")]
    [SerializeField] private float LowerAlpha = 0.5f ;
    [SerializeField] private float MaxAlpha = 1f ;
    [Tooltip("TMPro content that will display the first item needed")]
    public TMPro.TextMeshProUGUI[] ItemName;
    [Tooltip("TMPro Count Item Piece")]
    public TMPro.TextMeshProUGUI[] ItemCount;
    [Tooltip("TMPro Count Item Piece")]
    public TMPro.TextMeshProUGUI[] QuotaCount;
    [Tooltip("TMPro Count Item Piece")]
    public TMPro.TextMeshProUGUI[] ItemDivider;


    [Header("Call Other Scripts")]
    [SerializeField] GridArray itemsCountSource;
    [SerializeField] ObjectivesFirstAid quotaReqs;

    [Header("Update List")]
    public List<int> itemsCount;
    public List<int> quotas;
    public List<int> quotasTag;
    public List<int> objectiveRequirements;

    void Start()
    {
            for (int i = 0; i < quotaReqs.objectiveCounts.Count; i++)
        {
            if (quotaReqs.objectiveCounts[i] != 0)
            {
                quotas.Add(quotaReqs.objectiveCounts[i]);
                quotasTag.Add(i);
                Debug.Log("Item needed: 0 / " + quotaReqs.objectiveCounts[i] / 4);
            }
            else
            {

            }
        }
            foreach(int i in quotas)
        {
            itemsCount.Add(0);
            objectiveRequirements.Add(0);
        }
    }

	
	public void Checker()
    {
        for (int i = 0; i < itemsCountSource.slots.colliders.Count; i++)
        {
            GridFillerColliders colli = itemsCountSource.slots.colliders[i];
            if (colli.isFilled == true)
            {
                for (int x = 0; x < quotasTag.Count; x++)
                {
                    if ((colli.fillID - 1) == quotasTag[x])
                    {
                        itemsCount[x]++;
                    }
                }
            }
        }
        for (int i = 0; i < itemsCount.Count; i++)
        {
            if (itemsCount[i] >= quotas[i]) // complete requirement
            {
                switch (quotasTag[i])
                {
                    case 0:
                        //Debug.Log("Item requirements completed (Alcohol): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[0].text = (itemsCount[i] / 4).ToString();
                        ItemCount[0].alpha = LowerAlpha;
                        ItemName[0].alpha= LowerAlpha;
                        ItemDivider[0].alpha = LowerAlpha;
                        QuotaCount[0].alpha = LowerAlpha;
                        break;
					case 1:
                        //Debug.Log("Item requirements completed (Bandaid & Whistle): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[1].text = (itemsCount[i] / 4).ToString();
                        ItemCount[1].alpha = LowerAlpha;
                        ItemName[1].alpha = LowerAlpha;
                        ItemDivider[1].alpha = LowerAlpha;
                        QuotaCount[1].alpha = LowerAlpha;
                        break;
                    case 2:
                        //Debug.Log("Item requirements completed (Gauze): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[2].text = (itemsCount[i] / 4).ToString();
                        ItemCount[2].alpha = LowerAlpha;
                        ItemName[2].alpha = LowerAlpha;
                        ItemDivider[2].alpha = LowerAlpha;
                        QuotaCount[2].alpha = LowerAlpha;
                        break;
                    case 3:
                        //Debug.Log("Item requirements completed (Medicine): " + itemsCount[i] + " / " + quotas[i]);
                        ItemCount[3].text = (itemsCount[i]).ToString();
                        ItemCount[3].alpha = LowerAlpha;
                        ItemName[3].alpha = LowerAlpha;
                        ItemDivider[3].alpha = LowerAlpha;
                        QuotaCount[3].alpha = LowerAlpha;
                        break;
                    case 4:
                        //Debug.Log("Item requirements completed (Scissors): " + itemsCount[i] / 5 + " / " + quotas[i] / 5);
                        ItemCount[4].text = (itemsCount[i] / 5).ToString();
                        ItemCount[4].alpha = LowerAlpha;
                        ItemName[4].alpha = LowerAlpha;
                        ItemDivider[4].alpha = LowerAlpha;
                        QuotaCount[4].alpha = LowerAlpha;
                        break;
                    case 5:
                        //Debug.Log("Item requirements completed (Thermometer): " + itemsCount[i] / 3 + " / " + quotas[i] / 3);
                        ItemCount[5].text = (itemsCount[i] / 3).ToString();
                        ItemCount[5].alpha = LowerAlpha;
                        ItemName[5].alpha = LowerAlpha;
                        ItemDivider[5].alpha = LowerAlpha;
                        QuotaCount[5].alpha = LowerAlpha;
                        break;
                    case 6:
                        //Debug.Log("Item requirements completed (Triangular Bandage): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[6].text = (itemsCount[i] / 4).ToString();
                        ItemCount[6].alpha = LowerAlpha;
                        ItemName[6].alpha = LowerAlpha;
                        ItemDivider[6].alpha = LowerAlpha;
                        QuotaCount[6].alpha = LowerAlpha;
                        break;
                        //new
                    case 7:
                        ItemCount[7].text = (itemsCount[i] / 8).ToString();
                        ItemCount[7].alpha = LowerAlpha;
                        ItemName[7].alpha = LowerAlpha;
                        ItemDivider[7].alpha = LowerAlpha;
                        QuotaCount[7].alpha = LowerAlpha;
                        break;
                    case 8:
                        ItemCount[8].text = (itemsCount[i] / 8).ToString();
                        ItemCount[8].alpha = LowerAlpha;
                        ItemName[8].alpha = LowerAlpha;
                        ItemDivider[8].alpha = LowerAlpha;
                        QuotaCount[8].alpha = LowerAlpha;
                        break;
                    case 9:
                        ItemCount[9].text = (itemsCount[i] / 9).ToString();
                        ItemCount[9].alpha = LowerAlpha;
                        ItemName[9].alpha = LowerAlpha;
                        ItemDivider[9].alpha = LowerAlpha;
                        QuotaCount[9].alpha = LowerAlpha;
                        break;
                    case 10:
                        ItemCount[10].text = (itemsCount[i] / 12).ToString();
                        ItemCount[10].alpha = LowerAlpha;
                        ItemName[10].alpha = LowerAlpha;
                        ItemDivider[10].alpha = LowerAlpha;
                        QuotaCount[10].alpha = LowerAlpha;
                        break;
                    case 11:
                        ItemCount[11].text = (itemsCount[i] / 4).ToString();
                        ItemCount[11].alpha = LowerAlpha;
                        ItemName[11].alpha = LowerAlpha;
                        ItemDivider[11].alpha = LowerAlpha;
                        QuotaCount[11].alpha = LowerAlpha;
                        break;
                    
                }
            }
            else if (itemsCount[i] <= quotas[i]) // not complete
            {
                
                switch (quotasTag[i])
                {
                    case 0:
                        //Debug.Log("Item requirements update (Alcohol): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[0].text = (itemsCount[i] / 4).ToString();
                        ItemCount[0].alpha = MaxAlpha;
                        ItemName[0].alpha = MaxAlpha;
                        ItemDivider[0].alpha = MaxAlpha;
                        QuotaCount[0].alpha = MaxAlpha;
                        break;
                    case 1:
                        //Debug.Log("Item requirements update (Bandaid & Whistle): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[1].text = (itemsCount[i] / 4).ToString();
                        ItemCount[1].alpha = MaxAlpha;
                        ItemName[1].alpha = MaxAlpha;
                        ItemDivider[1].alpha = MaxAlpha;
                        QuotaCount[1].alpha = MaxAlpha;
                        break;
                        
                    case 2:
                        //Debug.Log("Item requirements update (Gauze): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[2].text = (itemsCount[i] / 4).ToString();
                        ItemCount[2].alpha = MaxAlpha;
                        ItemName[2].alpha = MaxAlpha;
                        ItemDivider[2].alpha = MaxAlpha;
                        QuotaCount[2].alpha = MaxAlpha;
                        break;
                        
                    case 3:
                        //Debug.Log("Item requirements update (Medicine): " + itemsCount[i] + " / " + quotas[i]);
                        ItemCount[3].text = (itemsCount[i]).ToString();
                        ItemCount[3].alpha = MaxAlpha;
                        ItemName[3].alpha = MaxAlpha;
                        ItemDivider[3].alpha = MaxAlpha;
                        QuotaCount[3].alpha = MaxAlpha;
                        break;
                    case 4:
                        //Debug.Log("Item requirements update (Scissors): " + itemsCount[i] / 5 + " / " + quotas[i] / 5);
                        ItemCount[4].text = (itemsCount[i] / 5).ToString();
                        ItemCount[4].alpha = MaxAlpha;
                        ItemName[4].alpha = MaxAlpha;
                        ItemDivider[4].alpha = MaxAlpha;
                        QuotaCount[4].alpha = MaxAlpha;
                        break;
                    case 5:
                        //Debug.Log("Item requirements update (Thermometer): " + itemsCount[i] / 3 + " / " + quotas[i] / 3);
                        ItemCount[5].text = (itemsCount[i] / 3).ToString();
                        ItemCount[5].alpha = MaxAlpha;
                        ItemName[5].alpha = MaxAlpha;
                        ItemDivider[5].alpha = MaxAlpha;
                        QuotaCount[5].alpha = MaxAlpha;
                        break;
                    case 6:
                        //Debug.Log("Item requirements update (Triangular Bandage): " + itemsCount[i] / 4 + " / " + quotas[i] / 4);
                        ItemCount[6].text = (itemsCount[i] / 4).ToString();
                        ItemCount[6].alpha = MaxAlpha;
                        ItemName[6].alpha = MaxAlpha;
                        ItemDivider[6].alpha = MaxAlpha;
                        QuotaCount[6].alpha = MaxAlpha;
                        break;
                    //new
                    case 7:
                        ItemCount[7].text = (itemsCount[i] / 8).ToString();
                        ItemCount[7].alpha = MaxAlpha;
                        ItemName[7].alpha = MaxAlpha;
                        ItemDivider[7].alpha = MaxAlpha;
                        QuotaCount[7].alpha = MaxAlpha;
                        break;
                    case 8:
                        ItemCount[8].text = (itemsCount[i] / 8).ToString();
                        ItemCount[8].alpha = MaxAlpha;
                        ItemName[8].alpha = MaxAlpha;
                        ItemDivider[8].alpha = MaxAlpha;
                        QuotaCount[8].alpha = MaxAlpha;
                        break;
                    case 9:
                        ItemCount[9].text = (itemsCount[i] / 9).ToString();
                        ItemCount[9].alpha = MaxAlpha;
                        ItemName[9].alpha = MaxAlpha;
                        ItemDivider[9].alpha = MaxAlpha;
                        QuotaCount[9].alpha = MaxAlpha;
                        break;
                    case 10:
                        ItemCount[10].text = (itemsCount[i] / 12).ToString();
                        ItemCount[10].alpha = MaxAlpha;
                        ItemName[10].alpha = MaxAlpha;
                        ItemDivider[10].alpha = MaxAlpha;
                        QuotaCount[10].alpha = MaxAlpha;
                        break;
                    case 11:
                        ItemCount[11].text = (itemsCount[i] / 4).ToString();
                        ItemCount[11].alpha = MaxAlpha;
                        ItemName[11].alpha = MaxAlpha;
                        ItemDivider[11].alpha = MaxAlpha;
                        QuotaCount[11].alpha = MaxAlpha;
                        break;
                }
            }
            else
            {
                
            }
        }
    }
    public void Reset()
    {
        for (int i = 0; i < itemsCount.Count; i++)
        { 
            itemsCount[i] = 0;
        }
    }


  
}

