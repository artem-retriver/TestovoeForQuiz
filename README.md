Energy & Regen

Тестовое задание выполнено на:
1) Unity 2022.3.46f1 LTS
2) VContainer
3) UniTask

Реализовано

1) ReactiveValue<T> с IDisposable-подписками
2) EnergyService с асинхронной регенерацией
3) UI без Update()
4) MVVM-подход
5) DI через VContainer
6) ScriptableObject-конфиг

Запуск

1) Открыть сцену `Assets/Scenes/Main.unity`
2) Убедиться, что установлены:
   а) VContainer
   б) UniTask
3) Нажать Play

Что бы я доделал ещё за 2 часа

1) Сохранение энергии между сессиями
2) Offline regeneration
3) Unit tests для EnergyService
4) Bootstrap через IStartable
5) Editor validation для ссылок
6) Анимацию progress bar (через DOTWeen)
7) PlayMode tests