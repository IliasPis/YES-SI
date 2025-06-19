using UnityEngine;

public class AfterSelectionStageCtegoryBusiness : MonoBehaviour
{
    public DropdownHandlerCategoryBuisiness DropdownHandlerCategoryBuisiness; // Assign this in the Inspector

    public void ChooseGoal(int value)
    {
        if (DropdownHandlerCategoryBuisiness.IsOtherSelected())
        {
            // Skip the execution if "Other" is selected
            return;
        }

        // Your existing code for choosing the goal
        Debug.Log("ChooseGoal executed with value: " + value);
    }
}
