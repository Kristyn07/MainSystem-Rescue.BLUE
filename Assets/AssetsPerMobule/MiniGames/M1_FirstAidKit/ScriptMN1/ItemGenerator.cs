using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum KitState { FIRSTACTIVE, ACTIVE, COMPLETED };

    public class ItemGenerator : MonoBehaviour
    {
        public List<GameObject> items = new List<GameObject>();
        public GameObject currentItem;
        private Transform itemStation;
        public KitState state;
        public int objID;

        void Start()
        {
            state = KitState.FIRSTACTIVE;
            objID = 0;
            foreach (GameObject item in items)
            {
                // All items are present in the object station, this hides the ones not being used.
                item.gameObject.SetActive(false);
            }
            items[objID].gameObject.SetActive(true);
            state = KitState.ACTIVE;
        }

        private void Update()
        {

        }
        public void Increment()
        {
            // Increase the object ID counter by 1, each object is associated with a different objID on the List.
            // 0 = Alcohol, 1 = Bandaids and Whistle, 2 = Gauze pads, 3 = Medications, 4 = Scissors, 5 = Thermometer, 6 = Triangular bandage
            // If objID is at the last item (objIJ=6 in this case), cycle back to first item in list.
            Debug.Log("Right button clicked");
            items[objID].gameObject.SetActive(false);
            objID++;
            if (objID > items.Count - 1)
            {
                objID = 0;
            }
            Debug.Log("ObjID Counter at: " + objID);
            items[objID].gameObject.SetActive(true);



        }
        public void Decrement()
        {
            // Decrease the object ID counter by 1 if the left button is clicked.
            // If objectID is 0, instead cycles back to the "last object" in the list.
            Debug.Log("Left button clicked");
            items[objID].gameObject.SetActive(false);
            objID--;
            if (objID < 0)
            {
                objID = items.Count - 1;
            }
            Debug.Log("ObjID Counter at: " + objID);
            items[objID].gameObject.SetActive(true);
        }
    }