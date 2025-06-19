using UnityEngine;

public class AfterSelectionStageCategoryProject : MonoBehaviour
{
    public DropdownHandlerCategoryProject DropdownHandlerCategoryProject; // Assign this in the Inspector

    public void ChooseGoal(int value)
    {
        if (DropdownHandlerCategoryProject.IsOtherSelected())
        {
            // Skip the execution if "Other" is selected
            return;
        }

        // Your existing code for choosing the goal
        Debug.Log("ChooseGoal executed with value: " + value);
    }
}
