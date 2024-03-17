using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    Animator anim;
    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    [SerializeField] private bool isOnLoginScreen;
    public bool IsOnLoginScreen { get { return isOnLoginScreen; } }

    [SerializeField] GameObject[] objectsToDisableOnBack;

    public void OnJoinButtonPressed()
    {
        Auth0Handler.Instance.JoinButtonPressed();
        PackageHandler.Instance.CreateCurrentPackageCard();
        anim.SetTrigger("Join");
    }

    public void ReturnFromJoinScreen()
    {
        anim.SetTrigger("Back");
        PackageHandler.Instance.DestroyCurrentPackage();
        Auth0Handler.Instance.ResetScreen();
        foreach (var item in objectsToDisableOnBack)
        {
            item.SetActive(false);
        }
    }

    public void OnSubscriptionSuccess()
    {
        anim.SetTrigger("Success");
    }

    public void OnSubmittedSuccess()
    {
        anim.SetTrigger("Submitted");
    }
}
