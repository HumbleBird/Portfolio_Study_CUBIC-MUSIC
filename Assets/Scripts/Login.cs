using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Login : MonoBehaviour
{
    [SerializeField] InputField id = null;
    [SerializeField] InputField pw = null;

    DataBaseManager theDatabase;

    // Start is called before the first frame update
    void Start()
    {
        theDatabase = FindObjectOfType<DataBaseManager>();
        Backend.Initialize(InitializeCallback);      
    }

    void InitializeCallback()
    {
        if (Backend.IsInitialized)
        {
            Debug.Log(Backend.Utils.GetServerTime());
            Debug.Log(Backend.Utils.GetGoogleHash());
        }
        else
            Debug.Log("�ʱ�ȭ ���� (���ͳ� ���� ���)");
    }

    public void BtnResgist()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomSignUp(t_id, t_pw, "Test");

        if (bro.IsSuccess())
        {
            Debug.Log("ȸ������ �Ϸ�");
            theDatabase.LoadScore();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("ȸ������ ����");
        }
    }

    public void BtnLogin()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomLogin(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α��� �Ϸ�");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
        }
    }
}
