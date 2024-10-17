using System;
using System.IO.Ports;

namespace HerdSync
{
    public class SerialPortManager
    {
        private static SerialPortManager _instance;
        private SerialPort _serialPort;
        private EventHandler<RfidEventArgs> _rfidHandler;

        private SerialPortManager() { }

        public static SerialPortManager Instance => _instance ??= new SerialPortManager();

        public void Initialize(HomePageForm homePageForm)
        {
            _rfidHandler = homePageForm.HandleRfidScan;
            Subscribe(_rfidHandler);
        }

        public void OpenPort(string portName = "COM3")
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    Console.WriteLine("Serial port already open.");
                    return;
                }

                _serialPort = new SerialPort(portName)
                {
                    BaudRate = 9600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Handshake = Handshake.None
                };
                _serialPort.DataReceived += SerialPort_DataReceived;
                _serialPort.Open();
                Console.WriteLine($"Serial port {portName} opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening serial port: {ex.Message}");
            }
        }

        public void ClosePort()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;
                    _serialPort.Close();
                    Console.WriteLine("Serial port closed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing serial port: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen) return;

            string rfid = _serialPort.ReadLine().Trim();
            OnRfidScanned(new RfidEventArgs { Rfid = rfid });
        }

        public void Subscribe(EventHandler<RfidEventArgs> handler)
        {
            RfidScanned += handler;
        }

        public void Unsubscribe(EventHandler<RfidEventArgs> handler)
        {
            RfidScanned -= handler;
        }

        public event EventHandler<RfidEventArgs> RfidScanned;

        protected virtual void OnRfidScanned(RfidEventArgs e)
        {
            RfidScanned?.Invoke(this, e);
        }
    }

    public class RfidEventArgs : EventArgs
    {
        public string Rfid { get; set; }
    }
}
