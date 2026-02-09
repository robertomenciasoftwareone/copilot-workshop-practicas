// Ejercicio 1: Calculadora básica
// Crear funciones para sumar, restar, multiplicar y dividir dos números
function sumar(a, b) {
    return a + b;
}
function restar(a, b) {
    return a - b;
}
function multiplicar(a, b) {
    return a * b;
}
function dividir(a, b) {
    return a / b;
}

// Ejercicio 2: Palíndromo
/**
 * Verifica si una palabra es un palíndromo.
 * Un palíndromo es una palabra o frase que se lee igual de izquierda a derecha que de derecha a izquierda,
 * ignorando mayúsculas, espacios y caracteres especiales.
 *
 * @param {string} palabra - La palabra o frase a verificar.
 * @returns {boolean} - Retorna true si la palabra es un palíndromo, de lo contrario false.
 * @throws {Error} - Lanza un error si el argumento no es una cadena de texto.
 */
function esPalindromo(palabra) {
    if (typeof palabra !== 'string') {
        throw new Error('El argumento debe ser una cadena de texto');
    }

    // Limpia la palabra: convierte a minúsculas y elimina caracteres no alfanuméricos
    const palabraLimpia = palabra.toLowerCase().replace(/[^a-z0-9]/g, '');

    // Compara la palabra limpia con su reverso
    return palabraLimpia === palabraLimpia.split('').reverse().join('');
}

// Ejercicio 3: FizzBuzz
// TODO: Implementar el clásico FizzBuzz (1-100)

// Ejercicio 4: Factorial
// TODO: Calcular el factorial de un número

// Ejercicio 5: Números primos
// Verificar si un número es primo
function esPrimo(num) {
    if (!Number.isInteger(num) || num <= 1) return false;
    if (num === 2) return true;
    if (num % 2 === 0) return false;
    
    for (let i = 3; i <= Math.sqrt(num); i += 2) {
        if (num % i === 0) return false;
    }
    return true;
}
 

module.exports = { esPalindromo };
