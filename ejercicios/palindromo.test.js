const { esPalindromo } = require('./01-basicos');

describe('esPalindromo', () => {
    test('debería retornar true para un palíndromo simple', () => {
        expect(esPalindromo('ana')).toBe(true);
    });

    test('debería retornar true para un palíndromo con mayúsculas y espacios', () => {
        expect(esPalindromo('A man a plan a canal Panama')).toBe(true);
    });

    test('debería retornar false para una palabra que no es un palíndromo', () => {
        expect(esPalindromo('hola')).toBe(false);
    });

    test('debería lanzar un error si el argumento no es una cadena', () => {
        expect(() => esPalindromo(123)).toThrow('El argumento debe ser una cadena de texto');
    });
});