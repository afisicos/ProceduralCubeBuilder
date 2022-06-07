using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneController : MonoBehaviour
{
    [SerializeField]
    private GameObject NW, NE, SE, SW, NWx, NEx, SEx, SWx;
    [SerializeField]
    private List<GameObject> roundedParts = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rectParts = new List<GameObject>();

    public void UpdateParts(List<Part> farNeighbours)
    {
        foreach (GameObject g in roundedParts)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in rectParts)
        {
            g.SetActive(false);
        }
        foreach (Part p in farNeighbours)
        {
            if (Globales.InWhichDirectionIs(p.gameObject, gameObject) == Direction.NorthWest)
            {
                NWx.SetActive(false);
                NW.SetActive(true);
            }
            if (Globales.InWhichDirectionIs(p.gameObject, gameObject) == Direction.NorthEast)
            {
                NEx.SetActive(false);
                NE.SetActive(true);
            }
            if (Globales.InWhichDirectionIs(p.gameObject, gameObject) == Direction.SouthEast)
            {
                SEx.SetActive(false);
                SE.SetActive(true);
            }
            if (Globales.InWhichDirectionIs(p.gameObject, gameObject) == Direction.SouthWest)
            {
                SWx.SetActive(false);
                SW.SetActive(true);
            }
        }
    }

}
