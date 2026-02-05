# Copilot Workshop - Prácticas

Este repositorio contiene ejercicios prácticos diseñados para aprender y practicar el uso de GitHub Copilot. Cada ejercicio aborda un concepto o problema específico, con el objetivo de mejorar las habilidades de programación y resolución de problemas.

## Estructura del Proyecto

El proyecto está organizado en las siguientes carpetas:

- **`ejercicios/`**: Contiene los archivos de código fuente para los ejercicios.
  - `01-basicos.js`: Incluye funciones básicas como suma, resta, multiplicación, división y verificación de palíndromos.
  - `test_palindromo.js`: Archivo de pruebas unitarias para la función `esPalindromo`.

- **`practica3-refactor/`**: Contiene código legado para refactorización.

## Ejercicios

### Ejercicio 1: Calculadora Básica
Se implementaron funciones para realizar operaciones matemáticas básicas:
- `sumar(a, b)`: Retorna la suma de dos números.
- `restar(a, b)`: Retorna la resta de dos números.
- `multiplicar(a, b)`: Retorna la multiplicación de dos números.
- `dividir(a, b)`: Retorna la división de dos números.

### Ejercicio 2: Palíndromo
Se implementó la función `esPalindromo` para verificar si una palabra o frase es un palíndromo. La función incluye validaciones y limpieza de caracteres no alfanuméricos.

### Ejercicios Pendientes
- **Ejercicio 3: FizzBuzz**: Implementar el clásico FizzBuzz para los números del 1 al 100.
- **Ejercicio 4: Factorial**: Calcular el factorial de un número.
- **Ejercicio 5: Números Primos**: Verificar si un número es primo.

## Pruebas Unitarias
Las pruebas unitarias se encuentran en el archivo `palindromo.test.js` y se ejecutan utilizando [Jest](https://jestjs.io/). Para ejecutar las pruebas:

1. Instalar dependencias:
   ```bash
   npm install
   ```
2. Ejecutar las pruebas:
   ```bash
   npm test
   ```

## Requisitos
- Node.js
- npm

## Contribuciones
Las contribuciones son bienvenidas. Si encuentras un problema o tienes una mejora, por favor abre un issue o envía un pull request.

## Licencia
Este proyecto está bajo la licencia ISC.
