using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0; // 1분당 비트 수
    double currentTime = 0d;

    [SerializeField]
    Transform tFNoteAppear = null;


    TimingManager theTimingManger;
    EffectManager theEffectManager;
    ComboManager theComboManager;

    void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManger = GetComponent<TimingManager>();
        theComboManager = FindObjectOfType<ComboManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isStartGame)
        {
            currentTime += Time.deltaTime;

            if(currentTime >= 60d / bpm)
            {
                GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                t_note.transform.position = tFNoteAppear.position;
                t_note.SetActive(true);
                theTimingManger.boxNoteList.Add(t_note);
                currentTime -= 60d / bpm;

            }
        }
            


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                theTimingManger.MissRecord();
                theComboManager.ResetCombo();
                theEffectManager.JudgementEffect(4);
            }


            theTimingManger.boxNoteList.Remove(collision.gameObject);


            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    public void RemoveNote()
    {
        GameManager.instance.isStartGame = false;

        for (int i = 0; i < theTimingManger.boxNoteList.Count; i++)
        {
            theTimingManger.boxNoteList[i].SetActive(false);
            ObjectPool.instance.noteQueue.Enqueue(theTimingManger.boxNoteList[i]);
        }

        theTimingManger.boxNoteList.Clear();
    }
}
