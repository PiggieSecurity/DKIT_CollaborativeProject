using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class QuestList : MonoBehaviour
{
    public TMP_Text InfoText;
    public TMP_Text QuestListText;
    public TimeManager TM;

    private void Start()
    {
        WriteBook();
    }
    private void Update()
    {
        WriteBook();
    }

    void WriteBook()
    {
        InfoText.text = "In this book you will see the tasks you should do when helping someone.";
        QuestListText.text = "todo\n";
        if (!TM.CallAmbulance)
        {
            QuestListText.text += "Call emergency services\n";
        }
        if (!TM.administerEpiPen)
        {
            QuestListText.text += "administer EpiPen\n";
        }
    }
}
