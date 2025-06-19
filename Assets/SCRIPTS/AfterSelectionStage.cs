using UnityEngine;

public class AfterSelectionStageBoyGoalProject : MonoBehaviour
{
    public DropdownHandlerBoyGoalProject DropdownHandlerBoyGoalProject; // Assign this in the Inspector

    public void ChooseGoal(int value)
    {
        if (DropdownHandlerBoyGoalProject.IsOtherSelected())
        {
            // Skip the execution if "Other" is selected
            return;
        }

        // Your existing code for choosing the goal
        Debug.Log("ChooseGoal executed with value: " + value);
    }
}
