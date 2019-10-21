using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class enemyscript : MonoBehaviour
{
    bool var1 = false;
    bool var2 = false;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://devjams1.firebaseio.com/");
    }
    // Update is called once per frame
    void Update()
    {
        string d1, d2, d3, d4;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
          .GetReference("ESP8266_Test").Child("Navigate to").Child("Direction1")
          .GetValueAsync().ContinueWith(task1 => {
              d1 = task1.Result.GetRawJsonValue();
              if (task1.IsFaulted)
              {
              // Handle the error...
          }
              else if (task1.IsCompleted)
              {
                  print(task1.Result);
              // Do something with snapshot...
          }
              if(d1=="1")
              {
                  var1 = false;
                  var2 = false;
                  transform.Translate(Vector3.forward * 10f * Time.deltaTime);
              }
          });
            FirebaseDatabase.DefaultInstance
          .GetReference("ESP8266_Test").Child("Navigate to").Child("Direction2")
          .GetValueAsync().ContinueWith(task2 => {
              d2 = task2.Result.GetRawJsonValue();
              if (task2.IsFaulted)
              {
              // Handle the error...
          }
              else if (task2.IsCompleted)
              {
                  print(task2.Result);
              // Do something with snapshot...
          }
              if (d2 == "1")
              {
                  var1 = false;
                  var2 = false;
                  transform.Translate(-Vector3.forward * 10f * Time.deltaTime);
              }
              
          });
            FirebaseDatabase.DefaultInstance
          .GetReference("ESP8266_Test").Child("Navigate to").Child("Direction3")
          .GetValueAsync().ContinueWith(task3 => {
              d3 = task3.Result.GetRawJsonValue();
              if (task3.IsFaulted)
              {
              // Handle the error...
          }
              else if (task3.IsCompleted)
              {
                  print(d3);
              // Do something with snapshot...
          }
              if (d3 == "1" && var1==false)
              {
                  var2 = false;
                  var1 = true;
                  transform.eulerAngles += new Vector3(0, 90f, 0);
              }
              else if(d3=="1" && var1==true)
              {
                  transform.Translate(Vector3.forward * 10f * Time.deltaTime);
              }
          });
        FirebaseDatabase.DefaultInstance
      .GetReference("ESP8266_Test").Child("Navigate to").Child("Direction4")
      .GetValueAsync().ContinueWith(task4 =>
      {
          d4 = task4.Result.GetRawJsonValue();
          if (task4.IsFaulted)
          {
              // Handle the error...
          }
          else if (task4.IsCompleted)
          {
              print(task4.Result);
              // Do something with snapshot...
          }
          if (d4 == "1" && var2 == false)
          {
              var1 = false; 
              var2 = true;
              transform.eulerAngles += new Vector3(0, 90f, 0);
          }
          else if (d4 == "1" && var2 == true)
          {
              transform.Translate(Vector3.forward * 10f * Time.deltaTime);
          }
         });
    }
}
