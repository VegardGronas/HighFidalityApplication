using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationMethods : MonoBehaviour
{
    public void ExitApplication()
    {
        GameManager.Instance.ExitApplication();
    }
}
