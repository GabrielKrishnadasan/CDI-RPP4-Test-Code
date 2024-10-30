Module Module1
    Public testing As Boolean

    Public Const POWER_OFF As Long = &HFE
    Public Const POWER_ON As Long = &H1
    Public Const BIT0 As Long = &H1
    Public Const BIT1 As Long = &H2
    Public Const BIT2 As Long = &H4
    Public Const BIT3 As Long = &H8
    Public Const BIT4 As Long = &H10
    Public Const BIT5 As Long = &H20
    Public Const BIT6 As Long = &H40
    Public Const BIT7 As Long = &H80
    Public Const CLEARBIT0 As Long = &HFE
    Public Const CLEARBIT1 As Long = &HFD
    Public Const CLEARBIT2 As Long = &HFB
    Public Const CLEARBIT3 As Long = &HF7
    Public Const CLEARBIT4 As Long = &HEF
    Public Const CLEARBIT5 As Long = &HDF
    Public Const CLEARBIT6 As Long = &HBF
    Public Const CLEARBIT7 As Long = &H7F

    Public Const vbGray As Long = &H80000000
    Public Const DarkGray As Long = &H202020
    Public Const DarkGreen As Long = &H1FF01
    Public Const vbYellow As Integer = &HFFFF00
    Public Const vbRed As Long = &HFF0000
    Public Const vbBlue As Long = &HFF
    Public Const vbGreen As Long = &H8000
    Public Const vbPink As Long = &HFFC0CB
    Public Const vbPurple As Long = &H800080

    Public Const COMMAND_0 As Long = &H30
    Public Const COMMAND_1 As Long = &H31
    Public Const COMMAND_2 As Long = &H32
    Public Const COMMAND_3 As Long = &H33
    Public Const COMMAND_4 As Long = &H34
    Public Const COMMAND_5 As Long = &H35
    Public Const COMMAND_6 As Long = &H36
    Public Const COMMAND_7 As Long = &H37
    Public Const COMMAND_8 As Long = &H38
    Public Const COMMAND_9 As Long = &H39
    Public Const COMMAND_A As Long = &H41
    Public Const COMMAND_B As Long = &H42
    Public Const COMMAND_C As Long = &H43
    Public Const COMMAND_D As Long = &H44
    Public Const COMMAND_E As Long = &H45
    Public Const COMMAND_F As Long = &H46
    Public Const COMMAND_G As Long = &H47
    Public Const COMMAND_H As Long = &H48
    Public Const COMMAND_I As Long = &H49
    Public Const COMMAND_J As Long = &H4A
    Public Const COMMAND_K As Long = &H4B
    Public Const COMMAND_L As Long = &H4C
    Public Const COMMAND_M As Long = &H4D
    Public Const COMMAND_N As Long = &H4E
    Public Const COMMAND_O As Long = &H4F
    Public Const COMMAND_P As Long = &H50
    Public Const COMMAND_Q As Long = &H51
    Public Const COMMAND_R As Long = &H52
    Public Const COMMAND_S As Long = &H53
    Public Const COMMAND_T As Long = &H54
    Public Const COMMAND_U As Long = &H55
    Public Const COMMAND_V As Long = &H56
    Public Const COMMAND_W As Long = &H57
    Public Const COMMAND_X As Long = &H58
    Public Const COMMAND_Y As Long = &H59
    Public Const COMMAND_Z As Long = &H5A
    Public Const COMMAND_La As Long = &H61
    Public Const COMMAND_Lb As Long = &H62
    Public Const COMMAND_Lc As Long = &H63
    Public Const COMMAND_Ld As Long = &H64
    Public Const COMMAND_Le As Long = &H65
    Public Const COMMAND_Lf As Long = &H66
    Public Const COMMAND_Lg As Long = &H67
    Public Const COMMAND_Lh As Long = &H68
    Public Const COMMAND_Li As Long = &H69
    Public Const COMMAND_Lj As Long = &H6A
    Public Const COMMAND_Lk As Long = &H6B
    Public Const COMMAND_Ll As Long = &H6C
    Public Const COMMAND_Lm As Long = &H6D
    Public Const COMMAND_Ln As Long = &H6E
    Public Const COMMAND_Lo As Long = &H6F
    Public Const COMMAND_Lp As Long = &H70
    Public Const COMMAND_Lq As Long = &H71
    Public Const COMMAND_Lr As Long = &H72
    Public Const COMMAND_Ls As Long = &H73
    Public Const COMMAND_Lt As Long = &H74
    Public Const COMMAND_Lu As Long = &H75
    Public Const COMMAND_Lv As Long = &H76
    Public Const COMMAND_Lw As Long = &H77
    Public Const COMMAND_Lx As Long = &H78
    Public Const COMMAND_Ly As Long = &H79
    Public Const COMMAND_Lz As Long = &H7A


    'PUBLIC VARIABLES

    Public wall_current_charging As Double
    Public all_tests_passed As Boolean

    Public file_name As String
    Public file_name2 As String
    Public file_name3 As String
    Public str_test_result As String
    Public str_test_prefix As String

    Public technician As String
    Public str_summary As String


    Public system_error As Boolean

    Public pos_neg(2000) As Long
    Public t(2000) As Long
    Public start_index As Long
    Public start_high As Boolean



    Public charge_current As Double

    Public test_number As Long
    Public serial_number As Long
    Public old_serial_number As String

    Public str_sn_richbox As String
    Public str_barcode As String
    Public current_date As String
    Public current_time As String
    Public com_port As Long
    Public comm_ok As Boolean
    Public valid_info As Boolean
    Public new_test As Boolean
    Public duplicate As Boolean

    Public line_number As Long
    Public end_of_file As Boolean
    Public valid_file As Boolean
    Public file_loaded As Boolean
    Public print_only_once As Boolean


    Public tx_num As Long
    Public digit1 As Long
    Public digit2 As Long
    Public command_value As Long
    Public data_received As Boolean
    Public valid_test_port As Boolean
    Public byte_received As Integer
    Public shadow_reg1 As Integer
    Public shadow_reg2 As Integer
    Public shadow_reg3 As Integer
    Public shadow_reg4 As Integer
    Public shadow_reg5 As Integer
    Public shadow_reg6 As Integer
    Public dip_switch As Integer
    Public led_value As Integer
    Public reg2 As Integer
    Public reg3 As Integer
    Public reg5 As Integer
    Public reg6 As Integer
    Public sram As Integer
    Public com_test_board_ok As Boolean
    Public com_meter_ok As Boolean
    Public tech_ok As Boolean
    Public sn_ok As Boolean
    Public ohm_test_ok As Boolean
    Public voltage_test_ok As Boolean
    Public voltage As Double
    Public resistance As Double
    Public debug_str As String
    Public text_found As Boolean
    Public meter_results As String
    Public read_fpga_str As String

    Public rpp4_str As String
    Public eth_str As String
    Public fpga_version As String
    Public measured_MAC As String
    Public MAC_test_str As String
    Public Temp1 As String
    Public Temp2 As String
    Public Temp3 As String
    Public Temp4 As String
    Public IADC1 As String
    Public IADC2 As String
    Public IADC3 As String
    Public IADC4 As String
    Public Ver_major As String
    Public Ver_minor As String
    Public Ver_build As String
    Public ip_address As String
    Public LED15_on_str As String
    Public LED7_blinking_str As String
    Public temp_test_str As String
    Public ver_test_str As String
    Public RTD_test_str As String
    Public iloop_test_str As String
    Public noise_test_str As String
    Public preamp_version_test_str As String
    Public sawtooth_test_str As String
    Public avg_test_str As String
    Public stdev_test_str As String
    Public moisture_test_str As String
    Public moisture_12_str As String
    Public moisture_8_str As String

    Public ngen_test_str As String
    Public computer_ip_address As String
    Public mac_address As String
    Public ps As String
    Public moisture_msw As String
    Public rpp4tester_id As Integer

    Public mem_test_return As String
    Public mem_test_result As String
    Public crc_test_result As String
    Public crc_rpp4_test As Boolean
    Public crc_pulse_test As Boolean


    Public Const METER_OFF As Long = &H10
    Public Const METER_ON As Long = &HEF
    Public Const V5 As Long = &H0
    Public Const V3_3 As Long = &H1
    Public Const VDD_MPU_CPU As Long = &H2
    Public Const V1_8A As Long = &H3
    Public Const V5A_MINUS As Long = &H4
    Public Const V3_3CPU As Long = &H5
    Public Const V1_8FPGA As Long = &H6
    Public Const V1_2 As Long = &H7
    Public Const V5A_PLUS As Long = &H8
    Public Const V3_3A As Long = &H9
    Public Const VDD_CORE_CPU As Long = &HA
    Public Const V1_8 As Long = &HE
    Public Const FPGA_DDR_VREF As Long = &HC
    Public Const FPGA_VTT As Long = &HD
    Public Const V24_IN As Long = &HB

    Public Meter_Address As String
    Public current As Double

    Public str_threshold_file As String
    Public graph_index As Long

    Public computer_number As String


End Module
