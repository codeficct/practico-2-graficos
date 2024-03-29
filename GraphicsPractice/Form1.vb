﻿Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form1
    Dim graphic As Graphics
    Dim timing As Integer = 99000000
    Dim msgError As String = "Importante: Datos incorrectos (número) o faltantes. "
    ' * i18n languages ES - EN
    Dim menu1Es As String = "Información del estudiante" : Dim menu1En As String = "Student information"
    Dim menu1Content1Es = "Ver información" : Dim menu1Content1En As String = "See information"
    Dim menu2Es As String = "Gráficos simétricos" : Dim menu2En As String = "Symetric graphics"
    Dim menu3Es As String = "Gráficos Aleatorios" : Dim menu3En As String = "Random graphics"
    Dim graphicTextEs As String = "Linea simétrica" : Dim graphicTextEn As String = "Symmetric line"
    Dim labelTitleBarEs As String = "Práctico de Gráficos" : Dim labelTitleBarEn As String = "Graphic Practice"
    Dim labelTextBoxEs As String = "Escribir n partes/líneas" : Dim labelTextBoxEn As String = "Write n parts/lines"
    Dim btnCreateGraphicEs As String = "Crear gráfico" : Dim btnCreateGraphicEn As String = "Create graphic"
    Dim btnCleanGraphicsEs As String = "Limpiar gráficos" : Dim btnCleanGraphicsEn As String = "Clean graphics"
    Dim btnResetEs As String = "Reiciar" : Dim btnResetEn As String = "Reset"
    Dim changeEs As String = "Cambiar idioma" : Dim changeEn As String = "Change language"

    ' * Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private borderRadius As Integer = 8
    Private borderSize As Integer = 0
    Private borderColor As Color = Color.Transparent
    Public Sub New()
        ' * This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Padding = New Padding(borderSize)
    End Sub
    ' * Add rounded in windows form
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
    ' * Active mouse donw or drag event in title bar
    Private Sub panelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles panelTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub
    ' * Title bar actions (minimize, maximize, close)
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
        RadioButton3.Checked = True
        RadioButton4.Checked = False
        graphic = PictureBox1.CreateGraphics
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        timing = 99000000
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        timing = 20000000
    End Sub

    Private Sub VerInformaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerInformaciónToolStripMenuItem.Click
        Dim info As String = "Name: Luis Gabriel Janco Alvarez" & vbCrLf & "Group:'INF110 - SD" & vbCrLf & "Registry N.: 220104875" & vbCrLf & "Career: Ingenieria en Sistemas" & vbCrLf & "Teacher: Alberto Mollo M."
        MsgBox(info, MsgBoxStyle.Information, Title:="Student Information")
    End Sub
    ' * Spanish
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        InformaciónDelEstudianteToolStripMenuItem.Text = menu1Es
        VerInformaciónToolStripMenuItem.Text = menu1Content1Es
        GraphicToolStripMenuItem.Text = "1. " + graphicTextEs
        GraphicToolStripMenuItem1.Text = "2. " + graphicTextEs
        GraphicToolStripMenuItem2.Text = "3. " + graphicTextEs
        GraphicToolStripMenuItem3.Text = "4. " + graphicTextEs
        GraphicToolStripMenuItem4.Text = "5. " + graphicTextEs + " bezier"
        GraphicToolStripMenuItem5.Text = "6. " + graphicTextEs + " aleatoria"
        GraphicToolStripMenuItem6.Text = "7. " + graphicTextEs + " aleatoria"
        GraphicToolStripMenuItem7.Text = "8. " + graphicTextEs + " aleatoria"
        GraphicToolStripMenuItem8.Text = "9. " + graphicTextEs + " aleatoria"
        GraphicToolStripMenuItem9.Text = "10. " + graphicTextEs + " aleatoria"
        SymmetricGraphicsToolStripMenuItem.Text = "Lineas simétricas"
        RandomGraphicsToolStripMenuItem.Text = "Lineas aleatorias random"
        RectangleToolStripMenuItem.Text = "Rectangulos simétricos"
        ToolStripMenuItem1.Text = "Elipses simétricas"
        ToolStripMenuItem2.Text = "1. " + "Rectangulos"
        RectangleToolStripMenuItem1.Text = "2. " + "Rectangulos"
        RectangleToolStripMenuItem2.Text = "3. " + "Rectangulos"
        RectangleToolStripMenuItem3.Text = "4. " + "Rectangulos"
        RectangleRandomToolStripMenuItem.Text = "5. " + "Rectangulos aleatorios"
        RectangleRandomToolStripMenuItem1.Text = "6. " + "Rectangulos aleatorios"
        RectangleRandomToolStripMenuItem2.Text = "7. " + "Rectangulos aleatorios"
        RectangleRandomToolStripMenuItem3.Text = "8. " + "Rectangulos aleatorios"
        ToolStripMenuItem3.Text = "1. " + "Elipses"
        ToolStripMenuItem4.Text = "2. " + "Elipses"
        ToolStripMenuItem5.Text = "3. " + "Elipses"
        ToolStripMenuItem6.Text = "4. " + "Elipses"
        ToolStripMenuItem7.Text = "5. " + "Elipses aleatorias"
        ToolStripMenuItem8.Text = "6. " + "Elipses aleatorias"
        ToolStripMenuItem9.Text = "7. " + "Elipses aleatorias"
        ToolStripMenuItem10.Text = "8. " + "Elipses aleatorias"
        Label1.Text = changeEs
        Label2.Text = labelTextBoxEs
        Label3.Text = labelTitleBarEs
        Label4.Text = "Aquí se pintara el gráfico:"
        Label15.Text = "Ancho"
        Label16.Text = "Alto"
        Label23.Text = "Retardo"
        Button1.Text = btnCreateGraphicEs
        Button2.Text = btnCleanGraphicsEs
        Button3.Text = btnResetEs
        RadioButton4.Text = "Rapido"
        RadioButton3.Text = "Lento"
    End Sub
    ' * English
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        InformaciónDelEstudianteToolStripMenuItem.Text = menu1En
        VerInformaciónToolStripMenuItem.Text = menu1Content1En
        GraphicToolStripMenuItem.Text = "1. " + graphicTextEn
        GraphicToolStripMenuItem1.Text = "2. " + graphicTextEn
        GraphicToolStripMenuItem2.Text = "3. " + graphicTextEn
        GraphicToolStripMenuItem3.Text = "4. " + graphicTextEn
        GraphicToolStripMenuItem4.Text = "5. " + graphicTextEn
        GraphicToolStripMenuItem5.Text = "6. " + graphicTextEn + " random"
        GraphicToolStripMenuItem6.Text = "7. " + graphicTextEn + " random"
        GraphicToolStripMenuItem7.Text = "8. " + graphicTextEn + " random"
        GraphicToolStripMenuItem8.Text = "9. " + graphicTextEn + " random"
        GraphicToolStripMenuItem9.Text = "10. " + graphicTextEn + " random"
        SymmetricGraphicsToolStripMenuItem.Text = "Symmetric lines"
        RandomGraphicsToolStripMenuItem.Text = "Symmetric random lines"
        RectangleToolStripMenuItem.Text = "Symmetric rectangles"
        ToolStripMenuItem1.Text = "Symmetric ellipses"
        ToolStripMenuItem2.Text = "1. " + "Rectangles"
        RectangleToolStripMenuItem1.Text = "2. " + "Rectangles"
        RectangleToolStripMenuItem2.Text = "3. " + "Rectangles"
        RectangleToolStripMenuItem3.Text = "4. " + "Rectangles"
        RectangleRandomToolStripMenuItem.Text = "5. " + "Rectangle random"
        RectangleRandomToolStripMenuItem1.Text = "6. " + "Rectangle random"
        RectangleRandomToolStripMenuItem2.Text = "7. " + "Rectangle random"
        RectangleRandomToolStripMenuItem3.Text = "8. " + "Rectangle random"
        ToolStripMenuItem3.Text = "1. " + "Ellipses"
        ToolStripMenuItem4.Text = "2. " + "Ellipses"
        ToolStripMenuItem5.Text = "3. " + "Ellipses"
        ToolStripMenuItem6.Text = "4. " + "Ellipses"
        ToolStripMenuItem7.Text = "5. " + "Ellipses random"
        ToolStripMenuItem8.Text = "6. " + "Ellipses random"
        ToolStripMenuItem9.Text = "7. " + "Ellipses random"
        ToolStripMenuItem10.Text = "8. " + "Ellipses random"
        Label1.Text = changeEn
        Label2.Text = labelTextBoxEn
        Label3.Text = labelTitleBarEn
        Label4.Text = "The graph will be drawn here:"
        Label15.Text = "Width"
        Label16.Text = "Height"
        Label23.Text = "Time delay"
        Button1.Text = btnCreateGraphicEn
        Button2.Text = btnCleanGraphicsEn
        Button3.Text = btnResetEn
    End Sub
    Public Sub Frame()
        graphic.DrawRectangle(Pens.Black, 0, 0, PictureBox1.Width - 1, PictureBox1.Height - 1)
        Label5.Text = "Width =" + Str(PictureBox1.Width)
        Label6.Text = "Height =" + Str(PictureBox1.Height)
    End Sub
    ' * Create rectangle with a line in halft
    Public Sub CreateRectangleWithHalf(ax As Single, bx As Single, ay As Single, by As Single, align As String)
        Dim half As Single
        Using pen As New Pen(Color.Green)
            pen.Width = 2
            graphic.DrawRectangle(pen, ax, ay, bx - ax, by - ay)
            Select Case align
                Case "vertical"
                    half = (ax + bx) / 2
                    graphic.DrawLine(pen, half, ay, half, by) ' * Vertical
                Case "horizontal"
                    half = (ay + by) / 2
                    graphic.DrawLine(pen, ax, half, bx, half) ' * Horizontal
                Case Else
            End Select
        End Using
    End Sub
    Public Sub GraphicRandomColor(x As Single, y As Single, w As Single, h As Single, gName As String)
        Dim rng As New Random()
        Using pen = New Pen(Color.FromArgb(rng.Next(256), rng.Next(156), rng.Next(200)))
            pen.Width = 2
            Select Case gName
                Case "line"
                    graphic.DrawLine(pen, x, y, w, h) ' * x1, y1, x2, y2
                Case "rectangle"
                    graphic.DrawRectangle(pen, x, y, w, h)
                Case "ellipse"
                    graphic.DrawEllipse(pen, x, y, w, h)
                Case Else

            End Select
        End Using
    End Sub
    ' * 1. Exercice symmetric graphics
    Public Sub SymmetricGraphic1(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, mx, halfmy, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : halfmy = (ay + by) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "horizontal") ' Horizontal
        r1 = mx / n : vi1 = ax
        r2 = (halfmy - ay) / n : x2 = bx
        If half Then
            y1 = halfmy : vi2 = ay
        Else
            y1 = by : vi2 = halfmy
        End If
        For index = 1 To n
            x1 = vi1 + (index - 1) * r1
            y2 = vi2 + (index - 1) * r2
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub
    ' *  2. Exercice symmetric graphics
    Public Sub SymmetricGraphic2(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        r = my / n : vi = ay
        y1 = (ay + by) / 2
        x2 = halfmx
        If half Then
            x1 = ax
        Else
            x1 = bx
        End If
        For index = 1 To n + 1
            y2 = vi + (index - 1) * r
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub
    ' *  3. Exercice symmetric graphics
    Public Sub SymmetricGraphic3(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        r = my / n : vi = ay
        x2 = halfmx : y2 = (ay + by) / 2
        If half Then
            x1 = ax
        Else
            x1 = bx
        End If
        For index = 1 To n + 1
            y1 = vi + (index - 1) * r
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub
    ' *  4. Exercice symmetric graphics
    Public Sub SymmetricGraphic4(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        r = my / n : vi = ay : x2 = halfmx
        If half Then
            x1 = ax : y1 = by
        Else
            x1 = bx : y1 = ay
        End If
        For index = 1 To n
            y2 = vi + (index - 1) * r
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub
    ' *  5. Exercice symmetric graphics
    Public Sub SymmetricGraphic5(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, mx, halfmx, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        r1 = my / n : vi1 = ay : x1 = halfmx
        r2 = (mx / 2) / n : y2 = by
        If half Then
            vi2 = halfmx + r2
        Else
            vi2 = halfmx - r2
        End If
        For index = 1 To n
            y1 = vi1 + (index - 1) * r1

            If half Then
                x2 = vi2 + (index - 1) * r2
                GraphicRandomColor(x1, y1, x2, y2, "line")
            Else
                x2 = vi2 - (index - 1) * r2
                GraphicRandomColor(x1, y1, x2, y2, "line")
            End If
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 6. Exercise random graphics
    Public Sub RandomLines6(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx, halfmy As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2 : halfmy = (ay + by) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        x1 = halfmx : y1 = halfmy
        For index = 1 To n
            y2 = ay + Rnd() * my
            If half Then
                x2 = halfmx + Rnd() * (bx - halfmx)
            Else
                x2 = ax + Rnd() * (halfmx - ax)
            End If
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 7. Exercise random graphics
    Public Sub RandomLines7(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        y1 = ay + (my / 2)
        If half Then
            x1 = (ax + halfmx) / 2
        Else
            x1 = halfmx + ((bx - ax) / 2) / 2
        End If
        For index = 1 To n
            y2 = ay + Rnd() * my
            If half Then
                x2 = ax + Rnd() * (halfmx - ax)
            Else
                x2 = halfmx + Rnd() * (bx - halfmx)
            End If
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To 66000000
            Next
        Next
    End Sub

    ' * 8. Exercice random graphics
    Public Sub RandomLines8(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        my = by - ay : halfmx = (ax + bx) / 2 : x1 = halfmx
        For index = 1 To n
            y1 = ay + Rnd() * my
            If half Then
                x2 = halfmx + Rnd() * (bx - halfmx)
            Else
                x2 = ax + Rnd() * (halfmx - ax)
            End If
            y2 = y1
            GraphicRandomColor(x1, y1, x2, y2, "line")
            For j = 1 To timing
            Next
        Next
    End Sub
    ' * 9 Exercice random graphics
    Public Sub RandomLines9(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, halfmx As Single
        Dim aux As Boolean = True
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        halfmx = (bx + ax) / 2 : y1 = ay : y2 = by
        If half Then
            x1 = ax + Rnd() * (halfmx - ax)
        Else
            x1 = halfmx + Rnd() * (bx - halfmx)
        End If
        For index = 1 To n
            If half Then
                x2 = ax + Rnd() * (halfmx - ax)
            Else
                x2 = halfmx + Rnd() * (bx - halfmx)
            End If
            If aux Then
                GraphicRandomColor(x1, y1, x2, y2, "line")
            Else
                GraphicRandomColor(x1, y2, x2, y1, "line")
            End If
            aux = Not aux
            x1 = x2
            For j = 1 To timing
            Next
        Next
    End Sub
    ' * 10 Exercice random graphics
    Public Sub RandomLines10(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        CreateRectangleWithHalf(ax, bx, ay, by, "vertical") 'Vertical
        If half Then
            x1 = ax + Rnd() * (halfmx - ax) : y1 = ay + Rnd() * my
        Else
            x1 = halfmx + Rnd() * (bx - halfmx) : y1 = ay + Rnd() * my
        End If
        For index = 1 To n
            If half Then
                x2 = ax + Rnd() * (halfmx - ax) : y2 = ay + Rnd() * my
            Else
                x2 = halfmx + Rnd() * (bx - halfmx) : y2 = ay + Rnd() * my
            End If
            GraphicRandomColor(x1, y1, x2, y2, "line")
            x1 = x2 : y1 = y2
            For j = 1 To timing
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Refresh()
        Frame()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        RadioButton3.Checked = True
        RadioButton4.Checked = False
    End Sub

    Private Sub GraphicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem.Click
        Try
            SymmetricGraphic1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            SymmetricGraphic1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="1. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem1.Click
        Try
            SymmetricGraphic2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            SymmetricGraphic2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="2. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem2.Click
        Try
            SymmetricGraphic3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            SymmetricGraphic3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="3. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem3.Click
        Try
            SymmetricGraphic4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            SymmetricGraphic4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="4. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem4.Click
        Try
            SymmetricGraphic5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            SymmetricGraphic5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="5. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem5.Click
        Try
            RandomLines6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            RandomLines6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="6. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem6.Click
        Try
            RandomLines7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            RandomLines7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="7. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem7.Click
        Try
            RandomLines8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            RandomLines8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="8. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem8.Click
        Try
            RandomLines9(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            RandomLines9(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="9. Gráfico")
        End Try
    End Sub

    Private Sub GraphicToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles GraphicToolStripMenuItem9.Click
        Try
            RandomLines10(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
            RandomLines10(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="10. Gráfico")
        End Try
    End Sub

    ' * <--- SECOND PART OF PRACTICE --->
    ' * 1. Symmetric Rectangle
    Public Sub SymmetricRectangle1(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, graphicName As String)
        Dim x, y, w, h, r1, r2, r3, vi1, vi2, vi3 As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "")
        vi1 = ax : r1 = (bx - ax) / ((2 * n) - 1)
        vi2 = bx - ax : r2 = -r1 * 2
        y = ay
        vi3 = by - ay : r3 = -(by - ay) / n
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            w = vi2 + (index - 1) * r2
            h = vi3 + (index - 1) * r3
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 2. Symmetric Rectangle
    Public Sub SymmetricRectangle2(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, graphicName As String)
        Dim x, y, w, h, r1, vi1 As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "")
        r1 = (by - ay) / n : vi1 = ay
        x = ((bx + ax) / 2) - (r1 / 2)
        w = r1
        h = r1
        For index = 1 To n
            y = vi1 + (index - 1) * r1
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 3. Symmetric Rectangle
    Public Sub SymmetricRectangle3(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, graphicName As String)
        Dim x, y, w, h, vi1, vi2, vi3, r1, r2, r3 As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "")
        r1 = (bx - ax) / n : vi1 = ax
        w = r1
        r2 = (by - ay) / n : vi2 = by - r2
        r3 = r2 : vi3 = r3
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            y = vi2 - (index - 1) * r2
            h = vi3 + (index - 1) * r3
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 4. Symmetric Rectangle
    Public Sub SymmetricRectangle4(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, graphicName As String)
        Dim x, y, w, h, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "")
        r1 = (bx - ax) / (n + 1) : vi1 = ax : w = r1 * 2
        r2 = (by - ay) / (n + 1) : vi2 = by - (r2 * 2) : h = r2 * 2
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            y = vi2 - (index - 1) * r2
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 5. Symmetric Rectangle Random
    Public Sub SymmetricRectangleRandom5(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean, graphicName As String)
        Dim x, y, w, h, halfmy As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "horizontal")
        halfmy = (by + ay) / 2
        For index = 1 To n
            If half Then
                y = halfmy + Rnd() * (by - halfmy)
                h = Rnd() * (by - y)
            Else
                y = ay + Rnd() * (halfmy - ay)
                h = Rnd() * (halfmy - y)
            End If
            x = ax + Rnd() * (bx - ax)
            w = Rnd() * (bx - x)
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    ' * 6. Symmetric Rectangle Random
    Public Sub SymmetricRectangleRandom6(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean, graphicName As String)
        Dim x, y, w, h, halfmy, limit As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "horizontal")
        halfmy = (ay + by) / 2
        If half Then
            y = ay : limit = halfmy - y
        Else
            y = halfmy : limit = by - y
        End If
        For index = 1 To n
            h = Rnd() * limit
            x = ax + Rnd() * (bx - ax)
            w = bx - x
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub
    ' * 7. Symmetric Rectangle Random
    Public Sub SymmetricRectangleRandom7(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean, graphicName As String)
        Dim x, y, w, h, halfmy As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "horizontal")
        halfmy = (by + ay) / 2
        For index = 1 To n
            If half Then
                y = ay + Rnd() * (halfmy - ay)
                h = Rnd() * (halfmy - y)
            Else
                y = halfmy + Rnd() * (by - halfmy)
                h = Rnd() * (by - y)
            End If
            x = ax + Rnd() * (bx - ax)
            w = bx - x
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub
    ' * 8. Symmetric Rectangle Random
    Public Sub SymmetricRectangleRandom8(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, graphicName As String)
        Dim x, y, w, h, halfmy, halfmx As Single
        Dim index, j As UInt32
        CreateRectangleWithHalf(ax, bx, ay, by, "")
        halfmy = (by + ay) / 2 : halfmx = (bx + ax) / 2
        For index = 1 To n
            x = ax + Rnd() * (halfmx - ax)
            y = ay + Rnd() * (halfmy - ay)
            w = (halfmx - x) * 2
            h = (halfmy - y) * 2
            GraphicRandomColor(x, y, w, h, graphicName)
            For j = 1 To timing
            Next
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            SymmetricRectangle1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="1. Rectangulo Simetrico")
        End Try
    End Sub

    Private Sub RectangleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem1.Click
        Try
            SymmetricRectangle2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="2. Rectangulo Simetrico")
        End Try
    End Sub

    Private Sub RectangleToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem2.Click
        Try
            SymmetricRectangle3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="3. Rectangulo Simetrico")
        End Try
    End Sub

    Private Sub RectangleToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem3.Click
        Try
            SymmetricRectangle4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="4. Rectangulo Simetrico")
        End Try
    End Sub

    Private Sub RectangleRandomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RectangleRandomToolStripMenuItem.Click
        Try
            SymmetricRectangleRandom5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "rectangle")
            SymmetricRectangleRandom5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="5. Rectangulo Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub RectangleRandomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RectangleRandomToolStripMenuItem1.Click
        Try
            SymmetricRectangleRandom6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "rectangle")
            SymmetricRectangleRandom6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="6. Rectangulo Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub RectangleRandomToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RectangleRandomToolStripMenuItem2.Click
        Try
            SymmetricRectangleRandom7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "rectangle")
            SymmetricRectangleRandom7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="7. Rectangulo Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub RectangleRandomToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RectangleRandomToolStripMenuItem3.Click
        Try
            SymmetricRectangleRandom8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "rectangle")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="8. Rectangulo Simetrico Aleatorio")
        End Try
    End Sub
    ' * Ellipse Handlers
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            SymmetricRectangle1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="1. Elipse Simetrico")
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            SymmetricRectangle2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="2. Elipse Simetrico")
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            SymmetricRectangle3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="3. Elipse Simetrico")
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Try
            SymmetricRectangle4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="4. Elipse Simetrico")
        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Try
            SymmetricRectangleRandom5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "ellipse")
            SymmetricRectangleRandom5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="5. Elipse Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Try
            SymmetricRectangleRandom6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "ellipse")
            SymmetricRectangleRandom6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="6. Elipse Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Try
            SymmetricRectangleRandom7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True, "ellipse")
            SymmetricRectangleRandom7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="7. Elipse Simetrico Aleatorio")
        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Try
            SymmetricRectangleRandom8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, "ellipse")
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="8. Elipse Simetrico Aleatorio")
        End Try
    End Sub
End Class
