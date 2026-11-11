'Resource ονομάζω το κάθε στοιχείο του PLC
'Resource είναι οι είσοδοι, οι έξοδοι, οι μνήμες, τα χρονικά και οι απαριθμητές
Public MustInherit Class PLCSingleResource

    Private username As String          'Το όνομα που έχει δώσει ο χρήστης, πχ. είσοδος από αισθητήρα κίνησης
    Private MyType As PLC_IO             'Ο τύπος  0,1,2,3,4,5 {"I", "Q", "M", "TON", "TOFF", "C"}
    Private number As Byte              'Το νούμερο του αντικειμένου πχ για Ι3 = 3
    Private value As Boolean            'Η τιμή (True ή False)
    Private Parameter As Integer        'Η παράμετρος - για χρονικά είναι η ρύθμιση του χρόνου και για αθροιστές η τιμή ενεργοποίησης, για τα υπόλοιπα δεν χρησιμοποιείται
    Private StartTime As DateTime       'Πότε ξεκίνησε το χρονικό να μετρά
    Private CurrentCount As Integer     'Η τιμή που μετρά ο απαριθμητής
    Private Equation, EquationCU, EquationCD As String          'Λογική εξίσωση λειτουργίας

    'Αποθήκευση των δεδομένων στον δίσκο
    Public Sub SaveDataToDisk(Writer As System.IO.StreamWriter)
        On Error GoTo skip
        Writer.WriteLine(username)
        Writer.WriteLine(MyType)
        Writer.WriteLine(number)
        Writer.WriteLine(Parameter)
        Writer.WriteLine(Equation)
        Writer.WriteLine(EquationCU)
        Writer.WriteLine(EquationCD)
        Exit Sub
skip:
        Resume Next

    End Sub

    'Αποθήκευση των δεδομένων στον δίσκο
    Public Sub ReadDataFromDisk(Reader As System.IO.StreamReader)
        Dim i As Integer
        Dim s As String

        On Error GoTo skip
        username = Reader.ReadLine()

        'Type
        s = Reader.ReadLine()
        i = Val(s)
        If i >= 0 And i < 6 Then MyType = i

        'Number
        s = Reader.ReadLine()
        i = Val(s)
        If i >= 0 And i < 255 Then number = i

        'Parameter
        s = Reader.ReadLine()
        i = Val(s)
        If i >= 0 And i < 30000 Then Parameter = i

        Equation = Reader.ReadLine()
        EquationCU = Reader.ReadLine()
        EquationCD = Reader.ReadLine()
        Exit Sub
skip:
        Resume Next

    End Sub




    'Απλός Constructor για μνήμες εισόδους και εξόδους
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")> Public Sub New(ByRef Name_of_Contact As String, ByRef UserName_of_Contact As String, ByRef TypeOfContact As PLC_IO, ByRef NumberOfCOntact As Byte)
        SetUserName(UserName_of_Contact)
        SetMyType(TypeOfContact)
        Setnumber(NumberOfCOntact)
        SetEquation("")
        SetValue(False)
        SetParameter(0)
        SetCurrentCount(0)
        SetStartTime(Now())
    End Sub
    'Πιο σύνθετος Constructor για χρονικά και απαριθμητές
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")> Public Sub New(ByRef Name_of_Contact As String, ByRef UserName_of_Contact As String, ByRef TypeOfCOntact As PLC_IO, ByRef NumberOfCOntact As Byte, ByRef Value_of_contact As Boolean, ByRef Parameter_of_Contact As Integer, ByRef CurrentState_of_Contact As Integer, ByRef Equation_Of_Contact As String)
        'Καλώ τον απλό Constructor
        Me.New(Name_of_Contact, UserName_of_Contact, TypeOfCOntact, NumberOfCOntact)
        'Προσθέτω τις πρόσθετες παραμέτρους
        SetEquation(Equation_Of_Contact)
        SetValue(Value_of_contact)
        SetParameter(Parameter_of_Contact)
        SetCurrentCount(CurrentState_of_Contact)
    End Sub



    'Επιστρέφει τη λογική εξίσωση για το συγκεκριμένο στοιχείο
    Public Function GetEquation() As String
        Return Equation
    End Function
    'Επιστρέφει τη λογική εξίσωση Count Up για το συγκεκριμένο στοιχείο
    Public Function GetEquationCU() As String
        Return EquationCU
    End Function
    'Επιστρέφει τη λογική εξίσωση Count Down για το συγκεκριμένο στοιχείο
    Public Function GetEquationCD() As String
        Return EquationCD
    End Function


    'Ορίζει τη λογική εξίσωση για το συγκεκριμένο στοιχείο
    Public Sub SetEquation(Equation_Of_Contact As String)
        Equation = Equation_Of_Contact
    End Sub
    'Ορίζει τη λογική εξίσωση Count Up για το συγκεκριμένο στοιχείο
    Public Sub SetEquationCU(Equation_Of_Contact As String)
        EquationCU = Equation_Of_Contact
    End Sub
    'Ορίζει τη λογική εξίσωση Count Down για το συγκεκριμένο στοιχείο
    Public Sub SetEquationCD(Equation_Of_Contact As String)
        EquationCD = Equation_Of_Contact
    End Sub


    'Επιστρέφει το όνομα του στοιχείου
    Public Function GetUserName() As String
        Return username
    End Function

    'Ορίζει το όνομα του στοιχείου
    Public Sub SetUserName(UserName_Of_Contact As String)
        username = UserName_Of_Contact
    End Sub

    'Επιστρέφει την τιμή του στοιχείου  0,1,2,3,4,5,6 {"I", "Q", "M", "TON", "TOFF", "C"}
    Public Function GetMyType() As PLC_IO
        Return MyType
    End Function

    'Ορίζει την τιμή του στοιχείου  0,1,2,3,4,5,6 {"I", "Q", "M", "TON", "TOFF", "C"}
    Public Sub SetMyType(value_of_Type As PLC_IO)
        MyType = value_of_Type
    End Sub



    'Επιστρέφει την τιμή του στοιχείου
    Public Overridable Function GetValue() As Boolean
        Return value
    End Function
    'Επιστρέφει την τιμή του στοιχείου ως 1 και 0
    Public Overridable Function GetValue10() As Byte
        If GetValue() Then Return 1 Else Return 0
    End Function

    'Επιστρέφει την τιμή του στοιχείου. Αυτό χρησιμοποιείται για τους απαριθμητές και τα χρονικά που επιστρέφουν άλλες τιμές με το GetValue (όταν κάνουν override το function Getvalue)
    Public Function isEnabled() As Boolean
        Return value
    End Function

    'Ορίζει την τιμή του στοιχείου
    Public Overridable Sub SetValue(value_of_contact As Boolean)
        value = value_of_contact
    End Sub

    

    'Ορίζει την τιμή του στοιχείου
    Public Sub SetValue10(value_of_contact As Byte)
        If value_of_contact = 1 Then value = True Else value = False
    End Sub


    'Επιστρέφει την παράμετρο του στοιχείου
    Public Function GetParameter() As Integer
        Return Parameter
    End Function

    'Ορίζει την παράμετρο του στοιχείου
    Public Sub SetParameter(Parameter_of_Contact As Integer)
        Parameter = Parameter_of_Contact
    End Sub

    'Επιστρέφει τον α/α του στοιχείου
    Public Function GetNumber() As Byte
        Return number
    End Function

    'Ορίζει τον α/α του στοιχείου
    Public Sub Setnumber(Number_of_Contact As Integer)
        number = Number_of_Contact
    End Sub

    'Επιστρέφει το σημείο που βρίσκεται ο απαριθμητής
    Public Function GetCurrentCount() As Integer
        Return CurrentCount
    End Function



    'Ορίζει το σημείο που βρίσκεται ο απαριθμητής
    Public Sub SetCurrentCount(Number_of_CurrentCount As Integer)
        CurrentCount = Number_of_CurrentCount
    End Sub

    'Επιστρέφει το χαρακτηριστικό όνομα του στοιχείου I0, Q3, M2
    Public Function GetReference() As String
        Return UCase(Trim(PLC_IO_Symbol(MyType) + Trim(number)))
    End Function



    'Επιστρέφει τον χρόνο ενεργοποίησης του χρονικού
    Public Function GetStartTime() As DateTime
        Return StartTime
    End Function


    'Επιστρέφει τα δευτερόλεπτα που πέρασαν από τον χρόνο ενεργοποίησης
    Public Function GetTimeElaplsed() As Integer
        Dim HowMuchTimeHasPassed As TimeSpan
        HowMuchTimeHasPassed = Now() - StartTime
        On Error GoTo skiptime
        Return HowMuchTimeHasPassed.TotalSeconds
skiptime: Return 0
    End Function



    'Ορίζει  τον χρόνο ενεργοποίησης του χρονικού
    Public Sub SetStartTime(StartTimeValue As DateTime)
        StartTime = StartTimeValue
    End Sub


End Class
