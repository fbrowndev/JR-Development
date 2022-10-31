using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handling the Producivity Unit's actions
/// </summary>
public class ProductivityUnit : Unit
{
    #region Productivity Unit Variables
    ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    #endregion



    protected override void BuildingInRange()
    {
        if(m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    #region Productivity Methods
    void ResetProductivity()
    {
        if(m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    #endregion
}
