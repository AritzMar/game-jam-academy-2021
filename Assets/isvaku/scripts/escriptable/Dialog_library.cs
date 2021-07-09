using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new DialogLibrary", menuName = "GJ/Dialog/Library", order = 0)]


public class Dialog_library : ScriptableObject
{
    [System.Serializable]
    public class Condition
    {
        public string Situation;
        public List<string> Dialogs = new List<string>();
    }

    public string PersonSqpeaking;
    public Condition[] conditions;

    public List<string> GetDialogsBySituation(string situation)
    {
        Condition tempCondition = Array.Find(conditions, condition => condition.Situation == situation);
        return tempCondition.Dialogs;
    }
}