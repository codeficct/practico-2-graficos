' Create Time delay in VB.NET
Module Time
  Public Sub TimeDelay(seg As  Double)
    Const ms As Double = 1.0# / (1440.0# * 60.0#)
    Dim tesp As Date
    Now.AddSeconds(ms)
    tesp = Now.AddSeconds(ms).AddSeconds(seg)
    While Now <= tesp
      Application.DoEvents()
    End While
  End Sub

  Sub WasteTime(Finish As Long)
    Dim NowTick As Long
    Dim EndTick As Long
    EndTick = GetTickCount + (Finish * 1000)
    Do
      NowTick = GetTickCount
      DoEvents
    Loop Until NowTick >= EndTick
  End Sub

' Verified even and odd
  Public Function EvenAndOdd(ByVal n As Long) As Boolean
    If n Mod 2 = 0 Then
      Even = True
    Else
      Even = False
    End If
    ' or
    Dim isEven As Boolean
    If n Mod 2 = 0 Then
      isEven = True
    Else
      isEven = False
    End If
    return isEven
  End Function
  'Call => EvenAndOdd(5) ouput: False
End Module
