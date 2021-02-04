using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
		{
            continueButton.SetActive(true);
		}
    }

    public void NextSentence()
	{
        continueButton.SetActive(false);

        if (index < sentences.Length - 1) 
		{
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
		}
		else
		{
            textDisplay.text = "";
            continueButton.SetActive(false);
		}
   	}


}
