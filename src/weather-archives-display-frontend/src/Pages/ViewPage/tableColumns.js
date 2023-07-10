const tableColumns = [
    {
        accessorKey: 'id',
        header: 'Номер в БД',
        size: 100
    },
    {
        accessorKey: 'dateTime',
        header: 'Дата, время',
        size: 150
    },
    {
        accessorKey: 'airTemperature',
        header: 'Температура воздуха, гр.Ц.',
        size: 150
    },
    {
        accessorKey: 'airHumidity',
        header: 'Отн.влажность воздуха, %',
        size: 140
    },
    {
        accessorKey: 'dewPoint',
        header: 'Точка росы, гр.Ц.',
        size: 140
    },
    {
        accessorKey: 'atmospherePressure',
        header: 'Атм.давление, мм.рт.ст.'
    },
    {
        accessorKey: 'windDirection',
        header: 'Направление ветра'
    },
    {
        accessorKey: 'windSpeed',
        header: 'Скорость ветра, м/с'
    },
    {
        accessorKey: 'cloudiness',
        header: 'Облачность, %'
    },
    {
        accessorKey: 'cloudBase',
        header: 'Нижняя граница облачности, м'
    },
    {
        accessorKey: 'horizontalVisibility',
        header: 'Горизонтальная видимость, км'
    },
    {
        accessorKey: 'weatherConditions',
        header: 'Погодные явления'
    }
]

export default tableColumns