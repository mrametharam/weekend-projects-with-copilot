# weekend-projects-with-copilot
A collection of projects built during the weekend together with the AI copilot for the purpose of familiarizing myself with the different design patterns out there.

## Copilot's response...

I'd be delighted to help you brainstorm ideas for a .NET application! Here are a few project concepts that you can consider, which will allow you to explore the latest features of .NET 8:

1. **E-commerce Web Application**: Utilize ASP.NET Core to create a platform for users to browse and purchase products. Implement features like user authentication, product listings, and a shopping cart.

2. **Personal Finance Tracker**: Develop a desktop application using WPF that allows users to track their expenses, set budgets, and visualize their financial data.

3. **Task Management Mobile App**: Use Xamarin.Forms to build a cross-platform mobile app that helps users organize their tasks, set reminders, and prioritize their daily activities.

4. **RESTful API Service**: Create a RESTful service with ASP.NET Core that supports CRUD operations, which can be consumed by other applications or services.

5. **Real-time Chat Application**: Implement a real-time chat application using SignalR to allow instant messaging between users.

6. **Inventory Management System**: Build a system to manage inventory levels, orders, sales, and deliveries for a small business.

7. **Recipe Sharing Platform**: Design a web application where users can share their favorite recipes, rate them, and leave comments.

8. **Online Voting System**: Create a secure and transparent online voting system using ASP.NET and SQL Server to handle elections or polls.

9. **Weather Forecast App**: Develop an application that fetches real-time weather data and provides forecasts using a weather API.

10. **Fitness Tracker**: Create a mobile app that tracks user activity, logs workouts, and provides health tips.

Each of these projects can be tailored to incorporate the new features of .NET 8, such as performance improvements, garbage collection enhancements, and the new globalization mode for mobile apps¹. Additionally, you can explore .NET Aspire, which is a cloud-ready stack for building distributed applications¹.

Remember, the key to building your skills is to understand every part of the code and to challenge yourself with the project's complexities. Good luck with your coding journey! 🚀

Source: Conversation with Bing, 3/30/2024
(1) What's new in .NET 8 | Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview.
(2) What's new in .NET 6 - .NET | Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6.
(3) Download .NET (Linux, macOS, and Windows). https://dotnet.microsoft.com/en-us/download.
(4) What's next in .NET? | .NET. https://dotnet.microsoft.com/en-us/next.
(5) 15 C# Project Ideas: Beginner to Expert [With tutorial]. https://dev.to/nerdjfpb/15-c-project-ideas-beginner-to-expert-with-tutorial-iio.
(6) Top 101+ .Net Project Ideas [Updated 2024] - StatAnalytica. https://statanalytica.com/blog/dot-net-project-ideas/.
(7) Build .NET applications with C# - Training | Microsoft Learn. https://learn.microsoft.com/en-us/training/paths/build-dotnet-applications-csharp/.
(8) 40+ ASP.NET Projects with Source Code - Code with C. https://www.codewithc.com/asp-net-projects-with-source-code/.


## The Weather Forecast App

For a project that can be completed within 24 hours, I recommend starting with the **Weather Forecast App**. It's a manageable size and offers a good balance of front-end and back-end development, which can be a great way to practice your .NET skills. Here's a simplified breakdown of what you could aim to achieve:

1. **Design a simple UI**: Create a basic user interface that allows users to enter their location and view the weather forecast.

2. **Fetch weather data**: Use an API like OpenWeatherMap to retrieve current weather data based on the user's location.

3. **Display the data**: Present the weather information in a user-friendly format, including temperature, humidity, and weather conditions.

4. **Error handling**: Implement basic error handling for API connectivity issues or user input errors.

This project will give you the opportunity to work with APIs, JSON data, and the .NET HttpClient class for making web requests. Plus, it's a practical application that you can expand on in the future if you wish. Good luck, and happy coding!


### Requirements

Certainly! As your client, here are my requirements for the Weather Forecast App:

1. **User Interface (UI) Requirements**:
   - A clean and intuitive interface.
   - Ability to search for a city or use the current location for weather data.
   - Display the current temperature, humidity, wind speed, and weather conditions (sunny, cloudy, etc.).

2. **Functional Requirements**:
   - The app should fetch data from a reliable weather API.
   - It should update weather information automatically or have a manual refresh option.
   - The app should handle errors gracefully and inform the user if the weather data is unavailable.

3. **Performance Requirements**:
   - The app should have a fast response time.
   - It should be optimized for low data usage.

4. **Security Requirements**:
   - Any API keys used should be secured and not exposed in the code.

5. **Testing Requirements**:
   - The app should be tested across different devices for compatibility.
   - Ensure there are no critical bugs before delivery.

6. **Delivery Requirements**:
   - The source code should be well-documented and easy to understand.
   - Provide a brief user manual on how to use the app.

Remember, the goal is to create a simple yet functional weather forecast app that provides users with the essential information they need. I'm looking forward to seeing what you create!


### The Weather API

For your Weather Forecast App project, I recommend using **Open-Meteo.com**¹. It's an open-source weather API that offers free access for non-commercial use, and it doesn't require an API key, making it convenient for developers. It provides accurate weather forecasts with high resolution, ranging from 1 to 11 kilometers, and it's updated hourly to ensure the latest data is available.

Another option is **WeatherAPI.com**², which provides real-time weather information, forecasts, and historical weather data in JSON and XML formats. It's designed for both commercial and non-commercial use and offers a variety of features that could be beneficial for your app.

Both of these APIs are well-documented and user-friendly, which should help you get your weather app up and running smoothly. Good luck with your project! 🌤️👨‍💻

Source: Conversation with Bing, 3/30/2024
(1) ️ Free Open-Source Weather API | Open-Meteo.com. https://open-meteo.com/.
(2) Free Weather API - WeatherAPI.com. https://www.weatherapi.com/.
(3) Top 6 Best Free Weather APIs (2023) - API Hub. https://bing.com/search?q=free+weather+API+for+development.
(4) undefined. https://api.open-meteo.com/v1/forecast.


## Information

DTO / Data Transfer Objects are flat objects that do not contain any business rules / logic and are mainly used to transfer data to another application. In a web API, this would be the response object.

