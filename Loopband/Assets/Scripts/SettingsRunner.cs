using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SettingsRunner : MonoBehaviour
{ 
	public float movementSpeed = 0;
  public float lastSpeed = 0;
	SerialPort mySerialPort;

	public float MovementSpeed
	{
		get { return movementSpeed; }
	}

	private void Start()
	{
		mySerialPort = new SerialPort("COM3");
		mySerialPort.BaudRate = 9600;
		mySerialPort.Parity = Parity.None;
		mySerialPort.StopBits = StopBits.One;
		mySerialPort.DataBits = 8;
		mySerialPort.Handshake = Handshake.None;
		mySerialPort.RtsEnable = true;
		mySerialPort.ReadTimeout = 1;

		//mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

		mySerialPort.Open();
		if (mySerialPort.IsOpen)
		{
			Debug.Log("Port is opened");
		}
	}

  private void Update()
  {
    if (mySerialPort.IsOpen)
    {

      try
      {
        string inData = mySerialPort.ReadLine();
        Debug.Log(inData);
        //double inData = double.Parse(mySerialPort.ReadLine());
        //float tempSpeed = (float)inData;
        //Debug.Log(tempSpeed);
        //if ((lastSpeed - tempSpeed) < 3f || (lastSpeed - tempSpeed) > -3f)
        //{
        //  movementSpeed = tempSpeed;
        //  lastSpeed = movementSpeed;
        //}
        //else
        //{
        //  Debug.Log("difference to big");
        //}

        //if (inData != "")
        //{
        //  Debug.Log(inData);
        //}
      }
      catch (System.TimeoutException e)
      {
        return;
        throw;
      }

    }

	}

	//private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
	//{
	//  SerialPort sp = (SerialPort)sender;
	//  string indata = sp.ReadExisting();
	//  int speed = int.Parse(indata);
	//  Debug.Log(speed);
	//}
}
