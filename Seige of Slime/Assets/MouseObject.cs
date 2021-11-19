using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObject : MonoBehaviour
{
    private DefenderAi selectedDefenderAi;
    private DefenderAi hoveredDefenderAi;
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position = GetMousePosition();

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedDefenderAi == null)
            {
                if (hoveredDefenderAi != null)
                {
                    selectedDefenderAi = hoveredDefenderAi;
                    selectedDefenderAi.Select();
                }
            }
            else
            {
                if (hoveredDefenderAi != null && selectedDefenderAi != hoveredDefenderAi)
                {
                    selectedDefenderAi.Deselect();
                    selectedDefenderAi = hoveredDefenderAi;
                    selectedDefenderAi.Select();
                }
            }
        }
    }

    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DefenderAi>() != null)
        {
            hoveredDefenderAi = other.gameObject.GetComponent<DefenderAi>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DefenderAi>() != null)
        {
            hoveredDefenderAi = null;
        }
    }
}
