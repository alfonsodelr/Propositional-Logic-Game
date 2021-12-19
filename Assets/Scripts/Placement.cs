using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{
    CardReader card;
    private bool MP = false;
    private string m_name;
    private GameObject obj;
    private GameObject board;
    private GameObject canvas;
    private List <string> objects_added;
    private int special_index, single;
    private int input_1 = -1;
    private int input_2 = -1;
    private GameObject board_2;
    private GameObject canvas_2;
    private bool run_num;
    bool first_input = true;
    bool correct = true;
    private void Awake() {
        board = GameObject.Find("Board");
        board_2 = GameObject.Find("Board_2");
        canvas = board.transform.GetChild(0).gameObject;
        canvas_2 = board_2.transform.GetChild(0).gameObject;
        objects_added = new List<string>();
        objects_added.Add("R");
        objects_added.Add("R->D");
        objects_added.Add("D->~J");
        special_index = 0;
        single = 0;
        run_num = false;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Draggable"){
            //Debug.Log("touching");
            run_num = true;
            card = other.gameObject.GetComponent<CardReader>();
            m_name = ProcessCardInfo(card);
        }
    }

    private void ChangeBoard(int num){
        GameObject inputs = canvas_2.transform.GetChild(1).gameObject;
        Text t = inputs.GetComponent<Text>();
        if(num == 1){
            t.text += input_1;
        }else {
            t.text +="\n" + input_2;
        }
    }

    private void EmptyBoard(){
        GameObject inputs = canvas_2.transform.GetChild(1).gameObject;
        Text t = inputs.GetComponent<Text>();
        t.text = "";
        first_input = true;
        input_2 = -1;
        input_1 = -1;
    }

    private void Prompt(int num){
        EmptyPrompt();
        GameObject prompts = canvas_2.transform.GetChild(2).gameObject;
        Text t = prompts.GetComponent<Text>();
        if(num == 1){
            t.text += "Incorrect";
        }
        else if(num == 2){t.text = "Invalid Input";}
    }

    private void EmptyPrompt(){
        GameObject prompts = canvas_2.transform.GetChild(2).gameObject;
        Text t = prompts.GetComponent<Text>();
        t.text = "";
    }

    private void PromptWin(){
        GameObject prompts = canvas_2.transform.GetChild(2).gameObject;
        Text t = prompts.GetComponent<Text>();
        t.text = "YOU HAVE WON\nEsc to Exit";
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(input_1 == -1 && input_2 == -1){Prompt(2);}
            else{
                string RV = TransferInfo();
                obj  = GameObject.Find(m_name);

                if(correct){
                    objects_added.Add(card.GetCardRV());
                    GameObject l = canvas.transform.GetChild(0).gameObject;
                    GameObject r = canvas.transform.GetChild(1).gameObject;
                    Text left = l.GetComponent<Text>();
                    Text right = r.GetComponent<Text>();
                    left.text += "\n" + RV;
                    right.text += "\n(" + objects_added.Count + ")";
                }
                
                run_num = false;
                EmptyBoard();
                Destroy(obj);
            }
        }   

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if(run_num){
            if(first_input){
            if(Input.GetKeyDown(KeyCode.Alpha1)){input_1 = 1; first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha2)){input_1 = 2;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha3)){input_1 = 3;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha4)){input_1 = 4;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha5)){input_1 = 5;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha6)){input_1 = 6;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha7)){input_1 = 7;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha8)){input_1 = 8;first_input = false;ChangeBoard(1);}
            if(Input.GetKeyDown(KeyCode.Alpha9)){input_1 = 9;first_input = false;ChangeBoard(1);}

            }else{
                if(Input.GetKeyDown(KeyCode.Alpha1)){input_2 = 1;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha2)){input_2 = 2;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha3)){input_2 = 3;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha4)){input_2 = 4;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha5)){input_2 = 5;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha6)){input_2 = 6;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha7)){input_2 = 7;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha8)){input_2 = 8;first_input = true;ChangeBoard(2);}
                if(Input.GetKeyDown(KeyCode.Alpha9)){input_2 = 9;first_input = true;ChangeBoard(2);}
            }
        }

        if(Input.GetKeyDown(KeyCode.Backspace)){
            EmptyBoard();
        }
    }

    private string TransferInfo(){
        int num =  card.GetCardValue();

        switch(num){
            case 1:
                if((input_1 == 1 && input_2 == 2) || (input_2 == 1 && input_1 == 2)){
                    single = objects_added.Count+1;
                    return "Q";
                }
                else if((input_1 == 1 && input_2 == special_index) || (input_2 == 1 && input_1 == special_index)){
                    PromptWin();
                    return "~R";
                }
                else if((input_1 == 3 && input_2 == single) ||(input_2 == 3 && input_1 == single)){
                    PromptWin();
                    return "~R";
                }
                else{
                    correct = false;
                    Prompt(1);
                    return "";
                }
            case 3:
                if((input_1 == 2 && input_2 == 3)|| (input_2 == 2 && input_1 == 3)){
                    special_index = objects_added.Count+1;
                    return "P->~R";
                }else{
                    correct = false;
                    Prompt(1);
                    return "";
                }
            case 4:
                if(input_1 == 1){
                    return "PvQ";
                }
                else if(input_1 == single){
                    return "QvR";
                }
                else{
                    correct = false;
                    Prompt(1);
                    return "";
                }
            case 5:
                if(input_1 == 2){
                    return "~PvQ";
                }
                else if(input_1 == 3){
                    return "~Qv~R";
                }
                else if(input_1 == special_index){
                    return "~Qv~R";
                }
                else{
                    correct = false;
                    Prompt(1);
                    return "";
                }
        }
        correct = false;
        Prompt(1);
        return "";
    }

    private string ProcessCardInfo(CardReader card){
        
        string n = "";

        n = card.GetCardName();

        return n;
    }
}


/*
text.text = "testing";

            Font A = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            text.font = A;
            text.fontSize = 50;
*/