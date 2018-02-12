using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawnerScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("started");
        Debug.Log(NetworkManager.singleton.numPlayers);
        GameObject player = FindObjectOfType<NetworkManager>().playerPrefab;
        for (int i = 0; i < NetworkManager.singleton.numPlayers; i++)
        {
            Transform startPos = FindObjectOfType<NetworkManager>().GetStartPosition();
            GameObject instance = Instantiate(player);
            instance.transform.position = startPos.position;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
