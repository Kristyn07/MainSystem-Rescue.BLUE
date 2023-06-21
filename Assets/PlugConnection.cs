using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Stage080910
{
    public class PlugConnection : MonoBehaviour
    {
        public bool ChargeThePhoneMission;
        [Header("Sockets Collider")]
        [SerializeField] List<BoxCollider2D> sockets;
        [SerializeField] BoxCollider2D Socket1;
        [SerializeField] BoxCollider2D Socket2;
        [SerializeField] BoxCollider2D Socket3;
        [SerializeField] BoxCollider2D Socket;

        [Header("UI Manipulataion")]
        public bool IsPlugged;
        [SerializeField] Image ChargingImage;
        [SerializeField] Color ChargingColor;
        [SerializeField] Color NotChargingColor;
        [SerializeField] BoxCollider2D Table;
        [SerializeField] Image ChargerPlug;
        
        [Header("Plug")]
        private Transform transformPosition;
        private BoxCollider2D boxCollider;
        private Rigidbody2D rigidbodyPlug;


        [SerializeField] CableConnector cable;

        [Header("Centralize Device")] 
        public bool IsElectricFan;
        [SerializeField] ElectricFanUIManipulation electricFanManger;
        public bool IsATV;
        [SerializeField] TVUIManipulation tVManager;

        [Header("OverWorldManipulation")]
        [SerializeField]bool phoneTask;
        [SerializeField] Overworld_ChargeThePhone phone;

        



        public void Start()
		{
            boxCollider = GetComponent<BoxCollider2D>();
            transformPosition = GetComponent<Transform>();
            rigidbodyPlug = GetComponent<Rigidbody2D>();
            DeviceIsConnectedToElectricity();
            if (ChargeThePhoneMission)
            {

            }
            else
            {
                if (IsPlugged)
                {
                    Snap();
                    //PhoneIsChargingIndication();
                }
                else
                {
                    // randomly select a socket and snap to its position
                    if (sockets.Count > 0)
                    {
                        int randomIndex = Random.Range(0, sockets.Count);
                        BoxCollider2D randomSocket = sockets[randomIndex];
                        transformPosition.position = randomSocket.transform.position;
                        IsPlugged = true;
                        DeviceIsConnectedToElectricity();
                        ChargerPlug.enabled = false;
                        //rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
                        rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePosition;
                        //PhoneIsChargingIndication();
                    }
                }
            }
            
        }
		public void CheckIfPlugged()
		{
            

            if (boxCollider.IsTouching(Socket1) || boxCollider.IsTouching(Socket2) || boxCollider.IsTouching(Socket3))
            {
                IsPlugged = true;
                rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePosition;
                ChargerPlug.enabled = false;
                Snap();
                DeviceIsConnectedToElectricity();
            }
            else
            {
                IsPlugged = false;
                ChargerPlug.enabled = true;
                rigidbodyPlug.constraints = RigidbodyConstraints2D.None;
                DeviceIsConnectedToElectricity();
            }
        }

        public void Snap()
		{
            if (boxCollider.IsTouching(Socket1))
            {
                transformPosition.position = Socket1.transform.position;
            }
            else if (boxCollider.IsTouching(Socket2))
            {
                transformPosition.position = Socket2.transform.position;
            }
            else if (boxCollider.IsTouching(Socket3))
            {
                transformPosition.position = Socket3.transform.position;
            }
        }

        public void DeviceIsConnectedToElectricity() // device is connected to electricity 
		{
            if (IsPlugged == true && cable.IsConnected == true) 
            {
                ChargingImage.color = ChargingColor;

                if (IsElectricFan) { electricFanManger.ElectricFanisOn(); }
                if (IsATV == true) { tVManager.OffTV(); }
                if (phoneTask) { phone.PhoneIsCharge(); }
            }
            
            else
			{
                ChargingImage.color = NotChargingColor;
                if (IsElectricFan) { electricFanManger.ElectricFanisOff(); }
                if (IsATV == true) { tVManager.OnTV(); }
                if (phoneTask) { phone.PhoneIsNotCharge(); }
            }
		}

        public void CheckIfOnTable()
		{
            if (boxCollider.IsTouching(Table))
            {
                rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePosition;
            }
			else
			{
                rigidbodyPlug.constraints = RigidbodyConstraints2D.None;
            }

        }



        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            BoxCollider2D otherBoxCollider = otherCollider.GetComponent<BoxCollider2D>();
            //Debug.Log(" has entered the trigger!");

            if (otherBoxCollider == Table)
            {
                // Compare the bounds of the UI Image and the other collider
                if (boxCollider.bounds.Intersects(otherBoxCollider.bounds))
                {
                    rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
        }

        public void IsHolding()
		{
           rigidbodyPlug.constraints = RigidbodyConstraints2D.FreezePosition;

        }

        public void IsNotHolding()
        {
            if (IsPlugged)
			{
                rigidbodyPlug.gravityScale = 0;
                rigidbodyPlug.constraints = RigidbodyConstraints2D.None;
            }
			else
			{
                rigidbodyPlug.gravityScale = 50;
            }
        }



    }
}
