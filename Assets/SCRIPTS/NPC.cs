using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour
 {

public NPCConversation Conversation;


 private void OnMouseOver(){

//public GameObject ButtonReaction;

//Scene currentScene = SceneManager.GetActiveScene ();


//string sceneName = currentScene.name;

		/*if(SceneManager.GetSceneByBuildIndex(2).IsValid()) 
		{
			 ConversationManager.Instance.StartConversation(Conversation);

		}*/

	if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
	{
	ConversationManager.Instance.StartConversation(Conversation);
	//ConversationManager.StartConversation();
	}
	
	}
}
