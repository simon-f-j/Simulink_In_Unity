using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Specialized;
using System.Globalization;

public class UDP_TRANSFORM : MonoBehaviour
{
    private UdpClient udpServer;
    public GameObject cube;
    //private Vector3 tempPos;
    private Thread t;
    //public float movementSpeed;
    //private long lastSend;
    private IPEndPoint remoteEP;
    private float[] transformPosition = new float[3];
    private float[] transformRotation = new float[3];

    

    // Send data to port 1234
    // format: string with 3 numbers separated by ','
    // encoding: 'utf-8'



    void Start()
    {
        udpServer = new UdpClient(1234);
        t = new Thread(() => {
            while (true)
            {
                this.receiveData();
            }
        });
        t.Start();
        t.IsBackground = true;
        remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 41234);
    }



    void Update()
    {
        transform.position = new Vector3(transformPosition[0], transformPosition[1], transformPosition[2]);
        transform.rotation = Quaternion.Euler(transformRotation[0], transformRotation[1], transformRotation[2]);
    } 

    private void OnApplicationQuit()
    {
        udpServer.Close();
        t.Abort();
    }

    private void receiveData()
    {

        byte[] data = udpServer.Receive(ref remoteEP);
        if (data.Length > 0)
        {
            var str = System.Text.Encoding.Default.GetString(data);
            Debug.Log("Received Data: " + str);
            string[] messageParts = str.Split(',');
            
            // Position
            transformPosition[0] = float.Parse(messageParts[0], CultureInfo.InvariantCulture);
            transformPosition[1] = float.Parse(messageParts[1], CultureInfo.InvariantCulture);
            transformPosition[2] = float.Parse(messageParts[2], CultureInfo.InvariantCulture);

            // Orientation
            transformRotation[0] = float.Parse(messageParts[3], CultureInfo.InvariantCulture);
            transformRotation[1] = float.Parse(messageParts[4], CultureInfo.InvariantCulture);
            transformRotation[2] = float.Parse(messageParts[5], CultureInfo.InvariantCulture);
        }
    }
}