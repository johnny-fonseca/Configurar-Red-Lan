
Imports System.Diagnostics
Imports System.IO

Public Class Form1
    'CONFIGURAR PC 1

    Private Sub btnConfigurar1_Click(sender As Object, e As EventArgs) Handles btnConfigurar1.Click
        txtOutput.Clear()
        Log("Ejecutando configuración para PC1...")

        ' Verifica adaptador conectado
        Dim conectado = RunCmd("netsh interface show interface").Any(Function(l) l.ToLower.Contains("conectado"))
        If conectado Then
            Log("Adaptador Ethernet conectado.")
        Else
            Log("No hay adaptadores conectados.")
        End If

        ' Asignar IP estática
        Log("Asignando IP fija...")
        RunCmd("netsh interface ip set address name=""Ethernet"" static 192.168.1.2 255.255.255.0 192.168.1.1")
        RunCmd("netsh interface ip set dns name=""Ethernet"" static 8.8.8.8")
        RunCmd("netsh interface ip add dns name=""Ethernet"" 8.8.4.4 index=2")
        Log("IP asignada.")

        ' Cambiar perfil de red a privada
        Log("Cambiando red a privada...")
        RunCmd("powershell -Command ""Get-NetConnectionProfile | Where-Object {_.IPv4Connectivity -ne 'None' | ForEach-Object if (_.NetworkCategory -ne 'Private') {Set-NetConnectionProfile -InterfaceIndex _.InterfaceIndex -NetworkCategory Private""")

        ' Crear carpeta compartida
        Dim carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "compartir")
        If Not Directory.Exists(carpeta) Then Directory.CreateDirectory(carpeta)
        RunCmd("icacls ""{carpeta}"" /grant Todos:(OI)(CI)F /T /C /Q")
        RunCmd("net share compartir=""carpeta"" /GRANT:Todos,FULL /REMARK:""Carpeta compartida para red local""")
        Log("Carpeta compartida creada.")

        ' Renombrar equipo
        Dim pcActual = Environment.MachineName
        If pcActual.ToLower <> "pc1" Then
            Log("Renombrando equipo a 'pc1'...")
            RunCmd("wmic computersystem where name=""{pcActual}"" call rename name=""pc1""")
            Log("Nombre cambiado. Reiniciando...")
            RunCmd("shutdown /r /t 5")
        Else
            Log("El equipo ya se llama 'pc1'.")
        End If
    End Sub
    'CONFIGURAR PC 2
    Private Sub btnConfigurar2_Click(sender As Object, e As EventArgs) Handles btnConfigurar2.Click
        txtOutput.Clear()
        Log("Ejecutando configuración para PC1...")

        ' Verifica adaptador conectado
        Dim conectado = RunCmd("netsh interface show interface").Any(Function(l) l.ToLower.Contains("conectado"))
        If conectado Then
            Log("Adaptador Ethernet conectado.")
        Else
            Log("No hay adaptadores conectados.")
        End If

        ' Asignar IP estática
        Log("Asignando IP fija...")
        RunCmd("netsh interface ip set address name=""Ethernet"" static 192.168.1.3 255.255.255.0 192.168.1.1")
        RunCmd("netsh interface ip set dns name=""Ethernet"" static 8.8.8.8")
        RunCmd("netsh interface ip add dns name=""Ethernet"" 8.8.4.4 index=2")
        Log("IP asignada.")

        ' Cambiar perfil de red a privada
        Log("Cambiando red a privada...")
        RunCmd("powershell -Command ""Get-NetConnectionProfile | Where-Object {_.IPv4Connectivity -ne 'None' | ForEach-Object if (_.NetworkCategory -ne 'Private') {Set-NetConnectionProfile -InterfaceIndex _.InterfaceIndex -NetworkCategory Private""")

        ' Crear carpeta compartida
        Dim carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "compartir")
        If Not Directory.Exists(carpeta) Then Directory.CreateDirectory(carpeta)
        RunCmd("icacls ""{carpeta}"" /grant Todos:(OI)(CI)F /T /C /Q")
        RunCmd("net share compartir=""carpeta"" /GRANT:Todos,FULL /REMARK:""Carpeta compartida para red local""")
        Log("Carpeta compartida creada.")

        ' Renombrar equipo
        Dim pcActual = Environment.MachineName
        If pcActual.ToLower <> "pc2" Then
            Log("Renombrando equipo a 'pc2'...")
            RunCmd("wmic computersystem where name=""{pcActual}"" call rename name=""pc2""")
            Log("Nombre cambiado. Reiniciando...")
            RunCmd("shutdown /r /t 5")
        Else
            Log("El equipo ya se llama 'pc2'.")
        End If
    End Sub

    Private Function RunCmd(cmd As String) As List(Of String)
        Dim psi As New ProcessStartInfo("cmd.exe", "/c " & cmd) With {
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Dim output As New List(Of String)
        Using p As Process = Process.Start(psi)
            While Not p.StandardOutput.EndOfStream
                Dim line = p.StandardOutput.ReadLine()
                output.Add(line)
                Log(line)
            End While
        End Using
        Return output
    End Function

    Private Sub Log(msg As String)
        txtOutput.AppendText(msg & Environment.NewLine)
    End Sub
End Class
