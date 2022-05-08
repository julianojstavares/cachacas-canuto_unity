using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ListViewClients : MonoBehaviour
{
    public GameObject card;

    public GameObject content;

    private ClientRoutes clientRoutes;

    private bool loaded = true;

    private void Awake() {
        clientRoutes = GameObject.Find("Network").GetComponent<ClientRoutes>();
        
    }

    private void Start() {
        clientRoutes.GetClients();
    }

    private void Update() {
        if (clientRoutes.clientes.Count > 0) {
            Show();
            loaded = false;
        }
    }

    public void Show(){
        
        if(loaded) 
        {
            foreach (Client client in clientRoutes.clientes) 
            {
                GameObject cardInstance = Instantiate(card);
                cardInstance.transform.SetParent(content.transform);
                cardInstance.transform.localScale = Vector3.one;

                cardInstance.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = client.nome;
                cardInstance.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = "id: " + client.id;
                cardInstance.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = "data nascimento: " + client.dataNascimento.ToShortDateString();
            }

        }
    }

}
