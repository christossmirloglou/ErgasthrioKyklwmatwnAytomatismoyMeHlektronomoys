Public Class PLCResources
    Private PLCIn As List(Of PLCInput) = New List(Of PLCInput)()
    Private PLCOut As List(Of PLCOutput) = New List(Of PLCOutput)()
    Private PLCMem As List(Of PLCMemory) = New List(Of PLCMemory)()
    Private PLCTOn As List(Of PLCTimerDelayOn) = New List(Of PLCTimerDelayOn)()
    Private PLCTOff As List(Of PLCTimerDelayOff) = New List(Of PLCTimerDelayOff)()
    Private PLCCnt As List(Of PLCCounter) = New List(Of PLCCounter)()
    Private MaxInputs As Integer = 0
    Private MaxOutputs As Integer = 0
    Private MaxMemory As Integer = 0
    Private MaxTimerDON As Integer = 0
    Private MaxTimerDOFF As Integer = 0
    Private MaxCounter As Integer = 0
    Private MyPLCWatch As PLCWatch
    'Constructor
    'Καθορισμός των χαρακτηριστικών του PLC
    'Κατά την δημιουργία των Resources θα πρέπει να ορίσουμε το πλήθος τους
    Public Sub New(NumInputs As Byte, NumOutputs As Byte, NumMemories As Byte, NumTimersDON As Byte, NumTimersDOFF As Byte, NumCounters As Byte, MyPLCWatchWatchForm As PLCWatch)
        Dim i As Integer
        MyPLCWatch = MyPLCWatchWatchForm
        'Ορισμός εισόδων
        MaxInputs = NumInputs
        For i = 0 To NumInputs - 1

            PLCIn.Add(New PLCInput("Είσοδος", i))

        Next


        'Ορισμός εξόδων
        MaxOutputs = NumOutputs
        For i = 0 To NumInputs - 1
            PLCOut.Add(New PLCOutput("Έξοδος", i))
        Next

        'Ορισμός μνημών
        MaxMemory = NumMemories
        For i = 0 To NumMemories - 1
            PLCMem.Add(New PLCMemory("Μνήμη", i))
        Next

        'Ορισμός Χρονικών DelayOn
        MaxTimerDON = NumTimersDON
        For i = 0 To NumTimersDON - 1
            PLCTOn.Add(New PLCTimerDelayOn("Χρονικό Delay On", i))
        Next

        'Ορισμός Χρονικών Delayoff
        MaxTimerDOFF = NumTimersDOFF
        For i = 0 To NumTimersDOFF - 1
            PLCTOff.Add(New PLCTimerDelayOff("Χρονικό Delay Off", i))
        Next

        'Ορισμός απαριθμητών
        MaxCounter = NumCounters
        For i = 0 To NumCounters - 1
            PLCCnt.Add(New PLCCounter("Μνήμη", i))
        Next

        'MsgBox("Δημιουργήθηκε PLC με " + vbNewLine + _
        '    MaxInputs.ToString + " Εισόδους " + vbNewLine + _
        '    MaxOutputs.ToString + " Εξόδους " + vbNewLine + _
        '    MaxMemory.ToString + " Μνήμες " + vbNewLine + _
        '    MaxTimerDON.ToString + " Χρονικά DON" + vbNewLine + _
        '    MaxTimerDOFF.ToString + " Χρονικά DOFF" + vbNewLine + _
        '    MaxCounter.ToString + " Απαριθμητές ")
    End Sub

    'Επαναφορά της κατάστασης χρονικών και απαριθμητών
    Public Sub ResetAll()
        Dim i As Integer
        For i = 0 To MaxOutputs - 1
            PLCOut(i).SetValue(False)
        Next
        For i = 0 To MaxMemory - 1
            PLCMem(i).SetValue(False)
        Next

        For i = 0 To MaxCounter - 1
            Set_Counter_Count(i, 0)
            PLCCnt(i).SetValue(False)
        Next
        For i = 0 To MaxTimerDON - 1
            set_timerDON_StartTime(i, Now())
            PLCTOn(i).SetValue(False)
        Next
        For i = 0 To MaxTimerDOFF - 1
            set_timerDOFF_Starttime(i, Now())
            PLCTOff(i).SetValue(False)
        Next


    End Sub

    Public Sub Set_Counter_Count(WhatCounter As Integer, WhatCount As Integer)
        If WhatCounter < 0 Or WhatCounter > MaxCounter - 1 Then Exit Sub
        PLCCnt(WhatCount).SetCurrentCount(WhatCount)
    End Sub

    Public Sub set_timerDON_StartTime(WhatTimer As Integer, WhatTimeSetting As DateTime)
        If WhatTimer < 0 Or WhatTimer > MaxTimerDON - 1 Then Exit Sub
        PLCTOn(WhatTimer).SetStartTime(WhatTimeSetting)
    End Sub


    Public Sub set_timerDOFF_Starttime(WhatTimer As Integer, WhatTimeSetting As DateTime)
        If WhatTimer < 0 Or WhatTimer > MaxTimerDOFF - 1 Then Exit Sub
        PLCTOff(WhatTimer).SetStartTime(WhatTimeSetting)
    End Sub


    Public Function Get_PLC_MaxInputs() As Integer
        Return MaxInputs
    End Function

    Public Function Get_PLC_MaxOutputs() As Integer
        Return MaxOutputs
    End Function

    Public Function Get_PLC_MaxMemory() As Integer
        Return MaxMemory
    End Function


    Public Function Get_PLC_MaxTimerDON() As Integer
        Return MaxTimerDON
    End Function

    Public Function Get_PLC_MaxTimerDOff() As Integer
        Return MaxTimerDOFF
    End Function


    Public Function Get_PLC_MaxCounter() As Integer
        Return MaxCounter
    End Function




    'Κάνει Replace όλα τα Reference (Ι2, Ι3) με την αξία του (1 ή 0) του κάθε στοιχείου
    'Δηλαδή αν δώσω ένα equation σαν αυτό: I1+Q4*C4 με I1=1 , Q4=0, C4=0 τότε το αποτέλεσμα θα είναι 1+0*0
    Public Function EquationSolver_ReferenceToValue(ByRef Equation As String) As String
        Dim initialEq As String = Equation
        'Θα κάνω replace όλα τα referene με το value τους
        'Δηλαδή θα άλλάξει το Ι0 με 1 ή 0 κτλ

        'Είσοδοι
        For i = MaxInputs - 1 To 0 Step -1
            If i = 1 Then
                'Debug.Print("I1 is now " + PLCIn(i).GetValue10.ToString)
            End If
            Equation = Equation.Replace(PLCIn(i).GetReference, Trim(PLCIn(i).GetValue10.ToString))
        Next

        'Έξοδοι
        For i = MaxOutputs - 1 To 0 Step -1
            Equation = Equation.Replace(PLCOut(i).GetReference, Trim(PLCOut(i).GetValue10.ToString))
        Next

        'Μνήμες

        For i = MaxMemory - 1 To 0 Step -1
            Equation = Equation.Replace(PLCMem(i).GetReference, Trim(PLCMem(i).GetValue10.ToString))
        Next

        'Delay On

        For i = MaxTimerDON - 1 To 0 Step -1
            Equation = Equation.Replace(PLCTOn(i).GetReference, Trim(PLCTOn(i).GetValue10.ToString))
        Next

        'Delay Off

        For i = MaxTimerDOFF - 1 To 0 Step -1
            Equation = Equation.Replace(PLCTOff(i).GetReference, Trim(PLCTOff(i).GetValue10.ToString))
        Next

        'Counter
        For i = MaxCounter - 1 To 0 Step -1
            Equation = Equation.Replace(PLCCnt(i).GetReference, Trim(PLCCnt(i).GetValue10.ToString))
        Next
        Return Equation
    End Function


    'Εκτελεί την πράξη NOT
    Private Function Execute_NOT(Value As String) As String
        Dim vl As Integer = Val(Value)
        If vl = 0 Then Return "1" Else Return "0"
    End Function

    'Εκτελεί την πράξη AND
    Private Function Execute_AND(Value As String, value2 As String) As String
        If Val(Value) * Val(value2) = 0 Then Return "0" Else Return "1"
    End Function

    'Εκτελεί την πράξη OR
    Private Function Execute_OR(Value As String, value2 As String) As String
        If Val(Value) + Val(value2) = 0 Then Return "0" Else Return "1"
    End Function


    'Εκτελεί την πράξη XOR
    Private Function Execute_XOR(Value As String, value2 As String) As String
        If Val(Value) + Val(value2) = 1 Then Return "1" Else Return "0"
    End Function


    Public Function EquationSolver_Simple(ByVal Equation As String) As String
        Dim FoundIt As Integer = 1
        Dim Value As Char
        Dim Value2 As Char
        Dim Responce As String
        Dim initialEq As String = Equation
        On Error GoTo Skip


        'Debug.Print("Αρχική " + Equation)
        'Debug.Print("Before equation solver :" + Equation)

        Equation = EquationSolver_ReferenceToValue(Equation)
        'Debug.Print("After equation solver :" + Equation)
        'Debug.Print("Με τιμές " + Equation)
        'Εκτέλεση των πράξεων με την σειρά

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'Εκτέλεση όλων των NOT !
        Do
            'Ψάξε για το !
            FoundIt = Equation.IndexOf(Logical_Symbol(Logical_Operators.LogicalNot))

            'Αν βρεθεί το !
            If FoundIt > -1 Then
                'Βρες την τιμή που υπάρχει ακριβώς μετά
                Value = Equation.Chars(FoundIt + 1)
                Responce = Execute_NOT(Value)
                Equation = Equation.Replace(Logical_Symbol(Logical_Operators.LogicalNot) + Value, Responce)
            End If

        Loop Until FoundIt < 0




        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'Εκτέλεση όλων των AND &
        Do
            'Ψάξε για το &
            FoundIt = Equation.IndexOf(Logical_Symbol(Logical_Operators.LogicalAnd))

            'Αν βρεθεί το &
            If FoundIt > -1 Then

                'Βρες την τιμή που υπάρχει ακριβώς πριν
                Value = Equation.Chars(FoundIt - 1)
                'Βρες την τιμή που υπάρχει ακριβώς μετά
                Value2 = Equation.Chars(FoundIt + 1)
                Responce = Execute_AND(Value, Value2)
                Equation = Equation.Replace(Value + Logical_Symbol(Logical_Operators.LogicalAnd) + Value2, Responce)
            End If
        Loop Until FoundIt < 0

        '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        'Εκτέλεση όλων των OR |
        Do
            'Ψάξε για το |
            FoundIt = Equation.IndexOf(Logical_Symbol(Logical_Operators.LogicalOr))

            'Αν βρεθεί το |
            If FoundIt > -1 Then
                'Βρες την τιμή που υπάρχει ακριβώς πριν
                Value = Equation.Chars(FoundIt - 1)
                'Βρες την τιμή που υπάρχει ακριβώς μετά
                Value2 = Equation.Chars(FoundIt + 1)
                Responce = Execute_OR(Value, Value2)
                Equation = Equation.Replace(Value + Logical_Symbol(Logical_Operators.LogicalOr) + Value2, Responce)
            End If
        Loop Until FoundIt < 0



        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        'Εκτέλεση όλων των XOR ^
        Do
            'Ψάξε για το ^
            FoundIt = Equation.IndexOf(Logical_Symbol(Logical_Operators.LogicalXor))

            'Αν βρεθεί το ^
            If FoundIt > -1 Then
                'Βρες την τιμή που υπάρχει ακριβώς πριν
                Value = Equation.Chars(FoundIt - 1)
                'Βρες την τιμή που υπάρχει ακριβώς μετά
                Value2 = Equation.Chars(FoundIt + 1)
                Responce = Execute_XOR(Value, Value2)
                Equation = Equation.Replace(Value + Logical_Symbol(Logical_Operators.LogicalXor) + Value2, Responce)
            End If
        Loop Until FoundIt < 0

        '        Debug.Print("ΤΕΛΙΚΗ " + Equation)


        'Debug.Print("Simp :" + initialEq + " result :" + Equation)
        Return Equation
Skip:
        'Debug.Print("Simp :" + initialEq + " result : ERROR")
        Return "ERROR"

    End Function


    'Επίλυση εξισώσεων με παρενθέσεις
    Public Function EquationSolver_Complex(ByVal Equation As String) As String
        Dim ps As Integer = -1, FounditA As Integer = 0, FounditB As Integer = 0, i As Integer
        Dim temp As String, tempparen As String
        On Error GoTo skip
        'Debug.Print("Αρχική εξίσωση " + Equation)
        If Trim(Equation) = "" Then Return "0"

        'Πρώτα βρίσκουμε την πιο μέσα παρένθεση
        Do
            For i = 0 To Equation.Length - 2
                FounditA = ps
                ps = Equation.IndexOf("(", i)
                If ps > -1 Then i = ps Else Exit For
            Next

            'Debug.Print("    Βρέθηκε ( στη θέση " + Str(FounditA))

            'Αν βρέθηκε κάποια παρένθεση
            If FounditA > -1 Then
                'τότε ψάχνω για το κλείσιμο της 
                FounditB = Equation.IndexOf(")", FounditA)
                '    Debug.Print("    Βρέθηκε ) στη θέση " + Str(FounditB))
                '     Debug.Print("    Θα επεξεργαστώ την εξίσωση " + Equation.Substring(FounditA + 1, FounditB - FounditA - 1))
                If FounditB > -1 Then
                    'Σημειώνω το κομμάτι της εξίσωσης που θα επεξεργαστώ μαζί με την παρένθεση
                    tempparen = Equation.Substring(FounditA, FounditB - FounditA + 1)
                    'Σημειώνω το κομμάτι της εξίσωσης που θα επεξεργαστώ χωρίς με την παρένθεση
                    temp = Equation.Substring(FounditA + 1, FounditB - FounditA - 1)
                    'Λύνω την εξίσωση
                    temp = EquationSolver_Simple(temp)
                    '          Debug.Print("    Αποτέλεσμα " + temp)

                    'Αντικαθιστώ το αποτέλεσμα της παρένθεσης στην εξίσωση
                    Equation = Equation.Replace(tempparen, temp)
                    '           Debug.Print("    Εξίσωση + αποτέλεσμα " + Equation)
                End If

            End If
        Loop Until FounditA = -1

        'Εδώ ξανακαλώ τον επιλυτή εξισώσεων για να λύσει την τελική εξίσωση που δεν θα έχει παρενθέσεις
        'Debug.Print("    Τελικό αποτέλεσμα πράξεων " + EquationSolver_Simple(Equation))

        Return EquationSolver_Simple(Equation)
skip:
        Return "ERROR"
    End Function

    'Επίλυση εξισώσεων με παρενθέσεις με το αποτέλεσμα να είναι true ή false
    Public Function EquationSolver_Complex_Boolean(ByRef Equation As String) As Boolean
        Dim result As String = EquationSolver_Complex(Equation)
        If Val(result) = 1 Then Return True
        Return False
    End Function


    'Ορισμός τιμής εισόδου
    Public Sub SetInput(ByRef WhichInput As Integer, ByRef NewValue As Boolean)
        If (WhichInput > MaxInputs - 1) Or (WhichInput < 0) Then Exit Sub
        PLCIn(WhichInput).SetValue(NewValue)
    End Sub

    'Ορισμός τιμής εξίσωσης
    Public Sub SetOutputEquation(ByRef Whichoutput As Integer, ByRef NewEquation As String)
        If (Whichoutput > MaxOutputs - 1) Or (Whichoutput < 0) Then Exit Sub
        PLCOut(Whichoutput).SetEquation(NewEquation)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetMemoryEquation(ByRef WhichOne As Integer, ByRef NewEquation As String)
        If (WhichOne > MaxMemory - 1) Or (WhichOne < 0) Then Exit Sub
        PLCMem(WhichOne).SetEquation(NewEquation)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetTONEquation(ByRef WhichOne As Integer, ByRef NewEquation As String)
        If (WhichOne > MaxTimerDON - 1) Or (WhichOne < 0) Then Exit Sub
        PLCTOn(WhichOne).SetEquation(NewEquation)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetTOFFEquation(ByRef WhichOne As Integer, ByRef NewEquation As String)
        If (WhichOne > MaxTimerDOFF - 1) Or (WhichOne < 0) Then Exit Sub
        PLCTOff(WhichOne).SetEquation(NewEquation)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetCounterEquation(ByRef WhichOne As Integer, ByRef NewEquation As String, ByRef newCU As String, ByRef newCD As String)
        If (WhichOne > MaxCounter - 1) Or (WhichOne < 0) Then Exit Sub
        PLCCnt(WhichOne).SetEquation(NewEquation)
        PLCCnt(WhichOne).SetEquationCU(newCU)
        PLCCnt(WhichOne).SetEquationCD(newCD)

    End Sub


    'Επιστροφή εξίσωσης
    Public Function GetOutputEquation(ByRef Whichoutput As Integer) As String
        If (Whichoutput > MaxOutputs - 1) Or (Whichoutput < 0) Then Return ""
        Return PLCOut(Whichoutput).GetEquation()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetMemoryEquation(ByRef WhichMemory As Integer) As String
        If (WhichMemory > MaxMemory - 1) Or (WhichMemory < 0) Then Return ""
        Return PLCMem(WhichMemory).GetEquation()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetTONEquation(ByRef WhichTimer As Integer) As String
        If (WhichTimer > MaxTimerDON - 1) Or (WhichTimer < 0) Then Return ""
        Return PLCTOn(WhichTimer).GetEquation()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetTOffEquation(ByRef WhichTimer As Integer) As String
        If (WhichTimer > MaxTimerDOFF - 1) Or (WhichTimer < 0) Then Return ""
        Return PLCTOff(WhichTimer).GetEquation()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetCounterEquation(ByRef WhichCounter As Integer) As String
        If (WhichCounter > MaxCounter - 1) Or (WhichCounter < 0) Then Return ""
        Return PLCCnt(WhichCounter).GetEquation()
    End Function

    Public Function GetCounterUEquation(ByRef WhichCounter As Integer) As String
        If (WhichCounter > MaxCounter - 1) Or (WhichCounter < 0) Then Return ""
        Return PLCCnt(WhichCounter).GetEquationCU()
    End Function
    Public Function GetCounterDEquation(ByRef WhichCounter As Integer) As String
        If (WhichCounter > MaxCounter - 1) Or (WhichCounter < 0) Then Return ""
        Return PLCCnt(WhichCounter).GetEquationCD()
    End Function





    'Ορισμός παραμέτρων
    Public Sub SetTONParameter(ByRef WhichOne As Integer, ByRef NewParameter As Integer)
        If (WhichOne > MaxTimerDON - 1) Or (WhichOne < 0) Then Exit Sub
        PLCTOn(WhichOne).SetParameter(NewParameter)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetTOFFParameter(ByRef WhichOne As Integer, ByRef NewParameter As Integer)
        If (WhichOne > MaxTimerDOFF - 1) Or (WhichOne < 0) Then Exit Sub
        PLCTOff(WhichOne).SetParameter(NewParameter)
    End Sub
    'Ορισμός τιμής εξίσωσης
    Public Sub SetCounterParameter(ByRef WhichOne As Integer, ByRef NewParameter As Integer)
        If (WhichOne > MaxCounter - 1) Or (WhichOne < 0) Then Exit Sub
        PLCCnt(WhichOne).SetParameter(NewParameter)
    End Sub


    'Επιστροφή εξίσωσης
    Public Function GetTONParameter(ByRef WhichTimer As Integer) As String
        If (WhichTimer > MaxTimerDON - 1) Or (WhichTimer < 0) Then Return ""
        Return PLCTOn(WhichTimer).GetParameter()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetTOffParameter(ByRef WhichTimer As Integer) As String
        If (WhichTimer > MaxTimerDOFF - 1) Or (WhichTimer < 0) Then Return ""
        Return PLCTOff(WhichTimer).GetParameter()
    End Function
    'Επιστροφή εξίσωσης
    Public Function GetCounterParameter(ByRef WhichCounter As Integer) As String
        If (WhichCounter > MaxCounter - 1) Or (WhichCounter < 0) Then Return ""
        Return PLCCnt(WhichCounter).GetParameter()
    End Function











    'Υπολογισμός των τιμών των εξόδων μνημών κτλ σύμφωνα με τις τρέχουσες τιμές εισόδων
    Public Sub EvaluateOutputState()
        Dim i As Integer
        Dim txt As String
        For i = 0 To MaxInputs - 1
            txt = "I" + i.ToString + "=" + PLCIn(i).GetValue10.ToString
            If (MyPLCWatch.inp.Items.Count < MaxInputs) Then MyPLCWatch.inp.Items.Add(txt) Else MyPLCWatch.inp.Items(i) = txt
            'MyPLCWatch.inp.Items().Add()
        Next
        'Υπολογισμός της νέας κατάστασης των εξόδων και προσωρινή αποθήκευση τους
        Dim TempOutValue(MaxOutputs) As Boolean
        For i = 0 To MaxOutputs - 1
            TempOutValue(i) = EquationSolver_Complex_Boolean(PLCOut(i).GetEquation)
        Next
        'Υπολογισμός της νέας κατάστασης των μνημών και προσωρινή αποθήκευση τους
        Dim TempMemValue(MaxMemory) As Boolean
        For i = 0 To MaxMemory - 1
            TempMemValue(i) = EquationSolver_Complex_Boolean(PLCMem(i).GetEquation)
        Next
        'Υπολογισμός της νέας κατάστασης των DelayOn και προσωρινή αποθήκευση τους
        Dim TempTonValue(MaxTimerDON) As Boolean
        For i = 0 To MaxTimerDON - 1
            TempTonValue(i) = EquationSolver_Complex_Boolean(PLCTOn(i).GetEquation)
        Next
        'Υπολογισμός της νέας κατάστασης των DelayOff και προσωρινή αποθήκευση τους
        Dim TempToffValue(MaxTimerDOFF) As Boolean
        For i = 0 To MaxTimerDOFF - 1
            TempToffValue(i) = EquationSolver_Complex_Boolean(PLCTOff(i).GetEquation)
        Next
        'Υπολογισμός της νέας κατάστασης των Απαριθμητών και προσωρινή αποθήκευση τους
        Dim TempCountValue(MaxCounter) As Boolean
        Dim TempCountUValue(MaxCounter) As Boolean
        Dim TempCountDValue(MaxCounter) As Boolean


        For i = 0 To MaxCounter - 1
            TempCountValue(i) = EquationSolver_Complex_Boolean(PLCCnt(i).GetEquation)
            TempCountUValue(i) = EquationSolver_Complex_Boolean(PLCCnt(i).GetEquationCU)
            TempCountDValue(i) = EquationSolver_Complex_Boolean(PLCCnt(i).GetEquationCD)
            'PLCCnt(i).SetValue(TempCountValue(i))



        Next
        'Debug.Print("CU =" + TempCountUValue(0).ToString + "  CD =" + TempCountDValue(0).ToString)


        'Τώρα, αφού έχουν υπολογιστεί όλα με τις παλιές τιμές είναι καιρός να ενημερώσουμε τις τιμές των Value
        'Νέες τιμές εξόδων
        For i = 0 To MaxOutputs - 1
            PLCOut(i).SetValue(TempOutValue(i))
        Next
        'Νέες τιμές μνημών
        For i = 0 To MaxMemory - 1
            PLCMem(i).SetValue(TempMemValue(i))
            'PLCMem(i).SetValue(TempMemValue(i))
        Next
        'Νέες τιμές χρονικών Delay On
        'MyPLCWatch.timON.Items.Clear()
        For i = 0 To MaxTimerDON - 1
            PLCTOn(i).SetValue(TempTonValue(i))
            'PLCTOn(i).SetValue(TempTonValue(i))

            txt = "TON" + i.ToString + "=" + PLCTOn(i).GetEquation + ", [Παράμετρος=" + PLCTOn(i).GetParameter().ToString + " sec], Ενεργό=" + Bool2String(PLCTOn(i).isEnabled) + ", Έξοδος=" + PLCTOn(i).GetValue10().ToString + ", Εκκίνηση μέτρησης=" + PLCTOn(i).GetStartTime.TimeOfDay.ToString + ", Μέτρηση sec=" + PLCTOn(i).GetTimeElaplsed.ToString
            If (MyPLCWatch.timON.Items.Count < MaxTimerDON) Then MyPLCWatch.timON.Items.Add(txt) Else MyPLCWatch.timON.Items(i) = txt

            'MyPLCWatch.timON.Items.Add("TON" + i.ToString + "=" + PLCTOn(i).GetEquation + ", [Παράμετρος=" + PLCTOn(i).GetParameter().ToString + "], Ενεργό=" + PLCTOn(i).isEnabled.ToString + ", Έξοδος=" + PLCTOn(i).GetValue10().ToString + ", Εκκίνηση μέτρησης=" + PLCTOn(i).GetStartTime.TimeOfDay.ToString + ", Μέτρηση sec=" + PLCTOn(i).GetTimeElaplsed.ToString)

        Next

        'Νέες τιμές χρονικών Delay Off
        'MyPLCWatch.Timoff.Items.Clear()
        For i = 0 To MaxTimerDOFF - 1


            PLCTOff(i).SetValue(TempToffValue(i))

            txt = "TOff" + i.ToString + "=" + PLCTOff(i).GetEquation + ", [Παράμετρος=" + PLCTOff(i).GetParameter().ToString + " sec], Ενεργό=" + Bool2String(PLCTOff(i).isEnabled) + ", Έξοδος=" + PLCTOff(i).GetValue10().ToString + ", Εκκίνηση μέτρησης=" + PLCTOff(i).GetStartTime.TimeOfDay.ToString + ", Μέτρηση sec=" + PLCTOff(i).GetTimeElaplsed.ToString
            If (MyPLCWatch.Timoff.Items.Count < MaxTimerDOFF) Then MyPLCWatch.Timoff.Items.Add(txt) Else MyPLCWatch.Timoff.Items(i) = txt

            'MyPLCWatch.Timoff.Items.Add("TOff" + i.ToString + "=" + PLCTOff(i).GetEquation + ", [Παράμετρος=" + PLCTOff(i).GetParameter().ToString + "], Ενεργό=" + PLCTOff(i).isEnabled.ToString + ", Έξοδος=" + PLCTOff(i).GetValue10().ToString + ", Εκκίνηση μέτρησης=" + PLCTOff(i).GetStartTime.TimeOfDay.ToString + ", Μέτρηση sec=" + PLCTOff(i).GetTimeElaplsed.ToString)

            'PLCTOff(i).SetValue(TempToffValue(i))
        Next
        'Νέες τιμές χρονικών απαριθμητών
        'Dim p As Boolean = PLCCnt(0).PreviousCountDownValue
        'Debug.Print("Before assignment : PrevioudCDValue = " + p.ToString)

        ' Debug.Print(TempCountDValue(0).ToString)
        'MyPLCWatch.COUNTER.Items.Clear()

        For i = 0 To MaxCounter - 1
            PLCCnt(i).SetValue(TempCountValue(i))

            PLCCnt(i).CountUp(TempCountUValue(i))
            PLCCnt(i).CountDown(TempCountDValue(i))

            txt =
             "C" + i.ToString + "=" + PLCCnt(i).GetEquation + ", [Παράμετρος=" + PLCCnt(i).GetParameter.ToString + " παλμοί/ Τρέχουσα τιμή=" + PLCCnt(i).GetCurrentCount.ToString + " παλμοί] " + _
             ",  Ενεργό=" + Bool2String(PLCCnt(i).isEnabled) + ", Έξοδος =" + PLCCnt(i).GetValue10.ToString + _
             ", CU=" + PLCCnt(i).GetEquationCU + "=" + Bool2String(TempCountUValue(i)) + _
             ", CD=" + PLCCnt(i).GetEquationCD + "=" + Bool2String(TempCountDValue(i))

            If (MyPLCWatch.COUNTER.Items.Count < MaxCounter) Then MyPLCWatch.COUNTER.Items.Add(txt) Else MyPLCWatch.COUNTER.Items(i) = txt


            'MyPLCWatch.COUNTER.Items.Add( _
            '"C" + i.ToString + "=" + PLCCnt(i).GetEquation + ", [Παράμετρος=" + PLCCnt(i).GetParameter.ToString + "/ Τρέχουσα τιμή=" + PLCCnt(i).GetCurrentCount.ToString + "] " + _
            '",  Ενεργό=" + PLCCnt(i).isEnabled.ToString + ", Έξοδος =" + PLCCnt(i).GetValue10.ToString + _
            '", CU=" + PLCCnt(i).GetEquationCU + "=" + TempCountUValue(i).ToString + _
            '", CD=" + PLCCnt(i).GetEquationCD + "=" + TempCountDValue(i).ToString)
        Next
        'Debug.Print("Right Above Here Should be more Info")
        'Debug.Print("AfterAssignment :" + PLCCnt(0).PreviousCountDownValue.ToString)

        'MyPLCWatch.OutPre.Items.Clear()
        For i = 0 To MaxOutputs - 1

            txt = "Q" + i.ToString + "=" + PLCOut(i).GetEquation + ", Εξοδος=" + PLCOut(i).GetValue10.ToString
            If (MyPLCWatch.OutPre.Items.Count < MaxOutputs) Then MyPLCWatch.OutPre.Items.Add(txt) Else MyPLCWatch.OutPre.Items(i) = txt

            'MyPLCWatch.OutPre.Items.Add("Q" + i.ToString + "=" + PLCOut(i).GetEquation + ", Εξοδος=" + PLCOut(i).GetValue10.ToString)
        Next



        For i = 0 To MaxMemory - 1

            txt = "M" + i.ToString + "=" + PLCMem(i).GetEquation + ", Εξοδος=" + PLCMem(i).GetValue10.ToString
            If (MyPLCWatch.mem.Items.Count < MaxMemory) Then MyPLCWatch.mem.Items.Add(txt) Else MyPLCWatch.mem.Items(i) = txt

            'MyPLCWatch.OutPre.Items.Add("Q" + i.ToString + "=" + PLCOut(i).GetEquation + ", Εξοδος=" + PLCOut(i).GetValue10.ToString)
        Next

    End Sub

    'Ανάγνωση της τιμής μίας εξόδου
    Public Function GetOutput(ByRef WhichOutput As Integer) As Boolean
        If (WhichOutput > MaxOutputs) Or (WhichOutput < 0) Then Return False
        Return PLCOut(WhichOutput).GetValue

    End Function

    'Άνοιγμα του παραθύρου ορισμού λογικών εξισώσεων
    Public Sub OpenEquationsWindow()

        PLC_Set_Equations.Initialize(Me)
        PLC_Set_Equations.Show()

    End Sub

    Public Sub SaveDataToDisk(Writer As System.IO.StreamWriter)
        Dim i As Integer

        For i = 0 To MaxInputs - 1
            PLCIn(i).SaveDataToDisk(Writer)
        Next

        'Έξοδοι
        For i = 0 To MaxOutputs - 1
            PLCOut(i).SaveDataToDisk(Writer)
        Next

        'Μνήμες

        For i = 0 To MaxMemory - 1
            PLCMem(i).SaveDataToDisk(Writer)
        Next

        'Delay On

        For i = 0 To MaxTimerDON - 1
            PLCTOn(i).SaveDataToDisk(Writer)
        Next

        'Delay Off

        For i = 0 To MaxTimerDOFF - 1
            PLCTOff(i).SaveDataToDisk(Writer)
        Next

        'Counter
        For i = 0 To MaxCounter - 1
            PLCCnt(i).SaveDataToDisk(Writer)
        Next
    End Sub


    Public Sub ReadDataFromDisk(Reader As System.IO.StreamReader)
        Dim i As Integer

        For i = 0 To MaxInputs - 1
            PLCIn(i).ReadDataFromDisk(Reader)
        Next

        'Έξοδοι
        For i = 0 To MaxOutputs - 1
            PLCOut(i).ReadDataFromDisk(Reader)
        Next

        'Μνήμες

        For i = 0 To MaxMemory - 1
            PLCMem(i).ReadDataFromDisk(Reader)
        Next

        'Delay On

        For i = 0 To MaxTimerDON - 1
            PLCTOn(i).ReadDataFromDisk(Reader)
        Next

        'Delay Off

        For i = 0 To MaxTimerDOFF - 1
            PLCTOff(i).ReadDataFromDisk(Reader)
        Next

        'Counter
        For i = 0 To MaxCounter - 1
            PLCCnt(i).ReadDataFromDisk(Reader)
        Next
    End Sub

    Function Bool2String(Bool As Boolean) As String
        If Bool Then Return "1" Else Return "0"
    End Function
End Class
