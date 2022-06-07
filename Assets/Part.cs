using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public List<Part> neighbours = new List<Part>();
    public List<Part> farNeighbours = new List<Part>();
    private PartManager pm;

    public Part north, east, south, west, northEast, northWest, southEast, southWest, up;

    [SerializeField]
    private GameObject end, straight, corner, cornerX, fork, forkX, forkN, forkM, solo, none;
    [SerializeField]
    private List<GameObject> shapes = new List<GameObject>();


    private void Start()
    {
        pm = FindObjectOfType<PartManager>();
        pm.AddToList(this);
        SetNeighbours();
        UpdatePart();
        UpdateNeighbours();
    }

    public void SetNeighbours()
    {
        neighbours.Clear();
        farNeighbours.Clear();

        if (pm.CheckIfIsSomethingThere(transform.position + Globales.North) != null)
        {
            north = pm.CheckIfIsSomethingThere(transform.position + Globales.North);
            neighbours.Add(north);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.East) != null)
        {
            east = pm.CheckIfIsSomethingThere(transform.position + Globales.East);
            neighbours.Add(east);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.South) != null)
        {
            south = pm.CheckIfIsSomethingThere(transform.position + Globales.South);
            neighbours.Add(south);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.West) != null)
        {
            west = pm.CheckIfIsSomethingThere(transform.position + Globales.West);
            neighbours.Add(west);
        }


        if (pm.CheckIfIsSomethingThere(transform.position + Globales.NorthEast) != null)
        {
            northEast = pm.CheckIfIsSomethingThere(transform.position + Globales.NorthEast);
            farNeighbours.Add(northEast);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.NorthWest) != null)
        {
            northWest = pm.CheckIfIsSomethingThere(transform.position + Globales.NorthWest);
            farNeighbours.Add(northWest);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.SouthEast) != null)
        {
            southEast = pm.CheckIfIsSomethingThere(transform.position + Globales.SouthEast);
            farNeighbours.Add(southEast);
        }
        if (pm.CheckIfIsSomethingThere(transform.position + Globales.SouthWest) != null)
        {
            southWest = pm.CheckIfIsSomethingThere(transform.position + Globales.SouthWest);
            farNeighbours.Add(southWest);
        }

        //if (pm.CheckIfIsSomethingThere(transform.position + Globales.Up) != null)
        //{
        //    up = pm.CheckIfIsSomethingThere(transform.position + Globales.Up);
        //    neighbours.Add(up);
        //}
    }

    public void UpdatePart()
    {
        foreach (GameObject g in shapes)
            g.SetActive(false);

        if (neighbours.Count == 0)
        {
            solo.SetActive(true);
        }
        if (neighbours.Count == 1)
        {
            end.SetActive(true);
            if (north)
                end.transform.localEulerAngles = new Vector3(0, 180, 0);
            if (east)
                end.transform.localEulerAngles = new Vector3(0, 270, 0);
            if (south)
                end.transform.localEulerAngles = new Vector3(0, 0, 0);
            if (west)
                end.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if (neighbours.Count == 2)
        {
            if (north && east)
            {
                if (northEast)
                {
                    corner.SetActive(true);
                    corner.transform.localEulerAngles = new Vector3(0, -90, 0);
                }
                else
                {
                    cornerX.SetActive(true);
                    cornerX.transform.localEulerAngles = new Vector3(0, -90, 0);
                }
            }
            if (east && south)
            {
                if (southEast)
                {
                    corner.SetActive(true);
                    corner.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    cornerX.SetActive(true);
                    cornerX.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }
            if (south && west)
            {
                if (southWest)
                {
                    corner.SetActive(true);
                    corner.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else
                {
                    cornerX.SetActive(true);
                    cornerX.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
            }
            if (west && north)
            {
                if (northWest)
                {
                    corner.SetActive(true);
                    corner.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    cornerX.SetActive(true);
                    cornerX.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
            }
            if (north && south)
            {
                straight.SetActive(true);
                straight.transform.localEulerAngles = new Vector3(0, 90, 0);
            }
            if (east && west)
            {
                straight.SetActive(true);
                straight.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (neighbours.Count == 3)
        {
            if (!north)
            {
                if (!southEast && !southWest)
                {
                    forkX.SetActive(true);
                    forkX.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else if (!southEast && southWest)
                {
                    forkN.SetActive(true);
                    forkN.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else if (southEast && !southWest)
                {
                    forkM.SetActive(true);
                    forkM.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    fork.SetActive(true);
                    fork.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }
                
            if (!east)
            {
                if (!northWest && !southWest)
                {
                    forkX.SetActive(true);
                    forkX.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else if (!northWest && southWest)
                {
                    forkM.SetActive(true);
                    forkM.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else if (northWest && !southWest)
                {
                    forkN.SetActive(true);
                    forkN.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else
                {
                    fork.SetActive(true);
                    fork.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
            }

            if (!south)
            {
                if (!northWest && !northEast)
                {
                    forkX.SetActive(true);
                    forkX.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else if (!northWest && northEast)
                {
                    forkN.SetActive(true);
                    forkN.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else if (northWest && !northEast)
                {
                    forkM.SetActive(true);
                    forkM.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    fork.SetActive(true);
                    fork.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
            }
            if (!west)
            {
                if (!southEast && !northEast)
                {
                    forkX.SetActive(true);
                    forkX.transform.localEulerAngles = new Vector3(0, 270, 0);
                }
                else if (!southEast && northEast)
                {
                    forkM.SetActive(true);
                    forkM.transform.localEulerAngles = new Vector3(0, 270, 0);
                }
                else if (southEast && !northEast)
                {
                    forkN.SetActive(true);
                    forkN.transform.localEulerAngles = new Vector3(0, 270, 0);
                }
                else
                {
                    fork.SetActive(true);
                    fork.transform.localEulerAngles = new Vector3(0,270, 0);
                }
            }
        }
        if (neighbours.Count == 4)
        {
            none.SetActive(true);
            none.GetComponent<NoneController>().UpdateParts(farNeighbours);
        }
    }
    public void UpdateNeighbours()
    {
        foreach(Part n in neighbours)
        {
            n.SetNeighbours();
            n.UpdatePart();
        }
        foreach (Part n in farNeighbours)
        {
            n.SetNeighbours();
            n.UpdatePart();
        }
    }
}
