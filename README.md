# WeatherArchivesDisplay
Приложение для загрузки и отображения архивов погодных условий в городе Москве

Временно (далее будет изменено на docker-compose) - команда Docker для запуска БД, к которой подключается бек: docker run --rm --name ms-sql -p 1433:1433 -t -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=myStrongPass!" mcr.microsoft.com/mssql/server

Оптимизировано для удобства дальнейшего добавления других метеостанций