using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    DialogueParser parser;

    public string dialogue;
    public string name;
    public Sprite pose;
    public string position;
    int lineNum;
    // Start is called before the first frame update
    public GUIStyle customStyle, customStyleName;

    void Start()
    {
        dialogue = "";
        parser = GameObject.Find ("DialogueParserObj").GetComponent<DialogueParser> ();
        lineNum = 0;
    }
    string oldname = "";
    // Update is called once per frame
    void Update()
    {
        //check for click input
        if (Input.GetMouseButtonDown(0))
        {
          ResetImages();

          //get name, etc
          name = parser.GetName(lineNum);
          dialogue = parser.GetContent(lineNum);
          pose = parser.GetPose(lineNum);
          position = parser.GetPosition(lineNum);

          DisplayImages();

          lineNum++;
        }
    }
    void ResetImages()
    {
      if(name != "")
      {
        GameObject character = GameObject.Find (name);
        //we want all characters
        Debug.Log("Name, dialogue, pose, position:");
        Debug.Log(name);
        Debug.Log(dialogue);
        Debug.Log(pose);
        Debug.Log(position);
        SpriteRenderer currSprite = character.GetComponent<SpriteRenderer> ();
        currSprite.sprite = null;
      }
    }
    void DisplayImages()
    {
      if(name != "")
      {
        GameObject character = GameObject.Find (name);

        SetSpritePositions (character);

        SpriteRenderer currSprite = character.GetComponent<SpriteRenderer> ();
        currSprite.sprite = pose;
      }
    }
    void SetSpritePositions(GameObject spriteObj) {
      if (position == "L")
      {
        spriteObj.transform.position = new Vector3(-3,2,0); //try width/3 etc so works on any screens
      }
      if (position == "R")
      {
        spriteObj.transform.position = new Vector3(3,2,0);
      }
      //could make centre position
    }
    void OnGUI()
    {
      dialogue = GUI.TextField ( new Rect (100, 400, 600, 200), dialogue, customStyle );
      //change placement of name box
      name = GUI.TextField ( new Rect (300, 600, 800, 400), name, customStyleName );
      //name = GUI.TextField ( new Rect (-100, 200, 400, 0), name, customStyleName );
    }
}
