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
        if (create.LoadUser()) return;
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

    private FileManageMent fileManagement;
    string filePath = Application.persistentDataPath + "/Users";

    public CreateAccount(string userName, string password)
    {
        _userName = userName;

        Hash128 hash = new Hash128();
        hash.Append(password);

        _password = hash;

        fileManagement = new FileManageMent();

        user = new User(fileManagement.ReturnFiles(filePath), _userName, _password);
    }

    public void SaveUser()
    {
        if (fileManagement.VerifyUser(user, filePath)) { return; }
        string json = JsonUtility.ToJson(user);
        File.WriteAllText(filePath + "/User"+ user.constantID + ".json", json);
    }

    public bool LoadUser()
    {
        if (fileManagement.VerifyUser(user, filePath)) { Debug.Log("User exists"); return true; }
        else { Debug.Log("User does not exists"); return false; }
    }
}

public class FileManageMent
{
    public FileManageMent() { }

    public int ReturnFiles(string filePath)
    {
        var info = new DirectoryInfo(filePath);
        var fileInfo = info.GetFiles();
        return fileInfo.Length;
    }

    public bool VerifyUser(User _user, string filePath)
    {
        var info = new DirectoryInfo(filePath);
        var fileInfo = info.GetFiles();

        for (int i = 0; i < fileInfo.Length; i++)
        {
            string json = File.ReadAllText(fileInfo[i].ToString());
            User user = JsonUtility.FromJson<User>(json);

            if (_user.username == user.username && _user.password == user.password)
            {
                Debug.Log("User exists");
                return true;
            }
        }
        Debug.Log("User does not exist");
        return false;
    }

    public User ReturnUser(User _user, string filePath)
    {
        var info = new DirectoryInfo(filePath);
        var fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            Debug.Log(file.ToString());
        }
        string json = File.ReadAllText(fileInfo[0].ToString());
        User user = JsonUtility.FromJson < User > (json);
        return user;
    }
}

[Serializable]
public class User
{
    public User(int constantID, string usernam, Hash128 hash) 
    {
        this.constantID = constantID;
        this.username = usernam;
        this.password = hash;
    }
    public int constantID;
    public string username;
    public Hash128 password;
}