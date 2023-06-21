using UnityEngine;
using UnityEngine.EventSystems;
namespace Stage080910
{
    public class DragrabbleElement : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private Vector2 offset;
        private RectTransform rectTransform;
        private Canvas canvas;
        [SerializeField] PlugConnection plugConnection;
        [SerializeField] CableConnector cableConnector;
        [SerializeField] bool isDragging;
        [SerializeField] bool PlugObj;

        
        //plug the device
        [Header("2plug")]
        [SerializeField] bool TaskIsChargingPhone;
        [SerializeField] TaskCompleteCargingPhone TaskChargePHone;
        //unplug
        [Header("1plug")]
        [SerializeField] TaskCompletePlugOnly TaskUnplug;
        public void Start()
		{
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
        }
		public void OnDrag(PointerEventData eventData)
        {
            // transform.position = eventData.position + offset;
            isDragging = true;
            if (isDragging == true)
			{
                if (PlugObj) { plugConnection.IsHolding(); }
                else
                {
                    cableConnector.IsHolding();
                }
            }
            
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //transform.position = eventData.position + offset;
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            //plugConnection.PhoneIsChargingIndication();
            isDragging = false;

            if (isDragging == false)
			{
                if (PlugObj)
				{
                    plugConnection.CheckIfOnTable();
                    //plugConnection.IsNotHolding();
                    plugConnection.CheckIfPlugged();
                }
				else
				{
                    cableConnector.DeviceIsConnectedToElectricity();
                }
			}

            //gameplay
            if (TaskIsChargingPhone)
			{
                TaskChargePHone.checkTask();
            }
			else if (!TaskIsChargingPhone)
			{
                TaskUnplug.checkTask();
			}
        }

        /*public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerId == -1) // touch input
            {
                offset = transform.position - new Vector3(eventData.position.x, eventData.position.y, transform.position.z);
                //plugConnection.CheckIfPlugged();

            }
            else // mouse input
            {
                offset = transform.position - new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
                //plugConnection.CheckIfPlugged();
               
            }
        }*/

        


    }
}
