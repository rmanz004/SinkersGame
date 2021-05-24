using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    #region Private Fields
    private HealthAndAmmo target;
    #endregion

    #region MonoBehaviour Callbacks
    
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image ammo1;
    public Image ammo2;
    public Image ammo3;
    
    void update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    public int Hearts(int num)
    {
        if(num < 0 || num > 3)
        {
            return -1;
        }
        else
        {
            if(num == 0)
            {
                heart1.enabled = false;
                heart2.enabled = false;
                heart3.enabled = false;
            }
            else if(num ==1)
            {
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
            }
            else if (num == 2)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
            }
            else
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
            }
            return 0;
        }
    }

    public int Ammo(int num)
    {
        if (num < 0 || num > 3)
        {
            return -1;
        }
        else
        {
            if (num == 0)
            {
                ammo1.enabled = false;
                ammo2.enabled = false;
                ammo3.enabled = false;
            }
            else if (num == 1)
            {
                ammo1.enabled = true;
                ammo2.enabled = false;
                ammo3.enabled = false;
            }
            else if (num == 2)
            {
                ammo1.enabled = true;
                ammo2.enabled = true;
                ammo3.enabled = false;
            }
            else
            {
                ammo1.enabled = true;
                ammo2.enabled = true;
                ammo3.enabled = true;
            }
            return 0;
        }
    }
    #endregion

    #region Public Methods
    public void SetTarget(HealthAndAmmo _target)
    {
        if(_target == null)
        {
            Debug.LogError("No player target");
            return;
        }
        target = _target;
    }
    #endregion
}
