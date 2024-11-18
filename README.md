# Proyecto de Control de Brazo Robótico en Unity

Este es un proyecto creado con Unity que simula y permite el control de un brazo robótico a través de diferentes conjuntos de teclas. El objetivo del proyecto es proporcionar una experiencia intuitiva para el control y manipulación de un brazo robótico con múltiples articulaciones.

---



## Requisitos del Proyecto

- Unity (versión compatible)

### Nota
El proyecto funciona en la **SampleScene**, donde se ha configurado el entorno y los componentes necesarios para el control del brazo robótico.

---

## Descripción del Proyecto

Este proyecto es ideal para simulaciones de robótica y aprendizaje de conceptos de cinemática inversa y directa. Puedes ajustar y modificar el script para adaptar el comportamiento del brazo robótico según tus necesidades.

---

## Explicación del Código

### MyRobotController.cs
- **Propósito**: Controlar la interacción entre el brazo robótico y un objeto llamado `Stud_target`, permitiendo recoger y soltar el objeto en una ubicación específica (`Workbench_destination`).
- **Principales Componentes**:
    - **Raycast**: Utilizado para verificar si el brazo puede recoger el objeto objetivo.
    - **Movimiento y Agarre**: Usa un controlador de movimiento (`MyRobotMovementControllerv`) para manipular el brazo y gestionar el estado de agarre.
    - **Método `Update()`**: Verifica continuamente si el brazo está agarrando el objeto y actualiza la posición y el estado del objeto en consecuencia.

### MyRobotMovementControllerv.cs
- **Propósito**: Controlar el movimiento y la rotación de las diferentes articulaciones del brazo robótico.
- **Principales Componentes**:
    - **Eventos de Entrada**: Escucha los eventos de entrada del usuario para actualizar la dirección, la rotación y el estado de agarre.
    - **Métodos de Rotación y Movimiento**: Calcula y aplica transformaciones a las articulaciones del brazo según las entradas del usuario.
    - **Apertura y Cierre de la Pinsa**: Gestiona la apertura y cierre de las pinzas para agarrar o soltar objetos mediante restricciones y límites en los ángulos de rotación.
    - **Método `NormalizeAngle()`**: Normaliza los ángulos de rotación para mantenerlos en el rango adecuado (-180° a 180°).

---

## Controles

### Desplazamiento del Brazo
- **W**: Mover el brazo hacia adelante
- **A**: Mover el brazo hacia la izquierda
- **S**: Mover el brazo hacia atrás
- **D**: Mover el brazo hacia la derecha

### Rotación del Joint 0
- **Flecha Arriba**: Rotar el Joint 0 en el eje X en dirección positiva
- **Flecha Abajo**: Rotar el Joint 0 en el eje X en dirección negativa
- **Flecha Izquierda**: Rotar el Joint 0 en el eje Y en dirección negativa
- **Flecha Derecha**: Rotar el Joint 0 en el eje Y en dirección positiva

### Rotación del Joint 1
- **Q**: Rotar el Joint 1 en el eje X en dirección negativa
- **E**: Rotar el Joint 1 en el eje X en dirección positiva

### Rotación del Joint 2
- **Z**: Rotar el Joint 2 en el eje X en dirección negativa
- **X**: Rotar el Joint 2 en el eje X en dirección positiva
- **C**: Rotar el Joint 2 en el eje Y en dirección negativa
- **V**: Rotar el Joint 2 en el eje Y en dirección positiva

---