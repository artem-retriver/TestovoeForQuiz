SELF_NOTES

Почему выбрал такую реализацию

Разделил проект на Infrastructure и Energy feature-модуль, чтобы отделить общую инфраструктуру от игровой логики.

Для реактивности выбрал собственный ReactiveValue, потому что для задания нужен минимальный функционал:
1) Хранение значения
2) Подписка
3) Dispose

Что писал сам

Самостоятельно писал:
1) ReactiveValue
2) Regen loop
3) Dispose lifecycle
4) UI bindings
5) Структуру проекта

Что понимаю полностью

Понимаю:
1) Async lifecycle
2) CancellationToken
3) IDisposable subscriptions
4) DI через VContainer
5) Regen loop
6) UI binding lifecycle

Что осталось менее очевидным

Глубоко не изучал внутреннюю реализацию:
1) VContainer resolve pipeline
2) Внутренние механизмы scheduling в UniTask

Но понимаю их публичный API, lifecycle и корректное применение в рамках проекта.

Ключевые решения

Почему выбрал WaitUntil - Чтобы не крутить пустой цикл при полном energy.

Почему реализовал ViewModel отдельно - Чтобы отделить UI от логики.

Почему реализовал ReactiveValue вместо event - Чтобы контролировать lifecycle подписок через IDisposable.