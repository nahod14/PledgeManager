# Product Price Tracker

A full-stack web application for tracking product prices across multiple e-commerce websites.

## Features

- Track product prices from Amazon, AliExpress, Walmart, and more
- Price history visualization with interactive charts
- Price drop alerts via email
- User authentication and personal product lists
- Responsive dashboard interface

## Tech Stack

### Frontend
- Next.js (React)
- Tailwind CSS
- Chart.js for data visualization
- TypeScript

### Backend
- Node.js with Express
- MongoDB for data storage
- Puppeteer for web scraping
- JWT for authentication
- SendGrid for email notifications

## Getting Started

### Prerequisites
- Node.js (v18 or higher)
- MongoDB
- Docker and Docker Compose (optional)

### Installation

1. Clone the repository
```bash
git clone [repository-url]
cd product-price-tracker
```

2. Install dependencies
```bash
# Install backend dependencies
cd backend
npm install

# Install frontend dependencies
cd ../frontend
npm install
```

3. Set up environment variables
```bash
# Backend
cp backend/.env.example backend/.env

# Frontend
cp frontend/.env.example frontend/.env
```

4. Start the development servers
```bash
# Start backend
cd backend
npm run dev

# Start frontend
cd frontend
npm run dev
```

## Docker Setup

To run the entire application using Docker:

```bash
docker-compose up
```

## Project Structure

```
product-price-tracker/
├── backend/           # Express.js backend
├── frontend/          # Next.js frontend
├── docker-compose.yml # Docker configuration
└── README.md         # Project documentation
```

## License

MIT 