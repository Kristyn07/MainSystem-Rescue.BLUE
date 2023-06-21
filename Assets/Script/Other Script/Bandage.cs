using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bandage : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public bool IsLeftWire;
    public Color CustomColor;

    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas;
    private bool _isDragStarted = false;
    private BandageTask _wireTask;
    public bool IsSuccess = false;


    // 1 Finger Function
    [SerializeField] Vector2 touchPosition;
    // 2 Finger Function
    [SerializeField] bool NeedTwoFinger;
    [SerializeField] Vector2 touchPosition1;
    [SerializeField] Vector2 touchPosition2;



    public GameObject Bandage1;
    public GameObject Bandage2;

    public Bandage Bandage1Script;
    public Bandage Bandage2Script;

    [SerializeField] LineRenderer _1lineRenderer;
    [SerializeField] LineRenderer _2lineRenderer;



    public void Initialize()
    {
        _wireTask = GetComponentInParent<BandageTask>();
       
        _canvas = GetComponentInParent<Canvas>();

        if (NeedTwoFinger)
		{
            _1lineRenderer = Bandage1.GetComponent<LineRenderer>();
            _2lineRenderer = Bandage2.GetComponent<LineRenderer>();

        }
		
        _lineRenderer = GetComponent<LineRenderer>();
        _image = GetComponent<Image>();
        //else
        _isDragStarted = false;
        IsSuccess = false;
    }

	public void Start()
	{
        if (NeedTwoFinger) { 
            Bandage1Script = Bandage1.GetComponent<Bandage>();
            _1lineRenderer = Bandage1.GetComponent<LineRenderer>();
       
            Bandage2Script = Bandage2.GetComponent<Bandage>();
            _2lineRenderer = Bandage2.GetComponent<LineRenderer>();
        }

    }

    private void Update()
	{
		if (Input.touchCount == 1)
		{
			MouseInput();
		}

		//MouseInput();
	}

    private void New_Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1) // 1 finger Detected
            {
                OneTouchInputDetected();
                Debug.Log("111");
            }
            else if (Input.touchCount == 2) // 2 finger Detected
            {
                Debug.Log("222");

                if (NeedTwoFinger)
				{
                    Debug.Log("need222");

                    NewTwoFingerNeededTouchInputDetected();
                }
				else
				{
                  OneTouchInputDetected();
                    Debug.Log("Notneed222");

                }
            }
        }
		else
		{
            MouseInput();
		}
    }

    private void MouseInput() {
        if (_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            // Hide the line if not dragging.
            // We will not hide it when it connects, later on.
            if (!IsSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);

        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }
    }

    private void OneTouchInputDetected()
    {
        if (_isDragStarted)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                touchPosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            // Hide the line if not dragging.
            // We will not hide it when it connects, later on.
            if (!IsSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, touchPosition, _canvas.worldCamera);

        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }



    }

    private void NewTwoFingerNeededTouchInputDetected()
    {

        if (_isDragStarted)
        {
            //1

            Touch touch1 = Input.GetTouch(0);
            touchPosition1 = touch1.position;
            Vector2 movePos1;
            // Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                touchPosition1,
                _canvas.worldCamera,
                out movePos1);

            _1lineRenderer.SetPosition(0, transform.position);
            _1lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos1));

            //2

            Touch touch2 = Input.GetTouch(1);
            touchPosition2 = touch2.position;
            Vector2 movePos2;
            // Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                touchPosition2,
                _canvas.worldCamera,
                out movePos2);

            _2lineRenderer.SetPosition(0, transform.position);
            _2lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos2));

        }
        else
        {
            if (!IsSuccess)
            {
                _1lineRenderer.SetPosition(0, Vector3.zero);
                _1lineRenderer.SetPosition(1, Vector3.zero);
                _2lineRenderer.SetPosition(0, Vector3.zero);
                _2lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered1 = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, touchPosition1, _canvas.worldCamera);
        bool isHovered2 = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, touchPosition2, _canvas.worldCamera);

		if (isHovered1)
		{
			_wireTask._1CurrentHoveredWire = Bandage1Script;
		}

		if (isHovered2)
		{
            _wireTask._2CurrentHoveredWire = Bandage2Script;
        }

    }

	public void SetColor(Color color)
    {
        _image.color = color;
        CustomColor = color;

        if (NeedTwoFinger)
		{
            _1lineRenderer.startColor = color;
            _1lineRenderer.endColor = color;
            _2lineRenderer.startColor = color;
            _2lineRenderer.endColor = color;
        }
        else
		{
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // needed for drag but not used
        if (NeedTwoFinger == false)
		{
            IsSuccess = false;
            _wireTask.CurrentHoveredWire = null;
        }
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (NeedTwoFinger)
        {//
            if (!IsLeftWire) { return; }
            // Is is successful, don't draw more lines!
            if (IsSuccess) { return; }
            _isDragStarted = true;
            _wireTask._1CurrentDraggedWire = Bandage1Script;
            _wireTask._2CurrentDraggedWire = Bandage2Script;
        }//
        else
        {
            if (!IsLeftWire) { return; }
            // Is is successful, don't draw more lines!
            if (IsSuccess) { return; }

            _isDragStarted = true;
            _wireTask.CurrentDraggedWire = this;
        }
		

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (NeedTwoFinger)//
		{
            if (_wireTask._1CurrentHoveredWire != null)
            {
                if (_wireTask._1CurrentHoveredWire.CustomColor == CustomColor && !_wireTask._1CurrentHoveredWire.IsLeftWire)
                {
                    IsSuccess = true;
                    // Set Successful on the Right Wire as well.
                    _wireTask._1CurrentHoveredWire.IsSuccess = true;
                }
            }
            if (_wireTask._2CurrentHoveredWire != null)
            {
                if (_wireTask._2CurrentHoveredWire.CustomColor == CustomColor && !_wireTask._2CurrentHoveredWire.IsLeftWire)
                {
                    IsSuccess = true;
                    // Set Successful on the Right Wire as well.
                    _wireTask._2CurrentHoveredWire.IsSuccess = true;
                }
            }

            _isDragStarted = false;

            _wireTask._1CurrentDraggedWire = null;
            _wireTask._2CurrentDraggedWire = null;


        }//
        else
		{
            if (_wireTask.CurrentHoveredWire != null)
            {
                if (_wireTask.CurrentHoveredWire.CustomColor == CustomColor && !_wireTask.CurrentHoveredWire.IsLeftWire)
                {
                    IsSuccess = true;
                    // Set Successful on the Right Wire as well.
                    _wireTask.CurrentHoveredWire.IsSuccess = true;
                }
            }

            _isDragStarted = false;

            _wireTask.CurrentDraggedWire = null;

        }
    }

}
