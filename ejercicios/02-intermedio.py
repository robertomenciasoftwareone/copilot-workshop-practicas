# Ejercicio 1: Lista de tareas
class TodoList:
    def __init__(self):
        self.tasks = []

    def add_task(self, task):
        self.tasks.append(task)

    def remove_task(self, index):
        try:
            self.tasks.pop(index)
        except IndexError:
            print("Índice fuera de rango.")

    def list_tasks(self):
        for i, task in enumerate(self.tasks):
            print(f"{i}: {task}")

# Ejercicio 2: Procesamiento de archivos
import csv

def procesar_csv(file_path):
    try:
        with open(file_path, mode='r') as file:
            reader = csv.DictReader(file)
            data = [row for row in reader]
            print("Datos cargados correctamente.")
            return data
    except FileNotFoundError:
        print("Archivo no encontrado.")
    except Exception as e:
        print(f"Error al procesar el archivo: {e}")

# Ejercicio 3: API REST básica
from flask import Flask, jsonify, request

app = Flask(__name__)
tasks = []

@app.route('/tasks', methods=['GET'])
def get_tasks():
    return jsonify(tasks)

@app.route('/tasks', methods=['POST'])
def add_task():
    task = request.json.get('task')
    if task:
        tasks.append(task)
        return jsonify({"message": "Tarea agregada."}), 201
    return jsonify({"error": "Falta el campo 'task'."}), 400

@app.route('/tasks/<int:task_id>', methods=['DELETE'])
def delete_task(task_id):
    try:
        tasks.pop(task_id)
        return jsonify({"message": "Tarea eliminada."})
    except IndexError:
        return jsonify({"error": "Índice fuera de rango."}), 404

# Ejercicio 4: Validación de datos
import re

def validar_email(email):
    patron = r'^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$'
    return re.match(patron, email) is not None

def validar_telefono(telefono):
    patron = r'^\+?\d{10,15}$'
    return re.match(patron, telefono) is not None

def validar_codigo_postal(codigo):
    patron = r'^\d{5}$'
    return re.match(patron, codigo) is not None
