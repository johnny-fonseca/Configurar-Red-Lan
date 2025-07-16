# Configurador de Red y Compartición de Carpetas en VB.NET

## Descripción

Esta aplicación desarrollada en Visual Basic .NET automatiza la configuración de red y la compartición de carpetas en equipos Windows. Permite establecer direcciones IP estáticas, cambiar el perfil de red a privado, crear una carpeta compartida en el escritorio y renombrar el equipo a “pc1” o “pc2”, según el botón que selecciones.  

El objetivo es simplificar tareas repetitivas de administración de red en entornos de laboratorio o pequeñas oficinas, garantizando consistencia y reduciendo errores manuales.

---

## Características Principales

- Verificación automática de adaptador Ethernet conectado.  
- Asignación de IP estática, máscara y puerta de enlace.  
- Configuración de servidor DNS primario y secundario.  
- Cambio de perfil de red a “Privado” mediante PowerShell.  
- Creación de carpeta compartida con permisos completos a todos los usuarios.  
- Renombrado del equipo y reinicio automático.  

---

## Requisitos Previos

- Windows 10 o superior con .NET Framework 4.7.1 instalado.  
- Visual Studio 2017/2019 o superior para compilar la solución.  
- Permisos de administrador en la máquina objetivo.  

---

## Instalación

1. Clona o descarga el repositorio que contiene el proyecto `.sln`.  
2. Abre la solución en Visual Studio.  
3. Verifica que el Target Framework esté configurado en .NET Framework 4.7.1.  
4. Compila el proyecto (`Build → Build Solution`).  
5. Ejecuta el ejecutable generado en modo administrador.  

---

## Configuración

Antes de ejecutar la aplicación, revisa y adapta los siguientes parámetros en `Form1.vb`:

1. Nombres de interfaz de red  
   ```vbnet
   name="Ethernet"
   ```  
2. Rango de direcciones IP  
   - PC1: `192.168.1.2`  
   - PC2: `192.168.1.3`  
3. Puerta de enlace y máscara: `255.255.255.0` y `192.168.1.1`.  
4. Servidores DNS: `8.8.8.8` y `8.8.4.4`.  
5. Ruta y nombre de la carpeta a compartir:
   ```vbnet
   Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "compartir")
   ```  

---

## Uso

1. Ejecuta la aplicación como administrador.  
2. Selecciona el botón **Configurar PC1** o **Configurar PC2** según corresponda.  
3. Observa el historial de comandos y mensajes en el cuadro de texto de salida.  
4. Al finalizar, el equipo se reiniciará si su nombre no coincide con el predefinido.  

---

## Estructura de Código

```vbnet
Private Sub btnConfigurar1_Click(...)  
    ' Limpia el log  
    RunCmd("netsh interface ip set address name=""Ethernet"" static 192.168.1.2 255.255.255.0 192.168.1.1")  
    RunCmd("icacls ""{carpeta}"" /grant Todos:(OI)(CI)F /T /C /Q")  
    RunCmd("shutdown /r /t 5")  
End Sub
```

La función `RunCmd` ejecuta comandos de consola redireccionando su salida y registrándola en pantalla. La rutina `Log` consolida cada línea en el control `txtOutput`.

---

## Solución de Problemas

- Si no aparece “Adaptador Ethernet conectado”, valida el nombre real de tu interfaz con  
  ```
  netsh interface show interface
  ```  
- Para permisos insuficientes al crear la carpeta compartida, asegúrate de ejecutar como administrador.  
- Si la red no cambia a privada, instala y habilita los módulos de NetTCPIP en PowerShell.  

---

## Personalización

- Para más máquinas, duplica los bloques de código y ajusta IP, nombre de equipo y botón.  
- Cambia la ruta de la carpeta compartida a otra ubicación editando `Environment.SpecialFolder`.  
- Implementa lógica de detección dinámica de interfaz si tu equipo tiene múltiples adaptadores.  

---

## Buenas Prácticas y Extensiones

- Incluye manejo de excepciones con `Try…Catch` para capturar errores de ejecución de procesos.  
- Registra el historial de acciones en un archivo de texto aparte para auditorías.  
- Agrega validación de conexión a Internet antes de asignar DNS externo.  
- Convierte las rutinas de configuración en tareas asíncronas (`Async/Await`) para mejorar la respuesta de la UI.  

---

## Licencia

Este proyecto está disponible bajo la licencia MIT. Revisa el archivo `LICENSE` para más detalles.

---

Te puede interesar explorar:

- Automatización con PowerShell puro para simplificar el despliegue en varios equipos.  
- Uso de Microsoft Endpoint Manager (Intune) para gestionar perfiles de red y políticas de equipo a gran escala.  
- Integración de un instalador personalizado (MSI) que incorpore estas configuraciones durante la instalación de software.