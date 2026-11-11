
'Edit.vb

'Χρησιμοποιήθηκαν οι εικόνες:
'A)Εικονίδιο μεγεθυντικού φάκού (zoom_in.png, zoom_out.png), εκτύπωσης (print.png), αποθήκευσης εικόνας (saveimage.png), νέου αρχείου(new_file.png), αποθήκευσης(savedisk.png), ανάγνωσης(openfile.png), εξόδου (power_on_off.png), εργαλειοθήκης (toolbox.png) : Απο συλλογή LibreOffice Symbol (https://extensions.libreoffice.org/en/extensions/show/symbols-gallery) άδεια Creative Commons 0 - Public Domain (https://creativecommons.org/share-your-work/public-domain/cc0/)
'B)Εικονίδιο εκκίνησης προσομοίωσης (play_button.png), παύσης προσομοίωσης (pause_button.png), επαναφοράς προσομοίωσης (go_back.png): Από τη συλλογή Icon Gallery του LibreOffice (https://extensions.libreoffice.org/en/extensions/show/icon-gallery) με άδεια Creative Commons 0 - Public Domain (https://creativecommons.org/share-your-work/public-domain/cc0/)
'Γ)Εικονίδιο φωτιάς (fire.pnh), https://commons.wikimedia.org/wiki/File:FireIcon.svg, άδεια: public domain
'Δ)Εικονίδιο χεριού με γάντι που δείχνει, https://openclipart.org/detail/160453/multitouchinterface-mousetheme-1fingertouchandhold, άδεια public domain by BenBois 
'Ήχοι:
'-54047__guitarguy1985__buzzer (https://freesound.org/people/guitarguy1985/sounds/54047/) - Licence:CC0 - by guitarguy1985 
'-470504__onderwish__emergency-siren (https://freesound.org/people/onderwish/sounds/470504/) - Licence: cc0 - by onderwish 
'-97182__timbre__electric-motor-spin-up-noise-1 (https://freesound.org/people/Timbre/sounds/97182/) - Licence: Attribution NonCommercial 4.0 - by Timbre
'-192278__lebaston100__click (https://freesound.org/people/lebaston100/sounds/192278/) - Licence: Attribution 4.0 - by Lebaston100
'-632233__audacitier__machine-motor (https://freesound.org/people/AUDACITIER/sounds/632233/) - Licence: Attribution 4.0 - by AUDACITIER
'-644035__szntndr__kontaktorok (https://freesound.org/people/Szntndr/sounds/644035/) - Licence: cc0 - by Szntndr
'-333872__alienxxx__screws (https://freesound.org/people/AlienXXX/sounds/333872/) - Licence: Attribution 4.0 - by AlienXXX
'144277__dwoboyle__light_switch-0003-on-flicked (https://freesound.org/people/DWOBoyle/sounds/144277/) - Licence: Attribution 4.0 - by DWOBoyle
'411933__iam_calderon__cooking-burgerstatic (https://freesound.org/people/Iam_calderon/sounds/411933/) - Licence: cc0 -by Iam_calderon
'167476__superandy__boil6(https://freesound.org/people/superandy/sounds/167476/)- Licence: cc0 - by superandy




Imports System.IO
Imports System.Deployment.Application


Public Class Edit
    Private WhichPLCtoWorkOn As PLC_Activeimage = Nothing
    Private WhichGarageDoortoWorkOn As ActiveImage = Nothing
    Private WhichAwningtoWorkOn As ActiveImage = Nothing
    Private WhichSlidingDoortoWorkOn As ActiveImage = Nothing
    Private WhereToResetInterlock As ActiveImage = Nothing
    Private WhichObjectToInterlock As ActiveImage = Nothing
    Private WhichObjectToWorkOn As ActiveImage = Nothing
    Public ObjectThatWasRightClicked As ActiveImage




    'Προσθήκη Handlers για τα εξαρτήματα που δημιουργούνται on the fly
    Private Sub add_Handlers_to_new_Activeimage(ee As ActiveImage)
        AddHandler ee.MouseClick, AddressOf ActiveImage_MouseClick
        AddHandler ee.MouseDown, AddressOf ActiveImage_MouseDown
        AddHandler ee.MouseUp, AddressOf ActiveImage_MouseUp
        AddHandler ee.MouseMove, AddressOf ActiveImage_MouseMove
        AddHandler ee.MouseHover, AddressOf ActiveImage_MouseHover
        AddHandler ee.DragEnter, AddressOf ActiveImage_DragEnter

    End Sub

  
    'Προσθήκη κοινών ιδιοτήτων για τα νέα εξαρτήματα
    'Χρησιμοποιείται κατά την δημιουργία των εξαρτημάτων για να ορίσει τα κοινά τους χαρακτηριστικά
    Sub Add_Item_CommonAttributes(ee As ActiveImage, type As Integer, locationx As Integer, locationy As Integer)
        ee.type = type

        ee.Location = New Point(locationx, locationy)

        'Αν δημιουργείται ένα αντικείμενο την στιγμή της επεξεργασίας τότε προστίθεται το κοινό κείμενο που φαίνεται παρακάτω
        ee.information = ee.information + vbNewLine + "Κρατήστε πατημένο το αριστερό κλικ για μετακίνηση. Για να ορίσετε ονομασία κάντε διπλό κλικ. Για διαγραφή κάντε δεξί κλικ και επιλέξτε τη 'Διαγραφή στοιχείου'. "


        ee.ratio = HScrollBar1.Value
        ee.Width = ee.Image.Width \ ee.ratio
        ee.Height = ee.Image.Height \ ee.ratio
        ee.BackColor = Color.Tomato
        ee.SizeMode = PictureBoxSizeMode.Zoom
        ee.Name = Trim(Str(numberOfActiveObjects))
        ee.Tag = Trim(Str(numberOfActiveObjects))
        ee.Cursor = Cursors.Hand
        'ToolTip1.SetToolTip(ee, ee.WhatAmIGreek + vbNewLine + ee.information) 'Είναι ενοχλητικό


        add_Handlers_to_new_Activeimage(ee)

        ee.Visible = True
        Me.Controls.Add(ee)

        'Εδώ ρυθμίζουμε το layer που ανήκει το καινούργιο αντικείμενο. Είναι πάνω από τα υπόλοιπα και κάτω από τις εργαλειοθήκες
        ee.BringToFront()
        ee.Refresh()
        Tooltip.BringToFront()
        Exarthmata1.BringToFront()
        Exarthmata2.BringToFront()
        Exarthmata3.BringToFront()
        Exarthmata4.BringToFront()
        exarthmata5.BringToFront()
        SettingsBox.BringToFront()
        MenuStrip1.BringToFront()

        ToolBoxShowHide.BringToFront()
        AdditionalResourceButtonPDF.BringToFront()
        AdditionalResourceButtonPresentation.BringToFront()
        AdditionalResourceButtonVideo.BringToFront()


        allActiveObjects(numberOfActiveObjects) = ee



        'gb = DirectCast(ee, Relay_ActiveImage)
        numberOfActiveObjects = numberOfActiveObjects + 1

    End Sub

    'Προσθήκη νέων εξαρτημάτων
    'Εδώ δημιουργούνται τα αντικείμενα τύπου Ρελέ, θερμικά, κτλ
    Private Sub Add_Item(type As Integer, locationx As Integer, locationy As Integer)

        If locationx = 0 And locationy = 0 Then
            If numberOfActiveObjects = 0 Then
                locationx = initial_location_const_x
                locationy = initial_location_const_Y
            Else
                locationy = allActiveObjects(numberOfActiveObjects - 1).Location.Y
                locationx = allActiveObjects(numberOfActiveObjects - 1).Location.X + allActiveObjects(numberOfActiveObjects - 1).Width + (23 \ (Me.HScrollBar1.Value))

            End If
        End If

        If numberOfActiveObjects = maxActiveObjects Then Exit Sub


        Select Case type
            Case 1 '------------------------------------------------------------------------------------------------------------------Δημιουργία Ρελέ
                Dim ee = New Relay_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)


            Case 2  'Θερμικό
                Dim ee = New thermiko_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 3 'Start
                Dim ee = New Start_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 4 'stop
                Dim ee = New Stop_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 5 'startstop
                Dim ee = New StartStop_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 6 'πράσινη ενδεικτική
                Dim ee = New LightGreen_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 7 'κόκκινη ενδεικτική
                Dim ee = New LightRed_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 8 'Μονοπολιή ασφάλεια        
                Dim ee = New CircuitBreaker1P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 9 'Τριπολική ασφάλεια
                Dim ee = New CircuitBreaker3P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 10 'τηκτή 1Π ασφάλεια
                Dim ee = New Fuse_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 11 '1Π ΄Διακόπτης
                Dim ee = New Switch1P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 12 'Τριπολικός διακόπτης
                Dim ee = New Switch3P_ActiveImage
                ee.initialization()

                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 13 'Παροχή από κάτω προς τα πάνω
                Dim ee = New Power_ActiveImage
                ee.initialization(0)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 14 'Παροχή από πανω προς τα κάτω
                Dim ee = New Power_ActiveImage
                ee.initialization(1)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 15 'Παροχή από αριστερά
                Dim ee = New Power_ActiveImage
                ee.initialization(2)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 16 'Κινητήρας

                'Έλεγχος αν γίνεται προσπάθεια προσθήκης και δεύτερου ΑΤΚ - Αυτό δεν είναι δυνατόν λόγω του τρόπου που γίνεται η ανίχνευση του Δ και Υ σε αυτό τον
                'τύπο κινητήρα
                Dim i As Integer

                For i = 0 To numberOfActiveObjects - 1
                    If allActiveObjects(i).WhatAmI = "3PHASE MOTOR" Then MsgBox("Μπορείτε να προσέσετε μόνο ένα κινητήρα αυτού του τύπου (ΑΤΚ). Δοκιμάστε να προσθέσετε κινητήρες με σύνδεση αστέρα ή τριγώνου.", MsgBoxStyle.OkOnly, "Προσθήκη ΑΤΚ") : Exit Sub
                Next


                Dim ee = New ATKNoConnection_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 17 'Κινητήρας σε αστέρα
                Dim ee = New ATKY_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 18 'Κινητήρας σε συνδεσμολογία τριγώνου
                Dim ee = New ATKD_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 19 'Κλέμα
                Dim ee = New Connector_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 20 'Timer delay on
                Dim ee = New DelayOn_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 21 'Timer delay off
                Dim ee = New DelayOff_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 22 'Τερματικός
                Dim ee = New Termatikos_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 23 'Φωτοκύτταρο
                Dim ee = New PhotoSwitch_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 24 ' 1φ κινητήρας
                Dim ee = New SinglePhaseMotor_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 25 ' Μεγάλο ρελέ
                Dim ee = New Relay2NO2NC_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 26 'Λαμπτήρας
                Dim ee = New Lamp_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 27 'buzzer
                Dim ee = New buzzer_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 28 'Siren
                Dim ee = New Siren_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 29 ' λυχνία με 3 λαμπες
                Dim ee = New ThreePhaseIndicator_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)


            Case 30 ' ΔΔΕ 3
                Dim ee = New DDE_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 31 ' ΔΔΕ 1
                Dim ee = New DDE1_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 32 ' Θερμομαγνητικός
                Dim ee = New Thermomagnetic_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 33 ' Μονοπολική ασφάλεια τήξης
                Dim ee = New fuse1p_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 34 ' Τριπολική ασφάλεια τήξης
                Dim ee = New fuse3p_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 35 ' Μπάρα γείωσης
                Dim ee = New MparaGeiwshs_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 36 ' Μπάρα ουδετέρου
                Dim ee = New mparaOudeterou_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 37 ' Απλός διακόπτης φωτισμού
                Dim ee = New LightSwitchSingle_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 38 'διακόπτης φωτισμού αλε ρετούρ
                Dim ee = New LightSwitchALE_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 39 ' διακόπτης φωτισμού αλέ ρετούρ μεσαίος
                Dim ee = New LightSwitchMES_Activeimage

                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 40 ' διακόπτης φωτισμού κομιτατέρ
                Dim ee = New LightSwitchComitater_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 41 ' ρελέ ράγας
                Dim ee = New ReleRagas
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 42 ' ρελέ καστάνιας
                Dim ee = New ReleKastanias
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 43 'Πλυντήριο
                Dim ee = New WashingMachine_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 44 'Θερμοσίφωνας
                Dim ee = New Waterheater_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)


            Case 45 'PLC
                Dim ee = New PLC_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 46 'Χειριστήριο 2Π
                Dim ee = New XeiristhrioLN1P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 47 'Πρίζα σούκο
                Dim ee = New Socket1ph_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 48 'Γκαραζόπορτα
                Dim ee = New GarageDoor_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 49 'Τριπολική βιομηχανική πρίζα
                Dim ee = New SocketIND3p
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 50 'Τετραπολική βιομηχανική πρίζα
                Dim ee = New SocketIND4p
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 51 'Πενταπολική βιομηχανική πρίζα
                Dim ee = New SocketIND5p
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 52 'AC
                Dim ee = New AC_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 53 'Bell
                Dim ee = New Bell_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 54 'DishWasher
                Dim ee = New Dishwasher_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 55 'dRYER
                Dim ee = New Dryer_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 56 'Ανεμιστήρας
                Dim ee = New Fan_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 57 'Ψυγείο
                Dim ee = New Freezer_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 58 'Θερμάστρα
                Dim ee = New Heater_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 59 'Εξαεριστήρας
                Dim ee = New Hood_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 60 'Φούρνος μικροκυμμάτων
                Dim ee = New Microwave_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 61 'Ηλεκτρική κουζίνα
                Dim ee = New Oven_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 62 'Τηλεόραση
                Dim ee = New TV_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 63 'Παροχή από κάτω προς τα πάνω + νυχτερινό
                Dim ee = New Power_nyxt_Activeimage

                ee.initialization(1)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 64 'Παροχή από πανω προς τα κάτω + νυχτερινό
                Dim ee = New Power_nyxt_Activeimage
                ee.initialization(0)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 65 'Παροχή από αριστερά + νυχτερινό
                Dim ee = New Power_nyxt_Activeimage
                ee.initialization(2)
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 66 'Παροχή από αριστερά + νυχτερινό

                Dim ee = New SlidingDoor_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 67 'Φλοτεροδιακόπτης

                Dim ee = New FloatingSwitch_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 68 'Δεξαμενή
                Dim ee = New WaterTank_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 69 'Διακόπτης κλιμακοστασίου
                Dim ee = New Klimakostasioy_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 70 'Μπουτόν φωτισμού
                Dim ee = New MpoutonFwtismou_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 71 'Μπουτόν κουδουνιού
                Dim ee = New MpoutonKoudouniou_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 72 'Ωρομετρητής
                Dim ee = New hourmeter_activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 73 'Φάρος
                Dim ee = New Faros_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 74 'Αισθητήρας φωτός
                Dim ee = New LightSensor_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 75 'Αισθητήρας ταχύτητας ανέμου
                Dim ee = New WindSensor_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 76 'Αισθητήρας βροχής
                Dim ee = New RainSensor_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 77 'Τέντα
                Dim ee = New Awning_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 78 'Πλήκτρο έκτακτης ανάγκης
                Dim ee = New EmergencyButton_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 79 'Διακόπτης με κλειδί
                Dim ee = New KeySwitch_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 80 'Ηλεκτρική κλειδαριά κυπρί
                Dim ee = New DoorLock_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 81 'Ρελέ λυχνίας
                Dim ee = New ReleLyxnias_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 82 'Διπολικός διακόπτης
                Dim ee = New Switch2p_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 83 'Τετραπολικός διακόπτης
                Dim ee = New Switch4P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 84 'Πενταπολικός διακόπτης
                Dim ee = New Switch5P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 85 'Διπολική ασφάλεια
                Dim ee = New CircuitBreaker2P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

            Case 86 'Τετραπολική ασφάλεια
                Dim ee = New CircuitBreaker4P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 87 'Ασφάλεια L+N τετραπολική 3Π+Ν
                Dim ee = New XeiristhrioLN3P_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 88 'RCBO μονοφασικό
                Dim ee = New RCBO1p_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 89 'RCBO τριφασικό
                Dim ee = New RCBO3p_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 90 '3Φ αντικεραυνικό
                Dim ee = New SurgeProtector3p_ActiveImage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)
            Case 91 '3Φ αντικεραυνικό
                Dim ee = New SurgeProtector1p_Activeimage
                ee.initialization()
                Add_Item_CommonAttributes(ee, type, locationx, locationy)

        End Select



    End Sub







    Private Sub resetallselections()
        Dim sarwsh As Integer
        'Μόλις γίνει η προσθήκη γίνεται αποεπιλογή αντικειμένων και βιδών\
        For sarwsh = 0 To numberOfActiveObjects - 1
            allActiveObjects(sarwsh).SetSelectedStatus(False) : allActiveObjects(sarwsh).SetSelectedScrew(-1)
        Next
        activeObject = Nothing
        activeScrewnum = -1
        currentActiveObject = Nothing
        currentActiveScrew = -1

    End Sub
    Private Sub ActiveImage_MouseClick(sender As Object, e As MouseEventArgs)
        'Όταν γίνεται κλικ τότε επιλέγεται το τρέχον αντικείμενο.
        Dim thescrew As SingleScrewData = Nothing
        Dim Clickedobj As ActiveImage
        Dim Sarwsh As Integer
        Dim SuccessOnWire As Boolean
        Dim brushcolor As Brush
        Dim nodepointb As Point
        Dim nodepointa As Point
        Dim extranodepoint As Point
        Dim screwdata As SingleScrewData = Nothing
        Dim GotScrew1 As Integer
        Dim GotScrew2 As Integer
        Dim apostash As Integer

        'Δημιούργησε αντικείμενο από το Sender
        Clickedobj = CType(sender, ActiveImage)
        Dim activekanabos As Integer = kanabos / (HScrollBar1.Value)

        On Error Resume Next
        'Πληροφορίές


        '-----------------------------------------------------------------------------------------------Αν έχει κάνει αριστερό κλικ
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'Ελέγχω αν έχει κάνει κλικ επάνω σε βίδα. Αν είναι τότε τη σημειώνω ως ενεργή βίδα
            currentActiveScrew = Clickedobj.isOnScrew(e.X, e.Y, sender)
            If currentActiveScrew > -1 Then Clickedobj.SetSelectedScrew(currentActiveScrew)

            'checkit.Items.Add("current screw :" + Str(currentActiveScrew))

            'Αν είχαμε μια ήδη επιλεγμένη βίδα πιο πριν τότε σχεδίασε καλώδιο
            If activeObject IsNot Nothing And (activeScrewnum > -1) And Clickedobj IsNot Nothing And (currentActiveScrew > -1) Then

                'Εάν υπάρχει ήδη αυτος ο αγωγός τότε μην προχωρήσεις στην πρόσθεση
                If wires.doesThisWireAlreadyExist(Clickedobj, activeObject, activeScrewnum, currentActiveScrew) > -1 Then wires.selectnone() : Exit Sub
                If numberOfWires = maxwires Then wires.selectnone() : MsgBox("Φτάσατε στον μέγιστο αριθμό αγωγών") : Exit Sub
                'Προσθήκη νέου αγωγού
                numberOfWires = numberOfWires + 1
                wires.allWires(numberOfWires) = New Wire


                'Ρυθμιση του αυτόματου χρώματος
                'Αν δεν έχουμε επιλέξει το αυτόματο χρώμα
                If Not AutoColor.Checked Then
                    brushcolor = New SolidBrush(selectedcolor2.BackColor)
                Else
                    'Αν έχουμε επιλέξει το αυτόματο χρώμα

                    activeObject.returnScrew(activeScrewnum, thescrew)
                    brushcolor = New SolidBrush(thescrew.color)
                End If


                wires.allWires(numberOfWires).CreateWire(activeObject, activeScrewnum, Clickedobj, currentActiveScrew, brushcolor, True, SuccessOnWire)


                'Κώδικας για την προσθήκη αρχικών nodes στον αγωγό
                'Για την πρώτη βίδα
                'Παίρνω τα στοιχεία της βίδας και βλέπω αν υπάρχει πρόβλημα
                GotScrew1 = activeObject.returnScrew(activeScrewnum, screwdata)
                'Υπολογίζω την απόσταση που πρέπει να έχουν τα αυτόματα nodes από την βίδα
                apostash = (Apostash_Aytomatoy_Node + Apostash_Aytomatoy_Node_Prosthhkh * Arithmos_aytomatvn_nodes) / Clickedobj.ratio

                'Αν δεν υπάρχει πρόβλημα
                If GotScrew1 > -1 Then
                    'Υπολογίζω το πρώτο σημείο
                    'Σημείο = Θέση Χ του Αντικειμένου + Θέση Χ της βίδας + μισό πλάτος βίδας + Αποσταση node * cos( Γωνία * π)
                    'nodepoint = New Point(activeObject.Location.X + screwdata.X + screwdata.Width / 2 - apostash * Math.Cos((screwdata.WhereToPutNode * Math.PI)), activeObject.Location.Y + screwdata.Y + screwdata.Width / 2 - apostash * Math.Sin((screwdata.WhereToPutNode * Math.PI)))
                    nodepointa = New Point(activeObject.Location.X + screwdata.X / Clickedobj.ratio + (screwdata.Width / Clickedobj.ratio) / 2 - apostash * Math.Cos((screwdata.WhereToPutNode * Math.PI)), activeObject.Location.Y + screwdata.Y / Clickedobj.ratio + (screwdata.Width / Clickedobj.ratio) / 2 - apostash * Math.Sin((screwdata.WhereToPutNode * Math.PI)))

                    wires.allWires(numberOfWires).InsertNode(nodepointa, 1)
                End If
                'Για την δεύτερη βίδα
                GotScrew2 = Clickedobj.returnScrew(currentActiveScrew, screwdata)
                'Αν δεν υπάρχει πρόβλημα
                If GotScrew2 > -1 Then
                    'Υπολογίζω το πρώτο σημείο
                    'Σημείο = Θέση Χ του Αντικειμένου + Θέση Χ της βίδας + μισό πλάτος βίδας + Αποσταση node * cos( Γωνία * π)
                    nodepointb = New Point(Clickedobj.Location.X + screwdata.X / Clickedobj.ratio + (screwdata.Width / Clickedobj.ratio) / 2 - apostash * Math.Cos((screwdata.WhereToPutNode * Math.PI)), Clickedobj.Location.Y + screwdata.Y / Clickedobj.ratio + (screwdata.Width / Clickedobj.ratio) / 2 - apostash * Math.Sin((screwdata.WhereToPutNode * Math.PI)))
                    wires.allWires(numberOfWires).InsertNode(nodepointb, 2)
                End If
                Arithmos_aytomatvn_nodes = Arithmos_aytomatvn_nodes + 1



                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                '**********************************************************************************************************************************************
                Dim w As Integer, n As Integer, upordown As Integer = nodepointb.Y - nodepointa.Y, gotscrew12 As Integer, screw2 As SingleScrewData = Nothing, isitok As Boolean

                'Αν έχουμε επιλέξει την αυτόματη προσθήκη nodes για πιο εύκολη καλωδίωση
                If Auto_Add_Nodes.Checked Then
                    gotscrew12 = activeObject.returnScrew(activeScrewnum, screw2)
                    'Η αλλή screw είναι η screwdata και υπολογίστηκε παραπάνω


                        'Εάν τα δύο nodes που προσθέσαμε πριν δεν βρίσκονται στην ίδια ευθεία τότε θα πρέπει να προσθέσουμε ένα ακόμα node
                        If Not ((nodepointa.X = nodepointb.X) Or (nodepointa.Y = nodepointb.Y)) Then
                            extranodepoint = New Point(nodepointb.X, nodepointa.Y)

                            'Τώρα θα γίνει έλεγχος αν είναι στην ίδια ευθεία με κάποιον άλλο αγωγό

                            'Τώρα διαβάζουμε την αρχική βίδα για να δούμε την φορά που θα πρέπει να έχει το node μας

                            'Τώρα σαρώνουμε όλα τα άλλα καλώδια και όλα τα nodes για να δούμε αν βρίσκονται στην ίδια ευθεία
                            For w = 0 To numberOfWires - 1
                                For n = 0 To wires.allWires(w).get_total_nodes
                                    'Αν είναι στην ίδια ευθεία με κάποιο άλλο node
                                    If extranodepoint.Y = wires.allWires(w).nodes(n).Y Then
                                        'Τότε μετακινώ το node κατά δύο κελιά κανάβου
                                    extranodepoint = New Point(extranodepoint.X, extranodepoint.Y - (kanabos * 2 * Math.Sin(screw2.WhereToPutNode * Math.PI)) / Clickedobj.ratio)
                                        'και μετακινώ και τον πρώτο node
                                        wires.allWires(numberOfWires).moveNode(1, nodepointa.X, extranodepoint.Y) 'extranodepoint.Y + 10)
                                    End If
                                Next
                            Next
                            wires.allWires(numberOfWires).InsertNode(extranodepoint, 2)




                        'Τώρα θα πρέπει να γίνει ο εξής έλεγχος.
                        'Αν ο αγωγός που φέυγει από το τελευταίο αντικείμενο πάει προς τα πάνω προς τον πρώτο node και μετά τον πρώτο node πάει προς τα κάτω τότε θα πρέπει να μπούνε νέα nodes
                        'Σε αυτή την περίπτωση θα πρέπει να μετακινηθεί το πρόσθετο node (2)
                        extranodepoint = New Point(((nodepointb.X + nodepointa.X) / 2), extranodepoint.Y)
                        wires.allWires(numberOfWires).moveNode(2, extranodepoint.X, extranodepoint.Y)
                        extranodepoint = New Point(((nodepointb.X + nodepointa.X) / 2), nodepointb.Y)

                        For w = 0 To numberOfWires - 1
                            For n = 0 To wires.allWires(w).get_total_nodes
                                'Αν είναι στην ίδια ευθεία με κάποιο άλλο node
                                If extranodepoint.Y = wires.allWires(w).nodes(n).Y Then
                                    'Τότε μετακινώ το node κατά δύο κελιά κανάβου
                                    extranodepoint = New Point(extranodepoint.X, extranodepoint.Y - (kanabos * 2 * Math.Sin(screwdata.WhereToPutNode * Math.PI) / Clickedobj.ratio))
                                    'και μετακινώ και τον πρώτο node
                                    'wires.allWires(numberOfWires).moveNode(3, nodepointa.X, extranodepoint.Y) 'extranodepoint.Y + 10)
                                    wires.allWires(numberOfWires).moveNode(3, wires.allWires(numberOfWires).getNode(4, isitok).X, extranodepoint.Y) 'extranodepoint.Y + 10)
                                End If

                            Next
                        Next
                        wires.allWires(numberOfWires).InsertNode(extranodepoint, 3)

                End If
            End If


            wires.drawAllWires()
            wires.selectnone()
            resetallselections()

            Clickedobj.Refresh()
            'Exit Sub


        End If

        'Σημειώνω τα αντικείμενο και την επιλεγμένη βίδα για την επόμενη φορά.
        If currentActiveScrew > -1 Then
            activeObject = Clickedobj
            activeScrewnum = currentActiveScrew

        End If


        'Εάν είναι ήδη επιλεγμένο τότε απλά βγες από το Sub
        If currentActiveObject = Int(Clickedobj.Tag) Then Exit Sub

        'Βρες τον αριθμό του αντικειμένου που έγινε κλικ
        currentActiveObject = Int(Clickedobj.Tag)


        'Ρυθμισε κατάλληλα το Border όλων των υπόλοιπων αντικειμένων
        For Sarwsh = 0 To numberOfActiveObjects - 1
            If currentActiveObject <> Sarwsh Then allActiveObjects(Sarwsh).SetSelectedStatus(False) : allActiveObjects(Sarwsh).SetSelectedScrew(-1)
        Next

        'Ρυθμισε κατάλληλα το Border του επιλεγμένου αντικειμένου
        allActiveObjects(currentActiveObject).SetSelectedStatus(True)



        '        End If
        '       End If

        Clickedobj.Refresh()

        End If


        '-----------------------------------------------------------------------------------------------Αν έχει κάνει δεξί κλικ
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim activeimagedelmenu = New ContextMenuStrip

            Dim menu1 = activeimagedelmenu.Items.Add("Διαγραφή στοιχείου")
            menu1.Tag = "delactiveimage"
            AddHandler menu1.Click, AddressOf DeleteActiveImage
            ObjectThatWasRightClicked = Clickedobj

            'Αν το αντικείμενο δέχεται ρύθμιση χρόνου
            If Clickedobj.HasTimeSettings Then
                Dim menuTime = activeimagedelmenu.Items.Add("Ρύθμιση χρονικής καθυστέρησης")
                menuTime.Tag = "settime"
                AddHandler menuTime.Click, AddressOf settime



            End If

            'Αν το αντικείμενο είναι relay
            If Clickedobj.WhatAmI = "RELAY" Or Clickedobj.WhatAmI = "RELAY2NC2NO" Then
                'Αν έχει μηχανική μανδάλωση με κάποιο ρελέ τότε του δίνεται η επιλογή να την ακυρώσει
                If Clickedobj.InterlockedWith > -1 Then
                    Dim menu2 = activeimagedelmenu.Items.Add("Ακύρωση μανδάλωσης")
                    WhereToResetInterlock = Clickedobj
                    menu2.Tag = "resetinterlock"
                    AddHandler menu2.Click, AddressOf reset_interlock
                End If
                'Ψάξε όλα τα άλλα αντικείμενα για να δεις αν υπάρχουν άλλα ρελέ.

                'Αν έχει μηχανική μανδάλωση με κάποιο ρελέ τότε του δίνεται η επιλογή να την ακυρώσει
                If Clickedobj.InterlockedWith = -1 Then
                    Dim menu3 = activeimagedelmenu.Items.Add("Ορισμός μανδάλωσης")
                    WhichObjectToInterlock = Clickedobj
                    menu3.Tag = "interlock"
                    AddHandler menu3.Click, AddressOf Set_Interlock
                End If


            End If




            'Αν το αντικείμενο είναι PLC πρέπει να προσθέσουμε τα παρακάτω στο μενού του δεξιού κλικ
            If Clickedobj.WhatAmI = "PLC" Then
                Dim menu4 = activeimagedelmenu.Items.Add("Ορισμός λογικών εξισώσεων")
                WhichPLCtoWorkOn = Clickedobj
                'MsgBox(WhichPLCtoWorkOn.GetHashCode.ToString)
                'MsgBox(Clickedobj.GetHashCode.ToString)
                menu4.Tag = "SetEquationsForPLC"
                AddHandler menu4.Click, AddressOf SetEquationsForPLC
            End If

            'Αν το αντικείμενο είναι γκαραζόπορτα τότε θα πρέπει να ανοίξουν οι ρυθμίσεις για την γκαραζόπορτα
            If Clickedobj.WhatAmI = "GARAGE DOOR" Then
                Dim menu4 = activeimagedelmenu.Items.Add("Τοποθέτηση και σύνδεση εξαρτημάτων στην γκαραζόπορτα.")
                WhichGarageDoortoWorkOn = Clickedobj
                menu4.Tag = "GarageDoorSettings"
                AddHandler menu4.Click, AddressOf setgaragedoorsettings
            End If


            'Αν το αντικείμενο είναι τέντα τότε θα πρέπει να ανοίξουν οι ρυθμίσεις για την γκαραζόπορτα
            If Clickedobj.WhatAmI = "AWNING" Then
                Dim menu4 = activeimagedelmenu.Items.Add("Τοποθέτηση και σύνδεση εξαρτημάτων στην τέντα.")
                WhichAwningtoWorkOn = Clickedobj
                menu4.Tag = "AwningSettings"
                AddHandler menu4.Click, AddressOf setAwningsettings
            End If



            'Αν το αντικείμενο είναι συρόμενη πορτα τότε θα πρέπει να ανοίξουν οι ρυθμίσεις για την πόρτα
            If Clickedobj.WhatAmI = "SLIDING DOOR" Then
                Dim menu4 = activeimagedelmenu.Items.Add("Τοποθέτηση και σύνδεση εξαρτημάτων στην συρόμενη πορτα.")
                WhichSlidingDoortoWorkOn = Clickedobj
                menu4.Tag = "SlidingDoorSettings"
                AddHandler menu4.Click, AddressOf setSlidingdoorsettings
            End If

            'Αν το αντικείμενο είναι δεξαμενή τότε θα πρέπει να ανοίξουν οι ρυθμίσεις για αυτή
            If Clickedobj.WhatAmI = "WATER TANK" Then
                Dim menu4 = activeimagedelmenu.Items.Add("Τοποθέτηση και σύνδεση εξαρτημάτων στην δεξαμενή.")
                WhichObjectToWorkOn = Clickedobj
                menu4.Tag = "WaterTankSettings"
                AddHandler menu4.Click, AddressOf setWaterTanksettings
            End If



            activeimagedelmenu.Show(Clickedobj, e.X, e.Y)
        End If
    End Sub

    Private Sub setWaterTanksettings()
        WhichObjectToWorkOn.ShowSettings()
    End Sub

    'Καλείται μέσω δεξιού κλικ
    'Ξεκινά την διαδικασία για τον ορισμό των εξισώσεων για τις εξόδους του PLC
    Private Sub SetEquationsForPLC()
        WhichPLCtoWorkOn.OpenEquationsWindow()
    End Sub

    'Καλείται μέσω δεξιού κλικ
    'Ξεκινά την διαδικασία για τον ορισμό των εξαρτημάτων της γκαραζόπορτας
    Private Sub setgaragedoorsettings()
        WhichGarageDoortoWorkOn.ShowSettings()
    End Sub

    'Καλείται μέσω δεξιού κλικ
    'Ξεκινά την διαδικασία για τον ορισμό των εξαρτημάτων της γκαραζόπορτας
    Private Sub setAwningsettings()
        WhichAwningtoWorkOn.ShowSettings()
    End Sub

    'Καλείται μέσω δεξιού κλικ
    'Ξεκινά την διαδικασία για τον ορισμό των εξαρτημάτων της γκαραζόπορτας
    Private Sub setSlidingdoorsettings()
        WhichSlidingDoortoWorkOn.ShowSettings()
    End Sub



    'Αφαίρεση του Interlock από το συγκεκριμένο ρελέ
    Private Sub reset_interlock()
        Dim i As Integer
        If WhereToResetInterlock Is Nothing Then Exit Sub
        'Πρώτα αφαιρείται το interlock από το άλλο αντικείμενο 
        i = WhereToResetInterlock.InterlockedWith
        allActiveObjects(i).InterlockedWith = -1
        allActiveObjects(i).Refresh()
        WhereToResetInterlock.InterlockedWith = -1
        WhereToResetInterlock.Refresh()

        WhereToResetInterlock = Nothing
    End Sub
    Private Sub Set_Interlock()
        Dim i As Integer
        Dim found(maxActiveObjects) As Integer
        Dim totalfound = 0
        Dim txt As String = "Πληκτρολογήστε τον σειριακό αριθμό(#) του ρελέ που θέλετε να μανδαλώσετε με το επιλεγμένο:" + vbNewLine
        Dim resp As String
        Dim correct As Boolean = False
        Dim rint As Integer
        'Ελέγχουμε την ποσότητα των διαθέσιμων ρελέ
        For i = 0 To numberOfActiveObjects - 1
            'Αν το αντικείμενο που ελέγχω αυτή τη στιγμή δεν είναι αυτό που ζήτησε ο χειριστής να μανδαλώσει
            'Debug.Print("Έλεγχος :" + i.ToString + "." + allActiveObjects(i).WhatAmIGreek)
            If allActiveObjects(i) IsNot WhichObjectToInterlock Then
                'Αν δεν έχει μανδαλωθεί ήδη και είναι ρελέ τότε...
                If (allActiveObjects(i).InterlockedWith = -1) And ((allActiveObjects(i).WhatAmI = "RELAY") Or (allActiveObjects(i).WhatAmI = "RELAY2NC2NO")) Then found(totalfound) = i : totalfound = totalfound + 1 : txt = txt + i.ToString + ", "
            End If
        Next
        If totalfound > 0 Then
retrythis:

            resp = InputBox(txt, "Επιλογή ρελέ για μηχανική μανδάλωση", "")
            If resp = "" Then Exit Sub
            On Error GoTo retrythis
            rint = Integer.Parse(resp)
            For i = 0 To totalfound - 1
                If rint = found(i) Then correct = True
            Next
            If Not correct Then MsgBox("Λάθος σειριακός αριθμός. Το ρελέ με τον σειριακό αριθμό που πληκτρολογήσατε δεν είναι διαθέσιμο", vbOKOnly) : Exit Sub
            'Αν όλα είναι ΟΚ τότε προχωράω στο interlock
            WhichObjectToInterlock.InterlockedWith = rint
            allActiveObjects(rint).InterlockedWith = Integer.Parse(WhichObjectToInterlock.Tag)
            WhichObjectToInterlock.Refresh()
            allActiveObjects(rint).Refresh()

        End If
    End Sub
    Private Sub ActiveImage_MouseDown(sender As Object, e As MouseEventArgs)

        If clickx = -1 Then
            clickx = e.Location.X
            clicky = e.Location.Y
        End If

        clicked = True






    End Sub

    Private Sub ActiveImage_MouseHover(sender As Object, e As EventArgs)
    End Sub

    Private Sub ActiveImage_MouseMove(sender As Object, e As MouseEventArgs)
        Dim Clickedobj As ActiveImage
        Dim currentActiveScrew As Integer
        Dim fromx, fromy, tox, toy As Integer


        Clickedobj = CType(sender, ActiveImage)
        Clickedobj.getMoveBounds(fromx, fromy, tox, toy)

        currentActiveScrew = Clickedobj.isOnScrew(e.X, e.Y, sender)


        If clicked And (currentActiveScrew = -1) And (e.X * Clickedobj.ratio > fromx) And (e.X * Clickedobj.ratio < tox) And (e.Y * Clickedobj.ratio > fromy) And (e.Y * Clickedobj.ratio < toy) Then
            Clickedobj.Location = New Point(Clickedobj.Location.X + e.Location.X - clickx, Clickedobj.Location.Y + e.Location.Y - clicky)
            'Me.Refresh()
            '***
            Clickedobj.Refresh()
            wires.drawAllWires()
            'deleteme.drawWire(Me, HScrollBar1.Value)

        End If

    End Sub


    Private Sub ActiveImage_MouseUp(sender As Object, e As MouseEventArgs)
        Dim Clickedobj As ActiveImage
        Dim newx As Integer
        Dim newy As Integer
        Dim activekanabos As Integer = kanabos / (HScrollBar1.Value)
        Clickedobj = CType(sender, ActiveImage)

        newx = Clickedobj.Location.X
        newy = Clickedobj.Location.Y



        'snapping to grid
        If Snaptogrid.Checked Then
            If (Clickedobj.Location.X Mod activekanabos) > (activekanabos / 2) Then newx = ((Clickedobj.Location.X \ activekanabos) + 1) * activekanabos Else newx = (Clickedobj.Location.X \ activekanabos) * activekanabos
            If (Clickedobj.Location.Y Mod activekanabos) > (activekanabos / 2) Then newy = ((Clickedobj.Location.Y \ activekanabos) + 1) * activekanabos Else newy = (Clickedobj.Location.Y \ activekanabos) * activekanabos
        End If

        Clickedobj.Location = New Point(newx, newy)

        'Me.Refresh()
        Clickedobj.Refresh()
        wires.drawAllWires()
        'deleteme.drawWire(Me, HScrollBar1.Value)

        clickx = -1
        clicky = -1
        clicked = False
    End Sub




    Private Sub refreshFilename()

        Me.Text = programName + " (" + ActiveFileName + ")"
        Simulator.Text = simulatorname + " (" + ActiveFileName + ")"
    End Sub

    Private Sub Edit_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        changezoomlevel()

    End Sub
    'Ανάγνωση των ρυθμίσεων του προγράμματος
    Private Sub Load_Settings()
        AutoColor.Checked = My.Settings.AutoColor
        AutoColorMenu.Checked = My.Settings.AutoColor
        ShowSplashScreenMenu.Checked = Not My.Settings.DoNotShowSplashScreen
        DrawNodes.Checked = My.Settings.DrawNodes
        ΣημείαΜετακίνησηςΑγωγώνToolStripMenuItem.Checked = DrawNodes.Checked

        Auto_Add_Nodes.Checked = My.Settings.AutoAddNodes

        Snaptogrid.Checked = My.Settings.SnapToGrid
        ΣυγκράτησηΣτοΠλέγμαToolStripMenuItem.Checked = My.Settings.SnapToGrid
        SnapToWire.Checked = My.Settings.SnapToWire
        ΣυγκράτησηΣταΑντικείμεναToolStripMenuItem.Checked = My.Settings.SnapToWire

        selectedcolor2.BackColor = My.Settings.WireColor


        ΠροβολήΣυμβόλωνToolStripMenuItem.Checked = My.Settings.ShowSymbolsOnEdit
        UseSymbolsOnEdit(My.Settings.ShowSymbolsOnEdit)


        ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.Checked = My.Settings.ShowInfoOnEdit
        drawUsernameDuringEdit = ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.Checked


        'Φόρτωση ρυθμίσεων Watch
        Watch.Show_Voltage.Checked = My.Settings.Simulator_ShowVoltage
        Show_Voltage_During_Simulation = My.Settings.Simulator_ShowVoltage

        Watch.showinfo.Checked = My.Settings.Simulator_ShowInfo
        show_info_during_simulation = My.Settings.Simulator_ShowInfo

        Watch.showkeys.Checked = My.Settings.Simulator_ShowKeys
        show_keys_during_simulation = My.Settings.Simulator_ShowKeys

        'Φόρτωση ρυθμίσεων Simulator

        Simulator.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Checked = My.Settings.Simulator_ShowSymbols
        SimulationSymbols = My.Settings.Simulator_ShowSymbols
        Simulator.Timer1.Interval = My.Settings.Simulator_TimerTick
        soundon = My.Settings.Simulator_SoundOn
        Simulator.SetSoundOnMenuImage()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Application.SaveMySettingsOnExit = True
        Load_Settings()



        'Ορισμός Tooltiptext
        'ToolTip1.SetToolTip(Me, tooltips_edit) 'Είναι ενοχλητικό

        ToolTip1.SetToolTip(Add_Swith_1P, addNewLine(My.Resources.RailSwitch_SinglePole_Tooltip))
        diakopths1p.ToolTipText = addNewLine(My.Resources.RailSwitch_SinglePole_Tooltip)


        ΔιπολικόςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RailSwitch_TwoPole_Tooltip)
        ΤέτραπολικόςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RailSwitch_FourPole_Tooltip)
        ΠενταπολικόςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RailSwitch_FivePole_Tooltip)

        ToolTip1.SetToolTip(Add_Switch_3P, addNewLine(My.Resources.RailSwitch_ThreePole_Tooltip))
        diakopths3p.ToolTipText = addNewLine(My.Resources.RailSwitch_ThreePole_Tooltip)



        ToolTip1.SetToolTip(Add_1P_CircuitBreaker, addNewLine(My.Resources.CircuitBreaker_SinglePole_Tooltip))
        asfalia1paytomath.ToolTipText = addNewLine(My.Resources.CircuitBreaker_SinglePole_Tooltip)

        ToolTip1.SetToolTip(Add_3P_CircuitBreaker, addNewLine(My.Resources.CircuitBreaker_ThreePole_Tooltip))
        asfaleia3paytomath.ToolTipText = addNewLine(My.Resources.CircuitBreaker_ThreePole_Tooltip)
        ΔιπολικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.CircuitBreaker_TwoPole_Tooltip)
        ΤετραπολικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.CircuitBreaker_FourPole_Tooltip)

        ToolTip1.SetToolTip(add_xeiristhrio, addNewLine(My.Resources.Xeiristhrio_SinglePole_Tooltip))
        ΔιπολικόLNToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Xeiristhrio_SinglePole_Tooltip)
        ΤετραπολικήΑσφάλειαLNToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Xeiristhrio_FourPole_Tooltip)
        ToolTip1.SetToolTip(add_fuse1p, addNewLine(My.Resources.Fuse_SinglePole_ToolTip))
        ΜονοπολικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Fuse_SinglePole_ToolTip)

        ToolTip1.SetToolTip(add_fuse3p, addNewLine(My.Resources.Fuse_ThreePole_Tooltip))
        ΤριπολικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Fuse_ThreePole_Tooltip)


        ToolTip1.SetToolTip(Add_DelayOn, addNewLine(My.Resources.DelayOn_Tooltip))
        DelayOnToolStripMenuItem.ToolTipText = addNewLine(My.Resources.DelayOn_Tooltip)

        ToolTip1.SetToolTip(Add_Delay_Off, addNewLine(My.Resources.DelayOff_Tooltip))
        DelayOffToolStripMenuItem.ToolTipText = addNewLine(My.Resources.DelayOff_Tooltip)

        ToolTip1.SetToolTip(add_HourMeter, addNewLine(My.Resources.HourMeter_Tooltip))
        ΩρομετρητήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.HourMeter_Tooltip)

        ToolTip1.SetToolTip(add_Connector, addNewLine(My.Resources.Connector_ToolTip))
        ΚλέμαΠίνακαToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Connector_ToolTip)

        ToolTip1.SetToolTip(Add_Start, addNewLine(My.Resources.StartButton_Tooltip))
        ΣτάρτStartToolStripMenuItem.ToolTipText = addNewLine(My.Resources.StartButton_Tooltip)

        ToolTip1.SetToolTip(add_stop, addNewLine(My.Resources.StopButton_Tooltip))
        ΣτοπToolStripMenuItem.ToolTipText = addNewLine(My.Resources.StopButton_Tooltip)

        ToolTip1.SetToolTip(Add_StartStop, addNewLine(My.Resources.StartStopButton_Tooltip))
        ΣταρτΣτόπStartStopNONCToolStripMenuItem.ToolTipText = addNewLine(My.Resources.StartStopButton_Tooltip)
        ToolTip1.SetToolTip(Add_Emergency_Button, addNewLine(My.Resources.Emergency_Button_Tooltip))
        ΠλήκτροΈκτακτηςΑνάγκηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Emergency_Button_Tooltip)
        ΔιακόπτηςΜεΚλειδίToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Key_Switch_tooltip)





        ToolTip1.SetToolTip(Add_Terminal_Switch, addNewLine(My.Resources.LimitSwitch_Tooltip))
        ΤερματικόςΔιακόπτηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LimitSwitch_Tooltip)

        ToolTip1.SetToolTip(Add_Photo_Switch, addNewLine(My.Resources.PhotoelectricSensor_Tooltip))
        ΦωτοκύτταροToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PhotoelectricSensor_Tooltip)

        ToolTip1.SetToolTip(Add_floter, addNewLine(My.Resources.FloatSwitch_Tooltip))
        ΦλοτεροδιακόπτηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.FloatSwitch_Tooltip)



        ToolTip1.SetToolTip(add_LightSensor, addNewLine(My.Resources.Sensor_Light_Tooltiptext))
        ΑισθητήραςΦωτόςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Sensor_Light_Tooltiptext)

        ToolTip1.SetToolTip(add_WindSensor, addNewLine(My.Resources.Sensor_Wind_ToolTipText))
        ΑισθητήραςΤαχύτηταςΑνέμουToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Sensor_Wind_ToolTipText)

        ToolTip1.SetToolTip(add_RainSensor, addNewLine(My.Resources.Sensor_Rain_Tooltiptext))
        ΑισθητήραςΒροχήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Sensor_Rain_Tooltiptext)


        ToolTip1.SetToolTip(add_buzzer, addNewLine(My.Resources.Buzzer_Tooltip))
        ΒομβητήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Buzzer_Tooltip)

        ToolTip1.SetToolTip(Add_siren, addNewLine(My.Resources.Siren_Tooltip))
        ΣειρήναToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Siren_Tooltip)

        ToolTip1.SetToolTip(Add_Relay, addNewLine(My.Resources.Relay_Tooltip))
        ΗλέκτρονόμοςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Relay_Tooltip)

        ToolTip1.SetToolTip(Add_Relay2NO2NC, addNewLine(My.Resources.RelayBig_ToolTip))
        ΗλεκτρονόμοςΜεΠολλέςΕπαφέςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RelayBig_ToolTip)

        ΡελέΛυχνίαςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Rele_Lyxnias_Tooltip)
        ΗλεκτρικήΚλειδαριάκυπρίToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Door_Lock_ToolTip)


        ToolTip1.SetToolTip(Add_thermiko, addNewLine(My.Resources.Thermiko_Tooltip))
        ΘερμικόToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Thermiko_Tooltip)

        ToolTip1.SetToolTip(add_thermomagnetic, addNewLine(My.Resources.Thermomagnitiko_Tooltip))
        ΘερμομαγνητικόςΔιακόπτηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Thermomagnitiko_Tooltip)

        ToolTip1.SetToolTip(Add_greenLight, addNewLine(My.Resources.Indicator_ToolTip))
        ΠράσινηToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Indicator_ToolTip)

        ToolTip1.SetToolTip(Add_redlight, addNewLine(My.Resources.Indicator_ToolTip))
        ΚόκκινηToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Indicator_ToolTip)

        ToolTip1.SetToolTip(add_3phInicator, addNewLine(My.Resources.Indicator3p_ToolTip))
        ΤριφασικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Indicator3p_ToolTip)

        ToolTip1.SetToolTip(Add_lamp, addNewLine(My.Resources.Lamp_ToolTip))
        ΛαμπτήραςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Lamp_ToolTip)
        ΦάροςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Faros_TooltipText)

        ToolTip1.SetToolTip(Add_Supply_FromAbove, addNewLine(My.Resources.Power_ToolTip))
        paroxh_panw.ToolTipText = addNewLine(My.Resources.Power_ToolTip)

        ToolTip1.SetToolTip(Add_Supply_FromBelow, addNewLine(My.Resources.Power_ToolTip))
        paroxh_katw.ToolTipText = addNewLine(My.Resources.Power_ToolTip)

        ToolTip1.SetToolTip(Add_Supply_FromLeft, addNewLine(My.Resources.Power_ToolTip))
        paroxh_dejia.ToolTipText = addNewLine(My.Resources.Power_ToolTip)

        ToolTip1.SetToolTip(Add_Nyxt_panw, addNewLine(My.Resources.PowerNyxt_tooltip))
        ΠαροχήΑπόΕπάνωToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PowerNyxt_tooltip)

        ToolTip1.SetToolTip(Add_Nyxt_Katw, addNewLine(My.Resources.PowerNyxt_tooltip))
        ΠαροχήΑπόΚάτωToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PowerNyxt_tooltip)

        ToolTip1.SetToolTip(Add_Nyxt_Arist, addNewLine(My.Resources.PowerNyxt_tooltip))
        ΠαροχήΑπόΑριστεράToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PowerNyxt_tooltip)


        ToolTip1.SetToolTip(add_motorY, addNewLine(My.Resources.ATKY_Tooltip))
        ΣεΣυνδεσμολογίαΑστέραΥToolStripMenuItem.ToolTipText = addNewLine(My.Resources.ATKY_Tooltip)

        ToolTip1.SetToolTip(add_motord, addNewLine(My.Resources.ATKD_ToolTip))
        ΣεΣυνδεσμολογίαΤριγώνουΔToolStripMenuItem.ToolTipText = addNewLine(My.Resources.ATKD_ToolTip)

        ToolTip1.SetToolTip(add_motor, addNewLine(My.Resources.ATK_ToolTip))
        ΧωρίςΣυνδεσμολογίαToolStripMenuItem.ToolTipText = addNewLine(My.Resources.ATK_ToolTip)

        ToolTip1.SetToolTip(add_1phMotor, addNewLine(My.Resources.Motor1ph_ToolTip))
        ΜονοφασικόςΚινητήραςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Motor1ph_ToolTip)

        ToolTip1.SetToolTip(Add_DDE, addNewLine(My.Resources.DDE3p_Tooltip))
        ΤριφασικόΡελέΔιαρροήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.DDE3p_Tooltip)

        ToolTip1.SetToolTip(add_DDE1, addNewLine(My.Resources.DDE1p_Tooltip))
        ΜονοφασικόΡελέΔιαρροήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.DDE1p_Tooltip)


        ToolTip1.SetToolTip(add_mpara_oudeterou, addNewLine(My.Resources.MparaOydeteroy_Tooltip))
        ΜπάραΟυδετέρουToolStripMenuItem.ToolTipText = addNewLine(My.Resources.MparaOydeteroy_Tooltip)

        ToolTip1.SetToolTip(add_mpara_geiwshs, addNewLine(My.Resources.MparaGeiwshs_Tooltip))
        ΜπάραΓείωσηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.MparaGeiwshs_Tooltip)


        ToolTip1.SetToolTip(Add_SingleLightSwitch, addNewLine(My.Resources.LightSwitch_Single_Tooltip))
        ΑπλόςΔιακόπτηςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LightSwitch_Single_Tooltip)


        ToolTip1.SetToolTip(Add_LightSwitchCOM, addNewLine(My.Resources.LightSwitch_Komitater_Tooltip))
        ΔιακόπτηςΚομιτατέρToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LightSwitch_Komitater_Tooltip)


        ToolTip1.SetToolTip(Add_LightSwitchALE, addNewLine(My.Resources.LightSwitch_AleRetour_Tooltip))
        ΑλέΡετούρToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LightSwitch_AleRetour_Tooltip)

        ToolTip1.SetToolTip(Add_LightSwitchMES, addNewLine(My.Resources.LightSwitch_AleRetourMesaios_Tooltip))
        ΜεσαίοςΔιακόπτηςΑλέΡετούρToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LightSwitch_AleRetourMesaios_Tooltip)

        ToolTip1.SetToolTip(add_button_koydoynioy, addNewLine(My.Resources.Bell_Button_Tooltip))
        ΜπουτόνΚουδουνιούToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Bell_Button_Tooltip)

        ToolTip1.SetToolTip(add_button_fwtismoy, addNewLine(My.Resources.LightButton_Tooltip))
        ΜπουτόνΦωτισμούToolStripMenuItem.ToolTipText = addNewLine(My.Resources.LightButton_Tooltip)



        ToolTip1.SetToolTip(Add_ΡελέΡάγας, addNewLine(My.Resources.RelayDINRail_Tooltip))
        ΗλεκτρονόμοςΡάγαςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RelayDINRail_Tooltip)


        ToolTip1.SetToolTip(add_rele_kastanias, addNewLine(My.Resources.RelayKastania_Tooltip))
        ΡελέΚαστάνιαςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.RelayKastania_Tooltip)


        ToolTip1.SetToolTip(add_klimakostasiou, addNewLine(My.Resources.Relay_Klimakostasioy_Tooltip))
        ΔιακόπτηςΚλιμακοστασίουToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Relay_Klimakostasioy_Tooltip)



        ToolTip1.SetToolTip(ADDPLC, addNewLine(My.Resources.PLC_Tooltip))
        ΠρογραμματιζόμενοςΛογικόςΕλεγκτήςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PLC_Tooltip)

        ToolTip1.SetToolTip(Add_gkarazoporta, addNewLine(My.Resources.Garage_Button_Tooltip))
        ΓκαραζόπορταToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Garage_Button_Tooltip)

        ToolTip1.SetToolTip(add_syromenh_porta, addNewLine(My.Resources.Syromenh_Button_Tooltip))
        ΣυρόμενηΠόρταToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Syromenh_Button_Tooltip)

        ToolTip1.SetToolTip(add_water_tank, addNewLine(My.Resources.WaterTank_Button_Tooltip))
        ΔεξαμενήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.WaterTank_Button_Tooltip)

        ToolTip1.SetToolTip(add_tenta, addNewLine(My.Resources.Tenta_Tooltip))
        ΗλεκτροκίνητηΤένταToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Tenta_Tooltip)

        ToolTip1.SetToolTip(add_schuko, addNewLine(My.Resources.PlugAndSocket_Schuko_Tooltip))
        ΠρίζαΣούκοΜεΦιςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PlugAndSocket_Schuko_Tooltip)

        ToolTip1.SetToolTip(add_Socket_3p, addNewLine(My.Resources.PlugAndSocket_Industrial_1ph_tooltip))
        ΤριπολικήμονοφασικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PlugAndSocket_Industrial_1ph_tooltip)

        ToolTip1.SetToolTip(add_socket_4p, addNewLine(My.Resources.PlugAndSocket_Industrial_3ph_4pl_tooltip))
        ΤετραπολικήτριφασικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PlugAndSocket_Industrial_3ph_4pl_tooltip)


        ToolTip1.SetToolTip(add_socket_5p, addNewLine(My.Resources.PlugAndSocket_Industrial_3ph_5pl_tooltip))
        ΠενταπολικήτριφασικήToolStripMenuItem.ToolTipText = addNewLine(My.Resources.PlugAndSocket_Industrial_3ph_5pl_tooltip)

        ToolTip1.SetToolTip(add_kouzina, addNewLine(My.Resources.Appliance_Oven_Tooltip))
        ΗλεκτρικήΚουζίναToolStripMenuItem1.ToolTipText = addNewLine(My.Resources.Appliance_Oven_Tooltip)

        ToolTip1.SetToolTip(add_waterheater, addNewLine(My.Resources.Appliance_WaterHeater_Tooltip))
        ΘερμοσίφωναςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_WaterHeater_Tooltip)

        ToolTip1.SetToolTip(add_washingmachine, addNewLine(My.Resources.Appliance_WashingMachine_Tooltip))
        ΠλυντήριοToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_WashingMachine_Tooltip)

        ToolTip1.SetToolTip(add_dishwasher, addNewLine(My.Resources.Appliance_DishWasher_Tooltip))
        ΠλυντήριοΠιάτωνToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_DishWasher_Tooltip)

        ToolTip1.SetToolTip(add_hood, addNewLine(My.Resources.Appliance_Hood_Tooltip))
        ΕξαεριστήραςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_Hood_Tooltip)

        ToolTip1.SetToolTip(add_refrigerator, addNewLine(My.Resources.Appliance_Refrigerator_Tooltip))
        ΨυγείοToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_Refrigerator_Tooltip)

        ToolTip1.SetToolTip(add_heater_single, addNewLine(My.Resources.Appliance_WaterHeater_Tooltip))
        ΘερμάστραToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_WaterHeater_Tooltip)

        ΦούρνοςΜικροκυμμάτωνToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_Microwave_Tooltip)

        ΣτεγνωτήριοΡούχωνToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_ClothesDryer_Tooltip)

        ΚλιματιστικοToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_AC_Tooltip)

        ΑνεμιστήραςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_CeilingFan_Tooltip)

        ΤηλεόρασηToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Appliance_TV_Tooltip)











        ToolTip1.SetToolTip(ToolBoxShowHide, addNewLine(My.Resources.Info_ShowHideToolbox_ToolTip))
        ΕργαλειοθήκηToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Info_ShowHideToolbox_ToolTip)

        ToolTip1.SetToolTip(Tooltip, addNewLine(My.Resources.Info_ToolTip_ToolTip))

        ToolTip1.SetToolTip(SelectDefaultColor, addNewLine(My.Resources.Info_SelectDefaultColor_Tooltip))

        ToolTip1.SetToolTip(HScrollBar1, addNewLine(My.Resources.Info_ZoomLevelEdit_ToolTip))
        ZoomToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Info_ZoomLevelEdit_ToolTip)

        ToolTip1.SetToolTip(DrawNodes, addNewLine(My.Resources.Info_ShowHideNodes_ToolTip))
        ΣημείαΜετακίνησηςΑγωγώνToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Info_ShowHideNodes_ToolTip)

        ToolTip1.SetToolTip(AutoColor, addNewLine(My.Resources.Info_AutoColor_ToolTip))

        ToolTip1.SetToolTip(Snaptogrid, addNewLine(My.Resources.Info_SnapToGrid_ToolTip))
        ΣυγκράτησηΣτοΠλέγμαToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Info_SnapToGrid_ToolTip)

        ToolTip1.SetToolTip(SnapToWire, addNewLine(My.Resources.Info_SnapToObject_Tooltip))
        ΣυγκράτησηΣταΑντικείμεναToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Info_SnapToObject_Tooltip)

        ToolTip1.SetToolTip(selectedcolor2, addNewLine(My.Resources.Info_SelectedWireColor_ToolTip))

        ΔημιουργίαΝέουΚυκλώματοςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_New_ToolTip)
        ΑνάγνωσηΑποθηκευμένουΚυκλώματοςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_Open_ToolTip)
        ΑποθήκευσηΚυκλώματοςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_Save_ToolTip)

        ΑποθήκευσηBMPToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_SaveImage_Tooltip)
        ΕκτύπωσηΕικόναςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_Print_ToolTip)
        ΈξοδοςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_Exit_Tooltip)

        ΠροσομοίωσηToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_Simulator_Tooltip)

        ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_ShowShortUserName_ToolTip)
        ΠροβολήΣυμβόλωνToolStripMenuItem.ToolTipText = addNewLine(My.Resources.Menu_ShowSymbols_Tooltip)


        'Dim arg() As String = My.Application.CommandLineArgs.ToArray
        refreshFilename()
        wirecolors = {Color.Black, Color.Gray, Color.Brown, Color.Blue, Color.YellowGreen, Color.Purple, Color.Red}
        'selectedcolor2.BackColor = Color.Black
        clickx = -1
        clicky = -1
        clicked = False
        activeObject = Nothing
        lastRatioValue = (HScrollBar1.Value)
        areWeCurrentlyMovingNodes = False



        Dim v As String
        If ApplicationDeployment.IsNetworkDeployed Then
            v = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Else
            v = Application.ProductVersion.ToString
        End If
        Tooltip.Text = programName + " " + v + vbNewLine + "Ιστοσελίδα εφαρμογής: https://csmyrlog.sites.sch.gr/lab/index.html" + vbNewLine + "Προγραμματιστής: Σμυρλόγλου Χρήστος - csmyrlog@sch.gr"

        If Not My.Settings.DoNotShowSplashScreen Then
            Me.Enabled = False
            Me.SendToBack()
            SplashScreen.onView()
        End If


        '-----------------------------------------------------------------------------------------------------------------------------
        'Αυτόματο άνοιγμα αρχείου με δεδομένα commandline arguments
        'Αν έχει κληθεί η εφαρμογή με commandline arguments

        'If My.Application.CommandLineArgs(0) <> "" Then MsgBox(My.Application.CommandLineArgs())
        On Error Resume Next

        If My.Application.CommandLineArgs.Count > 0 Then
            If My.Application.CommandLineArgs(0).ToString <> "" And My.Application.CommandLineArgs(0).ToString.ToUpper.EndsWith(".CIR") Then
                'MsgBox(My.Application.CommandLineArgs(0).ToString)
                openfile(My.Application.CommandLineArgs(0).ToString)
            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------


    End Sub







    Private Sub changezoomlevel()
        Dim i As Integer
        ' If currentActiveObject = -1 Then Exit Sub
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).ratio = HScrollBar1.Value
            allActiveObjects(i).Width = allActiveObjects(i).Image.Width \ allActiveObjects(i).ratio
            allActiveObjects(i).Height = allActiveObjects(i).Image.Height \ allActiveObjects(i).ratio
            allActiveObjects(i).Location = New Point(allActiveObjects(i).Location.X * (lastRatioValue / HScrollBar1.Value), allActiveObjects(i).Location.Y * (lastRatioValue / HScrollBar1.Value))
        Next
        Me.Refresh()
        'deleteme.changeRatio(lastRatioValue, HScrollBar1.Value)
        wires.changeAllWireRatios(lastRatioValue)
        wires.drawAllWires()
        refresh_all_activeobjects()

        lastRatioValue = HScrollBar1.Value

    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)
        changezoomlevel()
    End Sub



    Private Sub ActiveImage_DragEnter(sender As Object, e As DragEventArgs)

    End Sub

    'Εργασίες ελέγχου για το αν έχει γίνει κλικ επάνω σε κάποιο node
    Sub NodeChecking_For_Mousedown(WhichWire As Integer, x As Integer, y As Integer, ByRef ClickedOn As Boolean)
        Dim previousselectednode As Integer
        On Error Resume Next
        'Σημειώνω το επιλεγμένο Selected Node του συγκεκριμένου αγωγού (απο πρίν)
        previousselectednode = wires.allWires(WhichWire).getSelectedNode
        'Τρέχω τον έλεγχο για το κλικ και τα nodes
        wires.allWires(WhichWire).CheckForClick(x, y, ClickedOn)

        'Αν το node είναι το ίδιο, άρα έχω κάνει κλικ επάνω στο ίδιο node, οπότε αντιστρέφω την επιλογή του node
        If previousselectednode = wires.allWires(WhichWire).getSelectedNode Then wires.allWires(WhichWire).resetSelectedNode()
        'Αν έχω κάνει κλικ επάνω σε κάποιον αγωγό τότε τον σημειώνω ως ενεργό αγωγό
        If ClickedOn Then
            selectedWire = WhichWire
            wires.selectallbut(WhichWire)
        End If
    End Sub

    'Εκκίνηση μετακίνησης των nodes
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim i As Integer
        Dim ClickedOn As Boolean
        Dim skipthefollowing As Boolean



        'Αν δεν έχει πατηθεί το αριστερό κλικ τότε έξοδος
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

        'checkit.Items.Clear()
        'Me.Refresh()

        'Ψάχνουμε αν το node ήταν ήδη επιλεγμένο σε κάποιο wire


        skipthefollowing = False            'Αυτό θα το χρησιμοποιήσουμε για να αποφύγουμε να γίνει έλεγχος στα υπόλοιπα Wires εφόσον ελεγχθεί το επιλεγμένο και βρεθεί ότι το κλικ έγινε επάνω του
        ClickedOn = False
        If selectedWire > -1 Then NodeChecking_For_Mousedown(selectedWire, e.X, e.Y, ClickedOn) 'Αν έχουμε επιλέξει κάποιο Wire τότε γίνεται έλεγχος πρώτα σε αυτό
        If ClickedOn Then skipthefollowing = True Else selectedWire = -1 'Αν ο έλεγχος είναι επιτυχημένος τότε κάνουμε skip τον υπόλοιπο έλεγχο, αλλιώς αποπιλέγουμε το wire


        'Αν δεν ήταν το επιλεγμένο τότε θα γίνει έλεγχος στα υπόλοιπα wires
        If Not skipthefollowing Then


            For i = 0 To numberOfWires

                NodeChecking_For_Mousedown(i, e.X, e.Y, ClickedOn)
                If ClickedOn Then Exit For

                'Σημειώνω το επιλεγμένο Selected Node του συγκεκριμένου αγωγού (απο πρίν)
                '            previousselectednode = wires.allWires(i).getSelectedNode
                'Τρέχω τον έλεγχο για το κλικ και τα nodes
                '            wires.allWires(i).CheckForClick(e.X, e.Y, ClickedOn)

                'Αν το node είναι το ίδιο, άρα έχω κάνει κλικ επάνω στο ίδιο node, οπότε αντιστρέφω την επιλογή του node
                ' If previousselectednode = wires.allWires(i).getSelectedNode Then wires.allWires(i).resetSelectedNode()
                'Αν έχω κάνει κλικ επάνω σε κάποιον αγωγό τότε τον σημειώνω ως ενεργό αγωγό
                ' If ClickedOn Then
                ' selectedWire = i
                ' wires.selectallbut(i)
                ' Exit For
                'End If


            Next
        End If

        'Σχεδίαση όλων των αγωγών
        wires.drawAllWires()

        'deleteme.drawWire(Me, HScrollBar1.Value)
        'checkit.Items.Add(" MouseDown Selected = " + deleteme.GetSelectedStatus.ToString & " Node = " & deleteme.getSelectedNode.ToString)
    End Sub
    'Μετακίνηση nodes
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Tooltip.Text = ""
        Currently_moving_node = False               'Αυτή η μεταβλητή θα χρειαστεί στο mouseup για να ενεργοποιήσουμε το snap to grid. Εδώ ενημερώνουμε ότι δεν έχει γίνει μετακίνηση node

        'Αν δεν έχει πατηθεί το αριστερό κλικ τότε έξοδος

        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        'checkit.Items.Add("In mouseMove SelectedNode=" & deleteme.getSelectedNode.ToString & " Deleteme Selected = " + deleteme.GetSelectedStatus.ToString & " Node = " & deleteme.getSelectedNode.ToString)

        If selectedWire > -1 Then
            If wires.allWires(selectedWire).getSelectedNode > -1 Then
                Currently_moving_node = True        'Εδώ ενημερώνουμε ότι έχει γίνει μετακίνηση node. Αυτή την πληροφορία θα την χρησιμοποιήσει το mouseup
                wires.allWires(selectedWire).moveNode(wires.allWires(selectedWire).getSelectedNode, e.X, e.Y)
                'Me.Refresh()
                wires.drawAllWires()
            End If
            'checkit.Items.Add("MouseMove Selected = " + deleteme.GetSelectedStatus.ToString & " Node = " & deleteme.getSelectedNode.ToString)
        End If

    End Sub

    'Τέλος μετακίνησης των nodes
    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim activekanabos As Integer = kanabos / (HScrollBar1.Value)
        Dim pre, pn, former, latter As Point

        Dim ok, didchangeX, didchangeY As Boolean


        'Κατά την μετακίνηση του node γίνεται snap to grid
        'Αν πιο πριν είχε πατηθεί το αριστερό κουμπι, έγινε μετακίνηση node, και είναι εργοποιημένο το snap to grid

        If (e.Button = Windows.Forms.MouseButtons.Left) And Currently_moving_node Then
            pre = wires.allWires(selectedWire).getNode(wires.allWires(selectedWire).getSelectedNode, ok)
            pn = pre

            If Snaptogrid.Checked Then
                If ok Then
                    pre = pn
                    pn.X = ((pn.X \ activekanabos) + 1) * activekanabos
                    pn.Y = ((pn.Y \ activekanabos) + 1) * activekanabos
                    wires.allWires(selectedWire).moveNode(wires.allWires(selectedWire).getSelectedNode, pn.X, pn.Y)
                End If
            End If


            'Αν τώρα έχουμε ενεργοποιήσει την συγκράτηση στο αντικείμενο
            'Σημειώνουμε αρχικά ότι δεν έχει γίνει αλλαγή στα δεδομένα του Χ και Υ
            didchangeX = False
            didchangeY = False

            If SnapToWire.Checked Then
                'Παιρνουμε τα δεδομένα του προηγούμενου node
                former = wires.allWires(selectedWire).getNode(wires.allWires(selectedWire).getSelectedNode - 1, ok)
                'Αν όλα είναι ΟΚ παίρνουμε και του επόμενου node
                If ok Then
                    latter = wires.allWires(selectedWire).getNode(wires.allWires(selectedWire).getSelectedNode + 1, ok)
                    If ok Then
                        If former.X < pre.X + activekanabos And former.X > pre.X - activekanabos Then pre.X = former.X : didchangeX = True
                        If former.Y < pre.Y + activekanabos And former.Y > pre.Y - activekanabos Then pre.Y = former.Y : didchangeY = True

                        If latter.X < pre.X + activekanabos And latter.X > pre.X - activekanabos Then pre.X = latter.X : didchangeX = True
                        If latter.Y < pre.Y + activekanabos And latter.Y > pre.Y - activekanabos Then pre.Y = latter.Y : didchangeY = True
                        If Not didchangeX Then pre.X = pn.X
                        If Not didchangeY Then pre.Y = pn.Y
                        wires.allWires(selectedWire).moveNode(wires.allWires(selectedWire).getSelectedNode, pre.X, pre.Y)


                    End If
                End If

            End If
            Currently_moving_node = False
            Me.Refresh()
            wires.drawAllWires()
            Exit Sub

        End If


        'Αν έχει γίνει δεξί κλικ
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'Ετοιμάζω το μενού
            Dim nodedelmenu = New ContextMenuStrip
            Dim wiredelmenu = New ContextMenuStrip
            '
            If selectedWire > -1 Then
                nodeToBeDeleted = wires.allWires(selectedWire).getSelectedNode
                If nodeToBeDeleted > -1 Then
                    Dim menu1 = nodedelmenu.Items.Add("Διαγραφή σημείου")
                    menu1.Tag = "delnode"
                    AddHandler menu1.Click, AddressOf deleteSelectedNode
                    nodedelmenu.Show(Me, e.X, e.Y)
                    Exit Sub
                End If
                If nodeToBeDeleted = -1 Then
                    Dim menu1 = wiredelmenu.Items.Add("Διαγραφή αγωγού")
                    menu1.Tag = "delwire"
                    AddHandler menu1.Click, AddressOf deleteSelectedWire
                    wiredelmenu.Show(Me, e.X, e.Y)
                    Exit Sub
                End If



            Else : Exit Sub
            End If

            'deleteme.SetSelectedNode(-1)

        End If
        If selectedWire > -1 Then wires.allWires(selectedWire).moveNode(wires.allWires(selectedWire).getSelectedNode, e.X, e.Y)
        'Me.Refresh()
        'deleteme.resetSelectedNode()
        'SelectedNode = -1
        'deleteme.drawWire(Me, HScrollBar1.Value)
        wires.drawAllWires()

    End Sub
    'Διαγραφή σημείου
    Sub deleteSelectedNode()
        wires.deleteSelectedNode(nodeToBeDeleted)   'Αφαίρεση σημείου
    End Sub
    'Διαγραφή του επιλεγμένου αγωγού
    Sub deleteSelectedWire()
        wires.deleteSelectedWire(selectedWire)

        selectedWire = -1                 'Πλέον δεν είναι τίποτα επιλεγμένο

        Me.Refresh()                            'Ανανέωση ώστε να φανεί η διαγραφή
        wires.drawAllWires()                    'Επανασχεδίαση
    End Sub

    'Διαγραφή στοιχείου (ρελέ)
    Sub DeleteActiveImage()
        Dim i As Integer
        Dim skip As Integer = 0
        Dim intn As Integer
        If numberOfActiveObjects < 0 Then Exit Sub
        ObjectThatWasRightClicked.Visible = False

        wires.deleteAllWiresAssociatedWith(ObjectThatWasRightClicked)                         'Πρώτα γίνεται διαγραφή όλων των αγωγών που σχετίζονται με το συγκεκριμένο ρελ΄΄ε

        'Τώρα αφαιρούμε τυχών μανδάλωση
        If ObjectThatWasRightClicked.InterlockedWith > -1 Then
            intn = ObjectThatWasRightClicked.InterlockedWith
            If allActiveObjects(intn) IsNot Nothing Then allActiveObjects(intn).InterlockedWith = -1 : allActiveObjects(intn).Refresh()
        End If

        If numberOfActiveObjects > 1 Then
            For i = 0 To numberOfActiveObjects - 1
                If allActiveObjects(i) Is ObjectThatWasRightClicked Then skip = 1
                allActiveObjects(i) = allActiveObjects(i + skip)
                If allActiveObjects(i) IsNot Nothing Then allActiveObjects(i).Tag = Trim(i.ToString)
            Next
        End If

        ObjectThatWasRightClicked = Nothing
        numberOfActiveObjects = numberOfActiveObjects - 1
        currentActiveObject = -1
        currentActiveScrew = -1
        activeObject = Nothing
        activeScrewnum = -1
        Me.Refresh()                            'Ανανέωση ώστε να φανεί η διαγραφή
        refresh_all_activeobjects()
        wires.drawAllWires()                    'Επανασχεδίαση
    End Sub


    Public Sub refresh_all_activeobjects()
        Dim i As Integer
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).Refresh()
        Next

    End Sub






    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles add_stop.Click
        Add_Item(4, 0, 0) 'Προσθήκη στοπ
    End Sub

    Private Sub Add_Relay_Click_1(sender As Object, e As EventArgs) Handles Add_Relay.Click

        Add_Item(1, 0, 0)     'Πρόσθεσε ένα ρελέ
    End Sub

    Private Sub Add_thermiko_Click(sender As Object, e As EventArgs) Handles Add_thermiko.Click
        Add_Item(2, 0, 0) 'προσθήκη νέου θερμικού
    End Sub

    Private Sub Add_Start_Click_1(sender As Object, e As EventArgs) Handles Add_Start.Click
        Add_Item(3, 0, 0) 'Προσθήκη σταρτ
    End Sub

    Private Sub Add_StartStop_Click(sender As Object, e As EventArgs) Handles Add_StartStop.Click
        Add_Item(5, 0, 0) 'Προσθήκη startstop
    End Sub


    Private Sub Add_greenLight_Click(sender As Object, e As EventArgs) Handles Add_greenLight.Click
        Add_Item(6, 0, 0) ' Προσθήκη πράσινης ενδεικτικής λυχνίας
    End Sub

    Private Sub Add_redlight_Click(sender As Object, e As EventArgs) Handles Add_redlight.Click
        Add_Item(7, 0, 0) 'Προσθήκη κόκκινης ενδεικτικής λυχνίας
    End Sub

    Private Sub SelectDefaultColor_Click(sender As Object, e As EventArgs) Handles SelectDefaultColor.Click
        ColorDialog1.ShowDialog()
        selectedcolor2.BackColor = ColorDialog1.Color
        'Εάν υπάρχει κάποιο επιλεγμένο Wire τότε αλλαγή χρώματος σε αυτό
        If selectedWire > -1 Then
            wires.allWires(selectedWire).whichColor = New SolidBrush(ColorDialog1.Color)
            wires.drawAllWires()
        End If
    End Sub

    Private Sub Edit_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then HScrollBar1.Value = 1 Else HScrollBar1.Value = 2
        changezoomlevel()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Μετακίνηση του ToolTip στο κάτω μέρος της οθόνης
        Tooltip.Top = Me.Height - Tooltip.Height - 40
        Tooltip.Width = Me.Width - 20
        Tooltip.Left = 2

        ToolBoxShowHide.Left = Me.Width - ToolBoxShowHide.Width - 20

        'Μετακίνηση της εργαλειοθήκης δεξιά
        Exarthmata1.Left = Me.Width - Exarthmata1.Width - 15
        Exarthmata1.Top = 30
        Exarthmata2.Left = Exarthmata1.Left
        Exarthmata2.Top = Exarthmata1.Top
        Exarthmata3.Left = Exarthmata1.Left
        Exarthmata3.Top = Exarthmata1.Top
        Exarthmata4.Left = Exarthmata1.Left
        Exarthmata4.Top = Exarthmata1.Top
        exarthmata5.Left = Exarthmata1.Left
        exarthmata5.Top = Exarthmata1.Top


        'Και των επιλογών από κάτω
        If Exarthmata1.Top + Exarthmata1.Height + SettingsBox.Height > Me.Height - Tooltip.Height - 50 Then
            SettingsBox.Left = Exarthmata1.Left - SettingsBox.Width - 5
            SettingsBox.Top = Exarthmata1.Top
        Else
            SettingsBox.Left = Exarthmata1.Left
            SettingsBox.Top = Exarthmata1.Height + Exarthmata1.Top + 2

        End If

    End Sub

    Private Sub Add_1P_CircuitBreaker_Click(sender As Object, e As EventArgs) Handles Add_1P_CircuitBreaker.Click
        Add_Item(8, 0, 0) 'Προσθήκη μονοπολικής ασφάλειας
    End Sub

    Private Sub Add_3P_CircuitBreaker_Click(sender As Object, e As EventArgs) Handles Add_3P_CircuitBreaker.Click
        Add_Item(9, 0, 0) 'Προσθήκη 3πολικής ασφάλειας

    End Sub

    Private Sub Add_fuse_Click(sender As Object, e As EventArgs)
        Add_Item(10, 0, 0) 'Προσθήκη τηκτής ασφάλειας

    End Sub

    Private Sub Add_Swith_1P_Click(sender As Object, e As EventArgs) Handles Add_Swith_1P.Click
        Add_Item(11, 0, 0) 'Προσθήκη 1Π Διακόπτη
    End Sub

    Private Sub Add_Switch_3P_Click(sender As Object, e As EventArgs) Handles Add_Switch_3P.Click
        Add_Item(12, 0, 0) 'Προσθήκη 3Π Διακόπτη
    End Sub

    Private Sub Add_Supply_FromBelow_Click(sender As Object, e As EventArgs) Handles Add_Supply_FromBelow.Click
        Add_Item(13, 0, 0) 'Προσθήκη παροχής από κάτω

    End Sub

    Private Sub Add_Supply_FromAbove_Click(sender As Object, e As EventArgs) Handles Add_Supply_FromAbove.Click
        Add_Item(14, 0, 0) 'Προσθήκη παροχής από πάνω

    End Sub

    Private Sub Add_Supply_FromLeft_Click(sender As Object, e As EventArgs) Handles Add_Supply_FromLeft.Click
        Add_Item(15, 0, 0) 'Προσθήκη παροχής από αριστερά

    End Sub


    '-----------------------------------------------------------------------------------------------------------------------
    'Αποθήκευση αρχείου κυκλώματος στο δίσκο
    'Έκδοση 2
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")>
    Private Sub savefile(WhichFilename As String, Overwrite As Boolean)
        Dim ps, i As Integer

        Dim information_value As String = ""
        Dim firstobject_value As ActiveImage = Nothing
        Dim secondobject_value As ActiveImage = Nothing
        Dim firstscrew_value As Integer
        Dim secondscrew_value As Integer
        Dim whichColor_value As SolidBrush = Nothing
        Dim SelectedColor_value As SolidBrush = Nothing
        Dim nodecolor_Value As SolidBrush = Nothing
        Dim SelectedNodeColor_value As SolidBrush = Nothing
        Dim isitok As Boolean




        On Error GoTo erroroccured

        Using writer As New System.IO.StreamWriter(WhichFilename, False)
            '1η γραμμή - Πληροφορίες
            writer.WriteLine("Αυτό το αρχείο περιέχει δεδομένα του Εργαστηρίου Κυκλωμάτων Αυτοματισμού. Μην κάνετε αλλαγές στα παρακάτω δεδομένα.")



            '2η γραμμή - πλήθος ρελέ
            writer.WriteLine(numberOfActiveObjects)                         'Πόσα αντικείμενα έχουμε στο συγκεκριμένο κύκλωμα


            'Στη συνέχεια καταγράφονται οι πληροφορίες του κάθε ρελέ
            For ps = 0 To numberOfActiveObjects - 1
                writer.WriteLine(ps)                                        'Αριθμός αντικειμένου
                writer.WriteLine(allActiveObjects(ps).username)            'Το username 
                writer.WriteLine(allActiveObjects(ps).type)                 'Τύπος αντικειμένου
                writer.WriteLine(allActiveObjects(ps).Location.X)           'Θέση Χ
                writer.WriteLine(allActiveObjects(ps).Location.Y)           'Θέση Υ
                writer.WriteLine(allActiveObjects(ps).getTimeDelay)           'Χρόνος

                'Μανδάλωση
                writer.WriteLine(allActiveObjects(ps).InterlockedWith)


                'Ρυθμίσεις - Προστέθηκαν για να μπορούν να χρησιμοποιηθούν από την γκαραζόπορτα
                writer.WriteLine(allActiveObjects(ps).Settings1)
                writer.WriteLine(allActiveObjects(ps).Settings2)
                writer.WriteLine(allActiveObjects(ps).Settings3)
                writer.WriteLine(allActiveObjects(ps).Settings4)
                writer.WriteLine(allActiveObjects(ps).Settings5)
                writer.WriteLine(allActiveObjects(ps).Settings6)
                writer.WriteLine(allActiveObjects(ps).Settings7)
                writer.WriteLine(allActiveObjects(ps).Settings8)
                writer.WriteLine(allActiveObjects(ps).Settings9)
                writer.WriteLine(allActiveObjects(ps).Settings10)


            Next    'αντικείμενο


            'Καταγραφή όλων των αγωγών

            'Τώρα θα γράψουμε το πλήθος των αγωγών.
            writer.WriteLine(numberOfWires)                           'Πλήθος αγωγών στο αντικείμενο

            'Για κάθε αγωγό
            For ps = 0 To numberOfWires
                wires.allWires(ps).return_info_forsaving(firstobject_value, secondobject_value, firstscrew_value, secondscrew_value, whichColor_value)
                writer.WriteLine(ps)                                       'Αριθμός αγωγού

                writer.WriteLine(firstobject_value.Tag)                     'Πρώτο αντικείμενο
                writer.WriteLine(secondobject_value.Tag)                    'Δεύτερο αντικείμενο
                writer.WriteLine(firstscrew_value)                          'Πρώτη βίδα - αριθμός
                writer.WriteLine(secondscrew_value)                         'Δεύτερη βίδα -αριθμός
                writer.WriteLine(whichColor_value.Color.ToArgb)             'Χρώμα
                writer.WriteLine(wires.allWires(ps).get_total_nodes)        'Πλήθος nodes στον αγωγό

                'Για κάθε node κάθε αγωγού

                For i = 0 To wires.allWires(ps).get_total_nodes
                    writer.WriteLine(i)
                    writer.WriteLine(wires.allWires(ps).getNode(i, isitok).X)
                    writer.WriteLine(wires.allWires(ps).getNode(i, isitok).Y)
                Next

            Next

            'Τώρα ξεκινά η αποθήκευση των δεδομένων των PLC
            'Σάρωση όλων των αντικειμένων μέχρι που να βρούμε PLC
            For i = 0 To numberOfActiveObjects - 1
                'Αν είναι PLC

                If allActiveObjects(i).WhatAmI = "PLC" Then allActiveObjects(i).SaveDataToDisk(writer)
            Next



        End Using
        MsgBox("Η αποθήκευση ολοκληρώθηκε με επιτυχία", MsgBoxStyle.OkOnly, "Επιτυχής αποθήκευση")
        ActiveFileName = WhichFilename
        refreshFilename()
        Exit Sub
erroroccured:
        MsgBox("Δυστυχώς εμφανίστηκε σφάλμα κατά τη διάρκεια της αποθήκευσης του κυκλώματος στο δίσκο", MsgBoxStyle.Critical, "Σφάλμα αποθήκευσης")



    End Sub

    Private Sub openfile(filename As String)
        Dim text As String = ""
        Dim ps, i, number, type, x, y, obj1, obj2, scr1, scr2, nodesum, clr, nodenum, interlocknum As Integer
        Dim totalwires As Integer
        Dim username As String
        Dim information_value As String = ""
        Dim firstobject_value As ActiveImage = Nothing
        Dim secondobject_value As ActiveImage = Nothing
        Dim brush_value As SolidBrush = Nothing
        Dim SelectedNodeColor_value As SolidBrush = Nothing
        Dim thecolor As Color
        Dim timesettings As Integer
        Dim isitok As Boolean






        Using reader As New System.IO.StreamReader(filename, False)
            '1η γραμμή - Πληροφορίες
            text = reader.ReadLine()

            '2η γραμμή - πλήθος ρελέ
            number = Integer.Parse(reader.ReadLine())                         'Πόσα αντικείμενα έχουμε στο συγκεκριμένο κύκλωμα

            'Στη συνέχεια καταγράφονται οι πληροφορίες του κάθε ρελέ
            For ps = 0 To number - 1
                Try

                    number = Integer.Parse(reader.ReadLine())                                          'Αριθμός αντικειμένου
                    username = reader.ReadLine()                                                         'Το username
                    type = Integer.Parse(reader.ReadLine())                                            'Τύπος αντικειμένου
                    x = Integer.Parse(reader.ReadLine())                                              'Θέση Χ
                    y = Integer.Parse(reader.ReadLine())                                              'Θέση Υ
                    timesettings = Integer.Parse(reader.ReadLine())

                    interlocknum = Integer.Parse(reader.ReadLine())                                              'Θέση Υ




                    Add_Item(type, x, y)
                    allActiveObjects(ps).username = username
                    allActiveObjects(ps).InterlockedWith = interlocknum
                    allActiveObjects(ps).setTimeDelay(timesettings)


                    allActiveObjects(ps).Settings1 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings2 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings3 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings4 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings5 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings6 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings7 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings8 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings9 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις
                    allActiveObjects(ps).Settings10 = Integer.Parse(reader.ReadLine())                                              'Ρυθμίσεις

                Catch ex As Exception
                    GoTo erroroccured

                End Try

            Next    'αντικείμενο

            For ps = 0 To numberOfActiveObjects - 1
                allActiveObjects(ps).Refresh()
            Next



            'Καταγραφή όλων των αγωγών

            'Τώρα θα γράψουμε το πλήθος των αγωγών.
            totalwires = reader.ReadLine                           'Πλήθος αγωγών στο αντικείμενο

            'Για κάθε αγωγό
            For ps = 0 To totalwires
                Try

                    number = Integer.Parse(reader.ReadLine())                                       'Αριθμός αγωγού
                    obj1 = Integer.Parse(reader.ReadLine())                                         'Πρώτο αντικείμενο
                    obj2 = Integer.Parse(reader.ReadLine())                                         'Δεύτερο αντικείμενο
                    firstobject_value = allActiveObjects(obj1)
                    secondobject_value = allActiveObjects(obj2)

                    scr1 = Integer.Parse(reader.ReadLine())                                         'Πρώτη βίδα - αριθμός
                    scr2 = Integer.Parse(reader.ReadLine())                                         'Δεύτερη βίδα -αριθμός

                    clr = Integer.Parse(reader.ReadLine())                                            'Χρώμα
                    thecolor = Color.FromArgb(clr)
                    brush_value = New SolidBrush(thecolor)

                    nodesum = Integer.Parse(reader.ReadLine())                                     'Πλήθος nodes στον αγωγό
                    numberOfWires = ps
                    wires.allWires(ps) = New Wire
                    wires.allWires(ps).CreateWire(firstobject_value, scr1, secondobject_value, scr2, brush_value, False, isitok)


                    'Για κάθε node κάθε αγωγού
                    'Δεν καταγράφουμε το 0 και το total nodes - 1 γιατί θα οι συντεταγμένες αυτών των ακραίων nodes θα προστεθούν αυτόματα από τα στοιχεία των βιδών.
                    For i = 0 To nodesum
                        nodenum = Integer.Parse(reader.ReadLine())
                        x = Integer.Parse(reader.ReadLine())
                        y = Integer.Parse(reader.ReadLine())
                        If i > 0 And i < nodesum Then wires.allWires(ps).InsertNode(New Point(x, y), nodenum)

                    Next






                Catch ex As Exception
                    GoTo erroroccured
                End Try

            Next
            'Ανάγνωση δεδομένων PLC
            'Τώρα ξεκινά η αποθήκευση των δεδομένων των PLC
            'Σάρωση όλων των αντικειμένων μέχρι που να βρούμε PLC
            For i = 0 To numberOfActiveObjects - 1
                'Αν είναι PLC
                If allActiveObjects(i).WhatAmI = "PLC" Then allActiveObjects(i).ReadDatafromDisk(reader)
            Next

            This_Is_The_First_Time_Drawing = True
            wires.drawAllWires()
            This_Is_The_First_Time_Drawing = False
            ActiveFileName = filename
            refreshFilename()
        End Using


        'Άνοιγμα του συνοδευτικού αρχείου οδηγιών
        'Το συνοδευτικό αρχείο για ένα αρχείο κυκλώματος (πχ circuit.cir) είναι ένα αρχείο pdf με όνομα πχ circuit.cir.pdf
        'Ελέγχουμε αν υπάρχει το αρχείο μέσα στον φάκελο αν υπάρχει ενεργοποιούμε το πλήκτρο

        If CheckIfAdditionalResourceExists(ExtensionsForDocuments) <> "" Then
            AdditionalResourceButtonPDF.Visible = True
        Else
            AdditionalResourceButtonPDF.Visible = False
        End If


        If CheckIfAdditionalResourceExists(ExtensionsForPresentations) <> "" Then
            'Αν υπάρχει ρωτάμε αν ο χειριστής επιθυμεί να το ανοίξει.
            AdditionalResourceButtonPresentation.Visible = True
        Else
            AdditionalResourceButtonPresentation.Visible = False
        End If

        If CheckIfAdditionalResourceExists(ExtensionsForVideo) <> "" Then
            'Αν υπάρχει ρωτάμε αν ο χειριστής επιθυμεί να το ανοίξει.
            AdditionalResourceButtonVideo.Visible = True
        Else
            AdditionalResourceButtonVideo.Visible = False
        End If

      


        Exit Sub
erroroccured:
        MsgBox("Δυστυχώς εμφανίστηκε σφάλμα κατά τη διάρκεια της ανάγνωσης του κυκλώματος.", MsgBoxStyle.Critical, "Σφάλμα ανάγνωσης")
        CreateNewFile()

    End Sub



    'Αποθήκευση ως
    Private Sub savefileAs()

        SaveFileDialog1.Filter = "Αρχεία κυκλωμάτων (*.cir*)|*.cir"
        SaveFileDialog1.DefaultExt = "*.cir"
        SaveFileDialog1.FileName = ActiveFileName
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then



            savefile(SaveFileDialog1.FileName, True)

        End If
    End Sub



    Private Sub ΑποθήκευσηΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑποθήκευσηΚυκλώματοςToolStripMenuItem.Click
        HScrollBar1.Value = 1
        changezoomlevel()
        savefileAs()
    End Sub


    'Διαγραφή όλων των αντικειμένων για τη δημιουργία νέου αρχείου
    Private Sub CreateNewFile()
        Dim i As Integer
        For i = numberOfActiveObjects - 1 To 0 Step -1
            ObjectThatWasRightClicked = allActiveObjects(i)
            DeleteActiveImage()
        Next
        HScrollBar1.Value = HScrollBar1.Minimum         'Επαναφορά του Zoom στο κανονικό
        ActiveFileName = "Ανώνυμο.Cir"
        refreshFilename()
        AdditionalResourceButtonPDF.Visible = False
        AdditionalResourceButtonPresentation.Visible = False
        AdditionalResourceButtonVideo.Visible = False
    End Sub

    Private Sub PreparetoCreateNewFile(Prompt As String, title As String, ByRef goon As Boolean)
        'Dim goon As Boolean = False
        goon = False
        HScrollBar1.Value = 1
        changezoomlevel()
        'Εάν το κύκλωμα περιέχει δεδομένα τότε
        If numberOfActiveObjects > 0 Then
            If MsgBox(Prompt, MsgBoxStyle.YesNo, title) = MsgBoxResult.Yes Then goon = True
        Else : goon = True
        End If
        If goon Then CreateNewFile()

    End Sub

    Private Sub ΔημιουργίαΝέουΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔημιουργίαΝέουΚυκλώματοςToolStripMenuItem.Click
        Dim ok As Boolean
        HScrollBar1.Value = 1
        changezoomlevel()
        PreparetoCreateNewFile("Είστε σίγουρος ότι θέλετε να δημιουργήσετε ένα νέο κύκλωμα;" & vbNewLine & "Το τρέχων κύκλωμα θα διαγραφεί.", "Δημιουργία νέου κυκλώματος", ok)
    End Sub

    Private Sub ΑνάγνωσηΑποθηκευμένουΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑνάγνωσηΑποθηκευμένουΚυκλώματοςToolStripMenuItem.Click
        Dim ok As Boolean


        PreparetoCreateNewFile("Είστε σίγουρος ότι θέλετε να προχωρήσετε στην ανάγνωση ενός αποθηκευμένου κυκλώματος;" & vbNewLine & "Το τρέχων κύκλωμα θα διαγραφεί.", "Ανάγνωση κυκλώματος", ok)
        If ok Then
            OpenFileDialog1.Filter = "Αρχεία κυκλωμάτων (*.cir*)|*.cir"
            OpenFileDialog1.DefaultExt = "*.cir"
            OpenFileDialog1.FileName = ActiveFileName
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                openfile(OpenFileDialog1.FileName)

            End If
        End If
        refresh_all_activeobjects()
    End Sub


    Private Sub HScrollBar1_Scroll_1(sender As Object, e As ScrollEventArgs)
        changezoomlevel()
    End Sub

    Private Sub add_motor_Click(sender As Object, e As EventArgs) Handles add_motor.Click
        Add_Item(16, 0, 0)
    End Sub

    Private Sub add_motorY_Click(sender As Object, e As EventArgs) Handles add_motorY.Click
        Add_Item(17, 0, 0)
    End Sub

    Private Sub add_motord_Click(sender As Object, e As EventArgs) Handles add_motord.Click
        Add_Item(18, 0, 0)
    End Sub



    'Αποθήκευση ρυθμίσεων κατά την έξοδο
    Private Sub Save_Settings_On_Exit()
        'MsgBox("Saving :" + vbNewLine + "autocolor = " + AutoColor.Checked.ToString + vbNewLine + "No Splash=" + (Not ShowSplashScreenMenu.Checked).ToString)
        My.Settings.AutoColor = AutoColor.Checked
        My.Settings.DoNotShowSplashScreen = Not ShowSplashScreenMenu.Checked
        My.Settings.DrawNodes = DrawNodes.Checked
        My.Settings.SnapToGrid = Snaptogrid.Checked
        My.Settings.SnapToWire = SnapToWire.Checked
        My.Settings.WireColor = selectedcolor2.BackColor
        My.Settings.ShowSymbolsOnEdit = ΠροβολήΣυμβόλωνToolStripMenuItem.Checked
        My.Settings.ShowInfoOnEdit = ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.Checked

        My.Settings.Simulator_ShowVoltage = Watch.Show_Voltage.Checked
        My.Settings.Simulator_ShowInfo = Watch.showinfo.Checked
        My.Settings.Simulator_ShowKeys = Watch.showkeys.Checked
        My.Settings.Simulator_ShowSymbols = SimulationSymbols
        My.Settings.Simulator_TimerTick = Simulator.Timer1.Interval
        My.Settings.Simulator_SoundOn = soundon
        My.Settings.AutoAddNodes = Auto_Add_Nodes.Checked
        My.Settings.Save()
    End Sub

    Private Sub ΈξοδοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΈξοδοςToolStripMenuItem.Click
        If numberOfActiveObjects <= 0 Then Save_Settings_On_Exit() : Application.Exit()
        If MsgBox("Είστε σίγουρος ότι θέλετε να πραγματοποιήσετε έξοδο από το πρόγραμμα;" + vbNewLine + "Αν δεν έχετε αποθηκεύσει το κύκλωμα τότε αυτό θα χαθεί.", MsgBoxStyle.YesNoCancel, "Έξοδος") = MsgBoxResult.Yes Then Save_Settings_On_Exit() : Application.Exit()

    End Sub
    Sub toolboxclick()
        If SettingsBox.Visible = False Then Exarthmata1.Visible = True : SettingsBox.Visible = Not SettingsBox.Visible : ΕργαλειοθήκηToolStripMenuItem.Checked = Exarthmata1.Visible : Exit Sub
        If Exarthmata1.Visible = True Then Exarthmata1.Visible = False : Exarthmata2.Visible = True : Exit Sub
        If Exarthmata2.Visible = True Then Exarthmata2.Visible = False : Exarthmata3.Visible = True : Exit Sub
        If Exarthmata3.Visible = True Then Exarthmata3.Visible = False : Exarthmata4.Visible = True : Exit Sub
        If Exarthmata4.Visible = True Then Exarthmata4.Visible = False : exarthmata5.Visible = True : Exit Sub
        If exarthmata5.Visible = True Then exarthmata5.Visible = False : SettingsBox.Visible = Not SettingsBox.Visible : ΕργαλειοθήκηToolStripMenuItem.Checked = Exarthmata1.Visible : Exit Sub

    End Sub
    Private Sub ΕργαλειοθήκηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕργαλειοθήκηToolStripMenuItem.Click
        toolboxclick()
    End Sub

    Private Sub ClickZoomLevelMenu()
        If HScrollBar1.Value = HScrollBar1.Minimum Then HScrollBar1.Value = HScrollBar1.Maximum Else HScrollBar1.Value = HScrollBar1.Minimum
        changezoomlevel()

    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click
        ClickZoomLevelMenu()
    End Sub




    Private Sub ΤήξεωςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(10, 0, 0) 'Προσθήκη τηκτής ασφάλειας

    End Sub

    Private Sub asfalia1paytomath_Click(sender As Object, e As EventArgs) Handles asfalia1paytomath.Click
        Add_Item(8, 0, 0) 'Προσθήκη μονοπολικής ασφάλειας

    End Sub

    Private Sub asfaleia3paytomath_Click(sender As Object, e As EventArgs) Handles asfaleia3paytomath.Click
        Add_Item(9, 0, 0) 'Προσθήκη 3πολικής ασφάλειας

    End Sub

    Private Sub ΗλέκτρονόμοςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(1, 0, 0)     'Πρόσθεσε ένα ρελέ

    End Sub

    Private Sub ΘερμικόToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΘερμικόToolStripMenuItem.Click
        Add_Item(2, 0, 0) 'προσθήκη νέου θερμικού

    End Sub

    Private Sub ΣτάρτStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣτάρτStartToolStripMenuItem.Click
        Add_Item(3, 0, 0) 'Προσθήκη σταρτ

    End Sub

    Private Sub ΣτοπToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣτοπToolStripMenuItem.Click
        Add_Item(4, 0, 0) 'Προσθήκη σταρτ

    End Sub

    Private Sub ΣταρτΣτόπStartStopNONCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣταρτΣτόπStartStopNONCToolStripMenuItem.Click
        Add_Item(5, 0, 0) 'Προσθήκη σταρτ

    End Sub

    Private Sub ΠράσινηToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(6, 0, 0) ' Προσθήκη πράσινης ενδεικτικής λυχνίας

    End Sub

    Private Sub ΚόκκινηToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(7, 0, 0) ' Προσθήκη πράσινης ενδεικτικής λυχνίας

    End Sub

    Private Sub paroxh_panw_Click(sender As Object, e As EventArgs) Handles paroxh_panw.Click
        Add_Item(14, 0, 0) 'Προσθήκη παροχής από πάνω

    End Sub

    Private Sub paroxh_katw_Click(sender As Object, e As EventArgs) Handles paroxh_katw.Click
        Add_Item(13, 0, 0) 'Προσθήκη παροχής από κάτω

    End Sub

    Private Sub paroxh_dejia_Click(sender As Object, e As EventArgs) Handles paroxh_dejia.Click
        Add_Item(15, 0, 0) 'Προσθήκη παροχής από αριστερά

    End Sub

    Private Sub ΧωρίςΣυνδεσμολογίαToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΧωρίςΣυνδεσμολογίαToolStripMenuItem.Click
        Add_Item(16, 0, 0)

    End Sub

    Private Sub ΣεΣυνδεσμολογίαΑστέραΥToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣεΣυνδεσμολογίαΑστέραΥToolStripMenuItem.Click
        Add_Item(17, 0, 0)

    End Sub

    Private Sub ΣεΣυνδεσμολογίαΤριγώνουΔToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣεΣυνδεσμολογίαΤριγώνουΔToolStripMenuItem.Click
        Add_Item(18, 0, 0)

    End Sub

    Private Sub DrawNodes_CheckedChanged(sender As Object, e As EventArgs) Handles DrawNodes.CheckedChanged
        If Not Me.Visible Then Exit Sub
        wires.drawnodes = DrawNodes.Checked

        Me.Refresh()
        wires.drawAllWires()
    End Sub

    Private Sub ΣημείαΜετακίνησηςΑγωγώνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣημείαΜετακίνησηςΑγωγώνToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        DrawNodes.Checked = Not DrawNodes.Checked
        ΣημείαΜετακίνησηςΑγωγώνToolStripMenuItem.Checked = DrawNodes.Checked
    End Sub

    Private Sub ΑρχείοToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑρχείοToolStripMenuItem.Click

    End Sub

    Private Sub add_Connector_Click(sender As Object, e As EventArgs) Handles add_Connector.Click
        Add_Item(19, 0, 0)
    End Sub


    Private Sub ΣυγκράτησηΣτοΠλέγμαToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣυγκράτησηΣτοΠλέγμαToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        Snaptogrid.Checked = Not Snaptogrid.Checked
        ΣυγκράτησηΣτοΠλέγμαToolStripMenuItem.Checked = Snaptogrid.Checked
    End Sub

    Private Sub ΣυγκράτησηΣταΑντικείμεναToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣυγκράτησηΣταΑντικείμεναToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        SnapToWire.Checked = Not SnapToWire.Checked
        ΣυγκράτησηΣταΑντικείμεναToolStripMenuItem.Checked = SnapToWire.Checked
    End Sub

    Private Sub Add_DelayOn_Click(sender As Object, e As EventArgs) Handles Add_DelayOn.Click
        Add_Item(20, 0, 0)

    End Sub

    Private Sub Add_Delay_Off_Click(sender As Object, e As EventArgs) Handles Add_Delay_Off.Click
        Add_Item(21, 0, 0)

    End Sub

    Private Sub DelayOnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DelayOnToolStripMenuItem.Click
        Add_Item(20, 0, 0)

    End Sub

    Private Sub DelayOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DelayOffToolStripMenuItem.Click
        Add_Item(21, 0, 0)

    End Sub

    Private Sub ΠροσομοίωσηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠροσομοίωσηToolStripMenuItem.Click
        Dim s As New ScrollEventArgs(ScrollEventType.EndScroll, 2)

        Me.Enabled = False

        'Λόγω ενός bug θα πρέπει πάντα να είναι ενεργό το show code name όταν μπαίνουμε στο simulator
        'Αν είναι ανενεργό τότε δεν καλείται η drawanythingextra του Activeimage. 
        'Είναι bug και θα πρέπει να διορθωθεί, αλλά, στο μέλλον :)
        If Not drawUsernameDuringEdit Then
            changeShowCodeName()
        End If

        'Επαναφέρω το επίπεδο Zoom στο κανονικό
        HScrollBar1.Value = 1
        'Καλώ το sub του Scrollbar για να εκτελέσει τις απαραίτητες ενέργειες ωστε να προβληθεί σωστά το κύκλωμα
        HScrollBar1_Scroll_1(New Object, s)
        'wires.drawAllWires()

        Simulator.Show()
        Simulator.BringToFront()
        Simulator.reset_all()
        Simulator.draw_everything()

    End Sub

    Private Sub Add_Terminal_Switch_Click(sender As Object, e As EventArgs) Handles Add_Terminal_Switch.Click
        Add_Item(22, 0, 0)
    End Sub

    Private Sub Add_Photo_Switch_Click(sender As Object, e As EventArgs) Handles Add_Photo_Switch.Click
        Add_Item(23, 0, 0)
    End Sub



    Private Sub add_1phMotor_Click(sender As Object, e As EventArgs) Handles add_1phMotor.Click
        Add_Item(24, 0, 0)

    End Sub

    Private Sub ΜονοφασικόςΚινητήραςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜονοφασικόςΚινητήραςToolStripMenuItem.Click
        Add_Item(24, 0, 0)

    End Sub


    Private Sub Add_Relay2NO2NC_Click(sender As Object, e As EventArgs) Handles Add_Relay2NO2NC.Click
        Add_Item(25, 0, 0)
    End Sub

    Private Sub Add_lamp_Click(sender As Object, e As EventArgs) Handles Add_lamp.Click
        Add_Item(26, 0, 0)
    End Sub

    Private Sub ΛαμπτήραςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(26, 0, 0)
    End Sub

    Private Sub ΗλεκτρονόμοςΜεΠολλέςΕπαφέςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(25, 0, 0)

    End Sub

    Private Sub ToolBoxShowHide_Click(sender As Object, e As EventArgs) Handles ToolBoxShowHide.Click
        toolboxclick()
    End Sub


    Private Sub prepareimage(ByRef img As Image, UseCircuitSymbols As Boolean)
        Dim minx As Integer = 0, miny As Integer = 0, maxx As Integer = 0, maxy As Integer = 0
        'Dim minx As Integer = Width, miny As Integer = Height, maxx As Integer = 0, maxy As Integer = 0
        Dim obj As ActiveImage
        Dim txt As String = ""
        Dim pre_showinfo As Boolean = show_info_during_simulation
        Dim pre_showkeys As Boolean = show_keys_during_simulation

        'Βρίσκω πρώτα τα ελάχιστα και μέγιστα της εικόνας

        HScrollBar1.Value = 1
        changezoomlevel()

        show_info_during_simulation = True
        show_keys_during_simulation = False

        For i = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(i)
            If obj.Location.X < minx Then minx = obj.Location.X
            If obj.Location.Y < miny Then miny = obj.Location.Y
            If obj.Location.Y + obj.Height > maxy Then maxy = obj.Location.Y + obj.Height
            If obj.Location.X + obj.Width > maxx Then maxx = obj.Location.X + obj.Width
        Next

        wires.findMINMAXinAllWires(minx, miny, maxx, maxy)

        img = New Bitmap(maxx + 60, maxy + 80 + 14 * numberOfActiveObjects)
        Dim g As Graphics = Graphics.FromImage(img)
        Dim r As New System.Drawing.Rectangle(New Point(minx, miny), New Size(maxx - minx + 70, maxy - miny + 80 + 14 * numberOfActiveObjects))

        g.DrawRectangle(New Pen(Brushes.White), r)
        g.FillRectangle(New SolidBrush(Color.White), r)
        g.DrawString(programName, New Font("Arial", 10), Brushes.Blue, New Point(1, maxy))
        g.DrawString(ActiveFileName, New Font("Arial", 10), Brushes.Black, New Point(1, maxy + 17))
        g.DrawString(Date.Today.ToShortDateString + " / " + TimeOfDay.ToShortTimeString, New Font("Arial", 10), Brushes.Black, New Point(1, maxy + 34))

        g.DrawString("Ανάλυση εξαρτημάτων κυκλώματος", New Font("Arial", 10), Brushes.Black, New Point(1, maxy + 55))

        For i = 0 To numberOfActiveObjects - 1
            txt = "#" + allActiveObjects(i).Tag + ": " + allActiveObjects(i).username + " - " + allActiveObjects(i).WhatAmIGreek
            If allActiveObjects(i).InterlockedWith > -1 Then txt = txt + ". Σε μηχανική μανδάλωση με " + allActiveObjects(i).InterlockedWith.ToString + ": " + allActiveObjects(allActiveObjects(i).InterlockedWith).WhatAmIGreek + " " + allActiveObjects(allActiveObjects(i).InterlockedWith).username
            If allActiveObjects(i).HasTimeSettings Then txt = txt + ". Χρόνος ενεργοποίησης " + allActiveObjects(i).getTimeDelay.ToString + " κύκλοι."
            If UseCircuitSymbols Then allActiveObjects(i).prepare_For_Circuit_Printing()
            allActiveObjects(i).DrawImageforBMP(Me, img, ratiovalue, i)
            If UseCircuitSymbols Then allActiveObjects(i).Restore_Image_After_Circuit_Printing()
            g.DrawString(txt, New Font("Arial", 10), Brushes.Black, New Point(1, maxy + 72 + 14 * i))

        Next

        If UseCircuitSymbols Then wires.drawallwires_for_bmp(Me, img, ratiovalue, True, 1) Else wires.drawallwires_for_bmp(Me, img, ratiovalue, False, 6)

        show_info_during_simulation = pre_showinfo
        show_keys_during_simulation = pre_showkeys

    End Sub





    Private Sub saveimage(img As Image)


        SaveFileDialog1.Filter = "Αρχεία εικόνας Jpeg (*.jpg)|*.jpg|Αρχεία εικόνας Bmp (*.bmp)|*.bmp|Αρχεία εικόνας Png (*.png)|*.png|Αρχεία εικόνας Gif(*.gif)|*.gif|Αρχεία εικόνας Tiff (*.tiff)|*.tiff"

        SaveFileDialog1.DefaultExt = "*.jpg"
        SaveFileDialog1.FileName = ActiveFileName + ".jpg"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Select Case SaveFileDialog1.FileName.Substring(Len(SaveFileDialog1.FileName) - 4, 4).ToUpper
                    Case ".JPG"
                        img.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Case ".BMP"
                        img.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                    Case ".PNG"
                        img.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    Case ".GIF"
                        img.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif)
                    Case "TIFF"
                        img.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Tiff)
                    Case Else
                        MsgBox("Η αποθήκευση δεν θα γίνει." + vbNewLine + "Επιτρεπόμενες επεκτάσεις αρχείων εικόνας jpg, bmp, png, gif, tiff", vbOKOnly, "Λάθος όνομα αρχείου")
                End Select
            Catch ex As Exception
                MsgBox("Παρουσιάστηκε σφάλμα κατά την διαδικασία της αποθήκευσης", MsgBoxStyle.OkOnly, "Σφάλμα αποθήκευσης")
            End Try


        End If

        refresh_all_activeobjects()


    End Sub


    Private Sub ΑποθήκευσηBMPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑποθήκευσηBMPToolStripMenuItem.Click
        Dim i As Image = Nothing
        prepareimage(i, False)
        saveimage(i)
    End Sub
    Private Sub printimage()
        'Dim img As Image = Nothing
        'prepareimage(img)
        PrintDocument1.Print()

    End Sub
    Private Sub ΕκτύπωσηΕικόναςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕκτύπωσηΕικόναςToolStripMenuItem.Click

        printimage()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim g As Graphics = e.Graphics
        Dim img As Image = Nothing
        prepareimage(img, False)
        g.DrawImage(img, 0, 0)

    End Sub

    Private Sub add_buzzer_Click(sender As Object, e As EventArgs) Handles add_buzzer.Click
        Add_Item(27, 0, 0)
    End Sub

    Private Sub Add_siren_Click(sender As Object, e As EventArgs) Handles Add_siren.Click
        Add_Item(28, 0, 0)

    End Sub

    Private Sub ΒομβητήςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(27, 0, 0)

    End Sub

    Private Sub ΣειρήναToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(28, 0, 0)

    End Sub

    'Ορισμός χρόνου ενεργοποίησης για χρονικά (από δεξί κλικ)
    Private Sub settime()
        Dim resp As String
        Dim rint As Integer
        resp = InputBox("Πληκτρολογήστε τον αριθμό των κύκλων που επιθυμείται να καθυστερεί το συγκεκριμένο χρονικό ρελέ.", "Ρύθμιση καθυστέρησης χρονικού.", ObjectThatWasRightClicked.getTimeDelay.ToString)
        If resp = "" Then Exit Sub
        Try
            rint = Integer.Parse(resp)
            ObjectThatWasRightClicked.setTimeDelay(rint)
            ObjectThatWasRightClicked.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub add_3phInicator_Click(sender As Object, e As EventArgs) Handles add_3phInicator.Click
        Add_Item(29, 0, 0)

    End Sub

    Private Sub ΤριφασικήToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(29, 0, 0)

    End Sub

    Private Sub changeShowCodeName()
        If Not Me.Visible Then Exit Sub
        drawUsernameDuringEdit = Not drawUsernameDuringEdit
        ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.Checked = drawUsernameDuringEdit
        refresh_all_activeobjects()

    End Sub
    'Όταν γίνεται κλικ επάνω στο "ΕμφάνισηΚωδικήςΟνομάσιας" κάνει τις απαραίτητες αλλαγές ώστε να γίνεται ή να μην γίνεται προβολή της κωδικής ονομασίας κατά την επεξεργασία.
    Private Sub ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕμφάνισηΚωδικήςΟνομάσιαςToolStripMenuItem.Click
        changeShowCodeName()
    End Sub


    'Όταν επιλέξουμε να αλλάξει η προβολή των εικόνων από κανονική σε προβολή συμβόλων καλούμε αυτό το sub για να ανανεώσει όλες τις εικόνες όλων των αντικειμένων
    Public Sub changeAllImages()
        Dim i As Integer
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).nameImage()
        Next
    End Sub

    Private Sub UseSymbolsOnEdit(YesOrNo As Boolean)
        useStandardSymbolsDuringEdit = YesOrNo
        ΠροβολήΣυμβόλωνToolStripMenuItem.Checked = useStandardSymbolsDuringEdit
        changeAllImages()
        refresh_all_activeobjects()
    End Sub


    Private Sub ΠροβολήΣυμβόλωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠροβολήΣυμβόλωνToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        UseSymbolsOnEdit(Not useStandardSymbolsDuringEdit)
    End Sub


    Private Sub Exarthmata_Enter(sender As Object, e As EventArgs) Handles Exarthmata1.Enter

    End Sub

    Private Sub ΕκκίνησηΤηςΕφαρμογήςToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub ΕισαγωγήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕισαγωγήToolStripMenuItem.Click
        Process.Start("https://youtu.be/VbEp8KErdAs")

    End Sub

    Private Sub ΥλοποίησηΑπλούΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΥλοποίησηΑπλούΚυκλώματοςToolStripMenuItem.Click
        Process.Start("https://youtu.be/dk6HM9FbcNw")

    End Sub

    Private Sub ΥλοποίησηΣύνθετουΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΥλοποίησηΣύνθετουΚυκλώματοςToolStripMenuItem.Click
        Process.Start("https://youtu.be/clsrM1Ezx-Y")

    End Sub

    Private Sub ΕπιλογέςΗλεκτρονόμωνΚαιΧρονικώνΗλεκτρονόμωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕπιλογέςΗλεκτρονόμωνΚαιΧρονικώνΗλεκτρονόμωνToolStripMenuItem.Click
        Process.Start("https://youtu.be/H8kK3xT1f-s")


    End Sub


    Private Sub Add_DDE_Click(sender As Object, e As EventArgs) Handles Add_DDE.Click
        Add_Item(30, 0, 0)
    End Sub


    Private Sub DDE1_Click(sender As Object, e As EventArgs) Handles add_DDE1.Click
        Add_Item(31, 0, 0)

    End Sub

    Private Sub ΤριφασικόΡελέΔιαρροήςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(30, 0, 0)
    End Sub

    Private Sub ΜονοφασικόΡελέΔιαρροήςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(31, 0, 0)
    End Sub



    Private Sub add_thermomagnetic_Click(sender As Object, e As EventArgs) Handles add_thermomagnetic.Click
        Add_Item(32, 0, 0)
    End Sub

    Private Sub ΘερμομαγνητικόςΔιακόπτηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΘερμομαγνητικόςΔιακόπτηςToolStripMenuItem.Click
        Add_Item(32, 0, 0)

    End Sub

    Private Sub add_fuse1p_Click(sender As Object, e As EventArgs) Handles add_fuse1p.Click
        Add_Item(33, 0, 0)

    End Sub

    Private Sub add_fuse3p_Click(sender As Object, e As EventArgs) Handles add_fuse3p.Click
        Add_Item(34, 0, 0)

    End Sub

    Private Sub ΜονοπολικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜονοπολικήToolStripMenuItem.Click
        Add_Item(33, 0, 0)
    End Sub

    Private Sub ΤριπολικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤριπολικήToolStripMenuItem.Click
        Add_Item(34, 0, 0)
    End Sub


    Private Sub add_mpara_geiwshs_Click(sender As Object, e As EventArgs) Handles add_mpara_geiwshs.Click
        Add_Item(35, 0, 0)

    End Sub

    Private Sub ΜπάραΓείωσηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜπάραΓείωσηςToolStripMenuItem.Click
        Add_Item(35, 0, 0)

    End Sub

    Private Sub ΚλέμαΠίνακαToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΚλέμαΠίνακαToolStripMenuItem.Click
        Add_Item(19, 0, 0)
    End Sub

    Private Sub add_mpara_oudeterou_Click(sender As Object, e As EventArgs) Handles add_mpara_oudeterou.Click
        Add_Item(36, 0, 0)

    End Sub

    Private Sub Add_SingleLightSwitch_Click(sender As Object, e As EventArgs) Handles Add_SingleLightSwitch.Click
        Add_Item(37, 0, 0)

    End Sub

    Private Sub Add_LightSwitchALE_Click(sender As Object, e As EventArgs) Handles Add_LightSwitchALE.Click
        Add_Item(38, 0, 0)

    End Sub

    Private Sub Add_LightSwitchMES_Click(sender As Object, e As EventArgs) Handles Add_LightSwitchMES.Click
        Add_Item(39, 0, 0)

    End Sub

    Private Sub ΑπλόςΔιακόπτηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑπλόςΔιακόπτηςToolStripMenuItem.Click
        Add_Item(37, 0, 0)

    End Sub

    Private Sub ΑλέΡετούρToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑλέΡετούρToolStripMenuItem.Click
        Add_Item(38, 0, 0)

    End Sub

    Private Sub ΜεσαίοςΔιακόπτηςΑλέΡετούρToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜεσαίοςΔιακόπτηςΑλέΡετούρToolStripMenuItem.Click
        Add_Item(39, 0, 0)


    End Sub


    Private Sub Add_LightSwitchCOM_Click(sender As Object, e As EventArgs) Handles Add_LightSwitchCOM.Click
        Add_Item(40, 0, 0)
    End Sub

    Private Sub ΔιακόπτηςΚομιτατέρToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιακόπτηςΚομιτατέρToolStripMenuItem.Click
        Add_Item(40, 0, 0)
    End Sub




    Private Sub Add_ΡελέΡάγας_Click(sender As Object, e As EventArgs) Handles Add_ΡελέΡάγας.Click
        Add_Item(41, 0, 0)

    End Sub

    Private Sub add_rele_kastanias_Click(sender As Object, e As EventArgs) Handles add_rele_kastanias.Click
        Add_Item(42, 0, 0)

    End Sub

    Private Sub ΡελέΚαστάνιαςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΡελέΚαστάνιαςToolStripMenuItem.Click
        Add_Item(42, 0, 0)

    End Sub


    Private Sub ΗλεκτρικόςΘερμοσίφωναςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(44, 0, 0)
    End Sub

    Private Sub ΣχετικάΜεToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣχετικάΜεToolStripMenuItem.Click
        About.Show()

    End Sub

    Private Sub ΠλυντήριοToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠλυντήριοToolStripMenuItem.Click
        Add_Item(43, 0, 0)
    End Sub

    Private Sub ΘερμοσίφωναςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΘερμοσίφωναςToolStripMenuItem.Click
        Add_Item(44, 0, 0)

    End Sub

    Private Sub ADDPLC_Click(sender As Object, e As EventArgs) Handles ADDPLC.Click
        Add_Item(45, 0, 0)
    End Sub

    Private Sub ΠρογραμματιζόμενοςΛογικόςΕλεγκτήςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠρογραμματιζόμενοςΛογικόςΕλεγκτήςToolStripMenuItem.Click
        Add_Item(45, 0, 0)
    End Sub

    Private Sub HScrollBar1_Scroll_2(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        changezoomlevel()

    End Sub

    Private Sub ΠολυμεσιακόΥλικόToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠολυμεσιακόΥλικόToolStripMenuItem.Click
        Acknoledgement.Show()
    End Sub

    Private Sub ΔιπολικόLNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιπολικόLNToolStripMenuItem.Click
        Add_Item(46, 0, 0)

    End Sub

    Private Sub ΠρίζαΣούκοΜεΦιςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠρίζαΣούκοΜεΦιςToolStripMenuItem.Click
        Add_Item(47, 0, 0)

    End Sub

    Private Sub ΓκαραζόπορταToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΓκαραζόπορταToolStripMenuItem.Click
        Add_Item(48, 0, 0)
    End Sub

    Private Sub ΤριπολικήμονοφασικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤριπολικήμονοφασικήToolStripMenuItem.Click
        Add_Item(49, 0, 0)
    End Sub

    Private Sub ΤετραπολικήτριφασικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤετραπολικήτριφασικήToolStripMenuItem.Click
        Add_Item(50, 0, 0)
    End Sub

    Private Sub ΠενταπολικήτριφασικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠενταπολικήτριφασικήToolStripMenuItem.Click
        Add_Item(51, 0, 0)
    End Sub

    Private Sub ΚλιματιστικοToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΚλιματιστικοToolStripMenuItem.Click
        Add_Item(52, 0, 0)
    End Sub


    Private Sub ΠλυντήριοΠιάτωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠλυντήριοΠιάτωνToolStripMenuItem.Click
        Add_Item(54, 0, 0)

    End Sub

    Private Sub ΣτεγνωτήριοΡούχωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣτεγνωτήριοΡούχωνToolStripMenuItem.Click
        Add_Item(55, 0, 0)

    End Sub

    Private Sub ΑνεμιστήραςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑνεμιστήραςToolStripMenuItem.Click
        Add_Item(56, 0, 0)

    End Sub

    Private Sub ΨυγείοToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΨυγείοToolStripMenuItem.Click
        Add_Item(57, 0, 0)

    End Sub

    Private Sub ΘερμάστραToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΘερμάστραToolStripMenuItem.Click
        Add_Item(58, 0, 0)

    End Sub

    Private Sub ΕξαεριστήραςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕξαεριστήραςToolStripMenuItem.Click
        Add_Item(59, 0, 0)
    End Sub

    Private Sub ΦούρνοςΜικροκυμμάτωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΦούρνοςΜικροκυμμάτωνToolStripMenuItem.Click
        Add_Item(60, 0, 0)

    End Sub

    Private Sub ΗλεκτρικήΚουζίναToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ΗλεκτρικήΚουζίναToolStripMenuItem1.Click
        Add_Item(61, 0, 0)

    End Sub

    Private Sub ΤηλεόρασηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤηλεόρασηToolStripMenuItem.Click
        Add_Item(62, 0, 0)

    End Sub


    Private Sub ΠαροχήΑπόΕπάνωToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠαροχήΑπόΕπάνωToolStripMenuItem.Click
        Add_Item(63, 0, 0)

    End Sub

    Private Sub ΠαροχήΑπόΚάτωToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠαροχήΑπόΚάτωToolStripMenuItem.Click
        Add_Item(64, 0, 0)

    End Sub

    Private Sub ΠαροχήΑπόΑριστεράToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠαροχήΑπόΑριστεράToolStripMenuItem.Click
        Add_Item(65, 0, 0)
    End Sub

    Private Sub ΗλεκτρονόμοςΡάγαςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΗλεκτρονόμοςΡάγαςToolStripMenuItem.Click
        Add_Item(41, 0, 0)

    End Sub

    Private Sub ΣυρόμενηΠόρταToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣυρόμενηΠόρταToolStripMenuItem.Click
        Add_Item(66, 0, 0)
    End Sub

    Private Sub ΤερματικόςΔιακόπτηςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΤερματικόςΔιακόπτηςToolStripMenuItem.Click
        Add_Item(22, 0, 0)

    End Sub

    Private Sub ΦωτοκύτταροToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΦωτοκύτταροToolStripMenuItem.Click
        Add_Item(23, 0, 0)

    End Sub

    Private Sub ΦλοτεροδιακόπτηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΦλοτεροδιακόπτηςToolStripMenuItem.Click
        Add_Item(67, 0, 0)
    End Sub

    Private Sub diakopths3p_Click_1(sender As Object, e As EventArgs) Handles diakopths3p.Click
        Add_Item(12, 0, 0)

    End Sub

    Private Sub diakopths1p_Click_1(sender As Object, e As EventArgs) Handles diakopths1p.Click
        Add_Item(11, 0, 0)

    End Sub

    Private Sub ΔεξαμενήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔεξαμενήToolStripMenuItem.Click
        Add_Item(68, 0, 0)
    End Sub

    Private Sub ΔιακόπτηςΚλιμακοστασίουToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιακόπτηςΚλιμακοστασίουToolStripMenuItem.Click
        Add_Item(69, 0, 0)
    End Sub

    Private Sub ΜπουτόνΦωτισμούToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜπουτόνΦωτισμούToolStripMenuItem.Click
        Add_Item(70, 0, 0)
    End Sub

    Private Sub ΜπουτόνΚουδουνιούToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜπουτόνΚουδουνιούToolStripMenuItem.Click
        Add_Item(71, 0, 0)

    End Sub

    Private Sub ΚουδούνιToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Add_Item(53, 0, 0)

    End Sub

    Private Sub Add_floter_Click(sender As Object, e As EventArgs) Handles Add_floter.Click
        Add_Item(67, 0, 0)

    End Sub

    Private Sub Add_gkarazoporta_Click(sender As Object, e As EventArgs) Handles Add_gkarazoporta.Click
        Add_Item(48, 0, 0)
    End Sub

    Private Sub add_syromenh_porta_Click(sender As Object, e As EventArgs) Handles add_syromenh_porta.Click
        Add_Item(66, 0, 0)

    End Sub

    Private Sub add_water_tank_Click(sender As Object, e As EventArgs) Handles add_water_tank.Click
        Add_Item(68, 0, 0)

    End Sub

    Private Sub add_schucko_Click(sender As Object, e As EventArgs) Handles add_schuko.Click
        Add_Item(47, 0, 0)

    End Sub

    Private Sub add_singlephaseplug_Click(sender As Object, e As EventArgs) Handles add_Socket_3p.Click
        Add_Item(49, 0, 0)

    End Sub

    Private Sub add_4pole_socket_Click(sender As Object, e As EventArgs) Handles add_socket_4p.Click
        Add_Item(50, 0, 0)

    End Sub

    Private Sub add_5pole_socket_Click(sender As Object, e As EventArgs) Handles add_socket_5p.Click
        Add_Item(51, 0, 0)

    End Sub

    Private Sub add_xeiristhrio_Click(sender As Object, e As EventArgs) Handles add_xeiristhrio.Click
        Add_Item(46, 0, 0)

    End Sub

    Private Sub add_kouzina_Click(sender As Object, e As EventArgs) Handles add_kouzina.Click
        Add_Item(61, 0, 0)

    End Sub

    Private Sub add_waterheater_Click(sender As Object, e As EventArgs) Handles add_waterheater.Click
        Add_Item(44, 0, 0)

    End Sub

    Private Sub add_washingmachine_Click(sender As Object, e As EventArgs) Handles add_washingmachine.Click
        Add_Item(43, 0, 0)

    End Sub

    Private Sub add_dishwasher_Click(sender As Object, e As EventArgs) Handles add_dishwasher.Click
        Add_Item(54, 0, 0)

    End Sub

    Private Sub add_hood_Click(sender As Object, e As EventArgs) Handles add_hood.Click
        Add_Item(59, 0, 0)

    End Sub

    Private Sub add_refrigerator_Click(sender As Object, e As EventArgs) Handles add_refrigerator.Click
        Add_Item(57, 0, 0)

    End Sub

    Private Sub add_heater_single_Click(sender As Object, e As EventArgs) Handles add_heater_single.Click
        Add_Item(58, 0, 0)

    End Sub

    Private Sub add_button_fwtismoy_Click(sender As Object, e As EventArgs) Handles add_button_fwtismoy.Click
        Add_Item(70, 0, 0)

    End Sub

    Private Sub add_button_koydoynioy_Click(sender As Object, e As EventArgs) Handles add_button_koydoynioy.Click
        Add_Item(71, 0, 0)

    End Sub

    Private Sub Add_Nyxt_panw_Click(sender As Object, e As EventArgs) Handles Add_Nyxt_panw.Click
        Add_Item(63, 0, 0)

    End Sub

    Private Sub Add_Nyxt_Katw_Click(sender As Object, e As EventArgs) Handles Add_Nyxt_Katw.Click
        Add_Item(64, 0, 0)

    End Sub

    Private Sub Add_Nyxt_Arist_Click(sender As Object, e As EventArgs) Handles Add_Nyxt_Arist.Click
        Add_Item(65, 0, 0)

    End Sub

    Private Sub add_klimakostasiou_Click(sender As Object, e As EventArgs) Handles add_klimakostasiou.Click
        Add_Item(69, 0, 0)

    End Sub

    Private Sub ShowSplashScreenMenu_Click(sender As Object, e As EventArgs) Handles ShowSplashScreenMenu.Click
        If Not Me.Visible Then Exit Sub
        ShowSplashScreenMenu.Checked = Not ShowSplashScreenMenu.Checked

    End Sub


    Private Sub ChangeColorOfSelectedWireMenu_Click(sender As Object, e As EventArgs) Handles ChangeColorOfSelectedWireMenu.Click
        SelectDefaultColor_Click(Me, New System.EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub AutoColorMenu_Click(sender As Object, e As EventArgs) Handles AutoColorMenu.Click
        AutoColor.Checked = Not AutoColorMenu.Checked
    End Sub

    Private Sub AutoColor_CheckedChanged(sender As Object, e As EventArgs) Handles AutoColor.CheckedChanged
        AutoColorMenu.Checked = AutoColor.Checked
    End Sub



   
    Private Sub ΩρομετρητήςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΩρομετρητήςToolStripMenuItem.Click
        Add_Item(72, 0, 0)
    End Sub

    Private Sub ΦάροςToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Add_Item(73, 0, 0)

    End Sub

    Private Sub ΑισθητήραςΦωτόςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑισθητήραςΦωτόςToolStripMenuItem.Click
        Add_Item(74, 0, 0)

    End Sub

    Private Sub ΑισθητήραςΒροχήςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑισθητήραςΒροχήςToolStripMenuItem.Click
        Add_Item(76, 0, 0)
    End Sub

    Private Sub ΑισθητήραςΤαχύτηταςΑνέμουToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑισθητήραςΤαχύτηταςΑνέμουToolStripMenuItem.Click
        Add_Item(75, 0, 0)

    End Sub

    Private Sub ΗλεκτροκίνητηΤένταToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΗλεκτροκίνητηΤένταToolStripMenuItem.Click
        Add_Item(77, 0, 0)

    End Sub

    Private Sub AdditionalResourceButtonPDF_Click(sender As Object, e As EventArgs) Handles AdditionalResourceButtonPDF.Click
        On Error Resume Next
        Dim s = CheckIfAdditionalResourceExists(ExtensionsForDocuments)

        If s <> "" Then
            'Αν υπάρχει ρωτάμε αν ο χειριστής επιθυμεί να το ανοίξει.
            If MsgBox("Το κύκλωμα που ανοίξατε συνοδεύεται από κείμενο οδηγιών. Επιθυμείτε να το άνοίξετε;", vbYesNo) = MsgBoxResult.Yes Then
                Process.Start(s)
            End If
        End If

    End Sub

    Private Sub AdditionalResourceButtonPresentation_Click(sender As Object, e As EventArgs) Handles AdditionalResourceButtonPresentation.Click
        On Error Resume Next
        Dim s = CheckIfAdditionalResourceExists(ExtensionsForPresentations)

        If s <> "" Then
            'Αν υπάρχει ρωτάμε αν ο χειριστής επιθυμεί να το ανοίξει.
            If MsgBox("Το κύκλωμα που ανοίξατε συνοδεύεται από παρουσίαση. Επιθυμείτε να την άνοίξετε;", vbYesNo) = MsgBoxResult.Yes Then
                Process.Start(s)
            End If
        End If
    End Sub

    Private Sub AdditionalResourceButtonVideo_Click(sender As Object, e As EventArgs) Handles AdditionalResourceButtonVideo.Click
        On Error Resume Next
        Dim s = CheckIfAdditionalResourceExists(ExtensionsForVideo)

        If s <> "" Then
            'Αν υπάρχει ρωτάμε αν ο χειριστής επιθυμεί να το ανοίξει.
            If MsgBox("Το κύκλωμα που ανοίξατε συνοδεύεται από βίντεο. Επιθυμείτε να το άνοίξετε;", vbYesNo) = MsgBoxResult.Yes Then
                Process.Start(s)
            End If
        End If

    End Sub

    Private Sub ΠλήκτροΈκτακτηςΑνάγκηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠλήκτροΈκτακτηςΑνάγκηςToolStripMenuItem.Click
        Add_Item(78, 0, 0)

    End Sub

    Private Sub ΔιακόπτηςΜεΚλειδίToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιακόπτηςΜεΚλειδίToolStripMenuItem.Click
        Add_Item(79, 0, 0)

    End Sub

    Private Sub ΗλεκτρικήΚλειδαριάκυπρίToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΗλεκτρικήΚλειδαριάκυπρίToolStripMenuItem.Click
        Add_Item(80, 0, 0)

    End Sub

    Private Sub ΡελέΛυχνίαςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΡελέΛυχνίαςToolStripMenuItem.Click
        Add_Item(81, 0, 0)
    End Sub

    Private Sub ΗλεκτρονόμοςΜεΠολλέςΕπαφέςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΗλεκτρονόμοςΜεΠολλέςΕπαφέςToolStripMenuItem.Click
        Add_Item(25, 0, 0)
    End Sub

    Private Sub ΗλέκτρονόμοςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΗλέκτρονόμοςToolStripMenuItem.Click
        Add_Item(1, 0, 0)

    End Sub

    Private Sub ΕυθυγράμμισηΑγωγώνΣύνδεσηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Auto_Add_Nodes.Click
        If Not Me.Visible Then Exit Sub
        Auto_Add_Nodes.Checked = Not Auto_Add_Nodes.Checked

    End Sub

 
    Private Sub add_tenta_Click(sender As Object, e As EventArgs) Handles add_tenta.Click
        Add_Item(77, 0, 0)

    End Sub

    Private Sub Add_Emergency_Button_Click(sender As Object, e As EventArgs) Handles Add_Emergency_Button.Click
        Add_Item(78, 0, 0)

    End Sub

    Private Sub add_HourMeter_Click(sender As Object, e As EventArgs) Handles add_HourMeter.Click
        Add_Item(72, 0, 0)

    End Sub

    Private Sub add_LightSensor_Click(sender As Object, e As EventArgs) Handles add_LightSensor.Click
        Add_Item(74, 0, 0)

    End Sub

    Private Sub add_WindSensor_Click(sender As Object, e As EventArgs) Handles add_WindSensor.Click
        Add_Item(75, 0, 0)

    End Sub

    Private Sub add_RainSensor_Click(sender As Object, e As EventArgs) Handles add_RainSensor.Click
        Add_Item(74, 0, 0)

    End Sub

    Private Sub ΒοήθειαΣτοΔιαδίκτυοToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΒοήθειαΣτοΔιαδίκτυοToolStripMenuItem.Click
        On Error Resume Next
        Process.Start("https://csmyrlog.sites.sch.gr/lab/usage.html")
    End Sub

  
    Private Sub ΕκτύπωσηΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕκτύπωσηΚυκλώματοςToolStripMenuItem.Click
        Dim i As Image = Nothing
        prepareimage(i, True)
        saveimage(i)
    End Sub

    Private Sub ΙστοσελίδαΕφαρμογήςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΙστοσελίδαΕφαρμογήςToolStripMenuItem.Click
        On Error Resume Next
        Process.Start("https://csmyrlog.sites.sch.gr/lab")
    End Sub

    Private Sub ΔιπολικόςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιπολικόςToolStripMenuItem.Click
        Add_Item(82, 0, 0)

    End Sub

    Private Sub ΤέτραπολικόςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤέτραπολικόςToolStripMenuItem.Click
        Add_Item(83, 0, 0)

    End Sub

    Private Sub ΠενταπολικόςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠενταπολικόςToolStripMenuItem.Click
        Add_Item(84, 0, 0)

    End Sub

    Private Sub ΧειριστήριαToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΧειριστήριαToolStripMenuItem.Click

    End Sub

    Private Sub ΔιπολικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιπολικήToolStripMenuItem.Click
        Add_Item(85, 0, 0)
    End Sub

    Private Sub ΤετραπολικήToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤετραπολικήToolStripMenuItem.Click
        Add_Item(86, 0, 0)
    End Sub

    Private Sub ΤετραπολικήΑσφάλειαLNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤετραπολικήΑσφάλειαLNToolStripMenuItem.Click
        Add_Item(87, 0, 0)

    End Sub

    Private Sub ΜονοφασικόToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜονοφασικόToolStripMenuItem.Click
        Add_Item(88, 0, 0)
    End Sub

    Private Sub ΤριφασικόRCBOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΤριφασικόRCBOToolStripMenuItem.Click
        Add_Item(89, 0, 0)
    End Sub

    Private Sub ΜονοφασικόΡελέΔιαρροήςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΜονοφασικόΡελέΔιαρροήςToolStripMenuItem.Click
        Add_Item(31, 0, 0)
    End Sub

    Private Sub ΤριφασικόΡελέΔιαρροήςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΤριφασικόΡελέΔιαρροήςToolStripMenuItem.Click
        Add_Item(30, 0, 0)
    End Sub

    Private Sub ΑυτόματηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑυτόματηToolStripMenuItem.Click

    End Sub

    Private Sub ΠράσινηToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΠράσινηToolStripMenuItem.Click
        Add_Item(6, 0, 0)
    End Sub

    Private Sub ΚόκκινηToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΚόκκινηToolStripMenuItem.Click
        Add_Item(7, 0, 0)
    End Sub

    Private Sub ΤριφασικήToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΤριφασικήToolStripMenuItem.Click
        Add_Item(29, 0, 0)
    End Sub

    Private Sub ΜπάραΟυδετέρουToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜπάραΟυδετέρουToolStripMenuItem.Click
        Add_Item(36, 0, 0)
    End Sub

    Private Sub ΛαμπτήραςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΛαμπτήραςToolStripMenuItem.Click
        Add_Item(26, 0, 0)

    End Sub

    Private Sub ΦάροςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΦάροςToolStripMenuItem.Click
        Add_Item(73, 0, 0)

    End Sub

    Private Sub ΒομβητήςToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΒομβητήςToolStripMenuItem.Click
        Add_Item(27, 0, 0)

    End Sub

    Private Sub ΣειρήναToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ΣειρήναToolStripMenuItem.Click
        Add_Item(28, 0, 0)
    End Sub

    Private Sub ΚουδούνιToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΚουδούνιToolStripMenuItem.Click
        Add_Item(53, 0, 0)

    End Sub

    Private Sub ΑντικεραυνικότριφασικόToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑντικεραυνικότριφασικόToolStripMenuItem.Click
        Add_Item(90, 0, 0)

    End Sub

    Private Sub ΑντικεραυνικόμονοφασικόToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΑντικεραυνικόμονοφασικόToolStripMenuItem.Click
        Add_Item(91, 0, 0)
    End Sub
End Class
