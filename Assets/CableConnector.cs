using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stage080910;

public class CableConnector : MonoBehaviour
{
    [Header("GamePlay")]
    public bool ChargeThePhoneMission;
    public bool IsConnected;
    public bool DontApplyDragging;
    [Header("Cable Connected to Phone")]
    
    [SerializeField] BoxCollider2D Phone;

    private Transform transformPosition;
    private BoxCollider2D CableToPhone;
    private Rigidbody2D rigidbody2DConnector;
    [SerializeField] PlugConnection plugConnection;
    [SerializeField] Image cableplug;

    [Header("Centralize Device")]
    [SerializeField] bool DeviceIsATV;
    [SerializeField] TVUIManipulation tvManager;
    

	public void Start()
	{
        CableToPhone = GetComponent<BoxCollider2D>();
        transformPosition = GetComponent<Transform>();
        rigidbody2DConnector = GetComponent<Rigidbody2D>();
        if (DontApplyDragging == true)
		{
            if (DeviceIsATV == true) // start of tv // plug but not on
			{
                if (IsConnected == true)
                {
                    tvManager.OffTV(); // activate the off button
                }
                else
				{
                    tvManager.OnTV(); // activate the on tv
                }

            }
			else
			{
                IsConnected = true;
            }

        }
		else
		{
            if (ChargeThePhoneMission)
            {
                IsConnected = false;
                cableplug.enabled = true;
            }

            else
            {
                IsConnected = true;
                cableplug.enabled = false;
                //CheckIfConnectedToPhone();
                transformPosition.position = Phone.transform.position;
            }
            
            
        }
        

    }

	public void DeviceIsConnectedToElectricity()
    {

        if (CableToPhone.IsTouching(Phone))
        {
            IsConnected = true;
            cableplug.enabled = false;
            SnapConnectortoPhone();
            rigidbody2DConnector.constraints = RigidbodyConstraints2D.FreezePosition;
            plugConnection.DeviceIsConnectedToElectricity();

        }
        else
        {
            IsConnected = false;
            cableplug.enabled = true;
            plugConnection.DeviceIsConnectedToElectricity();
            rigidbody2DConnector.constraints = RigidbodyConstraints2D.None;

        }
    }

    public void SnapConnectortoPhone()
    {
        if (CableToPhone.IsTouching(Phone))
        {
            transformPosition.position = Phone.transform.position;
        }

    }

    public void IsHolding()
    {
        rigidbody2DConnector.constraints = RigidbodyConstraints2D.FreezePosition;

    }

    public void OnButton()
	{
        IsConnected = false;
        plugConnection.DeviceIsConnectedToElectricity();

    }
    public void OffButton()
	{
        IsConnected = true;
        plugConnection.DeviceIsConnectedToElectricity();


    }

}
