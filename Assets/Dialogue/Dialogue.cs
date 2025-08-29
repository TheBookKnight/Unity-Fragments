using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // if the user clicks while the text is being typed, finish typing the line immediately
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // Start the dialogue sequence
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Coroutine to type out the line character by character
    IEnumerator TypeLine()
    {
        // Display characters one by one
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // Proceed to the next line of dialogue
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
