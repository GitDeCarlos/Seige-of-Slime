using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObject : MonoBehaviour
{
    private GameObject selected;
    private GameObject hovered;
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position = GetMousePosition();

        if (Input.GetMouseButtonDown(0))
        {
            if (selected == null)
            {
                if (hovered != null)
                {
                    // surround with if statement
                    selected = hovered;
                    SelectSelected();
                }
            }
            else
            {
                if (hovered == selected)
                {
                    // surround with if statement
                    DeselectSelected();
                    selected = null;
                }
                else if (hovered != null && selected != hovered)
                {
                    // surround with if statement
                    DeselectSelected();
                    selected = hovered;
                    SelectSelected();
                }
            }
        }
    }

    public void SelectSelected()
    {
        if (selected.GetComponent<DefenderAi>() != null)
            selected.GetComponent<DefenderAi>().Select();
        else selected.GetComponent<CastleManager>().Select();
    }

    private void DeselectSelected()
    {
        if (selected.GetComponent<DefenderAi>() != null)
            selected.GetComponent<DefenderAi>().Deselect();
        else selected.GetComponent<CastleManager>().Deselect();
    }

    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DefenderAi>() != null || other.GetComponent<CastleManager>() != null)
        {
            hovered = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DefenderAi>() != null || other.GetComponent<CastleManager>() != null)
        {
            hovered = null;
        }
    }
}
