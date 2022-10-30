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

    public void CreateNewAccount()
    {
        if (password.text != passwordVerification.text) 
        {   
            return;
        } 
        CreateAccount create = new CreateAccount(username.text, passwordVerification.text);
    }
}

public class CreateAccount
{
    private User user;
    public CreateAccount(string userName, string password)
    {
        Hash128 hash = new Hash128();
        hash.Append(password);


        user = new User(userName, hash);
        Debug.Log("User " + userName + " Has generated " + hash);

        SaveUser(user);
    }

    private void SaveUser(User user)
    {
        string json = JsonUtility.ToJson(user);
        File.WriteAllText(Application.persistentDataPath + "/User.json", json);
        Debug.Log("User saved");
    }
}

public class Authenticator
{

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