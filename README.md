# BookLibraryApi
Book library api created in .NET

## Documentation

### Introduction
BookLibraryApi is api for book libraries. This api can make possible tracking books, reservations, users, memberships etc.

- If user is unauthorized his only available action is to login or register.
- If user is authorized he can preform different actions defined in RoleUserCase table.

### Database schema
![alt text](https://raw.githubusercontent.com/nciganovic/BookLibraryApi/main/db.png)

### Controllers
I will now explain what are controllers supposed to do so you can get a clear picture of the capabilities of this project.

- For every entity you can search by OnlyActive, Page, ItemsPerPage parameters. Also every search entity has on it own have may other parameters to search but this are the base ones.

#### Account
- Unauthorized users can preform login and register operations. If user registers successfully, he will be notified via email.
- In order for email sender to work you need to setup your personal email settings in appsettings.json, preferable with secret.json
- During registration password taken from user will be hased and and only hash and salt will be stored in database. Code for this is available at BugTracker/Application/Hash
- If login credentials are valid user will recive his JWT token
- If user is authorized he can change his inforamtions at /api/account/changeProfile

#### Audit
- When every action is executed, information will be stored in this table.
- There is ability to fully search through use case logs.

#### Author
- Ability to change book author information. 
- Multiple authors can write one book and one author can have many books.
- CRUD actions on Author entity

#### Book
- Admins can do CRUD on book information
- Basic users are supposed to be able to search through the book.
- When creating or chaning a book user can upload cover image or content file for the book.

#### Category
- Ability to change book categories information. 
- CRUD actions on Category entity

#### Format
- Ability to change book format information. 
- CRUD actions on Format entity

#### Langugage
- Ability to change book language information. 
- CRUD actions on Langugage entity

#### Membership
- Ability to change user membership information. 
- This is considerd to be membershiop to Book Library. So each membership can have different pricings and can allow different stuff to do in library.
- CRUD actions on Membership entity

#### Publisher
- Ability to change book publisher information. 
- CRUD actions on Publisher entity

#### Reservations
- Reservation can happen when users select books that they want to reserve and select time span in which they are going to own theese books.
- CRUD actions on Reservations entity

#### Role
- Role that is attached to specific user which grants his specific actions

#### RoleCase
- Connecting role ids to use case ids
- This enables that only user with specific role can do certain actions.

#### User
- Intended for admins
- CRUD actions on all application users
- Create or Change user without needing to go to loging or register

