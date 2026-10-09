using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Talking : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialougeText;
    public string[] dialogue; // I assume this will be used for custom text
    private int index; // For the array to the dialogue 
    public float wordSpeed; // The speed of the text
    public bool playerInRange;// If the player is in range to the npc (true) if not (false)
    public GameObject contButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(dialoguePanel.activeInHierarchy){
                zeroText();
            
            }else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialougeText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

        
    }
    public void zeroText()
    {
        dialougeText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void Nextline()
    {
        contButton.SetActive(false);
        if(index < dialogue.Length -1)
        {
            index++;
            dialougeText.text = "";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }
    // This method is used to make playerInRange turn to true when the player is near the NPC
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
        }
    }
    // This method is uded to make playerInRange turn to false when player is away the NPC
    private void OnTriggerExit2D (Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
            zeroText();
        }
    }
}
