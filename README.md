# Práctico de Gráficos
### Lineas y Rectángulos Simétricos

![Practice of visual basic graphics](https://user-images.githubusercontent.com/88288135/186324425-7aec102d-8980-41e2-a756-1a96a3ffffc8.gif)


Realizar los gráficos como un proyecto en Visual Basic.
- Todos los gráficos simétricos toman N Partes
- Todos los gráficos aleatorios toman N Líneas
- Se debe realizar un proceso para una parte(mitad) y otro para la segunda parte
- ✅ Lenguaje de programación: Visual Basic
- [ver PDF del Práctico de Gráficos](https://drive.google.com/file/d/1gr9bFUKlNZbxdDsgVC3dzoxcPqOcyYKS/view?usp=sharing)


## Contenido
1. [Ejercicio 1](#ejercicio-1)
2. [Ejercicio 2](#ejercicio-1)
3. [Ejercicio 3](#ejercicio-1)
4. [Ejercicio 4](#ejercicio-1)
5. [Ejercicio 5](#ejercicio-5)
6. [Ejercicio 6](#ejercicio-6)
7. [Ejercicio 7](#ejercicio-7)
8. [Ejercicio 8](#ejercicio-8)
9. [Ejercicio 9](#ejercicio-9)
10. [Ejercicio 10](#ejercicio-10)

### Primeros pasos ⚠️
```vb
Public Class Form1
    ' Crear una variable global de tipo Graphics
    Dim graphic As Graphics
    ' Definimos la variable timing para el retardo
    Dim timing As Integer = 99000000
    ' Cuando el formulario se abra por primera vez 
    ' asignaremos el PictureBox1.CreateGraphics a
    ' la variable graphic
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        graphic = PictureBox1.CreateGraphics
    End Sub
    ' Crearemos un procedimiento o una function que no retorna nada
    ' para graficar un rectangulo mas conocido como marco.
    Public Sub Frame()
        graphic.DrawRectangle(Pens.Gray, 0, 0, PictureBox1.Width - 1, PictureBox1.Height - 1)
    End Sub
    ' *******************************************************************
    ' **  FUNCIONES REUTILIZABLES QUE USAREMOS PARA NO REPETIR CODIGO  **
    ' estas funciones podras usarlas en cualquier ejercicio del práctico.
    ' *******************************************************************

    ' Esta function genera un Rectangulo con una linea por la Mitad
    ' el parametro "align" solo podra recibir "vertical" y "horizontal"
    Public Sub CreateRectangleWithHalf(ax As Single, bx As Single, ay As Single, by As Single, align As String)
        Dim half As Single
        ' Pintamos el rectangulo de color Verde
        Using pen As New Pen(Color.Green) ' Puedes modificarlo si gustas
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

    ' Esta funcion genera elementos Graficos (linea, rectangulo y ellipse)
    ' con colores random
    ' @parametros:
    ' x es la posision en el eje X
    ' y es la posision en el eje Y
    ' w es el ancho total del grafico (rectangle or ellipse)
    ' h es el alto total del grafico (rectangle or ellipse)
    Public Sub GraphicRandomColor(x As Single, y As Single, w As Single, h As Single, gName As String)
        Dim rng As New Random()
        Using pen = New Pen(Color.FromArgb(rng.Next(256), rng.Next(156), rng.Next(200)))
            pen.Width = 2
            Select Case gName
                Case "line"
                    ' para las lineas pasaremos x1, y1, x2, y2
                    graphic.DrawLine(pen, x, y, w, h) ' * x1, y1, x2, y2
                Case "rectangle"
                    graphic.DrawRectangle(pen, x, y, w, h)
                Case "ellipse"
                    graphic.DrawEllipse(pen, x, y, w, h)
                Case Else

            End Select
        End Using
    End Sub

    ' DESDE AQUI DESARROLLARAS EL PRACTICO...    
End Class
```

## Ejercicio 1
![example-1](https://user-images.githubusercontent.com/88288135/186312380-2f6ddec8-0189-4749-a079-6420da44bec7.png)
<details>
  <summary>Ver codigo</summary>

```vb
' * 1. Exercice symmetric graphics
Public Sub SymmetricGraphic1(ax As Single, bx As Single, ay As Single, by As Single, n As UInt32, half As Boolean)
    Dim x1, x2, y1, y2, mx, halfmy, r1, r2, vi1, vi2 As Single
    Dim index, j As UInt32
    mx = bx - ax : halfmy = (ay + by) / 2
    CreateRectangleWithHalf(ax, bx, ay, by, "horizontal") ' Horizontal
    r1 = mx / n : vi1 = ax
    r2 = (halfmy - ay) / n : x2 = bx
    ' Condicional para indicar en que mitad pintar las lineas
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    SymmetricGraphic1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    SymmetricGraphic1(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 2
![example-2](https://user-images.githubusercontent.com/88288135/186312922-076736fa-c550-4ea7-937e-ab2095816f98.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    SymmetricGraphic2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    SymmetricGraphic2(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 3
![example-3](https://user-images.githubusercontent.com/88288135/186314735-1b11c1b1-7d3b-4334-b8f1-5bc46076cd92.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    SymmetricGraphic3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    SymmetricGraphic3(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 4
![example-4](https://user-images.githubusercontent.com/88288135/186314808-efde460d-cc76-4acf-bdee-ac5b73ff6087.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    SymmetricGraphic4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    SymmetricGraphic4(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 5
![example-5](https://user-images.githubusercontent.com/88288135/186314857-56899c50-65b3-4882-94db-0bd47f706a43.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    SymmetricGraphic5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    SymmetricGraphic5(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 6
![example-6](https://user-images.githubusercontent.com/88288135/186314955-99072b92-704c-45a2-8fc8-22e8f77cc8d2.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    RandomLines6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    RandomLines6(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)    
End Sub
```

</details>

## Ejercicio 7
![example-7](https://user-images.githubusercontent.com/88288135/186315027-312ac77f-b65f-491e-8c36-5af9a6b6b16b.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    RandomLines7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    RandomLines7(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 8
![example-8](https://user-images.githubusercontent.com/88288135/186315157-745feb3b-5ee9-4662-8ee0-446a956c7562.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    RandomLines8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    RandomLines8(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
    
End Sub
```

</details>

## Ejercicio 9
![example-9](https://user-images.githubusercontent.com/88288135/186315223-fc5e3652-7b95-45c5-8086-0b3a919e67d3.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    RandomLines9(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    RandomLines9(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>

## Ejercicio 10
![example-10](https://user-images.githubusercontent.com/88288135/186315285-1c997e14-b183-411b-80e8-4f5b68a5db80.png)

<details>
  <summary>Ver codigo</summary>

```vb
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
```
```vb
' Llamada de la funcion
Private Sub CualquierEvento_Click(sender As Object, e As EventArgs) Handles CualquierEvento.Click
    ' Esta llamada pinta el grafico en una mitad del marco
    RandomLines10(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, True)
    ' Esta llamada pinta el grafico en la otra mitad del marco
    RandomLines10(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, False)
End Sub
```

</details>
