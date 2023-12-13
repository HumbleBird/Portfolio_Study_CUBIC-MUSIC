using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [SerializeField]
    GameObject gocomboImage = null;
    [SerializeField]
    Text txtCombo = null;

    int currentCombo = 0;
    int maxCombo = 0;

    Animator myAnim;
    string animScoreUp = "ComboUp";

    void Start()
    {
        myAnim = GetComponent<Animator>();
        txtCombo.gameObject.SetActive(false);
        gocomboImage.SetActive(false);
    }

    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (maxCombo < currentCombo)
            maxCombo = currentCombo;

        if(currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            gocomboImage.SetActive(true);

            // �ִ� ����
            myAnim.SetTrigger(animScoreUp);
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        gocomboImage.SetActive(false);
    }
    public int GetMaxCombo()
    {
        return maxCombo;
    }
}
