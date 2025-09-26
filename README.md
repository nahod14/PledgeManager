# PledgeManager

A modern web application built with ASP.NET Core 8.0 and Blazor for managing donor pledges, payments, and receipts. Perfect for non-profit organizations, churches, and fundraising campaigns.

## 🚀 Features

- **Donor Management**: Add, search, and manage donor information
- **Pledge Tracking**: Create and monitor pledges with different frequencies (one-time, monthly, yearly)
- **Payment Processing**: Record and track payments against pledges
- **File Upload & Management**: Upload and store receipts and documents
- **PDF Receipt Generation**: Automatically generate PDF receipts using QuestPDF
- **User Authentication**: Secure login system with ASP.NET Core Identity
- **Responsive Design**: Modern, mobile-friendly interface

## 🏗️ Architecture

The application follows Clean Architecture principles with three main projects:

- **PledgeManager.Domain**: Core business entities and domain models
- **PledgeManager.Infrastructure**: Data access, services, and external dependencies
- **PledgeManager.Web**: Blazor Server UI and web application logic

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 8.0
- **UI**: Blazor Server
- **Database**: SQLite (Entity Framework Core)
- **Authentication**: ASP.NET Core Identity
- **PDF Generation**: QuestPDF
- **File Storage**: Local file system
- **ORM**: Entity Framework Core 8.0

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Any code editor (Visual Studio, VS Code, JetBrains Rider)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/PledgeManager.git
cd PledgeManager
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Set Up the Database

Navigate to the web project and run the database migrations:

```bash
cd src/PledgeManager.Web
dotnet ef database update --project ../PledgeManager.Infrastructure --startup-project .
```

### 4. Run the Application

```bash
dotnet run --urls "https://localhost:5001;http://localhost:5000"
```

The application will be available at:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001

## 📁 Project Structure

```
PledgeManager/
├── src/
│   ├── PledgeManager.Domain/           # Core domain models
│   │   ├── Donor.cs                   # Donor entity
│   │   ├── Pledge.cs                  # Pledge entity
│   │   ├── Payment.cs                 # Payment entity
│   │   └── FileBlob.cs                # File storage entity
│   ├── PledgeManager.Infrastructure/   # Data & services layer
│   │   ├── AppDbContext.cs            # Entity Framework context
│   │   ├── ReceiptService.cs          # PDF receipt generation
│   │   ├── LocalFileStorage.cs        # File storage service
│   │   └── Services.cs                # Service interfaces
│   └── PledgeManager.Web/             # Blazor web application
│       ├── Pages/                     # Blazor pages
│       │   ├── Donors.razor           # Donor management
│       │   ├── Pledges.razor          # Pledge management
│       │   ├── Payments.razor         # Payment tracking
│       │   └── Files.razor            # File management
│       ├── Components/                # Reusable components
│       └── wwwroot/                   # Static files
├── tests/
│   └── PledgeManager.Tests/           # Unit tests
└── storage/                           # File storage directory
```

## 🔧 Configuration

### Database Connection

The application uses SQLite by default. Update the connection string in `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Data Source=pledge.db"
  }
}
```

### File Storage

Configure file storage location in `appsettings.Development.json`:

```json
{
  "Storage": {
    "Root": "storage"
  }
}
```

## 📊 Database Schema

The application includes the following main entities:

- **Donors**: Store donor information (Name, Email, Phone)
- **Pledges**: Track pledges with amounts, frequencies, and status
- **Payments**: Record payments against pledges
- **FileBlobs**: Manage uploaded files and receipts
- **AspNet Identity Tables**: User authentication and authorization

## 🔐 Authentication

The application includes built-in authentication using ASP.NET Core Identity. A default admin user can be created by uncommenting the seed data in `Program.cs`:

- Email: admin@example.com
- Password: Passw0rd!

## 🎯 Usage

### Managing Donors

1. Navigate to the Donors page
2. Use the search functionality to find existing donors
3. Click "+ New Donor" to add new donors
4. Fill in the required information (Name, Email, Phone)

### Creating Pledges

1. Go to the Pledges page
2. Select a donor from the dropdown
3. Enter pledge amount and frequency
4. Set the start date and status

### Recording Payments

1. Visit the Payments page
2. Select the pledge to pay against
3. Enter payment amount, date, and method
4. Add optional notes

### File Management

1. Access the Files page
2. Upload receipts and documents
3. Files are automatically linked to pledges
4. Generate PDF receipts for payments

## 🧪 Testing

Run the test suite:

```bash
dotnet test
```

## 🚀 Deployment

### Development

```bash
dotnet run --environment Development
```

### Production

1. Build the application:
```bash
dotnet publish -c Release -o ./publish
```

2. Configure production settings in `appsettings.Production.json`

3. Deploy to your preferred hosting platform (Azure, AWS, IIS, etc.)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🐛 Issues & Support

If you encounter any issues or have questions:

1. Check the [Issues](https://github.com/yourusername/PledgeManager/issues) page
2. Create a new issue with detailed information
3. Include steps to reproduce any bugs

## 🔮 Future Enhancements

- [ ] Email notifications for pledge reminders
- [ ] Dashboard with analytics and reporting
- [ ] Export functionality (CSV, Excel)
- [ ] Multi-tenant support
- [ ] Mobile app integration
- [ ] Payment gateway integration
- [ ] Advanced reporting and analytics

## 📞 Contact

- **Author**: Nahom
- **Email**: nahod14@gmail.com
- **GitHub**: [@ynahod14](https://github.com/nahod14)

---

⭐ **Star this repository if it helped you!**
