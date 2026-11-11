Public Class ObjectVarType
    Private x, y, size As Integer
    Private name As String

    Public Sub setX(newX As Integer)
        x = newX
    End Sub

    Public Sub setY(newY As Integer)
        y = newY
    End Sub

    Public Sub setSize(newSize As Integer)
        size = newSize
    End Sub

    Public Sub setName(newName As String)
        name = newName
    End Sub

    Public Function getX() As Integer
        Return x
    End Function

    Public Function getY() As Integer
        Return y
    End Function

    Public Function getSize() As Integer
        Return size
    End Function

    Public Function getName() As String
        Return name
    End Function


End Class
