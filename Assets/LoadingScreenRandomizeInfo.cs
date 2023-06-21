using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Centralize.UI
{
    public class LoadingScreenRandomizeInfo : MonoBehaviour
    {
        [SerializeField] Text InfomationText;
        [SerializeField] bool AllInfoIsRandomize;
        [SerializeField] int StageNumber;
        [SerializeField] string[] MainMenu;
        [SerializeField] string[] Stage1;
        [SerializeField] string[] Stage2;
        [SerializeField] string[] Stage3;
        [SerializeField] string[] Stage4;
        [SerializeField] string[] Stage5;
        [SerializeField] string[] Stage6;
        [SerializeField] string[] Stage7;
        [SerializeField] string[] Stage8;
        [SerializeField] string[] Stage9;
        [SerializeField] string[] Stage10;

        [TextArea(5, 15)] [SerializeField] string[] All;

        public void Start()
        {
            System.Random random = new System.Random();


            if (AllInfoIsRandomize)
			{
                All = All.OrderBy(x => random.Next()).ToArray();
                string randomOption = All[0];
                InfomationText.text = randomOption;
            }

			else { 
                switch (StageNumber)
            {
                case 0:
                    MainMenu = MainMenu.OrderBy(x => random.Next()).ToArray();
                    string randomOption = MainMenu[0];
                    InfomationText.text = randomOption;
                    break;
                case 1:
                    Stage1 = Stage1.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage1[0];
                    InfomationText.text = randomOption;
                    break;
                case 2:
                    Stage2 = Stage2.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage2[0];
                    InfomationText.text = randomOption;
                    break;
                case 3:
                    Stage3 = Stage3.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage3[0];
                    InfomationText.text = randomOption;
                    break;
                case 4:
                    Stage4 = Stage4.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage4[0];
                    InfomationText.text = randomOption;
                    break;
                case 5:
                    Stage5 = Stage5.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage5[0];
                    InfomationText.text = randomOption;
                    break;
                case 6:
                    Stage6 = Stage6.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage6[0];
                    InfomationText.text = randomOption;
                    break;
                case 7:
                    Stage7 = Stage7.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage7[0];
                    InfomationText.text = randomOption;
                    break;
                case 8:
                    Stage8 = Stage8.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage8[0];
                    InfomationText.text = randomOption;
                    break;
                case 9:
                    Stage9 = Stage9.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage9[0];
                    InfomationText.text = randomOption;
                    break;
                case 10:
                    Stage10 = Stage10.OrderBy(x => random.Next()).ToArray();
                    randomOption = Stage10[0];
                    InfomationText.text = randomOption;
                    break;
                default:
                   
                    break;

            }
            }
        }
    }
}
