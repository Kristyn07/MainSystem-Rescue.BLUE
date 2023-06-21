using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSpecification : MonoBehaviour
{
    [SerializeField] bool ForFood;
    [SerializeField] bool ForWater;
    [SerializeField] bool ForLight;

    [SerializeField] int AddValue;
    
    [SerializeField] float MAxValue;
    [SerializeField] float CurrentValue;
    [SerializeField] TyphoonGamePlayStage09 typhoonGamePlayStage;
    [SerializeField] GameObject BusyConsumingStuff;
    [SerializeField] Text Message;
    [SerializeField] Slider thisSlider;
    

    private Image thisImage;
    private string message;
	public void Start()
	{
        thisImage = GetComponent<Image>();
        if (ForFood)
        {
            this.thisSlider = typhoonGamePlayStage.FoodSlider;
            CurrentValue = typhoonGamePlayStage.F_Timer;
            MAxValue = typhoonGamePlayStage.F_MaxTimer;
            message = "busy consuming food...";
        }
        if (ForWater)
        {
            CurrentValue = typhoonGamePlayStage.W_Timer;
            this.thisSlider = typhoonGamePlayStage.WaterSlider;
            MAxValue = typhoonGamePlayStage.W_MaxTimer;
            message = "Drinking water...";
            
        }
        if (ForLight)
        {
            CurrentValue = typhoonGamePlayStage.L_Timer;
            this.thisSlider = typhoonGamePlayStage.LightSlider;
            MAxValue = typhoonGamePlayStage.L_MaxTimer;
            message = "Adding battery life to flashlight";
        }
    }


    public void BTNAddValue()
    {
        BusyConsumingStuff.SetActive(true);

        if ((MAxValue - (thisSlider.value * MAxValue)) >= AddValue)
        {
            //thisSlider.value += AddValue / MAxValue;
            Debug.Log("a");



            if (ForFood)
            {
                typhoonGamePlayStage.F_Timer += AddValue;
            }
            if (ForWater)
            {
                typhoonGamePlayStage.W_Timer += AddValue;
            }
            if (ForLight)
            {
                typhoonGamePlayStage.L_Timer += AddValue;
            }
        }
        else if ((MAxValue - (thisSlider.value * MAxValue)) < AddValue)
        {

            Debug.Log("b");
            if (ForFood)
            {
                typhoonGamePlayStage.F_Timer = typhoonGamePlayStage.F_MaxTimer;
            }
            if (ForWater)
            {
                typhoonGamePlayStage.W_Timer = typhoonGamePlayStage.W_MaxTimer;
            }
            if (ForLight)
            {
                typhoonGamePlayStage.L_Timer = typhoonGamePlayStage.L_MaxTimer;
            }
        }





        Message.text = message;
        gameObject.transform.SetParent(BusyConsumingStuff.transform);
        gameObject.transform.SetAsFirstSibling();



        RectTransform rectTransform = thisImage.rectTransform;
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;


        //gameObject.GetComponent<RectTransform>().anchoredPosition = centerPosition;

        thisImage.SetNativeSize();
        StartCoroutine(DothisWhenDone());
    }

    IEnumerator DothisWhenDone()
	{   
        Destroy(gameObject, 5f);
        yield return new WaitForSeconds(4.9f);
        BusyConsumingStuff.SetActive(false);
        

    }
}
