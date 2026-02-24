# Golf Club DB

A comprehensive web application for managing golf club members and their bookings. Built with ASP.NET Core 10 and Entity Framework Core, this application provides a user-friendly interface for member management, booking creation, and advanced data filtering and sorting.

## Overview

GolfClubDB is a full-featured golf club management system that enables administrators to:
- Manage comprehensive member profiles with 18 data fields
- Track member handicaps and booking history
- Create and manage golf course bookings with up to 4 players per booking
- Filter and sort members by gender, handicap/handicap range, name, and membership number
- View booking details and member associations
- Prevent duplicate bookings and maintain data integrity

## Technology Stack

### Backend
- **Framework**: ASP.NET Core with Razor Pages
- **Language**: C# 14.0
- **Target**: .NET 10
- **ORM**: Entity Framework Core (EF Core)
- **Database**: Microsoft SQL Server LocalDB

### Frontend
- **HTML/CSS**: Bootstrap 5
- **JavaScript**: Vanilla JavaScript with jQuery validation
- **CSS Slider**: noUISlider for range filtering
- **Styling**: Custom CSS with CSS variables for theming

### Development Environment
- **IDE**: Visual Studio 2026 (Community Edition)
- **Source Control**: Git
- **Repository**: GitHub (https://github.com/MichaelMcKibbin/GolfClubDB)

## Database

### Overview
The application uses **SQL Server LocalDB** for data persistence:
- **Server**: `(localdb)\mssqllocaldb`
- **Database Name**: `GCDB`
- **Location**: `D:\VisualStudioLocal\GolfClubDB\DB\GCDB.mdf`
- **Authentication**: Windows Authentication
- **Connection**: MultipleActiveResultSets enabled for concurrent queries

### Seed Data
The application includes **automatic seed data** that populates on first run:

**10 Sample Members** (IDs 1-10):
- Diverse mix of genders, skill levels (handicap 2-25)
- Complete profiles with address, emergency contact, bio
- Membership dates ranging from 5 years ago to 3 months ago

**20 Sample Bookings** (various dates starting tomorrow):
- Bookings with 0, 1, 2, and 3 additional players (full groups)
- Tee times throughout the day (7:00 AM - 5:15 PM)
- Multiple dates and configurations for comprehensive testing
- Member IDs reference the 10 sample members

**Seed data is only created once** - when the database is empty. After that, you can add your own data and edit or delete the seed data.

### Database Schema

#### Members Table
Stores comprehensive member information:
- **Basic Info**: ID, Name (Last, First), Email, Phone Number, Gender
- **Membership**: Membership Number (unique, auto-generated with GC prefix), Membership Start Date, Membership End Date
- **Golf**: Handicap (-20 to 54 range)
- **Personal**: Date of Birth (defaults to 01/01/1901)
- **Address**: Street Address, Street Address 2, Town, County, Postcode
- **Profile**: Bio, Profile Image URL
- **Emergency**: Emergency Contact Name, Emergency Contact Phone
- **Navigation**: Foreign key relationship with Bookings (one-to-many)

#### Bookings Table
Stores golf course booking information:
- **Reference**: ID, Member ID (foreign key to Members)
- **Scheduling**: Booking Date (DateOnly), Tee Time (TimeOnly)
- **Player 1**: Auto-populated from selected member (name and handicap from Member record)
- **Players 2-4**: Optional Name and Handicap fields for additional players
- **Constraints**: Unique constraint on (Member ID, Booking Date) - prevents duplicate bookings same day

## Members Management

### Viewing Members
- **List View**: All members in sortable, filterable table
- **Columns**: Name, Membership #, Email, Gender, Handicap
- **Clickable Rows**: Click any member to view full details

### Sorting Members
- **Name**: Ascending/Descending toggle
- **Membership #**: Ascending/Descending toggle
- **Handicap**: Ascending/Descending toggle
- **Default**: Sorted by Name (ascending)
- **Persistent Filters**: Applied during sort changes

### Filtering Members

**Gender Filter** (Radio buttons):
- All (default)
- Male
- Female
- Auto-submits on change

**Handicap Range Filter**:
- **All**: -20 to 54
- **Below 10**: -20 to 10
- **11 to 20**: 11 to 20
- **Above 20**: 21 to 54
- **Custom Range**: Interactive dual-handle slider with live preview
- Auto-submits on selection

### Member Details
- **Complete Profile**: All 18 fields displayed in organized sections
- **Date Formatting**: Formatted as dd/MM/yyyy
- **Sections**: Basic Info, Address Info, Additional Info, Emergency Contact
- **Navigation**: Edit, View Member's Bookings, Return buttons

### Creating Members
- **Auto-generated**: Membership Number (GC prefix)
- **Default Values**:
  - Date of Birth: 01/01/1901
  - Membership Start Date: Today's date
- **Required Fields**: Name, Email, Phone, Gender, Handicap, Address fields
- **Validation**: Client-side (HTML5) + Server-side (data annotations)

### Editing Members
- **All Fields Editable**: Except Membership Number (read-only)
- **Full Validation**: Applied to all updates
- **Data Preserved**: Existing values maintained unless changed

## Bookings Management

### Viewing Bookings
- **List View**: All bookings sorted by date then time
- **Columns**: Member Name, Booking Date (YYYY-MM-DD), Tee Time (HH:MM)
- **Clickable**: Click any booking for details
- **Member Filter**: View only specific member's bookings

### Booking Details
- **Player 1**: Member's name & handicap from database
- **Booking Info**: Date (formatted), Tee Time
- **Additional Players**: Shows Players 2-4 if filled
- **Navigation**: View Member's Bookings, Back to Bookings

### Creating Bookings
- **Member Selection**: Required dropdown
- **Auto-fill**: Player 1 name auto-fills on selection
- **Booking Date**: 
  - Calendar picker
  - Default: Today
  - Prevents past bookings
- **Tee Time**:
  - **Dropdown Selection** (not free text)
  - **Hours**: 7:00 AM - 6:00 PM
  - **Intervals**: 15-minute increments
  - **Display**: 12-hour format with AM/PM
  - **Total Options**: 44 available times
- **Additional Players**: Optional (Players 2-4)
  - Name (optional)
  - Handicap (-20 - 54, optional)

### Booking Validation
- **Member**: Required
- **Date**: Required, cannot be past
- **Tee Time**: Required, valid 15-min interval, 7 AM-6 PM
- **Handicaps**: -20 - 54 if provided
- **Duplicate Check**: Prevents same member booking same day
- **Validation**: Client-side + Server-side

## Original Assignment Requirements

### CRUD Operations
- [x] Create (Members & Bookings)
- [x] Read (View member & booking details)
- [x] Update (Edit member information)
- [x] Delete (Available for both entities)

### Member Details
- [x] Membership Number
- [x] Name
- [x] Email
- [x] Gender
- [x] Handicap
- [x] **Plus**: Phone, DOB, Address, Emergency Contact, Bio, Profile Image

### Tee Time Bookings
- [x] 15-minute intervals (7 AM - 6 PM)
- [x] Up to 4 players per booking
- [x] Names & handicaps for all players
- [x] No duplicate bookings (same member, same day)
- [x] No past bookings allowed

### Database Queries
- [x] Gender filter (All, Male, Female)
- [x] Handicap ranges (Below 10, 11-20, Above 20, Custom)
- [x] Member bookings view
- [x] Sorting by Name, Handicap, **Membership #**

### Database
- [x] SQL Server LocalDB
- [x] Member & Booking storage
- [x] Data integrity (constraints, validation)

## Additional Features

- [x] Advanced handicap slider with live preview
- [x] Auto-submitting filters (no "Apply" button)
- [x] Preset and custom handicap ranges
- [x] Sortable table headers
- [x] Global CSS color variables
- [x] Organized form sections
- [x] Auto-filling form fields
- [x] Comprehensive member profiles (18 fields)
- [x] Member-specific booking views
- [x] Responsive Bootstrap 5 design

## Getting Started

### Prerequisites
- Visual Studio 2026 or .NET 10 SDK
- SQL Server LocalDB
- Windows Authentication

### Installation

1. Clone repository:
   ```
   git clone https://github.com/MichaelMcKibbin/GolfClubDB.git
   cd GolfClubDB
   ```

2. Open in Visual Studio and build

3. Create the database folder:
   ```powershell
   New-Item -ItemType Directory -Path "D:\VisualStudioLocal\GolfClubDB\DB" -Force
   ```

4. Apply migrations:
   ```
   dotnet ef database update
   ```
   This creates the `GCDB.mdf` database file in the DB folder and automatically populates it with 10 sample members and 20 sample bookings.

5. Run application (F5):
   ```
   dotnet run
   ```

6. Open `https://localhost:5001`

### Database Reset & Reseed (Development Only)
To clear all data and start fresh with new seed data:

```
dotnet ef database drop --force
dotnet ef database update
```

This removes the database and recreates it with the default seed data.

### Database Location
- **Files**: `GolfClubDB\DB\`
- **Data File**: `GCDB.mdf` 
- **Log File**: `GCDB_log.ldf`

If you need to move the database, update the `AttachDbFilename` path in `appsettings.json`.


### Screenshots

![Home Page](HomePage.png)
![Members Page](MembersPage.png)
![Add Member Page](AddMember.png)
![Edit Member Page](EditMember.png)
![Bookings Page](BookingsPage.png)
![Booking Details Page](BookingDetails.png)
![Create Booking Page](CreateBooking.png)

