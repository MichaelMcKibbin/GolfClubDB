# ASP.NET Assignment2: Golf Club DB

Due Date: March 2nd

Develop a small website for a local golf club using ASP.NET 9/10 The application should enable users to perform the following operations on golfers' details:  
Create (Insert), Read (View), Update, Delete

You may implement this functionality using either Razor or Blazor.

## Member Details:
Each club member's profile should include:  
Membership Number, Name, Email, Gender, Handicap

## Tee Time Bookings:
The system should allow members to book tee times with the following specifications:  
### Intervals: 
Every 15 minutes starting from the hour (e.g., 9:00, 9:15, 9:30, 9:45).

### Group Size: 
Up to four players per tee time.

### Booking Details: 
Store the names and handicaps of up to four players for each slot.

### Booking Restriction: 
Members cannot book more than one game per day.

### Database Queries:
Provide users with the ability to query the database based on:
- Member Gender
- Handicap Ranges:
  - Below 10
  - Between 11 and 20
  - Above 20


### Member Bookings: 
View all bookings for a selected member.

### Sorting Options:
Implement sorting features for:
- Members by Name: Both ascending and descending order.
- Members by Handicap: Both ascending and descending order.

### Database Requirements:
- Database System: Use SQL Server to store member and booking details.

### Additional Data: 
You have the discretion to add any additional fields necessary for members and bookings.

### Validation:
Ensure that the application includes input validation on both the client-side and server-side to maintain data integrity and provide a smooth user experience.

### Marking scheme 
- Integrated CRUD application Create members/bookings 5% 
- Update members/bookings details 5% 
- Delete members/bookings details 5% 
- System queries View all members/ View by Gender 5% 
- View golfers with H/Caps below 10 5% 
- View golfers with H/Caps above 20 5% 
- View golfers with H/Caps between 11 and 20 5% 
- Golfers individual bookings 10% 
- Sorts name / Handicap 20% 
- Validation Member details 10% 
- Tee bookings 5% 
- Golf webpage GUI 20%

