using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridFillerColliders : MonoBehaviour, IDropHandler
{
    public bool isFilled;
    public int Index;
    public GameObject mainSysObj;
    public ItemGenerator mainSys;
    public List<Sprite> AlcoholTiles = new List<Sprite>();
    public List<Sprite> BandaidTiles = new List<Sprite>();
    public List<Sprite> GauzeTiles = new List<Sprite>();
    public List<Sprite> Medicine = new List<Sprite>();
    public List<Sprite> ScissorTiles = new List<Sprite>();
    public List<Sprite> ThermoTiles = new List<Sprite>();
    public List<Sprite> TriBandageTiles = new List<Sprite>();
    //new
    public List<Sprite> BottledWaterTiles = new List<Sprite>();
    public List<Sprite> FoodTiles = new List<Sprite>();
    public List<Sprite> ClothesTiles = new List<Sprite>();
    public List<Sprite> DocumentTiles = new List<Sprite>();
    public List<Sprite> FlashLighTiles = new List<Sprite>();


    public int fillID;
    private Image image;
    public GridSlots gridBox;
    public GridArray gridArray;
    void Start()
    {
        mainSys = mainSysObj.GetComponent<ItemGenerator>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            switch (mainSys.objID)
            {
                case 0:
                    gridArray.Alcohol();
                    break;
                case 1:
                    gridArray.BandaidWhistle();
                    break;
                case 2:
                    gridArray.Gauze();
                    break;
                case 3:
                    gridArray.Medicine();
                    break;
                case 4:
                    gridArray.Scissors();
                    break;
                case 5:
                    gridArray.Thermometer();
                    break;
                case 6:
                    gridArray.TriangularBandage();
                    break;
                // new
                case 7:
                    gridArray.BottledWater();
                    break;
                case 8:
                    gridArray.Foods();
                    break;
                case 9:
                    gridArray.Clothes();
                    break;
                case 10:
                    gridArray.Documents();
                    break;
                case 11:
                    gridArray.FlashLight();
                    break;
            }
        }
    }
}
