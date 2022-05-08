using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ClientRoutes : MonoBehaviour
{
    private ConfigRoutes configRoutes;
    private string baseUrl = "";
    public string resourceClients = "/clients";
    private string resource = "";
    
    public List<Client> clientes = new List<Client>();

    void Awake() {
        configRoutes = GetComponent<ConfigRoutes>();
        baseUrl = configRoutes.server_url;
        resource = baseUrl + resourceClients;
    }

    public void PopulateClients()
    {
        StartCoroutine(PopulateClientsAsync());
    }

    IEnumerator PopulateClientsAsync()
    {
        UnityWebRequest www = UnityWebRequest.Post(resource, "");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
        }
    }

    public void GetClients()
    {
        StartCoroutine(GetClientsAsync());
    }

    IEnumerator GetClientsAsync()
    {
        UnityWebRequest www = UnityWebRequest.Get(resource);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            clientes = JsonConvert.DeserializeObject<List<Client>>(json);
            Debug.Log(clientes.Count);
        }

    }

}
