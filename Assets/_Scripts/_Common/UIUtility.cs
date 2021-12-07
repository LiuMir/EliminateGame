using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtility 
{
    public static void SetAllToggleOff(ToggleGroup toggleGroup)
    {
        bool isAllowSwitchOff = toggleGroup.allowSwitchOff;
        toggleGroup.allowSwitchOff = true;
        foreach (var toggle in toggleGroup.ActiveToggles())
        {
            var transition = toggle.toggleTransition;
            toggle.toggleTransition = Toggle.ToggleTransition.None;
            toggle.isOn = false;
            toggle.toggleTransition = transition;
        }
        toggleGroup.allowSwitchOff = isAllowSwitchOff;
    }
}
