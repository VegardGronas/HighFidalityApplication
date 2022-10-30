using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class AccountManager : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI password;
    public TextMeshProUGUI passwordVerification;

    public GameObject activeWindow;

    public void CreateNewAccount()
    {
        if (password.text != passwordVerification.text) 
        {   
            return;
        } 
        CreateAccount create = new CreateAccount(username.text, password.text);
        create.SaveUser();
        GameManager.Instance.SetActiveWindow(activeWindow);
    }

    public void LoadAccount()
    {
        CreateAccount create = new CreateAccount(username.text, password.text);

        if (create.LoadUser())
        {
            GameManager.Instance.currentUser = create.user;
            GameManager.Instance.designPorfile.userName = create.user.username;
            GameManager.Instance.SetActiveWindow(activeWindow);
        }
        else Debug.Log("Wrong credentials");
    }
}

public class CreateAccount
{
    public User user;
    private string _userName;
    private Hash128 _password;

    public CreateAccount(string userName, string password)
    {
        _userName = userName;

        Hash128 hash = new Hash128();
        hash.Append(password);

        _password = hash;

        user = new User(_userName, _password);
    }

    public void SaveUser()
    {
        User user = new User(_userName, _password);
        string json = JsonUtility.ToJson(user);
        if(File.Exists(Application.persistentDataPath + "/User.json")) File.WriteAllText(Application.persistentDataPath + "/User.json", json);
        Debug.Log("User saved " + user.username);
    }

    public bool LoadUser()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/User.json");
        User _user = JsonUtility.FromJson<User>(json);
        if (_userName != _user.username) return false;
        else if (_password != _user.password) return false;
        else return true;
    }
}

[Serializable]
public class User
{
    public User(string usernam, Hash128 hash) 
    {
        this.username = usernam;
        this.password = hash;
    }
    public string username;
    public Hash128 password;
}