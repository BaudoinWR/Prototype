using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuButtonScript : NetworkBehaviour {

	public void StartGame()
    {
        NetworkManager.singleton.ServerChangeScene("Scenes/Main");
    }
}
