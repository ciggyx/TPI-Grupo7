# Trabajo Práctico Integrador - Diseño de Sistemas de Información

## 📚 Introducción

Este documento describe el Trabajo Práctico Integrador de la cátedra **Diseño de Sistemas de Información**, perteneciente a la carrera **Ingeniería en Sistemas de Información** de la **Universidad Tecnológica Nacional (UTN)**. El objetivo es aplicar los conceptos y metodologías vistos en el cursado para el análisis, diseño e implementación de un sistema de información completo.

---

## 🎯 Objetivos

1. **Analizar** los requerimientos funcionales y no funcionales de un dominio de negocio.
2. **Modelar** la estructura de datos y los procesos mediante UML (diagramas de casos de uso, de clases y de secuencia).
3. **Diseñar** una arquitectura modular y escalable, seleccionando tecnologías adecuadas.
4. **Implementar** prototipos de las principales capas (persistencia, lógica de negocio, presentación).
5. **Documentar** todo el ciclo de vida del proyecto.

---

## 📂 Estructura del Proyecto

```
tp_integrador/
├── docs/                   # Documentación UML y manuales
│   ├── casos_de_uso.md
│   ├── diagrama_clases.puml
│   └── diagrama_secuencia.puml
├── src/                    # Código fuente
│   ├── backend/           https://discord.gg/JZzMkPFG # API y lógica de negocio
│   └── frontend/           # Interfaz de usuario
├── data/                   # Scripts y datos de prueba
├── scripts/                # Scripts de despliegue y configuración
├── README.md               # Este archivo
└── LICENSE                 # Licencia del proyecto
```

---

## 🛠️ Requisitos

- .Net
- C#
- PostgreSQL 12+
- Dbeaver
- PlantUML (para diagramas)

---

## 🚀 Instalación

1. Clonar el repositorio:

   ```
   git clone https://github.com/usuario/tp_integrador.git
   cd tp_integrador
   ```

2. Configurar base de datos (PostgreSQL):

   - Crear base `tp_integrador`.
   - Ejecutar script de creación en `data/schema.sql`.

3. Backend:

   ```
   cd src/backend
   mvn install
   mvn spring-boot:run
   ```

   ```

   ```

---

## 📋 Uso

---

## 🧩 Metodología y Artefactos

| Artefacto                | Herramienta | Ubicación                      |
| ------------------------ | ----------- | ------------------------------ |
| Diagrama de Casos de Uso | PlantUML    | `docs/casos_de_uso.md`         |
| Diagrama de Clases       | PlantUML    | `docs/diagrama_clases.puml`    |
| Diagrama de Secuencia    | PlantUML    | `docs/diagrama_secuencia.puml` |
| Manual de Usuario        | Markdown    | `docs/manual_usuario.md`       |

---

## 👥 Integrantes

- **Medina, Lisandro** – Legajo 15669 – Rol (Análisis / Diseño / Implementación)
- **Belegni, Francisco** – Legajo 16170 – Rol (QA / Documentación)

- **Delpino, Noah** – Legajo 15141 – Rol (QA / Documentación)

- **Francioni, Ulises** – Legajo 15887 – Rol (QA / Documentación)

- **Perez Mignola, Joaquin** – Legajo 16275 – Rol (QA / Documentación)

- **Figueroa, Agustin** – Legajo 16273 – Rol (QA / Documentación)

- **Fermani, Julian** – Legajo 15172 – Rol (QA / Documentación)

- **Falchi Massietti, Alexander** – Legajo 14949 – Rol (QA / Documentación)

- **Doglio, Ramiro** – Legajo 16170 – Rol (QA / Documentación)

- **Mansilla, Pedro** – Legajo 16170 – Rol (QA / Documentación)

---

