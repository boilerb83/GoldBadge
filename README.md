"# GoldBadge" #
#--------------------------Challenge #1 (CAFE CHALLENGE)-----------------------------
Komodo Cafe

The main menu displayed shows create, delete, receive all items on the cafe menu.

The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price

#--------------------------Challenge #2 (CLAIMS CHALLENGE)----------------------------
Challenge 2: Claims
Komodo Claims Department
Komodo has a bug in its software and needs some new code.

The Claim has the following properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid
Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

A ClaimType could be the following:
Car
Home
Theft
 

The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim
For #1, a claims agent could see all items in the queue listed out like this:

ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid
1	Car	Car accident on 465.	$400.00	4/25/18	4/27/18	true
2	Home	House fire in kitchen.	$4000.00	4/11/18	4/12/18	true
3	Theft	Stolen pancakes.	$4.00	4/27/18	6/01/18	false
For #2, when a claims agent needs to deal with an item they see the next item in the queue.

Here are the details for the next claim to be handled:
ClaimID: 1
Type: Car
Description: Car Accident on 464.
Amount: $400.00
DateOfAccident: 4/25/18
DateOfClaim: 4/27/18
IsValid: True
Do you want to deal with this claim now(y/n)? y
When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:

Enter the claim id: 4
Enter the claim type: Car
Enter a claim description: Wreck on I-70.
Amount of Damage: $2000.00
Date Of Accident: 4/27/18
Date of Claim: 4/28/18
This claim is valid.


#------------------------------------Challenge #3 (BADGE ACCESS CHALLENGE)------------------------------
Komodo Insurance
The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access, like this:
Here are some views:
Menu

Hello Security Admin, What would you like to do?

Add a badge
Edit a badge.
List all Badges
#1 Add a badge
What is the number on the badge: 12345

List a door that it needs access to: A5
Any other doors(y/n)? y

List a door that it needs access to: A7
Any other doors(y/n)? n

(Return to main menu.)

#2 Update a badge
What is the badge number to update? 12345

12345 has access to doors A5 & A7.

What would you like to do?

Remove a door OR Add a door

Which door would you like to remove? A5
Door removed.

12345 has access to door A7.

#3 List all badges view
Key	
Badge #	Door Access
12345	A7
22345	A1, A4, B1, B2
32345	A4, A5
A badge class that has the following properties:
BadgeID
List of door names for access
A badge repository that will have methods that do the following:
Create a dictionary of badges.
The key for the dictionary will be the BadgeID.
The value for the dictionary will be the List of Door Names.

