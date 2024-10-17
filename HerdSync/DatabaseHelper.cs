using GMap.NET;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HerdSync
{
    public class DatabaseHelper
    {
        private readonly string _connectionString = "Data Source=HerdSyncDatabase.db;Version=3;";

        public DatabaseHelper()
        {
            InitializeDatabase();
            UpdateDatabaseSchema();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string createAnimalsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Animals (
                        Rfid TEXT PRIMARY KEY,
                        Name TEXT,
                        Species TEXT,
                        Origin TEXT,
                        DateOfBirth TEXT,
                        Sex TEXT,
                        Mother TEXT,
                        Father TEXT,
                        StatusUponArrival TEXT,
                        ArrivalDate TEXT,
                        StatusOfAnimal TEXT,
                        AddedDate TEXT,
                        InitialWeight REAL,
                        CurrentWeight REAL,
                        WeightGoal REAL,
                        TagId TEXT,
                        PhotoPath TEXT
                    );";

                string createScanEventsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ScanEvents (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Rfid TEXT,
                        EntryTime TEXT,
                        ExitTime TEXT
                    );";

                string createAreasTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Areas (
                        AreaName TEXT PRIMARY KEY
                    );";

                string createAreaPointsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS AreaPoints (
                        AreaName TEXT,
                        Latitude REAL,
                        Longitude REAL,
                        FOREIGN KEY (AreaName) REFERENCES Areas(AreaName)
                    );";

                using (var command = new SQLiteCommand(createAnimalsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createScanEventsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createAreasTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createAreaPointsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDatabaseSchema()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    string alterTableQuery = @"
                        ALTER TABLE Animals ADD COLUMN PhotoPath TEXT;";

                    using (var command = new SQLiteCommand(alterTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    if (!ex.Message.Contains("duplicate column name"))
                    {
                        Console.WriteLine($"SQLiteException: {ex.Message}");
                    }
                }
            }
        }

        public Animal GetAnimalByRfid(string rfid)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Animals WHERE Rfid = @Rfid";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Animal
                            {
                                Rfid = reader["Rfid"].ToString(),
                                Name = reader["Name"].ToString(),
                                Species = reader["Species"].ToString(),
                                Origin = reader["Origin"].ToString(),
                                DateOfBirth = reader["DateOfBirth"] != DBNull.Value && DateTime.TryParse(reader["DateOfBirth"].ToString(), out DateTime dob) ? dob : DateTime.MinValue,
                                Sex = reader["Sex"].ToString(),
                                Mother = reader["Mother"].ToString(),
                                Father = reader["Father"].ToString(),
                                StatusUponArrival = reader["StatusUponArrival"].ToString(),
                                ArrivalDate = reader["ArrivalDate"] != DBNull.Value && DateTime.TryParse(reader["ArrivalDate"].ToString(), out DateTime arrival) ? arrival : DateTime.MinValue,
                                StatusOfAnimal = reader["StatusOfAnimal"].ToString(),
                                AddedDate = reader["AddedDate"] != DBNull.Value && DateTime.TryParse(reader["AddedDate"].ToString(), out DateTime added) ? added : DateTime.MinValue,
                                InitialWeight = reader["InitialWeight"] != DBNull.Value && double.TryParse(reader["InitialWeight"].ToString(), out double initialWeight) ? initialWeight : 0.0,
                                CurrentWeight = reader["CurrentWeight"] != DBNull.Value && double.TryParse(reader["CurrentWeight"].ToString(), out double currentWeight) ? currentWeight : 0.0,
                                WeightGoal = reader["WeightGoal"] != DBNull.Value && double.TryParse(reader["WeightGoal"].ToString(), out double weightGoal) ? weightGoal : 0.0,
                                TagId = reader["TagId"].ToString(),
                                PhotoPath = reader["PhotoPath"] != DBNull.Value ? reader["PhotoPath"].ToString() : string.Empty // Ensure this column exists
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Animal GetAnimalByName(string name)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Animals WHERE Name = @Name";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Animal
                            {
                                Rfid = reader["Rfid"].ToString(),
                                Name = reader["Name"].ToString(),
                                Species = reader["Species"].ToString(),
                                Origin = reader["Origin"].ToString(),
                                DateOfBirth = reader["DateOfBirth"] != DBNull.Value && DateTime.TryParse(reader["DateOfBirth"].ToString(), out DateTime dob) ? dob : DateTime.MinValue,
                                Sex = reader["Sex"].ToString(),
                                Mother = reader["Mother"].ToString(),
                                Father = reader["Father"].ToString(),
                                StatusUponArrival = reader["StatusUponArrival"].ToString(),
                                ArrivalDate = reader["ArrivalDate"] != DBNull.Value && DateTime.TryParse(reader["ArrivalDate"].ToString(), out DateTime arrival) ? arrival : DateTime.MinValue,
                                StatusOfAnimal = reader["StatusOfAnimal"].ToString(),
                                AddedDate = reader["AddedDate"] != DBNull.Value && DateTime.TryParse(reader["AddedDate"].ToString(), out DateTime added) ? added : DateTime.MinValue,
                                InitialWeight = reader["InitialWeight"] != DBNull.Value && double.TryParse(reader["InitialWeight"].ToString(), out double initialWeight) ? initialWeight : 0.0,
                                CurrentWeight = reader["CurrentWeight"] != DBNull.Value && double.TryParse(reader["CurrentWeight"].ToString(), out double currentWeight) ? currentWeight : 0.0,
                                WeightGoal = reader["WeightGoal"] != DBNull.Value && double.TryParse(reader["WeightGoal"].ToString(), out double weightGoal) ? weightGoal : 0.0,
                                TagId = reader["TagId"].ToString(),
                                PhotoPath = reader["PhotoPath"] != DBNull.Value ? reader["PhotoPath"].ToString() : string.Empty // Ensure this column exists
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateAnimalPhotoPath(string rfid, string photoPath)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Animals SET PhotoPath = @PhotoPath WHERE Rfid = @Rfid";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhotoPath", photoPath ?? (object)DBNull.Value); // Set to NULL if no path
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetAllUniqueNames()
        {
            var names = new List<string>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Name FROM Animals;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return names;
        }

        public int GetTotalAnimalCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Animals;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int GetAnimalsOutsideCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(DISTINCT Rfid) FROM ScanEvents WHERE ExitTime IS NULL;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<string> GetAllUniqueRfids()
        {
            var rfids = new List<string>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Rfid FROM Animals;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rfids.Add(reader["Rfid"].ToString());
                        }
                    }
                }
            }
            return rfids;
        }

        public string GetNameByRfid(string rfid)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Name FROM Animals WHERE Rfid = @Rfid";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        public void InsertScanEvent(ScanEvent scanEvent)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO ScanEvents (Rfid, EntryTime, ExitTime)
                    VALUES (@Rfid, @EntryTime, @ExitTime)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", scanEvent.Rfid);
                    command.Parameters.AddWithValue("@EntryTime", scanEvent.EntryTime);
                    command.Parameters.AddWithValue("@ExitTime", scanEvent.ExitTime);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateScanEvent(ScanEvent scanEvent)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE ScanEvents
                    SET ExitTime = @ExitTime
                    WHERE Rfid = @Rfid AND ExitTime IS NULL";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", scanEvent.Rfid);
                    command.Parameters.AddWithValue("@ExitTime", scanEvent.ExitTime);
                    command.ExecuteNonQuery();
                }
            }

            var exitCount = GetScanEventsByRfid(scanEvent.Rfid).Count(e => e.ExitTime.HasValue && e.ExitTime.Value.Date == scanEvent.ExitTime.Value.Date);
            if (exitCount > 1)
            {
                MessageBox.Show("Multiple exit events detected for the same RFID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void InsertOrUpdateScanEvent(string rfid)
        {
            var lastEvent = GetScanEventsByRfid(rfid);
            var now = DateTime.Now;
            if (lastEvent != null && lastEvent.Count > 0)
            {
                var lastScanEvent = lastEvent.OrderByDescending(e => e.EntryTime).FirstOrDefault();
                if (lastScanEvent != null)
                {
                    if (lastScanEvent.EntryTime.Date == now.Date && lastScanEvent.EntryTime.TimeOfDay == now.TimeOfDay)
                    {
                        // Ignore duplicate scan within the same 5 seconds
                        return;
                    }
                }
            }

            if (lastEvent == null || lastEvent.Count == 0 || lastEvent[^1].ExitTime.HasValue)
            {
                var scanEvent = new ScanEvent
                {
                    Rfid = rfid,
                    EntryTime = now
                };
                InsertScanEvent(scanEvent);
            }
            else
            {
                var scanEvent = lastEvent[^1];
                scanEvent.ExitTime = now;
                UpdateScanEvent(scanEvent);

                if (lastEvent.Count(e => !e.ExitTime.HasValue) > 1)
                {
                    MessageBox.Show("Multiple entry events detected for the same RFID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void RemoveArea(string areaName)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deletePointsQuery = "DELETE FROM AreaPoints WHERE AreaName = @AreaName";
                        using (var command = new SQLiteCommand(deletePointsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AreaName", areaName);
                            command.ExecuteNonQuery();
                        }

                        string deleteAreaQuery = "DELETE FROM Areas WHERE AreaName = @AreaName";
                        using (var command = new SQLiteCommand(deleteAreaQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AreaName", areaName);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Failed to remove area", ex);
                    }
                }
            }
        }

        public List<ScanEvent> GetScanEventsByRfid(string rfid)
        {
            var scanEvents = new List<ScanEvent>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Rfid, EntryTime, ExitTime FROM ScanEvents WHERE Rfid = @Rfid;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rfid", rfid);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var scanEvent = new ScanEvent
                            {
                                Rfid = reader["Rfid"].ToString(),
                                EntryTime = DateTime.Parse(reader["EntryTime"].ToString()),
                                ExitTime = reader["ExitTime"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["ExitTime"].ToString()) : null
                            };
                            scanEvents.Add(scanEvent);
                        }
                    }
                }
            }
            return scanEvents;
        }

        public void DeleteAllRecords()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM ScanEvents;";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveArea(string areaName, List<PointLatLng> points, string address)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertAreaQuery = "INSERT OR REPLACE INTO Areas (AreaName, Address) VALUES (@AreaName, @Address)";
                        using (var command = new SQLiteCommand(insertAreaQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AreaName", areaName);
                            command.Parameters.AddWithValue("@Address", address);
                            command.ExecuteNonQuery();
                        }

                        string deletePointsQuery = "DELETE FROM AreaPoints WHERE AreaName = @AreaName";
                        using (var command = new SQLiteCommand(deletePointsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AreaName", areaName);
                            command.ExecuteNonQuery();
                        }

                        string insertPointQuery = "INSERT INTO AreaPoints (AreaName, Latitude, Longitude) VALUES (@AreaName, @Latitude, @Longitude)";
                        foreach (var point in points)
                        {
                            using (var command = new SQLiteCommand(insertPointQuery, connection))
                            {
                                command.Parameters.AddWithValue("@AreaName", areaName);
                                command.Parameters.AddWithValue("@Latitude", point.Lat);
                                command.Parameters.AddWithValue("@Longitude", point.Lng);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Failed to save area", ex);
                    }
                }
            }
        }

        public List<PointLatLng> LoadAreaPoints(string areaName)
        {
            var points = new List<PointLatLng>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Latitude, Longitude FROM AreaPoints WHERE AreaName = @AreaName";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AreaName", areaName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double lat = reader.GetDouble(0);
                            double lng = reader.GetDouble(1);
                            points.Add(new PointLatLng(lat, lng));
                        }
                    }
                }
            }
            return points;
        }

        public List<string> GetSavedAreaNames()
        {
            var areaNames = new List<string>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT AreaName FROM Areas";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            areaNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return areaNames;
        }

        public List<(string Name, string Address)> GetSavedAreaNamesWithAddresses()
        {
            var areaDetails = new List<(string Name, string Address)>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT AreaName, Address FROM Areas";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["AreaName"].ToString();
                            var address = reader["Address"].ToString();
                            areaDetails.Add((name, address));
                        }
                    }
                }
            }
            return areaDetails;
        }

        public List<(string Name, string Species)> GetNewAnimalsForCurrentMonth()
        {
            var newAnimals = new List<(string Name, string Species)>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT Name, Species 
                    FROM Animals 
                    WHERE strftime('%Y-%m', AddedDate) = strftime('%Y-%m', 'now')";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string species = reader["Species"].ToString();
                            newAnimals.Add((name, species));
                        }
                    }
                }
            }
            return newAnimals;
        }

        public List<Animal> GetAnimalsOutsideList()
        {
            List<Animal> animalsOutside = new List<Animal>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT a.Rfid, a.Name, a.Species
                    FROM Animals a
                    INNER JOIN ScanEvents se ON a.Rfid = se.Rfid
                    WHERE se.ExitTime IS NULL
                    GROUP BY a.Rfid, a.Name, a.Species"; // Group by to ensure unique animals

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Animal animal = new Animal
                            {
                                Rfid = reader["Rfid"].ToString(),
                                Name = reader["Name"].ToString(),
                                Species = reader["Species"].ToString(),
                                // Add more properties if needed
                            };
                            animalsOutside.Add(animal);
                        }
                    }
                }
            }

            return animalsOutside;
        }

        public void UpdateAreaType(string areaName, string areaType)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Areas SET AreaType = @AreaType WHERE AreaName = @AreaName";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AreaType", areaType);
                    command.Parameters.AddWithValue("@AreaName", areaName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public string GetAreaType(string areaName)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT AreaType FROM Areas WHERE AreaName = @AreaName";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AreaName", areaName);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }
    }

    public class Animal
    {
        public string Rfid { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Origin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string StatusUponArrival { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string StatusOfAnimal { get; set; }
        public DateTime AddedDate { get; set; }
        public double InitialWeight { get; set; }
        public double CurrentWeight { get; set; }
        public double WeightGoal { get; set; }
        public string TagId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string PhotoPath { get; set; } // New property to store the photo path
    }

    public class ScanEvent
    {
        public int Id { get; set; }
        public string Rfid { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
    }
}
