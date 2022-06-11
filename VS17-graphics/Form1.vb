Public Class Form1
    ' Create global scope variable.
    Dim graphic As Graphics
    Dim msg As String = "Importante: Datos incorrectos o faltantes. "

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        graphic = PictureBox1.CreateGraphics
    End Sub

    Public Sub Frame()
        graphic.DrawRectangle(Pens.Gray, 0, 0, PictureBox1.Width - 1, PictureBox1.Height - 1)
        Dim x1, y1, x2, y2 As Single
        x1 = PictureBox1.Width / 2 : y1 = 0 : x2 = PictureBox1.Width / 2 : y2 = PictureBox1.Height
        graphic.DrawLine(Pens.Gray, x1, y1, x2, y2)
        x1 = 0 : y1 = PictureBox1.Height / 2 : x2 = PictureBox1.Width : y2 = PictureBox1.Height / 2
        graphic.DrawLine(Pens.Gray, x1, y1, x2, y2)
    End Sub

    Public Sub CreateLine(x1 As Single, y1 As Single, x2 As Single, y2 As Single)
        graphic.DrawLine(Pens.Red, x1, y1, x2, y2)
    End Sub

    Public Sub CreateRectangle(x As Single, y As Single, width As Single, height As Single)
        graphic.DrawRectangle(Pens.Blue, x, y, width, height)
    End Sub

    Public Sub CreateEllipse(x As Single, y As Single, width As Single, height As Single)
        graphic.DrawEllipse(Pens.Purple, x, y, width, height)
    End Sub

    Public Sub CreateArc(x As Single, y As Single, width As Single, height As Single, startAng As Single, finalAng As Single)
        graphic.DrawArc(Pens.Purple, x, y, width, height, startAng, finalAng)
    End Sub

    Public Sub CreatePolygon(x1 As Single, y1 As Single, x2 As Single, y2 As Single, x3 As Single, y3 As Single)
        Dim point1, point2, point3 As Point
        Dim graphPoint As Point()
        point1.X = x1 : point1.Y = y1
        point2.X = x2 : point2.Y = y2
        point3.X = x3 : point3.Y = y3

        graphPoint = {point1, point2, point3}
        graphic.DrawPolygon(Pens.Orange, graphPoint)
    End Sub

    Public Sub SymetricGraphics1(n As Integer)
        Dim x1, y1, x2, y2, r, vi As Single
        x1 = 0 : y1 = PictureBox1.Height : y2 = 0 : x2 = 0
        r = PictureBox1.Width / (n - 1) : vi = r
        Dim index As UInt16
        For index = 1 To n
            graphic.DrawLine(Pens.Purple, x1, y1, x2, y2)
            x2 = vi + (index - 1) * r
        Next
    End Sub

    Public Sub SymetricGraphics2(n As Integer)
        Dim x1, y1, x2, y2, r, vi As Single
        x1 = 0 : y1 = PictureBox1.Height / 2 : y2 = 0 : x2 = 0
        r = PictureBox1.Width / (n - 1) : vi = r
        Dim index As UInt16
        For index = 1 To n
            graphic.DrawLine(Pens.Red, x1, y1, x2, y2)
            x2 = vi + (index - 1) * r
        Next
    End Sub

    Public Sub SymetricGraphics3(n As Integer)
        Dim x1, y1, x2, y2, r, vi, mx, my As Single
        Dim index As UInt16
        mx = PictureBox1.Width / 2
        my = PictureBox1.Height / 2
        x1 = mx / 2 : y1 = my
        y2 = 0 : x2 = 0
        r = mx / (n - 1) : vi = r
        graphic.DrawRectangle(Pens.Black, x2, y2, mx, my)
        For index = 1 To n
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            x2 = vi + (index - 1) * r
        Next
    End Sub

    Public Sub SymetricGraphics4(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, r, vi, mx, my As Single
        Dim index As UInt16
        mx = bx - ax
        my = by - ay

        vi = ax : r = mx / n
        y1 = ay : y2 = by
        x2 = (ax + bx) / 2
        graphic.DrawRectangle(Pens.Black, ax, ay, mx, my)
        For index = 1 To n + 1
            x1 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub SymetricGraphics5(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, r1, r2, vi1, mx, my, vi2 As Single
        Dim index As UInt16
        mx = bx - ax
        my = by - ay

        x1 = ax : y2 = by
        r1 = -my / n : r2 = mx / n
        vi1 = by + r1 : vi2 = ax + r2
        graphic.DrawRectangle(Pens.Black, ax, ay, mx, my)
        For index = 1 To n
            y1 = vi1 + (index - 1) * r1
            x2 = vi2 + (index - 1) * r2
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub SymetricGraphics6(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, vi1, vi2, r1, r2, mx, my As Single
        Dim index, i As UInt32
        mx = bx - ax : my = by - ay

        x1 = ax : y1 = ay : y2 = by
        r1 = my / n : r2 = mx / n
        vi1 = ay + r1 : vi2 = ax + r2
        graphic.DrawRectangle(Pens.Black, ax, ay, mx, my)
        For index = 1 To n
            x2 = vi2 + (index - 1) * r2
            For i = 1 To 99999999
            Next
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            y1 = vi1 + (index - 1) * r1
        Next
    End Sub

    Public Sub RandomLines(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2 As Single
        Dim index As UInt16

        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)

        For index = 1 To n
            x1 = ax + Rnd() * (bx - ax)
            y1 = ay + Rnd() * (by - ay)
            x2 = ax + Rnd() * (bx - ax)
            y2 = ay + Rnd() * (by - ay)
            graphic.DrawLine(Pens.Orange, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub RandomLines2(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, my As Single
        Dim index As UInt16
        x1 = (ax + bx) / 2
        y1 = (ay + by) / 2
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        my = (ay + by) / 2
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        For index = 1 To n
            x2 = ax + Rnd() * (bx - ax)
            y2 = ay + Rnd() * (my - ay)
            graphic.DrawLine(Pens.Orange, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub RandomLines3(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, y4, my As Single
        Dim index, j As UInt32
        x1 = (ax + bx) / 2
        y1 = (ay + by) / 2
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        my = (ay + by) / 2
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        For index = 1 To n
            x2 = ax + Rnd() * (bx - ax)
            y2 = ay + Rnd() * (my - ay)
            For j = 1 To 50000000
            Next
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            x2 = ax + Rnd() * (bx - ax)
            y4 = my + Rnd() * (by - my)
            graphic.DrawLine(Pens.Orange, x1, y1, x2, y4)
        Next
    End Sub

    Public Sub RandomLines3_1(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, my As Single
        Dim index, j As UInt32
        my = (ay + by) / 2
        y1 = my
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        For index = 1 To n
            x1 = ax + Rnd() * (bx - ax)
            x2 = x1
            y2 = ay + Rnd() * (my - ay)
            graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
            For j = 1 To 99000000
            Next
        Next
    End Sub

    Public Sub RandomLines3_2(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, my As Single
        Dim index, j As UInt32
        my = (ay + by) / 2
        y1 = my
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        For index = 1 To n
            x1 = ax + Rnd() * (bx - ax)
            x2 = x1
            y2 = my + Rnd() * (by - my)
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            For j = 1 To 99000000
            Next

        Next
    End Sub

    Public Sub ContunousRandom(ax As Single, bx As Single, ay As Single, by As Single, n As Integer)
        Dim x1, y1, x2, y2, my As Single
        Dim index, j As UInt32
        my = (ay + by) / 2
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        x1 = ax + Rnd() * (bx - ax) : y1 = ay + Rnd() * (my - ay)
        For index = 1 To n
            x2 = ax + Rnd() * (bx - ax) : y2 = ay + Rnd() * (my - ay)
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            x1 = x2 : y1 = y2
            For j = 1 To 99000000
            Next
        Next
    End Sub

    Public Sub ContinousRandom2(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x1, x2, y1, y2, my As Single
        Dim aux As Double = True
        Dim index, j As UInt32
        my = (ay + by) / 2
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        y1 = ay : y2 = (ay + by) / 2
        x1 = ax + Rnd() * (bx - ax)
        For index = 1 To n
            x2 = ax + Rnd() * (bx - ax)
            If aux Then
                graphic.DrawLine(Pens.Black, x1, y1, x2, y2)
            Else
                graphic.DrawLine(Pens.Black, x1, y2, x2, y1)
            End If
            aux = Not aux
            x1 = x2
            For j = 1 To 99999000
            Next
        Next
    End Sub

    Public Sub Ejercicio1(ax As Single, bx As Single, ay As Single, by As Single, n As Integer, mitad As Boolean)
        ' * mitad en y
        Dim mitady As Single = (ay + by) / 2
        ' * variables
        Dim x1, y1, x2, y2, r1, r2, vi1, vi2 As Single
        ' * mitad x
        Dim mitadx As Single = (ax + bx) / 2
        Dim i As Integer
        ' * ancho
        r1 = (bx - ax) / n : vi1 = ax
        ' * alto
        r2 = (mitady - ay) / n : x2 = bx
        ' * rectangulo
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Blue, ax, mitady, bx, mitady)

        If mitad Then
            y1 = mitady
            vi2 = ay
        Else
            y1 = by
            vi2 = mitady
        End If

        For i = 1 To n
            x1 = vi1 + (i - 1) * r1
            y2 = vi2 + (i - 1) * r2
            graphic.DrawLine(Pens.Green, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub Ejercicio2(ax As Single, bx As Single, ay As Single, by As Single, n As Integer, mitad As Boolean)
        Dim x1, x2, y1, y2, mitadx, r, vi As Single
        Dim i, j As Integer
        mitadx = (ax + bx) / 2
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Blue, mitadx, ay, mitadx, by)
        y1 = (ay + by) / 2
        x2 = (ax + bx) / 2
        vi = ay : r = (by - ay) / n

        If mitad Then
            x1 = ax
        Else
            x1 = bx
        End If

        For i = 1 To n + 1
            y2 = vi + (i - 1) * r
            graphic.DrawLine(Pens.Red, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub SymmetricRectangle(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, vi1, r1, vi2, r2 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        x = ax : y = ay
        r1 = (bx - ax) / n : vi1 = r1
        r2 = (by - ay) / n : vi2 = r2
        For index = 1 To n
            w = vi1 + (index - 1) * r1
            h = vi2 + (index - 1) * r2
            graphic.DrawRectangle(Pens.Purple, x, y, w, h)
            For j = 1 To 99999000
            Next
        Next
    End Sub

    Public Sub SymmetricEllipse(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, vi1, r1, vi2, r2 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        x = ax : y = ay
        r1 = (bx - ax) / n : vi1 = r1
        r2 = (by - ay) / n : vi2 = r2
        For index = 1 To n
            w = vi1 + (index - 1) * r1
            h = vi2 + (index - 1) * r2
            graphic.DrawEllipse(Pens.Purple, x, y, w, h)
            For j = 1 To 99999000
            Next
        Next
    End Sub
    ' * NO ENTIENDO NADA :/
    Public Sub SymmetricRectangleDiagonal(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, vi1, r1, vi2, r2 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        r1 = (bx - ax) / n : vi1 = ax
        r2 = (by - ay) / n : vi2 = ay
        w = r1 : h = r2
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            y = vi2 + (index - 1) * r2
            graphic.DrawRectangle(Pens.Purple, x, y, w, h)
            For j = 1 To 99777777
            Next
        Next
    End Sub

    Public Sub SymmetricEllipseDiagonal(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x, y, w, h, vi1, r1, vi2, r2 As Single
        Dim index, j As UInt32
        graphic.DrawRectangle(Pens.Blue, ax, ay, bx - ax, by - ay)
        r1 = (bx - ax) / n : vi1 = ax
        r2 = (by - ay) / n : vi2 = ay
        w = r1 : h = r2
        For index = 1 To n
            x = vi1 + (index - 1) * r1
            y = vi2 + (index - 1) * r2
            graphic.DrawEllipse(Pens.Purple, x, y, w, h)
            For j = 1 To 99777777
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

    Public Sub SymmetricEllipsePyram(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
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
            graphic.DrawEllipse(Pens.Purple, x, y, w, h)
            For j = 1 To 99777777
            Next
        Next
    End Sub

    Public Sub RectSim4(ax As Integer, bx As Integer, ay As Integer, by As Integer, n As Integer)
        Dim x, y, r1, r2, r3, r4, vi1, vi2, vi3, vi4, A, L As Single
        Dim i, j As UInt32
        vi1 = ax : r1 = (bx - ax) / (2 * n)
        vi2 = ay : r2 = (by - ay) / (2 * n)
        vi3 = bx - ax : r3 = -r1 * 2
        vi4 = by - ay : r4 = -r2 * 2
        graphic.DrawRectangle(Pens.Black, ax, bx, bx - ax, by - ay)
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

    Public Sub RectAleatorios1(ax As Integer, bx As Integer, ay As Integer, by As Integer, n As Integer)
        Dim x, y, A, L As Single
        Dim i, j As UInt32
        graphic.DrawRectangle(Pens.Black, ax, bx, bx - ax, by - ay)
        For i = 1 To n
            x = ax + Rnd() * (bx - ax)
            y = ay + Rnd() * (by - ay)
            A = Rnd() * (bx - x)
            L = Rnd() * (by - y)
            graphic.DrawRectangle(Pens.Black, x, y, A, L)
            For j = 1 To 9900000

            Next
        Next
    End Sub

    Public Sub RectAleatorios2(ax As Integer, bx As Integer, ay As Integer, by As Integer, n As Integer)
        Dim x, y, A, L, my As Single
        Dim i, j As UInteger
        my = (ay + by) / 2
        graphic.DrawRectangle(Pens.Black, ax, bx, bx - ax, by - ay)
        For i = 1 To n
            x = ax + Rnd() * (bx - ax)
            y = ay + Rnd() * (by - ay)
            A = Rnd() * (bx - x)
            L = my - y
            graphic.DrawRectangle(Pens.Black, x, y, A, L)
            For j = 1 To 9900000

            Next
        Next
    End Sub

    Public Sub RectAleatorios3(ax As Integer, bx As Integer, ay As Integer, by As Integer, n As Integer)
        Dim x, y, A, L, my As Single
        Dim i, j As UInteger
        my = (ay + by) / 2
        x = ax : y = ay
        graphic.DrawRectangle(Pens.Black, ax, bx, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, ax, my, bx, my)
        For i = 1 To n
            A = Rnd() * (bx - x)
            L = Rnd() * (my - y)
            graphic.DrawRectangle(Pens.Black, x, y, A, L)
            For j = 1 To 9900000

            Next
        Next
    End Sub

    Public Sub ejercicio6(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32)
        Dim x1, y1, x2, y2, x4, y4, My, mx As Single
        Dim i As Int32
        My = (ay + by) / 2 : mx = (ax + bx) / 2
        x1 = mx : y1 = My
        graphic.DrawRectangle(Pens.Black, ax, ay, bx - ax, by - ay)
        graphic.DrawLine(Pens.Black, (bx + ax) / 2, ay, (bx + ax) / 2, by)

        For i = 1 To n
            x2 = ax + Rnd() * (mx - ax)
            y2 = ay + Rnd() * (by - ay)
            x4 = mx + Rnd() * (bx - mx)
            y4 = ay + Rnd() * (by - ay)
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
            graphic.DrawLine(Pens.Blue, x1, y1, x4, y4)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Frame()
        Label1.Text = "X =" + Str(PictureBox1.Width())
        Label2.Text = "y =" + Str(PictureBox1.Height())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Refresh()
        Frame()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Label1.Text = "Width"
        Label2.Text = "Height"
    End Sub

    Private Sub LineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineToolStripMenuItem.Click
        Try
            CreateLine(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Line")
        End Try
    End Sub

    Private Sub RectangleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem.Click
        Try
            CreateRectangle(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Rectangle")
        End Try
    End Sub

    Private Sub EllipseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EllipseToolStripMenuItem.Click
        Try
            CreateEllipse(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Ellipse")
        End Try
    End Sub

    Private Sub ArcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArcToolStripMenuItem.Click
        Try
            CreateArc(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Arc")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Refresh()
        Frame()
    End Sub

    Private Sub PolygonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PolygonToolStripMenuItem.Click
        Try
            CreatePolygon(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Polygon")
        End Try
    End Sub

    Private Sub LinesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinesToolStripMenuItem.Click
        Try
            SymetricGraphics1(TextBox1.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="1. Graphic")
        End Try
    End Sub

    Private Sub SymetricGraphics2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SymetricGraphics2ToolStripMenuItem.Click
        Try
            SymetricGraphics2(TextBox1.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="2. Graphic")
        End Try
    End Sub

    Private Sub Graphic3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Graphic3ToolStripMenuItem.Click
        Try
            SymetricGraphics3(TextBox1.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="3. Graphic")
        End Try
    End Sub

    Private Sub Graphic4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Graphic4ToolStripMenuItem.Click
        Try
            SymetricGraphics4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="4. Graphic")
        End Try
    End Sub

    Private Sub Graphic5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Graphic5ToolStripMenuItem.Click
        Try
            SymetricGraphics5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="5. Graphic")
        End Try
    End Sub

    Private Sub Graphic6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Graphic6ToolStripMenuItem.Click
        Try
            SymetricGraphics6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="6. Graphic")
        End Try
    End Sub

    Private Sub LinesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LinesToolStripMenuItem1.Click
        Try
            RandomLines(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 1. Lines")
        End Try
    End Sub

    Private Sub LinesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LinesToolStripMenuItem2.Click
        Try
            RandomLines2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 2. Lines")
        End Try
    End Sub

    Private Sub LinesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles LinesToolStripMenuItem3.Click
        Try
            RandomLines3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 2. Lines")
        End Try
    End Sub

    Private Sub LinesparaleloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinesparaleloToolStripMenuItem.Click
        Try
            RandomLines3_1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
            RandomLines3_2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 2. Lines")
        End Try
    End Sub

    Private Sub LinesContinuosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinesContinuosToolStripMenuItem.Click
        Try
            ContunousRandom(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 2. Lines")
        End Try
    End Sub

    Private Sub LinesContinuos2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinesContinuos2ToolStripMenuItem.Click
        Try
            ContinousRandom2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox(msg + ex.Message, MsgBoxStyle.Information, Title:="Random - 2. Lines")
        End Try
    End Sub

    Private Sub LineasSimetricasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineasSimetricasToolStripMenuItem.Click
        Ejercicio1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
        Ejercicio1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
    End Sub

    Private Sub LineasSimetricasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LineasSimetricasToolStripMenuItem1.Click
        Ejercicio2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
        Ejercicio2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
    End Sub

    Private Sub RectangleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem1.Click
        SymmetricRectangle(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub EllipseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EllipseToolStripMenuItem1.Click
        SymmetricEllipse(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub RectangleToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem2.Click
        SymmetricRectangleDiagonal(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub EllipseDiagonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EllipseDiagonalToolStripMenuItem.Click
        SymmetricEllipseDiagonal(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub RectanglePyramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RectanglePyramToolStripMenuItem.Click
        SymmetricRectanglePyram(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub EllipsePyramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EllipsePyramToolStripMenuItem.Click
        SymmetricEllipsePyram(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub RectangleToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RectangleToolStripMenuItem3.Click
        RectSim4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub

    Private Sub TestEjercio6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestEjercio6ToolStripMenuItem.Click
        ejercicio6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
    End Sub
End Class
