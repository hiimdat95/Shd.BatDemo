**Mô tả ngắn gọn**

1. Kiến trúc của project được xây dựng trên kiến trúc n-tiers, dựa theo template của asp.net bolierplate. Có thể truy cập [access](https://aspnetboilerplate.com/Pages/Documents/NLayer-Architecture) để hiểu được toàn bộ các thành phần và xây dựng theo hướng dẫn.
2. Thành phần giao diện của project được customize và đã tích hợp với bộ giải pháp DevExpress Mvc [tại đây](https://www.devexpress.com/products/net/controls/asp/core.xml) và DevExpress Blazor [tại đây](https://www.devexpress.com/blazor/)

---

## Setup

Project sử dụng các thành phần sau

1. .NET SDK 8
2. DevExpress 24.1.6
---



## Quick start

Thực hiện các bước dưới đây để build project và chạy

1. Thực hiện restore libman.json để download các thư viện FE cần thiết cho khung Asp.net Bolierplate
2. Thực hiện restore package.json để download các thư viện FE của NPM (các thành phần thư viện của devexpress)
3. Rebuild Solution


---

## Config

1. Select the 'Web.Mvc' project as the startup project.
2. Check the connection string in the appsettings.json file of the Web.Mvc project, change it if you want.
3. Open Package Manager Console and run the Update-Database command to create your database (ensure that the Default project is selected as .EntityFrameworkCore in the Package Manager Console window).
4. Run the application.
---
