using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridArray : MonoBehaviour
{
    public GameObject[,] grid;
    public bool boxFilled;
    public List<IrregularObjectColliders> objects;
    public List<GridFillerColliders> fillerColliders;
    public ObjectivesFirstAid objectiveCounts;
    public List<int> fillIDs;
    int Vertical, Horizontal, Columns, Rows, x;
    public GridSlots slots;
    public UpdateObjectiveFirstAidKit updater;
    GameObject location, currentTile;
    int y;
    void Start()
    {
        Columns = 5;
        Rows = 5;
        grid = new GameObject[Columns, Rows];
        x = 0;
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                grid[i, j] = slots.collidersAsObjects[x];
                x++;
            }
        }
        //Purge();

                


    }





	public void Alcohol()
    {
        for (int i = 0; i < objects[0].ColumnsI; i++)
        {
            for (int j = 0; j < objects[0].RowsI; j++)
            {
                currentTile = objects[0].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {

                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[0]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[0].ColumnsI; i++)
        {
            for (int j = 0; j < objects[0].RowsI; j++)
            {
                objects[0].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 1;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].AlcoholTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void BandaidWhistle()
    {
        for (int i = 0; i < objects[1].ColumnsI; i++)
        {
            for (int j = 0; j < objects[1].RowsI; j++)
            {

                currentTile = objects[1].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[1]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[1].ColumnsI; i++)
        {
            for (int j = 0; j < objects[1].RowsI; j++)
            {
                objects[1].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 2;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].BandaidTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Gauze()
    {
        for (int i = 0; i < objects[2].ColumnsI; i++)
        {
            for (int j = 0; j < objects[2].RowsI; j++)
            {

                currentTile = objects[2].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[2]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[2].ColumnsI; i++)
        {
            for (int j = 0; j < objects[2].RowsI; j++)
            {
                objects[2].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 3;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].GauzeTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Scissors()
    {
        for (int i = 0; i < objects[4].ColumnsI; i++)
        {
            for (int j = 0; j < objects[4].RowsI; j++)
            {

                currentTile = objects[4].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[4]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[4].ColumnsI; i++)
        {
            for (int j = 0; j < objects[4].RowsI; j++)
            {
                objects[4].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 5;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].ScissorTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Thermometer()
    {
        for (int i = 0; i < objects[5].ColumnsI; i++)
        {
            for (int j = 0; j < objects[5].RowsI; j++)
            {

                currentTile = objects[5].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[5]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[5].ColumnsI; i++)
        {
            for (int j = 0; j < objects[5].RowsI; j++)
            {
                objects[5].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 6;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].ThermoTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void TriangularBandage()
    {
        for (int i = 0; i < objects[6].ColumnsI; i++)
        {
            for (int j = 0; j < objects[6].RowsI; j++)
            {

                currentTile = objects[6].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[6]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[6].ColumnsI; i++)
        {
            for (int j = 0; j < objects[6].RowsI; j++)
            {
                objects[6].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 7;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].TriBandageTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Medicine()
    {
        for (int i = 0; i < objects[3].ColumnsI; i++)
        {
            for (int j = 0; j < objects[3].RowsI; j++)
            {

                currentTile = objects[3].objColliders[i, j];
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1;
                    location = currentTile.GetComponent<ColliderLists>().collided[y];
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[3]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        for (int i = 0; i < objects[3].ColumnsI; i++)
        {
            for (int j = 0; j < objects[3].RowsI; j++)
            {
                objects[3].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            fillerColliders[z].fillID = 4;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].Medicine[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }


    // ForEarthQuakeITems
    public void BottledWater()
    {
        for (int i = 0; i < objects[7].ColumnsI; i++)
        {
            for (int j = 0; j < objects[7].RowsI; j++)
            {
                currentTile = objects[7].objColliders[i, j]; // Check the current tile in position listed.
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    // If the current tile is not in a valid position/outside the grid, or has not passed over any tiles, reject the item.
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1; // Get the most recent tile collided with.
                    location = currentTile.GetComponent<ColliderLists>().collided[y]; // Get the slot tile the object has recently collided with (read: currently over).
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        // If most recent collided tile is not filled and the tile is tagged as a filler tile, add the tile to a list of tiles to fill.
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[7]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        // If not filler tile, proceed to next and clear the tile's collided list.
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        // If neither condition met, that means tile is already filled.
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        // Clear the collider list for the object.
        for (int i = 0; i < objects[7].ColumnsI; i++)
        {
            for (int j = 0; j < objects[7].RowsI; j++)
            {
                objects[7].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            // Fill each tile with the specific component tile listed. Set the ID of the filled tile to match the object.
            fillerColliders[z].fillID = 8;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].BottledWaterTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Foods()
    {
        for (int i = 0; i < objects[8].ColumnsI; i++)
        {
            for (int j = 0; j < objects[8].RowsI; j++)
            {
                currentTile = objects[8].objColliders[i, j]; // Check the current tile in position listed.
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    // If the current tile is not in a valid position/outside the grid, or has not passed over any tiles, reject the item.
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1; // Get the most recent tile collided with.
                    location = currentTile.GetComponent<ColliderLists>().collided[y]; // Get the slot tile the object has recently collided with (read: currently over).
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        // If most recent collided tile is not filled and the tile is tagged as a filler tile, add the tile to a list of tiles to fill.
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[8]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        // If not filler tile, proceed to next and clear the tile's collided list.
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        // If neither condition met, that means tile is already filled.
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        // Clear the collider list for the object.
        for (int i = 0; i < objects[8].ColumnsI; i++)
        {
            for (int j = 0; j < objects[8].RowsI; j++)
            {
                objects[8].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            // Fill each tile with the specific component tile listed. Set the ID of the filled tile to match the object.
            fillerColliders[z].fillID = 9;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].FoodTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Clothes()
    {
        for (int i = 0; i < objects[9].ColumnsI; i++)
        {
            for (int j = 0; j < objects[9].RowsI; j++)
            {
                currentTile = objects[9].objColliders[i, j]; // Check the current tile in position listed.
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    // If the current tile is not in a valid position/outside the grid, or has not passed over any tiles, reject the item.
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1; // Get the most recent tile collided with.
                    location = currentTile.GetComponent<ColliderLists>().collided[y]; // Get the slot tile the object has recently collided with (read: currently over).
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        // If most recent collided tile is not filled and the tile is tagged as a filler tile, add the tile to a list of tiles to fill.
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[9]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        // If not filler tile, proceed to next and clear the tile's collided list.
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        // If neither condition met, that means tile is already filled.
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        // Clear the collider list for the object.
        for (int i = 0; i < objects[9].ColumnsI; i++)
        {
            for (int j = 0; j < objects[9].RowsI; j++)
            {
                objects[9].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            // Fill each tile with the specific component tile listed. Set the ID of the filled tile to match the object.
            fillerColliders[z].fillID = 10;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].ClothesTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void Documents()
    {
        for (int i = 0; i < objects[10].ColumnsI; i++)
        {
            for (int j = 0; j < objects[10].RowsI; j++)
            {
                currentTile = objects[10].objColliders[i, j]; // Check the current tile in position listed.
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    // If the current tile is not in a valid position/outside the grid, or has not passed over any tiles, reject the item.
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1; // Get the most recent tile collided with.
                    location = currentTile.GetComponent<ColliderLists>().collided[y]; // Get the slot tile the object has recently collided with (read: currently over).
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        // If most recent collided tile is not filled and the tile is tagged as a filler tile, add the tile to a list of tiles to fill.
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[10]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        // If not filler tile, proceed to next and clear the tile's collided list.
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        // If neither condition met, that means tile is already filled.
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        // Clear the collider list for the object.
        for (int i = 0; i < objects[10].ColumnsI; i++)
        {
            for (int j = 0; j < objects[10].RowsI; j++)
            {
                objects[10].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            // Fill each tile with the specific component tile listed. Set the ID of the filled tile to match the object.
            fillerColliders[z].fillID = 11;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].DocumentTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }
    public void FlashLight()
    {
        for (int i = 0; i < objects[11].ColumnsI; i++)
        {
            for (int j = 0; j < objects[11].RowsI; j++)
            {
                currentTile = objects[11].objColliders[i, j]; // Check the current tile in position listed.
                if (Physics2D.OverlapPoint(currentTile.transform.position) == null || currentTile.GetComponent<ColliderLists>().collided.Count == 0)
                {
                    // If the current tile is not in a valid position/outside the grid, or has not passed over any tiles, reject the item.
                    Debug.Log("One tile is not in the grid. Item rejected.");
                    currentTile.GetComponent<ColliderLists>().collided.Clear();
                    fillerColliders.Clear();
                    goto LoopEnd;
                }
                else
                {
                    y = currentTile.GetComponent<ColliderLists>().collided.Count - 1; // Get the most recent tile collided with.
                    location = currentTile.GetComponent<ColliderLists>().collided[y]; // Get the slot tile the object has recently collided with (read: currently over).
                    if (location.GetComponent<GridFillerColliders>().isFilled == false && currentTile.GetComponent<ColliderLists>().isFiller == true)
                    {
                        // If most recent collided tile is not filled and the tile is tagged as a filler tile, add the tile to a list of tiles to fill.
                        fillerColliders.Add(location.GetComponent<GridFillerColliders>());
                        fillIDs[11]++;
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else if (currentTile.GetComponent<ColliderLists>().isFiller == false)
                    {
                        // If not filler tile, proceed to next and clear the tile's collided list.
                        Debug.Log("Not a filler tile. Move on.");
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                    }
                    else
                    {
                        // If neither condition met, that means tile is already filled.
                        Debug.Log("Something happened. Probably a tile is already filled.");
                        fillerColliders.Clear();
                        currentTile.GetComponent<ColliderLists>().collided.Clear();
                        goto LoopEnd;
                    }
                }
            }
        }
    LoopEnd:
        // Clear the collider list for the object.
        for (int i = 0; i < objects[11].ColumnsI; i++)
        {
            for (int j = 0; j < objects[11].RowsI; j++)
            {
                objects[11].objColliders[i, j].GetComponent<ColliderLists>().collided.Clear();
            }
        }
        for (int z = 0; z < fillerColliders.Count; z++)
        {
            // Fill each tile with the specific component tile listed. Set the ID of the filled tile to match the object.
            fillerColliders[z].fillID = 12;
            fillerColliders[z].isFilled = true;
            Image image = fillerColliders[z].GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            image.sprite = fillerColliders[z].FlashLighTiles[z];
            updater.Reset();
            updater.Checker();
        }
        fillerColliders.Clear();
    }






    public void CheckCompletion()
    {
        for (int i = 0; i < fillIDs.Count; i++)
        {
            if (fillIDs[i] >= objectiveCounts.objectiveCounts[i])
            {
                Debug.Log("Object conditions met.");
                //objectiveCounts.Complete();
            }
            else if (fillIDs[i] < objectiveCounts.objectiveCounts[i])
            {
                boxFilled = false;
                return;
            }
        }
        objectiveCounts.Complete();
    }
    public void Purge()
    {
        var DefaultGrid = objectiveCounts.mySprite;
        for (int i = 0; i < slots.colliders.Count; i++)
        {
            slots.colliders[i].isFilled = false;
            slots.colliders[i].fillID = 0;
            slots.colliders[i].GetComponent<Image>().sprite = DefaultGrid;
            slots.colliders[i].GetComponent<Image>().color = new Color(255, 255, 255, 255f);
            updater.Checker();
            updater.Reset();
        }
        for (int i = 0; i < fillIDs.Count; i++)
        {
            fillIDs[i] = 0;
        }
    }
}

