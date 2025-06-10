Trabajo Práctico Integrador - Diseño de Sistemas de Información

# 📚 Introducción

Este documento describe el Trabajo Práctico Integrador de la cátedra Diseño de Sistemas de Información, perteneciente a la carrera Ingeniería en Sistemas de Información de la Universidad Tecnológica Nacional (UTN). El objetivo es aplicar los conceptos y metodologías vistos en el cursado para el análisis, diseño e implementación de un sistema de información completo.

## 🎯 Objetivos

- Analizar los requerimientos funcionales y no funcionales de un dominio de negocio.

- Modelar la estructura de datos y los procesos mediante UML (diagramas de casos de uso, de clases y de secuencia).

- Diseñar una arquitectura modular y escalable, seleccionando tecnologías adecuadas.

- Implementar prototipos de las principales capas (persistencia, lógica de negocio, presentación).

- Documentar todo el ciclo de vida del proyecto.

## 📂 Estructura del Proyecto

tp_integrador/
├── docs/ # Documentación UML y manuales
│ ├── casos_de_uso.md
│ ├── diagrama_clases.puml
│ └── diagrama_secuencia.puml
├── src/ # Código fuente
│ ├── backend/ <https://discord.gg/JZzMkPFG> # API y lógica de negocio
│ └── frontend/ # Interfaz de usuario
├── data/ # Scripts y datos de prueba
├── scripts/ # Scripts de despliegue y configuración
├── README.md # Este archivo
└── LICENSE # Licencia del proyecto

## 🛠️ Requisitos

- Java 11 o superior

- Node.js 14.x y npm

- PostgreSQL 12+

- Maven o Gradle

- PlantUML (para diagramas)

🚀 Instalación

1. Clonar el repositorio:

```
git clone https://github.com/usuario/tp_integrador.git
cd tp_integrador
```

2. Configurar base de datos (PostgreSQL):

- Crear base tp_integrador.

- Ejecutar script de creación en data/schema.sql.

3. Backend:

```
cd src/backend
mvn install
mvn spring-boot:run
```

4. Frontend:

```
cd src/frontend
npm install
npm start
```

## 📋 Uso

Acceder a la API REST en: <http://localhost:8080/api>

Interfaz web disponible en: <http://localhost:3000>

Documentación Swagger en: <http://localhost:8080/swagger-ui.html>

## 🧩 Metodología y Artefactos

## 👥 Integrantes

Apellido, Nombre – Legajo 12345 – Rol (Análisis / Diseño / Implementación)

Apellido, Nombre – Legajo 67890 – Rol (QA / Documentación)

