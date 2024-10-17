<h1>HerdSync</h1>
HerdSync is a comprehensive livestock management system designed to help farmers and animal caretakers manage and track their animals efficiently. The application provides features such as adding and maintaining animal records, assigning RFID tags, recording animal weights, and managing field areas for grazing and cropping. HerdSync also allows users to upload and manage animal photos for easy identification.

Features
1. Animal Records:
Add, view, and manage detailed records of each animal, including:
RFID
Name
Species
Gender
Age (calculated from the date of birth)
Origin (where the animal came from)
Purchase date
Initial and current weight
Weight goal
Tag ID for each animal
Search animals by RFID or Name to view their records.
Upload and remove animal photos.

2. Area Management:
Save and manage areas of land used for different purposes (cropping, grazing, etc.).
Mark areas on the map and assign a type (e.g., grazing, resting, etc.).
Save the address and location points of the area.
View and edit saved areas.
Remove areas that are no longer needed.

3. RFID Scanning:
Track animal entries and exits using RFID tags.
Automatically create entry and exit logs for each animal with timestamped scan events.
View which animals are currently outside.

4. User Management:
Sign Up and Sign In functionality for users.
Contact information form for customer support.
Ability to log out and exit the application.

5. Map Integration:
Interactive map to visualize farm areas and locations of marked areas.
Integrated with Google Maps using a valid API key for geocoding and map services.

7. Features Overview:
Users can click the Features button on the homepage to get a complete list of the application's features and understand its capabilities.

Installation:
1. Clone the repository

2. Requirements:
.NET Framework 4.8 or later
SQLite for database management
Google Maps API key (replace with your own API key in the code)

3. Setup Database:
The application uses an SQLite database (HerdSyncDatabase.db). The database schema is initialized automatically when the app is run for the first time.

4. Run the Application:
Open the project in Visual Studio and build the solution.
Run the application using MainForm.cs as the entry point.

How to Use

1. Animal Records:
Add animals by filling out the necessary fields like RFID, Name, Species, etc.
Search for animals using their RFID or Name to view and manage their records.
Upload animal photos for easier identification.

2. Area Management:
Add a new area by marking a location on the map and providing details such as the address and usage type.
View and edit saved areas or remove them when necessary.

3. RFID Scanning:
Track the movement of animals by scanning their RFID tags.
View records of animals that are currently outside or inside the designated areas.

4. User Interaction:
Users can sign in or sign up for a new account.
Click the Features button on the homepage to learn more about the application's capabilities.
