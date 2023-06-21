using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessagesGamePlay : MonoBehaviour
{
    [Header("PopUpLayout")]
    [SerializeField] GameObject MainLayoutPopUpMessage;

    [Header("PauseMenu")]
    [SerializeField] GameObject PauseMiniGamePopUpLayout;
    [Tooltip("***Reply")]
    [SerializeField] GameObject ReplyConfirmation;
    [Tooltip("***MainMenu")]
    [SerializeField] GameObject MainMenuConfirmation;

    [Header("WinCondition")]
    [SerializeField] GameObject WinConditionPopUpLayout;
    [Tooltip("***Reply")]
    [SerializeField] GameObject W_ReplyConfirmation;
    [Tooltip("***MainMenu")]
    [SerializeField] GameObject W_MainMenuConfirmation;
    [Tooltip("***ExitGame")]
    [SerializeField] GameObject W_ExitGameConfirmation;

    [Header("LoseCondition")]
    [SerializeField] GameObject LoseConditionPopUpLayout;
    /*[Tooltip("***Reply")]
    [SerializeField] GameObject L_ReplyConfirmation;*/
    [Tooltip("***MainMenu")]
    [SerializeField] GameObject L_MainMenuConfirmation;
    [Tooltip("***ExitGame")]
    [SerializeField] GameObject L_ExitGameConfirmation;





    //PauseMenuReply
    public void P_Reply_PopUpMessage()
	{
        MainLayoutPopUpMessage.SetActive(true);
        PauseMiniGamePopUpLayout.SetActive(true);
        ReplyConfirmation.SetActive(true);
	}

    public void P_Back_Reply_PopUpMessage()
	{
        MainLayoutPopUpMessage.SetActive(false);
        PauseMiniGamePopUpLayout.SetActive(false);
        ReplyConfirmation.SetActive(false);
    }

    public void P_MainMenu_PopUpMessage()
	{
        MainLayoutPopUpMessage.SetActive(true);
        PauseMiniGamePopUpLayout.SetActive(true);
        MainMenuConfirmation.SetActive(true);
    }

    public void P_Back_MainMenu_PopUpMessage()
	{
        MainLayoutPopUpMessage.SetActive(false);
        PauseMiniGamePopUpLayout.SetActive(false);
        MainMenuConfirmation.SetActive(false);
    }

    //WinCondition
    public void W_Reply_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(true);
        WinConditionPopUpLayout.SetActive(true);
        W_ReplyConfirmation.SetActive(true);
    }

    public void W_Back_Reply_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(false);
        WinConditionPopUpLayout.SetActive(false);
        W_ReplyConfirmation.SetActive(false);
    }

    public void W_MainMenu_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(true);
        WinConditionPopUpLayout.SetActive(true);
        W_MainMenuConfirmation.SetActive(true);
    }

    public void W_Back_MainMenu_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(false);
        WinConditionPopUpLayout.SetActive(false);
        W_MainMenuConfirmation.SetActive(false);
    }

    public void W_ExitGame_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(true);
        WinConditionPopUpLayout.SetActive(true);
        W_ExitGameConfirmation.SetActive(true);
    }

    public void W_Back_ExitGame_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(false);
        WinConditionPopUpLayout.SetActive(false);
        W_ExitGameConfirmation.SetActive(false);
    }

    //LoseCondition

    

    public void L_MainMenu_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(true);
        LoseConditionPopUpLayout.SetActive(true);
        L_MainMenuConfirmation.SetActive(true);
    }

    public void L_Back_MainMenu_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(false);
        LoseConditionPopUpLayout.SetActive(false);
        L_MainMenuConfirmation.SetActive(false);
    }

    public void L_ExitGame_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(true);
        LoseConditionPopUpLayout.SetActive(true);
        L_ExitGameConfirmation.SetActive(true);
    }

    public void L_Back_ExitGame_PopUpMessage()
    {
        MainLayoutPopUpMessage.SetActive(false);
        LoseConditionPopUpLayout.SetActive(false);
        L_ExitGameConfirmation.SetActive(false);
    }
}
