Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form1
    Dim graphic As Graphics
    Dim msgError As String = "Importante: Datos incorrectos (número) o faltantes. "
    'i18n languages ES - EN
    Dim menu1Es As String = "Información del estudiante" : Dim menu1En As String = "Student information"
    Dim menu1Content1Es = "Ver información" : Dim menu1Content1En As String = "See information"
    Dim menu2Es As String = "Gráficos simétricos" : Dim menu2En As String = "Symetric graphics"
    Dim menu3Es As String = "Gráficos Aleatorios" : Dim menu3En As String = "Random graphics"
    Dim graphicTextEs As String = "Gráfico" : Dim graphicTextEn As String = "Graphic"
    Dim labelTitleBarEs As String = "Práctico de Gráficos" : Dim labelTitleBarEn As String = "Graphic Practice"
    Dim labelTextBoxEs As String = "Escribir n partes/líneas" : Dim labelTextBoxEn As String = "Write n parts/lines"
    Dim btnCreateGraphicEs As String = "Crear gráfico" : Dim btnCreateGraphicEn As String = "Create graphic"
    Dim btnCleanGraphicsEs As String = "Limpiar gráficos" : Dim btnCleanGraphicsEn As String = "Clean graphics"
    Dim btnResetEs As String = "Reiciar" : Dim btnResetEn As String = "Reset"
    Dim changeEs As String = "Cambiar idioma" : Dim changeEn As String = "Change language"


    'Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private borderRadius As Integer = 8
    Private borderSize As Integer = 0
    Private borderColor As Color = Color.Transparent
    'Constructor
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Padding = New Padding(borderSize)
        'Me.panelTitleBar.BackColor = borderColor
        'Me.BackColor = borderColor
    End Sub
    Private Function GetRoundedPath(rect As Rectangle, radius As Single) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath()
        Dim curveSize As Single = radius * 2.0F
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90)
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90)
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90)
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90)
        path.CloseFigure()
        Return path
    End Function
    Private Sub FormRegionAndBorder(form As Form, radius As Single, graph As Graphics, borderColor As Color, borderSize As Single)
        If Me.WindowState <> FormWindowState.Minimized Then
            Using roundPath As GraphicsPath = GetRoundedPath(form.ClientRectangle, radius)
                Using penBorder As Pen = New Pen(borderColor, borderSize)
                    Using transform As Matrix = New Matrix()
                        graph.SmoothingMode = SmoothingMode.AntiAlias
                        form.Region = New Region(roundPath)
                        If borderSize >= 1 Then
                            Dim rect As Rectangle = form.ClientRectangle
                            Dim scaleX As Single = 1.0F - ((borderSize + 1) / rect.Width)
                            Dim scaleY As Single = 1.0F - ((borderSize + 1) / rect.Height)
                            transform.Scale(scaleX, scaleY)
                            transform.Translate(borderSize / 1.6F, borderSize / 1.6F)
                            graph.Transform = transform
                            graph.DrawPath(penBorder, roundPath)
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        FormRegionAndBorder(Me, borderRadius, e.Graphics, borderColor, borderSize)
    End Sub

    Private Sub panelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles panelTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Me.WindowState = WindowState.Normal Then
            Me.WindowState = WindowState.Maximized
        ElseIf Me.WindowState = WindowState.Maximized Then
            Me.WindowState = WindowState.Normal
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        graphic = PictureBox1.CreateGraphics
    End Sub

    Private Sub VerInformaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerInformaciónToolStripMenuItem.Click
        Dim info As String = "Name: Luis Gabriel Janco Alvarez" & vbCrLf & "Group:'INF110 - SD" & vbCrLf & "Registry N.: 220104875" & vbCrLf & "Career: Ingenieria en Sistemas" & vbCrLf & "Teacher: Alberto Mollo M."
        MsgBox(info, MsgBoxStyle.Information, Title:="Student Information")
    End Sub
    'Spanish
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        InformaciónDelEstudianteToolStripMenuItem.Text = menu1Es
        VerInformaciónToolStripMenuItem.Text = menu1Content1Es
        GraphicToolStripMenuItem.Text = "1. " + graphicTextEs
        GraphicToolStripMenuItem1.Text = "2. " + graphicTextEs
        GraphicToolStripMenuItem2.Text = "3. " + graphicTextEs
        GraphicToolStripMenuItem3.Text = "4. " + graphicTextEs
        GraphicToolStripMenuItem4.Text = "5. " + graphicTextEs
        GraphicToolStripMenuItem5.Text = "6. " + graphicTextEs
        GraphicToolStripMenuItem6.Text = "7. " + graphicTextEs
        GraphicToolStripMenuItem7.Text = "8. " + graphicTextEs
        GraphicToolStripMenuItem8.Text = "9. " + graphicTextEs
        GraphicToolStripMenuItem9.Text = "10. " + graphicTextEs
        SymmetricGraphicsToolStripMenuItem.Text = menu2Es
        RandomGraphicsToolStripMenuItem.Text = menu3Es
        Label1.Text = changeEs
        Label2.Text = labelTextBoxEs
        Label3.Text = labelTitleBarEs
        Label4.Text = "Aquí se pintara el gráfico:"
        Label15.Text = "Ancho"
        Label16.Text = "Alto"
        Button1.Text = btnCreateGraphicEs
        Button2.Text = btnCleanGraphicsEs
        Button3.Text = btnResetEs
    End Sub
    'English
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        InformaciónDelEstudianteToolStripMenuItem.Text = menu1En
        VerInformaciónToolStripMenuItem.Text = menu1Content1En
        GraphicToolStripMenuItem.Text = "1. " + graphicTextEn
        GraphicToolStripMenuItem1.Text = "2. " + graphicTextEn
        GraphicToolStripMenuItem2.Text = "3. " + graphicTextEn
        GraphicToolStripMenuItem3.Text = "4. " + graphicTextEn
        GraphicToolStripMenuItem4.Text = "5. " + graphicTextEn
        GraphicToolStripMenuItem5.Text = "6. " + graphicTextEn
        GraphicToolStripMenuItem6.Text = "7. " + graphicTextEn
        GraphicToolStripMenuItem7.Text = "8. " + graphicTextEn
        GraphicToolStripMenuItem8.Text = "9. " + graphicTextEn
        GraphicToolStripMenuItem9.Text = "10. " + graphicTextEn
        SymmetricGraphicsToolStripMenuItem.Text = menu2En
        RandomGraphicsToolStripMenuItem.Text = menu3En
        Label1.Text = changeEn
        Label2.Text = labelTextBoxEn
        Label3.Text = labelTitleBarEn
        Label4.Text = "The graph will be drawn here:"
        Label15.Text = "Width"
        Label16.Text = "Height"
        Button1.Text = btnCreateGraphicEn
        Button2.Text = btnCleanGraphicsEn
        Button3.Text = btnResetEn
    End Sub

    Public Sub Frame()
        graphic.DrawRectangle(Pens.Black, 0, 0, PictureBox1.Width - 1, PictureBox1.Height - 1)
        Label5.Text = "Width =" + Str(PictureBox1.Width)
        Label6.Text = "Height =" + Str(PictureBox1.Height)
    End Sub

    Public Sub createRectangleWithHalf(ax As Single, bx As Single, ay As Single, by As Single, vertical As Double)
        Dim half As Single
        graphic.DrawRectangle(Pens.Purple, ax, ay, bx - ax, by - ay)
        If vertical Then
            half = (ax + bx) / 2
            graphic.DrawLine(Pens.Purple, half, ay, half, by)
        Else
            half = (ay + by) / 2
            graphic.DrawLine(Pens.Purple, ax, half, bx, half)
        End If
    End Sub

    Public Sub SymmetricGraphic1(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x1, x2, y1, y2, my, mx, halfmy, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : halfmy = (ay + by) / 2
        createRectangleWithHalf(ax, bx, ay, by, False)
        r1 = mx / n : vi1 = ax : y1 = halfmy
        r2 = (halfmy - ay) / n : vi2 = ay : x2 = bx
        For index = 1 To n
            x1 = vi1 + (index - 1) * r1
            y2 = vi2 + (index - 1) * r2
            graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub

    Public Sub SymetricGraphic1_2(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x1, x2, y1, y2, my, mx, halfmy, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : my = by - ay 'max width and max height
        halfmy = (ay + by) / 2
        r1 = mx / n : vi1 = ax : y1 = by
        r2 = (halfmy - ay) / n : vi2 = halfmy : x2 = bx
        For index = 1 To n
            x1 = vi1 + (index - 1) * r1
            y2 = vi2 + (index - 1) * r2
            graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub

    '<--- EVENTS HANDLER --->
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Frame()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Refresh()
        Frame()
    End Sub

    Private Sub GraphicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem.Click
        Try
            SymmetricGraphic1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
            SymetricGraphic1_2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="1. Gráfico")
        End Try
    End Sub
End Class
