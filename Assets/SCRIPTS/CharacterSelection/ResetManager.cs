using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSelect;

public class ResetManager : MonoBehaviour
{
    public AfterSelectionStage AfterSelectionStage;
    public StageSelect stageSelect;
    public DropdownHandlerBoyGoalProject dropdownHandlerProject;
    public DropdownHandlerBoyGoalBuisiness dropdownHandlerBuisiness;
    public DropdownHandlerCategoryProject dropdownHandlerCategoryProject;
    public DropdownHandlerCategoryBuisiness dropdownHandlerCategoryBuisiness;
    

    void Start()
    {
        // Ensure references are assigned in the Inspector
        if (AfterSelectionStage == null || stageSelect == null || dropdownHandlerProject == null ||
            dropdownHandlerBuisiness == null || dropdownHandlerCategoryProject == null || dropdownHandlerCategoryBuisiness == null)
        {
            Debug.LogError("Please assign all references in the Inspector.");
        }
    }

    public void ResetAll()
    {
        // Clear PlayerPrefs
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs reset.");

        // Reset variables in AfterSelectionStage
        AfterSelectionStage.BuisinessSelection = false;
        AfterSelectionStage.ProjectSelection = false;
        AfterSelectionStage.NameOfBuisiness = string.Empty;
        AfterSelectionStage.NameOfProject = string.Empty;
        AfterSelectionStage.NameOfBuisinessGirl = string.Empty;
        AfterSelectionStage.NameOfProjectGirl = string.Empty;
        AfterSelectionStage.SelectChooseGoalValue = string.Empty;
        AfterSelectionStage.SelectChooseType = string.Empty;
        AfterSelectionStage.VisionSelect = string.Empty;
         
        // Reset variables in StageSelect
        stageSelect.RightAnswers = 0;
        stageSelect.BoyTypeCrowdfunding = string.Empty;
        stageSelect.GirlTypeCrowdfunding = string.Empty;
        stageSelect.BoyGetSelectedPlatform = string.Empty;
        stageSelect.GirlGetSelectedPlatform = string.Empty;
        stageSelect.BoyMarketingStrategy = string.Empty;
        stageSelect.GirlMarketingStrategy = string.Empty;
        stageSelect.DisaplyOfProjectName = string.Empty;
        stageSelect.customInputFieldProject.text = string.Empty;
        stageSelect.customInputFieldBuisiness.text = string.Empty;
        stageSelect.customInputFieldProjectText.text = string.Empty;
        stageSelect.customInputFieldBuisinessText.text = string.Empty;

        // Reset dropdown handlers
        dropdownHandlerProject.ResetPlayerPrefs();
        dropdownHandlerBuisiness.ResetPlayerPrefs();
        dropdownHandlerCategoryProject.ResetPlayerPrefs();
        dropdownHandlerCategoryBuisiness.ResetPlayerPrefs();


        // Add additional resets for any other components or variables as needed
    }
}
