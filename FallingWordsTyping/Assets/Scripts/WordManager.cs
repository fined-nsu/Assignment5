using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;

    public static int score;
    public static int lives = 3;

    private bool hasActiveWord;
    private Word activeWord;
    //private HighScore newHighScore;


    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        //Debug.Log(word.word);

        words.Add(word);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            score++;
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}