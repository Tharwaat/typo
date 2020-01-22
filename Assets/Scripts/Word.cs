using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    private WordDisplay display;
    
    public Word(string word, WordDisplay display){
        this.word = word;
        typeIndex = 0;
        this.display = display;
        this.display.SetWord(this.word);
    }    

    public char GetNextLetter(){
        return this.word[typeIndex];
    }

    public void TypeLetter(){
        this.typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped(){
        bool finished = (typeIndex >= word.Length);
        if (finished){
            display.RemoveWord();
        }
        return finished;
    }
}
