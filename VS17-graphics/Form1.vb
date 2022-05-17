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
        graphic.DrawArc(Pens.DarkGreen, x, y, width, height, startAng, finalAng)
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
        x1 = 0 : y1 = PictureBox1.Height : y2 = 0
        r = PictureBox1.Width / n : vi = r
        Dim index As UInt16
        For index = 1 To n
            x2 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Purple, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub SymetricGraphics2(n As Integer)
        Dim x1, y1, x2, y2, r, vi As Single
        x1 = 0 : y1 = PictureBox1.Height / 2 : y2 = 0
        r = PictureBox1.Width / n : vi = r
        Dim index As UInt16
        For index = 1 To n
            x2 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Purple, x1, y1, x2, y2)
        Next
    End Sub

    Public Sub SymetricGraphics3(n As Integer)
        Dim x1, y1, x2, y2, r, vi, mx, my As Single
        mx = PictureBox1.Width / 2
        my = PictureBox1.Height / 2
        vi = 0 : r = mx / n
        y1 = 0 : x2 = mx / 2 : y2 = my
        Dim index As UInt16
        For index = 1 To n
            x1 = vi + (index - 1) * r
            graphic.DrawLine(Pens.Blue, x1, y1, x2, y2)
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
End Class
