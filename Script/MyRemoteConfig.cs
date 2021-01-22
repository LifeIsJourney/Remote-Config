using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;
using UnityEngine.UI;

public class MyRemoteConfig : MonoBehaviour
{
    public struct userAttribute { };
    public struct appAttribute { };

    [SerializeField] float updateVersion;
    string Update = "UpdateStr";
    [SerializeField] Transform UpdatePopupTrans;
    [SerializeField] Button updateTheAppBtn;
    // Start is called before the first frame update
    void Start()
    {
        FetchConfigData();
        updateTheAppBtn.onClick.AddListener(() => OpenStoreLink());
    }

    public void FetchConfigData()
    {
        ConfigManager.FetchCompleted += RemoteFetchComplete;
        ConfigManager.FetchConfigs<userAttribute, appAttribute>(new userAttribute(), new appAttribute());

    }

    void RemoteFetchComplete(ConfigResponse response)
    {
        switch (response.requestOrigin)
        {
            case ConfigOrigin.Default:
                //no change if file

                break;
            case ConfigOrigin.Cached:
                //current no change in file but it was changed previously

                break;
            case ConfigOrigin.Remote:
                //connection successful
                float currentVersion;
                float.TryParse(Application.version,out currentVersion);
                updateVersion = ConfigManager.appConfig.GetFloat(Update, 0f);
                if (currentVersion < updateVersion)
                {
                    //show update. Update is available
                    ShowUpdatePopUp();
                }
                break;
            default:
                break;
        }
    }
    //show update
    void ShowUpdatePopUp()
    {
        UpdatePopupTrans.gameObject.SetActive(true);
    }
    void OpenStoreLink()
    {
        Debug.Log("Opening store page");
    }
}
