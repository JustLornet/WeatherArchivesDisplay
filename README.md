# WeatherArchivesDisplay
Приложение для загрузки и отображения архивов погодных условий в городе Москве

Временно (далее будет изменено на docker-compose) - команда Docker для запуска БД, к которой подключается бек: docker run --rm --name ms-sql -p 1433:1433 -t -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=myStrongPass!" mcr.microsoft.com/mssql/server

Оптимизировано для удобства дальнейшего добавления других метеостанций

Страница просмотра распарсенных данных:
![image](https://github.com/JustLornet/WeatherArchivesDisplay/assets/114276360/bdedc84b-44ad-4ae0-891f-111574bb24ea)
![image](https://github.com/JustLornet/WeatherArchivesDisplay/assets/114276360/2c1e3926-4b13-4e5d-acfc-8c297f40525b)

Страница загрузки архивов
![image](https://github.com/JustLornet/WeatherArchivesDisplay/assets/114276360/305dbb97-2217-4689-8a5e-fad4c464a1e4)
