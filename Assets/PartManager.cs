using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {North,NorthEast, East,SouthEast, South, SouthWest, West, NorthWest, Up}

public class PartManager : MonoBehaviour
{
    public List<Part> parts = new List<Part>();

    public GameObject partPrefab;

    public void AddToList(Part p)
    {
        parts.Add(p);
    }

    public Part CheckIfIsSomethingThere(Vector3 pos)
    {
        return parts.Find(x => x.transform.position == pos);    
    }

    public void CreatePart(Vector3 pos)
    {
        Instantiate(partPrefab, pos, Quaternion.identity);
    }

    private void Start()
    {
        Instantiate(partPrefab,Vector3.zero, Quaternion.identity);
    }
}
