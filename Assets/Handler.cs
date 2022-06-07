using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    public Direction dir;
    private MeshRenderer mr;
    PartManager pm;
    Part part;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        pm = FindObjectOfType<PartManager>();
        part = transform.parent.parent.GetComponent<Part>();
    }
    private void OnMouseDown()
    {
        pm.CreatePart(part.transform.position + Globales.ConvertDirectionToVector(dir));
    }

    private void OnMouseOver()
    {
        mr.enabled = true;
    }
    private void OnMouseExit()
    {
        mr.enabled = false;
    }
    
}
