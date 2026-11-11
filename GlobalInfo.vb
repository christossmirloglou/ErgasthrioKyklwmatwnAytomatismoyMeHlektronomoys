Module GlobalInfo
    Public Const maxwires = 200
    Public numberOfWires As Integer = -1
    Public selectedWire As Integer = -1
    Public kanabos As Integer = 5

    Public useStandardSymbolsDuringEdit As Boolean = False       'Αν είναι false τότε θα γίνεται χρήση των εικονιδίων με σύμβολά κατά την επεξεργασία
    Public Const maxActiveObjects = 100
    Public Const Apostash_Aytomatoy_Node = 20                      'Η απόσταση αυτόματης δημιουργίας (αρχικών) nodes από την βίδα.
    Public Const Apostash_Aytomatoy_Node_Prosthhkh = 0             'Αν θέλω σε κάθε νέο node να αυξάνει την απόσταση αυτόματης δημιουργίας τότε δίνω μια τιμή σε αυτή τη μτβ
    Public Arithmos_aytomatvn_nodes = 0                        'Εδώ μετράει τον αριθμό των αυτόματα δημιουργημένων nodes
    Public Const initial_location_const_x = 25
    Public Const initial_location_const_Y = 25
    Public Initial_LocationX As Integer = initial_location_const_x                            'Ορισμός αρχικής θέσης εμφάνισης των αντικειμένων που μόλις δημιουργήθηκαν Χ
    Public Initial_LocationY As Integer = initial_location_const_Y                           'Υ
    Public Show_Voltage_During_Simulation As Boolean = False
    Public clickx, clicky As Integer
    Public clicked As Boolean
    Public allActiveObjects(maxActiveObjects) As ActiveImage
    Public numberOfActiveObjects As Integer
    Public currentActiveObject As Integer = -1
    Public currentActiveScrew As Integer = -1
    'Ορισμός του κανάβου στοίχισης αντικειμένων
    Public This_Is_The_First_Time_Drawing = False
    Public activeObject As ActiveImage = Nothing
    Public activeScrewnum As Integer = -1
    'Dim deleteme As New Wire
    Public cnt As Integer
    Public wireColor As SolidBrush = Brushes.Black
    Public wireWidth As Integer = 4
    Public nodeColor As SolidBrush = Brushes.Blue
    Public shortcolor As SolidBrush = Brushes.Red
    Public selectedNodeColor As SolidBrush = Brushes.Red
    Public lastRatioValue As Integer
    Public areWeCurrentlyMovingNodes As Boolean = False
    Public nodeWidth As Integer = 3
    Public nodeToBeDeleted As Integer
    Public soundon As Boolean = True
    Public wires As New WireWorks
    Public wirecolors(5) As Color
    Public ActiveFileName As String = "Ανώνυμο.cir"
    Public programName As String = "Eργαστήριο κυκλωμάτων αυτοματισμού με ηλεκτρονόμους"
    Public simulatorname As String = "Προσομοιωτής"
    Public Currently_moving_node As Boolean = False
    Public Const max_branches As Integer = 20               'Πόσες παράλληλες συνδέσεις επιτρέπονται
    Public timerTick As Long = 0                              'Αυτή η μεταβλητή θα ορίσει το τικ του χρόνου
    Public timerDuration As Long = 5                        'Αυτή η μεταβλητή είναι ο χρόνος που περνάει σε κάθε τικ του χρόνου.
    Public show_info_during_simulation As Boolean = True
    Public show_keys_during_simulation As Boolean = True
    Public SimulationSymbols As Boolean = False
    Public Const V_L1 = 1
    Public Const V_L2 = 2
    Public Const V_L3 = 4
    Public Const V_N = 8
    Public Const V_PE = 16
    Public Const V_U1 = 32
    Public Const V_U2 = 64
    Public Const V_V1 = 128
    Public Const V_V2 = 256
    Public Const V_W1 = 512
    Public Const V_W2 = 1024
    Public Const V_PhaseMask = 7
    Public Const V_LNMASK = 15
    Public Const V_PhasesNeutralMask = 31
    Public Const V_WindingsMask = 2047 - V_PhasesNeutralMask
    Public drawUsernameDuringEdit As Boolean = True

    Public Const max_const_values = 4 'Επειδή το τελευταίο value είναι 2^4
    Public Simulation_Values_Have_Changed As Boolean = False
    Public ratiovalue As Single = 1 'Το ratio για το simulator
    Public Simulation_runsteps As Integer = 0 'Πόσα βήματα προσομοίωσης έχουν εκτελεστεί
    Public Structure shortdata
        Dim WhichObject As ActiveImage
        Dim WhichScrew As SingleScrewData
        Dim WhichScrewNumber As Integer
        Dim FaultFound As Boolean
    End Structure
    Public Stop_Simulation_On_Error As Boolean = False                   'Όταν είναι αληθές τότε θα πρέπει η προσομοίωση να σταματά κατά κάποιο σφάλμα (βραχυκύκλωμα ή υπερφόρτιση)
    Public Stop_Simulation_On_Grounding_Error As Boolean = False        'Όταν είναι αληθές τότε θα πρέπει η προσομοίωση να σταματά ακόμα και σε σφάλματα γείωσης
    Public Sim_Error_Text As String = ""                                'Το κείμενο του σφάλματος
    Public Sim_Grounding_Error_Text As String = ""                      'Το κείμενο του σφάλματος γείωσης
    Public ShortCircuit As shortdata

    Public ExtensionsForDocuments() As String = {".pdf", ".odt", ".doc", ".docx", ".xpf"}
    Public ExtensionsForPresentations() As String = {".ppt", ".pptx", ".odp"}
    Public ExtensionsForVideo() As String = {".avi", ".mpg", ".m4p", ".mp4", ".m4v", ".mpeg", ".mpv", ".webm", ".mkv", ".ogg", ".ogv", ".mov", ".qt", ".wmv"}

    'Αυτό το function μετατρέπει όλα τα /n σε ένα text με vbnewline (για τα tooltip texts)
    Public Function addNewLine(Text As String) As String
        Return Text.Replace("/n", vbNewLine)
    End Function

    Public Function explain_Value(whichValue As Integer) As String
        Select Case whichValue
            Case V_L1
                Return "L1"
            Case V_L2
                Return "L2"
            Case V_L3
                Return "L3"
            Case V_N
                Return "N"
            Case V_PE
                Return "PE"
            Case V_U1
                Return "U1"
            Case V_U2
                Return "U2"
            Case V_W1
                Return "W1"
            Case V_W2
                Return "W2"
            Case V_V1
                Return "V1"
            Case V_V2
                Return "V2"

            Case 0
                Return ""
            Case Else
                Return "!!"
        End Select
    End Function

    Enum state
        kleisto = 0
        anoixto = 1
        leitoyrgei_kanonika = 2
        rele_not_powered = 3
        rele_powered = 4
        pathmeno = 5
        anenergo = 6
        motor_right = 7
        motor_left = 8
        motor_not_powered = 9
        energo = 10
        xroniko_anenergo = 11
        xroniko_powered = 12
        xroniko_tripped = 13
        xroniko_counting = 14
        thermiko_anenergo = 15
        thermiko_energo = 16
        thermiko_reset = 17
        thermiko_test = 18
        thermiko_test_reset = 19
        c00 = 20
        c01 = 21
        c10 = 22
        c11 = 23
        leitoyrgei_kanonika_kai_nyxterino = 24

    End Enum

  

    Public motorspintext() As String = {"αριστερόστροφη", "δεξιόστροφη"}

    Public state_explained() As String = {
        "είναι κλειστό(ς,η)",
        "είναι ανοιχτό(ς,η)",
        "λειτουργεί κανονικά",
        "δεν είναι ενεργοποιημένο(ς,η)",
        "είναι ενεργοποιημένο(ς,η)",
        "είναι πατημένο(ς,η)",
        "είναι ανενεργό(ς,η)",
        "λειτουργεί και στρέφεται δεξιόστροφα",
        "λειτουργεί και στρέφεται αριστερόστροφα",
        "δεν λειτουργεί",
        "είναι ενεργό(ς,η)",
        "είναι ανενεργό(ς,η)",
        "τροφοδοτείται",
        "έχει ενεργοποιηθεί",
        "μετράει τον χρόνο για να ενεργοποιηθεί",
        "είναι ανενεργό",
        "είναι ενεργό - εντοπίστηκε σφάλμα",
        "είναι σε επαναφορά (ανενεργό_. Έχει πιεστεί το Reset",
        "είναι σε δοκιμή (ενεργό). Έχει πιεστεί το Test",
        "είναι ενεργό. Έχουν πιεστεί και το Test και το Reset ταυτόχρονα",
        "έχει και τους δύο διακόπτες ανοιχτούς",
        "έχει τον δεύτερο διακόπτη κλειστό",
        "έχει τον πρώτο διακόπτη κλειστό",
        "έχει και τους δύο διακόπτες κλειστούς",
        "λειτουργεί κανονικά - Νυχτερινό τιμολόγιο ενεργό!"
    }

    Public tooltips_edit As String = "   Αυτή είναι η επιφάνεια εργασίας σας, πάνω σε αυτή θα υλοποιήσετε το κύκλωμα σας." + vbNewLine + _
                                     "Διαλέξτε ένα εξάρτημα από την `Εργαλειοθήκη εξαρτημάτων` στα δεξιά για να ξεκινήσετε. " + vbNewLine + _
                                     "Στη συνέχεια, αφού τοποθετήστε όλα τα εξαρτήματα προχωρήστε στις συνδέσεις των αγωγών" + vbNewLine + _
                                     "κάνοντας κλικ διαδοχικά επάνω στα άκρα που θέλετε να συνδέσετε." + vbNewLine + _
                                     "   Αν θέλετε να διαγράψετε έναν αγωγό τότε θα πρέπει να τον διαλέξετε (όταν τον διαλέξετε" + vbNewLine + _
                                     "θα αλλάξει χρώμα) και στη συνέχεια να κάνετε δεξί κλικ και να επιλέξετε το `Διαγραφή" + vbNewLine + _
                                     "αγωγού` από το αναδυόμενο μενού. Με τον ίδιο τρόπο μπορείτε να διαγράψετε και σημεία" + vbNewLine + _
                                     "μετακίνησης αγωγών."














    Public Function CheckIfAdditionalResourceExists(whattocheck() As String) As String
        Dim s As String
        For Each s In whattocheck

            If System.IO.File.Exists(ActiveFileName + s) Then Return ActiveFileName + s

        Next
        Return ""
    End Function








End Module
