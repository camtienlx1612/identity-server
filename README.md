# Identity Server

## Goal
- Design and implement a custom authentication and user management system using MVC without relying on built-in identity frameworks.

- No ASP.NET Core Identity, OpenIddict, or external auth libraries.

## Technical Stack 
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

## Architecture
Separation of concerns:
- Controllers
- Views
- Services
- Repositories
- Data
- Models
No business logic inside UI layer
Reusable services for:
- Email sending
- Authentication
- Token generation
- Password hashing

## Curent Scope
All current lists feature are implementing or just implement:

- [ ] User Registration System
- [ ] Email Verification Systom
- [ ] Welcome Email System
- [ ] Authentication (Login/Logout)
- [ ] Password Reset System
- [ ] User Profile Mangement
- [ ] Avatar Upload System 

## Non-Function 
### ***Reliability***
- Handle invalid tokens gracefully
- Prevent duplicate registrations

### ***Security Hygiene***
- No sensitive data in logs
- No plaintext passwords or tokens exposed

### ***Maintainability***
- Code should be modular and testable

## Security Requirments (Critical)
Implement security manually
- Password Security
- Authentication Security
- Token Security
- Input Validation

## Data Structure Requirments (Database Design)
**Database Schema for:**
- Users
- Email confirmation tokens
- Password reset tokens ( or embedded fields)
- Optional audit fields

## UI Interface
- Registration page
- Login Page 
- Email confirmation page 
- Forgot password page
- Reset password page 
- Profile page ( authentication only )

## Backend API / Endpoint
- Authentication: register/login/logout
- Email flows: confirm email/resend confirmation
- Password reset: request reset/reset password
- Profile: get/updateb profile

## Local Development
### 1. Clone 
### Clone Repository
```bash
git clone https://github.com/camtienlx1612/identity-server.git
```

## Installation
```bash
dotnet restore

dotnet ef database update

dotnet run
```

## Testing 
### 1. Unit Tests
- Password hashing and verification logic
- Token generation and validation logic
- User creation logic (service layer)

### 2. Integration Tests
- Registration flow end-to-end
- Login flow
- Email confirmation flow
- Password reset flow
- Profile update flow
- Use test server + in-memory database or test DB.

