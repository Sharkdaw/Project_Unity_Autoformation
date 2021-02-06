
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

	public bool isInRange;

        
	void Update()
	{
		if(isInRange && Input.GetKeyDown(KeyCode.E))
		{
			TriggerDialogue();
		}
			
	}

   private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Slime"))
		{
			isInRange = true;
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Slime"))
		{
			isInRange = false;
		}
	}


	void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}


}

