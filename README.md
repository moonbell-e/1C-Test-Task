# 1C-Test-Task

Test task for Intern Unity Developer's position at 1C Game Studios.

Требуется реализовать механику обнаружения в Unity для 2D игры с видом сверху и статичной камерой на прямоугольном игровом поле. Два объекта перемещаются случайным образом, меняя направление при столкновении с границами. Настройки для каждого объекта (в компоненте на объекте): радиус обнаружения, сектор обнаружения (0-360 градусов), скорость передвижения, изначальный цвет, цвет при обнаружении. Сектор обнаружения направлен в сторону движения объекта. При обнаружении другого объекта, цвет меняется, и возвращается к изначальному после выхода из зоны видимости. Запрещено использование компонентов Collider, Physics, NavMesh. Лаконичность и масштабируемость количества объектов - преимущество.
