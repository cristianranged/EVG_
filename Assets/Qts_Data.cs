using UnityEngine;

[CreateAssetMenu(fileName ="New QuestionData", menuName ="QuestionData")]
public class Qts_Data : ScriptableObject
{
    [System.Serializable]
    public struct Question
    {
        public string questionText;
        public string []replies;
        public int correctReplyIndex;


    }

    public Question[] questions;
}
