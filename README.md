# Práctica Semana 9 – ASP.NET Core MVC  
Proyecto académico desarrollado como parte del laboratorio de Programación 3.  
Incluye dos módulos independientes, cada uno implementado en ASP.NET Core MVC, con validaciones,  
repositorios en memoria, vistas con Bootstrap y una interfaz moderna.

---

## 📌 Tecnologías utilizadas
- ASP.NET Core MVC (.NET 8)
- C#
- Razor Pages
- Bootstrap 5.3
- Bootstrap Icons
- HTML5 / CSS3
- Patrón MVC
- Validaciones con DataAnnotations

---

## 🧩 Estructura del Proyecto

PracticaSemana9/
│
├── Controllers/
│ ├── HomeController.cs
│ ├── LibroController.cs
│ └── InscripcionController.cs
│
├── Models/
│ ├── Libro.cs
│ └── Inscripcion.cs
│
├── Data/
│ ├── LibroRepository.cs
│ └── InscripcionRepository.cs
│
├── Views/
│ ├── Home/ (Dashboard)
│ ├── Libro/ (CRUD básico)
│ └── Inscripcion/ (CRUD básico)
│
└── wwwroot/
├── css/site.css
├── lib/bootstrap/
└── icons/


---

# 🎯 **Objetivo General**

Implementar dos casos independientes basados en MVC:

1. **Biblioteca Campus**  
   Gestión de libros con validaciones avanzadas.

2. **TechWorkshops**  
   Registro de participantes con campos validados y almacenamiento temporal.

Ambos módulos comparten un menú de navegación, un layout principal y estilos globales personalizados.
