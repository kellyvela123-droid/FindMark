using UnityEngine;
using UnityEngine UI;

public class Talking : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialougeText;
    public string[] dialogue; // I assume this will be used for custom text
    private int index; // For the array to the dialogue 
    public float wordSpeed; // The speed of the text
    public bool playerInRange;// If the player is in range to the npc (true) if not (false)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.SPACE) && playerIsRange){
            if(dialoguePanel.activeInHierarchy){
                zeroText();
            
            }else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
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
            dialogueText += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void Nextline()
    {
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }
    // This method is used to make playerInRange turn to true when the player is near the NPC
    private void OnTriggerEnter(Collider2d other){
        if(other.CompareTag("Player")){
            playerIsRange = true;
        }
    }
    // This method is uded to make playerInRange turn to false when player is away the NPC
    private void OnTriggerExit (Collider2d other){
        if(other.ComapteTag("Player")){
            playerInRange = false;
        }
    }
}
