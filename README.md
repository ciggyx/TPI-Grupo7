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
TPI_Grupo7/
├── diagramas/           # Documentación UML
│   ├── Diagramas/Parte_Dinámica_CU_23.svg
│   ├── Diagramas/Parte_Estática_CU_23.svg
│   ├── Diagramas/maquinaEstadoEventoSismico.svg
│   └── Diagramas.plantuml
├── source/              # Código fuente
│   ├── Boundary/           
│   ├── Database/           
│   ├── Entidades/          
│   ├── GestoresCU/         
│   ├── Images/             
│   └── Properties/          
├── README.md              
└── .gitignore
```

---

## 🛠️ Requisitos

- .Net
- C#
- PlantUML (para diagramas)

---

## 🚀 Instalación

1. Clonar el repositorio:

   ```
   git clone https://github.com/ciggyx/TPI-Grupo7.git
   cd TPI-Grupo7
   ```

2. Ejecución del proyecto:
   ```
   Instalar: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
   docker compose up -d
   cd source
   dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
   dotnet restore
   dotnet build
   dotnet tool install --global dotnet-ef --version 8.*
   dotnet ef migrations add CreacionInicial --output-dir Infraestructura/Migraciones
   dotnet ef database update
   dotnet run
   ```

---

## 👥 Integrantes

- **Medina, Lisandro** – Legajo 15669
- **Belegni, Francisco** – Legajo 16170
- **Delpino, Noah** – Legajo 15141
- **Francioni, Ulises** – Legajo 15887
- **Perez Mignola, Joaquin** – Legajo 16275
- **Figueroa, Agustin** – Legajo 16273
- **Fermani, Julián** – Legajo 15172
- **Falchi Massietti, Alexander** – Legajo 14949
- **Doglio, Ramiro** – Legajo 15071
- **Mansilla, Pedro** – Legajo 15667
---
