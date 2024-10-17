using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HerdSync
{
    public partial class LivestockMonitor : Form
    {
        private DatabaseHelper _databaseHelper;
        private HomePageForm _homePageForm;
        private static LivestockMonitor _instance;

        private TimeSpan _entryStartTime;
        private TimeSpan _entryEndTime;
        private TimeSpan _exitStartTime;
        private TimeSpan _exitEndTime;

        public LivestockMonitor(HomePageForm homePageForm)
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper();
            _homePageForm = homePageForm;
            InitializeTimer();
            SerialPortManager.Instance.Subscribe(Instance_RfidScanned);
            SerialPortManager.Instance.OpenPort();

            this.Load += LivestockMonitor_Load;
        }

        public static LivestockMonitor GetInstance(HomePageForm homePageForm)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new LivestockMonitor(homePageForm);
            }
            return _instance;
        }

        private void InitializeTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void LivestockMonitor_Load(object sender, EventArgs e)
        {
            LoadRfidRecords();
            LoadAnimalStatus();
        }

        private void Instance_RfidScanned(object sender, RfidEventArgs e)
        {
            if (DateTime.Now.TimeOfDay >= _entryStartTime && DateTime.Now.TimeOfDay <= _entryEndTime)
            {
                HandleRfidScan(e.Rfid, true);
            }
            else if (DateTime.Now.TimeOfDay >= _exitStartTime && DateTime.Now.TimeOfDay <= _exitEndTime)
            {
                HandleRfidScan(e.Rfid, false);
            }
        }

        public void HandleRfidScan(string rfidValue, bool isEntry)
        {
            Console.WriteLine($"Handling RFID Scan: {rfidValue}");
            var lastEvent = _databaseHelper.GetScanEventsByRfid(rfidValue);

            if (isEntry)
            {
                if (lastEvent == null || lastEvent.Count == 0 || lastEvent[^1].ExitTime.HasValue)
                {
                    var scanEvent = new ScanEvent
                    {
                        Rfid = rfidValue,
                        EntryTime = DateTime.Now
                    };
                    _databaseHelper.InsertScanEvent(scanEvent);
                }
                else
                {
                    Console.WriteLine("Multiple entry detected, discarding...");
                }
            }
            else
            {
                if (lastEvent != null && lastEvent.Count > 0 && !lastEvent[^1].ExitTime.HasValue)
                {
                    var scanEvent = lastEvent[^1];
                    scanEvent.ExitTime = DateTime.Now;
                    _databaseHelper.UpdateScanEvent(scanEvent);
                }
                else
                {
                    Console.WriteLine("Multiple exit detected, discarding...");
                }
            }

            LoadRfidRecords();
            LoadAnimalStatus();
            _homePageForm.UpdateAnimalsOutsideSummary();
        }

        private void LoadRfidRecords()
        {
            Console.WriteLine("Loading RFID records...");
            var rfidDataTable = new DataTable();
            rfidDataTable.Columns.Add("Rfid", typeof(string));
            rfidDataTable.Columns.Add("Name", typeof(string));
            rfidDataTable.Columns.Add("Entry Time", typeof(string));
            rfidDataTable.Columns.Add("Exit Time", typeof(string));

            var records = _databaseHelper.GetAllUniqueRfids();
            foreach (var rfid in records)
            {
                var scanEvents = _databaseHelper.GetScanEventsByRfid(rfid);
                foreach (var scanEvent in scanEvents)
                {
                    var row = rfidDataTable.NewRow();
                    row["Rfid"] = scanEvent.Rfid;
                    row["Name"] = _databaseHelper.GetNameByRfid(scanEvent.Rfid);
                    row["Entry Time"] = scanEvent.EntryTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row["Exit Time"] = scanEvent.ExitTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
                    rfidDataTable.Rows.Add(row);
                    Console.WriteLine($"Added row: {row["Rfid"]}, {row["Entry Time"]}, {row["Exit Time"]}");
                }
            }

            dgvRecords.Invoke((MethodInvoker)delegate
            {
                dgvRecords.DataSource = rfidDataTable;
                dgvRecords.Refresh();
            });
        }

        private void LoadAnimalStatus()
        {
            Console.WriteLine("Loading Animal Status...");
            var animalStatusTable = new DataTable();
            animalStatusTable.Columns.Add("Rfid", typeof(string));
            animalStatusTable.Columns.Add("Status", typeof(string));

            var records = _databaseHelper.GetAllUniqueRfids();
            foreach (var rfid in records)
            {
                var row = animalStatusTable.NewRow();
                row["Rfid"] = rfid;
                row["Status"] = DetermineCurrentStatus(rfid);
                animalStatusTable.Rows.Add(row);
            }

            dgvAnimalStatus.Invoke((MethodInvoker)delegate
            {
                dgvAnimalStatus.DataSource = animalStatusTable;
                dgvAnimalStatus.Refresh();
                FormatStatusColumn();
            });
        }

        private string DetermineCurrentStatus(string rfid)
        {
            var lastEvent = _databaseHelper.GetScanEventsByRfid(rfid);
            if (lastEvent != null && lastEvent.Count > 0 && lastEvent[^1].ExitTime == null)
            {
                return "Inside";
            }
            return "Outside";
        }


        private void FormatStatusColumn()
        {
            foreach (DataGridViewRow row in dgvAnimalStatus.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    if (row.Cells["Status"].Value.ToString() == "Inside")
                    {
                        row.Cells["Status"].Style.BackColor = Color.Green;
                    }
                    else if (row.Cells["Status"].Value.ToString() == "Outside")
                    {
                        row.Cells["Status"].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SerialPortManager.Instance.ClosePort();
            this.Hide();
            HomePageForm.GetInstance(_homePageForm.MainFormInstance, _homePageForm.CurrentUser).Show();
        }

        private void btnClearRecords_Click(object sender, EventArgs e)
        {
            _databaseHelper.DeleteAllRecords();
            LoadRfidRecords();
            LoadAnimalStatus();
            Console.WriteLine("All records have been cleared.");
        }

        private void btnSetEntryParameters_Click(object sender, EventArgs e)
        {
            _entryStartTime = dtpEntryStartTime.Value.TimeOfDay;
            _entryEndTime = dtpEntryEndTime.Value.TimeOfDay;
            Console.WriteLine($"Entry time parameters set: {_entryStartTime} - {_entryEndTime}");
        }

        private void btnSetExitParameters_Click(object sender, EventArgs e)
        {
            _exitStartTime = dtpExitStartTime.Value.TimeOfDay;
            _exitEndTime = dtpExitEndTime.Value.TimeOfDay;
            Console.WriteLine($"Exit time parameters set: {_exitStartTime} - {_exitEndTime}");
        }

        public List<AnimalStatus> GetAnimalsOutsideFromGrid()
        {
            List<AnimalStatus> animalsOutside = new List<AnimalStatus>();

            foreach (DataGridViewRow row in dgvAnimalStatus.Rows)
            {
                if (row.Cells["Status"].Value != null && row.Cells["Status"].Value.ToString() == "Outside")
                {
                    animalsOutside.Add(new AnimalStatus
                    {
                        Rfid = row.Cells["Rfid"].Value.ToString(),
                        Status = row.Cells["Status"].Value.ToString()
                    });
                }
            }

            return animalsOutside;
        }

        public class AnimalStatus
        {
            public string Rfid { get; set; }
            public string Status { get; set; }
        }
    }
}
