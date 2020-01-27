using System;
using UnityEngine;
using System.Collections.Generic;

public class ChatScript : MonoBehaviour
{
    //Chat History
    public List<string> chatHistory = new List<string>();

    //Keeps track of current message
    private string currentMessage = String.Empty;

    private void SendMessage()
    {
        if (string.IsNullOrEmpty(currentMessage.Trim()))
        {
            GetComponent<NetworkView>().RPC("ChatMessage", RPCMode.AllBuffered, new object[] { currentMessage }); //OBVIOUSLY DOES NOT WORK
            currentMessage = String.Empty;
        }
    }

    private void BottomChat()
    {
        currentMessage = GUI.TextField(new Rect(0, Screen.height - 20, 175, 20), currentMessage);
        if (GUI.Button(new Rect(200, Screen.height - 20, 75, 20), "Send"))
        {
            SendMessage();
        }
        GUILayout.Space(15);
        for (int i = chatHistory.Count - 1; i >= 0; i--)
            GUILayout.Label(chatHistory[i]);
    }

    private void TopChat()
    {
        GUILayout.Space(15);
        GUILayout.BeginHorizontal(GUILayout.Width(250));
        currentMessage = GUILayout.TextField(currentMessage);
        if (GUILayout.Button("Send"))
        {
            SendMessage();
        }
        GUILayout.EndHorizontal();
        foreach (string c in chatHistory)
            GUILayout.Label(c);
    }


    //Chatbox
    private void OnGUI()
    {
        BottomChat();
    }

    [RPC]
    public void ChatMessage(string message)
    {
        chatHistory.Add(message);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
