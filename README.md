﻿# `AppAnalysis`
## Предысловие
Ввиду подготовки к экзаменам, проект пришлось сделать грубо говоря за 3 дня. Из-за этого в нем остался большой простор для оптимизации, которую бы при достаточном времени я бы смог выполнить. Также из-за этого не удалось мне изучить новую для меня технологию Docker. Я пытался оформить докерфайлы, но когда я начал это тестировать, то из-за незнания технологии было много ошибок:) В фронтенде проекта использовались 3 дополнительные библиотеки, значительно ускорившие разработку:
1. moment - для работы со временем
2. chart.js - для составления диаграммы
3. jquery - для работы с DOM

Ну и bootstrap в эстетических целях

Также для удобства была добавлена вкладка "Добавить событие", чтобы вручную не писать код(что также доступно). 

## Инструкция по запуску
Ввиду отсутствия поддержки докера в проекте, придется компилировать вручную:
1. Скачать [.NET Sdk 6.0.201](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). Для этого надо долистать до панели с названием 6.0.3, раскрыть ее и с левой верхней таблицы установить Sdk для нужной платформы.
2. Открыть корневую папку проекта, перейти в AppAnalysis(где находится AppAnalysis.csproj)
3. Выполнить команду ```dotnet run -v q```
4. В браузере открыть https://localhost:7078/
