using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;

public class Connection : MonoBehaviour
{
  WebSocket websocket;
  
  struct Params
  {
    public String actor, direction, value;
  }
  
  async void Start()
  {
    websocket = new WebSocket("ws://127.0.0.1:8080");

    websocket.OnOpen += () =>
    {
      Debug.Log("Connection open!");
    };

    websocket.OnError += (e) =>
    {
      Debug.Log("Error! " + e);
    };

    websocket.OnClose += (e) =>
    {
      Debug.Log("Connection closed!");
    };

    websocket.OnMessage += (bytes) =>
    {
      // Debug.Log("OnMessage!");
      // Debug.Log(bytes);

      var message = System.Text.Encoding.UTF8.GetString(bytes);
      // Debug.Log("OnMessage! " + message);
      DirectCommand(message);


    };

    // Keep sending messages at every 0.3s
    // InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

    // waiting for messages
    await websocket.Connect();
  }

  void Update()
  {
    #if !UNITY_WEBGL || UNITY_EDITOR
      websocket.DispatchMessageQueue();
    #endif
  }

  async void SendWebSocketMessage()
  {
    if (websocket.State == WebSocketState.Open)
    {
      // Sending bytes
      await websocket.Send(new byte[] { 10, 20, 30 });

      // Sending plain text
      await websocket.SendText("plain text message");
    }
  }

  private async void OnApplicationQuit()
  {
    await websocket.Close();
  }

  private static void DirectCommand(String msg)
  {
    // Parse message
    Params p = new Params();
    object pbox = (object)p;
    Vector3 movement;
    Vector3 pastMovement = new Vector3(0.0f, 0.0f, 0.0f);
    float rotation = 0.0f;

    string[] args = msg.Split(new char[] { ' ', '_', }, StringSplitOptions.RemoveEmptyEntries);

    typeof(Params).GetField("actor").SetValue(pbox, args[0]);
    typeof(Params).GetField("direction").SetValue(pbox, args[1]);
    typeof(Params).GetField("value").SetValue(pbox, args[2]);
    p = (Params)pbox;

    String outputInfo = "Directing " + p.actor + " to move " + p.direction + " amount " + p.value;
    Debug.Log(outputInfo);


    // Delegate movement
    GameObject player = GameObject.Find("Player");

    if(p.actor == "dr")
    {
      // Convert Param to movement

      if(p.direction == "fwd")
      {
        player.SendMessage("Accelerate", float.Parse(p.value));
      }

      if(p.direction == "rev")
      {
        player.SendMessage("Accelerate", - float.Parse(p.value));
      }

      if(p.direction == "rgt")
      {
        player.SendMessage("Turn", float.Parse(p.value));
      }

      if(p.direction == "lft")
      {
        player.SendMessage("Turn", - float.Parse(p.value));
      }
      
      if(p.direction == "up")
      {
        player.SendMessage("Upward", float.Parse(p.value));
      }
    }
  }


}