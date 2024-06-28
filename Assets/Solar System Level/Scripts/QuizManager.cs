using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuesAndAns> QnA;
    public GameObject[] options;
    public int currQues;
    public int trigger_counter = 0;

    public TMPro.TMP_Text QuestionTxt;
    public TMPro.TMP_Text scoreTxt;
    
    public GameObject QuizPanel;
    public GameObject GOPanel;

    int totalQues = 0;
    public int score;
    
    private void Start(){
        totalQues = QnA.Count;
        GOPanel.SetActive(false);
        trigger_counter++;
        if (trigger_counter != 1)
        {
            QnA.RemoveAt(currQues);
        }
        generateQues();
    }
    
    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void gameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        scoreTxt.text = score + "/" + totalQues;
    }
    
    public void correct(){
        score+=1;
        QnA.RemoveAt(currQues);
        StartCoroutine(WaitForNext());
    }
    public void wrong(){
        QnA.RemoveAt(currQues);
        StartCoroutine(WaitForNext());
    }
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQues();
    }
    void SetAnswers(){
        for(int i=0;i<options.Length;i++){
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text= QnA[currQues].Answers[i];


            if(QnA[currQues].correctAns == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQues(){
        if(QnA.Count>0){
            currQues = Random.Range(0,QnA.Count);
            QuestionTxt.text = QnA[currQues].Question;
            SetAnswers();
        }
        else{
            //Debug.Log("Quiz Complete");
            gameOver();
        }
    }
        
}
