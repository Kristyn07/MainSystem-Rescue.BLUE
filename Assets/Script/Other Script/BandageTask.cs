using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageTask : MonoBehaviour
{

    public List<Color> _wireColors = new List<Color>();
    public List<Bandage> _leftWires = new List<Bandage>();
    public List<Bandage> _rightWires = new List<Bandage>();

    public Bandage CurrentDraggedWire;

    public Bandage CurrentHoveredWire;

    public Bandage _1CurrentDraggedWire;
    public Bandage _2CurrentDraggedWire;
    public Bandage _1CurrentHoveredWire;
    public Bandage _2CurrentHoveredWire;


    public bool IsTaskCompleted = false;

    private List<Color> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;

    private void OnEnable()
    {
        // Generate new wires each time this object becomes active
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
            _leftWires[i].Initialize();
        }

        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
            _rightWires[i].Initialize();
        }

        while (_availableColors.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0)
        {
            /*Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);*/

            Color pickedColor = _availableColors[_availableColors.Count];
            int pickedLeftWireIndex =  _availableLeftWireIndex.Count;
            int pickedRightWireIndex = _availableRightWireIndex.Count;

            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;
            for (int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].IsSuccess) { successfulWires++; }
            }

            if (successfulWires >= _rightWires.Count)
            {
                // Task Completed
                gameObject.SetActive(true);
            }
            else
            {
                // Task Incompleted
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}