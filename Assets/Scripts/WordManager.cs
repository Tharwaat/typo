using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner spawner;
    private bool hasActiveWord;
    private Word ActiveWord;
    
    public void AddWord(){
        Word word = new Word(WordGenerator.GetRandomWord(), spawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeLetter(char letter){
        if (hasActiveWord){
            if (ActiveWord.GetNextLetter() == letter) ActiveWord.TypeLetter();
        }
        else{
            foreach (Word word in words){
                if (word.GetNextLetter() == letter){
                    hasActiveWord = true;
                    ActiveWord = word;
                    word.TypeLetter();
                    break;
                }
            }
        } 

        if (hasActiveWord && ActiveWord.WordTyped()){
            hasActiveWord = false;
            words.Remove(ActiveWord);
        }
    }
}
