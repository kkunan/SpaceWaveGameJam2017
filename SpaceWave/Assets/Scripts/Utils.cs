using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// A collection of global values and utility methods to cut down on needing to copy and paste everything everywhere
// NOTE: NOT A MONOBEHAVIOUR, DO *NOT* ADD TO OBJECTS
class Utils
{
    public static Color defaultHealthColor = Color.green;

    public static Color GetHealthColor(float currentHealth, float maxHealth)
    {
        Color healthColor = defaultHealthColor;
        float percent = currentHealth/maxHealth;
        if (percent > 0.65f)
        {
            healthColor = new Color(defaultHealthColor.r + 0.1f / 0.35f, defaultHealthColor.g, 0, 1);
        }
        else if (percent <= 0.65f && percent > 0.30f)
        {
            healthColor = new Color(1, defaultHealthColor.g - 0.1f / 0.35f, 0, 1);
        }
        else if (percent < 0.3f)
        {
            healthColor = new Color(1, 0, 0, 1);
        }
        return healthColor;
    }
}
