Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form1
    Dim graphic As Graphics
    Dim msgError As String = "Importante: Datos incorrectos (número) o faltantes. "
    ' * i18n languages ES - EN
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
        graphic = PictureBox1.CreateGraphics
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
    ' * English
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
    ' * Create rectangle with a line in halft
    Public Sub createRectangleWithHalf(ax As Single, bx As Single, ay As Single, by As Single, vertical As Double)
        Dim half As Single
        graphic.DrawRectangle(Pens.Purple, ax, ay, bx - ax, by - ay)
        If vertical Then
            half = (ax + bx) / 2
            graphic.DrawLine(Pens.Purple, half, ay, half, by) ' * Vertical
        Else
            half = (ay + by) / 2
            graphic.DrawLine(Pens.Purple, ax, half, bx, half) ' * Horizontal
        End If
    End Sub
    ' * 1. Exercice symmetric graphics
    Public Sub SymmetricGraphic1(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
        Dim x1, x2, y1, y2, mx, halfmy, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : halfmy = (ay + by) / 2
        createRectangleWithHalf(ax, bx, ay, by, False) ' Horizontal
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
            graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub
    ' *  2. Exercice symmetric graphics
    Public Sub SymmetricGraphic2(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
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
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub
    ' *  3. Exercice symmetric graphics
    Public Sub SymmetricGraphic3(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        r = my / n : vi = ay
        x2 = halfmx : y2 = (ay + by) / 2
        If half Then
            x1 = ax
        Else
            x1 = bx
        End If
        For index = 1 To n + 1
            y1 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Red, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub
    ' *  4. Exercice symmetric graphics
    Public Sub SymmetricGraphic4(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx, r, vi As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        r = my / n : vi = ay : x2 = halfmx
        If half Then
            x1 = ax : y1 = by
        Else
            x1 = bx : y1 = ay
        End If
        For index = 1 To n
            y2 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Green, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub
    ' *  5. Exercice symmetric graphics
    Public Sub SymmetricGraphic5(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, mx, halfmx, r1, r2, vi1, vi2 As Single
        Dim index, j As UInt32
        mx = bx - ax : my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
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
            Else
                x2 = vi2 - (index - 1) * r2
            End If
            graphic.DrawLine(Pens.Brown, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub
    ' * 6. Exercise random graphics
    Public Sub RandomLines6(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx, halfmy As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2 : halfmy = (ay + by) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        x1 = halfmx : y1 = halfmy
        For index = 1 To n
            y2 = ay + Rnd() * my
            If half Then
                x2 = halfmx + Rnd() * (bx - halfmx)
            Else
                x2 = ax + Rnd() * (halfmx - ax)
            End If
            graphic.DrawLine(Pens.BlueViolet, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub

    '<--- 7 --->
    Public Sub RandomLines7(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        y1 = ay + (my / 2)
        If half Then
            x1 = ax + (halfmx / 2)
        Else
            x1 = halfmx + (halfmx / 2)
        End If
        For index = 1 To n
            y2 = ay + Rnd() * my
            If half Then
                x2 = ax + Rnd() * (halfmx - ax)
            Else
                x2 = halfmx + Rnd() * (bx - halfmx)
            End If
            graphic.DrawLine(Pens.DeepSkyBlue, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub

    '<--- 8 --->
    Public Sub RandomLines8(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        my = by - ay : halfmx = (ax + bx) / 2 : x1 = halfmx
        For index = 1 To n
            y1 = ay + Rnd() * my
            If half Then
                x2 = halfmx + Rnd() * (bx - halfmx)
            Else
                x2 = ax + Rnd() * (halfmx - ax)
            End If
            y2 = y1
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            For j = 1 To 66000000
            Next
        Next
    End Sub

    '<--- 9 --->
    Public Sub RandomLines9(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, halfmx As Single
        Dim aux As Double = True
        Dim index, j As UInt32
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
        halfmx = (ax + bx) / 2 : y1 = ay : y2 = by
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
                graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
                aux = False
            Else
                graphic.DrawLine(Pens.Black, x1, y2, x2, y1)
                aux = True
            End If
            x1 = x2
            For j = 1 To 99999000
            Next
        Next
    End Sub

    '<--- 10 --->
    Public Sub RandomLines10(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Double)
        Dim x1, x2, y1, y2, my, halfmx As Single
        Dim index, j As UInt32
        my = by - ay : halfmx = (ax + bx) / 2
        createRectangleWithHalf(ax, bx, ay, by, True) 'Vertical
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
            graphic.DrawLine(Pens.MediumPurple, x1, y1, x2, y2)
            x1 = x2 : y1 = y2
            For j = 1 To 99999000
            Next
        Next
    End Sub

    Public Sub RectSim4(ax As Integer, bx As Integer, ay As Integer, by As Integer, n As Integer)
        Dim x, y, r1, r2, r3, r4, vi1, vi2, vi3, vi4, A, L As Single
        Dim i, j As UInt32
        graphic.DrawRectangle(Pens.Black, ax, bx, bx - ax, by - ay)
        vi1 = ax : r1 = (bx - ax) / (2 * n)
        vi2 = ay : r2 = (by - ay) / (2 * n)
        vi3 = bx - ax : r3 = -r1 * 2
        vi4 = by - ay : r4 = -r2 * 2
        For i = 1 To n
            x = vi1 + (i - 1) * r1
            y = vi2 + (i - 1) * r2
            A = vi3 + (i - 1) * r3
            L = vi4 + (i - 1) * r4
            graphic.DrawRectangle(Pens.Black, x, y, A, L)
            For j = 1 To 9900000
            Next
        Next
    End Sub
    ' * 1. Symmetric Rectangle sencond part
    Public Sub SymmetricRectangle(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, r1, r2, r3, vi1, vi2, vi3 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        vi1 = ax : r1 = (bx - ax) / ((2 * n) - 1)
        y = ay
        vi2 = bx - ax : r2 = -r1 * 2
        vi3 = by - ay : r3 = -(by - ay) / n
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            w = vi2 + (index - 1) * r2
            h = vi3 + (index - 1) * r3
            graphic.DrawRectangle(Pens.Purple, x, y, w, h)
            For j = 1 To 99999000
            Next
        Next
    End Sub

    Public Sub SymmetricRectanglePyram(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, vi1, r1, vi2, r2, vi3, r3 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        r1 = (bx - ax) / (n * 2) : vi1 = (ax + bx) / 2 - r1
        r2 = (by - ay) / n : vi2 = ay
        r3 = (bx - ax) / n : vi3 = r3
        h = r2
        For index = 1 To n
            x = vi1 - (index - 1) * r1
            y = vi2 + (index - 1) * r2
            w = vi3 + (index - 1) * r3
            graphic.DrawRectangle(Pens.Purple, x, y, w, h)
            For j = 1 To 99777777
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            SymmetricRectangle(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
            'RectSim4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msgError + ex.Message, MsgBoxStyle.Information, Title:="1. Rectangulo")
        End Try
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem1.Click
        SymmetricRectanglePyram(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub
End Class
