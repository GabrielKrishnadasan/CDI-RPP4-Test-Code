
'Option Explicit On
'' """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
''  Copyright © 2002-2004 Agilent Technologies Inc.  All rights reserved.
''
'' You have a royalty-free right to use, modify, reproduce and distribute
'' the Sample Application Files (and/or any modified version) in any way
'' you find useful, provided that you agree that Agilent Technologies has no
'' warranty,  obligations or liability for any Sample Application Files.
''
'' Agilent Technologies provides programming examples for illustration only,
'' This sample program assumes that you are familiar with the programming
'' language being demonstrated and the tools used to create and debug
'' procedures. Agilent Technologies support engineers can help explain the
'' functionality of Agilent Technologies software components and associated
'' commands, but they will not modify these samples to provide added
'' functionality or construct procedures to meet your specific needs.
'' """"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""


'************************************************************************
' Note;
'   To use RS232, you must first set the instrument to
'   remote with this command:
'   DMM.WriteString "Syst:Rem"
'************************************************************************


Imports System.IO
Imports System.Drawing.Printing

'Com port
Imports Ivi.Visa.Interop
Imports System.IO.Ports
Imports System.Threading
Imports System.Runtime.InteropServices.ComTypes
Imports System.Linq
Imports System.Collections.Generic

Public Class frmEZSample
    Inherits System.Windows.Forms.Form
    Private ioDmm As Ivi.Visa.Interop.FormattedIO488
    Dim SN_() As TextBox
    Dim MBSN_() As TextBox
    Friend WithEvents Command6 As System.Windows.Forms.Button
    Friend WithEvents Command8 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Command_wr0 As System.Windows.Forms.Button
    Friend WithEvents Command_wr1 As System.Windows.Forms.Button
    Friend WithEvents Command_wr2 As System.Windows.Forms.Button
    Friend WithEvents Command_wr3 As System.Windows.Forms.Button
    Friend WithEvents Command_wr4 As System.Windows.Forms.Button
    Friend WithEvents Command_wr5 As System.Windows.Forms.Button
    Friend WithEvents Command_wr6 As System.Windows.Forms.Button
    Friend WithEvents Text_wr0 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr1 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr2 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr3 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr4 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr5 As System.Windows.Forms.TextBox
    Friend WithEvents Text_wr6 As System.Windows.Forms.TextBox
    Friend WithEvents Text_rd2 As System.Windows.Forms.TextBox
    Friend WithEvents Text_rd1 As System.Windows.Forms.TextBox
    Friend WithEvents Text_rd0 As System.Windows.Forms.TextBox
    Friend WithEvents Command_rd2 As System.Windows.Forms.Button
    Friend WithEvents Command_rd1 As System.Windows.Forms.Button
    Friend WithEvents Command_rd0 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Text_COM_RX As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_com As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Text_TX As System.Windows.Forms.TextBox
    Friend WithEvents Text_RX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents en_bus1 As System.Windows.Forms.Button
    Friend WithEvents dis_bus1 As System.Windows.Forms.Button
    Friend WithEvents dis_bus2 As System.Windows.Forms.Button
    Friend WithEvents en_bus2 As System.Windows.Forms.Button
    Friend WithEvents dis_pwr2 As System.Windows.Forms.Button
    Friend WithEvents en_pwr2 As System.Windows.Forms.Button
    Friend WithEvents dis_pwr1 As System.Windows.Forms.Button
    Friend WithEvents en_pwr1 As System.Windows.Forms.Button
    Friend WithEvents dis_pb_rst As System.Windows.Forms.Button
    Friend WithEvents en_pb_rst As System.Windows.Forms.Button
    Friend WithEvents dis_rtd As System.Windows.Forms.Button
    Friend WithEvents en_rtd As System.Windows.Forms.Button
    Friend WithEvents dis_uut_pwr As System.Windows.Forms.Button
    Friend WithEvents en_uut_pwr As System.Windows.Forms.Button
    Friend WithEvents dis_rel1 As System.Windows.Forms.Button
    Friend WithEvents en_rel1 As System.Windows.Forms.Button
    Friend WithEvents dis_rel2 As System.Windows.Forms.Button
    Friend WithEvents en_rel2 As System.Windows.Forms.Button
    Friend WithEvents dis_rel3 As System.Windows.Forms.Button
    Friend WithEvents en_rel3 As System.Windows.Forms.Button
    Friend WithEvents dis_rel4 As System.Windows.Forms.Button
    Friend WithEvents en_rel4 As System.Windows.Forms.Button
    Friend WithEvents dis_rel5 As System.Windows.Forms.Button
    Friend WithEvents en_rel5 As System.Windows.Forms.Button
    Friend WithEvents dis_rel6 As System.Windows.Forms.Button
    Friend WithEvents en_rel6 As System.Windows.Forms.Button
    Friend WithEvents dis_rel7 As System.Windows.Forms.Button
    Friend WithEvents en_rel7 As System.Windows.Forms.Button
    Friend WithEvents com_meter2 As System.Windows.Forms.Button
    Friend WithEvents com_meter1 As System.Windows.Forms.Button
    Friend WithEvents com_meter3 As System.Windows.Forms.Button
    Friend WithEvents com_meter4 As System.Windows.Forms.Button
    Friend WithEvents com_meter5 As System.Windows.Forms.Button
    Friend WithEvents com_meter6 As System.Windows.Forms.Button
    Friend WithEvents com_meter7 As System.Windows.Forms.Button
    Friend WithEvents com_meter8 As System.Windows.Forms.Button
    Friend WithEvents com_meter9 As System.Windows.Forms.Button
    Friend WithEvents com_meter10 As System.Windows.Forms.Button
    Friend WithEvents com_meter11 As System.Windows.Forms.Button
    Friend WithEvents com_meter12 As System.Windows.Forms.Button
    Friend WithEvents com_meter13 As System.Windows.Forms.Button
    Friend WithEvents com_meter14 As System.Windows.Forms.Button
    Friend WithEvents com_meter15 As System.Windows.Forms.Button
    Friend WithEvents com_meter16 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txt_rd_CPU As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dis_loop4 As System.Windows.Forms.Button
    Friend WithEvents en_loop4 As System.Windows.Forms.Button
    Friend WithEvents dis_loop3 As System.Windows.Forms.Button
    Friend WithEvents en_loop3 As System.Windows.Forms.Button
    Friend WithEvents dis_loop2 As System.Windows.Forms.Button
    Friend WithEvents en_loop2 As System.Windows.Forms.Button
    Friend WithEvents dis_loop1 As System.Windows.Forms.Button
    Friend WithEvents en_loop1 As System.Windows.Forms.Button
    Friend WithEvents dis_all_relay As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_StartNewTest As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents V5_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5A_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5A_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents DDR_VREF_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents DDR_VREF_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V24_min_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V24_max_ohm As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents V5_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V5A_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_ohm As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_ohm As System.Windows.Forms.TextBox
    Friend WithEvents DDR_VREF_ohm As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V24_ohm As System.Windows.Forms.TextBox
    Friend WithEvents V24_volt As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_volt As System.Windows.Forms.TextBox
    Friend WithEvents DDR_VREF_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5A_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5_volt As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents DDR_VREF_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_MPU_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8A_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5AMinus_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3_CPU_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents FPGA_VTT_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents DDR_VREF_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents VDD_Core_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V3_3A_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5A_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V5A_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_2_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents V1_8FPGA_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V24_min_volt As System.Windows.Forms.TextBox
    Friend WithEvents V24_max_volt As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents cb_UUT_COM As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents btn_LoadLinux As System.Windows.Forms.Button
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents fpga_ver As System.Windows.Forms.TextBox
    Friend WithEvents LED_15_on_check As System.Windows.Forms.CheckBox
    Friend WithEvents moisture_test As System.Windows.Forms.CheckBox
    Friend WithEvents LED7_blinking_check As System.Windows.Forms.CheckBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents build_ver As System.Windows.Forms.TextBox
    Friend WithEvents tb_ProgrammedMAC As System.Windows.Forms.TextBox
    Friend WithEvents Button47 As System.Windows.Forms.Button
    Friend WithEvents Button42 As System.Windows.Forms.Button
    Friend WithEvents Button43 As System.Windows.Forms.Button
    Friend WithEvents Button44 As System.Windows.Forms.Button
    Friend WithEvents Button46 As System.Windows.Forms.Button
    Friend WithEvents ip_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents T1 As System.Windows.Forms.TextBox
    Friend WithEvents T4 As System.Windows.Forms.TextBox
    Friend WithEvents T3 As System.Windows.Forms.TextBox
    Friend WithEvents T2 As System.Windows.Forms.TextBox
    Friend WithEvents T3_min As System.Windows.Forms.TextBox
    Friend WithEvents T3_max As System.Windows.Forms.TextBox
    Friend WithEvents T4_min As System.Windows.Forms.TextBox
    Friend WithEvents T4_max As System.Windows.Forms.TextBox
    Friend WithEvents T2_min As System.Windows.Forms.TextBox
    Friend WithEvents T2_max As System.Windows.Forms.TextBox
    Friend WithEvents T1_min As System.Windows.Forms.TextBox
    Friend WithEvents T1_max As System.Windows.Forms.TextBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents btn_ProgramFPGA As System.Windows.Forms.Button
    Friend WithEvents FPGA_ver_value As System.Windows.Forms.TextBox
    Friend WithEvents build_ver_value As System.Windows.Forms.TextBox
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents RTD_cur_open As System.Windows.Forms.TextBox
    Friend WithEvents RTD_cur_110 As System.Windows.Forms.TextBox
    Friend WithEvents RTD_cur_110_min As System.Windows.Forms.TextBox
    Friend WithEvents RTD_cur_110_max As System.Windows.Forms.TextBox
    Friend WithEvents RTD_cur_open_min As System.Windows.Forms.TextBox
    Friend WithEvents RTD_cur_open_max As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_open As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_open_min As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_open_max As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_110 As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_110_min As System.Windows.Forms.TextBox
    Friend WithEvents RTD_sense_110_max As System.Windows.Forms.TextBox
    Friend WithEvents Cur As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents L1_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L1_min_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L1_max_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L1_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L1_min_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L1_max_4ma As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents L2_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L2_min_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L2_max_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L2_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L2_min_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L2_max_4ma As System.Windows.Forms.TextBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents L3_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L3_min_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L3_max_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L3_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L3_min_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L3_max_4ma As System.Windows.Forms.TextBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents L4_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L4_min_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L4_max_20ma As System.Windows.Forms.TextBox
    Friend WithEvents L4_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L4_min_4ma As System.Windows.Forms.TextBox
    Friend WithEvents L4_max_4ma As System.Windows.Forms.TextBox
    Friend WithEvents comp_ip_address As System.Windows.Forms.TextBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Preamp_version As System.Windows.Forms.CheckBox
    Friend WithEvents sawtooth_check As System.Windows.Forms.CheckBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Stdev As System.Windows.Forms.TextBox
    Friend WithEvents Stdev_min As System.Windows.Forms.TextBox
    Friend WithEvents Stdev_max As System.Windows.Forms.TextBox
    Friend WithEvents Avg As System.Windows.Forms.TextBox
    Friend WithEvents Avg_min As System.Windows.Forms.TextBox
    Friend WithEvents Avg_max As System.Windows.Forms.TextBox
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents btn_VoltageTest As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents NGEN_12 As System.Windows.Forms.TextBox
    Friend WithEvents NGEN_4 As System.Windows.Forms.TextBox
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents Button34 As System.Windows.Forms.Button
    Friend WithEvents Button35 As System.Windows.Forms.Button
    Friend WithEvents Button37 As System.Windows.Forms.Button
    Friend WithEvents Button38 As System.Windows.Forms.Button
    Friend WithEvents Button50 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents btn_MemoryTest As System.Windows.Forms.Button
    Friend WithEvents Button36 As System.Windows.Forms.Button
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents txt_crc_pulsesvr As System.Windows.Forms.TextBox
    Friend WithEvents txt_crc_rpp4app As System.Windows.Forms.TextBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Button39 As System.Windows.Forms.Button
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents txt_ps As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Computer As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Init_meter_button As System.Windows.Forms.Button
    Friend WithEvents Button48 As System.Windows.Forms.Button
    Friend WithEvents txt_init_box As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Meter_Address As System.Windows.Forms.TextBox
    Friend WithEvents txt_read_dc_value As System.Windows.Forms.TextBox
    Friend WithEvents read_current_value As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Read_DC_Current_Button As System.Windows.Forms.Button
    Friend WithEvents Read_DC_Button As System.Windows.Forms.Button
    Friend WithEvents Button49 As System.Windows.Forms.Button
    Friend WithEvents txt_ohm As System.Windows.Forms.TextBox
    Friend WithEvents Button52 As Button
    Friend WithEvents cb_stop_on_message As System.Windows.Forms.CheckBox
    Friend WithEvents btn_ImpedanceTest As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents Panel_unneeded As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Button55 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btn_MAC_IP As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents flp_impedances As FlowLayoutPanel
    Friend WithEvents flp_voltages As FlowLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents tb_SNFull As TextBox
    Friend WithEvents tb_MAC_Full As TextBox
    Dim MCSN_() As TextBox


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ' The Windows Forms Designer requires the following call.

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTake3DC As System.Windows.Forms.Button
    Friend WithEvents btnTake1AC As System.Windows.Forms.Button
    Friend WithEvents lblReading3 As System.Windows.Forms.Label
    Friend WithEvents lblReading2 As System.Windows.Forms.Label
    Friend WithEvents lblReading1 As System.Windows.Forms.Label
    Friend WithEvents txtReading3 As System.Windows.Forms.TextBox
    Friend WithEvents txtReading2 As System.Windows.Forms.TextBox
    Friend WithEvents txtReading1 As System.Windows.Forms.TextBox
    Friend WithEvents btnClearDisplay As System.Windows.Forms.Button
    Friend WithEvents btnToDisplay As System.Windows.Forms.Button
    Friend WithEvents btnGetRev As System.Windows.Forms.Button
    Friend WithEvents btnGetID As System.Windows.Forms.Button
    Friend WithEvents btnInitIO As System.Windows.Forms.Button
    Friend WithEvents lblToDisplay As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblIDString As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtToDisplay As System.Windows.Forms.TextBox
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents txtIDString As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Txt_Tech As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEZSample))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTake3DC = New System.Windows.Forms.Button()
        Me.btnTake1AC = New System.Windows.Forms.Button()
        Me.lblReading3 = New System.Windows.Forms.Label()
        Me.lblReading2 = New System.Windows.Forms.Label()
        Me.lblReading1 = New System.Windows.Forms.Label()
        Me.txtReading3 = New System.Windows.Forms.TextBox()
        Me.txtReading2 = New System.Windows.Forms.TextBox()
        Me.txtReading1 = New System.Windows.Forms.TextBox()
        Me.btnClearDisplay = New System.Windows.Forms.Button()
        Me.btnToDisplay = New System.Windows.Forms.Button()
        Me.btnGetRev = New System.Windows.Forms.Button()
        Me.btnGetID = New System.Windows.Forms.Button()
        Me.btnInitIO = New System.Windows.Forms.Button()
        Me.lblToDisplay = New System.Windows.Forms.Label()
        Me.lblRevision = New System.Windows.Forms.Label()
        Me.lblIDString = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtToDisplay = New System.Windows.Forms.TextBox()
        Me.txtRevision = New System.Windows.Forms.TextBox()
        Me.txtIDString = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_StartNewTest = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.btn_LoadLinux = New System.Windows.Forms.Button()
        Me.Button44 = New System.Windows.Forms.Button()
        Me.btn_VoltageTest = New System.Windows.Forms.Button()
        Me.btn_MemoryTest = New System.Windows.Forms.Button()
        Me.Button48 = New System.Windows.Forms.Button()
        Me.btn_ImpedanceTest = New System.Windows.Forms.Button()
        Me.btn_MAC_IP = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Txt_Tech = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Command6 = New System.Windows.Forms.Button()
        Me.Command8 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Command_wr0 = New System.Windows.Forms.Button()
        Me.Command_wr1 = New System.Windows.Forms.Button()
        Me.Command_wr2 = New System.Windows.Forms.Button()
        Me.Command_wr3 = New System.Windows.Forms.Button()
        Me.Command_wr4 = New System.Windows.Forms.Button()
        Me.Command_wr5 = New System.Windows.Forms.Button()
        Me.Command_wr6 = New System.Windows.Forms.Button()
        Me.Text_wr0 = New System.Windows.Forms.TextBox()
        Me.Text_wr1 = New System.Windows.Forms.TextBox()
        Me.Text_wr2 = New System.Windows.Forms.TextBox()
        Me.Text_wr3 = New System.Windows.Forms.TextBox()
        Me.Text_wr4 = New System.Windows.Forms.TextBox()
        Me.Text_wr5 = New System.Windows.Forms.TextBox()
        Me.Text_wr6 = New System.Windows.Forms.TextBox()
        Me.Text_rd2 = New System.Windows.Forms.TextBox()
        Me.Text_rd1 = New System.Windows.Forms.TextBox()
        Me.Text_rd0 = New System.Windows.Forms.TextBox()
        Me.Command_rd2 = New System.Windows.Forms.Button()
        Me.Command_rd1 = New System.Windows.Forms.Button()
        Me.Command_rd0 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Text_COM_RX = New System.Windows.Forms.TextBox()
        Me.ComboBox_com = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Text_TX = New System.Windows.Forms.TextBox()
        Me.Text_RX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.en_bus1 = New System.Windows.Forms.Button()
        Me.dis_bus1 = New System.Windows.Forms.Button()
        Me.dis_bus2 = New System.Windows.Forms.Button()
        Me.en_bus2 = New System.Windows.Forms.Button()
        Me.dis_pwr2 = New System.Windows.Forms.Button()
        Me.en_pwr2 = New System.Windows.Forms.Button()
        Me.dis_pwr1 = New System.Windows.Forms.Button()
        Me.en_pwr1 = New System.Windows.Forms.Button()
        Me.dis_pb_rst = New System.Windows.Forms.Button()
        Me.en_pb_rst = New System.Windows.Forms.Button()
        Me.dis_rtd = New System.Windows.Forms.Button()
        Me.en_rtd = New System.Windows.Forms.Button()
        Me.dis_uut_pwr = New System.Windows.Forms.Button()
        Me.en_uut_pwr = New System.Windows.Forms.Button()
        Me.dis_rel1 = New System.Windows.Forms.Button()
        Me.en_rel1 = New System.Windows.Forms.Button()
        Me.dis_rel2 = New System.Windows.Forms.Button()
        Me.en_rel2 = New System.Windows.Forms.Button()
        Me.dis_rel3 = New System.Windows.Forms.Button()
        Me.en_rel3 = New System.Windows.Forms.Button()
        Me.dis_rel4 = New System.Windows.Forms.Button()
        Me.en_rel4 = New System.Windows.Forms.Button()
        Me.dis_rel5 = New System.Windows.Forms.Button()
        Me.en_rel5 = New System.Windows.Forms.Button()
        Me.dis_rel6 = New System.Windows.Forms.Button()
        Me.en_rel6 = New System.Windows.Forms.Button()
        Me.dis_rel7 = New System.Windows.Forms.Button()
        Me.en_rel7 = New System.Windows.Forms.Button()
        Me.com_meter2 = New System.Windows.Forms.Button()
        Me.com_meter1 = New System.Windows.Forms.Button()
        Me.com_meter3 = New System.Windows.Forms.Button()
        Me.com_meter4 = New System.Windows.Forms.Button()
        Me.com_meter5 = New System.Windows.Forms.Button()
        Me.com_meter6 = New System.Windows.Forms.Button()
        Me.com_meter7 = New System.Windows.Forms.Button()
        Me.com_meter8 = New System.Windows.Forms.Button()
        Me.com_meter9 = New System.Windows.Forms.Button()
        Me.com_meter10 = New System.Windows.Forms.Button()
        Me.com_meter11 = New System.Windows.Forms.Button()
        Me.com_meter12 = New System.Windows.Forms.Button()
        Me.com_meter13 = New System.Windows.Forms.Button()
        Me.com_meter14 = New System.Windows.Forms.Button()
        Me.com_meter15 = New System.Windows.Forms.Button()
        Me.com_meter16 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Txt_rd_CPU = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dis_loop4 = New System.Windows.Forms.Button()
        Me.en_loop4 = New System.Windows.Forms.Button()
        Me.dis_loop3 = New System.Windows.Forms.Button()
        Me.en_loop3 = New System.Windows.Forms.Button()
        Me.dis_loop2 = New System.Windows.Forms.Button()
        Me.en_loop2 = New System.Windows.Forms.Button()
        Me.dis_loop1 = New System.Windows.Forms.Button()
        Me.en_loop1 = New System.Windows.Forms.Button()
        Me.dis_all_relay = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.V5_min_ohm = New System.Windows.Forms.TextBox()
        Me.V5_max_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_min_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_max_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_min_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_max_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8A_min_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8A_max_ohm = New System.Windows.Forms.TextBox()
        Me.V5AMinus_min_ohm = New System.Windows.Forms.TextBox()
        Me.V5AMinus_max_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_min_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_max_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_min_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_max_ohm = New System.Windows.Forms.TextBox()
        Me.V1_2_min_ohm = New System.Windows.Forms.TextBox()
        Me.V1_2_max_ohm = New System.Windows.Forms.TextBox()
        Me.V5A_min_ohm = New System.Windows.Forms.TextBox()
        Me.V5A_max_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3A_min_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3A_max_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_Core_min_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_Core_max_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8_min_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8_max_ohm = New System.Windows.Forms.TextBox()
        Me.DDR_VREF_min_ohm = New System.Windows.Forms.TextBox()
        Me.DDR_VREF_max_ohm = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_min_ohm = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_max_ohm = New System.Windows.Forms.TextBox()
        Me.V24_min_ohm = New System.Windows.Forms.TextBox()
        Me.V24_max_ohm = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.V5_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8A_ohm = New System.Windows.Forms.TextBox()
        Me.V5AMinus_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_ohm = New System.Windows.Forms.TextBox()
        Me.V1_2_ohm = New System.Windows.Forms.TextBox()
        Me.V5A_ohm = New System.Windows.Forms.TextBox()
        Me.V3_3A_ohm = New System.Windows.Forms.TextBox()
        Me.VDD_Core_ohm = New System.Windows.Forms.TextBox()
        Me.V1_8_ohm = New System.Windows.Forms.TextBox()
        Me.DDR_VREF_ohm = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_ohm = New System.Windows.Forms.TextBox()
        Me.V24_ohm = New System.Windows.Forms.TextBox()
        Me.V24_volt = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_volt = New System.Windows.Forms.TextBox()
        Me.DDR_VREF_volt = New System.Windows.Forms.TextBox()
        Me.V1_8_volt = New System.Windows.Forms.TextBox()
        Me.VDD_Core_volt = New System.Windows.Forms.TextBox()
        Me.V3_3A_volt = New System.Windows.Forms.TextBox()
        Me.V5A_volt = New System.Windows.Forms.TextBox()
        Me.V1_2_volt = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_volt = New System.Windows.Forms.TextBox()
        Me.V5AMinus_volt = New System.Windows.Forms.TextBox()
        Me.V1_8A_volt = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_volt = New System.Windows.Forms.TextBox()
        Me.V5_volt = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.DDR_VREF_max_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_min_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_max_volt = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_min_volt = New System.Windows.Forms.TextBox()
        Me.VDD_MPU_max_volt = New System.Windows.Forms.TextBox()
        Me.V1_8A_min_volt = New System.Windows.Forms.TextBox()
        Me.V1_8A_max_volt = New System.Windows.Forms.TextBox()
        Me.V5AMinus_min_volt = New System.Windows.Forms.TextBox()
        Me.V5AMinus_max_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_min_volt = New System.Windows.Forms.TextBox()
        Me.V3_3_CPU_max_volt = New System.Windows.Forms.TextBox()
        Me.V5_min_volt = New System.Windows.Forms.TextBox()
        Me.V5_max_volt = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_min_volt = New System.Windows.Forms.TextBox()
        Me.FPGA_VTT_max_volt = New System.Windows.Forms.TextBox()
        Me.DDR_VREF_min_volt = New System.Windows.Forms.TextBox()
        Me.V1_8_max_volt = New System.Windows.Forms.TextBox()
        Me.V1_8_min_volt = New System.Windows.Forms.TextBox()
        Me.VDD_Core_max_volt = New System.Windows.Forms.TextBox()
        Me.VDD_Core_min_volt = New System.Windows.Forms.TextBox()
        Me.V3_3A_max_volt = New System.Windows.Forms.TextBox()
        Me.V3_3A_min_volt = New System.Windows.Forms.TextBox()
        Me.V5A_max_volt = New System.Windows.Forms.TextBox()
        Me.V5A_min_volt = New System.Windows.Forms.TextBox()
        Me.V1_2_max_volt = New System.Windows.Forms.TextBox()
        Me.V1_2_min_volt = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_max_volt = New System.Windows.Forms.TextBox()
        Me.V1_8FPGA_min_volt = New System.Windows.Forms.TextBox()
        Me.V24_min_volt = New System.Windows.Forms.TextBox()
        Me.V24_max_volt = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.cb_UUT_COM = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.fpga_ver = New System.Windows.Forms.TextBox()
        Me.LED_15_on_check = New System.Windows.Forms.CheckBox()
        Me.moisture_test = New System.Windows.Forms.CheckBox()
        Me.LED7_blinking_check = New System.Windows.Forms.CheckBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.build_ver = New System.Windows.Forms.TextBox()
        Me.tb_ProgrammedMAC = New System.Windows.Forms.TextBox()
        Me.Button47 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.ip_txt = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.T1 = New System.Windows.Forms.TextBox()
        Me.T4 = New System.Windows.Forms.TextBox()
        Me.T3 = New System.Windows.Forms.TextBox()
        Me.T2 = New System.Windows.Forms.TextBox()
        Me.T3_min = New System.Windows.Forms.TextBox()
        Me.T3_max = New System.Windows.Forms.TextBox()
        Me.T4_min = New System.Windows.Forms.TextBox()
        Me.T4_max = New System.Windows.Forms.TextBox()
        Me.T2_min = New System.Windows.Forms.TextBox()
        Me.T2_max = New System.Windows.Forms.TextBox()
        Me.T1_min = New System.Windows.Forms.TextBox()
        Me.T1_max = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.btn_ProgramFPGA = New System.Windows.Forms.Button()
        Me.FPGA_ver_value = New System.Windows.Forms.TextBox()
        Me.build_ver_value = New System.Windows.Forms.TextBox()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.RTD_cur_open = New System.Windows.Forms.TextBox()
        Me.RTD_cur_110 = New System.Windows.Forms.TextBox()
        Me.RTD_cur_110_min = New System.Windows.Forms.TextBox()
        Me.RTD_cur_110_max = New System.Windows.Forms.TextBox()
        Me.RTD_cur_open_min = New System.Windows.Forms.TextBox()
        Me.RTD_cur_open_max = New System.Windows.Forms.TextBox()
        Me.RTD_sense_open = New System.Windows.Forms.TextBox()
        Me.RTD_sense_open_min = New System.Windows.Forms.TextBox()
        Me.RTD_sense_open_max = New System.Windows.Forms.TextBox()
        Me.RTD_sense_110 = New System.Windows.Forms.TextBox()
        Me.RTD_sense_110_min = New System.Windows.Forms.TextBox()
        Me.RTD_sense_110_max = New System.Windows.Forms.TextBox()
        Me.Cur = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.L1_20ma = New System.Windows.Forms.TextBox()
        Me.L1_min_20ma = New System.Windows.Forms.TextBox()
        Me.L1_max_20ma = New System.Windows.Forms.TextBox()
        Me.L1_4ma = New System.Windows.Forms.TextBox()
        Me.L1_min_4ma = New System.Windows.Forms.TextBox()
        Me.L1_max_4ma = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.L2_20ma = New System.Windows.Forms.TextBox()
        Me.L2_min_20ma = New System.Windows.Forms.TextBox()
        Me.L2_max_20ma = New System.Windows.Forms.TextBox()
        Me.L2_4ma = New System.Windows.Forms.TextBox()
        Me.L2_min_4ma = New System.Windows.Forms.TextBox()
        Me.L2_max_4ma = New System.Windows.Forms.TextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.L3_20ma = New System.Windows.Forms.TextBox()
        Me.L3_min_20ma = New System.Windows.Forms.TextBox()
        Me.L3_max_20ma = New System.Windows.Forms.TextBox()
        Me.L3_4ma = New System.Windows.Forms.TextBox()
        Me.L3_min_4ma = New System.Windows.Forms.TextBox()
        Me.L3_max_4ma = New System.Windows.Forms.TextBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.L4_20ma = New System.Windows.Forms.TextBox()
        Me.L4_min_20ma = New System.Windows.Forms.TextBox()
        Me.L4_max_20ma = New System.Windows.Forms.TextBox()
        Me.L4_4ma = New System.Windows.Forms.TextBox()
        Me.L4_min_4ma = New System.Windows.Forms.TextBox()
        Me.L4_max_4ma = New System.Windows.Forms.TextBox()
        Me.comp_ip_address = New System.Windows.Forms.TextBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Preamp_version = New System.Windows.Forms.CheckBox()
        Me.sawtooth_check = New System.Windows.Forms.CheckBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Stdev = New System.Windows.Forms.TextBox()
        Me.Stdev_min = New System.Windows.Forms.TextBox()
        Me.Stdev_max = New System.Windows.Forms.TextBox()
        Me.Avg = New System.Windows.Forms.TextBox()
        Me.Avg_min = New System.Windows.Forms.TextBox()
        Me.Avg_max = New System.Windows.Forms.TextBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.NGEN_12 = New System.Windows.Forms.TextBox()
        Me.NGEN_4 = New System.Windows.Forms.TextBox()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.Button37 = New System.Windows.Forms.Button()
        Me.Button38 = New System.Windows.Forms.Button()
        Me.Button50 = New System.Windows.Forms.Button()
        Me.Button51 = New System.Windows.Forms.Button()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.txt_crc_pulsesvr = New System.Windows.Forms.TextBox()
        Me.txt_crc_rpp4app = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.txt_ps = New System.Windows.Forms.RichTextBox()
        Me.Computer = New System.Windows.Forms.TextBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Init_meter_button = New System.Windows.Forms.Button()
        Me.txt_init_box = New System.Windows.Forms.TextBox()
        Me.Txt_Meter_Address = New System.Windows.Forms.TextBox()
        Me.txt_read_dc_value = New System.Windows.Forms.TextBox()
        Me.read_current_value = New System.Windows.Forms.TextBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Read_DC_Current_Button = New System.Windows.Forms.Button()
        Me.Read_DC_Button = New System.Windows.Forms.Button()
        Me.Button49 = New System.Windows.Forms.Button()
        Me.txt_ohm = New System.Windows.Forms.TextBox()
        Me.Button52 = New System.Windows.Forms.Button()
        Me.cb_stop_on_message = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel_unneeded = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button55 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.flp_voltages = New System.Windows.Forms.FlowLayoutPanel()
        Me.flp_impedances = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.tb_SNFull = New System.Windows.Forms.TextBox()
        Me.tb_MAC_Full = New System.Windows.Forms.TextBox()
        Me.groupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.Panel_unneeded.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.flp_voltages.SuspendLayout()
        Me.flp_impedances.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(123, 344)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 20)
        Me.btnClose.TabIndex = 29
        Me.btnClose.Text = "Close IO"
        Me.ToolTip1.SetToolTip(Me.btnClose, "Click to close the IO enviornment")
        Me.btnClose.Visible = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnTake3DC)
        Me.groupBox1.Controls.Add(Me.btnTake1AC)
        Me.groupBox1.Controls.Add(Me.lblReading3)
        Me.groupBox1.Controls.Add(Me.lblReading2)
        Me.groupBox1.Controls.Add(Me.lblReading1)
        Me.groupBox1.Controls.Add(Me.txtReading3)
        Me.groupBox1.Controls.Add(Me.txtReading2)
        Me.groupBox1.Controls.Add(Me.txtReading1)
        Me.groupBox1.Location = New System.Drawing.Point(9, 218)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(416, 120)
        Me.groupBox1.TabIndex = 28
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Measurements"
        Me.groupBox1.Visible = False
        '
        'btnTake3DC
        '
        Me.btnTake3DC.Location = New System.Drawing.Point(240, 56)
        Me.btnTake3DC.Name = "btnTake3DC"
        Me.btnTake3DC.Size = New System.Drawing.Size(160, 20)
        Me.btnTake3DC.TabIndex = 14
        Me.btnTake3DC.Text = "Take Three Readings (DC)"
        Me.ToolTip1.SetToolTip(Me.btnTake3DC, "Click to take three DC Voltage readings")
        '
        'btnTake1AC
        '
        Me.btnTake1AC.Location = New System.Drawing.Point(240, 24)
        Me.btnTake1AC.Name = "btnTake1AC"
        Me.btnTake1AC.Size = New System.Drawing.Size(160, 20)
        Me.btnTake1AC.TabIndex = 13
        Me.btnTake1AC.Text = "Take One Reading (AC)"
        Me.ToolTip1.SetToolTip(Me.btnTake1AC, "Click to take one AC Voltage reading")
        '
        'lblReading3
        '
        Me.lblReading3.Location = New System.Drawing.Point(16, 88)
        Me.lblReading3.Name = "lblReading3"
        Me.lblReading3.Size = New System.Drawing.Size(64, 16)
        Me.lblReading3.TabIndex = 12
        Me.lblReading3.Text = "Reading 3"
        Me.lblReading3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading2
        '
        Me.lblReading2.Location = New System.Drawing.Point(16, 56)
        Me.lblReading2.Name = "lblReading2"
        Me.lblReading2.Size = New System.Drawing.Size(64, 16)
        Me.lblReading2.TabIndex = 11
        Me.lblReading2.Text = "Reading 2"
        Me.lblReading2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading1
        '
        Me.lblReading1.Location = New System.Drawing.Point(16, 24)
        Me.lblReading1.Name = "lblReading1"
        Me.lblReading1.Size = New System.Drawing.Size(64, 16)
        Me.lblReading1.TabIndex = 10
        Me.lblReading1.Text = "Reading 1"
        Me.lblReading1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtReading3
        '
        Me.txtReading3.Location = New System.Drawing.Point(88, 88)
        Me.txtReading3.Name = "txtReading3"
        Me.txtReading3.Size = New System.Drawing.Size(128, 20)
        Me.txtReading3.TabIndex = 9
        '
        'txtReading2
        '
        Me.txtReading2.Location = New System.Drawing.Point(88, 56)
        Me.txtReading2.Name = "txtReading2"
        Me.txtReading2.Size = New System.Drawing.Size(128, 20)
        Me.txtReading2.TabIndex = 8
        '
        'txtReading1
        '
        Me.txtReading1.Location = New System.Drawing.Point(88, 24)
        Me.txtReading1.Name = "txtReading1"
        Me.txtReading1.Size = New System.Drawing.Size(128, 20)
        Me.txtReading1.TabIndex = 7
        '
        'btnClearDisplay
        '
        Me.btnClearDisplay.Location = New System.Drawing.Point(127, 543)
        Me.btnClearDisplay.Name = "btnClearDisplay"
        Me.btnClearDisplay.Size = New System.Drawing.Size(104, 20)
        Me.btnClearDisplay.TabIndex = 27
        Me.btnClearDisplay.Text = "Clear Display"
        Me.ToolTip1.SetToolTip(Me.btnClearDisplay, "Click to clear the instrument display")
        Me.btnClearDisplay.Visible = False
        '
        'btnToDisplay
        '
        Me.btnToDisplay.Location = New System.Drawing.Point(134, 529)
        Me.btnToDisplay.Name = "btnToDisplay"
        Me.btnToDisplay.Size = New System.Drawing.Size(104, 20)
        Me.btnToDisplay.TabIndex = 26
        Me.btnToDisplay.Text = "Send to Display"
        Me.ToolTip1.SetToolTip(Me.btnToDisplay, "Click to send the display string to the instrument")
        Me.btnToDisplay.Visible = False
        '
        'btnGetRev
        '
        Me.btnGetRev.Location = New System.Drawing.Point(65, 547)
        Me.btnGetRev.Name = "btnGetRev"
        Me.btnGetRev.Size = New System.Drawing.Size(104, 20)
        Me.btnGetRev.TabIndex = 25
        Me.btnGetRev.Text = "Get Revision"
        Me.ToolTip1.SetToolTip(Me.btnGetRev, "Click to get the SCPI version for which the instrument complies")
        Me.btnGetRev.Visible = False
        '
        'btnGetID
        '
        Me.btnGetID.Location = New System.Drawing.Point(65, 543)
        Me.btnGetID.Name = "btnGetID"
        Me.btnGetID.Size = New System.Drawing.Size(104, 20)
        Me.btnGetID.TabIndex = 24
        Me.btnGetID.Text = "Get ID String"
        Me.ToolTip1.SetToolTip(Me.btnGetID, "Click to get the ID of the instrument")
        Me.btnGetID.Visible = False
        '
        'btnInitIO
        '
        Me.btnInitIO.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnInitIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitIO.Location = New System.Drawing.Point(5, 45)
        Me.btnInitIO.Name = "btnInitIO"
        Me.btnInitIO.Size = New System.Drawing.Size(48, 28)
        Me.btnInitIO.TabIndex = 23
        Me.btnInitIO.Text = "Set COM Port"
        Me.ToolTip1.SetToolTip(Me.btnInitIO, "Click to initialize the IO enviornment")
        Me.btnInitIO.UseVisualStyleBackColor = False
        '
        'lblToDisplay
        '
        Me.lblToDisplay.Location = New System.Drawing.Point(41, 549)
        Me.lblToDisplay.Name = "lblToDisplay"
        Me.lblToDisplay.Size = New System.Drawing.Size(88, 16)
        Me.lblToDisplay.TabIndex = 22
        Me.lblToDisplay.Text = "Display String"
        Me.lblToDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblToDisplay.Visible = False
        '
        'lblRevision
        '
        Me.lblRevision.Location = New System.Drawing.Point(7, 539)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(88, 16)
        Me.lblRevision.TabIndex = 21
        Me.lblRevision.Text = "Revision"
        Me.lblRevision.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblRevision.Visible = False
        '
        'lblIDString
        '
        Me.lblIDString.Location = New System.Drawing.Point(8, 529)
        Me.lblIDString.Name = "lblIDString"
        Me.lblIDString.Size = New System.Drawing.Size(88, 16)
        Me.lblIDString.TabIndex = 20
        Me.lblIDString.Text = "ID String"
        Me.lblIDString.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblIDString.Visible = False
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(8, 529)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(88, 16)
        Me.lblAddress.TabIndex = 19
        Me.lblAddress.Text = "Address"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblAddress.Visible = False
        '
        'txtToDisplay
        '
        Me.txtToDisplay.Location = New System.Drawing.Point(123, 535)
        Me.txtToDisplay.Name = "txtToDisplay"
        Me.txtToDisplay.Size = New System.Drawing.Size(73, 20)
        Me.txtToDisplay.TabIndex = 18
        Me.txtToDisplay.Text = "RPP4 TEST"
        Me.txtToDisplay.Visible = False
        '
        'txtRevision
        '
        Me.txtRevision.Location = New System.Drawing.Point(103, 539)
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.ReadOnly = True
        Me.txtRevision.Size = New System.Drawing.Size(25, 20)
        Me.txtRevision.TabIndex = 17
        Me.txtRevision.Visible = False
        '
        'txtIDString
        '
        Me.txtIDString.Location = New System.Drawing.Point(104, 529)
        Me.txtIDString.Name = "txtIDString"
        Me.txtIDString.ReadOnly = True
        Me.txtIDString.Size = New System.Drawing.Size(25, 20)
        Me.txtIDString.TabIndex = 16
        Me.txtIDString.Visible = False
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(102, 521)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(27, 20)
        Me.txtAddress.TabIndex = 15
        Me.txtAddress.Text = "ASRL4::INSTR"
        Me.txtAddress.Visible = False
        '
        'btn_StartNewTest
        '
        Me.btn_StartNewTest.BackColor = System.Drawing.Color.LemonChiffon
        Me.btn_StartNewTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_StartNewTest.Location = New System.Drawing.Point(12, 122)
        Me.btn_StartNewTest.Name = "btn_StartNewTest"
        Me.btn_StartNewTest.Size = New System.Drawing.Size(212, 57)
        Me.btn_StartNewTest.TabIndex = 286
        Me.btn_StartNewTest.Text = "Start New Test"
        Me.ToolTip1.SetToolTip(Me.btn_StartNewTest, "Click to initialize the IO enviornment")
        Me.btn_StartNewTest.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(0, 0)
        Me.Button9.Margin = New System.Windows.Forms.Padding(0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(100, 25)
        Me.Button9.TabIndex = 442
        Me.Button9.Text = "send enter"
        Me.ToolTip1.SetToolTip(Me.Button9, "Click to initialize the IO enviornment")
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(0, 25)
        Me.Button12.Margin = New System.Windows.Forms.Padding(0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(100, 25)
        Me.Button12.TabIndex = 443
        Me.Button12.Text = "read"
        Me.ToolTip1.SetToolTip(Me.Button12, "Click to initialize the IO enviornment")
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(0, 50)
        Me.Button14.Margin = New System.Windows.Forms.Padding(0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(100, 25)
        Me.Button14.TabIndex = 445
        Me.Button14.Text = "send root"
        Me.ToolTip1.SetToolTip(Me.Button14, "Click to initialize the IO enviornment")
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.Location = New System.Drawing.Point(0, 75)
        Me.Button15.Margin = New System.Windows.Forms.Padding(0)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(100, 25)
        Me.Button15.TabIndex = 446
        Me.Button15.Text = "send reboot"
        Me.ToolTip1.SetToolTip(Me.Button15, "Click to initialize the IO enviornment")
        Me.Button15.UseVisualStyleBackColor = False
        '
        'btn_LoadLinux
        '
        Me.btn_LoadLinux.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_LoadLinux.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LoadLinux.Location = New System.Drawing.Point(12, 281)
        Me.btn_LoadLinux.Name = "btn_LoadLinux"
        Me.btn_LoadLinux.Size = New System.Drawing.Size(212, 35)
        Me.btn_LoadLinux.TabIndex = 477
        Me.btn_LoadLinux.Text = "Copy Linux from SD"
        Me.ToolTip1.SetToolTip(Me.btn_LoadLinux, "Click to initialize the IO enviornment")
        Me.btn_LoadLinux.UseVisualStyleBackColor = False
        '
        'Button44
        '
        Me.Button44.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button44.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button44.Location = New System.Drawing.Point(1586, 840)
        Me.Button44.Name = "Button44"
        Me.Button44.Size = New System.Drawing.Size(186, 30)
        Me.Button44.TabIndex = 512
        Me.Button44.Text = "Program MAC Address"
        Me.ToolTip1.SetToolTip(Me.Button44, "Click to initialize the IO enviornment")
        Me.Button44.UseVisualStyleBackColor = False
        '
        'btn_VoltageTest
        '
        Me.btn_VoltageTest.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_VoltageTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_VoltageTest.Location = New System.Drawing.Point(12, 240)
        Me.btn_VoltageTest.Name = "btn_VoltageTest"
        Me.btn_VoltageTest.Size = New System.Drawing.Size(212, 35)
        Me.btn_VoltageTest.TabIndex = 624
        Me.btn_VoltageTest.Text = "Test voltages"
        Me.ToolTip1.SetToolTip(Me.btn_VoltageTest, "Click to initialize the IO enviornment")
        Me.btn_VoltageTest.UseVisualStyleBackColor = False
        '
        'btn_MemoryTest
        '
        Me.btn_MemoryTest.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_MemoryTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_MemoryTest.Location = New System.Drawing.Point(12, 459)
        Me.btn_MemoryTest.Name = "btn_MemoryTest"
        Me.btn_MemoryTest.Size = New System.Drawing.Size(212, 35)
        Me.btn_MemoryTest.TabIndex = 661
        Me.btn_MemoryTest.Text = "Memory test"
        Me.ToolTip1.SetToolTip(Me.btn_MemoryTest, "Click to initialize the IO enviornment")
        Me.btn_MemoryTest.UseVisualStyleBackColor = False
        '
        'Button48
        '
        Me.Button48.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button48.Location = New System.Drawing.Point(1441, 61)
        Me.Button48.Name = "Button48"
        Me.Button48.Size = New System.Drawing.Size(76, 22)
        Me.Button48.TabIndex = 731
        Me.Button48.Text = "Read cfg file"
        Me.ToolTip1.SetToolTip(Me.Button48, "Click to get the ID of the instrument")
        Me.Button48.UseVisualStyleBackColor = False
        '
        'btn_ImpedanceTest
        '
        Me.btn_ImpedanceTest.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_ImpedanceTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ImpedanceTest.Location = New System.Drawing.Point(12, 199)
        Me.btn_ImpedanceTest.Name = "btn_ImpedanceTest"
        Me.btn_ImpedanceTest.Size = New System.Drawing.Size(212, 35)
        Me.btn_ImpedanceTest.TabIndex = 744
        Me.btn_ImpedanceTest.Text = "Test impedances"
        Me.ToolTip1.SetToolTip(Me.btn_ImpedanceTest, "Click to initialize the IO enviornment")
        Me.btn_ImpedanceTest.UseVisualStyleBackColor = False
        '
        'btn_MAC_IP
        '
        Me.btn_MAC_IP.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_MAC_IP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_MAC_IP.Location = New System.Drawing.Point(12, 366)
        Me.btn_MAC_IP.Name = "btn_MAC_IP"
        Me.btn_MAC_IP.Size = New System.Drawing.Size(212, 35)
        Me.btn_MAC_IP.TabIndex = 761
        Me.btn_MAC_IP.Text = "Prog MAC / Check IP"
        Me.ToolTip1.SetToolTip(Me.btn_MAC_IP, "Click to initialize the IO enviornment")
        Me.btn_MAC_IP.UseVisualStyleBackColor = False
        '
        'Txt_Tech
        '
        Me.Txt_Tech.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tech.Location = New System.Drawing.Point(51, 19)
        Me.Txt_Tech.Name = "Txt_Tech"
        Me.Txt_Tech.Size = New System.Drawing.Size(173, 26)
        Me.Txt_Tech.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Tech:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "SN:"
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Command6.Location = New System.Drawing.Point(12, 382)
        Me.Command6.Name = "Command6"
        Me.Command6.Size = New System.Drawing.Size(188, 25)
        Me.Command6.TabIndex = 130
        Me.Command6.Text = "SAVE Test"
        Me.Command6.UseVisualStyleBackColor = False
        '
        'Command8
        '
        Me.Command8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command8.Location = New System.Drawing.Point(0, 125)
        Me.Command8.Margin = New System.Windows.Forms.Padding(0)
        Me.Command8.Name = "Command8"
        Me.Command8.Size = New System.Drawing.Size(100, 25)
        Me.Command8.TabIndex = 131
        Me.Command8.Text = "LOAD Existing Log File"
        Me.Command8.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(-36, 482)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 32)
        Me.Button6.TabIndex = 132
        Me.Button6.Text = "Print Test Log"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Command_wr0
        '
        Me.Command_wr0.Location = New System.Drawing.Point(3, 4)
        Me.Command_wr0.Name = "Command_wr0"
        Me.Command_wr0.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr0.TabIndex = 180
        Me.Command_wr0.Text = "WR SRAM"
        Me.Command_wr0.UseVisualStyleBackColor = True
        '
        'Command_wr1
        '
        Me.Command_wr1.Location = New System.Drawing.Point(3, 25)
        Me.Command_wr1.Name = "Command_wr1"
        Me.Command_wr1.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr1.TabIndex = 181
        Me.Command_wr1.Text = "WR LEDs"
        Me.Command_wr1.UseVisualStyleBackColor = True
        '
        'Command_wr2
        '
        Me.Command_wr2.Location = New System.Drawing.Point(3, 45)
        Me.Command_wr2.Name = "Command_wr2"
        Me.Command_wr2.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr2.TabIndex = 182
        Me.Command_wr2.Text = "WR 2"
        Me.Command_wr2.UseVisualStyleBackColor = True
        '
        'Command_wr3
        '
        Me.Command_wr3.Location = New System.Drawing.Point(3, 68)
        Me.Command_wr3.Name = "Command_wr3"
        Me.Command_wr3.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr3.TabIndex = 183
        Me.Command_wr3.Text = "WR 3"
        Me.Command_wr3.UseVisualStyleBackColor = True
        '
        'Command_wr4
        '
        Me.Command_wr4.Location = New System.Drawing.Point(3, 88)
        Me.Command_wr4.Name = "Command_wr4"
        Me.Command_wr4.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr4.TabIndex = 184
        Me.Command_wr4.Text = "WR DIP SW"
        Me.Command_wr4.UseVisualStyleBackColor = True
        '
        'Command_wr5
        '
        Me.Command_wr5.Location = New System.Drawing.Point(3, 112)
        Me.Command_wr5.Name = "Command_wr5"
        Me.Command_wr5.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr5.TabIndex = 185
        Me.Command_wr5.Text = "WR 5"
        Me.Command_wr5.UseVisualStyleBackColor = True
        '
        'Command_wr6
        '
        Me.Command_wr6.Location = New System.Drawing.Point(3, 136)
        Me.Command_wr6.Name = "Command_wr6"
        Me.Command_wr6.Size = New System.Drawing.Size(85, 22)
        Me.Command_wr6.TabIndex = 186
        Me.Command_wr6.Text = "WR 6"
        Me.Command_wr6.UseVisualStyleBackColor = True
        '
        'Text_wr0
        '
        Me.Text_wr0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr0.Location = New System.Drawing.Point(108, 5)
        Me.Text_wr0.Name = "Text_wr0"
        Me.Text_wr0.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr0.TabIndex = 187
        Me.Text_wr0.Tag = "2"
        '
        'Text_wr1
        '
        Me.Text_wr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr1.Location = New System.Drawing.Point(108, 25)
        Me.Text_wr1.Name = "Text_wr1"
        Me.Text_wr1.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr1.TabIndex = 188
        Me.Text_wr1.Tag = "2"
        '
        'Text_wr2
        '
        Me.Text_wr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr2.Location = New System.Drawing.Point(108, 45)
        Me.Text_wr2.Name = "Text_wr2"
        Me.Text_wr2.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr2.TabIndex = 189
        Me.Text_wr2.Tag = "2"
        '
        'Text_wr3
        '
        Me.Text_wr3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr3.Location = New System.Drawing.Point(108, 68)
        Me.Text_wr3.Name = "Text_wr3"
        Me.Text_wr3.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr3.TabIndex = 190
        Me.Text_wr3.Tag = "2"
        '
        'Text_wr4
        '
        Me.Text_wr4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr4.Location = New System.Drawing.Point(108, 89)
        Me.Text_wr4.Name = "Text_wr4"
        Me.Text_wr4.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr4.TabIndex = 191
        Me.Text_wr4.Tag = "2"
        '
        'Text_wr5
        '
        Me.Text_wr5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr5.Location = New System.Drawing.Point(108, 112)
        Me.Text_wr5.Name = "Text_wr5"
        Me.Text_wr5.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr5.TabIndex = 192
        Me.Text_wr5.Tag = "2"
        '
        'Text_wr6
        '
        Me.Text_wr6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_wr6.Location = New System.Drawing.Point(108, 136)
        Me.Text_wr6.Name = "Text_wr6"
        Me.Text_wr6.Size = New System.Drawing.Size(33, 22)
        Me.Text_wr6.TabIndex = 193
        Me.Text_wr6.Tag = "2"
        '
        'Text_rd2
        '
        Me.Text_rd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_rd2.Location = New System.Drawing.Point(271, 53)
        Me.Text_rd2.Name = "Text_rd2"
        Me.Text_rd2.Size = New System.Drawing.Size(49, 22)
        Me.Text_rd2.TabIndex = 199
        Me.Text_rd2.Tag = "2"
        '
        'Text_rd1
        '
        Me.Text_rd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_rd1.Location = New System.Drawing.Point(271, 28)
        Me.Text_rd1.Name = "Text_rd1"
        Me.Text_rd1.Size = New System.Drawing.Size(49, 22)
        Me.Text_rd1.TabIndex = 198
        Me.Text_rd1.Tag = "2"
        '
        'Text_rd0
        '
        Me.Text_rd0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_rd0.Location = New System.Drawing.Point(271, 4)
        Me.Text_rd0.Name = "Text_rd0"
        Me.Text_rd0.Size = New System.Drawing.Size(49, 22)
        Me.Text_rd0.TabIndex = 197
        Me.Text_rd0.Tag = "2"
        '
        'Command_rd2
        '
        Me.Command_rd2.Location = New System.Drawing.Point(156, 53)
        Me.Command_rd2.Name = "Command_rd2"
        Me.Command_rd2.Size = New System.Drawing.Size(85, 22)
        Me.Command_rd2.TabIndex = 196
        Me.Command_rd2.Text = "RD 2"
        Me.Command_rd2.UseVisualStyleBackColor = True
        '
        'Command_rd1
        '
        Me.Command_rd1.Location = New System.Drawing.Point(156, 28)
        Me.Command_rd1.Name = "Command_rd1"
        Me.Command_rd1.Size = New System.Drawing.Size(85, 22)
        Me.Command_rd1.TabIndex = 195
        Me.Command_rd1.Text = "RD 1"
        Me.Command_rd1.UseVisualStyleBackColor = True
        '
        'Command_rd0
        '
        Me.Command_rd0.Location = New System.Drawing.Point(156, 4)
        Me.Command_rd0.Name = "Command_rd0"
        Me.Command_rd0.Size = New System.Drawing.Size(85, 22)
        Me.Command_rd0.TabIndex = 194
        Me.Command_rd0.Text = "RD SRAM"
        Me.Command_rd0.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(7, 157)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(85, 20)
        Me.TextBox2.TabIndex = 200
        '
        'Text_COM_RX
        '
        Me.Text_COM_RX.Location = New System.Drawing.Point(156, 141)
        Me.Text_COM_RX.Name = "Text_COM_RX"
        Me.Text_COM_RX.Size = New System.Drawing.Size(85, 20)
        Me.Text_COM_RX.TabIndex = 201
        '
        'ComboBox_com
        '
        Me.ComboBox_com.FormattingEnabled = True
        Me.ComboBox_com.Location = New System.Drawing.Point(132, 18)
        Me.ComboBox_com.Name = "ComboBox_com"
        Me.ComboBox_com.Size = New System.Drawing.Size(56, 21)
        Me.ComboBox_com.TabIndex = 202
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(6, 17)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(120, 23)
        Me.btnConnect.TabIndex = 203
        Me.btnConnect.Text = "Open COM Port"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(6, 42)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(120, 23)
        Me.Button10.TabIndex = 206
        Me.Button10.Text = "CLOSE COM Port"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(156, 109)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(140, 27)
        Me.Button11.TabIndex = 207
        Me.Button11.Text = "Read COM Buffer"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Text_TX
        '
        Me.Text_TX.Location = New System.Drawing.Point(132, 44)
        Me.Text_TX.Name = "Text_TX"
        Me.Text_TX.Size = New System.Drawing.Size(22, 20)
        Me.Text_TX.TabIndex = 208
        Me.Text_TX.Text = "TX"
        '
        'Text_RX
        '
        Me.Text_RX.Location = New System.Drawing.Point(166, 44)
        Me.Text_RX.Name = "Text_RX"
        Me.Text_RX.Size = New System.Drawing.Size(22, 20)
        Me.Text_RX.TabIndex = 209
        Me.Text_RX.Text = "RX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(89, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "0x"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(89, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 13)
        Me.Label12.TabIndex = 211
        Me.Label12.Text = "0x"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(89, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 13)
        Me.Label13.TabIndex = 212
        Me.Label13.Text = "0x"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(88, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(18, 13)
        Me.Label14.TabIndex = 213
        Me.Label14.Text = "0x"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(89, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 13)
        Me.Label15.TabIndex = 214
        Me.Label15.Text = "0x"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(89, 141)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 13)
        Me.Label16.TabIndex = 215
        Me.Label16.Text = "0x"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(89, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(18, 13)
        Me.Label17.TabIndex = 216
        Me.Label17.Text = "0x"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.btnInitIO)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(462, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(126, 124)
        Me.GroupBox3.TabIndex = 221
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Meter"
        Me.GroupBox3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(55, 37)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(57, 39)
        Me.ComboBox1.TabIndex = 203
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(7, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(85, 26)
        Me.TextBox3.TabIndex = 34
        '
        'en_bus1
        '
        Me.en_bus1.Location = New System.Drawing.Point(1, 1)
        Me.en_bus1.Margin = New System.Windows.Forms.Padding(1)
        Me.en_bus1.Name = "en_bus1"
        Me.en_bus1.Size = New System.Drawing.Size(130, 22)
        Me.en_bus1.TabIndex = 222
        Me.en_bus1.Text = "ENABLE JTAG BUS1"
        Me.en_bus1.UseVisualStyleBackColor = True
        '
        'dis_bus1
        '
        Me.dis_bus1.Location = New System.Drawing.Point(1, 1)
        Me.dis_bus1.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_bus1.Name = "dis_bus1"
        Me.dis_bus1.Size = New System.Drawing.Size(130, 22)
        Me.dis_bus1.TabIndex = 225
        Me.dis_bus1.Text = "DISABLE JTAG BUS1"
        Me.dis_bus1.UseVisualStyleBackColor = True
        '
        'dis_bus2
        '
        Me.dis_bus2.Location = New System.Drawing.Point(1, 25)
        Me.dis_bus2.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_bus2.Name = "dis_bus2"
        Me.dis_bus2.Size = New System.Drawing.Size(130, 22)
        Me.dis_bus2.TabIndex = 227
        Me.dis_bus2.Text = "DISABLE FPGA BUS2"
        Me.dis_bus2.UseVisualStyleBackColor = True
        '
        'en_bus2
        '
        Me.en_bus2.Location = New System.Drawing.Point(1, 25)
        Me.en_bus2.Margin = New System.Windows.Forms.Padding(1)
        Me.en_bus2.Name = "en_bus2"
        Me.en_bus2.Size = New System.Drawing.Size(130, 22)
        Me.en_bus2.TabIndex = 226
        Me.en_bus2.Text = "ENABLE FPGA BUS2"
        Me.en_bus2.UseVisualStyleBackColor = True
        '
        'dis_pwr2
        '
        Me.dis_pwr2.Location = New System.Drawing.Point(1, 73)
        Me.dis_pwr2.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_pwr2.Name = "dis_pwr2"
        Me.dis_pwr2.Size = New System.Drawing.Size(130, 22)
        Me.dis_pwr2.TabIndex = 231
        Me.dis_pwr2.Text = "DISABLE FPGA PWR"
        Me.dis_pwr2.UseVisualStyleBackColor = True
        '
        'en_pwr2
        '
        Me.en_pwr2.Location = New System.Drawing.Point(1, 73)
        Me.en_pwr2.Margin = New System.Windows.Forms.Padding(1)
        Me.en_pwr2.Name = "en_pwr2"
        Me.en_pwr2.Size = New System.Drawing.Size(130, 22)
        Me.en_pwr2.TabIndex = 230
        Me.en_pwr2.Text = "ENABLE FPGA PWR"
        Me.en_pwr2.UseVisualStyleBackColor = True
        '
        'dis_pwr1
        '
        Me.dis_pwr1.Location = New System.Drawing.Point(1, 49)
        Me.dis_pwr1.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_pwr1.Name = "dis_pwr1"
        Me.dis_pwr1.Size = New System.Drawing.Size(130, 22)
        Me.dis_pwr1.TabIndex = 229
        Me.dis_pwr1.Text = "DISABLE JTAG PWR"
        Me.dis_pwr1.UseVisualStyleBackColor = True
        '
        'en_pwr1
        '
        Me.en_pwr1.Location = New System.Drawing.Point(1, 49)
        Me.en_pwr1.Margin = New System.Windows.Forms.Padding(1)
        Me.en_pwr1.Name = "en_pwr1"
        Me.en_pwr1.Size = New System.Drawing.Size(130, 22)
        Me.en_pwr1.TabIndex = 228
        Me.en_pwr1.Text = "ENABLE JTAG PWR"
        Me.en_pwr1.UseVisualStyleBackColor = True
        '
        'dis_pb_rst
        '
        Me.dis_pb_rst.Location = New System.Drawing.Point(1, 97)
        Me.dis_pb_rst.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_pb_rst.Name = "dis_pb_rst"
        Me.dis_pb_rst.Size = New System.Drawing.Size(130, 22)
        Me.dis_pb_rst.TabIndex = 233
        Me.dis_pb_rst.Text = "DISABLE PB RST#"
        Me.dis_pb_rst.UseVisualStyleBackColor = True
        '
        'en_pb_rst
        '
        Me.en_pb_rst.Location = New System.Drawing.Point(1, 97)
        Me.en_pb_rst.Margin = New System.Windows.Forms.Padding(1)
        Me.en_pb_rst.Name = "en_pb_rst"
        Me.en_pb_rst.Size = New System.Drawing.Size(130, 22)
        Me.en_pb_rst.TabIndex = 232
        Me.en_pb_rst.Text = "ENABLE PB RST#"
        Me.en_pb_rst.UseVisualStyleBackColor = True
        '
        'dis_rtd
        '
        Me.dis_rtd.Location = New System.Drawing.Point(1, 121)
        Me.dis_rtd.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rtd.Name = "dis_rtd"
        Me.dis_rtd.Size = New System.Drawing.Size(130, 22)
        Me.dis_rtd.TabIndex = 235
        Me.dis_rtd.Text = "DISABLE RTD#"
        Me.dis_rtd.UseVisualStyleBackColor = True
        '
        'en_rtd
        '
        Me.en_rtd.Location = New System.Drawing.Point(1, 121)
        Me.en_rtd.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rtd.Name = "en_rtd"
        Me.en_rtd.Size = New System.Drawing.Size(130, 22)
        Me.en_rtd.TabIndex = 234
        Me.en_rtd.Text = "ENABLE RTD#"
        Me.en_rtd.UseVisualStyleBackColor = True
        '
        'dis_uut_pwr
        '
        Me.dis_uut_pwr.Location = New System.Drawing.Point(609, 120)
        Me.dis_uut_pwr.Name = "dis_uut_pwr"
        Me.dis_uut_pwr.Size = New System.Drawing.Size(130, 41)
        Me.dis_uut_pwr.TabIndex = 237
        Me.dis_uut_pwr.Text = "DISABLE UUT PWR"
        Me.dis_uut_pwr.UseVisualStyleBackColor = True
        '
        'en_uut_pwr
        '
        Me.en_uut_pwr.Location = New System.Drawing.Point(609, 166)
        Me.en_uut_pwr.Name = "en_uut_pwr"
        Me.en_uut_pwr.Size = New System.Drawing.Size(130, 41)
        Me.en_uut_pwr.TabIndex = 236
        Me.en_uut_pwr.Text = "ENABLE UUT PWR"
        Me.en_uut_pwr.UseVisualStyleBackColor = True
        '
        'dis_rel1
        '
        Me.dis_rel1.Location = New System.Drawing.Point(1, 145)
        Me.dis_rel1.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel1.Name = "dis_rel1"
        Me.dis_rel1.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel1.TabIndex = 239
        Me.dis_rel1.Text = "DISABLE Relay 1"
        Me.dis_rel1.UseVisualStyleBackColor = True
        '
        'en_rel1
        '
        Me.en_rel1.Location = New System.Drawing.Point(1, 145)
        Me.en_rel1.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel1.Name = "en_rel1"
        Me.en_rel1.Size = New System.Drawing.Size(130, 22)
        Me.en_rel1.TabIndex = 238
        Me.en_rel1.Text = "ENABLE Relay 1"
        Me.en_rel1.UseVisualStyleBackColor = True
        '
        'dis_rel2
        '
        Me.dis_rel2.Location = New System.Drawing.Point(1, 169)
        Me.dis_rel2.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel2.Name = "dis_rel2"
        Me.dis_rel2.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel2.TabIndex = 241
        Me.dis_rel2.Text = "DISABLE Relay 2"
        Me.dis_rel2.UseVisualStyleBackColor = True
        '
        'en_rel2
        '
        Me.en_rel2.Location = New System.Drawing.Point(1, 169)
        Me.en_rel2.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel2.Name = "en_rel2"
        Me.en_rel2.Size = New System.Drawing.Size(130, 22)
        Me.en_rel2.TabIndex = 240
        Me.en_rel2.Text = "ENABLE Relay 2"
        Me.en_rel2.UseVisualStyleBackColor = True
        '
        'dis_rel3
        '
        Me.dis_rel3.Location = New System.Drawing.Point(1, 193)
        Me.dis_rel3.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel3.Name = "dis_rel3"
        Me.dis_rel3.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel3.TabIndex = 243
        Me.dis_rel3.Text = "DISABLE Relay 3"
        Me.dis_rel3.UseVisualStyleBackColor = True
        '
        'en_rel3
        '
        Me.en_rel3.Location = New System.Drawing.Point(1, 193)
        Me.en_rel3.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel3.Name = "en_rel3"
        Me.en_rel3.Size = New System.Drawing.Size(130, 22)
        Me.en_rel3.TabIndex = 242
        Me.en_rel3.Text = "ENABLE Relay 3"
        Me.en_rel3.UseVisualStyleBackColor = True
        '
        'dis_rel4
        '
        Me.dis_rel4.Location = New System.Drawing.Point(1, 217)
        Me.dis_rel4.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel4.Name = "dis_rel4"
        Me.dis_rel4.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel4.TabIndex = 245
        Me.dis_rel4.Text = "DISABLE Relay 4"
        Me.dis_rel4.UseVisualStyleBackColor = True
        '
        'en_rel4
        '
        Me.en_rel4.Location = New System.Drawing.Point(1, 217)
        Me.en_rel4.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel4.Name = "en_rel4"
        Me.en_rel4.Size = New System.Drawing.Size(130, 22)
        Me.en_rel4.TabIndex = 244
        Me.en_rel4.Text = "ENABLE Relay 4"
        Me.en_rel4.UseVisualStyleBackColor = True
        '
        'dis_rel5
        '
        Me.dis_rel5.Location = New System.Drawing.Point(1, 241)
        Me.dis_rel5.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel5.Name = "dis_rel5"
        Me.dis_rel5.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel5.TabIndex = 247
        Me.dis_rel5.Text = "DISABLE Relay 5"
        Me.dis_rel5.UseVisualStyleBackColor = True
        '
        'en_rel5
        '
        Me.en_rel5.Location = New System.Drawing.Point(1, 241)
        Me.en_rel5.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel5.Name = "en_rel5"
        Me.en_rel5.Size = New System.Drawing.Size(130, 22)
        Me.en_rel5.TabIndex = 246
        Me.en_rel5.Text = "ENABLE Relay 5"
        Me.en_rel5.UseVisualStyleBackColor = True
        '
        'dis_rel6
        '
        Me.dis_rel6.Location = New System.Drawing.Point(1, 265)
        Me.dis_rel6.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel6.Name = "dis_rel6"
        Me.dis_rel6.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel6.TabIndex = 249
        Me.dis_rel6.Text = "DISABLE Relay 6"
        Me.dis_rel6.UseVisualStyleBackColor = True
        '
        'en_rel6
        '
        Me.en_rel6.Location = New System.Drawing.Point(1, 265)
        Me.en_rel6.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel6.Name = "en_rel6"
        Me.en_rel6.Size = New System.Drawing.Size(130, 22)
        Me.en_rel6.TabIndex = 248
        Me.en_rel6.Text = "ENABLE Relay 6"
        Me.en_rel6.UseVisualStyleBackColor = True
        '
        'dis_rel7
        '
        Me.dis_rel7.Location = New System.Drawing.Point(1, 289)
        Me.dis_rel7.Margin = New System.Windows.Forms.Padding(1)
        Me.dis_rel7.Name = "dis_rel7"
        Me.dis_rel7.Size = New System.Drawing.Size(130, 22)
        Me.dis_rel7.TabIndex = 251
        Me.dis_rel7.Text = "DISABLE Relay 7"
        Me.dis_rel7.UseVisualStyleBackColor = True
        '
        'en_rel7
        '
        Me.en_rel7.Location = New System.Drawing.Point(1, 289)
        Me.en_rel7.Margin = New System.Windows.Forms.Padding(1)
        Me.en_rel7.Name = "en_rel7"
        Me.en_rel7.Size = New System.Drawing.Size(130, 22)
        Me.en_rel7.TabIndex = 250
        Me.en_rel7.Text = "ENABLE Relay 7"
        Me.en_rel7.UseVisualStyleBackColor = True
        '
        'com_meter2
        '
        Me.com_meter2.Location = New System.Drawing.Point(0, 21)
        Me.com_meter2.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter2.Name = "com_meter2"
        Me.com_meter2.Size = New System.Drawing.Size(190, 22)
        Me.com_meter2.TabIndex = 254
        Me.com_meter2.Text = "Enable Meter to V5"
        Me.com_meter2.UseVisualStyleBackColor = True
        '
        'com_meter1
        '
        Me.com_meter1.Location = New System.Drawing.Point(0, 43)
        Me.com_meter1.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter1.Name = "com_meter1"
        Me.com_meter1.Size = New System.Drawing.Size(190, 22)
        Me.com_meter1.TabIndex = 255
        Me.com_meter1.Text = "Disable Meter"
        Me.com_meter1.UseVisualStyleBackColor = True
        '
        'com_meter3
        '
        Me.com_meter3.Location = New System.Drawing.Point(0, 65)
        Me.com_meter3.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter3.Name = "com_meter3"
        Me.com_meter3.Size = New System.Drawing.Size(190, 22)
        Me.com_meter3.TabIndex = 256
        Me.com_meter3.Text = "Enable Meter to V3_3"
        Me.com_meter3.UseVisualStyleBackColor = True
        '
        'com_meter4
        '
        Me.com_meter4.Location = New System.Drawing.Point(0, 87)
        Me.com_meter4.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter4.Name = "com_meter4"
        Me.com_meter4.Size = New System.Drawing.Size(190, 22)
        Me.com_meter4.TabIndex = 257
        Me.com_meter4.Text = "Enable Meter to VDD MPU CPU"
        Me.com_meter4.UseVisualStyleBackColor = True
        '
        'com_meter5
        '
        Me.com_meter5.Location = New System.Drawing.Point(0, 109)
        Me.com_meter5.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter5.Name = "com_meter5"
        Me.com_meter5.Size = New System.Drawing.Size(190, 22)
        Me.com_meter5.TabIndex = 258
        Me.com_meter5.Text = "Enable Meter to V1_8A"
        Me.com_meter5.UseVisualStyleBackColor = True
        '
        'com_meter6
        '
        Me.com_meter6.Location = New System.Drawing.Point(0, 131)
        Me.com_meter6.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter6.Name = "com_meter6"
        Me.com_meter6.Size = New System.Drawing.Size(190, 22)
        Me.com_meter6.TabIndex = 259
        Me.com_meter6.Text = "Enable Meter to V5A-"
        Me.com_meter6.UseVisualStyleBackColor = True
        '
        'com_meter7
        '
        Me.com_meter7.Location = New System.Drawing.Point(0, 153)
        Me.com_meter7.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter7.Name = "com_meter7"
        Me.com_meter7.Size = New System.Drawing.Size(190, 22)
        Me.com_meter7.TabIndex = 260
        Me.com_meter7.Text = "Enable Meter to 3_3 CPU"
        Me.com_meter7.UseVisualStyleBackColor = True
        '
        'com_meter8
        '
        Me.com_meter8.Location = New System.Drawing.Point(0, 175)
        Me.com_meter8.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter8.Name = "com_meter8"
        Me.com_meter8.Size = New System.Drawing.Size(190, 22)
        Me.com_meter8.TabIndex = 261
        Me.com_meter8.Text = "Enable Meter to V1_8FPGA"
        Me.com_meter8.UseVisualStyleBackColor = True
        '
        'com_meter9
        '
        Me.com_meter9.Location = New System.Drawing.Point(0, 197)
        Me.com_meter9.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter9.Name = "com_meter9"
        Me.com_meter9.Size = New System.Drawing.Size(190, 22)
        Me.com_meter9.TabIndex = 262
        Me.com_meter9.Text = "Enable Meter to V1_2"
        Me.com_meter9.UseVisualStyleBackColor = True
        '
        'com_meter10
        '
        Me.com_meter10.Location = New System.Drawing.Point(0, 219)
        Me.com_meter10.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter10.Name = "com_meter10"
        Me.com_meter10.Size = New System.Drawing.Size(190, 22)
        Me.com_meter10.TabIndex = 263
        Me.com_meter10.Text = "Enable Meter to V5A+"
        Me.com_meter10.UseVisualStyleBackColor = True
        '
        'com_meter11
        '
        Me.com_meter11.Location = New System.Drawing.Point(0, 241)
        Me.com_meter11.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter11.Name = "com_meter11"
        Me.com_meter11.Size = New System.Drawing.Size(190, 22)
        Me.com_meter11.TabIndex = 264
        Me.com_meter11.Text = "Enable Meter to V3_3A"
        Me.com_meter11.UseVisualStyleBackColor = True
        '
        'com_meter12
        '
        Me.com_meter12.Location = New System.Drawing.Point(0, 263)
        Me.com_meter12.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter12.Name = "com_meter12"
        Me.com_meter12.Size = New System.Drawing.Size(190, 22)
        Me.com_meter12.TabIndex = 265
        Me.com_meter12.Text = "Enable Meter to VDD Core CPU"
        Me.com_meter12.UseVisualStyleBackColor = True
        '
        'com_meter13
        '
        Me.com_meter13.Location = New System.Drawing.Point(0, 285)
        Me.com_meter13.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter13.Name = "com_meter13"
        Me.com_meter13.Size = New System.Drawing.Size(190, 22)
        Me.com_meter13.TabIndex = 266
        Me.com_meter13.Text = "Enable Meter to V1_8"
        Me.com_meter13.UseVisualStyleBackColor = True
        '
        'com_meter14
        '
        Me.com_meter14.Location = New System.Drawing.Point(0, 307)
        Me.com_meter14.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter14.Name = "com_meter14"
        Me.com_meter14.Size = New System.Drawing.Size(190, 22)
        Me.com_meter14.TabIndex = 267
        Me.com_meter14.Text = "Enable Meter to FPGA DDR VREF"
        Me.com_meter14.UseVisualStyleBackColor = True
        '
        'com_meter15
        '
        Me.com_meter15.Location = New System.Drawing.Point(0, 329)
        Me.com_meter15.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter15.Name = "com_meter15"
        Me.com_meter15.Size = New System.Drawing.Size(190, 22)
        Me.com_meter15.TabIndex = 268
        Me.com_meter15.Text = "Enable Meter to FPGA VTT"
        Me.com_meter15.UseVisualStyleBackColor = True
        '
        'com_meter16
        '
        Me.com_meter16.Location = New System.Drawing.Point(0, 351)
        Me.com_meter16.Margin = New System.Windows.Forms.Padding(0)
        Me.com_meter16.Name = "com_meter16"
        Me.com_meter16.Size = New System.Drawing.Size(190, 22)
        Me.com_meter16.TabIndex = 269
        Me.com_meter16.Text = "Enable Meter to 24V_IN"
        Me.com_meter16.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(156, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 22)
        Me.Button1.TabIndex = 270
        Me.Button1.Text = "RD CPU"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Txt_rd_CPU
        '
        Me.Txt_rd_CPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_rd_CPU.Location = New System.Drawing.Point(271, 79)
        Me.Txt_rd_CPU.Name = "Txt_rd_CPU"
        Me.Txt_rd_CPU.Size = New System.Drawing.Size(49, 22)
        Me.Txt_rd_CPU.TabIndex = 271
        Me.Txt_rd_CPU.Tag = "2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 272
        Me.Label4.Text = "0x"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 273
        Me.Label5.Text = "0x"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(247, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 274
        Me.Label6.Text = "0x"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = "0x"
        '
        'dis_loop4
        '
        Me.dis_loop4.Location = New System.Drawing.Point(302, 492)
        Me.dis_loop4.Name = "dis_loop4"
        Me.dis_loop4.Size = New System.Drawing.Size(133, 22)
        Me.dis_loop4.TabIndex = 283
        Me.dis_loop4.Text = "DISABLE LOOP 4"
        Me.dis_loop4.UseVisualStyleBackColor = True
        '
        'en_loop4
        '
        Me.en_loop4.Location = New System.Drawing.Point(160, 492)
        Me.en_loop4.Name = "en_loop4"
        Me.en_loop4.Size = New System.Drawing.Size(133, 22)
        Me.en_loop4.TabIndex = 282
        Me.en_loop4.Text = "ENABLELOOP 4"
        Me.en_loop4.UseVisualStyleBackColor = True
        '
        'dis_loop3
        '
        Me.dis_loop3.Location = New System.Drawing.Point(302, 474)
        Me.dis_loop3.Name = "dis_loop3"
        Me.dis_loop3.Size = New System.Drawing.Size(133, 22)
        Me.dis_loop3.TabIndex = 281
        Me.dis_loop3.Text = "DISABLE LOOP 3"
        Me.dis_loop3.UseVisualStyleBackColor = True
        '
        'en_loop3
        '
        Me.en_loop3.Location = New System.Drawing.Point(160, 474)
        Me.en_loop3.Name = "en_loop3"
        Me.en_loop3.Size = New System.Drawing.Size(133, 22)
        Me.en_loop3.TabIndex = 280
        Me.en_loop3.Text = "ENABLE LOOP 3"
        Me.en_loop3.UseVisualStyleBackColor = True
        '
        'dis_loop2
        '
        Me.dis_loop2.Location = New System.Drawing.Point(302, 455)
        Me.dis_loop2.Name = "dis_loop2"
        Me.dis_loop2.Size = New System.Drawing.Size(133, 22)
        Me.dis_loop2.TabIndex = 279
        Me.dis_loop2.Text = "DISABLELOOP 2"
        Me.dis_loop2.UseVisualStyleBackColor = True
        '
        'en_loop2
        '
        Me.en_loop2.Location = New System.Drawing.Point(160, 455)
        Me.en_loop2.Name = "en_loop2"
        Me.en_loop2.Size = New System.Drawing.Size(133, 22)
        Me.en_loop2.TabIndex = 278
        Me.en_loop2.Text = "ENABLE LOOP 2"
        Me.en_loop2.UseVisualStyleBackColor = True
        '
        'dis_loop1
        '
        Me.dis_loop1.Location = New System.Drawing.Point(302, 437)
        Me.dis_loop1.Name = "dis_loop1"
        Me.dis_loop1.Size = New System.Drawing.Size(133, 22)
        Me.dis_loop1.TabIndex = 277
        Me.dis_loop1.Text = "DISABLE LOOP 1"
        Me.dis_loop1.UseVisualStyleBackColor = True
        '
        'en_loop1
        '
        Me.en_loop1.Location = New System.Drawing.Point(160, 437)
        Me.en_loop1.Name = "en_loop1"
        Me.en_loop1.Size = New System.Drawing.Size(133, 22)
        Me.en_loop1.TabIndex = 276
        Me.en_loop1.Text = "ENABLE LOOP 1"
        Me.en_loop1.UseVisualStyleBackColor = True
        '
        'dis_all_relay
        '
        Me.dis_all_relay.Location = New System.Drawing.Point(219, 409)
        Me.dis_all_relay.Name = "dis_all_relay"
        Me.dis_all_relay.Size = New System.Drawing.Size(133, 22)
        Me.dis_all_relay.TabIndex = 284
        Me.dis_all_relay.Text = "Disable ALL Relays"
        Me.dis_all_relay.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(250, 141)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 22)
        Me.Button2.TabIndex = 285
        Me.Button2.Text = "SRAM Test"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Margin = New System.Windows.Forms.Padding(0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(189, 21)
        Me.Button4.TabIndex = 288
        Me.Button4.Text = "Read Volt"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(0, 373)
        Me.Button5.Margin = New System.Windows.Forms.Padding(0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(189, 20)
        Me.Button5.TabIndex = 289
        Me.Button5.Text = "Read OHM"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 183)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(85, 20)
        Me.TextBox1.TabIndex = 290
        '
        'V5_min_ohm
        '
        Me.V5_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5_min_ohm.Location = New System.Drawing.Point(73, 48)
        Me.V5_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5_min_ohm.Name = "V5_min_ohm"
        Me.V5_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5_min_ohm.TabIndex = 291
        '
        'V5_max_ohm
        '
        Me.V5_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5_max_ohm.Location = New System.Drawing.Point(131, 48)
        Me.V5_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5_max_ohm.Name = "V5_max_ohm"
        Me.V5_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5_max_ohm.TabIndex = 292
        '
        'V3_3_min_ohm
        '
        Me.V3_3_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_min_ohm.Location = New System.Drawing.Point(73, 70)
        Me.V3_3_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_min_ohm.Name = "V3_3_min_ohm"
        Me.V3_3_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_min_ohm.TabIndex = 293
        '
        'V3_3_max_ohm
        '
        Me.V3_3_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_max_ohm.Location = New System.Drawing.Point(131, 70)
        Me.V3_3_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_max_ohm.Name = "V3_3_max_ohm"
        Me.V3_3_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_max_ohm.TabIndex = 294
        '
        'VDD_MPU_min_ohm
        '
        Me.VDD_MPU_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_MPU_min_ohm.Location = New System.Drawing.Point(73, 92)
        Me.VDD_MPU_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_MPU_min_ohm.Name = "VDD_MPU_min_ohm"
        Me.VDD_MPU_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.VDD_MPU_min_ohm.TabIndex = 295
        '
        'VDD_MPU_max_ohm
        '
        Me.VDD_MPU_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_MPU_max_ohm.Location = New System.Drawing.Point(131, 92)
        Me.VDD_MPU_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_MPU_max_ohm.Name = "VDD_MPU_max_ohm"
        Me.VDD_MPU_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.VDD_MPU_max_ohm.TabIndex = 296
        '
        'V1_8A_min_ohm
        '
        Me.V1_8A_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8A_min_ohm.Location = New System.Drawing.Point(73, 114)
        Me.V1_8A_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8A_min_ohm.Name = "V1_8A_min_ohm"
        Me.V1_8A_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8A_min_ohm.TabIndex = 297
        '
        'V1_8A_max_ohm
        '
        Me.V1_8A_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8A_max_ohm.Location = New System.Drawing.Point(131, 114)
        Me.V1_8A_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8A_max_ohm.Name = "V1_8A_max_ohm"
        Me.V1_8A_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8A_max_ohm.TabIndex = 298
        '
        'V5AMinus_min_ohm
        '
        Me.V5AMinus_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5AMinus_min_ohm.Location = New System.Drawing.Point(73, 136)
        Me.V5AMinus_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5AMinus_min_ohm.Name = "V5AMinus_min_ohm"
        Me.V5AMinus_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5AMinus_min_ohm.TabIndex = 299
        Me.V5AMinus_min_ohm.Visible = False
        '
        'V5AMinus_max_ohm
        '
        Me.V5AMinus_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5AMinus_max_ohm.Location = New System.Drawing.Point(131, 136)
        Me.V5AMinus_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5AMinus_max_ohm.Name = "V5AMinus_max_ohm"
        Me.V5AMinus_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5AMinus_max_ohm.TabIndex = 300
        Me.V5AMinus_max_ohm.Visible = False
        '
        'V3_3_CPU_min_ohm
        '
        Me.V3_3_CPU_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_CPU_min_ohm.Location = New System.Drawing.Point(73, 158)
        Me.V3_3_CPU_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_CPU_min_ohm.Name = "V3_3_CPU_min_ohm"
        Me.V3_3_CPU_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_CPU_min_ohm.TabIndex = 301
        '
        'V3_3_CPU_max_ohm
        '
        Me.V3_3_CPU_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_CPU_max_ohm.Location = New System.Drawing.Point(131, 158)
        Me.V3_3_CPU_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_CPU_max_ohm.Name = "V3_3_CPU_max_ohm"
        Me.V3_3_CPU_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_CPU_max_ohm.TabIndex = 302
        '
        'V1_8FPGA_min_ohm
        '
        Me.V1_8FPGA_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8FPGA_min_ohm.Location = New System.Drawing.Point(73, 180)
        Me.V1_8FPGA_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8FPGA_min_ohm.Name = "V1_8FPGA_min_ohm"
        Me.V1_8FPGA_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8FPGA_min_ohm.TabIndex = 303
        '
        'V1_8FPGA_max_ohm
        '
        Me.V1_8FPGA_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8FPGA_max_ohm.Location = New System.Drawing.Point(131, 180)
        Me.V1_8FPGA_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8FPGA_max_ohm.Name = "V1_8FPGA_max_ohm"
        Me.V1_8FPGA_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8FPGA_max_ohm.TabIndex = 304
        '
        'V1_2_min_ohm
        '
        Me.V1_2_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_2_min_ohm.Location = New System.Drawing.Point(73, 202)
        Me.V1_2_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_2_min_ohm.Name = "V1_2_min_ohm"
        Me.V1_2_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_2_min_ohm.TabIndex = 305
        '
        'V1_2_max_ohm
        '
        Me.V1_2_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_2_max_ohm.Location = New System.Drawing.Point(131, 202)
        Me.V1_2_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_2_max_ohm.Name = "V1_2_max_ohm"
        Me.V1_2_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_2_max_ohm.TabIndex = 320
        '
        'V5A_min_ohm
        '
        Me.V5A_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5A_min_ohm.Location = New System.Drawing.Point(73, 224)
        Me.V5A_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5A_min_ohm.Name = "V5A_min_ohm"
        Me.V5A_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5A_min_ohm.TabIndex = 319
        '
        'V5A_max_ohm
        '
        Me.V5A_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5A_max_ohm.Location = New System.Drawing.Point(131, 224)
        Me.V5A_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V5A_max_ohm.Name = "V5A_max_ohm"
        Me.V5A_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V5A_max_ohm.TabIndex = 318
        '
        'V3_3A_min_ohm
        '
        Me.V3_3A_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3A_min_ohm.Location = New System.Drawing.Point(73, 246)
        Me.V3_3A_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3A_min_ohm.Name = "V3_3A_min_ohm"
        Me.V3_3A_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3A_min_ohm.TabIndex = 317
        '
        'V3_3A_max_ohm
        '
        Me.V3_3A_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3A_max_ohm.Location = New System.Drawing.Point(131, 246)
        Me.V3_3A_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3A_max_ohm.Name = "V3_3A_max_ohm"
        Me.V3_3A_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V3_3A_max_ohm.TabIndex = 316
        '
        'VDD_Core_min_ohm
        '
        Me.VDD_Core_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_Core_min_ohm.Location = New System.Drawing.Point(73, 268)
        Me.VDD_Core_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_Core_min_ohm.Name = "VDD_Core_min_ohm"
        Me.VDD_Core_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.VDD_Core_min_ohm.TabIndex = 315
        '
        'VDD_Core_max_ohm
        '
        Me.VDD_Core_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_Core_max_ohm.Location = New System.Drawing.Point(131, 268)
        Me.VDD_Core_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_Core_max_ohm.Name = "VDD_Core_max_ohm"
        Me.VDD_Core_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.VDD_Core_max_ohm.TabIndex = 314
        '
        'V1_8_min_ohm
        '
        Me.V1_8_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8_min_ohm.Location = New System.Drawing.Point(73, 290)
        Me.V1_8_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8_min_ohm.Name = "V1_8_min_ohm"
        Me.V1_8_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8_min_ohm.TabIndex = 313
        '
        'V1_8_max_ohm
        '
        Me.V1_8_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8_max_ohm.Location = New System.Drawing.Point(131, 290)
        Me.V1_8_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8_max_ohm.Name = "V1_8_max_ohm"
        Me.V1_8_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V1_8_max_ohm.TabIndex = 312
        '
        'DDR_VREF_min_ohm
        '
        Me.DDR_VREF_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DDR_VREF_min_ohm.Location = New System.Drawing.Point(73, 334)
        Me.DDR_VREF_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.DDR_VREF_min_ohm.Name = "DDR_VREF_min_ohm"
        Me.DDR_VREF_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.DDR_VREF_min_ohm.TabIndex = 311
        '
        'DDR_VREF_max_ohm
        '
        Me.DDR_VREF_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DDR_VREF_max_ohm.Location = New System.Drawing.Point(131, 334)
        Me.DDR_VREF_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.DDR_VREF_max_ohm.Name = "DDR_VREF_max_ohm"
        Me.DDR_VREF_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.DDR_VREF_max_ohm.TabIndex = 310
        '
        'FPGA_VTT_min_ohm
        '
        Me.FPGA_VTT_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FPGA_VTT_min_ohm.Location = New System.Drawing.Point(73, 312)
        Me.FPGA_VTT_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.FPGA_VTT_min_ohm.Name = "FPGA_VTT_min_ohm"
        Me.FPGA_VTT_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.FPGA_VTT_min_ohm.TabIndex = 309
        Me.FPGA_VTT_min_ohm.Visible = False
        '
        'FPGA_VTT_max_ohm
        '
        Me.FPGA_VTT_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FPGA_VTT_max_ohm.Location = New System.Drawing.Point(131, 312)
        Me.FPGA_VTT_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.FPGA_VTT_max_ohm.Name = "FPGA_VTT_max_ohm"
        Me.FPGA_VTT_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.FPGA_VTT_max_ohm.TabIndex = 308
        Me.FPGA_VTT_max_ohm.Visible = False
        '
        'V24_min_ohm
        '
        Me.V24_min_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V24_min_ohm.Location = New System.Drawing.Point(73, 26)
        Me.V24_min_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V24_min_ohm.Name = "V24_min_ohm"
        Me.V24_min_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V24_min_ohm.TabIndex = 307
        '
        'V24_max_ohm
        '
        Me.V24_max_ohm.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V24_max_ohm.Location = New System.Drawing.Point(131, 26)
        Me.V24_max_ohm.Margin = New System.Windows.Forms.Padding(0)
        Me.V24_max_ohm.Name = "V24_max_ohm"
        Me.V24_max_ohm.Size = New System.Drawing.Size(55, 20)
        Me.V24_max_ohm.TabIndex = 306
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(83, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 20)
        Me.Label9.TabIndex = 322
        Me.Label9.Text = "Min."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(139, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 20)
        Me.Label11.TabIndex = 324
        Me.Label11.Text = "Max."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'V5_ohm
        '
        Me.V5_ohm.Location = New System.Drawing.Point(0, 23)
        Me.V5_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5_ohm.Name = "V5_ohm"
        Me.V5_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V5_ohm.TabIndex = 325
        '
        'V3_3_ohm
        '
        Me.V3_3_ohm.Location = New System.Drawing.Point(0, 45)
        Me.V3_3_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3_ohm.Name = "V3_3_ohm"
        Me.V3_3_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V3_3_ohm.TabIndex = 327
        '
        'VDD_MPU_ohm
        '
        Me.VDD_MPU_ohm.Location = New System.Drawing.Point(0, 67)
        Me.VDD_MPU_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.VDD_MPU_ohm.Name = "VDD_MPU_ohm"
        Me.VDD_MPU_ohm.Size = New System.Drawing.Size(58, 20)
        Me.VDD_MPU_ohm.TabIndex = 329
        '
        'V1_8A_ohm
        '
        Me.V1_8A_ohm.Location = New System.Drawing.Point(0, 89)
        Me.V1_8A_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8A_ohm.Name = "V1_8A_ohm"
        Me.V1_8A_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V1_8A_ohm.TabIndex = 331
        '
        'V5AMinus_ohm
        '
        Me.V5AMinus_ohm.Enabled = False
        Me.V5AMinus_ohm.Location = New System.Drawing.Point(0, 111)
        Me.V5AMinus_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5AMinus_ohm.Name = "V5AMinus_ohm"
        Me.V5AMinus_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V5AMinus_ohm.TabIndex = 333
        '
        'V3_3_CPU_ohm
        '
        Me.V3_3_CPU_ohm.Location = New System.Drawing.Point(0, 133)
        Me.V3_3_CPU_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3_CPU_ohm.Name = "V3_3_CPU_ohm"
        Me.V3_3_CPU_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V3_3_CPU_ohm.TabIndex = 335
        '
        'V1_8FPGA_ohm
        '
        Me.V1_8FPGA_ohm.Location = New System.Drawing.Point(0, 155)
        Me.V1_8FPGA_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8FPGA_ohm.Name = "V1_8FPGA_ohm"
        Me.V1_8FPGA_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V1_8FPGA_ohm.TabIndex = 337
        '
        'V1_2_ohm
        '
        Me.V1_2_ohm.Location = New System.Drawing.Point(0, 177)
        Me.V1_2_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_2_ohm.Name = "V1_2_ohm"
        Me.V1_2_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V1_2_ohm.TabIndex = 339
        '
        'V5A_ohm
        '
        Me.V5A_ohm.Location = New System.Drawing.Point(0, 199)
        Me.V5A_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5A_ohm.Name = "V5A_ohm"
        Me.V5A_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V5A_ohm.TabIndex = 341
        '
        'V3_3A_ohm
        '
        Me.V3_3A_ohm.Location = New System.Drawing.Point(0, 221)
        Me.V3_3A_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3A_ohm.Name = "V3_3A_ohm"
        Me.V3_3A_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V3_3A_ohm.TabIndex = 343
        '
        'VDD_Core_ohm
        '
        Me.VDD_Core_ohm.Location = New System.Drawing.Point(0, 243)
        Me.VDD_Core_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.VDD_Core_ohm.Name = "VDD_Core_ohm"
        Me.VDD_Core_ohm.Size = New System.Drawing.Size(58, 20)
        Me.VDD_Core_ohm.TabIndex = 345
        '
        'V1_8_ohm
        '
        Me.V1_8_ohm.Location = New System.Drawing.Point(0, 265)
        Me.V1_8_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8_ohm.Name = "V1_8_ohm"
        Me.V1_8_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V1_8_ohm.TabIndex = 347
        '
        'DDR_VREF_ohm
        '
        Me.DDR_VREF_ohm.Location = New System.Drawing.Point(0, 309)
        Me.DDR_VREF_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DDR_VREF_ohm.Name = "DDR_VREF_ohm"
        Me.DDR_VREF_ohm.Size = New System.Drawing.Size(58, 20)
        Me.DDR_VREF_ohm.TabIndex = 349
        '
        'FPGA_VTT_ohm
        '
        Me.FPGA_VTT_ohm.Location = New System.Drawing.Point(0, 287)
        Me.FPGA_VTT_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.FPGA_VTT_ohm.Name = "FPGA_VTT_ohm"
        Me.FPGA_VTT_ohm.Size = New System.Drawing.Size(58, 20)
        Me.FPGA_VTT_ohm.TabIndex = 351
        Me.FPGA_VTT_ohm.Visible = False
        '
        'V24_ohm
        '
        Me.V24_ohm.Location = New System.Drawing.Point(0, 1)
        Me.V24_ohm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V24_ohm.Name = "V24_ohm"
        Me.V24_ohm.Size = New System.Drawing.Size(58, 20)
        Me.V24_ohm.TabIndex = 353
        '
        'V24_volt
        '
        Me.V24_volt.Location = New System.Drawing.Point(0, 1)
        Me.V24_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V24_volt.Name = "V24_volt"
        Me.V24_volt.Size = New System.Drawing.Size(60, 20)
        Me.V24_volt.TabIndex = 402
        '
        'FPGA_VTT_volt
        '
        Me.FPGA_VTT_volt.Location = New System.Drawing.Point(0, 287)
        Me.FPGA_VTT_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.FPGA_VTT_volt.Name = "FPGA_VTT_volt"
        Me.FPGA_VTT_volt.Size = New System.Drawing.Size(60, 20)
        Me.FPGA_VTT_volt.TabIndex = 401
        '
        'DDR_VREF_volt
        '
        Me.DDR_VREF_volt.Location = New System.Drawing.Point(0, 309)
        Me.DDR_VREF_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DDR_VREF_volt.Name = "DDR_VREF_volt"
        Me.DDR_VREF_volt.Size = New System.Drawing.Size(60, 20)
        Me.DDR_VREF_volt.TabIndex = 400
        '
        'V1_8_volt
        '
        Me.V1_8_volt.Location = New System.Drawing.Point(0, 265)
        Me.V1_8_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8_volt.Name = "V1_8_volt"
        Me.V1_8_volt.Size = New System.Drawing.Size(60, 20)
        Me.V1_8_volt.TabIndex = 399
        '
        'VDD_Core_volt
        '
        Me.VDD_Core_volt.Location = New System.Drawing.Point(0, 243)
        Me.VDD_Core_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.VDD_Core_volt.Name = "VDD_Core_volt"
        Me.VDD_Core_volt.Size = New System.Drawing.Size(60, 20)
        Me.VDD_Core_volt.TabIndex = 398
        '
        'V3_3A_volt
        '
        Me.V3_3A_volt.Location = New System.Drawing.Point(0, 221)
        Me.V3_3A_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3A_volt.Name = "V3_3A_volt"
        Me.V3_3A_volt.Size = New System.Drawing.Size(60, 20)
        Me.V3_3A_volt.TabIndex = 397
        '
        'V5A_volt
        '
        Me.V5A_volt.Location = New System.Drawing.Point(0, 199)
        Me.V5A_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5A_volt.Name = "V5A_volt"
        Me.V5A_volt.Size = New System.Drawing.Size(60, 20)
        Me.V5A_volt.TabIndex = 396
        '
        'V1_2_volt
        '
        Me.V1_2_volt.Location = New System.Drawing.Point(0, 177)
        Me.V1_2_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_2_volt.Name = "V1_2_volt"
        Me.V1_2_volt.Size = New System.Drawing.Size(60, 20)
        Me.V1_2_volt.TabIndex = 395
        '
        'V1_8FPGA_volt
        '
        Me.V1_8FPGA_volt.Location = New System.Drawing.Point(0, 155)
        Me.V1_8FPGA_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8FPGA_volt.Name = "V1_8FPGA_volt"
        Me.V1_8FPGA_volt.Size = New System.Drawing.Size(60, 20)
        Me.V1_8FPGA_volt.TabIndex = 394
        '
        'V3_3_CPU_volt
        '
        Me.V3_3_CPU_volt.Location = New System.Drawing.Point(0, 133)
        Me.V3_3_CPU_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3_CPU_volt.Name = "V3_3_CPU_volt"
        Me.V3_3_CPU_volt.Size = New System.Drawing.Size(60, 20)
        Me.V3_3_CPU_volt.TabIndex = 393
        '
        'V5AMinus_volt
        '
        Me.V5AMinus_volt.Location = New System.Drawing.Point(0, 111)
        Me.V5AMinus_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5AMinus_volt.Name = "V5AMinus_volt"
        Me.V5AMinus_volt.Size = New System.Drawing.Size(60, 20)
        Me.V5AMinus_volt.TabIndex = 392
        '
        'V1_8A_volt
        '
        Me.V1_8A_volt.Location = New System.Drawing.Point(0, 89)
        Me.V1_8A_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V1_8A_volt.Name = "V1_8A_volt"
        Me.V1_8A_volt.Size = New System.Drawing.Size(60, 20)
        Me.V1_8A_volt.TabIndex = 391
        '
        'VDD_MPU_volt
        '
        Me.VDD_MPU_volt.Location = New System.Drawing.Point(0, 67)
        Me.VDD_MPU_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.VDD_MPU_volt.Name = "VDD_MPU_volt"
        Me.VDD_MPU_volt.Size = New System.Drawing.Size(60, 20)
        Me.VDD_MPU_volt.TabIndex = 390
        '
        'V3_3_volt
        '
        Me.V3_3_volt.Location = New System.Drawing.Point(0, 45)
        Me.V3_3_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V3_3_volt.Name = "V3_3_volt"
        Me.V3_3_volt.Size = New System.Drawing.Size(60, 20)
        Me.V3_3_volt.TabIndex = 389
        '
        'V5_volt
        '
        Me.V5_volt.Location = New System.Drawing.Point(0, 23)
        Me.V5_volt.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.V5_volt.Name = "V5_volt"
        Me.V5_volt.Size = New System.Drawing.Size(60, 20)
        Me.V5_volt.TabIndex = 388
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(333, 4)
        Me.Label33.Margin = New System.Windows.Forms.Padding(0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(42, 20)
        Me.Label33.TabIndex = 387
        Me.Label33.Text = "Max."
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(277, 4)
        Me.Label35.Margin = New System.Windows.Forms.Padding(0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(38, 20)
        Me.Label35.TabIndex = 385
        Me.Label35.Text = "Min."
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DDR_VREF_max_volt
        '
        Me.DDR_VREF_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DDR_VREF_max_volt.Location = New System.Drawing.Point(325, 334)
        Me.DDR_VREF_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.DDR_VREF_max_volt.Name = "DDR_VREF_max_volt"
        Me.DDR_VREF_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.DDR_VREF_max_volt.TabIndex = 384
        '
        'V3_3_min_volt
        '
        Me.V3_3_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_min_volt.Location = New System.Drawing.Point(267, 70)
        Me.V3_3_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_min_volt.Name = "V3_3_min_volt"
        Me.V3_3_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_min_volt.TabIndex = 383
        '
        'V3_3_max_volt
        '
        Me.V3_3_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_max_volt.Location = New System.Drawing.Point(325, 70)
        Me.V3_3_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_max_volt.Name = "V3_3_max_volt"
        Me.V3_3_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_max_volt.TabIndex = 382
        '
        'VDD_MPU_min_volt
        '
        Me.VDD_MPU_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_MPU_min_volt.Location = New System.Drawing.Point(267, 92)
        Me.VDD_MPU_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_MPU_min_volt.Name = "VDD_MPU_min_volt"
        Me.VDD_MPU_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.VDD_MPU_min_volt.TabIndex = 381
        '
        'VDD_MPU_max_volt
        '
        Me.VDD_MPU_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_MPU_max_volt.Location = New System.Drawing.Point(325, 92)
        Me.VDD_MPU_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_MPU_max_volt.Name = "VDD_MPU_max_volt"
        Me.VDD_MPU_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.VDD_MPU_max_volt.TabIndex = 380
        '
        'V1_8A_min_volt
        '
        Me.V1_8A_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8A_min_volt.Location = New System.Drawing.Point(267, 114)
        Me.V1_8A_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8A_min_volt.Name = "V1_8A_min_volt"
        Me.V1_8A_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8A_min_volt.TabIndex = 379
        '
        'V1_8A_max_volt
        '
        Me.V1_8A_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8A_max_volt.Location = New System.Drawing.Point(325, 114)
        Me.V1_8A_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8A_max_volt.Name = "V1_8A_max_volt"
        Me.V1_8A_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8A_max_volt.TabIndex = 378
        '
        'V5AMinus_min_volt
        '
        Me.V5AMinus_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5AMinus_min_volt.Location = New System.Drawing.Point(267, 136)
        Me.V5AMinus_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5AMinus_min_volt.Name = "V5AMinus_min_volt"
        Me.V5AMinus_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5AMinus_min_volt.TabIndex = 377
        '
        'V5AMinus_max_volt
        '
        Me.V5AMinus_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5AMinus_max_volt.Location = New System.Drawing.Point(325, 136)
        Me.V5AMinus_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5AMinus_max_volt.Name = "V5AMinus_max_volt"
        Me.V5AMinus_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5AMinus_max_volt.TabIndex = 376
        '
        'V3_3_CPU_min_volt
        '
        Me.V3_3_CPU_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_CPU_min_volt.Location = New System.Drawing.Point(267, 158)
        Me.V3_3_CPU_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_CPU_min_volt.Name = "V3_3_CPU_min_volt"
        Me.V3_3_CPU_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_CPU_min_volt.TabIndex = 375
        '
        'V3_3_CPU_max_volt
        '
        Me.V3_3_CPU_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3_CPU_max_volt.Location = New System.Drawing.Point(325, 158)
        Me.V3_3_CPU_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3_CPU_max_volt.Name = "V3_3_CPU_max_volt"
        Me.V3_3_CPU_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3_CPU_max_volt.TabIndex = 374
        '
        'V5_min_volt
        '
        Me.V5_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5_min_volt.Location = New System.Drawing.Point(267, 48)
        Me.V5_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5_min_volt.Name = "V5_min_volt"
        Me.V5_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5_min_volt.TabIndex = 373
        '
        'V5_max_volt
        '
        Me.V5_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5_max_volt.Location = New System.Drawing.Point(325, 48)
        Me.V5_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5_max_volt.Name = "V5_max_volt"
        Me.V5_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5_max_volt.TabIndex = 372
        '
        'FPGA_VTT_min_volt
        '
        Me.FPGA_VTT_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FPGA_VTT_min_volt.Location = New System.Drawing.Point(267, 312)
        Me.FPGA_VTT_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.FPGA_VTT_min_volt.Name = "FPGA_VTT_min_volt"
        Me.FPGA_VTT_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.FPGA_VTT_min_volt.TabIndex = 371
        '
        'FPGA_VTT_max_volt
        '
        Me.FPGA_VTT_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FPGA_VTT_max_volt.Location = New System.Drawing.Point(325, 312)
        Me.FPGA_VTT_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.FPGA_VTT_max_volt.Name = "FPGA_VTT_max_volt"
        Me.FPGA_VTT_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.FPGA_VTT_max_volt.TabIndex = 370
        '
        'DDR_VREF_min_volt
        '
        Me.DDR_VREF_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DDR_VREF_min_volt.Location = New System.Drawing.Point(267, 334)
        Me.DDR_VREF_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.DDR_VREF_min_volt.Name = "DDR_VREF_min_volt"
        Me.DDR_VREF_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.DDR_VREF_min_volt.TabIndex = 369
        '
        'V1_8_max_volt
        '
        Me.V1_8_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8_max_volt.Location = New System.Drawing.Point(325, 290)
        Me.V1_8_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8_max_volt.Name = "V1_8_max_volt"
        Me.V1_8_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8_max_volt.TabIndex = 368
        '
        'V1_8_min_volt
        '
        Me.V1_8_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8_min_volt.Location = New System.Drawing.Point(267, 290)
        Me.V1_8_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8_min_volt.Name = "V1_8_min_volt"
        Me.V1_8_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8_min_volt.TabIndex = 367
        '
        'VDD_Core_max_volt
        '
        Me.VDD_Core_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_Core_max_volt.Location = New System.Drawing.Point(325, 268)
        Me.VDD_Core_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_Core_max_volt.Name = "VDD_Core_max_volt"
        Me.VDD_Core_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.VDD_Core_max_volt.TabIndex = 366
        '
        'VDD_Core_min_volt
        '
        Me.VDD_Core_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VDD_Core_min_volt.Location = New System.Drawing.Point(267, 268)
        Me.VDD_Core_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.VDD_Core_min_volt.Name = "VDD_Core_min_volt"
        Me.VDD_Core_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.VDD_Core_min_volt.TabIndex = 365
        '
        'V3_3A_max_volt
        '
        Me.V3_3A_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3A_max_volt.Location = New System.Drawing.Point(325, 246)
        Me.V3_3A_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3A_max_volt.Name = "V3_3A_max_volt"
        Me.V3_3A_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3A_max_volt.TabIndex = 364
        '
        'V3_3A_min_volt
        '
        Me.V3_3A_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V3_3A_min_volt.Location = New System.Drawing.Point(267, 246)
        Me.V3_3A_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V3_3A_min_volt.Name = "V3_3A_min_volt"
        Me.V3_3A_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V3_3A_min_volt.TabIndex = 363
        '
        'V5A_max_volt
        '
        Me.V5A_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5A_max_volt.Location = New System.Drawing.Point(325, 224)
        Me.V5A_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5A_max_volt.Name = "V5A_max_volt"
        Me.V5A_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5A_max_volt.TabIndex = 362
        '
        'V5A_min_volt
        '
        Me.V5A_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V5A_min_volt.Location = New System.Drawing.Point(267, 224)
        Me.V5A_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V5A_min_volt.Name = "V5A_min_volt"
        Me.V5A_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V5A_min_volt.TabIndex = 361
        '
        'V1_2_max_volt
        '
        Me.V1_2_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_2_max_volt.Location = New System.Drawing.Point(325, 202)
        Me.V1_2_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_2_max_volt.Name = "V1_2_max_volt"
        Me.V1_2_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_2_max_volt.TabIndex = 360
        '
        'V1_2_min_volt
        '
        Me.V1_2_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_2_min_volt.Location = New System.Drawing.Point(267, 202)
        Me.V1_2_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_2_min_volt.Name = "V1_2_min_volt"
        Me.V1_2_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_2_min_volt.TabIndex = 359
        '
        'V1_8FPGA_max_volt
        '
        Me.V1_8FPGA_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8FPGA_max_volt.Location = New System.Drawing.Point(325, 180)
        Me.V1_8FPGA_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8FPGA_max_volt.Name = "V1_8FPGA_max_volt"
        Me.V1_8FPGA_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8FPGA_max_volt.TabIndex = 358
        '
        'V1_8FPGA_min_volt
        '
        Me.V1_8FPGA_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V1_8FPGA_min_volt.Location = New System.Drawing.Point(267, 180)
        Me.V1_8FPGA_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V1_8FPGA_min_volt.Name = "V1_8FPGA_min_volt"
        Me.V1_8FPGA_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V1_8FPGA_min_volt.TabIndex = 357
        '
        'V24_min_volt
        '
        Me.V24_min_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V24_min_volt.Location = New System.Drawing.Point(267, 26)
        Me.V24_min_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V24_min_volt.Name = "V24_min_volt"
        Me.V24_min_volt.Size = New System.Drawing.Size(55, 20)
        Me.V24_min_volt.TabIndex = 356
        '
        'V24_max_volt
        '
        Me.V24_max_volt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.V24_max_volt.Location = New System.Drawing.Point(325, 26)
        Me.V24_max_volt.Margin = New System.Windows.Forms.Padding(0)
        Me.V24_max_volt.Name = "V24_max_volt"
        Me.V24_max_volt.Size = New System.Drawing.Size(55, 20)
        Me.V24_max_volt.TabIndex = 355
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(23, 29)
        Me.Label51.Margin = New System.Windows.Forms.Padding(0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(26, 13)
        Me.Label51.TabIndex = 420
        Me.Label51.Text = "V24"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(26, 51)
        Me.Label53.Margin = New System.Windows.Forms.Padding(0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(20, 13)
        Me.Label53.TabIndex = 421
        Me.Label53.Text = "V5"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(20, 73)
        Me.Label54.Margin = New System.Windows.Forms.Padding(0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(32, 13)
        Me.Label54.TabIndex = 422
        Me.Label54.Text = "V3_3"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(6, 95)
        Me.Label55.Margin = New System.Windows.Forms.Padding(0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(60, 13)
        Me.Label55.TabIndex = 423
        Me.Label55.Text = "VDD_MPU"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(16, 117)
        Me.Label56.Margin = New System.Windows.Forms.Padding(0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(39, 13)
        Me.Label56.TabIndex = 424
        Me.Label56.Text = "V1_8A"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(19, 227)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(33, 13)
        Me.Label57.TabIndex = 429
        Me.Label57.Text = "V5A+"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(20, 205)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(32, 13)
        Me.Label58.TabIndex = 428
        Me.Label58.Text = "V1_2"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(6, 183)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(60, 13)
        Me.Label59.TabIndex = 427
        Me.Label59.Text = "V1_8FPGA"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(6, 161)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(60, 13)
        Me.Label60.TabIndex = 426
        Me.Label60.Text = "V3_3_CPU"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(21, 139)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(30, 13)
        Me.Label61.TabIndex = 425
        Me.Label61.Text = "V5A-"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(5, 315)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(62, 13)
        Me.Label62.TabIndex = 434
        Me.Label62.Text = "FPGA_VTT"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(6, 339)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(65, 13)
        Me.Label63.TabIndex = 433
        Me.Label63.Text = "DDR_VREF"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(20, 293)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(32, 13)
        Me.Label64.TabIndex = 432
        Me.Label64.Text = "V1_8"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(7, 271)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(58, 13)
        Me.Label65.TabIndex = 431
        Me.Label65.Text = "VDD_Core"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(16, 249)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(39, 13)
        Me.Label66.TabIndex = 430
        Me.Label66.Text = "V3_3A"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(106, 41)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(120, 23)
        Me.Button7.TabIndex = 437
        Me.Button7.Text = "CLOSE COM Port"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(106, 17)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(120, 23)
        Me.Button8.TabIndex = 436
        Me.Button8.Text = "Open COM Port"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'cb_UUT_COM
        '
        Me.cb_UUT_COM.FormattingEnabled = True
        Me.cb_UUT_COM.Location = New System.Drawing.Point(233, 19)
        Me.cb_UUT_COM.Name = "cb_UUT_COM"
        Me.cb_UUT_COM.Size = New System.Drawing.Size(70, 21)
        Me.cb_UUT_COM.TabIndex = 435
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button34)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Controls.Add(Me.cb_UUT_COM)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(817, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(312, 76)
        Me.GroupBox4.TabIndex = 440
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "RPP4 Serial Port"
        '
        'Button34
        '
        Me.Button34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button34.Location = New System.Drawing.Point(6, 18)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(94, 46)
        Me.Button34.TabIndex = 438
        Me.Button34.Text = "Power ON and Get Ports"
        Me.Button34.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(976, 460)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(570, 448)
        Me.RichTextBox1.TabIndex = 441
        Me.RichTextBox1.Text = ""
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button45.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button45.Location = New System.Drawing.Point(1586, 869)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(186, 30)
        Me.Button45.TabIndex = 476
        Me.Button45.Text = "Check IP Address"
        Me.Button45.UseVisualStyleBackColor = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(2, 79)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(48, 20)
        Me.Label67.TabIndex = 478
        Me.Label67.Text = "MAC:"
        '
        'fpga_ver
        '
        Me.fpga_ver.Location = New System.Drawing.Point(139, 627)
        Me.fpga_ver.Name = "fpga_ver"
        Me.fpga_ver.Size = New System.Drawing.Size(83, 20)
        Me.fpga_ver.TabIndex = 492
        '
        'LED_15_on_check
        '
        Me.LED_15_on_check.AutoSize = True
        Me.LED_15_on_check.Location = New System.Drawing.Point(13, 41)
        Me.LED_15_on_check.Name = "LED_15_on_check"
        Me.LED_15_on_check.Size = New System.Drawing.Size(98, 17)
        Me.LED_15_on_check.TabIndex = 497
        Me.LED_15_on_check.Text = "LED D15 = ON"
        Me.LED_15_on_check.UseVisualStyleBackColor = True
        '
        'moisture_test
        '
        Me.moisture_test.AutoSize = True
        Me.moisture_test.Location = New System.Drawing.Point(13, 169)
        Me.moisture_test.Name = "moisture_test"
        Me.moisture_test.Size = New System.Drawing.Size(128, 17)
        Me.moisture_test.TabIndex = 502
        Me.moisture_test.Text = "Moisture Test Passed"
        Me.moisture_test.UseVisualStyleBackColor = True
        '
        'LED7_blinking_check
        '
        Me.LED7_blinking_check.AutoSize = True
        Me.LED7_blinking_check.Location = New System.Drawing.Point(117, 40)
        Me.LED7_blinking_check.Name = "LED7_blinking_check"
        Me.LED7_blinking_check.Size = New System.Drawing.Size(113, 17)
        Me.LED7_blinking_check.TabIndex = 503
        Me.LED7_blinking_check.Text = "LED D7 = Blinking"
        Me.LED7_blinking_check.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(15, 629)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(38, 15)
        Me.Label74.TabIndex = 504
        Me.Label74.Text = "FPGA"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(15, 651)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(35, 15)
        Me.Label75.TabIndex = 505
        Me.Label75.Text = "Build"
        '
        'build_ver
        '
        Me.build_ver.Location = New System.Drawing.Point(139, 650)
        Me.build_ver.Name = "build_ver"
        Me.build_ver.Size = New System.Drawing.Size(83, 20)
        Me.build_ver.TabIndex = 506
        '
        'tb_ProgrammedMAC
        '
        Me.tb_ProgrammedMAC.Location = New System.Drawing.Point(69, 405)
        Me.tb_ProgrammedMAC.Name = "tb_ProgrammedMAC"
        Me.tb_ProgrammedMAC.Size = New System.Drawing.Size(155, 20)
        Me.tb_ProgrammedMAC.TabIndex = 508
        '
        'Button47
        '
        Me.Button47.Location = New System.Drawing.Point(399, 469)
        Me.Button47.Name = "Button47"
        Me.Button47.Size = New System.Drawing.Size(189, 27)
        Me.Button47.TabIndex = 509
        Me.Button47.Text = "Read MAC Address"
        Me.Button47.UseVisualStyleBackColor = True
        '
        'Button42
        '
        Me.Button42.Location = New System.Drawing.Point(58, 383)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(173, 28)
        Me.Button42.TabIndex = 510
        Me.Button42.Text = "Test Ohms"
        Me.Button42.UseVisualStyleBackColor = True
        '
        'Button43
        '
        Me.Button43.Location = New System.Drawing.Point(316, 380)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(183, 28)
        Me.Button43.TabIndex = 511
        Me.Button43.Text = "Test Voltages"
        Me.Button43.UseVisualStyleBackColor = True
        '
        'Button46
        '
        Me.Button46.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button46.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button46.Location = New System.Drawing.Point(14, 7)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(212, 35)
        Me.Button46.TabIndex = 513
        Me.Button46.Text = "Read Temperatures"
        Me.Button46.UseVisualStyleBackColor = False
        '
        'ip_txt
        '
        Me.ip_txt.Location = New System.Drawing.Point(69, 428)
        Me.ip_txt.Name = "ip_txt"
        Me.ip_txt.Size = New System.Drawing.Size(155, 20)
        Me.ip_txt.TabIndex = 515
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.Location = New System.Drawing.Point(202, 49)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(15, 15)
        Me.Label81.TabIndex = 528
        Me.Label81.Text = "C"
        '
        'T1
        '
        Me.T1.Location = New System.Drawing.Point(160, 48)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(40, 20)
        Me.T1.TabIndex = 527
        Me.T1.Text = "0"
        '
        'T4
        '
        Me.T4.Location = New System.Drawing.Point(160, 127)
        Me.T4.Name = "T4"
        Me.T4.Size = New System.Drawing.Size(40, 20)
        Me.T4.TabIndex = 526
        Me.T4.Text = "0"
        '
        'T3
        '
        Me.T3.Location = New System.Drawing.Point(160, 100)
        Me.T3.Name = "T3"
        Me.T3.Size = New System.Drawing.Size(40, 20)
        Me.T3.TabIndex = 525
        Me.T3.Text = "0"
        '
        'T2
        '
        Me.T2.Location = New System.Drawing.Point(160, 74)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(40, 20)
        Me.T2.TabIndex = 524
        Me.T2.Text = "0"
        '
        'T3_min
        '
        Me.T3_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T3_min.Location = New System.Drawing.Point(76, 100)
        Me.T3_min.Name = "T3_min"
        Me.T3_min.Size = New System.Drawing.Size(34, 20)
        Me.T3_min.TabIndex = 523
        Me.T3_min.Text = "20"
        '
        'T3_max
        '
        Me.T3_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T3_max.Location = New System.Drawing.Point(116, 100)
        Me.T3_max.Name = "T3_max"
        Me.T3_max.Size = New System.Drawing.Size(38, 20)
        Me.T3_max.TabIndex = 522
        Me.T3_max.Text = "42"
        '
        'T4_min
        '
        Me.T4_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T4_min.Location = New System.Drawing.Point(76, 127)
        Me.T4_min.Name = "T4_min"
        Me.T4_min.Size = New System.Drawing.Size(34, 20)
        Me.T4_min.TabIndex = 521
        Me.T4_min.Text = "20"
        '
        'T4_max
        '
        Me.T4_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T4_max.Location = New System.Drawing.Point(116, 127)
        Me.T4_max.Name = "T4_max"
        Me.T4_max.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.T4_max.Size = New System.Drawing.Size(38, 20)
        Me.T4_max.TabIndex = 520
        Me.T4_max.Text = "42"
        '
        'T2_min
        '
        Me.T2_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T2_min.Location = New System.Drawing.Point(76, 74)
        Me.T2_min.Name = "T2_min"
        Me.T2_min.Size = New System.Drawing.Size(34, 20)
        Me.T2_min.TabIndex = 519
        Me.T2_min.Text = "20"
        '
        'T2_max
        '
        Me.T2_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T2_max.Location = New System.Drawing.Point(116, 74)
        Me.T2_max.Name = "T2_max"
        Me.T2_max.Size = New System.Drawing.Size(38, 20)
        Me.T2_max.TabIndex = 518
        Me.T2_max.Text = "42"
        '
        'T1_min
        '
        Me.T1_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T1_min.Location = New System.Drawing.Point(76, 48)
        Me.T1_min.Name = "T1_min"
        Me.T1_min.Size = New System.Drawing.Size(34, 20)
        Me.T1_min.TabIndex = 517
        Me.T1_min.Text = "20"
        '
        'T1_max
        '
        Me.T1_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T1_max.Location = New System.Drawing.Point(116, 48)
        Me.T1_max.Name = "T1_max"
        Me.T1_max.Size = New System.Drawing.Size(38, 20)
        Me.T1_max.TabIndex = 516
        Me.T1_max.Text = "42"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(202, 128)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(15, 15)
        Me.Label78.TabIndex = 529
        Me.Label78.Text = "C"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(202, 101)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(15, 15)
        Me.Label79.TabIndex = 530
        Me.Label79.Text = "C"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(202, 75)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(15, 15)
        Me.Label80.TabIndex = 531
        Me.Label80.Text = "C"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(21, 49)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(49, 15)
        Me.Label82.TabIndex = 532
        Me.Label82.Text = "Temp 1"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.Location = New System.Drawing.Point(21, 101)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(49, 15)
        Me.Label83.TabIndex = 533
        Me.Label83.Text = "Temp 3"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.Location = New System.Drawing.Point(21, 75)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(49, 15)
        Me.Label84.TabIndex = 534
        Me.Label84.Text = "Temp 2"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(21, 128)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(49, 15)
        Me.Label85.TabIndex = 535
        Me.Label85.Text = "Temp 4"
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(0, 150)
        Me.Button13.Margin = New System.Windows.Forms.Padding(0)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(100, 25)
        Me.Button13.TabIndex = 536
        Me.Button13.Text = "t"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.Location = New System.Drawing.Point(1587, 799)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(183, 35)
        Me.Button16.TabIndex = 537
        Me.Button16.Text = "Check Versions"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'btn_ProgramFPGA
        '
        Me.btn_ProgramFPGA.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_ProgramFPGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ProgramFPGA.Location = New System.Drawing.Point(12, 500)
        Me.btn_ProgramFPGA.Name = "btn_ProgramFPGA"
        Me.btn_ProgramFPGA.Size = New System.Drawing.Size(212, 35)
        Me.btn_ProgramFPGA.TabIndex = 539
        Me.btn_ProgramFPGA.Text = "Program FPGA (Xilinx)"
        Me.btn_ProgramFPGA.UseVisualStyleBackColor = False
        '
        'FPGA_ver_value
        '
        Me.FPGA_ver_value.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FPGA_ver_value.Location = New System.Drawing.Point(69, 627)
        Me.FPGA_ver_value.Name = "FPGA_ver_value"
        Me.FPGA_ver_value.Size = New System.Drawing.Size(67, 20)
        Me.FPGA_ver_value.TabIndex = 540
        Me.FPGA_ver_value.Text = "x"
        '
        'build_ver_value
        '
        Me.build_ver_value.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.build_ver_value.Location = New System.Drawing.Point(69, 650)
        Me.build_ver_value.Name = "build_ver_value"
        Me.build_ver_value.Size = New System.Drawing.Size(67, 20)
        Me.build_ver_value.TabIndex = 541
        Me.build_ver_value.Text = "x"
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button19.Location = New System.Drawing.Point(14, 423)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(212, 35)
        Me.Button19.TabIndex = 546
        Me.Button19.Text = "Test RTD (J18)"
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.Location = New System.Drawing.Point(203, 524)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(84, 15)
        Me.Label92.TabIndex = 556
        Me.Label92.Text = "RTD 110 ohm"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.Location = New System.Drawing.Point(204, 474)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(63, 15)
        Me.Label93.TabIndex = 555
        Me.Label93.Text = "RTD open"
        '
        'RTD_cur_open
        '
        Me.RTD_cur_open.Location = New System.Drawing.Point(155, 461)
        Me.RTD_cur_open.Name = "RTD_cur_open"
        Me.RTD_cur_open.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_open.TabIndex = 552
        Me.RTD_cur_open.Text = "0"
        '
        'RTD_cur_110
        '
        Me.RTD_cur_110.Location = New System.Drawing.Point(155, 512)
        Me.RTD_cur_110.Name = "RTD_cur_110"
        Me.RTD_cur_110.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_110.TabIndex = 551
        Me.RTD_cur_110.Text = "0"
        '
        'RTD_cur_110_min
        '
        Me.RTD_cur_110_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_cur_110_min.Location = New System.Drawing.Point(64, 512)
        Me.RTD_cur_110_min.Name = "RTD_cur_110_min"
        Me.RTD_cur_110_min.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_110_min.TabIndex = 550
        Me.RTD_cur_110_min.Text = "B00"
        '
        'RTD_cur_110_max
        '
        Me.RTD_cur_110_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_cur_110_max.Location = New System.Drawing.Point(110, 512)
        Me.RTD_cur_110_max.Name = "RTD_cur_110_max"
        Me.RTD_cur_110_max.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_110_max.TabIndex = 549
        Me.RTD_cur_110_max.Text = "CFF"
        '
        'RTD_cur_open_min
        '
        Me.RTD_cur_open_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_cur_open_min.Location = New System.Drawing.Point(64, 461)
        Me.RTD_cur_open_min.Name = "RTD_cur_open_min"
        Me.RTD_cur_open_min.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_open_min.TabIndex = 548
        Me.RTD_cur_open_min.Text = "7000"
        '
        'RTD_cur_open_max
        '
        Me.RTD_cur_open_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_cur_open_max.Location = New System.Drawing.Point(109, 461)
        Me.RTD_cur_open_max.Name = "RTD_cur_open_max"
        Me.RTD_cur_open_max.Size = New System.Drawing.Size(40, 20)
        Me.RTD_cur_open_max.TabIndex = 547
        Me.RTD_cur_open_max.Text = "7FFF"
        '
        'RTD_sense_open
        '
        Me.RTD_sense_open.Location = New System.Drawing.Point(155, 484)
        Me.RTD_sense_open.Name = "RTD_sense_open"
        Me.RTD_sense_open.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_open.TabIndex = 559
        Me.RTD_sense_open.Text = "0"
        '
        'RTD_sense_open_min
        '
        Me.RTD_sense_open_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_sense_open_min.Location = New System.Drawing.Point(64, 484)
        Me.RTD_sense_open_min.Name = "RTD_sense_open_min"
        Me.RTD_sense_open_min.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_open_min.TabIndex = 558
        Me.RTD_sense_open_min.Text = "2000"
        '
        'RTD_sense_open_max
        '
        Me.RTD_sense_open_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_sense_open_max.Location = New System.Drawing.Point(109, 484)
        Me.RTD_sense_open_max.Name = "RTD_sense_open_max"
        Me.RTD_sense_open_max.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_open_max.TabIndex = 557
        Me.RTD_sense_open_max.Text = "2D00"
        '
        'RTD_sense_110
        '
        Me.RTD_sense_110.Location = New System.Drawing.Point(155, 535)
        Me.RTD_sense_110.Name = "RTD_sense_110"
        Me.RTD_sense_110.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_110.TabIndex = 562
        Me.RTD_sense_110.Text = "0"
        '
        'RTD_sense_110_min
        '
        Me.RTD_sense_110_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_sense_110_min.Location = New System.Drawing.Point(64, 535)
        Me.RTD_sense_110_min.Name = "RTD_sense_110_min"
        Me.RTD_sense_110_min.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_110_min.TabIndex = 561
        Me.RTD_sense_110_min.Text = "B00"
        '
        'RTD_sense_110_max
        '
        Me.RTD_sense_110_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RTD_sense_110_max.Location = New System.Drawing.Point(110, 535)
        Me.RTD_sense_110_max.Name = "RTD_sense_110_max"
        Me.RTD_sense_110_max.Size = New System.Drawing.Size(40, 20)
        Me.RTD_sense_110_max.TabIndex = 560
        Me.RTD_sense_110_max.Text = "CFF"
        '
        'Cur
        '
        Me.Cur.AutoSize = True
        Me.Cur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cur.Location = New System.Drawing.Point(29, 462)
        Me.Cur.Name = "Cur"
        Me.Cur.Size = New System.Drawing.Size(29, 15)
        Me.Cur.TabIndex = 563
        Me.Cur.Text = "Cur."
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.Location = New System.Drawing.Point(11, 485)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(47, 15)
        Me.Label91.TabIndex = 565
        Me.Label91.Text = "P_SEN"
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(609, 209)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(130, 41)
        Me.Button20.TabIndex = 567
        Me.Button20.Text = "Boot Linux"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button23.Location = New System.Drawing.Point(14, 178)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(212, 35)
        Me.Button23.TabIndex = 570
        Me.Button23.Text = "Test 4 mA / 20 mA Loops"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(192, 221)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(75, 16)
        Me.Label89.TabIndex = 577
        Me.Label89.Text = "Loop1 4mA"
        '
        'L1_20ma
        '
        Me.L1_20ma.Location = New System.Drawing.Point(1, 22)
        Me.L1_20ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L1_20ma.Name = "L1_20ma"
        Me.L1_20ma.Size = New System.Drawing.Size(50, 20)
        Me.L1_20ma.TabIndex = 576
        Me.L1_20ma.Text = "0"
        '
        'L1_min_20ma
        '
        Me.L1_min_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L1_min_20ma.Location = New System.Drawing.Point(32, 241)
        Me.L1_min_20ma.Name = "L1_min_20ma"
        Me.L1_min_20ma.Size = New System.Drawing.Size(44, 20)
        Me.L1_min_20ma.TabIndex = 575
        Me.L1_min_20ma.Text = "5000"
        '
        'L1_max_20ma
        '
        Me.L1_max_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L1_max_20ma.Location = New System.Drawing.Point(82, 241)
        Me.L1_max_20ma.Name = "L1_max_20ma"
        Me.L1_max_20ma.Size = New System.Drawing.Size(48, 20)
        Me.L1_max_20ma.TabIndex = 574
        Me.L1_max_20ma.Text = "7000"
        '
        'L1_4ma
        '
        Me.L1_4ma.Location = New System.Drawing.Point(1, 1)
        Me.L1_4ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L1_4ma.Name = "L1_4ma"
        Me.L1_4ma.Size = New System.Drawing.Size(50, 20)
        Me.L1_4ma.TabIndex = 573
        Me.L1_4ma.Text = "0"
        '
        'L1_min_4ma
        '
        Me.L1_min_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L1_min_4ma.Location = New System.Drawing.Point(32, 220)
        Me.L1_min_4ma.Name = "L1_min_4ma"
        Me.L1_min_4ma.Size = New System.Drawing.Size(44, 20)
        Me.L1_min_4ma.TabIndex = 572
        Me.L1_min_4ma.Text = "2500"
        '
        'L1_max_4ma
        '
        Me.L1_max_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L1_max_4ma.Location = New System.Drawing.Point(82, 220)
        Me.L1_max_4ma.Name = "L1_max_4ma"
        Me.L1_max_4ma.Size = New System.Drawing.Size(48, 20)
        Me.L1_max_4ma.TabIndex = 571
        Me.L1_max_4ma.Text = "3000"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(192, 242)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(82, 16)
        Me.Label88.TabIndex = 578
        Me.Label88.Text = "Loop1 20mA"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(191, 285)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(82, 16)
        Me.Label95.TabIndex = 586
        Me.Label95.Text = "Loop2 20mA"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.Location = New System.Drawing.Point(192, 263)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(75, 16)
        Me.Label96.TabIndex = 585
        Me.Label96.Text = "Loop2 4mA"
        '
        'L2_20ma
        '
        Me.L2_20ma.Location = New System.Drawing.Point(1, 64)
        Me.L2_20ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L2_20ma.Name = "L2_20ma"
        Me.L2_20ma.Size = New System.Drawing.Size(50, 20)
        Me.L2_20ma.TabIndex = 584
        Me.L2_20ma.Text = "0"
        '
        'L2_min_20ma
        '
        Me.L2_min_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L2_min_20ma.Location = New System.Drawing.Point(32, 284)
        Me.L2_min_20ma.Name = "L2_min_20ma"
        Me.L2_min_20ma.Size = New System.Drawing.Size(44, 20)
        Me.L2_min_20ma.TabIndex = 583
        Me.L2_min_20ma.Text = "5000"
        '
        'L2_max_20ma
        '
        Me.L2_max_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L2_max_20ma.Location = New System.Drawing.Point(82, 284)
        Me.L2_max_20ma.Name = "L2_max_20ma"
        Me.L2_max_20ma.Size = New System.Drawing.Size(48, 20)
        Me.L2_max_20ma.TabIndex = 582
        Me.L2_max_20ma.Text = "7000"
        '
        'L2_4ma
        '
        Me.L2_4ma.Location = New System.Drawing.Point(1, 43)
        Me.L2_4ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L2_4ma.Name = "L2_4ma"
        Me.L2_4ma.Size = New System.Drawing.Size(50, 20)
        Me.L2_4ma.TabIndex = 581
        Me.L2_4ma.Text = "0"
        '
        'L2_min_4ma
        '
        Me.L2_min_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L2_min_4ma.Location = New System.Drawing.Point(32, 262)
        Me.L2_min_4ma.Name = "L2_min_4ma"
        Me.L2_min_4ma.Size = New System.Drawing.Size(44, 20)
        Me.L2_min_4ma.TabIndex = 580
        Me.L2_min_4ma.Text = "2500"
        '
        'L2_max_4ma
        '
        Me.L2_max_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L2_max_4ma.Location = New System.Drawing.Point(82, 262)
        Me.L2_max_4ma.Name = "L2_max_4ma"
        Me.L2_max_4ma.Size = New System.Drawing.Size(48, 20)
        Me.L2_max_4ma.TabIndex = 579
        Me.L2_max_4ma.Text = "3000"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.Location = New System.Drawing.Point(191, 328)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(82, 16)
        Me.Label97.TabIndex = 594
        Me.Label97.Text = "Loop3 20mA"
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(192, 307)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(75, 16)
        Me.Label98.TabIndex = 593
        Me.Label98.Text = "Loop3 4mA"
        '
        'L3_20ma
        '
        Me.L3_20ma.Location = New System.Drawing.Point(1, 106)
        Me.L3_20ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L3_20ma.Name = "L3_20ma"
        Me.L3_20ma.Size = New System.Drawing.Size(50, 20)
        Me.L3_20ma.TabIndex = 592
        Me.L3_20ma.Text = "0"
        '
        'L3_min_20ma
        '
        Me.L3_min_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L3_min_20ma.Location = New System.Drawing.Point(32, 327)
        Me.L3_min_20ma.Name = "L3_min_20ma"
        Me.L3_min_20ma.Size = New System.Drawing.Size(44, 20)
        Me.L3_min_20ma.TabIndex = 591
        Me.L3_min_20ma.Text = "5000"
        '
        'L3_max_20ma
        '
        Me.L3_max_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L3_max_20ma.Location = New System.Drawing.Point(82, 327)
        Me.L3_max_20ma.Name = "L3_max_20ma"
        Me.L3_max_20ma.Size = New System.Drawing.Size(48, 20)
        Me.L3_max_20ma.TabIndex = 590
        Me.L3_max_20ma.Text = "7000"
        '
        'L3_4ma
        '
        Me.L3_4ma.Location = New System.Drawing.Point(1, 85)
        Me.L3_4ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L3_4ma.Name = "L3_4ma"
        Me.L3_4ma.Size = New System.Drawing.Size(50, 20)
        Me.L3_4ma.TabIndex = 589
        Me.L3_4ma.Text = "0"
        '
        'L3_min_4ma
        '
        Me.L3_min_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L3_min_4ma.Location = New System.Drawing.Point(32, 306)
        Me.L3_min_4ma.Name = "L3_min_4ma"
        Me.L3_min_4ma.Size = New System.Drawing.Size(44, 20)
        Me.L3_min_4ma.TabIndex = 588
        Me.L3_min_4ma.Text = "2500"
        '
        'L3_max_4ma
        '
        Me.L3_max_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L3_max_4ma.Location = New System.Drawing.Point(82, 306)
        Me.L3_max_4ma.Name = "L3_max_4ma"
        Me.L3_max_4ma.Size = New System.Drawing.Size(48, 20)
        Me.L3_max_4ma.TabIndex = 587
        Me.L3_max_4ma.Text = "3000"
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(191, 371)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(82, 16)
        Me.Label99.TabIndex = 602
        Me.Label99.Text = "Loop4 20mA"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(192, 349)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(75, 16)
        Me.Label100.TabIndex = 601
        Me.Label100.Text = "Loop4 4mA"
        '
        'L4_20ma
        '
        Me.L4_20ma.Location = New System.Drawing.Point(1, 148)
        Me.L4_20ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L4_20ma.Name = "L4_20ma"
        Me.L4_20ma.Size = New System.Drawing.Size(50, 20)
        Me.L4_20ma.TabIndex = 600
        Me.L4_20ma.Text = "0"
        '
        'L4_min_20ma
        '
        Me.L4_min_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L4_min_20ma.Location = New System.Drawing.Point(32, 370)
        Me.L4_min_20ma.Name = "L4_min_20ma"
        Me.L4_min_20ma.Size = New System.Drawing.Size(44, 20)
        Me.L4_min_20ma.TabIndex = 599
        Me.L4_min_20ma.Text = "5000"
        '
        'L4_max_20ma
        '
        Me.L4_max_20ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L4_max_20ma.Location = New System.Drawing.Point(82, 370)
        Me.L4_max_20ma.Name = "L4_max_20ma"
        Me.L4_max_20ma.Size = New System.Drawing.Size(48, 20)
        Me.L4_max_20ma.TabIndex = 598
        Me.L4_max_20ma.Text = "7000"
        '
        'L4_4ma
        '
        Me.L4_4ma.Location = New System.Drawing.Point(1, 127)
        Me.L4_4ma.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.L4_4ma.Name = "L4_4ma"
        Me.L4_4ma.Size = New System.Drawing.Size(50, 20)
        Me.L4_4ma.TabIndex = 597
        Me.L4_4ma.Text = "0"
        '
        'L4_min_4ma
        '
        Me.L4_min_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L4_min_4ma.Location = New System.Drawing.Point(32, 348)
        Me.L4_min_4ma.Name = "L4_min_4ma"
        Me.L4_min_4ma.Size = New System.Drawing.Size(44, 20)
        Me.L4_min_4ma.TabIndex = 596
        Me.L4_min_4ma.Text = "2500"
        '
        'L4_max_4ma
        '
        Me.L4_max_4ma.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.L4_max_4ma.Location = New System.Drawing.Point(82, 348)
        Me.L4_max_4ma.Name = "L4_max_4ma"
        Me.L4_max_4ma.Size = New System.Drawing.Size(48, 20)
        Me.L4_max_4ma.TabIndex = 595
        Me.L4_max_4ma.Text = "3000"
        '
        'comp_ip_address
        '
        Me.comp_ip_address.Location = New System.Drawing.Point(1664, 755)
        Me.comp_ip_address.Name = "comp_ip_address"
        Me.comp_ip_address.Size = New System.Drawing.Size(109, 20)
        Me.comp_ip_address.TabIndex = 603
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.Location = New System.Drawing.Point(1664, 739)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(106, 13)
        Me.Label101.TabIndex = 604
        Me.Label101.Text = "Computer IP Address"
        '
        'Preamp_version
        '
        Me.Preamp_version.AutoSize = True
        Me.Preamp_version.Location = New System.Drawing.Point(13, 105)
        Me.Preamp_version.Name = "Preamp_version"
        Me.Preamp_version.Size = New System.Drawing.Size(239, 17)
        Me.Preamp_version.TabIndex = 605
        Me.Preamp_version.Text = "RPP4Tester - Read Preamp Version correctly"
        Me.Preamp_version.UseVisualStyleBackColor = True
        '
        'sawtooth_check
        '
        Me.sawtooth_check.AutoSize = True
        Me.sawtooth_check.Location = New System.Drawing.Point(13, 335)
        Me.sawtooth_check.Name = "sawtooth_check"
        Me.sawtooth_check.Size = New System.Drawing.Size(161, 17)
        Me.sawtooth_check.TabIndex = 606
        Me.sawtooth_check.Text = "Sawtooth Waveform Passed"
        Me.sawtooth_check.UseVisualStyleBackColor = True
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.Location = New System.Drawing.Point(10, 263)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(37, 15)
        Me.Label102.TabIndex = 614
        Me.Label102.Text = "Stdev"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.Location = New System.Drawing.Point(21, 237)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(26, 15)
        Me.Label103.TabIndex = 613
        Me.Label103.Text = "Avg"
        '
        'Stdev
        '
        Me.Stdev.Location = New System.Drawing.Point(147, 262)
        Me.Stdev.Name = "Stdev"
        Me.Stdev.Size = New System.Drawing.Size(40, 20)
        Me.Stdev.TabIndex = 612
        Me.Stdev.Text = "0"
        '
        'Stdev_min
        '
        Me.Stdev_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Stdev_min.Location = New System.Drawing.Point(53, 262)
        Me.Stdev_min.Name = "Stdev_min"
        Me.Stdev_min.Size = New System.Drawing.Size(40, 20)
        Me.Stdev_min.TabIndex = 611
        Me.Stdev_min.Text = "0"
        '
        'Stdev_max
        '
        Me.Stdev_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Stdev_max.Location = New System.Drawing.Point(99, 262)
        Me.Stdev_max.Name = "Stdev_max"
        Me.Stdev_max.Size = New System.Drawing.Size(40, 20)
        Me.Stdev_max.TabIndex = 610
        Me.Stdev_max.Text = "5"
        '
        'Avg
        '
        Me.Avg.Location = New System.Drawing.Point(147, 236)
        Me.Avg.Name = "Avg"
        Me.Avg.Size = New System.Drawing.Size(40, 20)
        Me.Avg.TabIndex = 609
        Me.Avg.Text = "0"
        '
        'Avg_min
        '
        Me.Avg_min.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Avg_min.Location = New System.Drawing.Point(53, 236)
        Me.Avg_min.Name = "Avg_min"
        Me.Avg_min.Size = New System.Drawing.Size(40, 20)
        Me.Avg_min.TabIndex = 608
        Me.Avg_min.Text = "70"
        '
        'Avg_max
        '
        Me.Avg_max.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Avg_max.Location = New System.Drawing.Point(99, 236)
        Me.Avg_max.Name = "Avg_max"
        Me.Avg_max.Size = New System.Drawing.Size(40, 20)
        Me.Avg_max.TabIndex = 607
        Me.Avg_max.Text = "90"
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button24.Location = New System.Drawing.Point(201, 236)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(82, 48)
        Me.Button24.TabIndex = 615
        Me.Button24.Text = "Check Avg and Stdev"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(-36, 556)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(63, 33)
        Me.Button17.TabIndex = 617
        Me.Button17.Text = "Button17"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(-36, 520)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(59, 33)
        Me.Button21.TabIndex = 618
        Me.Button21.Text = "Button21"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button22.Location = New System.Drawing.Point(13, 137)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(170, 29)
        Me.Button22.TabIndex = 619
        Me.Button22.Text = "Check Moisture"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button25.Location = New System.Drawing.Point(13, 73)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(169, 29)
        Me.Button25.TabIndex = 620
        Me.Button25.Text = "Start RPPTester Program"
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button26.Location = New System.Drawing.Point(13, 304)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(168, 29)
        Me.Button26.TabIndex = 621
        Me.Button26.Text = "Start RAMP Waveform Test"
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button27.Location = New System.Drawing.Point(7, 8)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(112, 27)
        Me.Button27.TabIndex = 622
        Me.Button27.Text = "Check NGEN"
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Button29
        '
        Me.Button29.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button29.Location = New System.Drawing.Point(13, 352)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(189, 29)
        Me.Button29.TabIndex = 626
        Me.Button29.Text = "Close RPPTester.exe"
        Me.Button29.UseVisualStyleBackColor = False
        '
        'Button30
        '
        Me.Button30.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button30.Location = New System.Drawing.Point(673, 898)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(189, 20)
        Me.Button30.TabIndex = 627
        Me.Button30.Text = "Open RPPTester.exe"
        Me.Button30.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(3, 26)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox1.TabIndex = 628
        Me.CheckBox1.Text = "Auto"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(3, 49)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox2.TabIndex = 629
        Me.CheckBox2.Text = "Auto"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(3, 72)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox3.TabIndex = 630
        Me.CheckBox3.Text = "Auto"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(3, 95)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox4.TabIndex = 631
        Me.CheckBox4.Text = "Auto"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(29, 513)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(29, 15)
        Me.Label90.TabIndex = 632
        Me.Label90.Text = "Cur."
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(11, 536)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(47, 15)
        Me.Label94.TabIndex = 633
        Me.Label94.Text = "P_SEN"
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(3, 187)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox6.TabIndex = 635
        Me.CheckBox6.Text = "Auto"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(3, 210)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox7.TabIndex = 636
        Me.CheckBox7.Text = "Auto"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(232, 189)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox8.TabIndex = 637
        Me.CheckBox8.Text = "Auto"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(232, 433)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox9.TabIndex = 638
        Me.CheckBox9.Text = "Auto"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox10.TabIndex = 639
        Me.CheckBox10.Text = "Auto"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(3, 141)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox5.TabIndex = 640
        Me.CheckBox5.Text = "Auto"
        Me.CheckBox5.UseVisualStyleBackColor = True
        Me.CheckBox5.Visible = False
        '
        'Button31
        '
        Me.Button31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button31.Location = New System.Drawing.Point(0, 100)
        Me.Button31.Margin = New System.Windows.Forms.Padding(0)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(100, 25)
        Me.Button31.TabIndex = 643
        Me.Button31.Text = "Waveform"
        Me.Button31.UseVisualStyleBackColor = True
        '
        'NGEN_12
        '
        Me.NGEN_12.Location = New System.Drawing.Point(131, 10)
        Me.NGEN_12.Name = "NGEN_12"
        Me.NGEN_12.Size = New System.Drawing.Size(50, 20)
        Me.NGEN_12.TabIndex = 645
        Me.NGEN_12.Text = "0"
        '
        'NGEN_4
        '
        Me.NGEN_4.Location = New System.Drawing.Point(188, 10)
        Me.NGEN_4.Name = "NGEN_4"
        Me.NGEN_4.Size = New System.Drawing.Size(50, 20)
        Me.NGEN_4.TabIndex = 646
        Me.NGEN_4.Text = "0"
        '
        'Button32
        '
        Me.Button32.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button32.Location = New System.Drawing.Point(13, 201)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(168, 29)
        Me.Button32.TabIndex = 647
        Me.Button32.Text = "Check Noise Level"
        Me.Button32.UseVisualStyleBackColor = False
        '
        'Button33
        '
        Me.Button33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button33.Location = New System.Drawing.Point(0, 175)
        Me.Button33.Margin = New System.Windows.Forms.Padding(0)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(100, 25)
        Me.Button33.TabIndex = 648
        Me.Button33.Text = "Moisture"
        Me.Button33.UseVisualStyleBackColor = True
        '
        'Button35
        '
        Me.Button35.Location = New System.Drawing.Point(-38, 591)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(65, 28)
        Me.Button35.TabIndex = 649
        Me.Button35.Text = "meter"
        Me.Button35.UseVisualStyleBackColor = True
        '
        'Button37
        '
        Me.Button37.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button37.Location = New System.Drawing.Point(1688, 553)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(92, 27)
        Me.Button37.TabIndex = 651
        Me.Button37.Text = "USB ON"
        Me.Button37.UseVisualStyleBackColor = False
        '
        'Button38
        '
        Me.Button38.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button38.Location = New System.Drawing.Point(1688, 586)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(92, 27)
        Me.Button38.TabIndex = 652
        Me.Button38.Text = "USB OFF"
        Me.Button38.UseVisualStyleBackColor = False
        '
        'Button50
        '
        Me.Button50.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button50.Location = New System.Drawing.Point(1688, 619)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(92, 27)
        Me.Button50.TabIndex = 657
        Me.Button50.Text = "Disable LAN"
        Me.Button50.UseVisualStyleBackColor = False
        '
        'Button51
        '
        Me.Button51.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button51.Location = New System.Drawing.Point(1688, 652)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(92, 27)
        Me.Button51.TabIndex = 658
        Me.Button51.Text = "Enable LAN"
        Me.Button51.UseVisualStyleBackColor = False
        '
        'Button36
        '
        Me.Button36.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button36.Location = New System.Drawing.Point(12, 541)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(212, 35)
        Me.Button36.TabIndex = 662
        Me.Button36.Text = "CRC + Version Test"
        Me.Button36.UseVisualStyleBackColor = False
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(3, 164)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox11.TabIndex = 663
        Me.CheckBox11.Text = "Auto"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(3, 118)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox12.TabIndex = 664
        Me.CheckBox12.Text = "Auto"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'txt_crc_pulsesvr
        '
        Me.txt_crc_pulsesvr.Location = New System.Drawing.Point(139, 581)
        Me.txt_crc_pulsesvr.Name = "txt_crc_pulsesvr"
        Me.txt_crc_pulsesvr.Size = New System.Drawing.Size(83, 20)
        Me.txt_crc_pulsesvr.TabIndex = 665
        '
        'txt_crc_rpp4app
        '
        Me.txt_crc_rpp4app.Location = New System.Drawing.Point(139, 604)
        Me.txt_crc_rpp4app.Name = "txt_crc_rpp4app"
        Me.txt_crc_rpp4app.Size = New System.Drawing.Size(83, 20)
        Me.txt_crc_rpp4app.TabIndex = 666
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(15, 584)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(99, 15)
        Me.Label86.TabIndex = 667
        Me.Label86.Text = "PULSESVR CRC"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(15, 606)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(90, 15)
        Me.Label87.TabIndex = 668
        Me.Label87.Text = "RPP4APP CRC"
        '
        'Button39
        '
        Me.Button39.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button39.Location = New System.Drawing.Point(11, 414)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(131, 57)
        Me.Button39.TabIndex = 669
        Me.Button39.Text = "CRC Test - Check File Integrity"
        Me.Button39.UseVisualStyleBackColor = False
        '
        'Button40
        '
        Me.Button40.Location = New System.Drawing.Point(462, 419)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(75, 39)
        Me.Button40.TabIndex = 670
        Me.Button40.Text = "Button40"
        Me.Button40.UseVisualStyleBackColor = True
        '
        'txt_ps
        '
        Me.txt_ps.Location = New System.Drawing.Point(12, 346)
        Me.txt_ps.Name = "txt_ps"
        Me.txt_ps.Size = New System.Drawing.Size(262, 47)
        Me.txt_ps.TabIndex = 671
        Me.txt_ps.Text = ""
        '
        'Computer
        '
        Me.Computer.Location = New System.Drawing.Point(102, 19)
        Me.Computer.Name = "Computer"
        Me.Computer.Size = New System.Drawing.Size(30, 20)
        Me.Computer.TabIndex = 729
        Me.Computer.Text = "7"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(11, 47)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(74, 13)
        Me.Label107.TabIndex = 728
        Me.Label107.Text = "(Set in cfg file)"
        '
        'Init_meter_button
        '
        Me.Init_meter_button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Init_meter_button.Location = New System.Drawing.Point(9, 17)
        Me.Init_meter_button.Name = "Init_meter_button"
        Me.Init_meter_button.Size = New System.Drawing.Size(87, 23)
        Me.Init_meter_button.TabIndex = 727
        Me.Init_meter_button.Text = "Init Meter"
        Me.Init_meter_button.UseVisualStyleBackColor = False
        '
        'txt_init_box
        '
        Me.txt_init_box.Location = New System.Drawing.Point(18, 901)
        Me.txt_init_box.Name = "txt_init_box"
        Me.txt_init_box.Size = New System.Drawing.Size(255, 20)
        Me.txt_init_box.TabIndex = 732
        '
        'Txt_Meter_Address
        '
        Me.Txt_Meter_Address.Location = New System.Drawing.Point(1295, 12)
        Me.Txt_Meter_Address.Name = "Txt_Meter_Address"
        Me.Txt_Meter_Address.Size = New System.Drawing.Size(255, 20)
        Me.Txt_Meter_Address.TabIndex = 733
        Me.Txt_Meter_Address.Text = "USB0::0x2A8D::0x1301::MY53217214::0::INSTR"
        '
        'txt_read_dc_value
        '
        Me.txt_read_dc_value.Location = New System.Drawing.Point(103, 582)
        Me.txt_read_dc_value.Name = "txt_read_dc_value"
        Me.txt_read_dc_value.Size = New System.Drawing.Size(67, 20)
        Me.txt_read_dc_value.TabIndex = 735
        '
        'read_current_value
        '
        Me.read_current_value.Location = New System.Drawing.Point(103, 609)
        Me.read_current_value.Name = "read_current_value"
        Me.read_current_value.Size = New System.Drawing.Size(67, 20)
        Me.read_current_value.TabIndex = 734
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.Location = New System.Drawing.Point(29, 611)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(65, 13)
        Me.Label109.TabIndex = 737
        Me.Label109.Text = "Current Limit"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.Location = New System.Drawing.Point(55, 587)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(43, 13)
        Me.Label110.TabIndex = 736
        Me.Label110.Text = "Voltage"
        '
        'Read_DC_Current_Button
        '
        Me.Read_DC_Current_Button.Location = New System.Drawing.Point(193, 553)
        Me.Read_DC_Current_Button.Name = "Read_DC_Current_Button"
        Me.Read_DC_Current_Button.Size = New System.Drawing.Size(119, 24)
        Me.Read_DC_Current_Button.TabIndex = 739
        Me.Read_DC_Current_Button.Text = "Read DC Current"
        Me.Read_DC_Current_Button.UseVisualStyleBackColor = True
        '
        'Read_DC_Button
        '
        Me.Read_DC_Button.Location = New System.Drawing.Point(195, 530)
        Me.Read_DC_Button.Name = "Read_DC_Button"
        Me.Read_DC_Button.Size = New System.Drawing.Size(119, 23)
        Me.Read_DC_Button.TabIndex = 738
        Me.Read_DC_Button.Text = "Read DC Volt"
        Me.Read_DC_Button.UseVisualStyleBackColor = True
        '
        'Button49
        '
        Me.Button49.Location = New System.Drawing.Point(316, 530)
        Me.Button49.Name = "Button49"
        Me.Button49.Size = New System.Drawing.Size(119, 23)
        Me.Button49.TabIndex = 740
        Me.Button49.Text = "Read DC Resistance"
        Me.Button49.UseVisualStyleBackColor = True
        '
        'txt_ohm
        '
        Me.txt_ohm.Location = New System.Drawing.Point(343, 553)
        Me.txt_ohm.Name = "txt_ohm"
        Me.txt_ohm.Size = New System.Drawing.Size(92, 20)
        Me.txt_ohm.TabIndex = 741
        '
        'Button52
        '
        Me.Button52.BackColor = System.Drawing.Color.Yellow
        Me.Button52.Location = New System.Drawing.Point(108, 162)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(115, 41)
        Me.Button52.TabIndex = 742
        Me.Button52.Text = "program Linux"
        Me.Button52.UseVisualStyleBackColor = False
        '
        'cb_stop_on_message
        '
        Me.cb_stop_on_message.AutoSize = True
        Me.cb_stop_on_message.Location = New System.Drawing.Point(1148, 24)
        Me.cb_stop_on_message.Name = "cb_stop_on_message"
        Me.cb_stop_on_message.Size = New System.Drawing.Size(88, 17)
        Me.cb_stop_on_message.TabIndex = 743
        Me.cb_stop_on_message.Text = "Debug Stops"
        Me.cb_stop_on_message.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.en_bus1)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_bus2)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_pwr1)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_pwr2)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_pb_rst)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rtd)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel5)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel6)
        Me.FlowLayoutPanel1.Controls.Add(Me.en_rel7)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(303, 198)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(146, 67)
        Me.FlowLayoutPanel1.TabIndex = 745
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_bus1)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_bus2)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_pwr1)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_pwr2)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_pb_rst)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rtd)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel1)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel2)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel3)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel4)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel5)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel6)
        Me.FlowLayoutPanel2.Controls.Add(Me.dis_rel7)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(304, 282)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(138, 73)
        Me.FlowLayoutPanel2.TabIndex = 746
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.L1_4ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L1_20ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L2_4ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L2_20ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L3_4ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L3_20ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L4_4ma)
        Me.FlowLayoutPanel3.Controls.Add(Me.L4_20ma)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(136, 219)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(57, 172)
        Me.FlowLayoutPanel3.TabIndex = 747
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.Button4)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter2)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter1)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter3)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter4)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter5)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter6)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter7)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter8)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter9)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter10)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter11)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter12)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter13)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter14)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter15)
        Me.FlowLayoutPanel4.Controls.Add(Me.com_meter16)
        Me.FlowLayoutPanel4.Controls.Add(Me.Button5)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(360, 10)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(65, 133)
        Me.FlowLayoutPanel4.TabIndex = 748
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.Button9)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button12)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button14)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button15)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button31)
        Me.FlowLayoutPanel5.Controls.Add(Me.Command8)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button13)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button33)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(438, 16)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(125, 217)
        Me.FlowLayoutPanel5.TabIndex = 749
        '
        'Panel_unneeded
        '
        Me.Panel_unneeded.Controls.Add(Me.Command_wr0)
        Me.Panel_unneeded.Controls.Add(Me.FlowLayoutPanel5)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr1)
        Me.Panel_unneeded.Controls.Add(Me.FlowLayoutPanel4)
        Me.Panel_unneeded.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr2)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr3)
        Me.Panel_unneeded.Controls.Add(Me.txt_ohm)
        Me.Panel_unneeded.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel_unneeded.Controls.Add(Me.Button49)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr4)
        Me.Panel_unneeded.Controls.Add(Me.Read_DC_Current_Button)
        Me.Panel_unneeded.Controls.Add(Me.txt_ps)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr5)
        Me.Panel_unneeded.Controls.Add(Me.Button40)
        Me.Panel_unneeded.Controls.Add(Me.Read_DC_Button)
        Me.Panel_unneeded.Controls.Add(Me.Button39)
        Me.Panel_unneeded.Controls.Add(Me.Command_wr6)
        Me.Panel_unneeded.Controls.Add(Me.Label109)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr0)
        Me.Panel_unneeded.Controls.Add(Me.Label110)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr1)
        Me.Panel_unneeded.Controls.Add(Me.txt_read_dc_value)
        Me.Panel_unneeded.Controls.Add(Me.Button52)
        Me.Panel_unneeded.Controls.Add(Me.read_current_value)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr2)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr3)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr4)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr5)
        Me.Panel_unneeded.Controls.Add(Me.Text_wr6)
        Me.Panel_unneeded.Controls.Add(Me.Command_rd0)
        Me.Panel_unneeded.Controls.Add(Me.Command_rd1)
        Me.Panel_unneeded.Controls.Add(Me.Command_rd2)
        Me.Panel_unneeded.Controls.Add(Me.Text_rd0)
        Me.Panel_unneeded.Controls.Add(Me.Text_rd1)
        Me.Panel_unneeded.Controls.Add(Me.Text_rd2)
        Me.Panel_unneeded.Controls.Add(Me.TextBox2)
        Me.Panel_unneeded.Controls.Add(Me.Text_COM_RX)
        Me.Panel_unneeded.Controls.Add(Me.Button11)
        Me.Panel_unneeded.Controls.Add(Me.Label1)
        Me.Panel_unneeded.Controls.Add(Me.Label12)
        Me.Panel_unneeded.Controls.Add(Me.Label13)
        Me.Panel_unneeded.Controls.Add(Me.Label14)
        Me.Panel_unneeded.Controls.Add(Me.Label15)
        Me.Panel_unneeded.Controls.Add(Me.Label16)
        Me.Panel_unneeded.Controls.Add(Me.Label17)
        Me.Panel_unneeded.Controls.Add(Me.Button1)
        Me.Panel_unneeded.Controls.Add(Me.Txt_rd_CPU)
        Me.Panel_unneeded.Controls.Add(Me.Button35)
        Me.Panel_unneeded.Controls.Add(Me.Label4)
        Me.Panel_unneeded.Controls.Add(Me.Label5)
        Me.Panel_unneeded.Controls.Add(Me.Label6)
        Me.Panel_unneeded.Controls.Add(Me.Label7)
        Me.Panel_unneeded.Controls.Add(Me.Button2)
        Me.Panel_unneeded.Controls.Add(Me.TextBox1)
        Me.Panel_unneeded.Controls.Add(Me.groupBox1)
        Me.Panel_unneeded.Controls.Add(Me.btnClose)
        Me.Panel_unneeded.Controls.Add(Me.txtAddress)
        Me.Panel_unneeded.Controls.Add(Me.txtIDString)
        Me.Panel_unneeded.Controls.Add(Me.txtRevision)
        Me.Panel_unneeded.Controls.Add(Me.txtToDisplay)
        Me.Panel_unneeded.Controls.Add(Me.lblAddress)
        Me.Panel_unneeded.Controls.Add(Me.lblIDString)
        Me.Panel_unneeded.Controls.Add(Me.lblRevision)
        Me.Panel_unneeded.Controls.Add(Me.lblToDisplay)
        Me.Panel_unneeded.Controls.Add(Me.btnGetID)
        Me.Panel_unneeded.Controls.Add(Me.btnGetRev)
        Me.Panel_unneeded.Controls.Add(Me.btnToDisplay)
        Me.Panel_unneeded.Controls.Add(Me.btnClearDisplay)
        Me.Panel_unneeded.Controls.Add(Me.Button6)
        Me.Panel_unneeded.Controls.Add(Me.en_loop1)
        Me.Panel_unneeded.Controls.Add(Me.dis_loop1)
        Me.Panel_unneeded.Controls.Add(Me.en_loop2)
        Me.Panel_unneeded.Controls.Add(Me.dis_loop2)
        Me.Panel_unneeded.Controls.Add(Me.en_loop3)
        Me.Panel_unneeded.Controls.Add(Me.Button21)
        Me.Panel_unneeded.Controls.Add(Me.dis_loop3)
        Me.Panel_unneeded.Controls.Add(Me.Button17)
        Me.Panel_unneeded.Controls.Add(Me.en_loop4)
        Me.Panel_unneeded.Controls.Add(Me.dis_loop4)
        Me.Panel_unneeded.Controls.Add(Me.dis_all_relay)
        Me.Panel_unneeded.Controls.Add(Me.Button42)
        Me.Panel_unneeded.Controls.Add(Me.Button43)
        Me.Panel_unneeded.Controls.Add(Me.GroupBox3)
        Me.Panel_unneeded.Controls.Add(Me.Button47)
        Me.Panel_unneeded.Location = New System.Drawing.Point(1597, 8)
        Me.Panel_unneeded.Name = "Panel_unneeded"
        Me.Panel_unneeded.Size = New System.Drawing.Size(149, 62)
        Me.Panel_unneeded.TabIndex = 750
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(191, 3)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 22)
        Me.Label18.TabIndex = 752
        Me.Label18.Text = "Val (o)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(383, 4)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 20)
        Me.Label19.TabIndex = 753
        Me.Label19.Text = "Val (V)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button55
        '
        Me.Button55.Location = New System.Drawing.Point(416, 877)
        Me.Button55.Name = "Button55"
        Me.Button55.Size = New System.Drawing.Size(115, 41)
        Me.Button55.TabIndex = 752
        Me.Button55.Text = "Nm test"
        Me.Button55.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button23)
        Me.Panel1.Controls.Add(Me.Button19)
        Me.Panel1.Controls.Add(Me.RTD_cur_open_max)
        Me.Panel1.Controls.Add(Me.RTD_cur_open_min)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel1.Controls.Add(Me.RTD_cur_110_max)
        Me.Panel1.Controls.Add(Me.RTD_cur_110_min)
        Me.Panel1.Controls.Add(Me.RTD_cur_110)
        Me.Panel1.Controls.Add(Me.RTD_cur_open)
        Me.Panel1.Controls.Add(Me.Label93)
        Me.Panel1.Controls.Add(Me.Label92)
        Me.Panel1.Controls.Add(Me.RTD_sense_open_max)
        Me.Panel1.Controls.Add(Me.RTD_sense_open_min)
        Me.Panel1.Controls.Add(Me.RTD_sense_open)
        Me.Panel1.Controls.Add(Me.RTD_sense_110_max)
        Me.Panel1.Controls.Add(Me.RTD_sense_110_min)
        Me.Panel1.Controls.Add(Me.RTD_sense_110)
        Me.Panel1.Controls.Add(Me.Cur)
        Me.Panel1.Controls.Add(Me.Label91)
        Me.Panel1.Controls.Add(Me.L1_max_4ma)
        Me.Panel1.Controls.Add(Me.L1_min_4ma)
        Me.Panel1.Controls.Add(Me.L1_max_20ma)
        Me.Panel1.Controls.Add(Me.L1_min_20ma)
        Me.Panel1.Controls.Add(Me.Label89)
        Me.Panel1.Controls.Add(Me.Label88)
        Me.Panel1.Controls.Add(Me.L2_max_4ma)
        Me.Panel1.Controls.Add(Me.L2_min_4ma)
        Me.Panel1.Controls.Add(Me.L2_max_20ma)
        Me.Panel1.Controls.Add(Me.L2_min_20ma)
        Me.Panel1.Controls.Add(Me.Label96)
        Me.Panel1.Controls.Add(Me.Label95)
        Me.Panel1.Controls.Add(Me.L3_max_4ma)
        Me.Panel1.Controls.Add(Me.L3_min_4ma)
        Me.Panel1.Controls.Add(Me.L3_max_20ma)
        Me.Panel1.Controls.Add(Me.L3_min_20ma)
        Me.Panel1.Controls.Add(Me.CheckBox9)
        Me.Panel1.Controls.Add(Me.Label85)
        Me.Panel1.Controls.Add(Me.Label98)
        Me.Panel1.Controls.Add(Me.Label84)
        Me.Panel1.Controls.Add(Me.CheckBox8)
        Me.Panel1.Controls.Add(Me.Label83)
        Me.Panel1.Controls.Add(Me.Label97)
        Me.Panel1.Controls.Add(Me.Label82)
        Me.Panel1.Controls.Add(Me.L4_max_4ma)
        Me.Panel1.Controls.Add(Me.Label80)
        Me.Panel1.Controls.Add(Me.L4_min_4ma)
        Me.Panel1.Controls.Add(Me.Label79)
        Me.Panel1.Controls.Add(Me.Label94)
        Me.Panel1.Controls.Add(Me.Label78)
        Me.Panel1.Controls.Add(Me.L4_max_20ma)
        Me.Panel1.Controls.Add(Me.Label81)
        Me.Panel1.Controls.Add(Me.Label90)
        Me.Panel1.Controls.Add(Me.T1)
        Me.Panel1.Controls.Add(Me.L4_min_20ma)
        Me.Panel1.Controls.Add(Me.T4)
        Me.Panel1.Controls.Add(Me.Label100)
        Me.Panel1.Controls.Add(Me.T3)
        Me.Panel1.Controls.Add(Me.Label99)
        Me.Panel1.Controls.Add(Me.T2)
        Me.Panel1.Controls.Add(Me.Button46)
        Me.Panel1.Controls.Add(Me.T3_min)
        Me.Panel1.Controls.Add(Me.T1_max)
        Me.Panel1.Controls.Add(Me.T3_max)
        Me.Panel1.Controls.Add(Me.T1_min)
        Me.Panel1.Controls.Add(Me.T4_min)
        Me.Panel1.Controls.Add(Me.T2_max)
        Me.Panel1.Controls.Add(Me.T4_max)
        Me.Panel1.Controls.Add(Me.T2_min)
        Me.Panel1.Location = New System.Drawing.Point(279, 186)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(298, 626)
        Me.Panel1.TabIndex = 753
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.Controls.Add(Me.flp_voltages)
        Me.Panel2.Controls.Add(Me.Label51)
        Me.Panel2.Controls.Add(Me.flp_impedances)
        Me.Panel2.Controls.Add(Me.Label62)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label64)
        Me.Panel2.Controls.Add(Me.V24_max_ohm)
        Me.Panel2.Controls.Add(Me.Label63)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label65)
        Me.Panel2.Controls.Add(Me.V24_min_ohm)
        Me.Panel2.Controls.Add(Me.Label66)
        Me.Panel2.Controls.Add(Me.Label57)
        Me.Panel2.Controls.Add(Me.Label58)
        Me.Panel2.Controls.Add(Me.Label59)
        Me.Panel2.Controls.Add(Me.Label60)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Controls.Add(Me.Label56)
        Me.Panel2.Controls.Add(Me.Label55)
        Me.Panel2.Controls.Add(Me.Label54)
        Me.Panel2.Controls.Add(Me.Label53)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.V1_2_max_volt)
        Me.Panel2.Controls.Add(Me.V5A_max_volt)
        Me.Panel2.Controls.Add(Me.Label35)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Controls.Add(Me.V3_3A_max_volt)
        Me.Panel2.Controls.Add(Me.VDD_Core_max_volt)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.V1_8_max_volt)
        Me.Panel2.Controls.Add(Me.V5_min_ohm)
        Me.Panel2.Controls.Add(Me.FPGA_VTT_max_volt)
        Me.Panel2.Controls.Add(Me.V5_max_ohm)
        Me.Panel2.Controls.Add(Me.DDR_VREF_max_volt)
        Me.Panel2.Controls.Add(Me.V1_8FPGA_max_volt)
        Me.Panel2.Controls.Add(Me.V3_3_CPU_max_volt)
        Me.Panel2.Controls.Add(Me.V5AMinus_max_volt)
        Me.Panel2.Controls.Add(Me.V1_8A_max_volt)
        Me.Panel2.Controls.Add(Me.V3_3_min_ohm)
        Me.Panel2.Controls.Add(Me.VDD_MPU_max_volt)
        Me.Panel2.Controls.Add(Me.V3_3_max_ohm)
        Me.Panel2.Controls.Add(Me.V3_3_max_volt)
        Me.Panel2.Controls.Add(Me.V5_max_volt)
        Me.Panel2.Controls.Add(Me.VDD_MPU_min_ohm)
        Me.Panel2.Controls.Add(Me.V1_8A_min_ohm)
        Me.Panel2.Controls.Add(Me.DDR_VREF_min_volt)
        Me.Panel2.Controls.Add(Me.V5AMinus_min_ohm)
        Me.Panel2.Controls.Add(Me.FPGA_VTT_min_volt)
        Me.Panel2.Controls.Add(Me.V3_3_CPU_min_ohm)
        Me.Panel2.Controls.Add(Me.V1_8_min_volt)
        Me.Panel2.Controls.Add(Me.V1_8FPGA_min_ohm)
        Me.Panel2.Controls.Add(Me.VDD_Core_min_volt)
        Me.Panel2.Controls.Add(Me.V1_2_min_ohm)
        Me.Panel2.Controls.Add(Me.V3_3A_min_volt)
        Me.Panel2.Controls.Add(Me.V5A_min_ohm)
        Me.Panel2.Controls.Add(Me.V5A_min_volt)
        Me.Panel2.Controls.Add(Me.V3_3A_min_ohm)
        Me.Panel2.Controls.Add(Me.V1_2_min_volt)
        Me.Panel2.Controls.Add(Me.VDD_Core_min_ohm)
        Me.Panel2.Controls.Add(Me.V1_8FPGA_min_volt)
        Me.Panel2.Controls.Add(Me.V1_8_min_ohm)
        Me.Panel2.Controls.Add(Me.V3_3_CPU_min_volt)
        Me.Panel2.Controls.Add(Me.FPGA_VTT_min_ohm)
        Me.Panel2.Controls.Add(Me.V5AMinus_min_volt)
        Me.Panel2.Controls.Add(Me.DDR_VREF_min_ohm)
        Me.Panel2.Controls.Add(Me.V1_8A_min_volt)
        Me.Panel2.Controls.Add(Me.VDD_MPU_max_ohm)
        Me.Panel2.Controls.Add(Me.VDD_MPU_min_volt)
        Me.Panel2.Controls.Add(Me.V3_3_min_volt)
        Me.Panel2.Controls.Add(Me.V1_8A_max_ohm)
        Me.Panel2.Controls.Add(Me.V5_min_volt)
        Me.Panel2.Controls.Add(Me.V5AMinus_max_ohm)
        Me.Panel2.Controls.Add(Me.V3_3_CPU_max_ohm)
        Me.Panel2.Controls.Add(Me.V1_8FPGA_max_ohm)
        Me.Panel2.Controls.Add(Me.V1_2_max_ohm)
        Me.Panel2.Controls.Add(Me.V5A_max_ohm)
        Me.Panel2.Controls.Add(Me.V3_3A_max_ohm)
        Me.Panel2.Controls.Add(Me.VDD_Core_max_ohm)
        Me.Panel2.Controls.Add(Me.V1_8_max_ohm)
        Me.Panel2.Controls.Add(Me.V24_max_volt)
        Me.Panel2.Controls.Add(Me.FPGA_VTT_max_ohm)
        Me.Panel2.Controls.Add(Me.V24_min_volt)
        Me.Panel2.Controls.Add(Me.DDR_VREF_max_ohm)
        Me.Panel2.Location = New System.Drawing.Point(1095, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(462, 360)
        Me.Panel2.TabIndex = 754
        '
        'flp_voltages
        '
        Me.flp_voltages.Controls.Add(Me.V24_volt)
        Me.flp_voltages.Controls.Add(Me.V5_volt)
        Me.flp_voltages.Controls.Add(Me.V3_3_volt)
        Me.flp_voltages.Controls.Add(Me.VDD_MPU_volt)
        Me.flp_voltages.Controls.Add(Me.V1_8A_volt)
        Me.flp_voltages.Controls.Add(Me.V5AMinus_volt)
        Me.flp_voltages.Controls.Add(Me.V3_3_CPU_volt)
        Me.flp_voltages.Controls.Add(Me.V1_8FPGA_volt)
        Me.flp_voltages.Controls.Add(Me.V1_2_volt)
        Me.flp_voltages.Controls.Add(Me.V5A_volt)
        Me.flp_voltages.Controls.Add(Me.V3_3A_volt)
        Me.flp_voltages.Controls.Add(Me.VDD_Core_volt)
        Me.flp_voltages.Controls.Add(Me.V1_8_volt)
        Me.flp_voltages.Controls.Add(Me.FPGA_VTT_volt)
        Me.flp_voltages.Controls.Add(Me.DDR_VREF_volt)
        Me.flp_voltages.Location = New System.Drawing.Point(386, 25)
        Me.flp_voltages.Name = "flp_voltages"
        Me.flp_voltages.Size = New System.Drawing.Size(69, 332)
        Me.flp_voltages.TabIndex = 771
        '
        'flp_impedances
        '
        Me.flp_impedances.Controls.Add(Me.V24_ohm)
        Me.flp_impedances.Controls.Add(Me.V5_ohm)
        Me.flp_impedances.Controls.Add(Me.V3_3_ohm)
        Me.flp_impedances.Controls.Add(Me.VDD_MPU_ohm)
        Me.flp_impedances.Controls.Add(Me.V1_8A_ohm)
        Me.flp_impedances.Controls.Add(Me.V5AMinus_ohm)
        Me.flp_impedances.Controls.Add(Me.V3_3_CPU_ohm)
        Me.flp_impedances.Controls.Add(Me.V1_8FPGA_ohm)
        Me.flp_impedances.Controls.Add(Me.V1_2_ohm)
        Me.flp_impedances.Controls.Add(Me.V5A_ohm)
        Me.flp_impedances.Controls.Add(Me.V3_3A_ohm)
        Me.flp_impedances.Controls.Add(Me.VDD_Core_ohm)
        Me.flp_impedances.Controls.Add(Me.V1_8_ohm)
        Me.flp_impedances.Controls.Add(Me.FPGA_VTT_ohm)
        Me.flp_impedances.Controls.Add(Me.DDR_VREF_ohm)
        Me.flp_impedances.Location = New System.Drawing.Point(189, 25)
        Me.flp_impedances.Name = "flp_impedances"
        Me.flp_impedances.Size = New System.Drawing.Size(63, 334)
        Me.flp_impedances.TabIndex = 770
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnConnect)
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Controls.Add(Me.ComboBox_com)
        Me.GroupBox2.Controls.Add(Me.Text_TX)
        Me.GroupBox2.Controls.Add(Me.Text_RX)
        Me.GroupBox2.Location = New System.Drawing.Point(262, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 72)
        Me.GroupBox2.TabIndex = 756
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fixture PCA"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Init_meter_button)
        Me.GroupBox5.Controls.Add(Me.Computer)
        Me.GroupBox5.Controls.Add(Me.Label107)
        Me.GroupBox5.Location = New System.Drawing.Point(468, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(146, 72)
        Me.GroupBox5.TabIndex = 757
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Meter"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button27)
        Me.Panel3.Controls.Add(Me.LED_15_on_check)
        Me.Panel3.Controls.Add(Me.LED7_blinking_check)
        Me.Panel3.Controls.Add(Me.NGEN_12)
        Me.Panel3.Controls.Add(Me.NGEN_4)
        Me.Panel3.Controls.Add(Me.Button25)
        Me.Panel3.Controls.Add(Me.Preamp_version)
        Me.Panel3.Controls.Add(Me.Button22)
        Me.Panel3.Controls.Add(Me.moisture_test)
        Me.Panel3.Controls.Add(Me.Button32)
        Me.Panel3.Controls.Add(Me.Avg_max)
        Me.Panel3.Controls.Add(Me.Avg_min)
        Me.Panel3.Controls.Add(Me.Avg)
        Me.Panel3.Controls.Add(Me.Stdev_max)
        Me.Panel3.Controls.Add(Me.Stdev_min)
        Me.Panel3.Controls.Add(Me.Stdev)
        Me.Panel3.Controls.Add(Me.Label103)
        Me.Panel3.Controls.Add(Me.Label102)
        Me.Panel3.Controls.Add(Me.Button24)
        Me.Panel3.Controls.Add(Me.Button26)
        Me.Panel3.Controls.Add(Me.sawtooth_check)
        Me.Panel3.Controls.Add(Me.Command6)
        Me.Panel3.Controls.Add(Me.Button29)
        Me.Panel3.Location = New System.Drawing.Point(649, 446)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(298, 438)
        Me.Panel3.TabIndex = 766
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox10)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox1)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox2)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox3)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox4)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox12)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox5)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox11)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox6)
        Me.FlowLayoutPanel7.Controls.Add(Me.CheckBox7)
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(1678, 301)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(68, 240)
        Me.FlowLayoutPanel7.TabIndex = 769
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(875, 459)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 15)
        Me.Label8.TabIndex = 770
        Me.Label8.Text = "Build"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(30, 407)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 771
        Me.Label10.Text = "MAC"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(45, 429)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(18, 15)
        Me.Label20.TabIndex = 772
        Me.Label20.Text = "IP"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(262, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 27)
        Me.Button3.TabIndex = 773
        Me.Button3.Text = "Get MAC"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'tb_SNFull
        '
        Me.tb_SNFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_SNFull.Location = New System.Drawing.Point(51, 48)
        Me.tb_SNFull.Name = "tb_SNFull"
        Me.tb_SNFull.Size = New System.Drawing.Size(173, 26)
        Me.tb_SNFull.TabIndex = 774
        '
        'tb_MAC_Full
        '
        Me.tb_MAC_Full.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_MAC_Full.Location = New System.Drawing.Point(51, 77)
        Me.tb_MAC_Full.Name = "tb_MAC_Full"
        Me.tb_MAC_Full.Size = New System.Drawing.Size(173, 26)
        Me.tb_MAC_Full.TabIndex = 775
        '
        'frmEZSample
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1784, 933)
        Me.Controls.Add(Me.tb_MAC_Full)
        Me.Controls.Add(Me.tb_SNFull)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FlowLayoutPanel7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btn_MAC_IP)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button55)
        Me.Controls.Add(Me.Panel_unneeded)
        Me.Controls.Add(Me.en_uut_pwr)
        Me.Controls.Add(Me.btn_ImpedanceTest)
        Me.Controls.Add(Me.cb_stop_on_message)
        Me.Controls.Add(Me.txt_init_box)
        Me.Controls.Add(Me.Txt_Meter_Address)
        Me.Controls.Add(Me.Button48)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.Label86)
        Me.Controls.Add(Me.txt_crc_rpp4app)
        Me.Controls.Add(Me.txt_crc_pulsesvr)
        Me.Controls.Add(Me.Button36)
        Me.Controls.Add(Me.btn_MemoryTest)
        Me.Controls.Add(Me.Button51)
        Me.Controls.Add(Me.Button50)
        Me.Controls.Add(Me.Button38)
        Me.Controls.Add(Me.Button37)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.btn_VoltageTest)
        Me.Controls.Add(Me.Label101)
        Me.Controls.Add(Me.comp_ip_address)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.build_ver_value)
        Me.Controls.Add(Me.FPGA_ver_value)
        Me.Controls.Add(Me.btn_ProgramFPGA)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.ip_txt)
        Me.Controls.Add(Me.Button44)
        Me.Controls.Add(Me.tb_ProgrammedMAC)
        Me.Controls.Add(Me.build_ver)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.fpga_ver)
        Me.Controls.Add(Me.btn_LoadLinux)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Button45)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_StartNewTest)
        Me.Controls.Add(Me.dis_uut_pwr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Tech)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEZSample"
        Me.Text = "RPP4 Test - Revision 2"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.Panel_unneeded.ResumeLayout(False)
        Me.Panel_unneeded.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.flp_voltages.ResumeLayout(False)
        Me.flp_voltages.PerformLayout()
        Me.flp_impedances.ResumeLayout(False)
        Me.flp_impedances.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    'COM Port Test Board *****************************************************************************************************
    'COM Port Test Board *****************************************************************************************************
    'COM Port Test Board *****************************************************************************************************
    'COM Port Test Board *****************************************************************************************************
    'COM Port Test Board *****************************************************************************************************

    'DECLARE A COMM PORT 
    Dim WithEvents Test_port As SerialPort = New System.IO.Ports.SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
    Private Sub ezsample_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        'CHECK IF PORT IS OPEN AND THEN CLOSE COMM PORt

        'If Test_port.IsOpen Then
        '    Call disable_uut_pwr()
        '    Thread.Sleep(500)
        '    Test_port.Close()
        'End If
        'Call close_comm()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        ''CHECK IF PORT IS CLOSED AND THEN OPEN COM PORT FROM COMOBOX PORT NAMES        
        'Test_port.PortName = ComboBox_com.SelectedItem
        '' Test_port.Encoding = System.Text.Encoding.GetEncoding(1252)
        'Test_port.Encoding = System.Text.Encoding.GetEncoding(28591)
        '' Test_port.Encoding = System.Text.Encoding.28591

        'If Not Test_port.IsOpen Then
        '    Test_port.Open()
        'End If
        'If Test_port.IsOpen Then
        '    btnConnect.BackColor = Color.LightGreen
        '    Call disable_uut_pwr()
        '    Call disable_all_relays()
        '    Call meter(METER_OFF)
        '    If Text_COM_RX.Text = 35 Then
        '        com_test_board_ok = True
        '    Else
        '        com_test_board_ok = False
        '    End If

        'Else
        '    com_test_board_ok = False
        '    btnConnect.BackColor = Color.Red
        '    MsgBox("Not a Valid COM Port")
        'End If

        Test_port.Close() 'Added 2024-06-12 for safer error handling -NM

        If ComboBox_com.Text <> "" Then
            Test_port.PortName = ComboBox_com.SelectedItem
            Test_port.Encoding = System.Text.Encoding.GetEncoding(28591)
        Else

            MsgBox("Select a valid COM port!")
            Exit Sub
        End If

        Test_port.Close()
        Test_port.Open()

        If Test_port.IsOpen Then
            btnConnect.BackColor = Color.LightGreen
            Call disable_uut_pwr()
            Call disable_all_relays()
            Call meter(METER_OFF)
            If Text_COM_RX.Text = 35 Then
                com_test_board_ok = True
            Else
                com_test_board_ok = False
            End If
        Else
            com_test_board_ok = False
            btnConnect.BackColor = Color.Red
            MsgBox("Could not establish connection with " & ComboBox_com.SelectedItem.ToString)
        End If





    End Sub
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
        'Read the COM Port and display in text box
        Text_COM_RX.Text = (Test_port.ReadTo(Chr(13)))
    End Sub
    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs)
        'Manually Close the COM port
        If Test_port.IsOpen Then
            Test_port.Close()
            btnConnect.BackColor = Color.White
        End If
    End Sub

    Private Sub send_data(wr_data As Long, write_reg As Long)

        data_received = False
        Call transmit_out("X")
        Text_COM_RX.BackColor = Color.Yellow

        Call transmit_out(System.Convert.ToChar(wr_data))

        data_received = False
        Call transmit_out(System.Convert.ToChar(write_reg))

    End Sub

    Private Sub transmit_out(tx_out As String)


        Try
            Text_TX.BackColor = Color.LightGreen
            Test_port.Write(tx_out)
            Thread.Sleep(12)
            Text_RX.BackColor = Color.White
            'SET READ TIMOUT FOR RS232 READ TO 100MS
            Test_port.ReadTimeout = 22
            Text_TX.BackColor = Color.White
            Text_RX.BackColor = Color.LightGreen
            Text_COM_RX.Text = Test_port.ReadByte
            byte_received = Text_COM_RX.Text

        Catch ex As TimeoutException
            'IF THERE IS A TIMEOUT, PRINT" No Data " IN TEXTBOX1.TEXT
            Text_COM_RX.Text = "NoData"
            Text_RX.BackColor = Color.Red
        End Try

    End Sub

    Private Sub Button10_Click_1(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'Manually Close the COM port
        If Test_port.IsOpen Then
            Test_port.Close()
            btnConnect.BackColor = Color.White
        End If
    End Sub

    Private Sub Button11_Click_1(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Call request_read_command()
    End Sub

    Private Sub request_read_command()
        Try
            Text_RX.BackColor = Color.White
            Test_port.ReadTimeout = 100
            Text_RX.BackColor = Color.LightGreen
            Text_COM_RX.Text = Test_port.ReadByte
            byte_received = Test_port.ReadByte
        Catch ex As TimeoutException
            Text_COM_RX.Text = "NoData"
            Text_RX.BackColor = Color.Red
        End Try
    End Sub

    'RPP4 COM Port *******************************************************************************
    'RPP4 COM Port *******************************************************************************
    'RPP4 COM Port *******************************************************************************
    'RPP4 COM Port *******************************************************************************


    Dim WithEvents debug_port As SerialPort = New System.IO.Ports.SerialPort("COM2", 115200, Parity.None, 8, StopBits.One)


    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Call open_rpp4_port()
    End Sub
    Private Sub open_rpp4_port()
        If cb_UUT_COM.Text <> "" Then
            debug_port.PortName = cb_UUT_COM.SelectedItem
            debug_port.Encoding = System.Text.Encoding.GetEncoding(28591)
        Else
            MsgBox("Select a valid COM port!")
            Exit Sub
        End If

        debug_port.Close()
        debug_port.Open()
        'If Not debug_port.IsOpen Then
        '    debug_port.Open()
        'End If
        If debug_port.IsOpen Then
            Button8.BackColor = Color.LightGreen
            Button8.Refresh()
        Else
            Button8.BackColor = Color.Red
            MsgBox("Could not establish connection with " & cb_UUT_COM.SelectedItem.ToString)
        End If

    End Sub
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Call close_rpp4_port()
    End Sub
    Private Sub close_rpp4_port()
        'Manually Close the COM port
        If debug_port.IsOpen Then
            debug_port.Close()
            Button8.BackColor = Color.White
        End If
    End Sub

    Private Sub comm_with_RPP4(send_com As String, rec_com As String, time_out As Long)

        debug_port.ReadTimeout = time_out
        debug_port.Write(send_com)
        Try
            RichTextBox1.Text = RichTextBox1.Text & (debug_port.ReadTo(rec_com))
            With RichTextBox1
                .SelectionStart = Len(.Text)
                .SelectionLength = 0
            End With
            RichTextBox1.ScrollToCaret()
        Catch ex As TimeoutException
            RichTextBox1.Text = RichTextBox1.Text & "Error: Serial Port read timed out."
        End Try
    End Sub
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        send_and_wait_RPP4("reboot", "Hit any key to stop autoboot:", 20, 500)
    End Sub
    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        send_and_wait_RPP4("root", "root@am335x-evm:~#", 30, 100)
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        RichTextBox1.Text = RichTextBox1.Text & debug_port.ReadExisting()
        RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        RichTextBox1.ScrollToCaret()
        RichTextBox1.Select()
    End Sub
    Private Sub read_RPP4(count As Long, duration As Long)
        Dim x As Long
        x = 0
        Do While x <= count
            Thread.Sleep(duration)
            RichTextBox1.Text = RichTextBox1.Text & debug_port.ReadExisting()
            RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
            RichTextBox1.ScrollToCaret()
            RichTextBox1.Select()
            x = x + 1
        Loop
    End Sub
    Private Sub send_and_wait_RPP4(text_command As String, text_search As String, attempts As Long, delay_per_attempt As Long)
        RichTextBox1.BackColor = Color.White
        RichTextBox1.Refresh()

        Dim x As Long = 0
        Dim temp_str As String = ""
        text_found = False

        debug_port.Write(text_command)

        Do While x <= attempts
            Thread.Sleep(delay_per_attempt)
            Dim newline = debug_port.ReadExisting()
            temp_str = temp_str & newline
            RichTextBox1.Focus()
            RichTextBox1.AppendText(newline)
            RichTextBox1.Refresh()

            If InStr(temp_str, text_search) > 0 Then
                text_found = True
                x = attempts + 100
                RichTextBox1.BackColor = Color.LightGreen

                If text_command = "ifconfig" & vbCr Then
                    eth_str = temp_str
                End If

                If text_command = "rpp4test" & vbCr Then
                    rpp4_str = temp_str
                End If

                If text_command = "ps" & vbCr Then
                    ps = temp_str
                End If

                If text_command = "mtest 0x80000000 0x87f7be28 0xa5a5a5a5 1" & vbCr Then
                    mem_test_return = temp_str
                End If


            End If

            x = x + 1
        Loop
        If text_found = False Then
            RichTextBox1.BackColor = Color.Yellow
            MsgBox("Command: " & text_command & vbCrLf & "Could not find: " & text_search) 'debug code

        End If

        'debug_str = debug_str & temp_str '<- Removed because this isn't used anywhere -NM

        'RichTextBox1.Text = debug_str
        'RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        'RichTextBox1.ScrollToCaret()
        'RichTextBox1.Select()
        'RichTextBox1.Refresh()

    End Sub
    Private Function search_RPP4_serial(text_search As String, max_attempts As Long, delay_per_attempt_ms As Long, overwrite_log As Boolean) As Boolean
        Dim text_found_NM = False

        RichTextBox1.BackColor = Color.White
        RichTextBox1.Refresh()

        Dim attempt_counter As Long = 0
        Dim read_string As String = ""

        Do Until (text_found_NM = True OrElse attempt_counter = max_attempts)
            Thread.Sleep(delay_per_attempt_ms)
            Dim newline = debug_port.ReadExisting()
            read_string = read_string & newline
            RichTextBox1.Focus()
            RichTextBox1.AppendText(newline)
            RichTextBox1.Refresh()

            If read_string.Contains(text_search) Then
                text_found_NM = True
            End If

            attempt_counter += 1
        Loop

        If text_found_NM = True Then
            RichTextBox1.BackColor = Color.LightGreen
        Else
            RichTextBox1.BackColor = Color.Red
        End If
        RichTextBox1.Refresh()

        Return text_found_NM

    End Function
    Private Sub search_RPP4(text_search As String, max_attempts As Long, delay_per_attempt_ms As Long)
        RichTextBox1.BackColor = Color.White
        RichTextBox1.Refresh()

        Dim attempt_counter As Long = 0
        Dim read_string As String = ""
        text_found = False

        Do Until (text_found = True OrElse attempt_counter = max_attempts)
            Thread.Sleep(delay_per_attempt_ms)
            Dim newline = debug_port.ReadExisting()
            read_string = read_string & newline
            RichTextBox1.Focus()
            RichTextBox1.AppendText(newline)
            RichTextBox1.Refresh()

            If read_string.Contains(text_search) Then
                text_found = True
            End If

            attempt_counter += 1
        Loop



        'Do While x <= attempts
        '    Thread.Sleep(delay_per_attempt_ms)
        '    temp_str = temp_str & debug_port.ReadExisting()
        '    RichTextBox1.Text = temp_str
        '    RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        '    RichTextBox1.ScrollToCaret()
        '    RichTextBox1.Select()
        '    RichTextBox1.Refresh()
        '    If InStr(temp_str, text_search) > 0 Then
        '        text_found = True
        '        x = attempts + 100
        '        RichTextBox1.BackColor = Color.LightGreen
        '        RichTextBox1.Refresh()
        '    End If
        '    x = x + 1
        'Loop

        If text_found = True Then
            RichTextBox1.BackColor = Color.LightGreen
        Else
            RichTextBox1.BackColor = Color.Red

        End If
        RichTextBox1.Refresh()

        'debug_str = debug_str & temp_str
        'RichTextBox1.Text = debug_str
        'RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        'RichTextBox1.ScrollToCaret()
        'RichTextBox1.Select()
        'RichTextBox1.Refresh()


    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        debug_port.Write(vbCr)
    End Sub

    Private Function ReceiveSerialData() As String
        ' Receive strings from a serial port. 
        Dim returnStr As String = ""
        Try
            debug_port.ReadTimeout = 5000
            Do
                Dim Incoming As String = debug_port.ReadLine()
                If Incoming Is Nothing Then
                    Exit Do
                Else
                    returnStr &= Incoming & vbCrLf
                End If
            Loop
        Catch ex As TimeoutException
            returnStr = "Error: Serial Port read timed out."
        End Try

        Return returnStr
    End Function


    '   Private Sub debug_port_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles debug_port.DataReceived
    ' Dim str As String = ""
    '     If e.EventType = SerialData.Chars Then
    '         Do
    ' Dim bytecount As Integer = debug_port.BytesToRead
    '
    '                If bytecount = 0 Then
    '                    Exit Do
    '                End If
    '    Dim byteBuffer(bytecount) As Byte
    '
    '
    '                debug_port.Read(byteBuffer, 0, bytecount)
    '                str = str & System.Text.Encoding.ASCII.GetString(byteBuffer, 0, 1)
    '                RichTextBox1.Text = RichTextBox1.Text & str
    '            Loop
    '        End If
    '
    ''  RaiseEvent ScanDataRecieved(str)
    '
    '    End Sub


    'Power Supply COM Port *******************************************************************************
    'Power Supply COM Port *******************************************************************************
    'Power Supply COM Port *******************************************************************************
    'Power Supply COM Port *******************************************************************************
    'Power Supply COM Port *******************************************************************************


    Private Sub btnInitIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitIO.Click

        Dim comm_port As String
        comm_port = ComboBox1.Text
        Call open_com_port(comm_port)
        If com_meter_ok = True Then
            Call get_hp_string()
            MsgBox("Get one reading")
            Call get_a_single_reading()
            MsgBox("Get revision")
            Call get_meter_rev()
            MsgBox("Get one reading")
            Call get_a_single_reading()
        End If

    End Sub

    'Sub CheckDMMError(myDmm As FormattedIO488)
    '    myDmm.WriteString("SYST:ERR?")
    '    Dim errStr As String = myDmm.ReadString()
    '    If (errStr.Contains("No error")) Then 'If no error, then return
    '        Return
    '        'If there is an error, read out all of the errors and return them in an exception
    '    Else
    '        Dim errStr2 As String = ""
    '        Do
    '            myDmm.WriteString("SYST:ERR?")
    '            errStr2 = myDmm.ReadString()
    '            If (Not errStr2.Contains("No error")) Then
    '                errStr = errStr + "\n" + errStr2
    '            End If
    '        Loop While (Not errStr2.Contains("No error"))
    '        Throw New Exception("Exception: Encountered system error(s)\n" + errStr)
    '    End If
    'End Sub

    'Private Sub setup_meter()

    '    '' """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
    '    ''  © Agilent Technologies, Inc. 2013
    '    ''
    '    '' You have a royalty-free right to use, modify, reproduce and distribute
    '    '' the Sample Application Files (and/or any modified version) in any way
    '    '' you find useful, provided that you agree that Agilent Technologies has no
    '    '' warranty,  obligations or liability for any Sample Application Files.
    '    ''
    '    '' Agilent Technologies provides programming examples for illustration only,
    '    '' This sample program assumes that you are familiar with the programming
    '    '' language being demonstrated and the tools used to create and debug
    '    '' procedures. Agilent Technologies support engineers can help explain the
    '    '' functionality of Agilent Technologies software components and associated
    '    '' commands, but they will not modify these samples to provide added
    '    '' functionality or construct procedures to meet your specific needs.
    '    '' """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
    '    'This example program illustrates how to connect to an instrument
    '    'Gives an example setup for all major function configurations (DCV, DCI, Ohms2W, Ohms 4W, ACV, ACI, Temp, Freq). 
    '    'Gets a single reading from the DMM for each function and reports the result. 
    '    'Ohms 4W shows an autorange setup while all other functions show a direct range setup.

    '    'For more information on getting started using VISA COM I/O operations see the app note located at:
    '    'http:'cp.literature.agilent.com/litweb/pdf/5989-6338EN.pdf
    '    Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
    '    Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 

    '    Try
    '        'Dim DutAddr as String = "GPIB0::22"  'String for GPIB
    '        'Dim DutAddr as String = "TCPIP0::169.254.4.61"   'Example string for LAN
    '        Dim DutAddr As String = Meter_Address  'Example string for USB
    '        'Dim DutAddr As String = "USB0::0x0957::0x1C07::US00000069::0::INSTR"  'String for GPIB
    '        'Dim DutAddr As String = "TCPIP0::156.140.92.16"   'Example string for LAN

    '        myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout

    '        'myDmm.IO.Timeout = 3000  'You can also set your timeout by doing this command, sets to 3 seconds
    '        'First start off with a reset state
    '        myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
    '        myDmm.WriteString("*RST")  'Reset the device
    '        myDmm.WriteString("*IDN?")  'Get the IDN string                
    '        Dim IDN As String = myDmm.ReadString()
    '        TextBox3.Text = IDN 'report the DMM's identity
    '        CheckDMMError(myDmm)  'Check if the DMM has any errors

    '    Catch ex As Exception

    '        Console.WriteLine("Error occured: " + ex.Message)

    '    Finally

    '        'Close out your resources
    '        Try
    '            myDmm.IO.Close()
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(myDmm)
    '        Catch ex As Exception

    '        End Try

    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
    '        Catch ex As Exception

    '        End Try

    '    End Try

    'End Sub

    Private Sub open_com_port(com_num As String)
        ' set the I/O address to the text box in case the user changed it.
        ' bring up the input dialog and save any changes to the text box
        Dim mgr As Ivi.Visa.Interop.ResourceManager
        Dim ioAddress As String
        On Error GoTo ioError


        '  ioAddress = txtAddress.Text
        ioAddress = "ASRL" & com_num & "::INSTR"

        txtAddress.Text = ioAddress
        mgr = New Ivi.Visa.Interop.ResourceManager
        ioDmm = New Ivi.Visa.Interop.FormattedIO488
        ioDmm.IO() = mgr.Open(ioAddress)
        EnableControl(True)
        btnInitIO.BackColor = Color.White


        'HEWLETT-PACKARD,34401A
        Call get_hp_string()
        If txtIDString.Text = "" Then
            btnInitIO.BackColor = Color.Red
            Call close_comm()
            com_meter_ok = False
        Else
            btnInitIO.BackColor = Color.LightGreen
            com_meter_ok = True
        End If

        Exit Sub
ioError:
        MsgBox("InitIO Error:" & vbCrLf & Err.Description)
        btnInitIO.BackColor = Color.Red

    End Sub
    Private Sub close_comm()
        ioDmm.IO.Close()
        EnableControl(False)
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Call close_comm()
    End Sub
    Private Sub get_hp_string()
        Dim result As String
        On Error GoTo ioError

        txtIDString.Text = ""
        ioDmm.WriteString("*idn?")
        result = ioDmm.ReadString
        txtIDString.Text = result
        Exit Sub
ioError:
        MsgBox("GetID Error:" & vbCrLf & Err.Description)
    End Sub

    Private Sub btnGetID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetID.Click
        Call get_hp_string()
    End Sub
    Private Sub btnGetRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRev.Click
        Call get_meter_rev()
    End Sub
    Private Sub get_meter_rev()
        ' Gets the hardware revision from the instrument
        Dim result As String
        On Error GoTo ioError
        ioDmm.WriteString(":Syst:Vers?")
        result = ioDmm.ReadString
        txtRevision.Text = result
        Exit Sub
ioError:
        MsgBox("GetRevision Error:" & vbCrLf & Err.Description)
    End Sub

    Private Sub btnToDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToDisplay.Click
        Call send_to_displays()
    End Sub
    Private Sub send_to_displays()
        ' Send a message to the multimeters display,
        ' and generate a beep
        On Error GoTo ioError
        ioDmm.WriteString(":syst:beep;:disp:text " & "'" & txtToDisplay.Text & "'")
        Exit Sub
ioError:
        MsgBox("Display Error:" & vbCrLf & Err.Description)
    End Sub

    Private Sub btnClearDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDisplay.Click
        Call clear_the_display()
    End Sub
    Private Sub clear_the_display()
        On Error GoTo ioError
        ' Clear the display
        ioDmm.WriteString("Display:text:Clear")
        Exit Sub
ioError:
        MsgBox("Clear Display Error:" & vbCrLf & Err.Description)
    End Sub


    Private Sub read_meter_volt()
        '        Dim Reading As Double 'zzz
        '
        '        On Error GoTo ioError
        '        ioDmm.WriteString("Syst:Rem")
        '        ioDmm.WriteString("Measure:Voltage:DC?")
        '        System.Threading.Thread.Sleep(100) ' Added by tom
        '        Reading = ioDmm.ReadNumber
        '        voltage = Reading
        '        Exit Sub
        'ioError:
        '        MsgBox("Error Getting Reading:" & vbCrLf & Err.Description)

        'USB meter
        Call Read_DC_Volt()





    End Sub
    Private Sub read_meter_ohm()
        '        Dim Reading As Double
        '
        '        On Error GoTo ioError
        '        ioDmm.WriteString("Syst:Rem")
        '        ioDmm.WriteString("Measure:RESistance?")
        '        System.Threading.Thread.Sleep(100) ' Added by tom
        '        Reading = ioDmm.ReadNumber
        '        resistance = Reading
        '        Exit Sub
        'ioError:
        '        MsgBox("Error Getting Reading:" & vbCrLf & Err.Description)


        'new USB meter


        Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
        Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 
        Dim DutAddr As String = Meter_Address  'Example string for USB
        myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout
        myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
        myDmm.WriteString("*RST")  'Reset the device
        myDmm.WriteString("*IDN?")  'Get the IDN string                
        Dim IDN As String = myDmm.ReadString()

        'Configure for OHM 2 wire 100 Ohm range, 100uOhm resolution
        ' myDmm.WriteString("CONF:RES 100, 0.0001")
        myDmm.WriteString("CONF:RES ")
        myDmm.WriteString("READ?")
        Dim Res2WResult As String = myDmm.ReadString()
        resistance = Res2WResult

        CheckDMMError(myDmm)  'Check if the DMM has any errors




    End Sub

    'Private Sub Read_impedance()
    '    Dim x As Integer
    '    Dim Reading As Double

    '    x = 1
    '    Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
    '    Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 
    '    Try
    '        Dim DutAddr As String = Meter_Address  'Example string for USB
    '        myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout
    '        myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
    '        myDmm.WriteString("*RST")  'Reset the device
    '        myDmm.WriteString("*IDN?")  'Get the IDN string                
    '        Dim IDN As String = myDmm.ReadString()
    '        myDmm.WriteString("CONF:RES 10000, 100")
    '        myDmm.WriteString("READ?")
    '        Dim ImpResult As String = myDmm.ReadString()
    '        Reading = ImpResult
    '        resistance = Reading
    '        CheckDMMError(myDmm)  'Check if the DMM has any errors
    '    Catch ex As Exception
    '        MsgBox("Error occured: " + ex.Message)
    '    Finally
    '        Try
    '            myDmm.IO.Close()
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(myDmm)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
    '        Catch ex As Exception
    '        End Try
    '    End Try
    'End Sub

    Private Sub btnTake1AC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTake1AC.Click
        Call get_a_single_reading()
    End Sub
    Private Sub get_a_single_reading()
        ' Set the multimeter for ac voltage reading,
        ' Use default values
        ' Get the reading and put it in first text box
        Dim Reading As Double
        On Error GoTo ioError
        '""""""""""""""""""""""""""""""""""""
        '   Include this line for RS232 only
        ioDmm.WriteString("Syst:Rem")
        ioDmm.WriteString("Measure:Voltage:DC?")
        System.Threading.Thread.Sleep(100) ' Added by tom

        Reading = ioDmm.ReadNumber

        txtReading1.Text = Reading
        txtReading2.Text = ""
        txtReading3.Text = ""
        Exit Sub
ioError:
        MsgBox("Error Getting Reading:" & vbCrLf & Err.Description)

    End Sub

    Private Sub btnTake3DC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTake3DC.Click

        ' Configure the multimeter for dc voltage readings,
        ' 10V range, 0.1V resolution, and 3 readings
        Dim Readings() As Object
        Dim strtemp As String

        On Error GoTo ioError


        '""""""""""""""""""""""""""""""""""""
        '   Include this line for RS232 only
        ioDmm.WriteString("Syst:Rem")
        With ioDmm
            .WriteString(":CONF:VOLT:DC 10, 0.1")
            .WriteString("SAMP:COUN 3")
            ' for RS232 only, a delay may be needed before the Read
            System.Threading.Thread.Sleep(100) ' Added by tom

            .WriteString("Read?")
        End With
        Readings = ioDmm.ReadList

        txtReading1.Text = Readings(0)
        txtReading2.Text = Readings(1)
        txtReading3.Text = Readings(2)

        Exit Sub
ioError:
        MsgBox("Error Getting Readings:" & vbCrLf & Err.Description)
    End Sub
    Function CheckForRPP4COM() As Boolean
        Dim RPP4_COM_Likely As New List(Of String)
        Dim COMPorts As New List(Of String)

        cb_UUT_COM.DataSource = Nothing
        cb_UUT_COM.Items.Clear()
        cb_UUT_COM.Refresh()

        Call enable_uut_pwr()

        Dim i As Integer = 0
        Do Until i = 5 OrElse RPP4_COM_Likely.Any
            Thread.Sleep(1000)
            COMPorts = My.Computer.Ports.SerialPortNames.ToList
            RPP4_COM_Likely = (From n In COMPorts
                               Where n <> ComboBox_com.Text).ToList
            i += 1
        Loop

        'disable_uut_pwr()

        If RPP4_COM_Likely.Any Then
            cb_UUT_COM.DataSource = COMPorts
            cb_UUT_COM.SelectedItem = RPP4_COM_Likely.First
            Return True
        Else
            MsgBox("RPP4 COM not found!")
            Return False
        End If

    End Function
    Sub RefreshAvailCOMs()
        cb_UUT_COM.DataSource = Nothing
        cb_UUT_COM.Refresh()
        ' Show all available COM ports. 
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cb_UUT_COM.Items.Add(sp)
        Next
        cb_UUT_COM.SelectedIndex = cb_UUT_COM.Items.Count - 1
    End Sub
    Private Sub search_all_com_ports()

        Call enable_uut_pwr()

        Dim i As Integer = 0
        For i = 0 To 5
            Button34.BackColor = Color.Yellow
            Button34.Refresh()
            Thread.Sleep(1000)
            Button34.BackColor = Color.Bisque
            Button34.Refresh()
            i += 1
        Next

        RefreshAvailCOMs()

        'ComboBox2.SelectedIndex = 0
        'Call disable_uut_pwr()
    End Sub

    Private Sub EnableControl(ByVal bStatus As Boolean)

        txtIDString.Text = ""
        txtRevision.Text = ""
        txtReading1.Text = ""
        txtReading2.Text = ""
        txtReading3.Text = ""

        btnInitIO.Enabled = Not bStatus
        txtAddress.Enabled = Not bStatus
        txtIDString.Enabled = bStatus
        txtRevision.Enabled = bStatus
        txtReading1.Enabled = bStatus
        txtReading2.Enabled = bStatus
        txtReading3.Enabled = bStatus
        txtToDisplay.Enabled = bStatus
        btnClearDisplay.Enabled = bStatus
        btnClose.Enabled = bStatus
        btnGetID.Enabled = bStatus
        btnGetRev.Enabled = bStatus
        btnTake1AC.Enabled = bStatus
        btnTake3DC.Enabled = bStatus
        btnToDisplay.Enabled = bStatus
    End Sub

    Private MacList As String = ""
    Function LoadMacList()
        MacList = IO.File.ReadAllText("C:\Users\Production1\Desktop\RPP4 MAC ADDRESSES v4.csv")
    End Function

    Function GetMac(SN As String) As String

        If Not MacList.Contains(SN) Then
            MsgBox("Cannot find SN " & SN & " in C:\Users\Production1\Desktop\RPP4 MAC ADDRESSES v4.csv!!!")
        Else
            Dim Line = Split(Split(MacList, SN)(1), vbCrLf)(0)
            Dim Value = Split(Line, ",")(6).Trim.Replace(".", ":")
            'Dim MAC = Split(Value, ".")

            tb_MAC_Full.Text = Value
            tb_MAC_Full.BackColor = Color.LightGreen
        End If





    End Function

    Function GetSubstring() As String

    End Function


    Public Sub frmEZSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMacList()

        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim strIPAddress As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        computer_ip_address = strIPAddress
        comp_ip_address.Text = strIPAddress

        EnableControl(False)

        ComboBox_com.DataSource = My.Computer.Ports.SerialPortNames
        ComboBox1.DataSource = My.Computer.Ports.SerialPortNames

        shadow_reg1 = &HAA
        shadow_reg2 = &H3C
        shadow_reg3 = &H0
        shadow_reg4 = &HFF
        shadow_reg5 = &H0
        shadow_reg6 = &HFF

        Call set_thresholds()

        txt_crc_pulsesvr.Text = "0xfd2c0182"
        txt_crc_rpp4app.Text = "0x76ad1f4d"

    End Sub




    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btn_StartNewTest.Click
        btn_StartNewTest.BackColor = Color.LemonChiffon

        If Not com_test_board_ok = True Then
            MsgBox("Problem with COM Ports.")
            Exit Sub
        End If

        disable_uut_pwr()

        If Not Txt_Tech.Text <> "" Then
            MsgBox("Must enter Technician name.")
            Exit Sub
        End If

        Dim MacReg As New System.Text.RegularExpressions.Regex("^([A-Fa-f0-9]{2}[:]){5}[A-Fa-f0-9]{2}$")

        If Not MacReg.Match(tb_MAC_Full.Text).Success Then
            'If Not MAC1.Text <> "" And Not MAC2.Text <> "" And Not MAC3.Text <> "" And Not MAC4.Text <> "" And Not MAC5.Text <> "" And Not MAC6.Text <> "" Then
            MsgBox("Must enter a valid MAC Address.")
            Exit Sub
        End If

        If Not tb_SNFull.BackColor = Color.LightGreen Then
            MsgBox("Must enter a valid serial number.")
            Exit Sub
        End If

        MsgBox("Set power supply to: 24V, CV, output ON")
        btn_StartNewTest.BackColor = Color.LightGreen
        btn_StartNewTest.Refresh()

        'all_tests_passed = True
        'voltage_test_ok = True
        'ohm_test_ok = True

        Call clear_textboxes()
        btn_ImpedanceTest.BackColor = Color.LemonChiffon

    End Sub

    Private Sub take_3_ohm_readings()
        Call read_meter_ohm()
        Call read_meter_ohm()
        Call read_meter_ohm()
    End Sub

    Private Sub Button42_Click(sender As System.Object, e As System.EventArgs) Handles Button42.Click
        Call clear_textboxes()
        Call disable_uut_pwr()
        Call impedance_test()
    End Sub

    Private Sub Button43_Click(sender As System.Object, e As System.EventArgs) Handles Button43.Click
        Call enable_uut_pwr()
        Thread.Sleep(500)
        Call voltage_test()
    End Sub

    Private Sub impedance_test()

        ohm_test_ok = True
        meter_results = ""

        Call meter(V24_IN)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V24_ohm.Text = resistance
        If resistance >= Val(V24_min_ohm.Text) And resistance <= Val(V24_max_ohm.Text) Then
            V24_ohm.BackColor = Color.LightGreen
        Else
            V24_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V24_ohm.Refresh()
        meter_results = meter_results & "24 Volt Impedance = " & V24_ohm.Text & " Ohms." & vbCrLf

        Call meter(V5)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V5_ohm.Text = resistance
        If resistance >= Val(V5_min_ohm.Text) And resistance <= Val(V5_max_ohm.Text) Then
            V5_ohm.BackColor = Color.LightGreen
        Else
            V5_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V5_ohm.Refresh()
        meter_results = meter_results & "5.0 Volt Impedance = " & V5_ohm.Text & " Ohms." & vbCrLf

        Call meter(V3_3)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V3_3_ohm.Text = resistance
        If resistance >= Val(V3_3_min_ohm.Text) And resistance <= Val(V3_3_max_ohm.Text) Then
            V3_3_ohm.BackColor = Color.LightGreen
        Else
            V3_3_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3_ohm.Refresh()
        meter_results = meter_results & "3.3 Volt Impedance = " & V3_3_ohm.Text & " Ohms." & vbCrLf

        Call meter(VDD_MPU_CPU)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        VDD_MPU_ohm.Text = resistance
        If resistance >= Val(VDD_MPU_min_ohm.Text) And resistance <= Val(VDD_MPU_max_ohm.Text) Then
            VDD_MPU_ohm.BackColor = Color.LightGreen
        Else
            VDD_MPU_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        VDD_MPU_ohm.Refresh()
        meter_results = meter_results & "VDD MPU Volt Impedance = " & VDD_MPU_ohm.Text & " Ohms." & vbCrLf

        Call meter(V1_8A)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V1_8A_ohm.Text = resistance
        If resistance >= Val(V1_8A_min_ohm.Text) And resistance <= Val(V1_8A_max_ohm.Text) Then
            V1_8A_ohm.BackColor = Color.LightGreen
        Else
            V1_8A_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8A_ohm.Refresh()
        meter_results = meter_results & "1.8A Volt Impedance = " & V1_8A_ohm.Text & " Ohms." & vbCrLf


        '    Call meter(V5A_MINUS)
        '    Call enable_relay6()
        '    Call take_3_ohm_readings()
        '    Call disable_relay6()
        '    resistance = Math.Round(resistance, 0)

        'V5AMinus_ohm.Text = resistance
        'If resistance >= Val(V5AMinus_min_ohm.Text) And resistance <= Val(V5AMinus_max_ohm.Text) Then
        ' V5AMinus_ohm.BackColor = Color.LightGreen
        ' Else
        ' V5AMinus_ohm.BackColor = Color.Red
        ' ohm_test_ok = False
        ' meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        ' End If
        ' V5AMinus_ohm.Refresh()
        ' meter_results = meter_results & "-5.0 Volt Impedance = " & V5AMinus_ohm.Text & " Ohms." & vbCrLf

        Call meter(V3_3CPU)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V3_3_CPU_ohm.Text = resistance
        If resistance >= Val(V3_3_CPU_min_ohm.Text) And resistance <= Val(V3_3_CPU_max_ohm.Text) Then
            V3_3_CPU_ohm.BackColor = Color.LightGreen
        Else
            V3_3_CPU_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3_CPU_ohm.Refresh()
        meter_results = meter_results & "3.3 CPU Volt Impedance = " & V3_3_CPU_ohm.Text & " Ohms." & vbCrLf

        Call meter(V1_8FPGA)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V1_8FPGA_ohm.Text = resistance
        If resistance >= Val(V1_8FPGA_min_ohm.Text) And resistance <= Val(V1_8FPGA_max_ohm.Text) Then
            V1_8FPGA_ohm.BackColor = Color.LightGreen
        Else
            V1_8FPGA_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8FPGA_ohm.Refresh()
        meter_results = meter_results & "1.8 FPGA Volt Impedance = " & V1_8FPGA_ohm.Text & " Ohms." & vbCrLf

        Call meter(V1_2)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V1_2_ohm.Text = resistance
        If resistance >= Val(V1_2_min_ohm.Text) And resistance <= Val(V1_2_max_ohm.Text) Then
            V1_2_ohm.BackColor = Color.LightGreen
        Else
            V1_2_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_2_ohm.Refresh()
        meter_results = meter_results & "1.2 Volt Impedance = " & V1_2_ohm.Text & " Ohms." & vbCrLf

        Call meter(V5A_PLUS)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V5A_ohm.Text = resistance
        If resistance >= Val(V5A_min_ohm.Text) And resistance <= Val(V5A_max_ohm.Text) Then
            V5A_ohm.BackColor = Color.LightGreen
        Else
            V5A_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V5A_ohm.Refresh()
        meter_results = meter_results & "5.0A Volt Impedance = " & V5A_ohm.Text & " Ohms." & vbCrLf

        Call meter(V3_3A)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V3_3A_ohm.Text = resistance
        If resistance >= Val(V3_3A_min_ohm.Text) And resistance <= Val(V3_3A_max_ohm.Text) Then
            V3_3A_ohm.BackColor = Color.LightGreen
        Else
            V3_3A_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3A_ohm.Refresh()
        meter_results = meter_results & "3.3A Volt Impedance = " & V3_3A_ohm.Text & " Ohms." & vbCrLf

        Call meter(VDD_CORE_CPU)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        VDD_Core_ohm.Text = resistance
        If resistance >= Val(VDD_Core_min_ohm.Text) And resistance <= Val(VDD_Core_max_ohm.Text) Then
            VDD_Core_ohm.BackColor = Color.LightGreen
        Else
            VDD_Core_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        VDD_Core_ohm.Refresh()
        meter_results = meter_results & "VDD Core Volt Impedance = " & VDD_Core_ohm.Text & " Ohms." & vbCrLf

        Call meter(V1_8)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        V1_8_ohm.Text = resistance
        If resistance >= Val(V1_8_min_ohm.Text) And resistance <= Val(V1_8_max_ohm.Text) Then
            V1_8_ohm.BackColor = Color.LightGreen
        Else
            V1_8_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8_ohm.Refresh()
        meter_results = meter_results & "1.8 Volt Impedance = " & V1_8_ohm.Text & " Ohms." & vbCrLf

        Call meter(FPGA_VTT)
        Call take_3_ohm_readings()
        resistance = Math.Round(resistance, 0)
        FPGA_VTT_ohm.Text = resistance
        If resistance >= Val(FPGA_VTT_min_ohm.Text) And resistance <= Val(FPGA_VTT_max_ohm.Text) Then
            FPGA_VTT_ohm.BackColor = Color.LightGreen
        Else
            FPGA_VTT_ohm.BackColor = Color.Red
            ohm_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        FPGA_VTT_ohm.Refresh()
        meter_results = meter_results & "FPGA VTT Volt Impedance = " & FPGA_VTT_ohm.Text & " Ohms." & vbCrLf


    End Sub
    Private Sub voltage_test()

        meter_results = meter_results & vbCrLf
        Call meter(V24_IN)
        Thread.Sleep(100)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V24_volt.Text = voltage
        If voltage >= Val(V24_min_volt.Text) And voltage <= Val(V24_max_volt.Text) Then
            V24_volt.BackColor = Color.LightGreen
        Else
            V24_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V24_volt.Refresh()
        meter_results = meter_results & "24V Voltage  = " & V24_volt.Text & " Volts." & vbCrLf


        Call meter(V5)
        Thread.Sleep(100)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V5_volt.Text = voltage
        If voltage >= Val(V5_min_volt.Text) And voltage <= Val(V5_max_volt.Text) Then
            V5_volt.BackColor = Color.LightGreen
        Else
            V5_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V5_volt.Refresh()
        meter_results = meter_results & "5.0 Voltage  = " & V5_volt.Text & " Volts." & vbCrLf

        Call meter(V3_3)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V3_3_volt.Text = voltage
        If voltage >= Val(V3_3_min_volt.Text) And voltage <= Val(V3_3_max_volt.Text) Then
            V3_3_volt.BackColor = Color.LightGreen
        Else
            V3_3_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3_volt.Refresh()
        meter_results = meter_results & "3.3 Voltage  = " & V3_3_volt.Text & " Volts." & vbCrLf

        Call meter(VDD_MPU_CPU)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        VDD_MPU_volt.Text = voltage
        If voltage >= Val(VDD_MPU_min_volt.Text) And voltage <= Val(VDD_MPU_max_volt.Text) Then
            VDD_MPU_volt.BackColor = Color.LightGreen
        Else
            VDD_MPU_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        VDD_MPU_volt.Refresh()
        meter_results = meter_results & "VDD MPU Voltage  = " & VDD_MPU_volt.Text & " Volts." & vbCrLf

        Call meter(V1_8A)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V1_8A_volt.Text = voltage
        If voltage >= Val(V1_8A_min_volt.Text) And voltage <= Val(V1_8A_max_volt.Text) Then
            V1_8A_volt.BackColor = Color.LightGreen
        Else
            V1_8A_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8A_volt.Refresh()
        meter_results = meter_results & "1.8A Voltage  = " & V1_8A_volt.Text & " Volts." & vbCrLf




        Call meter(V5A_MINUS)
        Call enable_relay6()
        Call read_meter_volt()
        Call disable_relay6()
        voltage = Math.Round(voltage, 2)
        V5AMinus_volt.Text = voltage
        If voltage >= Val(V5AMinus_min_volt.Text) And voltage <= Val(V5AMinus_max_volt.Text) Then
            V5AMinus_volt.BackColor = Color.LightGreen
        Else
            V5AMinus_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V5AMinus_volt.Refresh()
        meter_results = meter_results & "-5.0 Voltage  = " & V5AMinus_volt.Text & " Volts." & vbCrLf


        Call meter(V3_3CPU)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V3_3_CPU_volt.Text = voltage
        If voltage >= Val(V3_3_CPU_min_volt.Text) And voltage <= Val(V3_3_CPU_max_volt.Text) Then
            V3_3_CPU_volt.BackColor = Color.LightGreen
        Else
            V3_3_CPU_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3_CPU_volt.Refresh()
        meter_results = meter_results & "3.3 CPU Voltage  = " & V3_3_CPU_volt.Text & " Volts." & vbCrLf

        Call meter(V1_8FPGA)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V1_8FPGA_volt.Text = voltage
        If voltage >= Val(V1_8FPGA_min_volt.Text) And voltage <= Val(V1_8FPGA_max_volt.Text) Then
            V1_8FPGA_volt.BackColor = Color.LightGreen
        Else
            V1_8FPGA_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8FPGA_volt.Refresh()
        meter_results = meter_results & "1.8 FPGA Voltage  = " & V1_8FPGA_volt.Text & " Volts." & vbCrLf

        Call meter(V1_2)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V1_2_volt.Text = voltage
        If voltage >= Val(V1_2_min_volt.Text) And voltage <= Val(V1_2_max_volt.Text) Then
            V1_2_volt.BackColor = Color.LightGreen
        Else
            V1_2_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_2_volt.Refresh()
        meter_results = meter_results & "1.2 Voltage  = " & V1_2_volt.Text & " Volts." & vbCrLf

        Call meter(V5A_PLUS)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V5A_volt.Text = voltage
        If voltage >= Val(V5A_min_volt.Text) And voltage <= Val(V5A_max_volt.Text) Then
            V5A_volt.BackColor = Color.LightGreen
        Else
            V5A_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V5A_volt.Refresh()
        meter_results = meter_results & "5.0A Voltage  = " & V5A_volt.Text & " Volts." & vbCrLf

        Call meter(V3_3A)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V3_3A_volt.Text = voltage
        If voltage >= Val(V3_3A_min_volt.Text) And voltage <= Val(V3_3A_max_volt.Text) Then
            V3_3A_volt.BackColor = Color.LightGreen
        Else
            V3_3A_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V3_3A_volt.Refresh()
        meter_results = meter_results & "3.3A Voltage  = " & V3_3A_volt.Text & " Volts." & vbCrLf

        Call meter(VDD_CORE_CPU)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        VDD_Core_volt.Text = voltage
        If voltage >= Val(VDD_Core_min_volt.Text) And voltage <= Val(VDD_Core_max_volt.Text) Then
            VDD_Core_volt.BackColor = Color.LightGreen
        Else
            VDD_Core_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        VDD_Core_volt.Refresh()
        meter_results = meter_results & "VDD Core Voltage  = " & VDD_Core_volt.Text & " Volts." & vbCrLf

        Call meter(V1_8)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        V1_8_volt.Text = voltage
        If voltage >= Val(V1_8_min_volt.Text) And voltage <= Val(V1_8_max_volt.Text) Then
            V1_8_volt.BackColor = Color.LightGreen
        Else
            V1_8_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        V1_8_volt.Refresh()
        meter_results = meter_results & "1.8 Voltage  = " & V1_8_volt.Text & " Volts." & vbCrLf

        Call meter(FPGA_VTT)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        FPGA_VTT_volt.Text = voltage
        If voltage >= Val(FPGA_VTT_min_volt.Text) And voltage <= Val(FPGA_VTT_max_volt.Text) Then
            FPGA_VTT_volt.BackColor = Color.LightGreen
        Else
            FPGA_VTT_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        FPGA_VTT_volt.Refresh()
        meter_results = meter_results & "FPGA VTT Voltage  = " & FPGA_VTT_volt.Text & " Volts." & vbCrLf

        'Skip this reading until after the FPGA is programmed

        'Call meter(FPGA_DDR_VREF)
        'Call read_meter_volt()
        'voltage = Math.Round(voltage, 2)
        'DDR_VREF_volt.Text = voltage
        '     If voltage >= Val(V24_min_volt.Text) And voltage <= Val(DDR_VREF_max_volt.Text) Then
        ' DDR_VREF_volt.BackColor = Color.LightGreen
        ' Else
        ' DDR_VREF_volt.BackColor = Color.Red
        ' voltage_test_ok = False
        ' meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        ' End If
        ' DDR_VREF_volt.Refresh()
        ' meter_results = meter_results & "FPGA VREF Voltage  = " & DDR_VREF_volt.Text & " Volts." & vbCrLf
        btn_ImpedanceTest.BackColor = Color.LightGreen
    End Sub

    Private Sub Text3_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Tech.TextChanged
        technician = Txt_Tech.Text
        If Txt_Tech.Text <> "" Then
            Txt_Tech.BackColor = Color.LightGreen
        End If
    End Sub


    Private Sub Command6_Click(sender As System.Object, e As System.EventArgs) Handles Command6.Click
        Call close_rpp4_port()
        Call disable_uut_pwr()
        Call save_test1()
        Command6.BackColor = Color.LightGreen
        Command6.Refresh()
    End Sub
    Sub InitTestData()
        tb_MAC_Full.Text = ""
        tb_MAC_Full.BackColor = Color.White
        tb_SNFull.Text = ""
        tb_SNFull.BackColor = Color.White
    End Sub

    Private Sub save_test1()
        Dim overwrite2_stat%

        'file_name = "RPP4_" & sn_pre.Text & sn.Text & ".txt"
        file_name = "RPP4_" & tb_SNFull.Text & ".txt"

        If Dir(file_name) <> "" Then 'file exists
            overwrite2_stat% = MsgBox("The test log already exists, do you want to overwrite it?", vbInformation + vbYesNo, "RPP4 Test")
            If overwrite2_stat = vbYes Then
                Call save_results()
            End If
        Else 'okay to write results
            Call save_results()
        End If

        InitTestData()

    End Sub

    Public Sub save_results()
        Dim str_test_header As String
        Dim total_failure_string As String
        Dim results_string As String

        'If MAC5.Text = "" Or MAC6.Text = "" Then
        '    MsgBox("You are missing the MAC Address.")
        'End If

        current_date = DateValue(Now)
        current_time = TimeValue(Now)
        str_test_header = "RPP4 Test Report." & vbCrLf
        'str_test_header = str_test_header & "Serial Number: " & sn_pre.Text & sn.Text & vbCrLf
        str_test_header = str_test_header & "Serial Number: " & tb_SNFull.Text & vbCrLf

        str_test_header = str_test_header & "MAC Address: " & tb_MAC_Full.Text & vbCrLf '& MAC1.Text & ":" & MAC2.Text & ":" & MAC3.Text & ":" & MAC4.Text & ":" & MAC5.Text & ":" & MAC6.Text & vbCrLf
        str_test_header = str_test_header & "DATE: " & current_date & vbCrLf
        str_test_header = str_test_header & "Technician: " & Txt_Tech.Text & vbCrLf & vbCrLf


        results_string = "Test Data." & vbCrLf
        results_string = results_string & "--------------------------------------------------------------------------" & vbCrLf & vbCrLf

        results_string = results_string & meter_results & vbCrLf & vbCrLf

        Call test_mac()
        results_string = results_string & MAC_test_str & tb_ProgrammedMAC.Text & vbCrLf & vbCrLf

        results_string = results_string & mem_test_result & vbCrLf

        Call test_led15()
        results_string = results_string & LED15_on_str & vbCrLf
        Call test_led7()
        results_string = results_string & LED7_blinking_str & vbCrLf

        Call test_fpga_ver()
        results_string = results_string & ver_test_str & vbCrLf
        Call test_build()
        results_string = results_string & ver_test_str & vbCrLf


        results_string = results_string & crc_test_result & vbCrLf

        Call test_temp()
        results_string = results_string & temp_test_str & vbCrLf

        results_string = results_string & RTD_test_str & vbCrLf

        results_string = results_string & iloop_test_str & vbCrLf

        Call test_preamp()
        results_string = results_string & preamp_version_test_str & vbCrLf

        Call test_ngen()
        results_string = results_string & ngen_test_str & vbCrLf

        Call test_moisture()
        results_string = results_string & moisture_test_str & vbCrLf

        Call test_noise()
        results_string = results_string & avg_test_str & vbCrLf
        results_string = results_string & stdev_test_str & vbCrLf

        Call test_sawtooth()
        results_string = results_string & sawtooth_test_str & vbCrLf


        'check for any red failures
        If btn_StartNewTest.BackColor = Color.Red Or
         btn_LoadLinux.BackColor = Color.Red Or
         Button44.BackColor = Color.Red Or
         LED_15_on_check.BackColor = Color.Red Or
         tb_ProgrammedMAC.BackColor = Color.Red Or
         LED7_blinking_check.BackColor = Color.Red Or
         Button16.BackColor = Color.Red Or
         btn_MemoryTest.BackColor = Color.Red Or
         Button36.BackColor = Color.Red Or
         fpga_ver.BackColor = Color.Red Or
        build_ver.BackColor = Color.Red Or
        Button46.BackColor = Color.Red Or
        T1.BackColor = Color.Red Or
        T2.BackColor = Color.Red Or
        T3.BackColor = Color.Red Or
        T4.BackColor = Color.Red Or
        Button23.BackColor = Color.Red Or
        L1_4ma.BackColor = Color.Red Or
        L1_20ma.BackColor = Color.Red Or
        L2_4ma.BackColor = Color.Red Or
        L2_20ma.BackColor = Color.Red Or
        L3_4ma.BackColor = Color.Red Or
        L3_20ma.BackColor = Color.Red Or
        L4_4ma.BackColor = Color.Red Or
        L4_20ma.BackColor = Color.Red Or
        RTD_cur_open.BackColor = Color.Red Or
        RTD_sense_open.BackColor = Color.Red Or
        RTD_cur_110.BackColor = Color.Red Or
        RTD_sense_110.BackColor = Color.Red Or
        Preamp_version.BackColor = Color.Red Or
        sawtooth_check.BackColor = Color.Red Or
        Avg.BackColor = Color.Red Or
        Stdev.BackColor = Color.Red Or
        moisture_test.BackColor = Color.Red Or
        NGEN_4.BackColor = Color.Red Or
        NGEN_12.BackColor = Color.Red Or
        Button1.BackColor = Color.Red Or voltage_test_ok = False Or ohm_test_ok = False Then

            total_failure_string = "Failures Detected!!!" & vbCrLf
            total_failure_string = total_failure_string & "Failures Detected!!!" & vbCrLf
            total_failure_string = total_failure_string & "Failures Detected!!!" & vbCrLf
            total_failure_string = total_failure_string & "Failures Detected!!!" & vbCrLf & vbCrLf
            file_name = "RPP4_" & tb_SNFull.Text & "-FAIL.txt"

        Else
            total_failure_string = "All Tests Passed!!!" & vbCrLf
            total_failure_string = total_failure_string & "All Tests Passed!!!" & vbCrLf
            total_failure_string = total_failure_string & "All Tests Passed!!!" & vbCrLf
            total_failure_string = total_failure_string & "All Tests Passed!!!" & vbCrLf & vbCrLf
            file_name = "RPP4_" & tb_SNFull.Text & ".txt"

        End If


        str_test_header = str_test_header & total_failure_string & results_string & vbCrLf

        '    str_test_header = str_test_header & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '    str_test_header = str_test_header & "Debug Port ******************************************"
        '    str_test_header = str_test_header & "Debug Port ******************************************"
        '    str_test_header = str_test_header & "Debug Port ******************************************"
        '    str_test_header = str_test_header & "Debug Port ******************************************"
        '    str_test_header = str_test_header & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        '  str_test_header = str_test_header & RichTextBox1.Text


        My.Computer.FileSystem.WriteAllText(file_name, str_test_header, False) 'false overwrites, true appends
        MsgBox("Test Log Saved.")

        btn_StartNewTest.BackColor = Color.White


    End Sub

    'Private Sub save_test2()
    '    file_name = sn_pre.Text & ".txt"
    '    Call save_results2()
    'End Sub
    'Public Sub save_results2()
    '    Dim tmp_test_number As Long

    '    current_date = DateValue(Now)
    '    current_time = TimeValue(Now)
    '    str_test_result = "NuFACE Final Test - BOX Number: " & sn_pre.Text & vbCrLf
    '    str_test_result = str_test_result & "DATE: " & current_date & vbCrLf & vbCrLf
    '    tmp_test_number = 0
    '    file_name = "Final Test Box P-" & sn_pre.Text & ".txt"

    '    My.Computer.FileSystem.WriteAllText(file_name, str_test_result, False) 'false overwrites, true appends

    'End Sub



    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim printmenu As New Form1
        print_only_once = False
        printmenu.Show() 'See the Print function Class Form1
        '     printmenu.Close()
    End Sub


    'OPEN File *********************************************************************************
    'OPEN File *********************************************************************************
    'OPEN File *********************************************************************************
    'OPEN File *********************************************************************************
    'OPEN File *********************************************************************************

    Public Function OpenFile() As String
        Dim directory As String = My.Application.Info.DirectoryPath
        'declare a string, this is will contain the filename that we return
        Dim strFileName As String
        strFileName = ""

        'declare a new open file dialog
        Dim fileDialogBox As New OpenFileDialog()
        fileDialogBox.Filter = "Rich Text Format (*.rtf)|*.rtf|" _
               & "Text Files (*.txt)|*.txt|" _
               & "Word Documents (*.doc;*.docx)|*.doc;*.docx|" _
               & "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|" _
               & "All Files(*.*)|"
        'this sets the default filter that we created in the line above, if you don't 
        'set a FilterIndex it will automatically default to 1
        fileDialogBox.FilterIndex = 2
        fileDialogBox.InitialDirectory = directory
        'Check to see if the user clicked the open button
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            strFileName = fileDialogBox.FileName
            'Else
            '   MsgBox("You did not select a file!")
        End If
        'return the name of the file
        Return strFileName
    End Function





    Private Sub GetReadings()
        Dim Readings() As Object
        Dim strtemp As String
        Dim i As Long

        On Error GoTo ioError
        '""""""""""""""""""""""""""""""""""""
        '   Include this line for RS232 only
        ioDmm.WriteString("Syst:Rem")
        With ioDmm
            .WriteString(":CONF:VOLT:DC 40, 1")
            .WriteString("TRIG:SOURce IMM")
            .WriteString("TRIG:DELay 0")
            .WriteString("SAMP:COUN 250")
            ' for RS232 only, a delay may be needed before the Read
            System.Threading.Thread.Sleep(100) ' Added by tom
            .WriteString("Read?")
        End With
        Readings = ioDmm.ReadList

        i = 30
        Do While i < 248
            pos_neg(i) = Convert.ToInt64(Readings(i))
            i = i + 1
        Loop
        Exit Sub
ioError:
        MsgBox("Error Getting Readings:" & vbCrLf & Err.Description)

    End Sub


    Private Sub Command4_Click(sender As System.Object, e As System.EventArgs)
        Dim Reading As Double
        ioDmm.WriteString("Syst:Rem")
        With ioDmm
            .WriteString("Measure:Current:DC?")
        End With
        Reading = ioDmm.ReadNumber
        charge_current = Reading
    End Sub




    Private Sub Command_wr0_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr0.Click
        sram = Convert.ToInt32(Text_wr0.Text, 16)
        Call WR_sram()
    End Sub
    Private Sub WR_sram()
        Call send_data(sram, COMMAND_Lc)
    End Sub
    Private Sub Command_wr1_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr1.Click
        led_value = Convert.ToInt32(Text_wr1.Text, 16)
        Call WR_leds()
    End Sub
    Private Sub WR_leds()
        Call send_data(led_value, COMMAND_J)
    End Sub
    Private Sub Command_wr2_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr2.Click
        reg2 = Convert.ToInt32(Text_wr2.Text, 16)
        Call WR_reg2()
    End Sub
    Private Sub WR_reg2()
        Call send_data(reg2, COMMAND_K)
    End Sub
    Private Sub Command_wr3_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr3.Click
        reg3 = Convert.ToInt32(Text_wr3.Text, 16)
        Call WR_reg3()
    End Sub
    Private Sub WR_reg3()
        Call send_data(reg3, COMMAND_L)
    End Sub
    Private Sub Command_wr4_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr4.Click
        dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        Call WR_dip_switch()
    End Sub
    Private Sub WR_dip_switch()
        Call send_data(dip_switch, COMMAND_M)
    End Sub
    Private Sub Command_wr5_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr5.Click
        reg5 = Convert.ToInt32(Text_wr5.Text, 16)
        Call WR_reg5()
    End Sub
    Private Sub WR_reg5()
        Call send_data(reg5, COMMAND_N)
    End Sub
    Private Sub Command_wr6_Click(sender As System.Object, e As System.EventArgs) Handles Command_wr6.Click
        reg6 = Convert.ToInt32(Text_wr6.Text, 16)
        Call WR_reg6()
    End Sub
    Private Sub WR_reg6()
        Call send_data(reg6, COMMAND_O)
    End Sub





    Private Sub en_bus1_Click(sender As System.Object, e As System.EventArgs) Handles en_bus1.Click
        Call enable_jtag()
    End Sub
    Private Sub enable_jtag()
        shadow_reg2 = shadow_reg2 Or BIT0
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_bus1_Click(sender As System.Object, e As System.EventArgs) Handles dis_bus1.Click
        Call disable_jtag()
    End Sub
    Private Sub disable_jtag()
        shadow_reg2 = shadow_reg2 And CLEARBIT0
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_bus2_Click(sender As System.Object, e As System.EventArgs) Handles en_bus2.Click
        Call enable_fpga()
    End Sub
    Private Sub enable_fpga()
        shadow_reg2 = shadow_reg2 Or BIT1
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_bus2_Click(sender As System.Object, e As System.EventArgs) Handles dis_bus2.Click
        Call disable_jtag()
    End Sub
    Private Sub disable_fpga()
        shadow_reg2 = shadow_reg2 And CLEARBIT1
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_pwr1_Click(sender As System.Object, e As System.EventArgs) Handles en_pwr1.Click
        Call enable_jtag_pwr()
    End Sub
    Private Sub enable_jtag_pwr()
        shadow_reg2 = shadow_reg2 And CLEARBIT2
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_pwr1_Click(sender As System.Object, e As System.EventArgs) Handles dis_pwr1.Click
        Call disable_jtag_pwr()
    End Sub
    Private Sub disable_jtag_pwr()
        shadow_reg2 = shadow_reg2 Or BIT2
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_pwr2_Click(sender As System.Object, e As System.EventArgs) Handles en_pwr2.Click
        Call enable_fpga_pwr()
    End Sub
    Private Sub enable_fpga_pwr()
        shadow_reg2 = shadow_reg2 And CLEARBIT3
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_pwr2_Click(sender As System.Object, e As System.EventArgs) Handles dis_pwr2.Click
        Call disable_fpga_pwr()
    End Sub
    Private Sub disable_fpga_pwr()
        shadow_reg2 = shadow_reg2 Or BIT3
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_pb_rst_Click(sender As System.Object, e As System.EventArgs) Handles en_pb_rst.Click
        Call enable_pbrst()
    End Sub
    Private Sub enable_pbrst()
        shadow_reg2 = shadow_reg2 And CLEARBIT4
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_pb_rst_Click(sender As System.Object, e As System.EventArgs) Handles dis_pb_rst.Click
        Call disable_pbrst()
    End Sub
    Private Sub disable_pbrst()
        shadow_reg2 = shadow_reg2 Or BIT4
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_rtd_Click(sender As System.Object, e As System.EventArgs) Handles en_rtd.Click
        Call enable_rtd()
    End Sub
    Private Sub enable_rtd()
        shadow_reg2 = shadow_reg2 And CLEARBIT5
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_rtd_Click(sender As System.Object, e As System.EventArgs) Handles dis_rtd.Click
        Call disable_rtd()
    End Sub
    Private Sub disable_rtd()
        shadow_reg2 = shadow_reg2 Or BIT5
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub en_uut_pwr_Click(sender As System.Object, e As System.EventArgs) Handles en_uut_pwr.Click
        Call enable_uut_pwr()
    End Sub
    Private Sub enable_uut_pwr()
        shadow_reg2 = shadow_reg2 Or BIT7
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub
    Private Sub dis_uut_pwr_Click(sender As System.Object, e As System.EventArgs) Handles dis_uut_pwr.Click
        Call disable_uut_pwr()
    End Sub
    Private Sub disable_uut_pwr()
        shadow_reg2 = shadow_reg2 And CLEARBIT7
        Call send_data(shadow_reg2, COMMAND_K)
    End Sub




    Private Sub en_rel1_Click(sender As System.Object, e As System.EventArgs) Handles en_rel1.Click
        Call enable_relay1()
    End Sub
    Private Sub enable_relay1()
        shadow_reg3 = shadow_reg3 Or BIT0
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel1_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel1.Click
        Call disable_relay1()
    End Sub
    Private Sub disable_relay1()
        shadow_reg3 = shadow_reg3 And CLEARBIT0
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel2_Click(sender As System.Object, e As System.EventArgs) Handles en_rel2.Click
        Call enable_relay2()
    End Sub
    Private Sub enable_relay2()
        shadow_reg3 = shadow_reg3 Or BIT1
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel2_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel2.Click
        Call disable_relay2()
    End Sub
    Private Sub disable_relay2()
        shadow_reg3 = shadow_reg3 And CLEARBIT1
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel3_Click(sender As System.Object, e As System.EventArgs) Handles en_rel3.Click
        Call enable_relay3()
    End Sub
    Private Sub enable_relay3()
        shadow_reg3 = shadow_reg3 Or BIT2
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel3_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel3.Click
        Call disable_relay3()
    End Sub
    Private Sub disable_relay3()
        shadow_reg3 = shadow_reg3 And CLEARBIT2
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel4_Click(sender As System.Object, e As System.EventArgs) Handles en_rel4.Click
        Call enable_relay4()
    End Sub
    Private Sub enable_relay4()
        shadow_reg3 = shadow_reg3 Or BIT3
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel4_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel4.Click
        Call disable_relay4()
    End Sub
    Private Sub disable_relay4()
        shadow_reg3 = shadow_reg3 And CLEARBIT3
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel5_Click(sender As System.Object, e As System.EventArgs) Handles en_rel5.Click
        Call enable_relay5()
    End Sub
    Private Sub enable_relay5()
        shadow_reg3 = shadow_reg3 Or BIT4
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel5_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel5.Click
        Call disable_relay5()
    End Sub
    Private Sub disable_relay5()
        shadow_reg3 = shadow_reg3 And CLEARBIT4
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel6_Click(sender As System.Object, e As System.EventArgs) Handles en_rel6.Click
        Call enable_relay6()
    End Sub
    Private Sub enable_relay6()
        shadow_reg3 = shadow_reg3 Or BIT5
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel6_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel6.Click
        Call disable_relay6()
    End Sub
    Private Sub disable_relay6()
        shadow_reg3 = shadow_reg3 And CLEARBIT5
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub en_rel7_Click(sender As System.Object, e As System.EventArgs) Handles en_rel7.Click
        Call enable_relay7()
    End Sub
    Private Sub enable_relay7()
        shadow_reg3 = shadow_reg3 Or BIT6
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_rel7_Click(sender As System.Object, e As System.EventArgs) Handles dis_rel7.Click
        Call disable_relay7()
    End Sub
    Private Sub disable_relay7()
        shadow_reg3 = shadow_reg3 And CLEARBIT6
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub
    Private Sub dis_all_relay_Click(sender As System.Object, e As System.EventArgs) Handles dis_all_relay.Click
        Call disable_all_relays()
    End Sub
    Private Sub disable_all_relays()
        shadow_reg3 = shadow_reg3 And 0
        Call send_data(shadow_reg3, COMMAND_L)
    End Sub




    Private Sub en_loop1_Click(sender As System.Object, e As System.EventArgs) Handles en_loop1.Click
        Call enable_loop1()
    End Sub
    Private Sub enable_loop1()
        shadow_reg5 = shadow_reg5 Or BIT0
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub dis_loop1_Click(sender As System.Object, e As System.EventArgs) Handles dis_loop1.Click
        Call disable_loop1()
    End Sub
    Private Sub disable_loop1()
        shadow_reg5 = shadow_reg5 And CLEARBIT0
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub en_loop2_Click(sender As System.Object, e As System.EventArgs) Handles en_loop2.Click
        Call enable_loop2()
    End Sub
    Private Sub enable_loop2()
        shadow_reg5 = shadow_reg5 Or BIT1
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub dis_loop2_Click(sender As System.Object, e As System.EventArgs) Handles dis_loop2.Click
        Call disable_loop2()
    End Sub
    Private Sub disable_loop2()
        shadow_reg5 = shadow_reg5 And CLEARBIT1
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub en_loop3_Click(sender As System.Object, e As System.EventArgs) Handles en_loop3.Click
        Call enable_loop3()
    End Sub
    Private Sub enable_loop3()
        shadow_reg5 = shadow_reg5 Or BIT2
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub dis_loop3_Click(sender As System.Object, e As System.EventArgs) Handles dis_loop3.Click
        Call disable_loop3()
    End Sub
    Private Sub disable_loop3()
        shadow_reg5 = shadow_reg5 And CLEARBIT2
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub en_loop4_Click(sender As System.Object, e As System.EventArgs) Handles en_loop4.Click
        Call enable_loop4()
    End Sub
    Private Sub enable_loop4()
        shadow_reg5 = shadow_reg5 Or BIT3
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub
    Private Sub dis_loop4_Click(sender As System.Object, e As System.EventArgs) Handles dis_loop4.Click
        Call disable_loop4()
    End Sub
    Private Sub disable_loop4()
        shadow_reg5 = shadow_reg5 And CLEARBIT3
        Call send_data(shadow_reg5, COMMAND_N)
    End Sub






    Public Sub update_write_register(wr_reg_value As String) 'FIXED
        Call send_data(wr_reg_value, command_value)
    End Sub


    '   Public Function update_write_register(wr_reg_str As String) 'FIXED
    ' Dim lngLen As Long
    ' Dim wr_reg_value As Long
    '
    '        If IsNumeric("&H" & wr_reg_str) Then
    '            lngLen = Len(wr_reg_str)
    '            If lngLen = 1 Then
    '                Call compute_hex1(wr_reg_str)
    '                wr_reg_value = digit1
    '               Call send_data(wr_reg_value, command_value)
    '               TextBox2.BackColor = Color.LightGreen
    '           ElseIf lngLen = 2 Then
    '               Call compute_hex2(wr_reg_str)
    '               wr_reg_value = digit1 + digit2
    '               Call send_data(wr_reg_value, command_value)
    '           Else
    '               MsgBox("Must enter a 1 or 2 digit value")
    '           End If
    '       Else
    '           MsgBox("Invalid HEX Number")
    '       End If
    '
    '    End Function

    Public Sub compute_hex1(temp_str As String)
        temp_str = Char.ToUpper(temp_str)
        Select Case temp_str
            Case "A"
                digit1 = &HA
            Case "B"
                digit1 = &HB
            Case "C"
                digit1 = &HC
            Case "D"
                digit1 = &HD
            Case "E"
                digit1 = &HE
            Case "F"
                digit1 = &HF
            Case Else
                digit1 = Val(temp_str)
        End Select

    End Sub

    Public Sub compute_hex2(temp_str2 As String)
        Dim temp_str3 As String

        temp_str3 = Mid$(temp_str2, 1, 1)
        temp_str3 = Char.ToUpper(temp_str3)
        Select Case temp_str3
            Case "A"
                digit2 = &HA0
            Case "B"
                digit2 = &HB0
            Case "C"
                digit2 = &HC0
            Case "D"
                digit2 = &HD0
            Case "E"
                digit2 = &HE0
            Case "F"
                digit2 = &HF0
            Case Else
                digit2 = Val(temp_str3) * &H10
        End Select

        temp_str3 = Mid$(temp_str2, 2, 1)
        Call compute_hex1(temp_str3)
    End Sub

    Private Sub Command_rd0_Click(sender As System.Object, e As System.EventArgs) Handles Command_rd0.Click
        Call read_sram()
    End Sub
    Private Sub read_sram()
        Call transmit_out(System.Convert.ToChar(COMMAND_H))
        Text_rd0.Text = Hex(byte_received)
    End Sub
    Private Sub Command_rd1_Click(sender As System.Object, e As System.EventArgs) Handles Command_rd1.Click
        Call read_reg1()
    End Sub
    Private Sub read_reg1()
        Call transmit_out(System.Convert.ToChar(COMMAND_A))
        Text_rd1.Text = Hex(byte_received)
    End Sub
    Private Sub Command_rd2_Click(sender As System.Object, e As System.EventArgs) Handles Command_rd2.Click
        Call read_reg2()
    End Sub
    Private Sub read_reg2()
        Call transmit_out(System.Convert.ToChar(COMMAND_B))
        Text_rd2.Text = Hex(byte_received)
    End Sub





    Private Sub meter(meter_value As Integer)

        Call disable_all_relays()
        If meter_value <> METER_OFF Then
            Call enable_relay5()
        End If
        shadow_reg6 = shadow_reg6 Or METER_OFF
        Call send_data(shadow_reg6, COMMAND_O)
        System.Threading.Thread.Sleep(100)

        shadow_reg6 = shadow_reg6 And METER_OFF
        Call send_data(shadow_reg6, COMMAND_O)
        System.Threading.Thread.Sleep(100)

        If meter_value <> METER_OFF Then
            shadow_reg6 = shadow_reg6 Or meter_value
            Call send_data(shadow_reg6, COMMAND_O)
            System.Threading.Thread.Sleep(100)
            shadow_reg6 = shadow_reg6 And METER_ON
            Call send_data(shadow_reg6, COMMAND_O)
        End If

    End Sub

    Private Sub com_meter1_Click(sender As System.Object, e As System.EventArgs) Handles com_meter1.Click
        Call meter(METER_OFF)
    End Sub
    Private Sub com_meter2_Click(sender As System.Object, e As System.EventArgs) Handles com_meter2.Click
        Call meter(V5)
    End Sub
    Private Sub com_meter3_Click(sender As System.Object, e As System.EventArgs) Handles com_meter3.Click
        Call meter(V3_3)
    End Sub
    Private Sub com_meter4_Click(sender As System.Object, e As System.EventArgs) Handles com_meter4.Click
        Call meter(VDD_MPU_CPU)
    End Sub
    Private Sub com_meter5_Click(sender As System.Object, e As System.EventArgs) Handles com_meter5.Click
        Call meter(V1_8A)
    End Sub
    Private Sub com_meter6_Click(sender As System.Object, e As System.EventArgs) Handles com_meter6.Click
        Call meter(V5A_MINUS)
    End Sub
    Private Sub com_meter7_Click(sender As System.Object, e As System.EventArgs) Handles com_meter7.Click
        Call meter(V3_3CPU)
    End Sub
    Private Sub com_meter8_Click(sender As System.Object, e As System.EventArgs) Handles com_meter8.Click
        Call meter(V1_8FPGA)
    End Sub
    Private Sub com_meter9_Click(sender As System.Object, e As System.EventArgs) Handles com_meter9.Click
        Call meter(V1_2)
    End Sub
    Private Sub com_meter10_Click(sender As System.Object, e As System.EventArgs) Handles com_meter10.Click
        Call meter(V5A_PLUS)
    End Sub
    Private Sub com_meter11_Click(sender As System.Object, e As System.EventArgs) Handles com_meter11.Click
        Call meter(V3_3A)
    End Sub
    Private Sub com_meter12_Click(sender As System.Object, e As System.EventArgs) Handles com_meter12.Click
        Call meter(VDD_CORE_CPU)
    End Sub
    Private Sub com_meter13_Click(sender As System.Object, e As System.EventArgs) Handles com_meter13.Click
        Call meter(V1_8)
    End Sub
    Private Sub com_meter14_Click(sender As System.Object, e As System.EventArgs) Handles com_meter14.Click
        Call meter(FPGA_DDR_VREF)
    End Sub
    Private Sub com_meter15_Click(sender As System.Object, e As System.EventArgs) Handles com_meter15.Click
        Call meter(FPGA_VTT)
    End Sub
    Private Sub com_meter16_Click(sender As System.Object, e As System.EventArgs) Handles com_meter16.Click
        Call meter(V24_IN)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Call read_cpu()
    End Sub
    Private Sub read_cpu()
        Call transmit_out(System.Convert.ToChar(COMMAND_Z))
        Txt_rd_CPU.Text = Hex(byte_received)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim wr_val As Integer
        Dim run_test As Boolean

        run_test = True
        wr_val = 0
        Do While run_test = True
            Text_wr0.Text = Hex(wr_val)
            sram = Convert.ToInt32(Text_wr0.Text, 16)
            Call WR_sram()
            Text_wr0.Refresh()
            Call read_sram()
            Text_rd0.Refresh()
            If Text_wr0.Text <> Text_rd0.Text Then
                run_test = False
                MsgBox("FAILED Memory Test  :(")
            End If
            If wr_val = &HFF Then
                If run_test = True Then
                    MsgBox("Memory Test PASSED!!!")
                End If
                run_test = False
            End If
            wr_val = wr_val + 1
        Loop

    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Call read_meter_volt()
        TextBox1.Text = voltage
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Call read_meter_ohm()
        TextBox1.Text = resistance
    End Sub

    Private Sub set_thresholds()

        V24_min_ohm.Text = 1050 '
        V24_max_ohm.Text = 1000000 '
        V5_min_ohm.Text = 1100 '
        V5_max_ohm.Text = 100000 '
        V3_3_min_ohm.Text = 1100 '
        V3_3_max_ohm.Text = 2000 '
        VDD_MPU_min_ohm.Text = 1050 '
        VDD_MPU_max_ohm.Text = 100000 '
        V1_8A_min_ohm.Text = 1100 '
        V1_8A_max_ohm.Text = 100000 '
        V5AMinus_min_ohm.Text = 5000 '
        V5AMinus_max_ohm.Text = 1000000 '
        V3_3_CPU_min_ohm.Text = 1050 '
        V3_3_CPU_max_ohm.Text = 100000 '
        V1_8FPGA_min_ohm.Text = 1100 '
        V1_8FPGA_max_ohm.Text = 100000 '
        V1_2_min_ohm.Text = 1100 '
        V1_2_max_ohm.Text = 2000 '
        V5A_min_ohm.Text = 1050 '
        V5A_max_ohm.Text = 100000 '
        V3_3A_min_ohm.Text = 5000 '
        V3_3A_max_ohm.Text = 100000 '
        VDD_Core_min_ohm.Text = 1030 '
        VDD_Core_max_ohm.Text = 100000 '
        V1_8_min_ohm.Text = 500 '
        V1_8_max_ohm.Text = 1000000 '
        DDR_VREF_min_ohm.Text = 50000 '
        DDR_VREF_max_ohm.Text = 1000000 '
        FPGA_VTT_min_ohm.Text = 4000 '
        FPGA_VTT_max_ohm.Text = 100000 '

        V24_min_volt.Text = 23.5 '
        V24_max_volt.Text = 24.5 '
        V5_min_volt.Text = 4.8 '
        V5_max_volt.Text = 5.2 '
        V3_3_min_volt.Text = 3.2 '
        V3_3_max_volt.Text = 3.46 '
        VDD_MPU_min_volt.Text = 1.05 '
        VDD_MPU_max_volt.Text = 1.15 '
        V1_8A_min_volt.Text = 1.7 '
        V1_8A_max_volt.Text = 1.9 '
        V5AMinus_min_volt.Text = -5.25 '
        V5AMinus_max_volt.Text = -4.75 '
        V3_3_CPU_min_volt.Text = 3.2 '
        V3_3_CPU_max_volt.Text = 3.46 '
        V1_8FPGA_min_volt.Text = 1.75 '
        V1_8FPGA_max_volt.Text = 1.85 '
        V1_2_min_volt.Text = 1.17 '
        V1_2_max_volt.Text = 1.27 '
        V5A_min_volt.Text = 4.8 '
        V5A_max_volt.Text = 5.2 '
        V3_3A_min_volt.Text = 3.2 '
        V3_3A_max_volt.Text = 3.46 '
        VDD_Core_min_volt.Text = 1.05 '
        VDD_Core_max_volt.Text = 1.15 '
        V1_8_min_volt.Text = 1.75 '
        V1_8_max_volt.Text = 1.85 '
        DDR_VREF_min_volt.Text = 0.85 '
        DDR_VREF_max_volt.Text = 0.95 '
        FPGA_VTT_min_volt.Text = 0.85 '
        FPGA_VTT_max_volt.Text = 0.95 '
    End Sub


    Private Sub clear_textboxes()

        V24_ohm.Text = "" '
        V24_ohm.BackColor = Color.Bisque
        V5_ohm.Text = "" '
        V5_ohm.BackColor = Color.Bisque
        V3_3_ohm.Text = "" '
        V3_3_ohm.BackColor = Color.Bisque
        VDD_MPU_ohm.Text = "" '
        VDD_MPU_ohm.BackColor = Color.Bisque
        V1_8A_ohm.Text = "" '
        V1_8A_ohm.BackColor = Color.Bisque
        V5AMinus_ohm.Text = "" '
        V5AMinus_ohm.BackColor = Color.Bisque
        V3_3_CPU_ohm.Text = "" '
        V3_3_CPU_ohm.BackColor = Color.Bisque
        V1_8FPGA_ohm.Text = "" '
        V1_8FPGA_ohm.BackColor = Color.Bisque
        V1_2_ohm.Text = "" '
        V1_2_ohm.BackColor = Color.Bisque
        V5A_ohm.Text = "" '
        V5A_ohm.BackColor = Color.Bisque
        V3_3A_ohm.Text = "" '
        V3_3A_ohm.BackColor = Color.Bisque
        VDD_Core_ohm.Text = "" '
        VDD_Core_ohm.BackColor = Color.Bisque
        V1_8_ohm.Text = "" '
        V1_8_ohm.BackColor = Color.Bisque
        DDR_VREF_ohm.Text = "" '
        DDR_VREF_ohm.BackColor = Color.Bisque
        FPGA_VTT_ohm.Text = "" '
        FPGA_VTT_ohm.BackColor = Color.Bisque

        V24_volt.Text = "" '
        V24_volt.BackColor = Color.Bisque
        V5_volt.Text = ""
        V5_volt.BackColor = Color.Bisque
        V3_3_volt.Text = ""
        V3_3_volt.BackColor = Color.Bisque
        VDD_MPU_volt.Text = ""
        VDD_MPU_volt.BackColor = Color.Bisque
        V1_8A_volt.Text = ""
        V1_8A_volt.BackColor = Color.Bisque
        V5AMinus_volt.Text = ""
        V5AMinus_volt.BackColor = Color.Bisque
        V3_3_CPU_volt.Text = ""
        V3_3_CPU_volt.BackColor = Color.Bisque
        V1_8FPGA_volt.Text = ""
        V1_8FPGA_volt.BackColor = Color.Bisque
        V1_2_volt.Text = ""
        V1_2_volt.BackColor = Color.Bisque
        V5A_volt.Text = ""
        V5A_volt.BackColor = Color.Bisque
        V3_3A_volt.Text = ""
        V3_3A_volt.BackColor = Color.Bisque
        VDD_Core_volt.Text = ""
        VDD_Core_volt.BackColor = Color.Bisque
        V1_8_volt.Text = ""
        V1_8_volt.BackColor = Color.Bisque
        DDR_VREF_volt.Text = ""
        DDR_VREF_volt.BackColor = Color.Bisque
        FPGA_VTT_volt.Text = ""
        FPGA_VTT_volt.BackColor = Color.Bisque

        ip_txt.Text = ""
        ip_txt.BackColor = Color.Bisque
        tb_ProgrammedMAC.Text = ""
        tb_ProgrammedMAC.BackColor = Color.Bisque

        build_ver.Text = ""
        build_ver.BackColor = Color.Bisque
        fpga_ver.Text = ""
        fpga_ver.BackColor = Color.Bisque
        LED_15_on_check.Checked = False
        LED7_blinking_check.Checked = False

        T1.Text = "0"
        T1.BackColor = Color.Bisque
        T2.Text = "0"
        T2.BackColor = Color.Bisque
        T3.Text = "0"
        T3.BackColor = Color.Bisque
        T4.Text = "0"
        T4.BackColor = Color.Bisque

        RTD_cur_open.Text = "0"
        RTD_cur_open.BackColor = Color.Bisque
        RTD_cur_110.Text = "0"
        RTD_cur_110.BackColor = Color.Bisque

        RTD_sense_open.Text = "0"
        RTD_sense_open.BackColor = Color.Bisque
        RTD_sense_110.Text = "0"
        RTD_sense_110.BackColor = Color.Bisque

        L1_4ma.Text = "0"
        L1_4ma.BackColor = Color.Bisque
        L1_20ma.Text = "0"
        L1_20ma.BackColor = Color.Bisque
        L2_4ma.Text = "0"
        L2_4ma.BackColor = Color.Bisque
        L2_20ma.Text = "0"
        L2_20ma.BackColor = Color.Bisque
        L3_4ma.Text = "0"
        L3_4ma.BackColor = Color.Bisque
        L3_20ma.Text = "0"
        L3_20ma.BackColor = Color.Bisque
        L4_4ma.Text = "0"
        L4_4ma.BackColor = Color.Bisque
        L4_20ma.Text = "0"
        L4_20ma.BackColor = Color.Bisque

        NGEN_12.Text = "0"
        NGEN_12.BackColor = Color.Bisque
        NGEN_4.Text = "0"
        NGEN_4.BackColor = Color.Bisque

        Avg.Text = "0"
        Avg.BackColor = Color.Bisque
        Stdev.Text = "0"
        Stdev.BackColor = Color.Bisque

        LED7_blinking_check.BackColor = Color.White
        LED_15_on_check.BackColor = Color.White


        Preamp_version.Checked = False
        sawtooth_check.Checked = False
        moisture_test.Checked = False

        Preamp_version.BackColor = Color.White
        sawtooth_check.BackColor = Color.White
        moisture_test.BackColor = Color.White
        Command6.BackColor = Color.White


        btn_StartNewTest.BackColor = Color.White
        btn_ImpedanceTest.BackColor = Color.White
        btn_VoltageTest.BackColor = Color.White
        btn_LoadLinux.BackColor = Color.White
        btn_MAC_IP.BackColor = Color.White
        Button44.BackColor = Color.White
        Button45.BackColor = Color.White
        btn_ProgramFPGA.BackColor = Color.White
        Button16.BackColor = Color.White
        Button23.BackColor = Color.White
        Button22.BackColor = Color.White
        Button24.BackColor = Color.White
        Button25.BackColor = Color.White
        Button26.BackColor = Color.White
        Button27.BackColor = Color.White
        Button19.BackColor = Color.White
        Button46.BackColor = Color.White
        Button29.BackColor = Color.White
        Button32.BackColor = Color.White
        Button36.BackColor = Color.White
        btn_MemoryTest.BackColor = Color.White

    End Sub
    Private Sub Button41_Click(sender As System.Object, e As System.EventArgs) Handles btn_LoadLinux.Click
        'search_all_com_ports()

        If CheckForRPP4COM() = True Then
            btn_LoadLinux.BackColor = Color.Yellow
            btn_LoadLinux.Refresh()
            start_load_linux()
        End If

    End Sub
    Private Sub start_load_linux()
        Call disable_uut_pwr()
        SetDipswitches(24)
        'Text_wr4.Text = 24
        'dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        'Call WR_dip_switch()
        Thread.Sleep(500)
        Call enable_uut_pwr()
        Thread.Sleep(3000)
        Call open_rpp4_port()
        Thread.Sleep(500)
        Button8.Refresh()

        '?? Boot from SD card
        Dim FoundPrompt As Boolean = False
        FoundPrompt = search_RPP4_serial(text_search:="am335x-evm login:",
                                                        max_attempts:=30,
                                                        delay_per_attempt_ms:=1000,
                                                        overwrite_log:=True)
        If Not FoundPrompt Then
            MsgBox("Unable to boot from SD card!")
            btn_LoadLinux.BackColor = Color.Red
            Exit Sub
        End If

        'search_RPP4("am335x-evm login:", 20, 500)

        Thread.Sleep(500)
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 30, 100)
        Thread.Sleep(500)
        send_and_wait_RPP4("reboot" & vbCr, "Hit any key to stop autoboot:", 120, 500)
        Thread.Sleep(100)
        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)

        Dim delay = 100
        send_and_wait_RPP4("mmc rescan" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nandecc hw 2" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand erase 0x0 0x00280000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("fatload mmc 0 0x81000000 MLO" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x0 0x00020000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x00020000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x00040000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x00060000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("fatload mmc 0 0x81000000 u-boot.img" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x00080000 0x001E0000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand erase 0x00280000 0x00500000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("fatload mmc 0 0x81000000 uImage" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand write 0x81000000 0x00280000 0x00500000" & vbCr, "U-Boot#", 80, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("nand erase 0x00780000 0x0F880000" & vbCr, "U-Boot#", 30, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("run mmc_boot" & vbCr, "am335x-evm login:", 200, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 100, 100)
        Thread.Sleep(delay)
        send_and_wait_RPP4("mount -t msdos /dev/mmcblk0p1 /media/mmc1" & vbCr, "root@am335x-evm:~#", 500, 100)
        Thread.Sleep(delay)

        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Wait up to a minute to process.")
        'Else
        '    MsgBox("PASSED. mount -t msdos /dev/mmcblk0p1 /media/mmc1 = OKAY!")
        'End If

        'send_and_wait_RPP4("ubiformat /dev/mtd8" & vbCr, "root@am33", 600, 100)
        send_and_wait_RPP4("ubiformat /dev/mtd8 -y" & vbCr, "root@am33", 600, 100)
        '2024-03-18: Added -y parameter to automatically reply yes to "continue" prompts (which is what the below code does anyway) -NM 


        'MsgBox("Sent the command = ubiformat /dev/mtd8")
        'debug_port.Write("y" & vbCr)
        'debug_port.Write("y" & vbCr)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Y1.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'Thread.Sleep(250)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Y2.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'Thread.Sleep(250)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Y3.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Wait one minute.")
        'End If


        'comm_with_RPP4("ubiformat /dev/mtd8 -f /media/mmc1/ubi.img -s 512 -O 2048" & vbCr, "continue? (yes/no)", 65000)
        'send_and_wait_RPP4("ubiformat /dev/mtd8 -f /media/mmc1/ubi.img -s 512 -O 2048" & vbCr, "(yes/no)", 650, 100)

        send_and_wait_RPP4("ubiformat /dev/mtd8 -f /media/mmc1/ubi.img -s 512 -O 2048 -y" & vbCr, "root@am335x-evm:~#", 650, 100)
        '2024-03-18: Added -y parameter to automatically reply yes to "continue" prompts (which is what the below code does anyway) -NM 

        'Thread.Sleep(250)
        'debug_port.Write("y" & vbCr)
        'debug_port.Write("y" & vbCr)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. 1.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'Thread.Sleep(250)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Y2.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'Thread.Sleep(250)
        'RichTextBox1.Refresh()
        'If RichTextBox1.BackColor = Color.Yellow Then
        '    MsgBox("Possible problem. Y3.")
        'End If
        'send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        'Thread.Sleep(250)

        send_and_wait_RPP4("reboot" & vbCr, "Hit any key to stop autoboot:", 120, 500)
        Thread.Sleep(100)
        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)
        Thread.Sleep(250)

        send_and_wait_RPP4("setenv optargs 'init=/init'" & vbCr, "U-Boot#", 100, 100)
        Thread.Sleep(250)
        send_and_wait_RPP4("setenv nand_root ubi0:rootfs rw ubi.mtd=8,2048" & vbCr, "U-Boot#", 100, 100)
        Thread.Sleep(250)
        send_and_wait_RPP4("setenv bootcmd 'if mmc rescan; then run mmc_boot; else run nand_boot; fi;'" & vbCr, "U-Boot#", 100, 100)
        Thread.Sleep(250)
        send_and_wait_RPP4("saveenv" & vbCr, "U-Boot#", 100, 100)
        Thread.Sleep(250)

        Call close_rpp4_port()
        Call disable_uut_pwr()

        MsgBox("Remove the Micro SD Card now and adjust SW1 to 01001100." & vbCrLf & "SW1_1=ON" & vbCrLf & "SW1_2=OFF" & vbCrLf &
       "SW1_3=ON" & vbCrLf & "SW1_4=ON" & vbCrLf & "SW1_5=OFF" & vbCrLf & "SW1_6=OFF" & vbCrLf & "SW1_7=ON" & vbCrLf & "SW1_8=ON")

        btn_LoadLinux.BackColor = Color.LightGreen
        Button44.BackColor = Color.LemonChiffon

        'If CheckBox3.Checked = True Then
        '    Call start_program_mac()
        'End If



    End Sub

    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click

        Call disable_uut_pwr()
        Text_wr4.Text = 24
        dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        Call WR_dip_switch()
        Thread.Sleep(500)
        Call enable_uut_pwr()
        Thread.Sleep(3000)
        Call open_rpp4_port()
        Thread.Sleep(500)
        Button8.Refresh()
        search_RPP4("am335x-evm login:", 50, 500)
        MsgBox("Pause")
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("reboot" & vbCr, "Hit any key to stop autoboot:", 120, 500)
        MsgBox("Pause")
        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)


        send_and_wait_RPP4("mmc rescan" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nandecc hw 2" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand erase 0x0 0x00280000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("fatload mmc 0 0x81000000 MLO" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x0 0x00020000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x00020000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x00040000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x00060000 0x00020000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("fatload mmc 0 0x81000000 u-boot.img" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x00080000 0x001E0000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand erase 0x00280000 0x00500000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("fatload mmc 0 0x81000000 uImage" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand write 0x81000000 0x00280000 0x00500000" & vbCr, "U-Boot#", 80, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("nand erase 0x00780000 0x0F880000" & vbCr, "U-Boot#", 30, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("run mmc_boot" & vbCr, "am335x-evm login:", 200, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 100, 100)
        MsgBox("Pause")

        '   MsgBox("Mounting drive.")
        send_and_wait_RPP4("mount -t msdos /dev/mmcblk0p1 /media/mmc1" & vbCr, "root@am335x-evm:~#", 500, 100)
        Thread.Sleep(250)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Wait up to a minute to process.")
        End If
        send_and_wait_RPP4("ubiformat /dev/mtd8" & vbCr, "root@am33", 500, 100)
        MsgBox("Pause")
        debug_port.Write("y" & vbCr)
        debug_port.Write("y" & vbCr)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Y1.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        Thread.Sleep(250)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Y2.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        Thread.Sleep(250)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Y3.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Wait one minute.")
        End If
        '  comm_with_RPP4("ubiformat /dev/mtd8 -f /media/mmc1/ubi.img -s 512 -O 2048" & vbCr, "continue? (yes/no)", 65000)
        send_and_wait_RPP4("ubiformat /dev/mtd8 -f /media/mmc1/ubi.img -s 512 -O 2048" & vbCr, "(yes/no)", 650, 100)
        MsgBox("Pause")

        Thread.Sleep(250)
        debug_port.Write("y" & vbCr)
        debug_port.Write("y" & vbCr)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. 1.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        Thread.Sleep(250)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Y2.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        Thread.Sleep(250)
        RichTextBox1.Refresh()
        If RichTextBox1.BackColor = Color.Yellow Then
            MsgBox("Possible problem. Y3.")
        End If
        send_and_wait_RPP4("y" & vbCr, "root@am335x-evm:~#", 500, 100)
        MsgBox("Pause")

        send_and_wait_RPP4("reboot" & vbCr, "Hit any key to stop autoboot:", 120, 500)
        MsgBox("Pause")
        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)
        MsgBox("Pause")

        send_and_wait_RPP4("setenv optargs 'init=/init'" & vbCr, "U-Boot#", 100, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("setenv nand_root ubi0:rootfs rw ubi.mtd=8,2048" & vbCr, "U-Boot#", 100, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("setenv bootcmd 'if mmc rescan; then run mmc_boot; else run nand_boot; fi;'" & vbCr, "U-Boot#", 100, 100)
        MsgBox("Pause")
        send_and_wait_RPP4("saveenv" & vbCr, "U-Boot#", 100, 100)
        MsgBox("Pause")

        '      Call close_rpp4_port()
        '      Call disable_uut_pwr()

        MsgBox("Remove the Micro SD Card Now and Set SW1 to 01001100." & vbCrLf & "SW1_1=ON" & vbCrLf & "SW1_2=OFF" & vbCrLf &
       "SW1_3=ON" & vbCrLf & "SW1_4=ON" & vbCrLf & "SW1_5=OFF" & vbCrLf & "SW1_6=OFF" & vbCrLf & "SW1_7=ON" & vbCrLf & "SW1_8=ON")

        btn_LoadLinux.BackColor = Color.LightGreen
        Button44.BackColor = Color.Yellow

        ' If CheckBox3.Checked = True Then
        ' Call start_program_mac()
        ' End If


    End Sub
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************
    '*********************** special test for loading LINUX *****************************

    Sub SetDipswitches(value As String)
        Text_wr4.Text = value
        Text_wr4.Refresh()
        dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        WR_dip_switch()

        'Text_wr4.Text = "FF"
        'Text_wr4.Refresh()
        'dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        'Call WR_dip_switch()
    End Sub
    Private ubootSuccess = False
    Private Sub start_program_mac()

        Call close_rpp4_port()
        Call disable_uut_pwr()
        SetDipswitches("FF")
        Thread.Sleep(500)

        Call enable_uut_pwr()
        Thread.Sleep(2000)
        Call open_rpp4_port()
        Thread.Sleep(2000)
        Button8.Refresh()

        send_and_wait_RPP4("reboot" & vbCr, "Hit any key to stop autoboot:", 40, 500)
        Thread.Sleep(100)

        If RichTextBox1.BackColor = Color.Yellow Then
            Dim abortCheck As DialogResult = MessageBox.Show("Reboot appears unsuccessful, abort test?", "Abort?", MessageBoxButtons.YesNo)
            If abortCheck = DialogResult.Yes Then
                Exit Sub
            End If
        End If


        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)
        Thread.Sleep(1000)



        'mac_address = MAC1.Text & ":" & MAC2.Text & ":" & MAC3.Text & ":" & MAC4.Text & ":" & MAC5.Text & ":" & MAC6.Text
        mac_address = tb_MAC_Full.Text
        send_and_wait_RPP4("setenv ethaddr " & mac_address & vbCr, "U-Boot#", 50, 100)
        Thread.Sleep(1000)
        send_and_wait_RPP4("saveenv" & vbCr, "U-Boot#", 50, 100)
        Thread.Sleep(1000)

        send_and_wait_RPP4("reset" & vbCr, "am335x-evm login:", 100, 500)
        'Thread.Sleep(1000)
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 30, 100)
        Thread.Sleep(1000)
        measured_MAC = ""
        send_and_wait_RPP4("ifconfig" & vbCr, "root@am335x-evm:~#", 30, 100)
        Call get_ip_address()
        tb_ProgrammedMAC.Text = measured_MAC
        Call test_mac()
        Button45.BackColor = Color.Yellow
        tb_ProgrammedMAC.Refresh()
        If CheckBox4.Checked = True And tb_ProgrammedMAC.BackColor = Color.LightGreen Then
            Call start_ip_address()
        End If
    End Sub

    Private Sub Button44_Click(sender As System.Object, e As System.EventArgs) Handles Button44.Click

        Call start_program_mac()

    End Sub
    Private Sub test_mac()
        If tb_MAC_Full.Text.ToLower = tb_ProgrammedMAC.Text.ToLower Then
            tb_ProgrammedMAC.BackColor = Color.LightGreen
            MAC_test_str = "MAC Address Confirmed. MAC Address programmed as: "
            Button44.BackColor = Color.LightGreen
        Else
            tb_ProgrammedMAC.BackColor = Color.Red
            MAC_test_str = "FAILED!!! FAILED !!! FAILED !!! --------------------------> MAC Address = "
            Button44.BackColor = Color.Red
        End If

    End Sub
    Private Sub start_ip_address()
        Dim x As Integer
        x = 0
        ip_address = ""

        If Not debug_port.IsOpen Then
            Call boot_linux()
        End If

        Do While x < 3
            send_and_wait_RPP4("ifconfig" & vbCr, "root@am335x-evm:~#", 30, 100)
            Call get_ip_address()
            ip_txt.Text = ip_address
            If ip_address <> "" Then
                x = 1000
            End If
            'Thread.Sleep(1000)
            x = x + 1
        Loop
        If ip_address <> "" Then
            ip_txt.BackColor = Color.LightGreen
            Button45.BackColor = Color.LightGreen
        Else
            ip_txt.BackColor = Color.Red
            Button45.BackColor = Color.LightGreen
        End If
        btn_MemoryTest.BackColor = Color.Yellow
        ip_txt.Refresh()
        If CheckBox12.Checked = True And ip_txt.BackColor = Color.LightGreen Then
            Call mem_test()
        End If

    End Sub
    Private Sub Button45_Click(sender As System.Object, e As System.EventArgs) Handles Button45.Click
        Call start_ip_address()
    End Sub


    Private Sub get_ip_address()
        Dim x As Integer
        Dim x_diff As Integer
        Dim x_end As Integer
        Dim x_start As Integer

        send_and_wait_RPP4("ifconfig eth0 192.168.16.25" & vbCr, "root@am335x-evm:~#", 3, 100)

        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        x = InStr(eth_str, "HWaddr")
        If x > 0 Then
            measured_MAC = Mid(eth_str, x + 7, 17)
        End If
        x = InStr(eth_str, "inet addr:192.168")
        x_start = x + 10
        If x > 0 Then
            x_end = InStr(x_start, eth_str, " ")
            x_diff = x_end - x_start
            ip_address = Mid(eth_str, x_start, x_diff)
        End If
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************
        'Original code *******************************************************************************



    End Sub

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles btn_ProgramFPGA.Click

        If ip_address = "" Then
            If ip_txt.Text = "192.168.16.25" Then
                ip_address = "192.168.16.25"
            End If
            MsgBox("Must have a valid IP Address!")
            Exit Sub
        End If

        Call start_xilinx()
    End Sub
    Private Sub start_xilinx()

        Dim ps_kill As String
        Dim stop_on_message As Boolean

        If cb_stop_on_message.Checked = True Then
            stop_on_message = True
        Else
            stop_on_message = False
        End If

        boot_linux()

        txt_ps.Text = ""

        'If Not debug_port.IsOpen Then
        '    Call boot_linux()
        '    MsgBox("Linux booted.")
        'End If

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 30, 1000)
        If stop_on_message = True Then
            MsgBox("1")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/pulsesvr")
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 30, 1000)
        If stop_on_message = True Then
            MsgBox("2")
        End If
        Thread.Sleep(2000)

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("3")
        End If
        Thread.Sleep(2000)
        If stop_on_message = True Then
            MsgBox("4")
        End If
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("5")
        End If

        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("6")
        End If
        Thread.Sleep(2000)

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("7")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("8")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("9")
        End If
        Thread.Sleep(2000)

        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("10")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("11")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("12")
        End If
        Thread.Sleep(2000)

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("13")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("14")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("15")
        End If
        Thread.Sleep(2000)
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("16")
        End If
        Thread.Sleep(2000)


        Call start_telnet()
        If stop_on_message = True Then
            MsgBox("17")
        End If
        Thread.Sleep(2000)
        Call first_tftp()
        If stop_on_message = True Then
            MsgBox("18")
        End If
        Thread.Sleep(2000)
        Call kill_telnet()
        If stop_on_message = True Then
            MsgBox("19")
        End If

        Thread.Sleep(1000)
        Call boot_linux()

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("20")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/pulsesvr")
        If stop_on_message = True Then
            MsgBox("21")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("22")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("23")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("24")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("25")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("26")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("27")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("28")
        End If
        Thread.Sleep(2000)


        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("29")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("30")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("31")
        End If
        Thread.Sleep(2000)

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("32")
        End If
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        If stop_on_message = True Then
            MsgBox("33")
        End If
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("34")
        End If
        Thread.Sleep(2000)
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code

        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 200, 100)
        If stop_on_message = True Then
            MsgBox("35")
        End If
        Thread.Sleep(2000)

        Call start_telnet()
        If stop_on_message = True Then
            MsgBox("36")
        End If
        Thread.Sleep(1000)
        Call second_tftp()
        If stop_on_message = True Then
            MsgBox("37")
        End If
        Thread.Sleep(1000)
        Call kill_telnet()
        If stop_on_message = True Then
            MsgBox("38")
        End If
        Thread.Sleep(1000)

        btn_ProgramFPGA.BackColor = Color.LightGreen
        Button36.BackColor = Color.Yellow
        ' LED_15_on_check.BackColor = Color.Yellow

        If CheckBox11.Checked = True Then
            Call crc_test()
        End If

        ' Call test_led7()
    End Sub


    Private Function get_ps_value(line_str As String) As String
        Dim x_end As Integer
        Dim x_start As Integer
        Dim x_str As String

        txt_ps.Text = txt_ps.Text & "ps = " & ps & "; line_str = " & line_str & vbCrLf

        x_str = "0"
        x_end = InStr(ps, line_str)
        If x_end > 0 Then
            x_start = x_end - 25
            x_str = Mid$(ps, x_start, 4)
            If IsNumeric(x_str) = False Then
                x_str = "0"
            End If
        End If
        get_ps_value = x_str

    End Function


    Public ProcID As Integer
    Private Sub start_telnet()

        If cb_stop_on_message.Checked = True Then
            MsgBox("Starting Telnet")
        End If

        'added by Tom 1-6-2016
        send_and_wait_RPP4("ifconfig eth0 192.168.16.25" & vbCr, "root@am335x-evm:~#", 20, 100)
        'added by Tom 1-6-2016

        If cb_stop_on_message.Checked = True Then
            MsgBox("Opening Hyperterminal")
        End If

        ProcID = Shell("C:\Local Data\Hyperterminal\hypertrm.exe", AppWinStyle.NormalFocus)

        SendKeys.Send("Telnet RPP4")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")

        '   SendKeys.Send("192.168.16.139")
        Thread.Sleep(300)
        SendKeys.Send(ip_address)

        Thread.Sleep(300)
        'SendKeys.Send("{TAB}")
        'Thread.Sleep(100)
        'SendKeys.Send("{TAB}")
        'Thread.Sleep(100)
        'SendKeys.Send("{TAB}")
        'Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(1500)
        SendKeys.Send("root")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        If cb_stop_on_message.Checked = True Then
            MsgBox("Telnet ended.")
        End If


    End Sub
    Private Sub kill_telnet()
        AppActivate(ProcID)
        SendKeys.SendWait("%{F4}")
        Thread.Sleep(300)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(300)
        SendKeys.Send("{RIGHT}")
        Thread.Sleep(300)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(300)
    End Sub

    Private Sub first_tftp()
        AppActivate(ProcID)
        If cb_stop_on_message.Checked = True Then
            MsgBox("First tftp starting...")
        End If

        SendKeys.Send("cd /")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(1000)
        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4.bin") '192.168.16.30
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(12000)
        SendKeys.Send("/etc/config/update-fpga.sh")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(45000)
        If cb_stop_on_message.Checked = True Then
            MsgBox("First tftp ended.")
        End If



    End Sub
    Private Sub reboot_telnet()
        If cb_stop_on_message.Checked = True Then
            MsgBox("Going to reboot...")
        End If


        AppActivate(ProcID)
        SendKeys.Send("reboot")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(5000)
        Call kill_telnet()

    End Sub
    Private Sub second_tftp()
        AppActivate(ProcID)

        If cb_stop_on_message.Checked = True Then
            MsgBox("second tftp starting...")
        End If
        SendKeys.Send("cd /usr/bin")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4app")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r pulsesvr")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)


        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code

        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4getmac")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)
        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4test")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code

        SendKeys.Send("chmod 777 rpp4app")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        SendKeys.Send("chmod 777 pulsesvr")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)


        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        SendKeys.Send("chmod 777 rpp4getmac")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        SendKeys.Send("chmod 777 rpp4test")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code


        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        SendKeys.Send("tftp -g " & computer_ip_address & " -r filecrc")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************


        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        SendKeys.Send("chmod 755 filecrc")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(800)
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************

        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code
        'added 6-21-2-2016 per Ben's code

        SendKeys.Send("cd /srv/www")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r companylogo.png")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r index.html")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r graphTest.html")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("cd /srv/www/cgi-bin")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r boardinfo")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r adcstream2")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("chmod 755 boardinfo")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        SendKeys.Send("chmod 755 adcstream2")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        'sent by ben on 6-22-16
        SendKeys.Send("cd /etc")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp3fpga.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(13000)

        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp3hv.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)


        '*CHECKING FILE SIZES OF RPP3FPGA AND RPP3HV* added 7-11
        SendKeys.Send("ls -la rpp3fpga.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)

        SendKeys.Send("ls -la rpp3hv.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)
        '*********************************************


        SendKeys.Send("chmod 666 rpp3fpga.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        SendKeys.Send("chmod 666 rpp3hv.bin")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        'END - added 6-21-2-2016 per Ben's code
        If cb_stop_on_message.Checked = True Then
            MsgBox("2nd tftp ended.")
        End If


    End Sub

    Private Sub third_tftp()
        AppActivate(ProcID)
        If cb_stop_on_message.Checked = True Then
            MsgBox("3rd tftp starting...")
        End If

        SendKeys.Send("cd /usr/bin")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)

        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        SendKeys.Send("tftp -g " & computer_ip_address & " -r filecrc")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(7000)
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************

        SendKeys.Send("chmod 777 rpp4app")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

        SendKeys.Send("chmod 777 pulsesvr")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)


        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        SendKeys.Send("chmod 777 filecrc")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        'Memory and FLASH CRC check from Ben 1-25-2016 **************************************************
        If cb_stop_on_message.Checked = True Then
            MsgBox("3rd tftp ended.")
        End If


    End Sub



    Private Sub start_temp_test()
        Dim tmp As Integer

        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)

        Math.Round(resistance, 0)
        tmp = get_rpp4_value("=CS0_TEMP1")
        T1.Text = Math.Round((Val(tmp) / 16))
        tmp = get_rpp4_value("=CS0_TEMP2")
        T2.Text = Math.Round((Val(tmp) / 16))
        tmp = get_rpp4_value("=CS0_TEMP3")
        T3.Text = Math.Round((Val(tmp) / 16))
        tmp = get_rpp4_value("=CS0_TEMP4")
        T4.Text = Math.Round((Val(tmp) / 16))

        Call test_temp()
        Button23.BackColor = Color.Yellow
        T1.Refresh()
        T2.Refresh()
        T3.Refresh()
        T4.Refresh()

        If CheckBox8.Checked = True And Button46.BackColor = Color.LightGreen Then
            Call start_loop_test()
        End If

    End Sub
    Private Sub Button46_Click(sender As System.Object, e As System.EventArgs) Handles Button46.Click
        Call start_temp_test()
    End Sub

    Private Sub test_temp()
        If Val(T1.Text) >= Val(T1_min.Text) And Val(T1.Text) <= Val(T1_max.Text) Then
            T1.BackColor = Color.LightGreen
            temp_test_str = "PASSED. Temperature 1 = " & T1.Text & vbCrLf
        Else
            temp_test_str = "FAILED!!! FAILED!!! FAILED!!! -------------------------------------> Temperature 1 = " & T1.Text & vbCrLf
            T1.BackColor = Color.Red
        End If

        If Val(T2.Text) >= Val(T2_min.Text) And Val(T2.Text) <= Val(T2_max.Text) Then
            T2.BackColor = Color.LightGreen
            temp_test_str = temp_test_str & "PASSED. Temperature 2 = " & T2.Text & vbCrLf
        Else
            temp_test_str = temp_test_str & "FAILED!!! FAILED!!! FAILED!!! -------------------------------------> Temperature 2 = " & T2.Text & vbCrLf
            T2.BackColor = Color.Red
        End If

        If Val(T3.Text) >= Val(T3_min.Text) And Val(T3.Text) <= Val(T3_max.Text) Then
            T3.BackColor = Color.LightGreen
            temp_test_str = temp_test_str & "PASSED. Temperature 3 = " & T3.Text & vbCrLf
        Else
            temp_test_str = temp_test_str & "FAILED!!! FAILED!!! FAILED!!! -------------------------------------> Temperature 3 = " & T3.Text & vbCrLf
            T3.BackColor = Color.Red
        End If

        If Val(T4.Text) >= Val(T4_min.Text) And Val(T4.Text) <= Val(T4_max.Text) Then
            T4.BackColor = Color.LightGreen
            temp_test_str = temp_test_str & "PASSED. Temperature 4 = " & T4.Text & vbCrLf
        Else
            temp_test_str = temp_test_str & "FAILED!!! FAILED!!! FAILED!!! -------------------------------------> Temperature 4 = " & T4.Text & vbCrLf
            T4.BackColor = Color.Red
        End If
        If T1.BackColor = Color.Red Or T2.BackColor = Color.Red Or T3.BackColor = Color.Red Or T4.BackColor = Color.Red Then
            Button46.BackColor = Color.Red
        Else
            Button46.BackColor = Color.LightGreen
        End If

    End Sub
    Private Function get_rpp4_value(rpp4_value As String) As String
        Dim x As Integer
        Dim x_diff As Integer
        Dim x_end As Integer
        Dim x_start As Integer
        Dim x_str As String

        x_str = "0"
        x_end = InStr(rpp4_str, rpp4_value)
        If x_end > 0 Then
            x_start = x_end - 1
            x = InStr(x_start, rpp4_str, " ")
            Do While x > x_end
                x_start = x_start - 1
                x = InStr(x_start, rpp4_str, " ")
            Loop
            x_start = x_start + 1 'added
            x_diff = x_end - x_start
            x_str = Mid(rpp4_str, x_start, x_diff)
        End If
        get_rpp4_value = x_str
    End Function

    Private Sub Button47_Click(sender As System.Object, e As System.EventArgs) Handles Button47.Click
        measured_MAC = ""
        send_and_wait_RPP4("ifconfig" & vbCr, "root@am335x-evm:~#", 30, 100)
        Call get_ip_address()
        tb_ProgrammedMAC.Text = measured_MAC
    End Sub



    Private Sub LED_15_on_check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles LED_15_on_check.CheckedChanged
        If LED_15_on_check.Checked = True Then
            LED_15_on_check.BackColor = Color.LightGreen
        Else
            LED_15_on_check.BackColor = Color.Red
        End If
        LED7_blinking_check.BackColor = Color.Yellow
    End Sub
    Private Sub test_led15()
        If LED_15_on_check.Checked = True Then
            LED_15_on_check.BackColor = Color.LightGreen
            LED15_on_str = "FPGA LED ON." & vbCrLf
        Else
            LED_15_on_check.BackColor = Color.Red
            LED15_on_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> FPGA LED Not Working." & vbCrLf
        End If
    End Sub

    Private Sub LED7_blinking_check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles LED7_blinking_check.CheckedChanged

        If LED7_blinking_check.Checked = True Then
            LED7_blinking_check.BackColor = Color.LightGreen
        Else
            LED7_blinking_check.BackColor = Color.Red
        End If
        Button25.BackColor = Color.Yellow

    End Sub
    Private Sub test_led7()
        If LED7_blinking_check.Checked = True Then
            LED7_blinking_check.BackColor = Color.LightGreen
            LED7_blinking_str = "LED D7 Blinking." & vbCrLf
        Else
            LED7_blinking_check.BackColor = Color.Red
            LED7_blinking_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> LED D7 Not blinking." & vbCrLf
        End If
    End Sub
    Private Sub start_ver_test()
        Dim maj As String
        Dim min As String
        Dim bld As String

        Call boot_linux()

        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        fpga_ver.Text = get_rpp4_value("=CS1_FPGA_CODE_VER")
        Call test_fpga_ver()

        maj = get_rpp4_value("=CS0_VER_MAJOR")
        min = get_rpp4_value("=CS0_VER_MINOR")
        bld = get_rpp4_value("=CS0_VER_BUILD")
        build_ver.Text = maj & "." & min & "." & bld
        Call test_build()

        'After the xilinx is programmed you can read the DDR VREF voltage

        Call meter(FPGA_DDR_VREF)
        Call read_meter_volt()
        voltage = Math.Round(voltage, 2)
        DDR_VREF_volt.Text = voltage
        If voltage >= Val(DDR_VREF_min_volt.Text) And voltage <= Val(DDR_VREF_max_volt.Text) Then
            DDR_VREF_volt.BackColor = Color.LightGreen
        Else
            DDR_VREF_volt.BackColor = Color.Red
            voltage_test_ok = False
            meter_results = meter_results & "FAILED FAILED FAILED ----------------------------> "
        End If
        DDR_VREF_volt.Refresh()
        meter_results = meter_results & "FPGA VREF Voltage  = " & DDR_VREF_volt.Text & " Volts." & vbCrLf

        Button46.BackColor = Color.Yellow
        fpga_ver.Refresh()
        build_ver.Refresh()

        If CheckBox7.Checked = True And fpga_ver.BackColor = Color.LightGreen And build_ver.BackColor = Color.LightGreen And DDR_VREF_volt.BackColor = Color.LightGreen Then
            Call start_temp_test()
        End If
        Button16.Refresh()

    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Call start_ver_test()

    End Sub

    Private Sub test_fpga_ver()
        If fpga_ver.Text = FPGA_ver_value.Text Then
            fpga_ver.BackColor = Color.LightGreen
            ver_test_str = "FPGA Version Correct. FPGA VERSION = " & fpga_ver.Text & vbCrLf
        Else
            fpga_ver.BackColor = Color.Red
            ver_test_str = "FAILED!!! FAILED!!! FAILED!!! --------------------------------> FPGA VERSION = " & fpga_ver.Text & vbCrLf
        End If
    End Sub
    Private Sub test_build()
        If build_ver.Text = build_ver_value.Text Then
            build_ver.BackColor = Color.LightGreen
            ver_test_str = "Build Version Correct. BUILD VERSION = " & build_ver.Text & vbCrLf
            Button16.BackColor = Color.LightGreen
        Else
            build_ver.BackColor = Color.Red
            ver_test_str = "FAILED!!! FAILED!!! FAILED!!! --------------------------------> BUILD VERSION = " & build_ver.Text & vbCrLf
            Button16.BackColor = Color.Red
        End If

    End Sub




    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Call boot_linux()
    End Sub

    Private Sub boot_linux()
        Call close_rpp4_port()
        Call disable_uut_pwr()
        SetDipswitches("FF")
        'Text_wr4.Text = "FF"
        'Text_wr4.Refresh()
        'dip_switch = Convert.ToInt32(Text_wr4.Text, 16)
        'Call WR_dip_switch()
        Thread.Sleep(500)

        Call enable_uut_pwr()
        Thread.Sleep(2000)
        CheckForRPP4COM()
        Call open_rpp4_port()
        Thread.Sleep(500)
        Button8.Refresh()

        'Thread.Sleep(10000)

        Dim FoundPrompt As Boolean = False
        FoundPrompt = search_RPP4_serial(text_search:="am335x-evm login:",
                                                        max_attempts:=60,
                                                        delay_per_attempt_ms:=1000,
                                                        overwrite_log:=True)
        If Not FoundPrompt Then
            MsgBox("Unable to boot!")
            btn_LoadLinux.BackColor = Color.Red
            Exit Sub
        End If

        'send_and_wait_RPP4(vbCr, "am335x-evm login:", 30, 1000)
        'Thread.Sleep(1000)
        send_and_wait_RPP4("root" & vbCr, "root@am335x-evm:~#", 10, 1000)
        Thread.Sleep(1000)

    End Sub

    Private Sub start_rtd_test()
        Dim num1 As Integer
        Dim num1_min As Integer
        Dim num1_max As Integer
        Dim num2 As Integer
        Dim num2_min As Integer
        Dim num2_max As Integer
        Dim retest As Boolean
        Dim overwrite2_stat%


        retest = True
        Do While retest = True

            RTD_test_str = ""
            Call disable_rtd()

            send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
            RTD_cur_open.Text = Hex(get_rpp4_value("=CS0_RTD1"))
            RTD_sense_open.Text = Hex(get_rpp4_value("=CS0_RTD2"))
            RTD_cur_open.Refresh()
            RTD_sense_open.Refresh()
            RTD_cur_open.Refresh()
            RTD_sense_open.Refresh()
            num1 = Convert.ToInt32(RTD_cur_open.Text, 16)
            num1_min = Convert.ToInt32(RTD_cur_open_min.Text, 16)
            num1_max = Convert.ToInt32(RTD_cur_open_max.Text, 16)
            num2 = Convert.ToInt32(RTD_sense_open.Text, 16)
            num2_min = Convert.ToInt32(RTD_sense_open_min.Text, 16)
            num2_max = Convert.ToInt32(RTD_sense_open_max.Text, 16)

            If num1 >= num1_min And num1 <= num1_max Then
                RTD_test_str = RTD_test_str & "PASSED. RTD Current (OPEN) = " & RTD_cur_open.Text & vbCrLf
                RTD_cur_open.BackColor = Color.LightGreen
            Else
                RTD_test_str = RTD_test_str & "FAILED!!! FAILED!!! FAILED!!! ------------------------------------->  RTD Current (OPEN) = " & RTD_cur_open.Text & vbCrLf
                RTD_cur_open.BackColor = Color.Red
            End If

            If num2 >= num2_min And num2 <= num2_max Then
                RTD_test_str = RTD_test_str & "PASSED. RTD P_Sense (OPEN) = " & RTD_sense_open.Text & vbCrLf
                RTD_sense_open.BackColor = Color.LightGreen
            Else
                RTD_test_str = RTD_test_str & "FAILED!!! FAILED!!! FAILED!!! ------------------------------------->  RTD P_Sense (OPEN) = " & RTD_sense_open.Text & vbCrLf
                RTD_sense_open.BackColor = Color.Red
            End If

            overwrite2_stat% = MsgBox("Do you want to test again?", vbInformation + vbYesNo, "RPP4 Test")
            If overwrite2_stat = vbYes Then
                retest = True
            Else
                retest = False
            End If

        Loop

        Call enable_rtd()
        Thread.Sleep(500)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        RTD_cur_110.Text = Hex(get_rpp4_value("=CS0_RTD1"))
        RTD_sense_110.Text = Hex(get_rpp4_value("=CS0_RTD2"))

        num1 = Convert.ToInt32(RTD_cur_110.Text, 16)
        num1_min = Convert.ToInt32(RTD_cur_110_min.Text, 16)
        num1_max = Convert.ToInt32(RTD_cur_110_max.Text, 16)
        num2 = Convert.ToInt32(RTD_sense_110.Text, 16)
        num2_min = Convert.ToInt32(RTD_sense_110_min.Text, 16)
        num2_max = Convert.ToInt32(RTD_sense_110_max.Text, 16)

        If num1 >= num1_min And num1 <= num1_max Then
            RTD_test_str = RTD_test_str & "PASSED. RTD Current (110 ohm) = " & RTD_cur_110.Text & vbCrLf
            RTD_cur_110.BackColor = Color.LightGreen
        Else
            RTD_test_str = RTD_test_str & "FAILED!!! FAILED!!! FAILED!!! ------------------------------------->  RTD Current (110 ohm) = " & RTD_cur_110.Text & vbCrLf
            RTD_cur_110.BackColor = Color.Red
        End If

        If num2 >= num2_min And num2 <= num2_max Then
            RTD_test_str = RTD_test_str & "PASSED. RTD Current (110 ohm) = " & RTD_sense_110.Text & vbCrLf
            RTD_sense_110.BackColor = Color.LightGreen
        Else
            RTD_test_str = RTD_test_str & "FAILED!!! FAILED!!! FAILED!!! ------------------------------------->  RTD P_Sense (110 ohm) = " & RTD_sense_110.Text & vbCrLf
            RTD_sense_110.BackColor = Color.Red
        End If

        If RTD_cur_open.BackColor = Color.Red Or RTD_sense_open.BackColor = Color.Red Then
            Button19.BackColor = Color.Red
        Else
            Button19.BackColor = Color.LightGreen
        End If
        Button27.BackColor = Color.Yellow
        Call disable_rtd()
    End Sub
    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click

        Call start_rtd_test()

        Button19.Refresh()
        LED_15_on_check.BackColor = Color.Yellow
        LED7_blinking_check.BackColor = Color.Yellow
        If CheckBox10.Checked = True And Button19.BackColor = Color.LightGreen Then
            Call start_ngen_test()
        End If

    End Sub
    Sub clearLoopBoxes()
        For Each tb As TextBox In FlowLayoutPanel3.Controls
            tb.Text = ""
            tb.BackColor = Color.Yellow
            tb.Refresh()
        Next
    End Sub
    Private Sub start_loop_test()
        clearLoopBoxes()
        Call disable_rtd()

        Call meter(METER_OFF)
        Call disable_all_relays()
        Call disable_loop1()
        Call disable_loop2()
        Call disable_loop3()
        Call disable_loop4()
        iloop_test_str = ""

        Call meter(V5)
        Call enable_relay1()
        Call enable_loop1()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        Call clear_up_adc_message() 'added 1-16-2017
        L1_4ma.Text = get_rpp4_value("=CS1_IADC1")
        If Val(L1_4ma.Text) >= Val(L1_min_4ma.Text) And Val(L1_4ma.Text) <= Val(L1_max_4ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 4mA Test. ILOOP 1 = " & L1_4ma.Text & vbCrLf
            L1_4ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 4mA Test. ------------------------------------> ILOOP 1 = " & L1_4ma.Text & vbCrLf
            L1_4ma.BackColor = Color.Red
        End If
        L1_4ma.Refresh()

        Call meter(V24_IN) 'change this to 24V when it is fixed.
        Call enable_relay1()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        Call clear_up_adc_message() 'added 1-16-2017
        L1_20ma.Text = get_rpp4_value("=CS1_IADC1")
        If Val(L1_20ma.Text) >= Val(L1_min_20ma.Text) And Val(L1_4ma.Text) <= Val(L1_max_20ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 20mA Test. ILOOP 1 = " & L1_20ma.Text & vbCrLf
            L1_20ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 20mA Test. ------------------------------------> ILOOP 1 = " & L1_20ma.Text & vbCrLf
            L1_20ma.BackColor = Color.Red
        End If
        Call disable_loop1()
        Call meter(METER_OFF)
        L1_20ma.Refresh()


        Call meter(V5)
        Call enable_relay2()
        Call enable_loop2()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L2_4ma.Text = get_rpp4_value("=CS1_IADC2")
        If Val(L2_4ma.Text) >= Val(L2_min_4ma.Text) And Val(L2_4ma.Text) <= Val(L2_max_4ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 4mA Test. ILOOP 2 = " & L2_4ma.Text & vbCrLf
            L2_4ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 4mA Test. ------------------------------------> ILOOP 2 = " & L2_4ma.Text & vbCrLf
            L2_4ma.BackColor = Color.Red
        End If
        L2_4ma.Refresh()

        Call meter(V24_IN) 'change this to 24V when it is fixed.
        Call enable_relay2()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L2_20ma.Text = get_rpp4_value("=CS1_IADC2")
        If Val(L2_20ma.Text) >= Val(L2_min_20ma.Text) And Val(L2_20ma.Text) <= Val(L2_max_20ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 20mA Test. ILOOP 2 = " & L2_20ma.Text & vbCrLf
            L2_20ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 20mA Test. ------------------------------------> ILOOP 2 = " & L2_20ma.Text & vbCrLf
            L2_20ma.BackColor = Color.Red
        End If
        Call disable_loop2()
        Call meter(METER_OFF)
        L2_20ma.Refresh()


        Call meter(V5)
        Call enable_relay3()
        Call enable_loop3()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L3_4ma.Text = get_rpp4_value("=CS1_IADC3")
        If Val(L3_4ma.Text) >= Val(L3_min_4ma.Text) And Val(L3_4ma.Text) <= Val(L3_max_4ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 4mA Test. ILOOP 3 = " & L3_4ma.Text & vbCrLf
            L3_4ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 4mA Test. ------------------------------------> ILOOP 3 = " & L3_4ma.Text & vbCrLf
            L3_4ma.BackColor = Color.Red
        End If
        L3_4ma.Refresh()

        Call meter(V24_IN) 'change this to 24V when it is fixed.
        Call enable_relay3()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L3_20ma.Text = get_rpp4_value("=CS1_IADC3")
        If Val(L3_20ma.Text) >= Val(L3_min_20ma.Text) And Val(L3_20ma.Text) <= Val(L3_max_20ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 20mA Test. ILOOP 3 = " & L3_20ma.Text & vbCrLf
            L3_20ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 20mA Test. ------------------------------------> ILOOP 3 = " & L3_20ma.Text & vbCrLf
            L3_20ma.BackColor = Color.Red
        End If
        Call disable_loop3()
        Call meter(METER_OFF)
        L3_20ma.Refresh()


        Call meter(V5)
        Call enable_relay4()
        Call enable_loop4()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L4_4ma.Text = get_rpp4_value("=CS1_IADC4")
        If Val(L4_4ma.Text) >= Val(L4_min_4ma.Text) And Val(L4_4ma.Text) <= Val(L4_max_4ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 4mA Test. ILOOP 4 = " & L4_4ma.Text & vbCrLf
            L4_4ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 4mA Test. ------------------------------------> ILOOP 4 = " & L4_4ma.Text & vbCrLf
            L4_4ma.BackColor = Color.Red
        End If
        L4_4ma.Refresh()

        Call meter(V24_IN) 'change this to 24V when it is fixed.
        Call enable_relay4()
        Thread.Sleep(1000)
        send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        L4_20ma.Text = get_rpp4_value("=CS1_IADC4")
        If Val(L4_20ma.Text) >= Val(L4_min_20ma.Text) And Val(L4_20ma.Text) <= Val(L4_max_20ma.Text) Then
            iloop_test_str = iloop_test_str & "PASSED 20mA Test. ILOOP 4 = " & L4_20ma.Text & vbCrLf
            L4_20ma.BackColor = Color.LightGreen
        Else
            iloop_test_str = iloop_test_str & "FAILED!!! FAILED!!! FAILED!!! 20mA Test. ------------------------------------> ILOOP 4 = " & L4_20ma.Text & vbCrLf
            L4_20ma.BackColor = Color.Red
        End If
        Call disable_loop4()
        Call meter(METER_OFF)
        L4_20ma.Refresh()

        If L1_4ma.BackColor = Color.Red Or L2_4ma.BackColor = Color.Red Or L3_4ma.BackColor = Color.Red Or L4_4ma.BackColor = Color.Red Or
            L1_20ma.BackColor = Color.Red Or L2_20ma.BackColor = Color.Red Or L3_20ma.BackColor = Color.Red Or L4_20ma.BackColor = Color.Red Then
            Button23.BackColor = Color.Red
        Else
            Button23.BackColor = Color.LightGreen
        End If
        Button19.BackColor = Color.Yellow

        L1_4ma.Refresh()
        L1_20ma.Refresh()
        L2_4ma.Refresh()
        L2_20ma.Refresh()
        L3_4ma.Refresh()
        L3_20ma.Refresh()
        L4_4ma.Refresh()
        L4_20ma.Refresh()

        If CheckBox9.Checked = True And Button23.BackColor = Color.LightGreen Then
            Call start_rtd_test()
        End If

    End Sub


    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        Call start_loop_test()
    End Sub



    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        rpp4_str =
"root@am335x-evm:~# rpp4test" &
"RPP4App Test program" &
"Server [127.0.0.1] Port [8081] Hex Display=0" &
"RPP4App Server version 0.1.1" &
"[rpp4ref.c:479] semId=0" &
"[   57.068692] tscadc_read1: reg:0xe4 value:0x6 " &
"[  145.392668] tscadc_read_proc: starting   " &
"[  145.396806] tscadc_readl: reg:0xe4 value:0x6 " &
"[  145.402811] tscadc_readl: reg:0x100 value:0xaaf    " &
"[  145.409061] tscadc_readl: reg:0x100 value:0x10e7f " &
"[  145.415481] tscadc_readl: reg:0x100 value:0x20ef7 " &
"[  145.421916] tscadc_readl: reg:0x100 value:0x30eeb     " &
"[  145.428335] tscadc_readl: reg:0x100 value:0x40d0f " &
"[  145.434854] tscadc_readl: reg:0x100 value:0x50e4b      " &
"[  145.441219] tscadc_read_proc: buf:2735:3711:3831:3819:3343:3659" &
"[  145.441230]  40_RTD          [  145.452383] tscadc_write_proc: count:1 " &
"[  145.457294] tscadc_writel: reg:54 value:0x7e " &
"No data on socket 6 terminating child PID"
        '


        rpp4_str =
"root@am335x-evm:~# rpp4test" &
"RPP4App Test program" &
"Server [127.0.0.1] Port [8081] Hex Display=0" &
"RPP4App Server version 0.1.1" &
"[rpp4ref.c:479] semId=0" &
"   51=CS1_FPGA_CODE_VER        0=CS1_RESET               2693=CS1_IADC[   57.068692] tscadc_readl: reg:0xe4 value:0x6" & " 1  " &
"   31=CS1_IADC2               31=CS1_IADC3               31=CS1_IADC4         [  145.392668] tscadc_read_proc: starting   " &
"    0=CS1_MO[  145.396806] tscadc_readl: reg:0xe4 value:0x6 ISTURE_LSW      [  145.402811] tscadc_readl: reg:0x100 value:0xaaf    99=CS1_MOISTUR[  145.409061] tscadc_readl: reg:0x100 value:0x10e7f E_MSW        12=[  145.415481] tscadc_readl: reg:0x100 value:0x20ef7 CS1_MISC_IO     [  145.421916] tscadc_readl: reg:0x100 value:0x30eeb     " &
"    0=CS1_[  145.428335] tscadc_readl: reg:0x100 value:0x40d0f ADS1240_CUR     [  145.434854] tscadc_readl: reg:0x100 value:0x50e4b      0=CS1_ADS12[  145.441219] tscadc_read_proc: buf:2735:3711:3831:3819:3343:3659" &
"[  145.441230]  40_RTD          0=CS1_ADS1240_TH[  145.452383] tscadc_write_proc: count:1 ERM   " &
"    0=CS[  145.457294] tscadc_writel: reg:54 value:0x7e 1_LM86_LOCAL           0=CS1_LM86_REMOTE          0=CS1_LM86_STATUS     " &
"    0=CS1_EXP_IOA              0=CS1_EXP_IOB          19626=CS2_DAC_VALUE " &
"12710=CS2_ENERGY2CHANNEL   32767=CS2_DIGPTSUMCH100        0=CS2_CTH_SEL " &
"    0=CS2_FIFOSIGID        39905=CS2_REALTIMEREG      39905=CS2_LIVETIMEREG  " &
"   32=CS2_CPBAS              640=CS2_BSPLIBX32            0=CS2_PUR1       " &
" 4388=CS2_NORMALIZE_PULSES 13056=CS2_RAWPULSEPTS          0=CS0_VER_MAJOR     " &
"    1=CS0_VER_MINOR            1=CS0_VER_BUILD         2735=CS1_ADC1         " &
" 3711=CS1_ADC2              3831=CS1_ADC3              3819=CS1_ADC4        " &
" 3343=CS1_ADC5              3659=CS1_ADC6             21447=CS0_VOLTAGE1     " &
"21651=CS0_VOLTAGE2         22189=CS0_VOLTAGE3         22726=CS0_VOLTAGE4     " &
"  452=CS0_TEMP1              423=CS0_TEMP2              383=CS0_TEMP3      " &
"  413=CS0_TEMP4            32709=CS0_RTD1             25008=CS0_RTD2      " &
"   25=CS0_RTD3             16484=CS0_RTD4                 0=CS0_FPGA_REPROGRAM  " &
"No data on socket 6 terminating child PID"
        '
        rpp4_str =
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000800-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000801-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000802-0X00000000" &
"RPP4App Server version 0.2.4 CRC=0x5aea2937" &
"                    PulseSvr CRC=0x5454a62f" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000101-0X00000000" &
"[code/rpp4ref.c:479] semId=0" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000100-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000102-0X00000000" &
"   55=CS1_FPGA_CODE_VER        0=CS1_RESET          [   57.063682] tscadc_read_proc: starting    2693=CS1_IADC[   57.068692] tscadc_readl: reg:0xe4 value:0x6 1           " &
"[c[   57.074696] tscadc_readl: reg:0x100 value:0xaab ode/rpp4.c:2031][   57.080946] tscadc_readl: reg:0x100 value:0x10e73  iNumRead=28, cm[   57.087366] tscadc_readl: reg:0x100 value:0x20ecd dRead=getr:1:0X0[   57.093802] tscadc_readl: reg:0x100 value:0x30eba 0000103-0X000000[   57.100314] tscadc_readl: reg:0x100 value:0x40d27 00" &
"[code/rpp4.c[   57.106658] tscadc_readl: reg:0x100 value:0x50eae :2031] iNumRead=[   57.113104] tscadc_read_proc: buf:2731:3699:3789:3770:3367:3758" &
"[   57.113114]  28, cmdRead=getr[   57.123356] tscadc_write_proc: count:1 :1:0X00000104-0X[   57.127786] tscadc_writel: reg:54 value:0x7e 00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000105-0X00000000" &
"   31=CS1_IADC2               31=CS1_IADC3               31=CS1_IADC4    " &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000106-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000107-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000108-0X00000000" &
"    0=CS1_MOISTURE_LSW         0=CS1_MOISTURE_MSW        12=CS1_MISC_IO  "
        '
        rpp4_str = "root@am335x-evm:~# ifconfig eth0 192.168.16.25" &
"root@am335x-evm:~# rpp4test" &
"RPP4App Test program" &
"AM335x Revision - Device [0010] ROM [22.03]" &
"Server [127.0.0.1] Port [8081] Hex Display=0" &
"[code/rpp4.c:2698] Socket Accept returned. Client=6, Port=39379" &
"[code/rpp4.c:2704] Accepted new client connection" &
"[code/rpp4.c:2718] EmptyChild loop finished iEmptyChild=2." &
"[code/rpp4.c:2729] Main function pre-fork socket 6, PID=0" &
"[code/rpp4.c:2734] Socket Client Forked." &
"[code/rpp4.c:2735] Main function post-fork socket 6, PID=0" &
"[code/rpp4.c:1983] ServiceClient socket 6, PID=1080" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000800-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000801-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000802-0X00000000" &
"RPP4App Server version 0.2.4 CRC=0x5aea2937" &
"                    PulseSvr CRC=0x5454a62f" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000101-0X00000000" &
"[code/rpp4ref.c:479] semId=0" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000100-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000102-0X00000000" &
"   55=CS1_FPGA_CODE_VER        0=CS1_RESET          [   57.063682] tscadc_read_proc: starting    2693=CS1_IADC[   57.068692] tscadc_readl: reg:0xe4 value:0x6 1           " &
"[c[   57.074696] tscadc_readl: reg:0x100 value:0xaab ode/rpp4.c:2031][   57.080946] tscadc_readl: reg:0x100 value:0x10e73  iNumRead=28, cm[   57.087366] tscadc_readl: reg:0x100 value:0x20ecd dRead=getr:1:0X0[   57.093802] tscadc_readl: reg:0x100 value:0x30eba 0000103-0X000000[   57.100314] tscadc_readl: reg:0x100 value:0x40d27 00" &
"[code/rpp4.c[   57.106658] tscadc_readl: reg:0x100 value:0x50eae :2031] iNumRead=[   57.113104] tscadc_read_proc: buf:2731:3699:3789:3770:3367:3758" &
"[   57.113114]  28, cmdRead=getr[   57.123356] tscadc_write_proc: count:1 :1:0X00000104-0X[   57.127786] tscadc_writel: reg:54 value:0x7e 00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000105-0X00000000" &
"   31=CS1_IADC2               31=CS1_IADC3               31=CS1_IADC4    " &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000106-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000107-0X00000000" &
"[code/rpp4.c:2031] iNumRead=28, cmdRead=getr:1:0X00000108-0X00000000"
        '
        Call clear_up_adc_message()
        L1_4ma.Text = get_rpp4_value("=CS1_IADC1")
        '
        '   RichTextBox1.Text = strip_and_get_value("CSMISCIO")
        '        ' 
        '[   57.068692] tscadc_read1: reg:0xe4 value:0x6
        '[  145.396806] tscadc_readl: reg:0xe4 value:0x6 
        '[  145.402811] tscadc_readl: reg:0x100 value:0xaaf
        '[  145.409061] tscadc_readl: reg:0x100 value:0x10e7f 
        '[  145.428335] tscadc_readl: reg:0x100 value:0x40d0f 
        '[  145.441219] tscadc_read_proc: buf:2735:3711:3831:3819:3343:3659
        '
    End Sub
    Private Sub clear_up_adc_message()
        Dim x1 As Integer
        Dim x2 As Integer
        Dim starting_pos As Integer
        Dim string_to_eliminate As String
        Dim str_fnd As Boolean
        '[  145.396806] tscadc_readl: reg:0xe4 value:0x6 " 



        '   str_fnd = True
        '   Do While str_fnd = True
        ' x1 = InStr(rpp4_str, "tscadc_readl:")
        ' If x1 > 0 Then
        ' starting_pos = x1 - 16
        ' x1 = InStr(starting_pos, rpp4_str, "value:")
        ' x2 = InStr(x1, rpp4_str, " ")
        ' Do While x2 < 1
        ' x2 = InStr(x1, rpp4_str, " ")
        ' x1 = x1 + 1
        ' Loop
        ' string_to_eliminate = Mid(rpp4_str, starting_pos + 1, x2 - starting_pos)
        ' rpp4_str = Replace(rpp4_str, string_to_eliminate, "")
        '
        '        Else
        '        str_fnd = False
        '        End If
        '
        '        Loop

        str_fnd = True
        Do While str_fnd = True
            x1 = InStr(rpp4_str, "=CS1_IADC[")
            If x1 > 0 Then
                rpp4_str = Replace(rpp4_str, "=CS1_IADC[", "=CS1_IADC1 ")
            Else
                str_fnd = False
            End If

        Loop




        '   MsgBox(rpp4_str)

    End Sub
    Private Function strip_and_get_value(test_result_val As String) As String
        Dim x As Integer
        Dim test_value As String

        x = 0
        Do While x < 50
            rpp4_str = strip1(rpp4_str)
            x = x + 1
        Loop
        '    MsgBox("Strip 1 = " & rpp4_str)

        rpp4_str = strip2(rpp4_str, "a")
        rpp4_str = strip2(rpp4_str, "b")
        rpp4_str = strip2(rpp4_str, "c")
        rpp4_str = strip2(rpp4_str, "d")
        rpp4_str = strip2(rpp4_str, "e")
        rpp4_str = strip2(rpp4_str, "f")
        rpp4_str = strip2(rpp4_str, "g")
        rpp4_str = strip2(rpp4_str, "h")
        rpp4_str = strip2(rpp4_str, "i")
        rpp4_str = strip2(rpp4_str, "j")
        rpp4_str = strip2(rpp4_str, "k")
        rpp4_str = strip2(rpp4_str, "l")
        rpp4_str = strip2(rpp4_str, "m")
        rpp4_str = strip2(rpp4_str, "n")
        rpp4_str = strip2(rpp4_str, "o")
        rpp4_str = strip2(rpp4_str, "p")
        rpp4_str = strip2(rpp4_str, "q")
        rpp4_str = strip2(rpp4_str, "r")
        rpp4_str = strip2(rpp4_str, "s")
        rpp4_str = strip2(rpp4_str, "t")
        rpp4_str = strip2(rpp4_str, "u")
        rpp4_str = strip2(rpp4_str, "v")
        rpp4_str = strip2(rpp4_str, "w")
        rpp4_str = strip2(rpp4_str, "x")
        rpp4_str = strip2(rpp4_str, "y")
        rpp4_str = strip2(rpp4_str, "z")
        rpp4_str = strip2(rpp4_str, ":")
        rpp4_str = strip2(rpp4_str, "_")
        rpp4_str = strip2(rpp4_str, vbCrLf)
        rpp4_str = strip2(rpp4_str, vbCr)
        rpp4_str = strip2(rpp4_str, vbLf)

        '     MsgBox("Strip 2 = " & rpp4_str)

        test_value = strip3(rpp4_str, test_result_val)

        '     MsgBox("Strip 3 = " & test_value)

        strip_and_get_value = test_value


    End Function

    Private Function strip3(x_str As String, x_word As String) As String
        Dim x_equal_sign As Integer
        Dim x_start As Integer
        Dim x_end As Integer
        Dim x_len As Integer
        Dim x_value As String
        Dim temp_str As String
        Dim temp_word As String
        Dim num_str As String
        Dim stop_search As Boolean
        Dim temp_equal As Integer

        num_str = "0"
        stop_search = False
        x_start = 1
        Do While stop_search = False

            x_equal_sign = InStr(x_start, x_str, "=")
            If x_equal_sign > 0 Then
                x_value = get_x_value(x_str, x_equal_sign)
                x_len = Len(x_str)
                If x_len - x_equal_sign > 0 Then
                    temp_str = Mid(x_str, x_equal_sign, x_len - x_equal_sign)
                Else
                    '     MsgBox("x_len - x_equal_sign <= 0")
                    temp_str = 0
                End If
                num_str = get_x_value(x_str, x_equal_sign)

                temp_str = Replace(temp_str, " ", "")
                temp_str = Replace(temp_str, "0", "")
                temp_str = Replace(temp_str, "1", "")
                temp_str = Replace(temp_str, "2", "")
                temp_str = Replace(temp_str, "3", "")
                temp_str = Replace(temp_str, "4", "")
                temp_str = Replace(temp_str, "5", "")
                temp_str = Replace(temp_str, "6", "")
                temp_str = Replace(temp_str, "7", "")
                temp_str = Replace(temp_str, "8", "")
                temp_str = Replace(temp_str, "9", "")
                temp_str = Replace(temp_str, vbCrLf, "")
                temp_str = Replace(temp_str, vbCr, "")
                temp_str = Replace(temp_str, vbLf, "")

                temp_equal = InStr(temp_str, "=")

                x_end = InStr(temp_equal + 1, temp_str, "=")
                If x_end - 2 > 0 Then
                    temp_word = Mid(temp_str, 2, x_end - 2)
                Else
                    '    MsgBox("x_end - 2 <= 0")
                    temp_word = 0
                End If

                If temp_word = x_word Then
                    stop_search = True
                Else
                    x_start = x_equal_sign + 1
                End If
            Else
                stop_search = True
                num_str = "0"
            End If

        Loop
        strip3 = num_str

    End Function

    Private Function get_x_value(x_str As String, equal_loc As Integer) As String
        Dim y As Integer
        Dim z As Integer
        Dim space_found As Boolean
        Dim num_str As String

        space_found = False
        y = equal_loc
        Do While space_found = False
            z = InStr(y, x_str, " ")
            If z > 0 Then
                If z < equal_loc Then
                    space_found = True
                End If
                y = y - 1
            End If
            If y < 2 Then
                space_found = True
            End If
        Loop
        If equal_loc - z - 1 > 0 Then
            num_str = Mid(x_str, z + 1, equal_loc - z - 1)
        Else
            'MsgBox("equal_loc - z - 1 <= 0; equal_loc = " & equal_loc & "; z = " & z)
            num_str = 0
        End If


        get_x_value = num_str
    End Function

    Private Function strip1(x_str As String) As String
        Dim x_start As Integer
        Dim x_end As Integer
        Dim x_len As Integer
        Dim x_left As String
        Dim x_right As String

        x_start = InStr(x_str, "[")
        If x_start > 0 Then
            x_end = InStr(x_start, x_str, "]")
        End If
        If x_start > 1 And x_end > 0 Then
            x_start = x_start - 1
            x_end = x_end + 1
            x_left = Mid(x_str, 1, x_start)
            x_len = Len(x_str)
            If x_len - x_end > 0 Then
                x_right = Mid(x_str, x_end, x_len - x_end)
            Else
                '    MsgBox("x_len - x_end <= 0")
                x_right = 0
            End If
            x_str = x_left & x_right
        End If
        strip1 = x_str

    End Function
    Private Function strip2(x_str As String, x_char As String) As String
        x_str = Replace(x_str, x_char, " ")
        strip2 = x_str
    End Function











    Private Sub Preamp_version_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Preamp_version.CheckedChanged
        If Preamp_version.Checked = True Then
            Preamp_version.BackColor = Color.LightGreen
        Else
            Preamp_version.BackColor = Color.Red
        End If
        Button22.BackColor = Color.Yellow
    End Sub
    Private Sub test_preamp()
        If Preamp_version.Checked = True Then
            Preamp_version.BackColor = Color.LightGreen
            preamp_version_test_str = "PASSED. RPP4 read the Preamp Board Version correctly." & vbCrLf
        Else
            Preamp_version.BackColor = Color.Red
            preamp_version_test_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> RPP4 NOT reading Preamp Version correctly." & vbCrLf
        End If
    End Sub

    Private Sub sawtooth_check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles sawtooth_check.CheckedChanged
        Call test_sawtooth()
        Button29.BackColor = Color.Yellow

    End Sub
    Private Sub test_sawtooth()
        If sawtooth_check.Checked = True Then
            sawtooth_check.BackColor = Color.LightGreen
            sawtooth_test_str = "PASSED. Sawtooth Waveform looks correct and no missing codes." & vbCrLf
        Else
            sawtooth_check.BackColor = Color.Red
            sawtooth_test_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> Failed Sawtooth Waveform Test." & vbCrLf
        End If

    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        Call test_noise()
        If Avg.BackColor = Color.LightGreen And Stdev.BackColor = Color.LightGreen Then
            Button24.BackColor = Color.LightGreen
        Else
            Button24.BackColor = Color.Red
        End If

        Button26.BackColor = Color.Yellow

    End Sub

    Private Sub test_noise()
        If Val(Avg.Text) > Val(Avg_min.Text) And Val(Avg.Text) < Val(Avg_max.Text) Then
            avg_test_str = "PASSED. ADC Pulse noise test Average = " & Avg.Text & vbCrLf
            Avg.BackColor = Color.LightGreen
        Else
            avg_test_str = "FAILED!!! FAILED!!! FAILED!!! ------------------------------------> ADC Pulses noise test Average =  " & Avg.Text & vbCrLf
            Avg.BackColor = Color.Red
        End If

        If Val(Stdev.Text) > Val(Stdev_min.Text) And Val(Stdev.Text) < Val(Stdev_max.Text) Then
            stdev_test_str = "PASSED. ADC Pulse noise test Standard Deviation = " & Stdev.Text & vbCrLf
            Stdev.BackColor = Color.LightGreen
        Else
            stdev_test_str = "FAILED!!! FAILED!!! FAILED!!! ------------------------------------> ADC Pulses noise test Standard Deviation =  " & Stdev.Text & vbCrLf
            Stdev.BackColor = Color.Red
        End If
    End Sub

    Private Sub moisture_test_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles moisture_test.CheckedChanged
        Call test_moisture()
        Button32.BackColor = Color.Yellow

    End Sub
    Private Sub test_moisture()


        If moisture_12_str = 12 And moisture_8_str = 8 And moisture_test.Checked = True Then

            moisture_test.BackColor = Color.LightGreen
            moisture_test_str = "PASSED. Moisture Test PASSED. " & vbCrLf
        Else
            moisture_test.BackColor = Color.Red
            moisture_test_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> Moisture Test FAILED." & vbCrLf
        End If
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click


        Shell("C:\Local Data\Hyperterminal\hypertrm.exe", AppWinStyle.NormalFocus)
        ' Shell("hypertrm.exe")

        SendKeys.Send("Telnet RPP4")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("{DOWN}")
        SendKeys.Send("192.168.16.139")
        Thread.Sleep(1000)
        SendKeys.Send("{TAB}")
        SendKeys.Send("{TAB}")
        SendKeys.Send("{TAB}")
        SendKeys.Send("{ENTER}")
        Thread.Sleep(1000)
        SendKeys.Send("root")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(1000)
        SendKeys.SendWait("ps")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
        SendKeys.Send("kill ")



        '   SendKeys.SendWait("{ENTER}")






        '    SendKeys.Send("{TAB}")
        '    SendKeys.Send("{TAB}")
        '    SendKeys.Send("{LEFT}")
        '    SendKeys.Send("{LEFT}")
        '    SendKeys.Send("{TAB}")
        '    SendKeys.Send("{TAB}")
        '    SendKeys.Send("{TAB}")

        ' SendKeys.Send("{TAB}")
        ' SendKeys.Send("{TAB}")
        ' SendKeys.Send("{TAB}")
        ' SendKeys.Send("{TAB}")
        ' SendKeys.Send("{ENTER}")


    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        SendKeys.Send("PS")
        '       SendKeys.Send("{ENTER}")
        '       SendKeys.Send("PS")
        '       SendKeys.Send("{ENTER}")

    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        Dim tom_test As String
        Dim retest As Boolean
        Dim overwrite2_stat%


        Call disable_all_relays()
        Call usb_output_off()

        retest = True
        Do While retest = True
            send_and_wait_RPP4("rpp4test –a 119 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 115 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 116 –d 78" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 117 –d 258" & vbCr, "root@am335x-evm:~#", 40, 100)


            Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
            '   tom_test = strip_and_get_value("CSMISCIO")
            moisture_12_str = get_rpp4_value("=CS1_MISC_IO")

            overwrite2_stat% = MsgBox("Moisture 12 = " & moisture_12_str & " Do you want to test again?", vbInformation + vbYesNo, "CS1_MISC_IO")
            If overwrite2_stat = vbYes Then
                retest = True
            Else 'okay to write results
                retest = False
            End If
        Loop

        Call open_usb()
        Call usb_DC_3V()
        Call usb_output_on()
        Thread.Sleep(1000)

        retest = True
        Do While retest = True
            send_and_wait_RPP4("rpp4test –a 119 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 115 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 116 –d 78" & vbCr, "root@am335x-evm:~#", 40, 100)
            send_and_wait_RPP4("rpp4test –a 117 –d 258" & vbCr, "root@am335x-evm:~#", 40, 100)

            Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
            '   tom_test = strip_and_get_value("CSMISCIO")
            moisture_8_str = get_rpp4_value("=CS1_MISC_IO")

            overwrite2_stat% = MsgBox("Moisture 8 = " & moisture_8_str & " Do you want to test again?", vbInformation + vbYesNo, "CS1_MISC_IO")
            If overwrite2_stat = vbYes Then
                retest = True
            Else 'okay to write results
                retest = False
            End If
        Loop

        Call usb_exit()

        Try
            AppActivate(rpp4tester_id)
            Thread.Sleep(200)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Call usb_output_off()
        MsgBox("Wait a few seconds and then Verify MOISTURE_MSW = 0 on the RPPTest Program.")

        Call open_usb()
        Call usb_pulse_500nsec()
        Call usb_output_on()
        Call usb_exit()
        Thread.Sleep(1000)
        Try
            AppActivate(rpp4tester_id)
            Thread.Sleep(200)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        MsgBox("Wait a few seconds and then Verify MOISTURE_MSW = 10000 on the RPPTest Program.")


        '   send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        '   MsgBox("wai3")
        '   H2O_high.Text = strip_and_get_value("CSMOISTUREMSW")
        '   MsgBox("wai4")
        '   send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        '   MsgBox("wai3")
        '   H2O_high.Text = strip_and_get_value("CSMOISTUREMSW")
        '   send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        '   MsgBox("wai3")
        '   H2O_high.Text = strip_and_get_value("CSMOISTUREMSW")



        '     MsgBox("Configure Waveform Generator for: " & vbCrLf & _
        '    "1) Pulse, Freq=10Khz, Ampl=3Vpp, Offset=0 Volt, Width=100nsec, and Output=ON." & vbCrLf & _
        '    "2) Verify CS1_MOISTURE_MSW=0" & vbCrLf & _
        '    "3) Change Width=500nsec" & vbCrLf & _
        '    "4) Verify CS1_MOISTURE_MSW=10,000")
        '     Button22.BackColor = Color.LightGreen
        '    moisture_test.BackColor = Color.Yellow


        moisture_test.BackColor = Color.Yellow
        Button22.BackColor = Color.LightGreen



    End Sub
    Private Sub start_rpptest()
        MsgBox("1) Enter RPP4 MAC Address: " & tb_ProgrammedMAC.Text & " into top box and select the RJ-45 Jack ICON after the RPPTest program opens." & vbCrLf &
               "2) Then verify the Program can read the Preamp Board Revision")
        '   rpp4tester_id = Shell("\\CLARITYSVR\Company Shared Folders\Production\Manufacturing Data\Board Level Products\PCA0346 - RPP4 (ThermoFisher)\Software\RPP4Tester\RPPTester.exe", AppWinStyle.NormalFocus)

        'added by Tom 1-6-2016
        send_and_wait_RPP4("ifconfig eth0 192.168.16.25" & vbCr, "root@am335x-evm:~#", 20, 100)
        'added by Tom 1-6-2016

        rpp4tester_id = Shell("C:\RPP4\RPPTester.exe", AppWinStyle.NormalFocus)

        Thread.Sleep(100)

        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        Thread.Sleep(100)
        Button25.BackColor = Color.LightGreen
        Preamp_version.BackColor = Color.Yellow
        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)


    End Sub
    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        Call start_rpptest()
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        Call open_usb()
        Call usb_ramp()
        Call usb_output_on()
        Call usb_exit()
        Try
            AppActivate(rpp4tester_id)
            Thread.Sleep(200)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        '    MsgBox("Configure Waveform Generator for: " & vbCrLf & _
        '           "1) Ramp, Freq=15Khz, Ampl=4Vpp, Offset=1 Volt, and Output=ON." & vbCrLf & _
        '           "2) Go to ADC Samples and verify proper Waveform." & vbCrLf & _
        '           "3) Turn Output=OFF and record the Avg value and Stdev values")
        sawtooth_check.BackColor = Color.Yellow
        Button26.BackColor = Color.LightGreen

    End Sub
    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        Call start_ngen_test()
    End Sub
    Private Sub start_ngen_test()
        Call disable_all_relays()
        Call enable_relay6()
        Call enable_relay7()


        '    Call open_usb()
        Call usb_output_off()


        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        NGEN_12.Text = get_rpp4_value("=CS1_MISC_IO")

        '   NGEN_12.Text = strip_and_get_value("CSMISCIO")
        If NGEN_12.Text = "12" Then
            NGEN_12.BackColor = Color.LightGreen
        Else
            NGEN_12.BackColor = Color.Red
        End If

        Call usb_DC_3V()
        Call usb_output_on()
        Thread.Sleep(1000)
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        NGEN_4.Text = get_rpp4_value("=CS1_MISC_IO")
        '        NGEN_4.Text = strip_and_get_value("CSMISCIO")
        If NGEN_4.Text = "4" Then
            NGEN_4.BackColor = Color.LightGreen
        Else
            NGEN_4.BackColor = Color.Red
        End If
        Call usb_exit()

        '  MsgBox("Configure Waveform Generator for: " & vbCrLf & _
        '         "1) Ramp, Freq=10Khz, Ampl=10mV, Offset=3 Volt, and Output=ON." & vbCrLf & _
        '         "2) And verify CS1_MISC_IO = 4.")
        Button27.BackColor = Color.LightGreen
        Button27.Refresh()
        LED_15_on_check.BackColor = Color.Yellow
        LED7_blinking_check.BackColor = Color.Yellow
    End Sub



    Private Sub test_ngen()

        If NGEN_12.Text = "12" Then
            NGEN_12.BackColor = Color.LightGreen
        Else
            NGEN_12.BackColor = Color.Red
        End If

        If NGEN_4.Text = "4" Then
            NGEN_4.BackColor = Color.LightGreen
        Else
            NGEN_4.BackColor = Color.Red
        End If

        If NGEN_4.BackColor = Color.LightGreen And NGEN_12.BackColor = Color.LightGreen Then
            ngen_test_str = "PASSED. NGEN Test PASSED. " & vbCrLf
        Else
            ngen_test_str = "FAILED!!! FAILED!!! FAILED!!! ----------------> NGEN Test FAILED." & vbCrLf
        End If

    End Sub
    Function ImpedanceFailuresCheck() As Boolean
        Dim impedance_failures As List(Of TextBox) = (From tb As TextBox In flp_impedances.Controls
                                                      Where tb.BackColor = Color.Red).ToList

        If impedance_failures.Any Then
            btn_ImpedanceTest.BackColor = Color.Red
            Return True
        Else
            btn_ImpedanceTest.BackColor = Color.LightGreen
            Return False
        End If
    End Function
    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles btn_VoltageTest.Click
        If ImpedanceFailuresCheck() = True Then
            MsgBox("Voltage test aborted! DO NOT apply power to PCA until impedance failures are resolved!")
        Else
            start_voltage_test()
        End If

    End Sub
    Function VoltageFailures() As Boolean
        Dim voltage_failures As List(Of TextBox) = (From tb As TextBox In flp_voltages.Controls
                                                    Where tb.BackColor = Color.Red).ToList

        If voltage_failures.Any Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub start_voltage_test()
        btn_VoltageTest.BackColor = Color.Yellow
        btn_VoltageTest.Refresh()

        enable_uut_pwr()
        Thread.Sleep(500)
        voltage_test()

        If VoltageFailures() = True Then
            btn_VoltageTest.BackColor = Color.Red
        Else
            btn_VoltageTest.BackColor = Color.LightGreen
            btn_LoadLinux.BackColor = Color.LemonChiffon
        End If
        btn_VoltageTest.Refresh()
        btn_LoadLinux.Refresh()

    End Sub
    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click

        Try

            AppActivate(rpp4tester_id)
            SendKeys.SendWait("%{F4}")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Command6.BackColor = Color.Yellow
        Button29.BackColor = Color.LightGreen
    End Sub


    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
        rpp4tester_id = Shell("\\CLARITYSVR\Company Shared Folders\Production\Manufacturing Data\Board Level Products\PCA0346 - RPP4 (ThermoFisher)\Software\RPP4Tester\RPPTester.exe", AppWinStyle.NormalFocus)

        Thread.Sleep(2000)
        SendKeys.Send("{RIGHT}")
        Thread.Sleep(100)
        SendKeys.Send("{RIGHT}")
        Thread.Sleep(100)


    End Sub


    Private Sub Label105_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Public ProcID2 As Integer
    Private Sub open_usb()
        Dim use_usb As Boolean


        '  Call disable_LAN()

        use_usb = False
        If use_usb = True Then
            MsgBox("DISABLE LAN before preceeding.")
            ProcID2 = Shell("C:\Program Files\Agilent\IO Libraries Suite\InteractiveIO.exe", AppWinStyle.NormalFocus)


            '    MsgBox("Wait until program loaded.")

            Thread.Sleep(1000)

            AppActivate(ProcID2)

            'MsgBox("Wait until program running.")

            SendKeys.Send("%{c}")
            Thread.Sleep(100)
            SendKeys.Send("o")
            Thread.Sleep(100)
            SendKeys.Send("USBInstrument1")
            Thread.Sleep(100)
            SendKeys.Send("{ENTER}")
            Thread.Sleep(100)
            SendKeys.Send("{TAB}")
            Thread.Sleep(100)
        End If


    End Sub
    Private Sub usb_output_on()
        'AppActivate(ProcID2)
        'SendKeys.Send("OUTPut ON")
        'Thread.Sleep(100)
        'SendKeys.Send("{ENTER}")
        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("Turn waveform generator output ON.")
    End Sub
    Private Sub usb_output_off()
        '  AppActivate(ProcID2)
        '  SendKeys.Send("OUTPut OFF")
        ' Thread.Sleep(100)
        'SendKeys.Send("{ENTER}")
        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("Turn waveform generator output OFF.")
    End Sub
    Private Sub usb_pulse_100nsec()
        '   AppActivate(ProcID2)
        '   SendKeys.Send("FUNCtion PULSe")
        '   Thread.Sleep(100)
        '   SendKeys.Send("{ENTER}")
        '   Thread.Sleep(100)
        '   SendKeys.Send("FREQuency 10000;VOLTage 3;voltage:offset 0")
        '   Thread.Sleep(100)
        '   SendKeys.Send("{ENTER}")
        '   Thread.Sleep(100)
        '   SendKeys.Send("PULSe:WIDTh 100e-9")
        '   Thread.Sleep(100)
        '   SendKeys.Send("{ENTER}")
        '   Thread.Sleep(100)

        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("1) Set Function to PULSE." & vbCrLf & "2) Frequency = 10 kHz, Amplitude = 3 Vpp, Offset = 0 V" & vbCrLf & "3) Set Pulse Width=100nsec.")
    End Sub
    Private Sub usb_exit()
        Dim use_usb As Boolean

        use_usb = False
        If use_usb = True Then

            AppActivate(ProcID2)
            SendKeys.Send("%{c}")
            Thread.Sleep(100)
            SendKeys.Send("e")
            Thread.Sleep(100)

            '   Call enable_LAN()
            MsgBox("ENABLE LAN before preceeding.")
        End If

    End Sub
    Private Sub usb_pulse_500nsec()
        '    AppActivate(ProcID2)
        '    SendKeys.Send("PULSe:WIDTh 500e-9")
        '    Thread.Sleep(100)
        '    SendKeys.Send("{ENTER}")
        '    Thread.Sleep(100)

        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("1) Set Function to PULSE." & vbCrLf & "2) Frequency = 10 kHz" & vbCrLf & "3) Amplitude = 3 V" & vbCrLf & "4) Offset = 3 V" & vbCrLf & "4) Pulse Width = 500 ns")
    End Sub
    Private Sub usb_ramp()
        '    AppActivate(ProcID2)
        '    SendKeys.Send("FUNCtion RAMP")
        '    Thread.Sleep(100)
        '    SendKeys.Send("{ENTER}")
        '    Thread.Sleep(100)
        '    SendKeys.Send("FREQuency 15000;VOLTage 4;voltage:offset 1")
        '    Thread.Sleep(100)
        '    SendKeys.Send("{ENTER}")
        '    Thread.Sleep(100)

        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("1) Set Function to RAMP." & vbCrLf & "2) Frequency = 15 kHz, Amplitude = 4 Vpp, Offset = 1 V")
    End Sub
    Private Sub usb_DC_3V()
        '   AppActivate(ProcID2)
        '   SendKeys.Send("FUNCtion RAMP")
        '   Thread.Sleep(100)
        '   SendKeys.Send("{ENTER}")
        '   Thread.Sleep(100)
        '   SendKeys.Send("FREQuency 15000;VOLTage 10e-9;voltage:offset 3")
        '   Thread.Sleep(100)
        '   SendKeys.Send("{ENTER}")
        '   Thread.Sleep(100)

        'Disabled USB comm code to instrument 1-26-2016 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        MsgBox("1) Set Function to RAMP." & vbCrLf & "2) Frequency = 15 kHz, Amplitude = 10mV Vpp, Offset = 3 V")
    End Sub
    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        Call open_usb()
        Call usb_pulse_100nsec()
        Call usb_output_on()
        Call usb_ramp()
        Call usb_DC_3V()
    End Sub

    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click

        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        Call disable_all_relays()
        Call enable_relay6()
        Call open_usb()
        Call usb_output_off()
        Call usb_ramp()
        Call usb_exit()
        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        Try
            AppActivate(rpp4tester_id)
            Thread.Sleep(200)
            SendKeys.Send("{RIGHT}")
            Thread.Sleep(100)
            SendKeys.Send("{RIGHT}")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Record the Avg and StDev values")
        Button32.BackColor = Color.LightGreen
        Button24.BackColor = Color.Yellow
        send_and_wait_RPP4("rpp4test –a 21f –d 5" & vbCr, "root@am335x-evm:~#", 40, 100)

    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox10.CheckedChanged

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox7.CheckedChanged

    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click
        send_and_wait_RPP4("rpp4test –a 119 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
        send_and_wait_RPP4("rpp4test –a 115 –d a" & vbCr, "root@am335x-evm:~#", 40, 100)
        send_and_wait_RPP4("rpp4test –a 116 –d 78" & vbCr, "root@am335x-evm:~#", 40, 100)
        send_and_wait_RPP4("rpp4test –a 117 –d 258" & vbCr, "root@am335x-evm:~#", 40, 100)

        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")
        Call send_and_wait_RPP4("rpp4test" & vbCr, "root@am335x-evm:~#", 40, 100)
        MsgBox("Wait")

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_UUT_COM.SelectedIndexChanged

    End Sub

    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click
        Call search_all_com_ports()
    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        ProcID2 = Shell("C:\Program Files\Agilent\IO Libraries Suite\InteractiveIO.exe", AppWinStyle.NormalFocus)


        '    MsgBox("Wait until program loaded.")

        Thread.Sleep(1000)

        AppActivate(ProcID2)

        '     MsgBox("Wait until program running.")

        SendKeys.Send("%{c}")
        Thread.Sleep(100)
        SendKeys.Send("o")
        Thread.Sleep(100)
        SendKeys.Send("USBInstrument1")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(100)
        SendKeys.Send("{TAB}")
        Thread.Sleep(100)

    End Sub


    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles Button37.Click
        Call open_usb()

    End Sub

    Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles Button38.Click
        Call usb_output_off()

    End Sub



    Private Sub Button50_Click(sender As System.Object, e As System.EventArgs) Handles Button50.Click
        Call disable_LAN()
    End Sub
    Private Sub disable_LAN()

        Dim MyProcess As Process

        If MyProcess Is Nothing Then
            MyProcess = Process.Start("cmd.exe", "arguments")
        End If

        System.Threading.Thread.Sleep(100)
        SendKeys.Send("control.exe /name ")
        SendKeys.Send("Microsoft.Network")
        SendKeys.Send("AndSharingCenter")
        SendKeys.Send(vbCrLf)

        System.Threading.Thread.Sleep(3000)

        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(2000)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)

        SendKeys.Send(vbCrLf)
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("l")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send(vbCrLf)
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send(vbCrLf)
        System.Threading.Thread.Sleep(2000)

        SendKeys.Send("%{f}") 'close Networks and sharing
        System.Threading.Thread.Sleep(1000)
        SendKeys.Send("c")

        If MyProcess IsNot Nothing Then
            MyProcess.Kill()
            MyProcess.Close()
            MyProcess = Nothing
        End If

        SendKeys.Send("%{f}") 'close Networks and sharing
        System.Threading.Thread.Sleep(1000)
        SendKeys.Send("c")

    End Sub

    Private Sub Button51_Click(sender As System.Object, e As System.EventArgs) Handles Button51.Click
        Call enable_LAN()
    End Sub
    Private Sub enable_LAN()

        Dim MyProcess As Process

        If MyProcess Is Nothing Then
            MyProcess = Process.Start("cmd.exe", "arguments")
        End If

        System.Threading.Thread.Sleep(100)
        SendKeys.Send("control.exe /name ")
        SendKeys.Send("Microsoft.Network")
        SendKeys.Send("AndSharingCenter")
        SendKeys.Send(vbCrLf)

        System.Threading.Thread.Sleep(3000)

        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(2000)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("{TAB}")
        System.Threading.Thread.Sleep(200)

        SendKeys.Send(vbCrLf)
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("l")
        System.Threading.Thread.Sleep(200)
        SendKeys.Send(vbCrLf)
        System.Threading.Thread.Sleep(3000)


        SendKeys.Send("%{f}") 'close Networks and sharing
        System.Threading.Thread.Sleep(200)
        SendKeys.Send("c")

        If MyProcess IsNot Nothing Then
            MyProcess.Kill()
            MyProcess.Close()
            MyProcess = Nothing
        End If
    End Sub

    Private Sub mem_test()
        'memory test from Ben 1-25-2016 *************************************************************
        'memory test from Ben 1-25-2016 *************************************************************

        Call close_rpp4_port()
        Call disable_uut_pwr()
        Thread.Sleep(1000)
        Call enable_uut_pwr()
        Thread.Sleep(2000)
        Call open_rpp4_port()
        Thread.Sleep(500)
        Button8.Refresh()
        send_and_wait_RPP4(vbCr, "Hit any key to stop autoboot:", 50, 100)
        Thread.Sleep(500)
        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)
        Thread.Sleep(1000)


        send_and_wait_RPP4("mtest 0x80000000 0x87f7be28 0xa5a5a5a5 1" & vbCr, "U-Boot#", 350, 100)
        ' send_and_wait_RPP4("mtest 0x80000000 0x87f7be28 0xa5a5a5a5 1" & vbCr, "Tested 1 iterations(s) with 0 errors.", 350, 100)
        Thread.Sleep(1000)

        mem_test_return = RichTextBox1.Text
        'MsgBox(mem_test_return)
        If InStr(mem_test_return, "Tested 1 iteration(s) with 0 errors.") > 0 Then
            btn_MemoryTest.BackColor = Color.LightGreen
            mem_test_result = "Memory Test PASSED." & vbCrLf
        Else
            btn_MemoryTest.BackColor = Color.Red
            mem_test_result = "Memory Test FAILED!!!" & vbCrLf
        End If

        btn_ProgramFPGA.BackColor = Color.Yellow
        If CheckBox5.Checked = True And btn_MemoryTest.BackColor = Color.LightGreen Then
            '      Call start_xilinx()
        End If

    End Sub
    Private Sub Button54_Click(sender As System.Object, e As System.EventArgs) Handles btn_MemoryTest.Click
        Call mem_test()
    End Sub

    Sub MemTest2()
        btn_MemoryTest.BackColor = Color.Yellow
        btn_MemoryTest.Refresh()

        send_and_wait_RPP4(vbCr, "U-Boot#", 10, 100)
        Thread.Sleep(1000)

        send_and_wait_RPP4("mtest 0x80000000 0x87f7be28 0xa5a5a5a5 1" & vbCr, "U-Boot#", 350, 100)
        ' send_and_wait_RPP4("mtest 0x80000000 0x87f7be28 0xa5a5a5a5 1" & vbCr, "Tested 1 iterations(s) with 0 errors.", 350, 100)
        Thread.Sleep(1000)

        mem_test_return = RichTextBox1.Text
        'MsgBox(mem_test_return)
        If InStr(mem_test_return, "Tested 1 iteration(s) with 0 errors.") > 0 Then
            btn_MemoryTest.BackColor = Color.LightGreen
            mem_test_result = "Memory Test PASSED." & vbCrLf
            btn_ProgramFPGA.BackColor = Color.LemonChiffon
        Else
            btn_MemoryTest.BackColor = Color.Red
            mem_test_result = "Memory Test FAILED!!!" & vbCrLf
        End If
        btn_MemoryTest.Refresh()
    End Sub

    Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles Button36.Click

        crc_test()
        start_ver_test()

    End Sub
    Private Sub crc_test()
        Dim crc_return As String
        Dim str_crc As String

        If debug_port.IsOpen Then
            debug_port.DiscardInBuffer()
        End If

        Thread.Sleep(2000)
        RichTextBox1.Text = ""
        RichTextBox1.Refresh()

        Call boot_linux()


        send_and_wait_RPP4("cd /usr/bin" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("filecrc pulsesvr" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("filecrc rpp4app" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)

        crc_return = RichTextBox1.Text
        crc_return = Microsoft.VisualBasic.Right(crc_return, 200)

        crc_pulse_test = True
        crc_rpp4_test = True
        crc_test_result = ""
        str_crc = "CRC: " & txt_crc_pulsesvr.Text
        'MsgBox("Searching for " & str_crc & vbCrLf & vbCrLf & "from:" & vbCrLf & vbCrLf & crc_return)

        If InStr(crc_return, str_crc) > 0 Then
            crc_test_result = crc_test_result & "pulsesvr CRC File Integrity Test PASSED." & vbCrLf
        Else
            crc_pulse_test = False
            crc_test_result = crc_test_result & "pulsesvr CRC File Integrity Test FAILED!!!" & vbCrLf
        End If

        str_crc = "CRC: " & txt_crc_rpp4app.Text
        'MsgBox("Searching for " & str_crc & vbCrLf & vbCrLf & "from:" & vbCrLf & vbCrLf & crc_return)
        If InStr(crc_return, str_crc) > 0 Then
            crc_test_result = crc_test_result & "rpp4app CRC File Integrity Test PASSED." & vbCrLf
        Else
            crc_rpp4_test = False
            crc_test_result = crc_test_result & "rpp4app CRC File Integrity Test FAILED!!!" & vbCrLf
        End If

        If crc_pulse_test = False Or crc_rpp4_test = False Then
            Button36.BackColor = Color.Red
        Else
            Button36.BackColor = Color.LightGreen
        End If

        Button16.BackColor = Color.Yellow


        If CheckBox6.Checked = True Then
            Call start_ver_test()
        End If

    End Sub

    Private Sub Button39_Click(sender As System.Object, e As System.EventArgs) Handles Button39.Click
        '    Dim xilinx As New Form3
        Dim ps_kill As String


        Dim crc_return As String
        Dim str_crc As String


        Thread.Sleep(2000)
        RichTextBox1.Text = ""
        RichTextBox1.Refresh()

        Call boot_linux()


        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/pulsesvr")
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        ps_kill = get_ps_value("/usr/bin/rpp4app")
        Thread.Sleep(2000)
        send_and_wait_RPP4("kill " & ps_kill & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("ps" & vbCr, "root@am335x-evm:~#", 20, 100)
        Thread.Sleep(2000)

        Call start_telnet()
        Thread.Sleep(1000)
        Call third_tftp()
        Thread.Sleep(1000)
        Call kill_telnet()
        Thread.Sleep(1000)




        send_and_wait_RPP4("cd /usr/bin" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("filecrc pulsesvr" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)
        send_and_wait_RPP4("filecrc rpp4app" & vbCr, "root@am335x-evm:/usr/bin#", 20, 100)
        Thread.Sleep(2000)

        crc_return = RichTextBox1.Text

        crc_return = Microsoft.VisualBasic.Right(crc_return, 200)

        MsgBox(crc_return)

        crc_pulse_test = True
        crc_rpp4_test = True
        crc_test_result = ""
        str_crc = "CRC: " & txt_crc_pulsesvr.Text

        If InStr(crc_return, str_crc) > 0 Then
            crc_test_result = crc_test_result & "pulsesvr CRC File Integrity Test PASSED." & vbCrLf
        Else
            crc_pulse_test = False
            crc_test_result = crc_test_result & "pulsesvr CRC File Integrity Test FAILED!!!" & vbCrLf
        End If

        str_crc = "CRC: " & txt_crc_rpp4app.Text
        If InStr(crc_return, str_crc) > 0 Then
            crc_test_result = crc_test_result & "rpp4app CRC File Integrity Test PASSED." & vbCrLf
        Else
            crc_pulse_test = False
            crc_test_result = crc_test_result & "rpp4app CRC File Integrity Test FAILED!!!" & vbCrLf
        End If

        If crc_pulse_test = False Then
            Button36.BackColor = Color.LightGreen
        Else
            Button36.BackColor = Color.Red
        End If

        Button16.BackColor = Color.Yellow


        If CheckBox6.Checked = True Then
            Call start_ver_test()
        End If

    End Sub

    Private Sub Button40_Click(sender As System.Object, e As System.EventArgs) Handles Button40.Click
        Dim str_crc As String
        Dim str_t As String

        str_crc = "CRC: " & txt_crc_pulsesvr.Text
        str_t = "root@am335x-evm:/usr/bin# filecrc pulsesvr File: [pulsesvr] Read: 112814 bytes CRC: 0xf2b68d72 root@am335x-evm:/usr/bin# filecrc rpp4app File: [rpp4app] Read: 137927 bytes CRC: 0x47e72266 oot@am335x-evm:/usr/bin#"

        str_t = Microsoft.VisualBasic.Right(str_t, 200)

        If InStr(str_t, str_crc) > 0 Then
            MsgBox("pulse found")

        Else
            MsgBox("pulse NOT found")
        End If

        str_crc = "CRC: " & txt_crc_rpp4app.Text
        If InStr(str_t, str_crc) > 0 Then
            MsgBox("rpp4 found")
        Else
            MsgBox("rpp4 NOT found")
        End If


    End Sub

    Private Sub T4_max_TextChanged(sender As System.Object, e As System.EventArgs) Handles T4_max.TextChanged

    End Sub

    Private Sub RTD_sense_open_min_TextChanged(sender As System.Object, e As System.EventArgs) Handles RTD_sense_open_min.TextChanged

    End Sub
    'Mulitmeter code *******************************************************************************
    'Mulitmeter code *******************************************************************************
    'Mulitmeter code *******************************************************************************
    'Mulitmeter code *******************************************************************************
    'Mulitmeter code *******************************************************************************

    Sub CheckDMMError(myDmm As FormattedIO488)
        myDmm.WriteString("SYST:ERR?")
        Dim errStr As String = myDmm.ReadString()
        If (errStr.Contains("No error")) Then 'If no error, then return
            Return
            'If there is an error, read out all of the errors and return them in an exception
        Else
            Dim errStr2 As String = ""
            Do
                myDmm.WriteString("SYST:ERR?")
                errStr2 = myDmm.ReadString()
                If (Not errStr2.Contains("No error")) Then
                    errStr = errStr + "\n" + errStr2
                End If
            Loop While (Not errStr2.Contains("No error"))
            Throw New Exception("Exception: Encountered system error(s)\n" + errStr)
        End If
    End Sub


    Private Sub Read_DC_Volt()

        Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
        Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 
        Try
            Dim DutAddr As String = Meter_Address  'Example string for USB
            myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout
            myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
            myDmm.WriteString("*RST")  'Reset the device
            myDmm.WriteString("*IDN?")  'Get the IDN string                
            Dim IDN As String = myDmm.ReadString()
            myDmm.WriteString("CONF:VOLT:DC 100, 0.0001")
            myDmm.WriteString("READ?")
            Dim DCVResult As String = myDmm.ReadString()
            txt_read_dc_value.Text = DCVResult
            voltage = txt_read_dc_value.Text
            CheckDMMError(myDmm)  'Check if the DMM has any errors

        Catch ex As Exception
            MsgBox("Error occured: " + ex.Message)
        Finally
            Try
                myDmm.IO.Close()
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myDmm)
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub Init_meter_button_Click(sender As System.Object, e As System.EventArgs) Handles Init_meter_button.Click
        Call Read_cfg_file()
        Meter_Address = Txt_Meter_Address.Text
        Call setup_meter()

    End Sub
    Private Sub Read_cfg_file()
        Dim f As String

        f = "34461A-" & Computer.Text & ".cfg"
        If System.IO.File.Exists(f) Then
            str_threshold_file = My.Computer.FileSystem.ReadAllText(f)
            Txt_Meter_Address.Text = str_threshold_file
        Else
            MsgBox("ERROR!!! The " & f & " File does NOT exist!")
            Computer.Text = ""
        End If

        f = "crc_pulsesvr.cfg"
        If System.IO.File.Exists(f) Then
            txt_crc_pulsesvr.Text = My.Computer.FileSystem.ReadAllText(f)
        Else
            MsgBox("ERROR!!! The " & f & " File does NOT exist!")
            txt_crc_pulsesvr.Text = ""
        End If


        f = "crc_rrp4app.cfg"
        If System.IO.File.Exists(f) Then
            txt_crc_rpp4app.Text = My.Computer.FileSystem.ReadAllText(f)
        Else
            MsgBox("ERROR!!! The " & f & " File does NOT exist!")
            txt_crc_rpp4app.Text = ""
        End If


        f = "fpga_version.cfg"
        If System.IO.File.Exists(f) Then
            FPGA_ver_value.Text = My.Computer.FileSystem.ReadAllText(f)
        Else
            MsgBox("ERROR!!! The " & f & " File does NOT exist!")
            FPGA_ver_value.Text = ""
        End If


        f = "build_version.cfg"
        If System.IO.File.Exists(f) Then
            build_ver_value.Text = My.Computer.FileSystem.ReadAllText(f)
        Else
            MsgBox("ERROR!!! The " & f & " File does NOT exist!")
            build_ver_value.Text = ""
        End If


    End Sub

    Private Sub setup_meter()

        '' """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
        ''  © Agilent Technologies, Inc. 2013
        ''
        '' You have a royalty-free right to use, modify, reproduce and distribute
        '' the Sample Application Files (and/or any modified version) in any way
        '' you find useful, provided that you agree that Agilent Technologies has no
        '' warranty,  obligations or liability for any Sample Application Files.
        ''
        '' Agilent Technologies provides programming examples for illustration only,
        '' This sample program assumes that you are familiar with the programming
        '' language being demonstrated and the tools used to create and debug
        '' procedures. Agilent Technologies support engineers can help explain the
        '' functionality of Agilent Technologies software components and associated
        '' commands, but they will not modify these samples to provide added
        '' functionality or construct procedures to meet your specific needs.
        '' """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
        'This example program illustrates how to connect to an instrument
        'Gives an example setup for all major function configurations (DCV, DCI, Ohms2W, Ohms 4W, ACV, ACI, Temp, Freq). 
        'Gets a single reading from the DMM for each function and reports the result. 
        'Ohms 4W shows an autorange setup while all other functions show a direct range setup.

        'For more information on getting started using VISA COM I/O operations see the app note located at:
        'http:'cp.literature.agilent.com/litweb/pdf/5989-6338EN.pdf
        Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
        Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 

        Try
            'Dim DutAddr as String = "GPIB0::22"  'String for GPIB
            'Dim DutAddr as String = "TCPIP0::169.254.4.61"   'Example string for LAN
            Dim DutAddr As String = Meter_Address  'Example string for USB
            'Dim DutAddr As String = "USB0::0x0957::0x1C07::US00000069::0::INSTR"  'String for GPIB
            'Dim DutAddr As String = "TCPIP0::156.140.92.16"   'Example string for LAN

            myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout

            'myDmm.IO.Timeout = 3000  'You can also set your timeout by doing this command, sets to 3 seconds

            'First start off with a reset state
            myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
            myDmm.WriteString("*RST")  'Reset the device
            myDmm.WriteString("*IDN?")  'Get the IDN string                
            Dim IDN As String = myDmm.ReadString()
            txt_init_box.Text = IDN 'report the DMM's identity
            Init_meter_button.BackColor = Color.LightGreen
            CheckDMMError(myDmm)  'Check if the DMM has any errors

        Catch ex As Exception
            '  Console.WriteLine("Error occured: " + ex.Message)
            MsgBox("Error occured: " + ex.Message)
            Init_meter_button.BackColor = Color.Red
        Finally
            'Close out your resources
            Try
                myDmm.IO.Close()
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myDmm)
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
            Catch ex As Exception
            End Try
        End Try
    End Sub


    Private Sub read_DC_Current()
        Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
        Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 
        Try
            Dim DutAddr As String = Meter_Address  'Example string for USB
            myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout
            myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
            myDmm.WriteString("*RST")  'Reset the device
            myDmm.WriteString("*IDN?")  'Get the IDN string                
            Dim IDN As String = myDmm.ReadString()
            'Configure for DCI 10A range, 100uA resolution
            myDmm.WriteString("CONF:CURR:DC 10, 0.0001")
            myDmm.WriteString("READ?")
            Dim MeterResult As String = myDmm.ReadString()
            read_current_value.Text = MeterResult
            charge_current = MeterResult
            CheckDMMError(myDmm)  'Check if the DMM has any errors
        Catch ex As Exception
            MsgBox("Error occured: " + ex.Message)
        Finally
            Try
                myDmm.IO.Close()
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myDmm)
            Catch ex As Exception
            End Try
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Private Sub Read_DC_Button_Click(sender As System.Object, e As System.EventArgs) Handles Read_DC_Button.Click
        Call Read_DC_Volt()
    End Sub

    Private Sub Read_DC_Current_Button_Click(sender As System.Object, e As System.EventArgs) Handles Read_DC_Current_Button.Click
        Call read_DC_Current()
    End Sub

    Private Sub Button48_Click(sender As System.Object, e As System.EventArgs) Handles Button48.Click
        Call Read_cfg_file()
    End Sub



    Private Sub t()
        Dim rm As Ivi.Visa.Interop.ResourceManager = New Ivi.Visa.Interop.ResourceManager()   'Open up a new resource manager
        Dim myDmm As Ivi.Visa.Interop.FormattedIO488 = New Ivi.Visa.Interop.FormattedIO488()  'Open a new Formatted IO 488 session 
        Dim DutAddr As String = Meter_Address  'Example string for USB
        myDmm.IO = rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "")  'Open up a handle to the DMM with a 2 second timeout
        myDmm.IO.Clear()  'Send a device clear first to stop any measurements in process
        myDmm.WriteString("*RST")  'Reset the device
        myDmm.WriteString("*IDN?")  'Get the IDN string                
        Dim IDN As String = myDmm.ReadString()

        'Configure for ACV 100V range, to read a 100 Hz signal
        myDmm.WriteString("CONF:VOLT:AC 100, 0.0001")
        myDmm.WriteString("VOLT:AC:BAND 20") 'Choose the band that is lower than your input frequency, Bands are 3 Hz|20 Hz|200 Hz
        myDmm.WriteString("READ?")
        Dim ACVResult As String = myDmm.ReadString()
        Console.WriteLine("ACV Reading = " + ACVResult)  'report the ACV reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors

        'Configure for DCI 10A range, 100uA resolution
        myDmm.WriteString("CONF:CURR:DC 10, 0.0001")
        myDmm.WriteString("READ?")
        Dim DCIResult As String = myDmm.ReadString()
        Console.WriteLine("DCI Reading = " + DCIResult)  'report the DCI reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors

        'Configure for ACI 10mA range, to read a 100 KHz signal
        myDmm.WriteString("CONF:CURR:AC .01, 0.0001")
        myDmm.WriteString("VOLT:AC:BAND 200") 'Choose the band that is lower than your input frequency, Bands are 3 Hz|20 Hz|200 Hz
        myDmm.WriteString("READ?")
        Dim ACIResult As String = myDmm.ReadString()
        Console.WriteLine("ACI Reading = " + ACIResult)  'report the ACV reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors

        'Configure for OHM 2 wire 100 Ohm range, 100uOhm resolution
        myDmm.WriteString("CONF:RES 100, 0.0001")
        myDmm.WriteString("READ?")
        Dim Res2WResult As String = myDmm.ReadString()
        Console.WriteLine("2 Wire Resistance Reading = " + Res2WResult)  'report the 2W resistance reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors

        'Configure for OHM 4 wire Autoranged
        myDmm.WriteString("CONF:FRES")
        myDmm.WriteString("READ?")
        Dim Res4WResult As String = myDmm.ReadString()
        Console.WriteLine("4 Wire Resistance Reading = " + Res4WResult)  'report the 2W resistance reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors


        'Configure for Frequency 100V, 1Khz signal, maximum resolution
        myDmm.WriteString("CONF:FREQ 200, MAX")  'Sets the bandwidth range to 200 (highest BW range) which will measure a 1Khz signal
        myDmm.WriteString("FREQ:VOLT:RANG  100")
        myDmm.WriteString("READ?")
        Dim FreqResult As String = myDmm.ReadString()
        Console.WriteLine("Freq Reading = " + FreqResult)  'report the 2W resistance reading
        CheckDMMError(myDmm)  'Check if the DMM has any errors



    End Sub

    Private Sub Button49_Click(sender As System.Object, e As System.EventArgs) Handles Button49.Click
        Call read_meter_ohm()
        txt_ohm.Text = resistance
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles btn_ImpedanceTest.Click
        btn_ImpedanceTest.BackColor = Color.Yellow
        btn_ImpedanceTest.Refresh()

        Call disable_uut_pwr()

        Dim switchstring = "SW2: 00001001     SW1: 11011011"
        'MsgBox("Make sure:" & vbCrLf & vbCrLf & "1) SD Card is inserted." & vbCrLf & "2) Switch 1 is set to all off." & vbCrLf & "3) Switch 2 set to 01101111. ")
        MsgBox("Make sure:" & vbCrLf & vbCrLf & "1) SD Card is inserted." & vbCrLf & vbCrLf & "2) Switches are set: " & vbCrLf & switchstring)

        SetDipswitches(24)
        impedance_test()
        ImpedanceFailuresCheck()
    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click

        'Dim psi As New ProcessStartInfo
        'psi.FileName = "C:\Hyperterminal\TST10.exe"
        'psi.Arguments = "/r:ftp1.txt /o:output.txt"
        'Process.Start("powershell", "-File C:\Hyperterminal\ftp1.sh")

        'Process.Start("C:\Hyperterminal\TST10.exe", "/r:ftp1.txt /o:output.txt")
        System.Diagnostics.Process.Start("C:\Hyperterminal\ftp1.bat")
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles btn_MAC_IP.Click
        search_all_com_ports()

        start_program_mac()

        start_ip_address()
    End Sub

    Private Sub tb_SNFull_TextChanged(sender As Object, e As PreviewKeyDownEventArgs) Handles tb_SNFull.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            Dim r As New System.Text.RegularExpressions.Regex("0?346-[A-Z]\d{1,4}")

            If r.Match(tb_SNFull.Text).Success Then
                Dim j = ""
                tb_SNFull.BackColor = Color.LightGreen
                GetMac(tb_SNFull.Text)
            Else
                tb_SNFull.BackColor = Color.Red
                tb_MAC_Full.Text = ""
                tb_MAC_Full.BackColor = Color.White
            End If
            tb_SNFull.Refresh()

        Else
            'keep taking inputs

        End If

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        LoadMacList()
        GetMac(tb_SNFull.Text)
    End Sub
End Class











'Print Function ***********************************************************************************************
'Print Function ***********************************************************************************************
'Print Function ***********************************************************************************************
'Print Function ***********************************************************************************************
'Print Function ***********************************************************************************************
Public Class Form1

    Inherits System.Windows.Forms.Form
    Private WithEvents printButton As System.Windows.Forms.Button
    Private printFont As Font
    Private streamToPrint As StreamReader

    Public Sub New()
        ' The Windows Forms Designer requires the following call.
        InitializeComponent()
        InitializeForm()
    End Sub


    ' The Click event is raised when the user clicks the Print button. 
    Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printButton.Click
        Try
            If file_name <> "" Then
                If print_only_once = False Then
                    streamToPrint = New StreamReader(file_name)
                    Try
                        printFont = New Font("Arial", 10)
                        Dim pd As New PrintDocument()
                        AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                        pd.Print()
                        print_only_once = True
                    Finally
                        streamToPrint.Close()
                    End Try
                End If
            Else
                MsgBox("No Test File to Print!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If print_only_once = True Then
            Me.Close()
        End If
    End Sub

    ' The PrintPage event is raised for each page to be printed. 
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Print each line of the file. 
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page. 
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If

    End Sub

    Private Sub InitializeForm()
        Me.components = New System.ComponentModel.Container()
        Me.printButton = New System.Windows.Forms.Button()

        Me.ClientSize = New System.Drawing.Size(300, 100)
        Me.Text = "Print"

        printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        printButton.BackColor = Color.Beige
        printButton.Location = New System.Drawing.Point(25, 40)
        printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        printButton.TabIndex = 0
        printButton.Text = "Print " & file_name
        printButton.Size = New System.Drawing.Size(250, 40)
        AddHandler printButton.Click, AddressOf printButton_Click

        Me.Controls.Add(printButton)
    End Sub


    ' This is the main entry point for the application.     
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    'Print Function ***********************************************************************************************
    'Print Function ***********************************************************************************************
    'Print Function ***********************************************************************************************
    'Print Function ***********************************************************************************************
    'Print Function ***********************************************************************************************
End Class


