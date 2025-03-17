# ExoplanetQueryApp
Exoscope is a full-stack application designed to explore NASA's exoplanet database. Whether you're an astronomy enthusiast or a curious learner, Exoscope lets you query exoplanets by various parameters such as planet name, host star, discovery year, and more, delivering detailed results. The backend leverages .NET Core for a scalable API, hosted on Azure, while the frontend, built with Angular, runs on Render for a fast, responsive user experience.
![image](https://github.com/user-attachments/assets/e9887b5c-4b47-42a4-9c49-7b1349e88b11)

## Features

- **Exoplanet Querying**: Filter exoplanets using criteria like name, host star, discovery method, or orbital period.
- **Real-Time Data**: Pulls data from a pre-loaded NASA exoplanet dataset (CSV-based).
- **Secure Backend**: .NET Core Web API hosted on Azure App Service with CORS support.
- **Responsive Frontend**: Angular-powered UI hosted on Render.
- **Scalable Design**: Built with modern development practices, ready for future enhancements.

## Tech Stack

- **Backend**: .NET Core (Web API)
  - Framework: .NET 9 
  - Data Handling: CsvHelper for parsing NASA’s exoplanet CSV
  - Hosting: Azure App Service
- **Frontend**: Angular 19
  - Hosting: Render (static site)
- **Deployment**: GitHub Actions for CI/CD
