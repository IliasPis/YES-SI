using UnityEngine;

public class AfterSelectionStageBoyGoalBuisiness : MonoBehaviour
{
    public DropdownHandlerBoyGoalBuisiness DropdownHandlerBoyGoalBuisiness; // Assign this in the Inspector

    public void ChooseGoal(int value)
    {
        if (DropdownHandlerBoyGoalBuisiness.IsOtherSelected())
        {
            // Skip the execution if "Other" is selected
            return;
        }

        // Your existing code for choosing the goal
        Debug.Log("ChooseGoal executed with value: " + value);
    }
}
