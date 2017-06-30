Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMenu
    Inherits System.Windows.Forms.Form

    Dim txtParm As String
    Friend WithEvents txtPrint As System.Windows.Forms.TextBox
    Dim txtDis As String


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC Inventories - Gross Value", 21, 21)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Accounts Payable", 21, 21)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Month-End - Opening and Closing Inventory ", 21, 21)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Head Office - Sales and Bookings statistics ", 21, 21)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update RMS / PO Unit Price", 21, 21)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC - Automatic Invoice Integration into M3", 21, 21)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Accounting", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain Employee Table", 21, 21)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Master Part Cross Reference Module", 21, 21)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Test Quote", 21, 21)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC Automatic Invoice Transfer", 21, 21)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administrative Tools", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain Customer Data", 21, 21)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers List", 4, 4)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Order Entry", 21, 21)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("DOs & COs  -  Automatically Integration into LAC system", 21, 21)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Head Office - Sales and Bookings statistics ", 21, 21)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders - (BackLog & Orders Entry Analyze)", 21, 21)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Budget - Booking per Customer", 21, 21)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MPO - Generate Mpo Number From Customer Order", 21, 21)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MPO - ReAssign Delivery Date to MPOs (split)", 21, 21)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("By Order Date  --  Detail", 4, 4)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Booking Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode24, TreeNode25})
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Orders LIST", 4, 4)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detail", 4, 4)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date And MPO Number", 4, 4)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Part Number", 4, 4)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Customer Part Number Delivery Date & Production Status" & _
        "", 4, 4)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forecast Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode30, TreeNode31, TreeNode32, TreeNode33})
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode26, TreeNode27, TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Orders", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode35})
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Part Master List", 21, 21)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Requirements Planning  and Release to Production (MPO No.)", 21, 21)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Analyze (RM Inventory & RM Purchasing)", 21, 21)
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MPO Planed Split", 21, 21)
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Material - Master Form", 21, 21)
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Part Number - Master Form", 21, 21)
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Specifications List", 21, 21)
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cost Estimation", 21, 21)
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Approved Mill Producer List", 21, 21)
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain Dwg Source Name", 21, 21)
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain Process Finish Type", 21, 21)
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Technical Notes for Purchasing", 21, 21)
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Part Number Revision (Family of Parts)", 21, 21)
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Index P/N Blank ", 21, 21)
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Dia P/N Blank ", 21, 21)
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data Maintenance", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode46, TreeNode47, TreeNode48, TreeNode49, TreeNode50, TreeNode51})
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Part Master List  (Link With MPO Part Number)", 4, 4)
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Material Lot List (Link with MPO)", 4, 4)
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List -- With Inspection Results", 4, 4)
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode53, TreeNode54, TreeNode55})
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Engineering", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode37, TreeNode38, TreeNode39, TreeNode40, TreeNode41, TreeNode42, TreeNode43, TreeNode44, TreeNode52, TreeNode56})
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts inventory - Adjustments", 21, 21)
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts inventory  -  Release From Finish Parts Inventory To Production", 21, 21)
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Material Lot Number - Adjustments", 21, 21)
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Material Lot Number - Price Depreciation", 21, 21)
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lisi Receiving", 21, 21)
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Packing Slip / Certificate of Conformance", 21, 21)
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Expedition / Reception", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode58, TreeNode59, TreeNode60, TreeNode61, TreeNode62, TreeNode63})
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory  vs. Customer Contracts / Orders", 4, 4)
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory  vs. Customer Contracts / Orders", 4, 4)
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Analyzing Inventory vs. Customer Contracts / Orders", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode65, TreeNode66})
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Indicator of Feasibility - Total cycle per article", 4, 4)
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supplier Performance Measurement", 4, 4)
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Indicators", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode68, TreeNode69})
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Analyzing - Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode67, TreeNode70})
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("By Order Date  --  Detail", 4, 4)
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Booking Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode72, TreeNode73})
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("(1) Other Customers - Forward Forecast Report By Customer Part Number Delivery Da" & _
        "te & Production Status", 4, 4)
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("(2) LNA                    - Forward Forecast Report By Part Number Delivery Date" & _
        " & Production Status", 4, 4)
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date & Production Status", 4, 4)
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Part Number", 4, 4)
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detail", 4, 4)
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode79, TreeNode80})
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode75, TreeNode76, TreeNode77, TreeNode78, TreeNode81})
        Dim TreeNode83 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts   -   INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode84 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts   -   Stock Location", 4, 4)
        Dim TreeNode85 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Semi Finish Parts  (Blanks)  -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode86 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode83, TreeNode84, TreeNode85})
        Dim TreeNode87 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC Finish Parts  -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode88 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LNA Transferd Stock  -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode89 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Semi Finish Parts (Blanks)  -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode90 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Release", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode87, TreeNode88, TreeNode89})
        Dim TreeNode91 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts   -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode92 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Semi Finish Parts   -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode93 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Adjustment", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode91, TreeNode92})
        Dim TreeNode94 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List", 4, 4)
        Dim TreeNode95 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Semi  Finish Parts  Inventory List", 4, 4)
        Dim TreeNode96 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory List", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode94, TreeNode95})
        Dim TreeNode97 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Finish & Semi-Finish Parts", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode86, TreeNode90, TreeNode93, TreeNode96})
        Dim TreeNode98 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Receiving  -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode99 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Release -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode100 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Adjustment -  INVENTORY  CHANGE  ACTIVITY", 4, 4)
        Dim TreeNode101 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List", 4, 4)
        Dim TreeNode102 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List (KSI/SPECIFICATIONS/ENTRY YEAR)", 4, 4)
        Dim TreeNode103 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List -- With Inspection Results", 4, 4)
        Dim TreeNode104 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Receiving  By Period", 4, 4)
        Dim TreeNode105 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Release  By Period", 4, 4)
        Dim TreeNode106 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Summary Activity", 4, 4)
        Dim TreeNode107 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Raw Material", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode98, TreeNode99, TreeNode100, TreeNode101, TreeNode102, TreeNode103, TreeNode104, TreeNode105, TreeNode106})
        Dim TreeNode108 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by Entry Date)", 4, 4)
        Dim TreeNode109 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List By Customer (Order by Entry Date)", 4, 4)
        Dim TreeNode110 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by Quantity Stock)", 4, 4)
        Dim TreeNode111 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by Value Stock)", 4, 4)
        Dim TreeNode112 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by Stock Location)", 4, 4)
        Dim TreeNode113 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by MPO Delivery Date)", 4, 4)
        Dim TreeNode114 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List (Order by Part Number)", 4, 4)
        Dim TreeNode115 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode108, TreeNode109, TreeNode110, TreeNode111, TreeNode112, TreeNode113, TreeNode114})
        Dim TreeNode116 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List (Order by Entry Date)", 4, 4)
        Dim TreeNode117 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List (Order by Quantity Stock)", 4, 4)
        Dim TreeNode118 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List (Order by Value Stock)", 4, 4)
        Dim TreeNode119 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode116, TreeNode117, TreeNode118})
        Dim TreeNode120 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WIP Detail  (Order By Start Mpo Date)", 4, 4)
        Dim TreeNode121 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WIP Detail  By Customer (Order By Start Mpo Date)", 4, 4)
        Dim TreeNode122 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WIP Detail  (Order By Actual Quantity)", 4, 4)
        Dim TreeNode123 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WIP Detail  (Order By MPO WIP Value)", 4, 4)
        Dim TreeNode124 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("W.I.P.", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode120, TreeNode121, TreeNode122, TreeNode123})
        Dim TreeNode125 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC Inventory Check Lists", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode115, TreeNode119, TreeNode124})
        Dim TreeNode126 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices grouped by Customer - Summary", 4, 4)
        Dim TreeNode127 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices grouped by Customer", 4, 4)
        Dim TreeNode128 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices ordered by Invoice Number", 4, 4)
        Dim TreeNode129 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices Grouped by Customer (YTD - Summary)", 4, 4)
        Dim TreeNode130 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Opened or Cancelled Sale Orders", 4, 4)
        Dim TreeNode131 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lisi Invoices Lists", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode126, TreeNode127, TreeNode128, TreeNode129, TreeNode130})
        Dim TreeNode132 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Parts List from Blanks", 4, 4)
        Dim TreeNode133 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bar Code Production Activity by Employee (Date - 24Hrs)", 4, 4)
        Dim TreeNode134 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bar Code Production Activity by MPO", 4, 4)
        Dim TreeNode135 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bar Code Production  --  MBO Value (Date - 24Hrs)", 4, 4)
        Dim TreeNode136 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bar Code", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode133, TreeNode134, TreeNode135})
        Dim TreeNode137 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Machine(s) Utilization - Periode & Percentage", 4, 4)
        Dim TreeNode138 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MPOs List- Quantity Manually Changed", 4, 4)
        Dim TreeNode139 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Production Control Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode136, TreeNode137, TreeNode138})
        Dim TreeNode140 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("(1) Production List By MPO Delivery Date ", 4, 4)
        Dim TreeNode141 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control By Department  --  Daily Production List", 4, 4)
        Dim TreeNode142 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control By Department (Qty & Value)  --  Detail ", 4, 4)
        Dim TreeNode143 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control By Department  --  Summary", 4, 4)
        Dim TreeNode144 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode140, TreeNode141, TreeNode142, TreeNode143})
        Dim TreeNode145 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode146 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detail", 4, 4)
        Dim TreeNode147 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Work-In-Process", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode145, TreeNode146})
        Dim TreeNode148 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lisi  Reports", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode71, TreeNode74, TreeNode82, TreeNode97, TreeNode107, TreeNode125, TreeNode131, TreeNode132, TreeNode139, TreeNode144, TreeNode147})
        Dim TreeNode149 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Machinery and Equipment Module", 21, 21)
        Dim TreeNode150 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(" Machinery and Equipment Info", 21, 21)
        Dim TreeNode151 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Task Info", 21, 21)
        Dim TreeNode152 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Product / Component Name", 21, 21)
        Dim TreeNode153 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data Maintenance", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode150, TreeNode151, TreeNode152})
        Dim TreeNode154 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintenance", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode149, TreeNode153})
        Dim TreeNode155 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving Acceptance- Perishable Products", 21, 21)
        Dim TreeNode156 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Release To Production -  Perishable Products", 21, 21)
        Dim TreeNode157 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving", 4, 4)
        Dim TreeNode158 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Release", 4, 4)
        Dim TreeNode159 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Perishable - Inventory List", 4, 4)
        Dim TreeNode160 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode157, TreeNode158, TreeNode159})
        Dim TreeNode161 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Perishable Inventory Control", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode155, TreeNode156, TreeNode160})
        Dim TreeNode162 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MPO Cost Analyze", 21, 21)
        Dim TreeNode163 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Work-In-Process -- MFG Cost", 4, 4)
        Dim TreeNode164 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Invoices List -- Gross Profit", 4, 4)
        Dim TreeNode165 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Invoices List by Customer -- Gross Profit", 4, 4)
        Dim TreeNode166 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish  Part Inventory  List --  MFG Cost ", 4, 4)
        Dim TreeNode167 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish  Part Inventory  List - LAC LOTS - Stock Price", 4, 4)
        Dim TreeNode168 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish  Part Inventory  List - LAC LOTS - Standard Price", 4, 4)
        Dim TreeNode169 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish  Part Inventory  List - LNA Transferred LOTS", 4, 4)
        Dim TreeNode170 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Depreciation Estimates - Finish  Part Inventory  List - LNA Transferred LOTS", 4, 4)
        Dim TreeNode171 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Semi Finish  Part Inventory  List", 4, 4)
        Dim TreeNode172 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Inventory List", 4, 4)
        Dim TreeNode173 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC -  Sales Statistics", 21, 21)
        Dim TreeNode174 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock Valuation (M3 - Method)", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode167, TreeNode168, TreeNode169, TreeNode170, TreeNode171, TreeNode172, TreeNode173})
        Dim TreeNode175 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Analyzing Cost", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode163, TreeNode164, TreeNode165, TreeNode166, TreeNode174})
        Dim TreeNode176 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices Grouped by Customer (YTD - Summary)", 4, 4)
        Dim TreeNode177 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices grouped by Customer - Summary", 4, 4)
        Dim TreeNode178 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices ordered by Invoice Number", 4, 4)
        Dim TreeNode179 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lisi Invoices Lists", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode176, TreeNode177, TreeNode178})
        Dim TreeNode180 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("By Order Date  --  Detail", 4, 4)
        Dim TreeNode181 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode182 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Booking Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode180, TreeNode181})
        Dim TreeNode183 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Orders LIST", 4, 4)
        Dim TreeNode184 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Orders", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode183})
        Dim TreeNode185 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date And MPO Number", 4, 4)
        Dim TreeNode186 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Part Number", 4, 4)
        Dim TreeNode187 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detail", 4, 4)
        Dim TreeNode188 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode189 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Delivery Date", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode187, TreeNode188})
        Dim TreeNode190 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forward Forecast Report By Customer Part Number Delivery Date & Production Status" & _
        "", 4, 4)
        Dim TreeNode191 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(" Forecast Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode185, TreeNode186, TreeNode189, TreeNode190})
        Dim TreeNode192 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts  Inventory List", 4, 4)
        Dim TreeNode193 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Finish Parts", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode192})
        Dim TreeNode194 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List", 4, 4)
        Dim TreeNode195 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material  Inventory List -- With Inspection Results", 4, 4)
        Dim TreeNode196 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Raw Material", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode194, TreeNode195})
        Dim TreeNode197 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary", 4, 4)
        Dim TreeNode198 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detail", 4, 4)
        Dim TreeNode199 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Work-In-Process", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode197, TreeNode198})
        Dim TreeNode200 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control By Department (Qty & Value)  --  Summary", 4, 4)
        Dim TreeNode201 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control By Department (Qty & Value)  --  Detail ", 4, 4)
        Dim TreeNode202 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode200, TreeNode201})
        Dim TreeNode203 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode175, TreeNode179, TreeNode182, TreeNode184, TreeNode191, TreeNode193, TreeNode196, TreeNode199, TreeNode202})
        Dim TreeNode204 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Management ", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode162, TreeNode203})
        Dim TreeNode205 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Blanks Requirements Planning  and Release to Production (MPO No.)", 21, 21)
        Dim TreeNode206 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Requirements Planning  and Release to Production (MPO No.)", 21, 21)
        Dim TreeNode207 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Analyze (RM Inventory & RM Purchasing)", 21, 21)
        Dim TreeNode208 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shop Floor Control ", 21, 21)
        Dim TreeNode209 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customized Production Queries", 21, 21)
        Dim TreeNode210 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bar Code Production Queries", 21, 21)
        Dim TreeNode211 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Add Comments in Raw Material Inventory", 21, 21)
        Dim TreeNode212 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Part Master (Short Form)", 21, 21)
        Dim TreeNode213 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tool Box", 21, 21)
        Dim TreeNode214 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("P/N - First Time Release to Production", 21, 21)
        Dim TreeNode215 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("1. Min/Max Daily - Integrate", 21, 21)
        Dim TreeNode216 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LNA - Extract Data from MRP By P/N", 21, 21)
        Dim TreeNode217 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Min/Max Procedures", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode215, TreeNode216})
        Dim TreeNode218 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planning And Production Control ", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode205, TreeNode206, TreeNode207, TreeNode208, TreeNode209, TreeNode210, TreeNode211, TreeNode212, TreeNode213, TreeNode214, TreeNode217})
        Dim TreeNode219 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchasing", 21, 21)
        Dim TreeNode220 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Technical Notes for Purchasing", 21, 21)
        Dim TreeNode221 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Subcontracting - Analyze Module", 21, 21)
        Dim TreeNode222 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("POs Data Extraction", 21, 21)
        Dim TreeNode223 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchasing Information List", 4, 4)
        Dim TreeNode224 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (Price Correction - Less 0.02$)", 4, 4)
        Dim TreeNode225 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (By Supplier)", 4, 4)
        Dim TreeNode226 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (By PO Type and Periode)", 4, 4)
        Dim TreeNode227 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (By GL Account Number)", 4, 4)
        Dim TreeNode228 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (By Supplier / GL Account Number) - Summary", 4, 4)
        Dim TreeNode229 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchase Order List (By GL Account Number / Supplier) - By PO Due Date", 4, 4)
        Dim TreeNode230 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Incoming Receiving PO - (By Supplier)", 4, 4)
        Dim TreeNode231 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Processing & Sub-Contracting List", 4, 4)
        Dim TreeNode232 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PO Received and not Invoiced", 4, 4)
        Dim TreeNode233 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode223, TreeNode224, TreeNode225, TreeNode226, TreeNode227, TreeNode228, TreeNode229, TreeNode230, TreeNode231, TreeNode232})
        Dim TreeNode234 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchasing Control", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode219, TreeNode220, TreeNode221, TreeNode222, TreeNode233})
        Dim TreeNode235 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quotation", 21, 21)
        Dim TreeNode236 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quote Analyze Form", 21, 21)
        Dim TreeNode237 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quote Analyze Form - M3", 21, 21)
        Dim TreeNode238 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Status (Cost estimation)", 21, 21)
        Dim TreeNode239 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quote List per Customers", 4, 4)
        Dim TreeNode240 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quote List per Part Number", 4, 4)
        Dim TreeNode241 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Parts Count per Customer - YTD", 4, 4)
        Dim TreeNode242 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode239, TreeNode240, TreeNode241})
        Dim TreeNode243 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Request For Quotation", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode235, TreeNode236, TreeNode237, TreeNode238, TreeNode242})
        Dim TreeNode244 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inspection Requirements List", 21, 21)
        Dim TreeNode245 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Stock Location", 21, 21)
        Dim TreeNode246 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data Maintenance ", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode244, TreeNode245})
        Dim TreeNode247 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Final Inspection (Closing Mpo No.)", 21, 21)
        Dim TreeNode248 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Adjustments -- Raw Material & Mpo ", 21, 21)
        Dim TreeNode249 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving Inspection - Raw Material", 21, 21)
        Dim TreeNode250 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving Inspection - Processing, Sub-Contracting, Tolling, Calibration, Other", 21, 21)
        Dim TreeNode251 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Unplaned Mpo Splits", 21, 21)
        Dim TreeNode252 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Raw Material Inspection And Release", 4, 4)
        Dim TreeNode253 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode252})
        Dim TreeNode254 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quality Control Lab Inspection", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode246, TreeNode247, TreeNode248, TreeNode249, TreeNode250, TreeNode251, TreeNode253})
        Dim TreeNode255 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admin Module", 21, 21)
        Dim TreeNode256 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Read Only Module", 21, 21)
        Dim TreeNode257 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admin Documents", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode255, TreeNode256})
        Dim TreeNode258 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quality Control Documents", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode257})
        Dim TreeNode259 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admin Module", 21, 21)
        Dim TreeNode260 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Read Only Module", 21, 21)
        Dim TreeNode261 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admin Documents", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode259, TreeNode260})
        Dim TreeNode262 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HSE Control Documents", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode261})
        Dim TreeNode263 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Invoice Form", 21, 21)
        Dim TreeNode264 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Delivery Quantity Request", 21, 21)
        Dim TreeNode265 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Delivery Cancel Request", 21, 21)
        Dim TreeNode266 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Finish Parts - Price Adjustment", 21, 21)
        Dim TreeNode267 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Part Master (Short Form)", 21, 21)
        Dim TreeNode268 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices grouped by Customer", 4, 4)
        Dim TreeNode269 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lists Invoices ordered by Invoice Number", 4, 4)
        Dim TreeNode270 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lisi Invoices Lists", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode268, TreeNode269})
        Dim TreeNode271 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode270})
        Dim TreeNode272 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode263, TreeNode264, TreeNode265, TreeNode266, TreeNode267, TreeNode271})
        Dim TreeNode273 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Forecast", 21, 21)
        Dim TreeNode274 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forecast By Item", 21, 21)
        Dim TreeNode275 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forecast List By Customer and Part Number", 4, 4)
        Dim TreeNode276 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Forecast List By Customer and Part Number (By Delivery Date)", 4, 4)
        Dim TreeNode277 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode275, TreeNode276})
        Dim TreeNode278 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Forecast & Planning", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode273, TreeNode274, TreeNode277})
        Dim TreeNode279 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain Supplier Data", 21, 21)
        Dim TreeNode280 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Approved Supplier List", 4, 4)
        Dim TreeNode281 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sub-Contractors  Check  List  ", 4, 4)
        Dim TreeNode282 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode280, TreeNode281})
        Dim TreeNode283 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supplier", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode279, TreeNode282})
        Dim TreeNode284 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintain LAC Employee data", 21, 21)
        Dim TreeNode285 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PayRoll Data Collect", 18, 19, New System.Windows.Forms.TreeNode() {TreeNode284})
        Dim TreeNode286 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC - Quality Indicators", 21, 21)
        Dim TreeNode287 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC - Memo Module", 21, 21)
        Dim TreeNode288 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LAC - Request for Material", 21, 21)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.txtPrint = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 21
        TreeNode1.Name = "frmAccUploadCorpData"
        TreeNode1.SelectedImageIndex = 21
        TreeNode1.Text = "LAC Inventories - Gross Value"
        TreeNode2.ImageIndex = 21
        TreeNode2.Name = "frmAccPayable"
        TreeNode2.SelectedImageIndex = 21
        TreeNode2.Text = "Accounts Payable"
        TreeNode3.ImageIndex = 21
        TreeNode3.Name = "frmCloseMonth"
        TreeNode3.SelectedImageIndex = 21
        TreeNode3.Text = "Month-End - Opening and Closing Inventory "
        TreeNode4.ImageIndex = 21
        TreeNode4.Name = "frmAccHeadOfficeStatistics"
        TreeNode4.SelectedImageIndex = 21
        TreeNode4.Text = "Head Office - Sales and Bookings statistics "
        TreeNode5.ImageIndex = 21
        TreeNode5.Name = "frmAccAddRMSPrice"
        TreeNode5.SelectedImageIndex = 21
        TreeNode5.Text = "Update RMS / PO Unit Price"
        TreeNode6.ImageIndex = 21
        TreeNode6.Name = "frmAccUploadInvoicesintoM3"
        TreeNode6.SelectedImageIndex = 21
        TreeNode6.Text = "LAC - Automatic Invoice Integration into M3"
        TreeNode7.ImageIndex = 18
        TreeNode7.Name = "Acc"
        TreeNode7.SelectedImageIndex = 19
        TreeNode7.Text = "Accounting"
        TreeNode8.ImageIndex = 21
        TreeNode8.Name = "ViewEmployee"
        TreeNode8.SelectedImageIndex = 21
        TreeNode8.Text = "Maintain Employee Table"
        TreeNode9.ImageIndex = 21
        TreeNode9.Name = "frmPartCreateCrossRef"
        TreeNode9.SelectedImageIndex = 21
        TreeNode9.Text = "Master Part Cross Reference Module"
        TreeNode10.ImageIndex = 21
        TreeNode10.Name = "frmStQuote"
        TreeNode10.SelectedImageIndex = 21
        TreeNode10.Text = "Test Quote"
        TreeNode11.ImageIndex = 21
        TreeNode11.Name = "frmAccInterCoInvoices"
        TreeNode11.SelectedImageIndex = 21
        TreeNode11.Text = "LAC Automatic Invoice Transfer"
        TreeNode12.ImageIndex = 18
        TreeNode12.Name = "Admin"
        TreeNode12.SelectedImageIndex = 19
        TreeNode12.Text = "Administrative Tools"
        TreeNode13.ImageIndex = 21
        TreeNode13.Name = "frmCustomer"
        TreeNode13.SelectedImageIndex = 21
        TreeNode13.Text = "Maintain Customer Data"
        TreeNode14.ImageIndex = 4
        TreeNode14.Name = "rptCustomerList"
        TreeNode14.SelectedImageIndex = 4
        TreeNode14.Text = "Customers List"
        TreeNode15.ImageIndex = 4
        TreeNode15.Name = ""
        TreeNode15.SelectedImageIndex = 4
        TreeNode15.Text = "Reports"
        TreeNode16.ImageIndex = 18
        TreeNode16.Name = "Cust"
        TreeNode16.SelectedImageIndex = 19
        TreeNode16.Text = "Customer"
        TreeNode17.ImageIndex = 21
        TreeNode17.Name = "frmOrderEntry"
        TreeNode17.SelectedImageIndex = 21
        TreeNode17.Text = "Order Entry"
        TreeNode18.ImageIndex = 21
        TreeNode18.Name = "frmOrderEntryM3CODO"
        TreeNode18.SelectedImageIndex = 21
        TreeNode18.Text = "DOs & COs  -  Automatically Integration into LAC system"
        TreeNode19.ImageIndex = 21
        TreeNode19.Name = "frmAccHeadOfficeStatistics"
        TreeNode19.SelectedImageIndex = 21
        TreeNode19.Text = "Head Office - Sales and Bookings statistics "
        TreeNode20.ImageIndex = 21
        TreeNode20.Name = "frmBackLogAnalyze"
        TreeNode20.SelectedImageIndex = 21
        TreeNode20.Text = "Orders - (BackLog & Orders Entry Analyze)"
        TreeNode21.ImageIndex = 21
        TreeNode21.Name = "frmCustUpdateBudget"
        TreeNode21.SelectedImageIndex = 21
        TreeNode21.Text = "Budget - Booking per Customer"
        TreeNode22.ImageIndex = 21
        TreeNode22.Name = "frmMPOGenfromOrder"
        TreeNode22.SelectedImageIndex = 21
        TreeNode22.Text = "MPO - Generate Mpo Number From Customer Order"
        TreeNode23.ImageIndex = 21
        TreeNode23.Name = "frmOrderAssignDellivToMPO"
        TreeNode23.SelectedImageIndex = 21
        TreeNode23.Text = "MPO - ReAssign Delivery Date to MPOs (split)"
        TreeNode24.ImageIndex = 4
        TreeNode24.Name = "rptCustOrderActiveBookingByOderDate"
        TreeNode24.SelectedImageIndex = 4
        TreeNode24.Text = "By Order Date  --  Detail"
        TreeNode25.ImageIndex = 4
        TreeNode25.Name = "rptCustOrderActiveBookingByOderDateSummary"
        TreeNode25.SelectedImageIndex = 4
        TreeNode25.Text = "Summary"
        TreeNode26.ImageIndex = 4
        TreeNode26.Name = "Node1"
        TreeNode26.SelectedImageIndex = 4
        TreeNode26.Text = "Booking Reports"
        TreeNode27.ImageIndex = 4
        TreeNode27.Name = "rptCustOrderActive"
        TreeNode27.SelectedImageIndex = 4
        TreeNode27.Text = "Customer Orders LIST"
        TreeNode28.ImageIndex = 4
        TreeNode28.Name = "rptCustOrderActiveForecastByDelDate"
        TreeNode28.SelectedImageIndex = 4
        TreeNode28.Text = "Detail"
        TreeNode29.ImageIndex = 4
        TreeNode29.Name = "rptCustOrderActiveForecastByDelDateSummary"
        TreeNode29.SelectedImageIndex = 4
        TreeNode29.Text = "Summary"
        TreeNode30.ImageIndex = 4
        TreeNode30.Name = "Node4"
        TreeNode30.SelectedImageIndex = 4
        TreeNode30.Text = "Forward Forecast Report By Delivery Date"
        TreeNode31.ImageIndex = 4
        TreeNode31.Name = "rptCustOrderActiveForecastByDelDateAndPartNo"
        TreeNode31.SelectedImageIndex = 4
        TreeNode31.Text = "Forward Forecast Report By Delivery Date And MPO Number"
        TreeNode32.ImageIndex = 4
        TreeNode32.Name = "rptCustOrderActiveForecastByPartNoMpoNo"
        TreeNode32.SelectedImageIndex = 4
        TreeNode32.Text = "Forward Forecast Report By Part Number"
        TreeNode33.ImageIndex = 4
        TreeNode33.Name = "rptCustOrderActiveForecastByPartAndDelDateProduction"
        TreeNode33.SelectedImageIndex = 4
        TreeNode33.Text = "Forward Forecast Report By Customer Part Number Delivery Date & Production Status" & _
    ""
        TreeNode34.ImageIndex = 4
        TreeNode34.Name = "Node0"
        TreeNode34.SelectedImageIndex = 4
        TreeNode34.Text = "Forecast Reports"
        TreeNode35.ImageIndex = 4
        TreeNode35.Name = "OrdRep"
        TreeNode35.SelectedImageIndex = 4
        TreeNode35.Text = "Reports"
        TreeNode36.ImageIndex = 18
        TreeNode36.Name = "CustOrd"
        TreeNode36.SelectedImageIndex = 19
        TreeNode36.Text = "Customer Orders"
        TreeNode37.ImageIndex = 21
        TreeNode37.Name = "frmEngPartMasterList"
        TreeNode37.SelectedImageIndex = 21
        TreeNode37.Text = "Part Master List"
        TreeNode38.ImageIndex = 21
        TreeNode38.Name = "frmReleaseRawMaterial"
        TreeNode38.SelectedImageIndex = 21
        TreeNode38.Text = "Raw Material Requirements Planning  and Release to Production (MPO No.)"
        TreeNode39.ImageIndex = 21
        TreeNode39.Name = "frmRawMaterialAnalyze"
        TreeNode39.SelectedImageIndex = 21
        TreeNode39.Text = "Raw Material Analyze (RM Inventory & RM Purchasing)"
        TreeNode40.ImageIndex = 21
        TreeNode40.Name = "frmEngMPOPlanedSplit"
        TreeNode40.SelectedImageIndex = 21
        TreeNode40.Text = "MPO Planed Split"
        TreeNode41.ImageIndex = 21
        TreeNode41.Name = "frmEngMatlType"
        TreeNode41.SelectedImageIndex = 21
        TreeNode41.Text = "Material - Master Form"
        TreeNode42.ImageIndex = 21
        TreeNode42.Name = "frmPartMaster"
        TreeNode42.SelectedImageIndex = 21
        TreeNode42.Text = "Part Number - Master Form"
        TreeNode43.ImageIndex = 21
        TreeNode43.Name = "frmEngSpecList"
        TreeNode43.SelectedImageIndex = 21
        TreeNode43.Text = "Specifications List"
        TreeNode44.ImageIndex = 21
        TreeNode44.Name = "frmCostEstimation"
        TreeNode44.SelectedImageIndex = 21
        TreeNode44.Text = "Cost Estimation"
        TreeNode45.ImageIndex = 21
        TreeNode45.Name = "frmEngApprMillList"
        TreeNode45.SelectedImageIndex = 21
        TreeNode45.Text = "Approved Mill Producer List"
        TreeNode46.ImageIndex = 21
        TreeNode46.Name = "frmEngDWGSourceName"
        TreeNode46.SelectedImageIndex = 21
        TreeNode46.Text = "Maintain Dwg Source Name"
        TreeNode47.ImageIndex = 21
        TreeNode47.Name = "frmEngFinishSourceList"
        TreeNode47.SelectedImageIndex = 21
        TreeNode47.Text = "Maintain Process Finish Type"
        TreeNode48.ImageIndex = 21
        TreeNode48.Name = "frmEngRemarks"
        TreeNode48.SelectedImageIndex = 21
        TreeNode48.Text = "Technical Notes for Purchasing"
        TreeNode49.ImageIndex = 21
        TreeNode49.Name = "frmEngUpdateRev"
        TreeNode49.SelectedImageIndex = 21
        TreeNode49.Text = "Update Part Number Revision (Family of Parts)"
        TreeNode50.ImageIndex = 21
        TreeNode50.Name = "frmEngBlankIndex"
        TreeNode50.SelectedImageIndex = 21
        TreeNode50.Text = "Update Index P/N Blank "
        TreeNode51.ImageIndex = 21
        TreeNode51.Name = "frmEngBlankDia"
        TreeNode51.SelectedImageIndex = 21
        TreeNode51.Text = "Update Dia P/N Blank "
        TreeNode52.ImageIndex = 18
        TreeNode52.Name = "EngMaint"
        TreeNode52.SelectedImageIndex = 19
        TreeNode52.Text = "Data Maintenance"
        TreeNode53.ImageIndex = 4
        TreeNode53.Name = "rptPartMasterListMpoLink"
        TreeNode53.SelectedImageIndex = 4
        TreeNode53.Text = "Part Master List  (Link With MPO Part Number)"
        TreeNode54.ImageIndex = 4
        TreeNode54.Name = "rptMPOMatlLotNo"
        TreeNode54.SelectedImageIndex = 4
        TreeNode54.Text = "Material Lot List (Link with MPO)"
        TreeNode55.ImageIndex = 4
        TreeNode55.Name = "rptInvRawMaterialKSI"
        TreeNode55.SelectedImageIndex = 4
        TreeNode55.Text = "Raw Material  Inventory List -- With Inspection Results"
        TreeNode56.ImageIndex = 4
        TreeNode56.Name = "Node4"
        TreeNode56.SelectedImageIndex = 4
        TreeNode56.Text = "Reports"
        TreeNode57.ImageIndex = 18
        TreeNode57.Name = "Eng"
        TreeNode57.SelectedImageIndex = 19
        TreeNode57.Text = "Engineering"
        TreeNode58.ImageIndex = 21
        TreeNode58.Name = "frmFPAdj"
        TreeNode58.SelectedImageIndex = 21
        TreeNode58.Text = "Finish Parts inventory - Adjustments"
        TreeNode59.ImageIndex = 21
        TreeNode59.Name = "frmFPReleaseToMPO"
        TreeNode59.SelectedImageIndex = 21
        TreeNode59.Text = "Finish Parts inventory  -  Release From Finish Parts Inventory To Production"
        TreeNode60.ImageIndex = 21
        TreeNode60.Name = "frmMatlLotAdj"
        TreeNode60.SelectedImageIndex = 21
        TreeNode60.Text = "Material Lot Number - Adjustments"
        TreeNode61.ImageIndex = 21
        TreeNode61.Name = "frmMatlPriceDepreciation"
        TreeNode61.SelectedImageIndex = 21
        TreeNode61.Text = "Material Lot Number - Price Depreciation"
        TreeNode62.ImageIndex = 21
        TreeNode62.Name = "frmPOReceiving"
        TreeNode62.SelectedImageIndex = 21
        TreeNode62.Text = "Lisi Receiving"
        TreeNode63.ImageIndex = 21
        TreeNode63.Name = "frmSalesPSlip"
        TreeNode63.SelectedImageIndex = 21
        TreeNode63.Text = "Packing Slip / Certificate of Conformance"
        TreeNode64.ImageIndex = 18
        TreeNode64.Name = "Exp"
        TreeNode64.SelectedImageIndex = 19
        TreeNode64.Text = "Expedition / Reception"
        TreeNode65.ImageIndex = 4
        TreeNode65.Name = "rptFPInventoryListGroupByPartNo"
        TreeNode65.SelectedImageIndex = 4
        TreeNode65.Text = "Finish Parts  Inventory  vs. Customer Contracts / Orders"
        TreeNode66.ImageIndex = 4
        TreeNode66.Name = "rptRawMatlToContractAllWIPProdandEng"
        TreeNode66.SelectedImageIndex = 4
        TreeNode66.Text = "Raw Material  Inventory  vs. Customer Contracts / Orders"
        TreeNode67.ImageIndex = 4
        TreeNode67.Name = "Node4"
        TreeNode67.SelectedImageIndex = 4
        TreeNode67.Text = "Analyzing Inventory vs. Customer Contracts / Orders"
        TreeNode68.ImageIndex = 4
        TreeNode68.Name = "rptShopArticleTotalCycle"
        TreeNode68.SelectedImageIndex = 4
        TreeNode68.Text = "Indicator of Feasibility - Total cycle per article"
        TreeNode69.ImageIndex = 4
        TreeNode69.Name = "rptSupplierCycleDelivery"
        TreeNode69.SelectedImageIndex = 4
        TreeNode69.Text = "Supplier Performance Measurement"
        TreeNode70.ImageIndex = 4
        TreeNode70.Name = "Node0"
        TreeNode70.SelectedImageIndex = 4
        TreeNode70.Text = "Indicators"
        TreeNode71.ImageIndex = 4
        TreeNode71.Name = "AnalyzingReports"
        TreeNode71.SelectedImageIndex = 4
        TreeNode71.Text = "Analyzing - Reports"
        TreeNode72.ImageIndex = 4
        TreeNode72.Name = "rptCustOrderActiveBookingByOderDate"
        TreeNode72.SelectedImageIndex = 4
        TreeNode72.Text = "By Order Date  --  Detail"
        TreeNode73.ImageIndex = 4
        TreeNode73.Name = "rptCustOrderActiveBookingByOderDateSummary"
        TreeNode73.SelectedImageIndex = 4
        TreeNode73.Text = "Summary"
        TreeNode74.ImageIndex = 4
        TreeNode74.Name = "Booking"
        TreeNode74.SelectedImageIndex = 4
        TreeNode74.Text = "Booking Reports"
        TreeNode75.ImageIndex = 4
        TreeNode75.Name = "rptCustOrderActiveForecastByPartAndDelDateProduction"
        TreeNode75.SelectedImageIndex = 4
        TreeNode75.Text = "(1) Other Customers - Forward Forecast Report By Customer Part Number Delivery Da" & _
    "te & Production Status"
        TreeNode76.ImageIndex = 4
        TreeNode76.Name = "rptCustOrderActiveForecastByPartAndDelDateProduction_LNAOnlyVer2"
        TreeNode76.SelectedImageIndex = 4
        TreeNode76.Text = "(2) LNA                    - Forward Forecast Report By Part Number Delivery Date" & _
    " & Production Status"
        TreeNode77.ImageIndex = 4
        TreeNode77.Name = "rptCustOrderActiveForecastByDelDateAndPartNo"
        TreeNode77.SelectedImageIndex = 4
        TreeNode77.Text = "Forward Forecast Report By Delivery Date & Production Status"
        TreeNode78.ImageIndex = 4
        TreeNode78.Name = "rptCustOrderActiveForecastByPartNoMpoNo"
        TreeNode78.SelectedImageIndex = 4
        TreeNode78.Text = "Forward Forecast Report By Part Number"
        TreeNode79.ImageIndex = 4
        TreeNode79.Name = "rptCustOrderActiveForecastByDelDate"
        TreeNode79.SelectedImageIndex = 4
        TreeNode79.Text = "Detail"
        TreeNode80.ImageIndex = 4
        TreeNode80.Name = "rptCustOrderActiveForecastByDelDateSummary"
        TreeNode80.SelectedImageIndex = 4
        TreeNode80.Text = "Summary"
        TreeNode81.ImageIndex = 4
        TreeNode81.Name = "Node2"
        TreeNode81.SelectedImageIndex = 4
        TreeNode81.Text = "Forward Forecast Report By Delivery Date"
        TreeNode82.ImageIndex = 4
        TreeNode82.Name = "ForwardForecast"
        TreeNode82.SelectedImageIndex = 4
        TreeNode82.Text = "Forward Forecast"
        TreeNode83.ImageIndex = 4
        TreeNode83.Name = "rptFinishPartsRecvTranz"
        TreeNode83.SelectedImageIndex = 4
        TreeNode83.Text = "Finish Parts   -   INVENTORY  CHANGE  ACTIVITY"
        TreeNode84.ImageIndex = 4
        TreeNode84.Name = "rptFinishPartsRecvTranzAll"
        TreeNode84.SelectedImageIndex = 4
        TreeNode84.Text = "Finish Parts   -   Stock Location"
        TreeNode85.ImageIndex = 4
        TreeNode85.Name = "rptFinishPartsRecvBlanksTranz"
        TreeNode85.SelectedImageIndex = 4
        TreeNode85.Text = "Semi Finish Parts  (Blanks)  -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode86.ImageIndex = 4
        TreeNode86.Name = "Node1"
        TreeNode86.SelectedImageIndex = 4
        TreeNode86.Text = "Receiving"
        TreeNode87.ImageIndex = 4
        TreeNode87.Name = "rptFinishPartsReleaseTranz"
        TreeNode87.SelectedImageIndex = 4
        TreeNode87.Text = "LAC Finish Parts  -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode88.ImageIndex = 4
        TreeNode88.Name = "rptFinishPartsReleaseTranz_FromLNA_TransferStock"
        TreeNode88.SelectedImageIndex = 4
        TreeNode88.Text = "LNA Transferd Stock  -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode89.ImageIndex = 4
        TreeNode89.Name = "rptFinishPartsReleaseBlanksTranz"
        TreeNode89.SelectedImageIndex = 4
        TreeNode89.Text = "Semi Finish Parts (Blanks)  -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode90.ImageIndex = 4
        TreeNode90.Name = "Node2"
        TreeNode90.SelectedImageIndex = 4
        TreeNode90.Text = "Release"
        TreeNode91.ImageIndex = 4
        TreeNode91.Name = "rptFinishPartsAdjTranz"
        TreeNode91.SelectedImageIndex = 4
        TreeNode91.Text = "Finish Parts   -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode92.ImageIndex = 4
        TreeNode92.Name = "rptFinishPartsAdjBlanksTranz"
        TreeNode92.SelectedImageIndex = 4
        TreeNode92.Text = "Semi Finish Parts   -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode93.ImageIndex = 4
        TreeNode93.Name = "Node3"
        TreeNode93.SelectedImageIndex = 4
        TreeNode93.Text = "Adjustment"
        TreeNode94.ImageIndex = 4
        TreeNode94.Name = "rptFinishPartsInventoryList"
        TreeNode94.SelectedImageIndex = 4
        TreeNode94.Text = "Finish Parts  Inventory List"
        TreeNode95.ImageIndex = 4
        TreeNode95.Name = "rptFinishPartsBlanksInventoryList"
        TreeNode95.SelectedImageIndex = 4
        TreeNode95.Text = "Semi  Finish Parts  Inventory List"
        TreeNode96.ImageIndex = 4
        TreeNode96.Name = "Node4"
        TreeNode96.SelectedImageIndex = 4
        TreeNode96.Text = "Inventory List"
        TreeNode97.ImageIndex = 4
        TreeNode97.Name = "INVFP"
        TreeNode97.SelectedImageIndex = 4
        TreeNode97.Text = "Inventory Finish & Semi-Finish Parts"
        TreeNode98.ImageIndex = 4
        TreeNode98.Name = "rptRawMatRecvTranz"
        TreeNode98.SelectedImageIndex = 4
        TreeNode98.Text = "Raw Material  Receiving  -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode99.ImageIndex = 4
        TreeNode99.Name = "rptRawMatlRelTranz"
        TreeNode99.SelectedImageIndex = 4
        TreeNode99.Text = "Raw Material  Release -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode100.ImageIndex = 4
        TreeNode100.Name = "rptRawMatlAdjTranz"
        TreeNode100.SelectedImageIndex = 4
        TreeNode100.Text = "Raw Material Adjustment -  INVENTORY  CHANGE  ACTIVITY"
        TreeNode101.ImageIndex = 4
        TreeNode101.Name = "rptInvRawMaterial"
        TreeNode101.SelectedImageIndex = 4
        TreeNode101.Text = "Raw Material  Inventory List"
        TreeNode102.ImageIndex = 4
        TreeNode102.Name = "rptInvRawMaterialByDateandKSI"
        TreeNode102.SelectedImageIndex = 4
        TreeNode102.Text = "Raw Material  Inventory List (KSI/SPECIFICATIONS/ENTRY YEAR)"
        TreeNode103.ImageIndex = 4
        TreeNode103.Name = "rptInvRawMaterialKSI"
        TreeNode103.SelectedImageIndex = 4
        TreeNode103.Text = "Raw Material  Inventory List -- With Inspection Results"
        TreeNode104.ImageIndex = 4
        TreeNode104.Name = "rptRawMatReceivigByPeriode"
        TreeNode104.SelectedImageIndex = 4
        TreeNode104.Text = "Raw Material  Receiving  By Period"
        TreeNode105.ImageIndex = 4
        TreeNode105.Name = "rptRawMatlRelTranzAll"
        TreeNode105.SelectedImageIndex = 4
        TreeNode105.Text = "Raw Material  Release  By Period"
        TreeNode106.ImageIndex = 4
        TreeNode106.Name = "rptRawMatlBRFSummary"
        TreeNode106.SelectedImageIndex = 4
        TreeNode106.Text = "Raw Material  Summary Activity"
        TreeNode107.ImageIndex = 4
        TreeNode107.Name = "Raw"
        TreeNode107.SelectedImageIndex = 4
        TreeNode107.Text = "Inventory Raw Material"
        TreeNode108.ImageIndex = 4
        TreeNode108.Name = "rptFinishPartsInvListOrderByEntryDate"
        TreeNode108.SelectedImageIndex = 4
        TreeNode108.Text = "Finish Parts  Inventory List (Order by Entry Date)"
        TreeNode109.ImageIndex = 4
        TreeNode109.Name = "rptFinishPartsInvListOrderByEntryDateAndCustomer"
        TreeNode109.SelectedImageIndex = 4
        TreeNode109.Text = "Finish Parts  Inventory List By Customer (Order by Entry Date)"
        TreeNode110.ImageIndex = 4
        TreeNode110.Name = "rptFinishPartsInvListOrderByStockQty"
        TreeNode110.SelectedImageIndex = 4
        TreeNode110.Text = "Finish Parts  Inventory List (Order by Quantity Stock)"
        TreeNode111.ImageIndex = 4
        TreeNode111.Name = "rptFinishPartsInvListOrderByStockValue"
        TreeNode111.SelectedImageIndex = 4
        TreeNode111.Text = "Finish Parts  Inventory List (Order by Value Stock)"
        TreeNode112.ImageIndex = 4
        TreeNode112.Name = "rptFinishPartsInvListOrderByLocation"
        TreeNode112.SelectedImageIndex = 4
        TreeNode112.Text = "Finish Parts  Inventory List (Order by Stock Location)"
        TreeNode113.ImageIndex = 4
        TreeNode113.Name = "rptFinishPartsInvListOrderByDeliveryDate"
        TreeNode113.SelectedImageIndex = 4
        TreeNode113.Text = "Finish Parts  Inventory List (Order by MPO Delivery Date)"
        TreeNode114.ImageIndex = 4
        TreeNode114.Name = "rptFinishPartsInvListOrderByPartNumber"
        TreeNode114.SelectedImageIndex = 4
        TreeNode114.Text = "Finish Parts  Inventory List (Order by Part Number)"
        TreeNode115.ImageIndex = 4
        TreeNode115.Name = "Node0"
        TreeNode115.SelectedImageIndex = 4
        TreeNode115.Text = "Finish Parts"
        TreeNode116.ImageIndex = 4
        TreeNode116.Name = "rptInvRawMaterial"
        TreeNode116.SelectedImageIndex = 4
        TreeNode116.Text = "Raw Material  Inventory List (Order by Entry Date)"
        TreeNode117.ImageIndex = 4
        TreeNode117.Name = "rptInvRawMaterialByStockQty"
        TreeNode117.SelectedImageIndex = 4
        TreeNode117.Text = "Raw Material  Inventory List (Order by Quantity Stock)"
        TreeNode118.ImageIndex = 4
        TreeNode118.Name = "rptInvRawMaterialByStockValue"
        TreeNode118.SelectedImageIndex = 4
        TreeNode118.Text = "Raw Material  Inventory List (Order by Value Stock)"
        TreeNode119.ImageIndex = 4
        TreeNode119.Name = "Node0"
        TreeNode119.SelectedImageIndex = 4
        TreeNode119.Text = "Raw Material"
        TreeNode120.ImageIndex = 4
        TreeNode120.Name = "rptWIPDetailOrderByMpoDate"
        TreeNode120.SelectedImageIndex = 4
        TreeNode120.Text = "WIP Detail  (Order By Start Mpo Date)"
        TreeNode121.ImageIndex = 4
        TreeNode121.Name = "rptWIPDetailOrderByMpoDateByCustomer"
        TreeNode121.SelectedImageIndex = 4
        TreeNode121.Text = "WIP Detail  By Customer (Order By Start Mpo Date)"
        TreeNode122.ImageIndex = 4
        TreeNode122.Name = "rptWIPDetailOrderByActualQty"
        TreeNode122.SelectedImageIndex = 4
        TreeNode122.Text = "WIP Detail  (Order By Actual Quantity)"
        TreeNode123.ImageIndex = 4
        TreeNode123.Name = "rptWIPDetailOrderByValue"
        TreeNode123.SelectedImageIndex = 4
        TreeNode123.Text = "WIP Detail  (Order By MPO WIP Value)"
        TreeNode124.ImageIndex = 4
        TreeNode124.Name = "Node1"
        TreeNode124.SelectedImageIndex = 4
        TreeNode124.Text = "W.I.P."
        TreeNode125.ImageIndex = 4
        TreeNode125.Name = "InvCheck"
        TreeNode125.SelectedImageIndex = 4
        TreeNode125.Text = "LAC Inventory Check Lists"
        TreeNode126.ImageIndex = 4
        TreeNode126.Name = "rptInvoiceListByCustSummary"
        TreeNode126.SelectedImageIndex = 4
        TreeNode126.Text = "Lists Invoices grouped by Customer - Summary"
        TreeNode127.ImageIndex = 4
        TreeNode127.Name = "rptInvoiceListByCust"
        TreeNode127.SelectedImageIndex = 4
        TreeNode127.Text = "Lists Invoices grouped by Customer"
        TreeNode128.ImageIndex = 4
        TreeNode128.Name = "rptInvoiceList"
        TreeNode128.SelectedImageIndex = 4
        TreeNode128.Text = "Lists Invoices ordered by Invoice Number"
        TreeNode129.ImageIndex = 4
        TreeNode129.Name = "rptInvoiceByCustomerYD"
        TreeNode129.SelectedImageIndex = 4
        TreeNode129.Text = "Lists Invoices Grouped by Customer (YTD - Summary)"
        TreeNode130.ImageIndex = 4
        TreeNode130.Name = "rptInvoiceListNotPosted"
        TreeNode130.SelectedImageIndex = 4
        TreeNode130.Text = "Opened or Cancelled Sale Orders"
        TreeNode131.ImageIndex = 4
        TreeNode131.Name = "Billing"
        TreeNode131.SelectedImageIndex = 4
        TreeNode131.Text = "Lisi Invoices Lists"
        TreeNode132.ImageIndex = 4
        TreeNode132.Name = "rptPartFromBlanks"
        TreeNode132.SelectedImageIndex = 4
        TreeNode132.Text = "Parts List from Blanks"
        TreeNode133.ImageIndex = 4
        TreeNode133.Name = "rptBarCodeByEmpPeriode24Hrs"
        TreeNode133.SelectedImageIndex = 4
        TreeNode133.Text = "Bar Code Production Activity by Employee (Date - 24Hrs)"
        TreeNode134.ImageIndex = 4
        TreeNode134.Name = "rptBarCodeByMpoPeriode"
        TreeNode134.SelectedImageIndex = 4
        TreeNode134.Text = "Bar Code Production Activity by MPO"
        TreeNode135.ImageIndex = 4
        TreeNode135.Name = "rptBarCodeByValMBOPeriode24Hrs"
        TreeNode135.SelectedImageIndex = 4
        TreeNode135.Text = "Bar Code Production  --  MBO Value (Date - 24Hrs)"
        TreeNode136.ImageIndex = 4
        TreeNode136.Name = "Node1"
        TreeNode136.SelectedImageIndex = 4
        TreeNode136.Text = "Bar Code"
        TreeNode137.ImageIndex = 4
        TreeNode137.Name = "rptProdMachLoad"
        TreeNode137.SelectedImageIndex = 4
        TreeNode137.Text = "Machine(s) Utilization - Periode & Percentage"
        TreeNode138.ImageIndex = 4
        TreeNode138.Name = "rptMpoActualQtyChg"
        TreeNode138.SelectedImageIndex = 4
        TreeNode138.Text = "MPOs List- Quantity Manually Changed"
        TreeNode139.ImageIndex = 4
        TreeNode139.Name = "Prod"
        TreeNode139.SelectedImageIndex = 4
        TreeNode139.Text = "Production Control Reports"
        TreeNode140.ImageIndex = 4
        TreeNode140.Name = "rptCustOrderActiveForecastByMPODeliveryDate"
        TreeNode140.SelectedImageIndex = 4
        TreeNode140.Text = "(1) Production List By MPO Delivery Date "
        TreeNode141.ImageIndex = 4
        TreeNode141.Name = "rptShopFloorByDept"
        TreeNode141.SelectedImageIndex = 4
        TreeNode141.Text = "Shop Floor Control By Department  --  Daily Production List"
        TreeNode142.ImageIndex = 4
        TreeNode142.Name = "rptShopFloorByDeptByValue"
        TreeNode142.SelectedImageIndex = 4
        TreeNode142.Text = "Shop Floor Control By Department (Qty & Value)  --  Detail "
        TreeNode143.ImageIndex = 4
        TreeNode143.Name = "rptShopFloorByDeptSummaryByValue"
        TreeNode143.SelectedImageIndex = 4
        TreeNode143.Text = "Shop Floor Control By Department  --  Summary"
        TreeNode144.ImageIndex = 4
        TreeNode144.Name = "Shop"
        TreeNode144.SelectedImageIndex = 4
        TreeNode144.Text = "Shop Floor Control"
        TreeNode145.ImageIndex = 4
        TreeNode145.Name = "rptWIPSummary"
        TreeNode145.SelectedImageIndex = 4
        TreeNode145.Text = "Summary"
        TreeNode146.ImageIndex = 4
        TreeNode146.Name = "rptWIPDetail"
        TreeNode146.SelectedImageIndex = 4
        TreeNode146.Text = "Detail"
        TreeNode147.ImageIndex = 4
        TreeNode147.Name = "WIP"
        TreeNode147.SelectedImageIndex = 4
        TreeNode147.Text = "Work-In-Process"
        TreeNode148.ImageIndex = 18
        TreeNode148.Name = "Inv"
        TreeNode148.SelectedImageIndex = 19
        TreeNode148.Text = "Lisi  Reports"
        TreeNode149.ImageIndex = 21
        TreeNode149.Name = "frmMaintEquipmentsModule"
        TreeNode149.SelectedImageIndex = 21
        TreeNode149.Text = "Machinery and Equipment Module"
        TreeNode150.ImageIndex = 21
        TreeNode150.Name = "frmMaintEquipInfo"
        TreeNode150.SelectedImageIndex = 21
        TreeNode150.Text = " Machinery and Equipment Info"
        TreeNode151.ImageIndex = 21
        TreeNode151.Name = "frmMaintTaskInfo"
        TreeNode151.SelectedImageIndex = 21
        TreeNode151.Text = "Task Info"
        TreeNode152.ImageIndex = 21
        TreeNode152.Name = "frmMaintProductCatalog"
        TreeNode152.SelectedImageIndex = 21
        TreeNode152.Text = "Product / Component Name"
        TreeNode153.ImageIndex = 18
        TreeNode153.Name = "MaintFrms"
        TreeNode153.SelectedImageIndex = 19
        TreeNode153.Text = "Data Maintenance"
        TreeNode154.ImageIndex = 18
        TreeNode154.Name = "Maint"
        TreeNode154.SelectedImageIndex = 19
        TreeNode154.Text = "Maintenance"
        TreeNode155.ImageIndex = 21
        TreeNode155.Name = "frmReceivingPerishable"
        TreeNode155.SelectedImageIndex = 21
        TreeNode155.Text = "Receiving Acceptance- Perishable Products"
        TreeNode156.ImageIndex = 21
        TreeNode156.Name = "frmReleasePerishable"
        TreeNode156.SelectedImageIndex = 21
        TreeNode156.Text = "Release To Production -  Perishable Products"
        TreeNode157.ImageIndex = 4
        TreeNode157.Name = "rptPerishableReceiving"
        TreeNode157.SelectedImageIndex = 4
        TreeNode157.Text = "Receiving"
        TreeNode158.ImageIndex = 4
        TreeNode158.Name = "rptPerishableRelease"
        TreeNode158.SelectedImageIndex = 4
        TreeNode158.Text = "Release"
        TreeNode159.ImageIndex = 4
        TreeNode159.Name = "rptPerishableInventoryList"
        TreeNode159.SelectedImageIndex = 4
        TreeNode159.Text = "Perishable - Inventory List"
        TreeNode160.ImageIndex = 4
        TreeNode160.Name = "Perishable Products - Reports"
        TreeNode160.SelectedImageIndex = 4
        TreeNode160.Text = "Reports"
        TreeNode161.ImageIndex = 18
        TreeNode161.Name = "Perishable"
        TreeNode161.SelectedImageIndex = 19
        TreeNode161.Text = "Perishable Inventory Control"
        TreeNode162.ImageIndex = 21
        TreeNode162.Name = "frmMPOCostAnalyze"
        TreeNode162.SelectedImageIndex = 21
        TreeNode162.Text = "MPO Cost Analyze"
        TreeNode163.ImageIndex = 4
        TreeNode163.Name = "rptWIPDetailWithCost"
        TreeNode163.SelectedImageIndex = 4
        TreeNode163.Text = "Work-In-Process -- MFG Cost"
        TreeNode164.ImageIndex = 4
        TreeNode164.Name = "rptInvoiceListWithCost"
        TreeNode164.SelectedImageIndex = 4
        TreeNode164.Text = "Invoices List -- Gross Profit"
        TreeNode165.ImageIndex = 4
        TreeNode165.Name = "rptInvoiceListWithCostByCustandPeriod"
        TreeNode165.SelectedImageIndex = 4
        TreeNode165.Text = "Invoices List by Customer -- Gross Profit"
        TreeNode166.ImageIndex = 4
        TreeNode166.Name = "rptFinishPartsInventoryListWithCost"
        TreeNode166.SelectedImageIndex = 4
        TreeNode166.Text = "Finish  Part Inventory  List --  MFG Cost "
        TreeNode167.ImageIndex = 4
        TreeNode167.Name = "rptFinishPartsInventoryListWithCostAsMovex_2"
        TreeNode167.SelectedImageIndex = 4
        TreeNode167.Text = "Finish  Part Inventory  List - LAC LOTS - Stock Price"
        TreeNode168.ImageIndex = 4
        TreeNode168.Name = "rptFinishPartsInventoryListWithCostAsMovexStdPrice"
        TreeNode168.SelectedImageIndex = 4
        TreeNode168.Text = "Finish  Part Inventory  List - LAC LOTS - Standard Price"
        TreeNode169.ImageIndex = 4
        TreeNode169.Name = "rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment"
        TreeNode169.SelectedImageIndex = 4
        TreeNode169.Text = "Finish  Part Inventory  List - LNA Transferred LOTS"
        TreeNode170.ImageIndex = 4
        TreeNode170.Name = "rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment_Ver2"
        TreeNode170.SelectedImageIndex = 4
        TreeNode170.Text = "Depreciation Estimates - Finish  Part Inventory  List - LNA Transferred LOTS"
        TreeNode171.ImageIndex = 4
        TreeNode171.Name = "rptFinishPartsBlanksInventoryListAsMovex"
        TreeNode171.SelectedImageIndex = 4
        TreeNode171.Text = "Semi Finish  Part Inventory  List"
        TreeNode172.ImageIndex = 4
        TreeNode172.Name = "rptInvRawMaterialAsMovex"
        TreeNode172.SelectedImageIndex = 4
        TreeNode172.Text = "Raw Material Inventory List"
        TreeNode173.ImageIndex = 21
        TreeNode173.Name = "frmAccHeadOfficeLACQueries"
        TreeNode173.SelectedImageIndex = 21
        TreeNode173.Text = "LAC -  Sales Statistics"
        TreeNode174.ImageIndex = 4
        TreeNode174.Name = "Node0"
        TreeNode174.SelectedImageIndex = 4
        TreeNode174.Text = "Stock Valuation (M3 - Method)"
        TreeNode175.ImageIndex = 4
        TreeNode175.Name = "Node1"
        TreeNode175.SelectedImageIndex = 4
        TreeNode175.Text = "Analyzing Cost"
        TreeNode176.ImageIndex = 4
        TreeNode176.Name = "rptInvoiceByCustomerYD"
        TreeNode176.SelectedImageIndex = 4
        TreeNode176.Text = "Lists Invoices Grouped by Customer (YTD - Summary)"
        TreeNode177.ImageIndex = 4
        TreeNode177.Name = "rptInvoiceListByCustSummary"
        TreeNode177.SelectedImageIndex = 4
        TreeNode177.Text = "Lists Invoices grouped by Customer - Summary"
        TreeNode178.ImageIndex = 4
        TreeNode178.Name = "rptInvoiceList"
        TreeNode178.SelectedImageIndex = 4
        TreeNode178.Text = "Lists Invoices ordered by Invoice Number"
        TreeNode179.ImageIndex = 4
        TreeNode179.Name = "Node3"
        TreeNode179.SelectedImageIndex = 4
        TreeNode179.Text = "Lisi Invoices Lists"
        TreeNode180.ImageIndex = 4
        TreeNode180.Name = "rptCustOrderActiveBookingByOderDate"
        TreeNode180.SelectedImageIndex = 4
        TreeNode180.Text = "By Order Date  --  Detail"
        TreeNode181.ImageIndex = 4
        TreeNode181.Name = "rptCustOrderActiveBookingByOderDateSummary"
        TreeNode181.SelectedImageIndex = 4
        TreeNode181.Text = "Summary"
        TreeNode182.ImageIndex = 4
        TreeNode182.Name = "Node2"
        TreeNode182.SelectedImageIndex = 4
        TreeNode182.Text = "Booking Reports"
        TreeNode183.ImageIndex = 4
        TreeNode183.Name = "rptCustOrderActive"
        TreeNode183.SelectedImageIndex = 4
        TreeNode183.Text = "Customer Orders LIST"
        TreeNode184.ImageIndex = 4
        TreeNode184.Name = "Node0"
        TreeNode184.SelectedImageIndex = 4
        TreeNode184.Text = "Customer Orders"
        TreeNode185.ImageIndex = 4
        TreeNode185.Name = "rptCustOrderActiveForecastByDelDateAndPartNo"
        TreeNode185.SelectedImageIndex = 4
        TreeNode185.Text = "Forward Forecast Report By Delivery Date And MPO Number"
        TreeNode186.ImageIndex = 4
        TreeNode186.Name = "rptCustOrderActiveForecastByPartNoMpoNo"
        TreeNode186.SelectedImageIndex = 4
        TreeNode186.Text = "Forward Forecast Report By Part Number"
        TreeNode187.ImageIndex = 4
        TreeNode187.Name = "rptCustOrderActiveForecastByDelDate"
        TreeNode187.SelectedImageIndex = 4
        TreeNode187.Text = "Detail"
        TreeNode188.ImageIndex = 4
        TreeNode188.Name = "rptCustOrderActiveForecastByDelDateSummary"
        TreeNode188.SelectedImageIndex = 4
        TreeNode188.Text = "Summary"
        TreeNode189.ImageIndex = 4
        TreeNode189.Name = "Node0"
        TreeNode189.SelectedImageIndex = 4
        TreeNode189.Text = "Forward Forecast Report By Delivery Date"
        TreeNode190.ImageIndex = 4
        TreeNode190.Name = "rptCustOrderActiveForecastByPartAndDelDateProduction"
        TreeNode190.SelectedImageIndex = 4
        TreeNode190.Text = "Forward Forecast Report By Customer Part Number Delivery Date & Production Status" & _
    ""
        TreeNode191.ImageIndex = 4
        TreeNode191.Name = "Node0"
        TreeNode191.SelectedImageIndex = 4
        TreeNode191.Text = " Forecast Reports"
        TreeNode192.ImageIndex = 4
        TreeNode192.Name = "rptFinishPartsInventoryList"
        TreeNode192.SelectedImageIndex = 4
        TreeNode192.Text = "Finish Parts  Inventory List"
        TreeNode193.ImageIndex = 4
        TreeNode193.Name = "Node7"
        TreeNode193.SelectedImageIndex = 4
        TreeNode193.Text = "Inventory Finish Parts"
        TreeNode194.ImageIndex = 4
        TreeNode194.Name = "rptInvRawMaterial"
        TreeNode194.SelectedImageIndex = 4
        TreeNode194.Text = "Raw Material  Inventory List"
        TreeNode195.ImageIndex = 4
        TreeNode195.Name = "rptInvRawMaterialKSI"
        TreeNode195.SelectedImageIndex = 4
        TreeNode195.Text = "Raw Material  Inventory List -- With Inspection Results"
        TreeNode196.ImageIndex = 4
        TreeNode196.Name = "Node1"
        TreeNode196.SelectedImageIndex = 4
        TreeNode196.Text = "Inventory Raw Material"
        TreeNode197.ImageIndex = 4
        TreeNode197.Name = "rptWIPSummary"
        TreeNode197.SelectedImageIndex = 4
        TreeNode197.Text = "Summary"
        TreeNode198.ImageIndex = 4
        TreeNode198.Name = "rptWIPDetail"
        TreeNode198.SelectedImageIndex = 4
        TreeNode198.Text = "Detail"
        TreeNode199.ImageIndex = 4
        TreeNode199.Name = "WIP"
        TreeNode199.SelectedImageIndex = 4
        TreeNode199.Text = "Work-In-Process"
        TreeNode200.ImageIndex = 4
        TreeNode200.Name = "rptShopFloorByDeptSummaryByValue"
        TreeNode200.SelectedImageIndex = 4
        TreeNode200.Text = "Shop Floor Control By Department (Qty & Value)  --  Summary"
        TreeNode201.ImageIndex = 4
        TreeNode201.Name = "rptShopFloorByDeptByValue"
        TreeNode201.SelectedImageIndex = 4
        TreeNode201.Text = "Shop Floor Control By Department (Qty & Value)  --  Detail "
        TreeNode202.ImageIndex = 4
        TreeNode202.Name = "Node6"
        TreeNode202.SelectedImageIndex = 4
        TreeNode202.Text = "Shop Floor Control"
        TreeNode203.ImageIndex = 4
        TreeNode203.Name = "Node2"
        TreeNode203.SelectedImageIndex = 4
        TreeNode203.Text = "Reports"
        TreeNode204.ImageIndex = 18
        TreeNode204.Name = "Mng"
        TreeNode204.SelectedImageIndex = 19
        TreeNode204.Text = "Management "
        TreeNode205.ImageIndex = 21
        TreeNode205.Name = "frmReleaseBlanks.xxx"
        TreeNode205.SelectedImageIndex = 21
        TreeNode205.Text = "Blanks Requirements Planning  and Release to Production (MPO No.)"
        TreeNode206.ImageIndex = 21
        TreeNode206.Name = "frmReleaseRawMaterial"
        TreeNode206.SelectedImageIndex = 21
        TreeNode206.Text = "Raw Material Requirements Planning  and Release to Production (MPO No.)"
        TreeNode207.ImageIndex = 21
        TreeNode207.Name = "frmRawMaterialAnalyze"
        TreeNode207.SelectedImageIndex = 21
        TreeNode207.Text = "Raw Material Analyze (RM Inventory & RM Purchasing)"
        TreeNode208.ImageIndex = 21
        TreeNode208.Name = "frmShopFloorControl"
        TreeNode208.SelectedImageIndex = 21
        TreeNode208.Text = "Shop Floor Control "
        TreeNode209.ImageIndex = 21
        TreeNode209.Name = "frmProductionAnalize"
        TreeNode209.SelectedImageIndex = 21
        TreeNode209.Text = "Customized Production Queries"
        TreeNode210.ImageIndex = 21
        TreeNode210.Name = "frmBarCodeMBO"
        TreeNode210.SelectedImageIndex = 21
        TreeNode210.Text = "Bar Code Production Queries"
        TreeNode211.ImageIndex = 21
        TreeNode211.Name = "frmMatlLotStockNotes"
        TreeNode211.SelectedImageIndex = 21
        TreeNode211.Text = "Add Comments in Raw Material Inventory"
        TreeNode212.ImageIndex = 21
        TreeNode212.Name = "frmPartMasterQuote"
        TreeNode212.SelectedImageIndex = 21
        TreeNode212.Text = "Part Master (Short Form)"
        TreeNode213.ImageIndex = 21
        TreeNode213.Name = "frmPartToolBox"
        TreeNode213.SelectedImageIndex = 21
        TreeNode213.Text = "Tool Box"
        TreeNode214.ImageIndex = 21
        TreeNode214.Name = "frmProdFirstRelease"
        TreeNode214.SelectedImageIndex = 21
        TreeNode214.Text = "P/N - First Time Release to Production"
        TreeNode215.ImageIndex = 21
        TreeNode215.Name = "frmLNALoadMiMax"
        TreeNode215.SelectedImageIndex = 21
        TreeNode215.Text = "1. Min/Max Daily - Integrate"
        TreeNode216.ImageIndex = 21
        TreeNode216.Name = "frmLNAAnalyze"
        TreeNode216.SelectedImageIndex = 21
        TreeNode216.Text = "LNA - Extract Data from MRP By P/N"
        TreeNode217.ImageIndex = 18
        TreeNode217.Name = "LNA"
        TreeNode217.SelectedImageIndex = 19
        TreeNode217.Text = "Min/Max Procedures"
        TreeNode218.ImageIndex = 18
        TreeNode218.Name = "Prod"
        TreeNode218.SelectedImageIndex = 19
        TreeNode218.Text = "Planning And Production Control "
        TreeNode219.ImageIndex = 21
        TreeNode219.Name = "frmPOMaster"
        TreeNode219.SelectedImageIndex = 21
        TreeNode219.Text = "Purchasing"
        TreeNode220.ImageIndex = 21
        TreeNode220.Name = "frmEngRemarks"
        TreeNode220.SelectedImageIndex = 21
        TreeNode220.Text = "Technical Notes for Purchasing"
        TreeNode221.ImageIndex = 21
        TreeNode221.Name = "frmPOAnalyze"
        TreeNode221.SelectedImageIndex = 21
        TreeNode221.Text = "Subcontracting - Analyze Module"
        TreeNode222.ImageIndex = 21
        TreeNode222.Name = "frmPOQuery"
        TreeNode222.SelectedImageIndex = 21
        TreeNode222.Text = "POs Data Extraction"
        TreeNode223.ImageIndex = 4
        TreeNode223.Name = "rptPOPrintAll"
        TreeNode223.SelectedImageIndex = 4
        TreeNode223.Text = "Purchasing Information List"
        TreeNode224.ImageIndex = 4
        TreeNode224.Name = "rptPrintPOPriceCorrection"
        TreeNode224.SelectedImageIndex = 4
        TreeNode224.Text = "Purchase Order List (Price Correction - Less 0.02$)"
        TreeNode225.ImageIndex = 4
        TreeNode225.Name = "rptPrintPOBySupp"
        TreeNode225.SelectedImageIndex = 4
        TreeNode225.Text = "Purchase Order List (By Supplier)"
        TreeNode226.ImageIndex = 4
        TreeNode226.Name = "rptPrintPOByType"
        TreeNode226.SelectedImageIndex = 4
        TreeNode226.Text = "Purchase Order List (By PO Type and Periode)"
        TreeNode227.ImageIndex = 4
        TreeNode227.Name = "rptPrintPOByGLAccount"
        TreeNode227.SelectedImageIndex = 4
        TreeNode227.Text = "Purchase Order List (By GL Account Number)"
        TreeNode228.ImageIndex = 4
        TreeNode228.Name = "rptPrintPOByGLAccountSummary"
        TreeNode228.SelectedImageIndex = 4
        TreeNode228.Text = "Purchase Order List (By Supplier / GL Account Number) - Summary"
        TreeNode229.ImageIndex = 4
        TreeNode229.Name = "rptPrintPOByGLAccountSupplierSummary"
        TreeNode229.SelectedImageIndex = 4
        TreeNode229.Text = "Purchase Order List (By GL Account Number / Supplier) - By PO Due Date"
        TreeNode230.ImageIndex = 4
        TreeNode230.Name = "rptPrintPOReceivingByPeriode"
        TreeNode230.SelectedImageIndex = 4
        TreeNode230.Text = "Incoming Receiving PO - (By Supplier)"
        TreeNode231.ImageIndex = 4
        TreeNode231.Name = "CrptPOAnalyzeSubContracting"
        TreeNode231.SelectedImageIndex = 4
        TreeNode231.Text = "Processing & Sub-Contracting List"
        TreeNode232.ImageIndex = 4
        TreeNode232.Name = "rptAccReceivedAndNotPaid"
        TreeNode232.SelectedImageIndex = 4
        TreeNode232.Text = "PO Received and not Invoiced"
        TreeNode233.ImageIndex = 4
        TreeNode233.Name = "PurCtlReports"
        TreeNode233.SelectedImageIndex = 4
        TreeNode233.Text = "Reports"
        TreeNode234.ImageIndex = 18
        TreeNode234.Name = "PurCtl"
        TreeNode234.SelectedImageIndex = 19
        TreeNode234.Text = "Purchasing Control"
        TreeNode235.ImageIndex = 21
        TreeNode235.Name = "frmQuote"
        TreeNode235.SelectedImageIndex = 21
        TreeNode235.Text = "Quotation"
        TreeNode236.ImageIndex = 21
        TreeNode236.Name = "frmQuoteAnalyze"
        TreeNode236.SelectedImageIndex = 21
        TreeNode236.Text = "Quote Analyze Form"
        TreeNode237.ImageIndex = 21
        TreeNode237.Name = "frmQuoteAnalyzeM3"
        TreeNode237.SelectedImageIndex = 21
        TreeNode237.Text = "Quote Analyze Form - M3"
        TreeNode238.ImageIndex = 21
        TreeNode238.Name = "frmQuoteEngEst"
        TreeNode238.SelectedImageIndex = 21
        TreeNode238.Text = "Status (Cost estimation)"
        TreeNode239.ImageIndex = 4
        TreeNode239.Name = "rptQuoteListByCust"
        TreeNode239.SelectedImageIndex = 4
        TreeNode239.Text = "Quote List per Customers"
        TreeNode240.ImageIndex = 4
        TreeNode240.Name = "rptQuoteListByPart"
        TreeNode240.SelectedImageIndex = 4
        TreeNode240.Text = "Quote List per Part Number"
        TreeNode241.ImageIndex = 4
        TreeNode241.Name = "rptQuoteSuccessYD"
        TreeNode241.SelectedImageIndex = 4
        TreeNode241.Text = "Parts Count per Customer - YTD"
        TreeNode242.ImageIndex = 4
        TreeNode242.Name = "Node0"
        TreeNode242.SelectedImageIndex = 4
        TreeNode242.Text = "Reports"
        TreeNode243.ImageIndex = 18
        TreeNode243.Name = "RFQ"
        TreeNode243.SelectedImageIndex = 19
        TreeNode243.Text = "Request For Quotation"
        TreeNode244.ImageIndex = 21
        TreeNode244.Name = "frmInspReqList"
        TreeNode244.SelectedImageIndex = 21
        TreeNode244.Text = "Inspection Requirements List"
        TreeNode245.ImageIndex = 21
        TreeNode245.Name = "frmRMStockLocation"
        TreeNode245.SelectedImageIndex = 21
        TreeNode245.Text = "Raw Material Stock Location"
        TreeNode246.ImageIndex = 18
        TreeNode246.Name = "DataMaint"
        TreeNode246.SelectedImageIndex = 19
        TreeNode246.Text = "Data Maintenance "
        TreeNode247.ImageIndex = 21
        TreeNode247.Name = "frmFinalInspection"
        TreeNode247.SelectedImageIndex = 21
        TreeNode247.Text = "Final Inspection (Closing Mpo No.)"
        TreeNode248.ImageIndex = 21
        TreeNode248.Name = "frmRawMatlAdj"
        TreeNode248.SelectedImageIndex = 21
        TreeNode248.Text = "Adjustments -- Raw Material & Mpo "
        TreeNode249.ImageIndex = 21
        TreeNode249.Name = "frmPORecvInsp"
        TreeNode249.SelectedImageIndex = 21
        TreeNode249.Text = "Receiving Inspection - Raw Material"
        TreeNode250.ImageIndex = 21
        TreeNode250.Name = "frmPoRecvTreatInsp"
        TreeNode250.SelectedImageIndex = 21
        TreeNode250.Text = "Receiving Inspection - Processing, Sub-Contracting, Tolling, Calibration, Other"
        TreeNode251.ImageIndex = 21
        TreeNode251.Name = "frmMpoSplitProd"
        TreeNode251.SelectedImageIndex = 21
        TreeNode251.Text = "Unplaned Mpo Splits"
        TreeNode252.ImageIndex = 4
        TreeNode252.Name = "rptMatlLotNumber"
        TreeNode252.SelectedImageIndex = 4
        TreeNode252.Text = "Raw Material Inspection And Release"
        TreeNode253.ImageIndex = 4
        TreeNode253.Name = "Node0"
        TreeNode253.SelectedImageIndex = 4
        TreeNode253.Text = "Reports"
        TreeNode254.ImageIndex = 18
        TreeNode254.Name = "QC"
        TreeNode254.SelectedImageIndex = 19
        TreeNode254.Text = "Quality Control Lab Inspection"
        TreeNode255.ImageIndex = 21
        TreeNode255.Name = "frmQAImportWordDoc"
        TreeNode255.SelectedImageIndex = 21
        TreeNode255.Text = "Admin Module"
        TreeNode256.ImageIndex = 21
        TreeNode256.Name = "frmQAReadDocuments"
        TreeNode256.SelectedImageIndex = 21
        TreeNode256.Text = "Read Only Module"
        TreeNode257.ImageIndex = 18
        TreeNode257.Name = "DM"
        TreeNode257.SelectedImageIndex = 19
        TreeNode257.Text = "Admin Documents"
        TreeNode258.ImageIndex = 18
        TreeNode258.Name = "QD"
        TreeNode258.SelectedImageIndex = 19
        TreeNode258.Text = "Quality Control Documents"
        TreeNode259.ImageIndex = 21
        TreeNode259.Name = "frmHSEImportWordDoc"
        TreeNode259.SelectedImageIndex = 21
        TreeNode259.Text = "Admin Module"
        TreeNode260.ImageIndex = 21
        TreeNode260.Name = "frmHSEReadDocuments"
        TreeNode260.SelectedImageIndex = 21
        TreeNode260.Text = "Read Only Module"
        TreeNode261.ImageIndex = 18
        TreeNode261.Name = "HSEAD"
        TreeNode261.SelectedImageIndex = 19
        TreeNode261.Text = "Admin Documents"
        TreeNode262.ImageIndex = 18
        TreeNode262.Name = "HSE"
        TreeNode262.SelectedImageIndex = 19
        TreeNode262.Text = "HSE Control Documents"
        TreeNode263.ImageIndex = 21
        TreeNode263.Name = "frmSalesInvoice"
        TreeNode263.SelectedImageIndex = 21
        TreeNode263.Text = "Customer Invoice Form"
        TreeNode264.ImageIndex = 21
        TreeNode264.Name = "frmSalesDelivReq"
        TreeNode264.SelectedImageIndex = 21
        TreeNode264.Text = "Delivery Quantity Request"
        TreeNode265.ImageIndex = 21
        TreeNode265.Name = "frmSalesCancelDlivReq"
        TreeNode265.SelectedImageIndex = 21
        TreeNode265.Text = "Delivery Cancel Request"
        TreeNode266.ImageIndex = 21
        TreeNode266.Name = "frmFPSalesPriceUpdate"
        TreeNode266.SelectedImageIndex = 21
        TreeNode266.Text = "Finish Parts - Price Adjustment"
        TreeNode267.ImageIndex = 21
        TreeNode267.Name = "frmPartMasterQuote"
        TreeNode267.SelectedImageIndex = 21
        TreeNode267.Text = "Part Master (Short Form)"
        TreeNode268.ImageIndex = 4
        TreeNode268.Name = "rptInvoiceListByCust"
        TreeNode268.SelectedImageIndex = 4
        TreeNode268.Text = "Lists Invoices grouped by Customer"
        TreeNode269.ImageIndex = 4
        TreeNode269.Name = "rptInvoiceList"
        TreeNode269.SelectedImageIndex = 4
        TreeNode269.Text = "Lists Invoices ordered by Invoice Number"
        TreeNode270.ImageIndex = 4
        TreeNode270.Name = "Node0"
        TreeNode270.SelectedImageIndex = 4
        TreeNode270.Text = "Lisi Invoices Lists"
        TreeNode271.ImageIndex = 4
        TreeNode271.Name = "Node3"
        TreeNode271.SelectedImageIndex = 4
        TreeNode271.Text = "Reports"
        TreeNode272.ImageIndex = 18
        TreeNode272.Name = "Sales"
        TreeNode272.SelectedImageIndex = 19
        TreeNode272.Text = "Sales"
        TreeNode273.ImageIndex = 21
        TreeNode273.Name = "frmSalesForecast"
        TreeNode273.SelectedImageIndex = 21
        TreeNode273.Text = "Sales Forecast"
        TreeNode274.ImageIndex = 21
        TreeNode274.Name = "frmSalesPlanningFPInventory"
        TreeNode274.SelectedImageIndex = 21
        TreeNode274.Text = "Forecast By Item"
        TreeNode275.ImageIndex = 4
        TreeNode275.Name = "rptSalesPlanningFPInventory"
        TreeNode275.SelectedImageIndex = 4
        TreeNode275.Text = "Forecast List By Customer and Part Number"
        TreeNode276.ImageIndex = 4
        TreeNode276.Name = "rptSalesPlanningFPInventoryByDeliveryDate"
        TreeNode276.SelectedImageIndex = 4
        TreeNode276.Text = "Forecast List By Customer and Part Number (By Delivery Date)"
        TreeNode277.ImageIndex = 4
        TreeNode277.Name = "Node0"
        TreeNode277.SelectedImageIndex = 4
        TreeNode277.Text = "Reports"
        TreeNode278.ImageIndex = 18
        TreeNode278.Name = "ForecastSales"
        TreeNode278.SelectedImageIndex = 19
        TreeNode278.Text = "Sales Forecast & Planning"
        TreeNode279.ImageIndex = 21
        TreeNode279.Name = "frmSupplier"
        TreeNode279.SelectedImageIndex = 21
        TreeNode279.Text = "Maintain Supplier Data"
        TreeNode280.ImageIndex = 4
        TreeNode280.Name = "rptSuppApprovedList"
        TreeNode280.SelectedImageIndex = 4
        TreeNode280.Text = "Approved Supplier List"
        TreeNode281.ImageIndex = 4
        TreeNode281.Name = "rptSuppApprovedListWithRating"
        TreeNode281.SelectedImageIndex = 4
        TreeNode281.Text = "Sub-Contractors  Check  List  "
        TreeNode282.ImageIndex = 4
        TreeNode282.Name = "Node3"
        TreeNode282.SelectedImageIndex = 4
        TreeNode282.Text = "Reports"
        TreeNode283.ImageIndex = 18
        TreeNode283.Name = "Supp"
        TreeNode283.SelectedImageIndex = 19
        TreeNode283.Text = "Supplier"
        TreeNode284.ImageIndex = 21
        TreeNode284.Name = "frmOperatorsPay"
        TreeNode284.SelectedImageIndex = 21
        TreeNode284.Text = "Maintain LAC Employee data"
        TreeNode285.ImageIndex = 18
        TreeNode285.Name = "Pay"
        TreeNode285.SelectedImageIndex = 19
        TreeNode285.Text = "PayRoll Data Collect"
        TreeNode286.ImageIndex = 21
        TreeNode286.Name = "frmLisiQualityIndicators"
        TreeNode286.SelectedImageIndex = 21
        TreeNode286.Text = "LAC - Quality Indicators"
        TreeNode287.ImageIndex = 21
        TreeNode287.Name = "frmLisiMemoApp"
        TreeNode287.SelectedImageIndex = 21
        TreeNode287.Text = "LAC - Memo Module"
        TreeNode288.ImageIndex = 21
        TreeNode288.Name = "frmEngRequestForMaterial"
        TreeNode288.SelectedImageIndex = 21
        TreeNode288.Text = "LAC - Request for Material"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode12, TreeNode16, TreeNode36, TreeNode57, TreeNode64, TreeNode148, TreeNode154, TreeNode161, TreeNode204, TreeNode218, TreeNode234, TreeNode243, TreeNode254, TreeNode258, TreeNode262, TreeNode272, TreeNode278, TreeNode283, TreeNode285, TreeNode286, TreeNode287, TreeNode288})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(631, 710)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 710)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'txtPrint
        '
        Me.txtPrint.Location = New System.Drawing.Point(448, 21)
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.ReadOnly = True
        Me.txtPrint.Size = New System.Drawing.Size(100, 20)
        Me.txtPrint.TabIndex = 2
        Me.txtPrint.Visible = False
        '
        'frmMenu
        '
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(631, 710)
        Me.Controls.Add(Me.txtPrint)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "frmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada Corporation  --  Business Solutions for Fasteners (Ver. 201" & _
    "3)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmMenu_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        End
        GC.Collect()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        txtParm = "Null"
        txtParm = Me.TreeView1.SelectedNode.Name
    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick

        Me.Cursor = Cursors.WaitCursor

        If Len(Trim(txtParm)) <> 0 Then
            If IsDBNull(txtParm) = False Then

                GC.Collect()

                Select Case txtParm
                    Case Is = "ViewEmployee"
                        'ViewEmployee

                    Case Is = "frmCloseMonth"
                        frmCloseMonth.ShowDialog()
                        If frmCloseMonth.WindowState = FormWindowState.Minimized Then
                            frmCloseMonth.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngRemarks"
                        frmEngRemarks.ShowDialog()
                        If frmEngRemarks.WindowState = FormWindowState.Minimized Then
                            frmEngRemarks.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngMatlType"
                        frmEngMatlType.ShowDialog()
                        If frmEngMatlType.WindowState = FormWindowState.Minimized Then
                            frmEngMatlType.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmReleaseRawMaterial"
                        frmReleaseRawMaterial.Show()
                        If frmReleaseRawMaterial.WindowState = FormWindowState.Minimized Then
                            frmReleaseRawMaterial.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngDWGSourceName"
                        frmEngDWGSourceName.ShowDialog()
                        If frmEngDWGSourceName.WindowState = FormWindowState.Minimized Then
                            frmEngDWGSourceName.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPartMaster"
                        frmPartMaster.Show()
                        If frmPartMaster.WindowState = FormWindowState.Minimized Then
                            frmPartMaster.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngSpecList"
                        frmEngSpecList.ShowDialog()
                        If frmEngSpecList.WindowState = FormWindowState.Minimized Then
                            frmEngSpecList.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngApprMillList"
                        frmEngApprMillList.ShowDialog()
                        If frmEngApprMillList.WindowState = FormWindowState.Minimized Then
                            frmEngApprMillList.WindowState = FormWindowState.Normal
                        End If

                        'Case Is = "frmCostEstimation"
                        'frmCostEstimation.ShowDialog()
                    Case Is = "frmCustomer"
                        frmCustomer.ShowDialog()
                        If frmCustomer.WindowState = FormWindowState.Minimized Then
                            frmCustomer.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSupplier"
                        frmSupplier.ShowDialog()
                        If frmSupplier.WindowState = FormWindowState.Minimized Then
                            frmSupplier.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPOMaster"
                        frmPOMaster.ShowDialog()
                        If frmPOMaster.WindowState = FormWindowState.Minimized Then
                            frmPOMaster.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPOReceiving"
                        frmPOReceiving.ShowDialog()
                        If frmPOReceiving.WindowState = FormWindowState.Minimized Then
                            frmPOReceiving.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPORecvInsp"
                        frmPoRecvInsp.ShowDialog()
                        If frmPoRecvInsp.WindowState = FormWindowState.Minimized Then
                            frmPoRecvInsp.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPOQuery"
                        frmPOQuery.ShowDialog()
                        If frmPOQuery.WindowState = FormWindowState.Minimized Then
                            frmPOQuery.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmOrderEntry"
                        frmOrderEntry.Show()
                        If frmOrderEntry.WindowState = FormWindowState.Minimized Then
                            frmOrderEntry.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesCancelDlivReq"
                        LisiPrjMRP.frmSalesCancelDelivReq.Show()
                        If LisiPrjMRP.frmSalesCancelDelivReq.WindowState = FormWindowState.Minimized Then
                            LisiPrjMRP.frmSalesCancelDelivReq.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmOrderEntryM3CODO"
                        frmOrderEntryM3CODO.Show()
                        If frmOrderEntryM3CODO.WindowState = FormWindowState.Minimized Then
                            frmOrderEntryM3CODO.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQuote"
                        frmQuote.Show()
                        If frmQuote.WindowState = FormWindowState.Minimized Then
                            frmQuote.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQuoteEngEst"
                        frmQuoteEngEst.ShowDialog()
                        If frmQuoteEngEst.WindowState = FormWindowState.Minimized Then
                            frmQuoteEngEst.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmRMStockLocation"
                        frmRMStockLocation.ShowDialog()
                        If frmRMStockLocation.WindowState = FormWindowState.Minimized Then
                            frmRMStockLocation.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmInspReqList"
                        frmInspReqList.ShowDialog()
                        If frmInspReqList.WindowState = FormWindowState.Minimized Then
                            frmInspReqList.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMPOGenfromOrder"
                        frmMPOGenfromOrder.Show()
                        If frmMPOGenfromOrder.WindowState = FormWindowState.Minimized Then
                            frmMPOGenfromOrder.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmRawMatlAdj"
                        frmRawMatlAdj.ShowDialog()
                        If frmRawMatlAdj.WindowState = FormWindowState.Minimized Then
                            frmRawMatlAdj.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmShopFloorControl"
                        frmShopFloorControl.Show()
                        If frmShopFloorControl.WindowState = FormWindowState.Minimized Then
                            frmShopFloorControl.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmFinalInspection"
                        frmFinalInspection.Show()
                        If frmFinalInspection.WindowState = FormWindowState.Minimized Then
                            frmFinalInspection.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesDelivReq"
                        frmSalesDelivReq.Show()
                        If frmSalesDelivReq.WindowState = FormWindowState.Minimized Then
                            frmSalesDelivReq.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesPSlip"
                        frmSalesPSlip.Show()
                        If frmSalesPSlip.WindowState = FormWindowState.Minimized Then
                            frmSalesPSlip.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesInvoice"
                        frmSalesInvoice.Show()
                        If frmSalesInvoice.WindowState = FormWindowState.Minimized Then
                            frmSalesInvoice.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPartMasterQuote"
                        frmPartMasterQuote.Show()
                        If frmPartMasterQuote.WindowState = FormWindowState.Minimized Then
                            frmPartMasterQuote.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmFPAdj"
                        frmFPAdj.Show()
                        If frmFPAdj.WindowState = FormWindowState.Minimized Then
                            frmFPAdj.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMpoSplitProd"
                        frmMpoSplitProd.ShowDialog()
                        If frmMpoSplitProd.WindowState = FormWindowState.Minimized Then
                            frmMpoSplitProd.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMatlLotAdj"
                        frmMatlLotAdj.ShowDialog()
                        If frmMatlLotAdj.WindowState = FormWindowState.Minimized Then
                            frmMatlLotAdj.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmCustUpdateBudget"
                        frmCustUpdateBudget.ShowDialog()
                        If frmCustUpdateBudget.WindowState = FormWindowState.Minimized Then
                            frmCustUpdateBudget.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPoRecvTreatInsp"
                        frmPoRecvTreatInsp.Show()
                        If frmPoRecvTreatInsp.WindowState = FormWindowState.Minimized Then
                            frmPoRecvTreatInsp.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmReceivingPerishable"
                        frmReceivingPerishable.Show()
                        If frmReceivingPerishable.WindowState = FormWindowState.Minimized Then
                            frmReceivingPerishable.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmLisiMemoApp"
                        frmLisiMemoApp.Show()
                        If frmLisiMemoApp.WindowState = FormWindowState.Minimized Then
                            frmLisiMemoApp.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesForecast"
                        frmSalesForecast.Show()
                        If frmSalesForecast.WindowState = FormWindowState.Minimized Then
                            frmSalesForecast.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmSalesPlanningFPInventory"
                        frmSalesPlanningFPInventory.Show()
                        If frmSalesPlanningFPInventory.WindowState = FormWindowState.Minimized Then
                            frmSalesPlanningFPInventory.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngFinishSourceList"
                        frmEngFinishSourceList.Show()
                        If frmEngFinishSourceList.WindowState = FormWindowState.Minimized Then
                            frmEngFinishSourceList.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQAImportWordDoc"
                        frmQAImportWordDoc.Show()
                        If frmQAImportWordDoc.WindowState = FormWindowState.Minimized Then
                            frmQAImportWordDoc.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQAReadDocuments"
                        frmQAReadDocuments.Show()
                        If frmQAReadDocuments.WindowState = FormWindowState.Minimized Then
                            frmQAReadDocuments.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmFPReleaseToMPO"
                        frmFPReleaseToMPO.Show()
                        If frmFPReleaseToMPO.WindowState = FormWindowState.Minimized Then
                            frmFPReleaseToMPO.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmAccPayable"
                        frmAccPayable.Show()
                        If frmAccPayable.WindowState = FormWindowState.Minimized Then
                            frmAccPayable.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMatlLotStockNotes"
                        frmMatlLotStockNotes.Show()
                        If frmMatlLotStockNotes.WindowState = FormWindowState.Minimized Then
                            frmMatlLotStockNotes.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmOrderAssignDellivToMPO"
                        frmOrderAssignDellivToMPO.Show()
                        If frmOrderAssignDellivToMPO.WindowState = FormWindowState.Minimized Then
                            frmOrderAssignDellivToMPO.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmFPSalesPriceUpdate"
                        frmFPSalesPriceUpdate.Show()
                        If frmFPSalesPriceUpdate.WindowState = FormWindowState.Minimized Then
                            frmFPSalesPriceUpdate.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQuoteAnalyze"
                        frmQuoteAnalyze.Show()
                        If frmQuoteAnalyze.WindowState = FormWindowState.Minimized Then
                            frmQuoteAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmQuoteAnalyzeM3"
                        frmQuoteAnalyzeM3.Show()
                        If frmQuoteAnalyzeM3.WindowState = FormWindowState.Minimized Then
                            frmQuoteAnalyzeM3.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPOAnalyze"
                        frmPOAnalyze.Show()
                        If frmPOAnalyze.WindowState = FormWindowState.Minimized Then
                            frmPOAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngUpdateRev"
                        frmEngUpdateRev.Show()
                        If frmEngUpdateRev.WindowState = FormWindowState.Minimized Then
                            frmEngUpdateRev.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmBackLogAnalyze"
                        frmBackLogAnalyze.Show()
                        If frmBackLogAnalyze.WindowState = FormWindowState.Minimized Then
                            frmBackLogAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMatlPriceDepreciation"
                        frmMatlPriceDepreciation.Show()
                        If frmMatlPriceDepreciation.WindowState = FormWindowState.Minimized Then
                            frmMatlPriceDepreciation.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngMPOPlanedSplit"
                        frmEngMPOPlanedSplit.Show()
                        If frmEngMPOPlanedSplit.WindowState = FormWindowState.Minimized Then
                            frmEngMPOPlanedSplit.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmRawMaterialAnalyze"
                        frmRawMaterialAnalyze.Show()
                        If frmRawMaterialAnalyze.WindowState = FormWindowState.Minimized Then
                            frmRawMaterialAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmProductionAnalize"
                        frmProductionAnalize.Show()
                        If frmProductionAnalize.WindowState = FormWindowState.Minimized Then
                            frmProductionAnalize.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngBlankIndex"
                        frmEngBlankIndex.ShowDialog()
                        If frmEngBlankIndex.WindowState = FormWindowState.Minimized Then
                            frmEngBlankIndex.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngBlankDia"
                        frmEngBlankDia.ShowDialog()
                        If frmEngBlankDia.WindowState = FormWindowState.Minimized Then
                            frmEngBlankDia.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmReleaseBlanks"
                        frmReleaseBlanks.Show()
                        If frmReleaseBlanks.WindowState = FormWindowState.Minimized Then
                            frmReleaseBlanks.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmEngPartMasterList"
                        frmEngPartMasterList.Show()
                        If frmEngPartMasterList.WindowState = FormWindowState.Minimized Then
                            frmEngPartMasterList.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmLisiQualityIndicators"
                        frmLisiQualityIndicators.Show()
                        If frmLisiQualityIndicators.WindowState = FormWindowState.Minimized Then
                            frmLisiQualityIndicators.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmAccAddRMSPrice"
                        frmAccAddRMSPrice.Show()
                        If frmAccAddRMSPrice.WindowState = FormWindowState.Minimized Then
                            frmAccAddRMSPrice.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmAccUploadCorpData"
                        frmAccUploadCorpData.Show()
                        If frmAccUploadCorpData.WindowState = FormWindowState.Minimized Then
                            frmAccUploadCorpData.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMPOCostAnalyze"
                        frmMPOCostAnalyze.Show()
                        If frmMPOCostAnalyze.WindowState = FormWindowState.Minimized Then
                            frmMPOCostAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPartCreateCrossRef"
                        frmPartCreateCrossRef.Show()
                        If frmPartCreateCrossRef.WindowState = FormWindowState.Minimized Then
                            frmPartCreateCrossRef.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmAccHeadOfficeStatistics"
                        frmAccHeadOfficeStatistics.Show()
                        If frmAccHeadOfficeStatistics.WindowState = FormWindowState.Minimized Then
                            frmAccHeadOfficeStatistics.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMaintEquipmentsModule"
                        frmMaintEquipmentsModule.Show()
                        If frmMaintEquipmentsModule.WindowState = FormWindowState.Minimized Then
                            frmMaintEquipmentsModule.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmHSEImportWordDoc"
                        frmHSEImportWordDoc.Show()
                        If frmHSEImportWordDoc.WindowState = FormWindowState.Minimized Then
                            frmHSEImportWordDoc.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmHSEReadDocuments"
                        frmHSEReadDocuments.Show()
                        If frmHSEReadDocuments.WindowState = FormWindowState.Minimized Then
                            frmHSEReadDocuments.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmStQuote"
                        frmStQuote.Show()
                        If frmStQuote.WindowState = FormWindowState.Minimized Then
                            frmStQuote.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMaintTaskInfo"
                        frmMaintTaskInfo.ShowDialog()
                        If frmMaintTaskInfo.WindowState = FormWindowState.Minimized Then
                            frmMaintTaskInfo.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMaintEquipInfo"
                        frmMaintEquipInfo.ShowDialog()
                        If frmMaintEquipInfo.WindowState = FormWindowState.Minimized Then
                            frmMaintEquipInfo.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmMaintProductCatalog"
                        frmMaintProductCatalog.ShowDialog()
                        If frmMaintProductCatalog.WindowState = FormWindowState.Minimized Then
                            frmMaintProductCatalog.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmAccHeadOfficeLACQueries"
                        frmAccHeadOfficeLACQueries.ShowDialog()
                        If frmAccHeadOfficeLACQueries.WindowState = FormWindowState.Minimized Then
                            frmAccHeadOfficeLACQueries.WindowState = FormWindowState.Normal
                        End If

                        'Case Is = "frmAccInterCoInvoices"
                        '    frmAccInterCoInvoices.ShowDialog()
                        '    If frmAccInterCoInvoices.WindowState = FormWindowState.Minimized Then
                        '        frmAccInterCoInvoices.WindowState = FormWindowState.Normal
                        '    End If

                    Case Is = "frmAccUploadInvoicesintoM3"
                        frmAccUploadInvoicesintoM3.ShowDialog()
                        If frmAccUploadInvoicesintoM3.WindowState = FormWindowState.Minimized Then
                            frmAccUploadInvoicesintoM3.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmLNAAnalyze"
                        frmLNAAnalyze.Show()
                        If frmLNAAnalyze.WindowState = FormWindowState.Minimized Then
                            frmLNAAnalyze.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmLNALoadMiMax"
                        frmLNALoadMiMax.Show()
                        If frmLNALoadMiMax.WindowState = FormWindowState.Minimized Then
                            frmLNALoadMiMax.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmPartToolBox"
                        frmPartToolBox.Show()
                        If frmPartToolBox.WindowState = FormWindowState.Minimized Then
                            frmPartToolBox.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmProdFirstRelease"
                        frmProdFirstRelease.Show()
                        If frmProdFirstRelease.WindowState = FormWindowState.Minimized Then
                            frmProdFirstRelease.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmOperatorsPay"
                        'frmOperatorsPay.Show()
                        'If frmOperatorsPay.WindowState = FormWindowState.Minimized Then
                        'frmOperatorsPay.WindowState = FormWindowState.Normal
                        'End If

                    Case Is = "frmEngRequestForMaterial"
                        frmEngRequestForMaterial.Show()
                        If frmEngRequestForMaterial.WindowState = FormWindowState.Minimized Then
                            frmEngRequestForMaterial.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmReceivingPerishable"
                        frmReceivingPerishable.Show()
                        If frmReceivingPerishable.WindowState = FormWindowState.Minimized Then
                            frmReceivingPerishable.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmReleasePerishable"
                        frmReleasePerishable.Show()
                        If frmReleasePerishable.WindowState = FormWindowState.Minimized Then
                            frmReleasePerishable.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "frmBarCodeMBO"
                        frmBarCodeMBO.Show()
                        If frmBarCodeMBO.WindowState = FormWindowState.Minimized Then
                            frmBarCodeMBO.WindowState = FormWindowState.Normal
                        End If

                    Case Is = "rptPOPrintAll"
                        Dim rptPO As New rptPOPrintAll()
                        rptPO.Load("..\rptPOPrintAll.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptPrintPOBySupp"
                        Dim rptPO As New rptPrintPOBySupp()
                        rptPO.Load("..\rptPrintPOBySupp.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptQuoteListByCust"
                        Dim rptPO As New rptQuoteListByCust()
                        rptPO.Load("..\rptQuoteListByCust.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptQuoteListByPart"
                        Dim rptPO As New rptQuoteListByPart()
                        rptPO.Load("..\ rptQuoteListByPart.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptRawMatRecvTranz"
                        Dim rptPO As New rptRawMatRecvTranz
                        rptPO.Load("..\rptRawMatRecvTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptRawMatlRelTranz"
                        Dim rptPO As New rptRawMatlRelTranz
                        rptPO.Load("..\rptRawMatlRelTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptRawMatlRelTranzAll"
                        Dim rptPO As New rptRawMatlRelTranzAll
                        rptPO.Load("..\rptRawMatlRelTranzAll.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptRawMatlAdjTranz"
                        Dim rptPO As New rptRawMatlAdjTranz
                        rptPO.Load("..\rptRawMatlAdjTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvRawMaterial"
                        Dim rptPO As New rptInvRawMaterial
                        rptPO.Load("..\rptInvRawMaterial.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptMatlLotNumber"
                        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues
                        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue
                        Dim rptPO As New rptMatlLotNumber

                        txtPrint.Text = "M1"

                        rptPO.Load("..\rptMatlLotNumber.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        pdvCustomerName.Value = txtPrint.Text
                        pvCollection.Add(pdvCustomerName)
                        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

                        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                        frmPOMasterPrint.ShowDialog()

                    Case Is = "rptWIPSummary"
                        Dim rptPO As New rptWIPSummary
                        rptPO.Load("..\rptWIPSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptWIPDetail"
                        Dim rptPO As New rptWIPDetail
                        rptPO.Load("..\rptWIPDetail.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptShopFloorByDept"
                        Dim rptPO As New rptShopFloorByDept
                        rptPO.Load("..\rptShopFloorByDept.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptShopFloorByDeptByValue"
                        Dim rptPO As New rptShopFloorByDeptByValue
                        rptPO.Load("..\rptShopFloorByDeptByValue.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptShopFloorByDeptSummaryByValue"
                        Dim rptPO As New rptShopFloorByDeptSummaryByValue
                        rptPO.Load("..\rptShopFloorByDeptSummaryByValue.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptCustOrderActive"
                        Dim rptPO As New rptCustOrderActive
                        rptPO.Load("..\rptCustOrderActive.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptCustOrderActiveForecastByDelDate"
                        Dim rptPO As New rptCustOrderActiveForecastByDelDate
                        rptPO.Load("..\rptCustOrderActiveForecastByDelDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptCustOrderActiveForecastByDelDateSummary"
                        Dim rptPO As New rptCustOrderActiveForecastByDelDateSummary
                        rptPO.Load("..\rptCustOrderActiveForecastByDelDateSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptCustOrderActiveForecastByDelDateAndPartNo"
                        Dim rptPO As New rptCustOrderActiveForecastByDelDateAndPartNo
                        rptPO.Load("..\rptCustOrderActiveForecastByDelDateAndPartNo.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptInvRawMaterialKSI"
                        Dim rptPO As New rptInvRawMaterialKSI
                        rptPO.Load("..\rptInvRawMaterialKSI.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()


                    Case Is = "rptCustOrderActiveBookingByOderDate"
                        Dim rptPO As New rptCustOrderActiveBookingByOderDate
                        rptPO.Load("..\rptCustOrderActiveBookingByOderDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptPartMasterListMpoLink"
                        Dim rptPO As New rptPartMasterListMpoLink
                        rptPO.Load("..\rptPartMasterListMpoLink.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptFinishPartsRecvTranz"
                        Dim rptPO As New rptFinishPartsRecvTranz
                        rptPO.Load("..\rptFinishPartsRecvTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptFinishPartsReleaseTranz_FromLNA_TransferStock"
                        Dim rptPO As New rptFinishPartsReleaseTranz_FromLNA_TransferStock
                        rptPO.Load("..\rptFinishPartsReleaseTranz_FromLNA_TransferStock.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptFinishPartsReleaseTranz"
                        Dim rptPO As New rptFinishPartsReleaseTranz
                        rptPO.Load("..\rptFinishPartsReleaseTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptFinishPartsInventoryList"
                        Dim rptPO As New rptFinishPartsInventoryList
                        rptPO.Load("..\rptFinishPartsInventoryList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptMPOMatlLotNo"
                        Dim rptPO As New rptMPOMatlLotNo
                        rptPO.Load("..\rptMPOMatlLotNo.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.Show()

                    Case Is = "rptPrintPOByType"
                        Dim rptPO As New rptPrintPOByType
                        rptPO.Load("..\rptPrintPOByType.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustOrderActiveBookingByOderDateSummary"
                        Dim rptPO As New rptCustOrderActiveBookingByOderDateSummary
                        rptPO.Load("..\rptCustOrderActiveBookingByOderDateSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        'frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvoiceList"
                        Dim rptPO As New rptInvoiceList
                        rptPO.Load("..\rptInvoiceList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvoiceListByCust"
                        Dim rptPO As New rptInvoiceListByCust
                        rptPO.Load("..\rptInvoiceListByCust.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsAdjTranz"
                        Dim rptPO As New rptFinishPartsAdjTranz
                        rptPO.Load("..\rptFinishPartsAdjTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustOrderActiveForecastByPartNoMpoNo"
                        Dim rptPO As New rptCustOrderActiveForecastByPartNoMpoNo
                        rptPO.Load("..\rptCustOrderActiveForecastByPartNoMpoNo.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPrintPOByGLAccount"
                        Dim rptPO As New rptPrintPOByGLAccount
                        rptPO.Load("..\rptPrintPOByGLAccount.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustomerList"
                        Dim rptPO As New rptCustomerList
                        rptPO.Load("..\rptCustomerList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvoiceListByCustSummary"
                        Dim rptPO As New rptInvoiceListByCustSummary
                        rptPO.Load("..\rptInvoiceListByCustSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptSuppApprovedList"
                        Dim rptPO As New rptSuppApprovedList
                        rptPO.Load("..\rptSuppApprovedList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustOrderActiveForecastByPartAndDelDateProduction"
                        Dim rptPO As New rptCustOrderActiveForecastByPartAndDelDateProduction
                        rptPO.Load("..\rptCustOrderActiveForecastByPartAndDelDateProduction.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustOrderActiveForecastByPartAndDelDateProduction_LNAOnlyVer2"
                        Dim rptPO As New rptCustOrderActiveForecastByPartAndDelDateProduction_LNAOnlyVer2
                        rptPO.Load("..\rptCustOrderActiveForecastByPartAndDelDateProduction_LNAOnlyVer2.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptRawMatReceivigByPeriode"
                        Dim rptPO As New rptRawMatReceivigByPeriode
                        rptPO.Load("..\rptRawMatReceivigByPeriode.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptWIPDetailOrderByMpoDate"
                        Dim rptPO As New rptWIPDetailOrderByMpoDate
                        rptPO.Load("..\rptWIPDetailOrderByMpoDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPrintPOByGLAccountSummary"
                        Dim rptPO As New rptPrintPOByGLAccountSummary
                        rptPO.Load("..\rptPrintPOByGLAccountSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPrintPOByGLAccountSupplierSummary"
                        Dim rptPO As New rptPrintPOByGLAccountSupplierSummary
                        rptPO.Load("..\rptPrintPOByGLAccountSupplierSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptBarCodeByEmpPeriode24Hrs"
                        Dim rptPO As New rptBarCodeByEmpPeriode24Hrs
                        rptPO.Load("..\rptBarCodeByEmpPeriode24Hrs.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptBarCodeByMpoPeriode"
                        Dim rptPO As New rptBarCodeByMpoPeriode
                        rptPO.Load("..\rptBarCodeByMpoPeriode.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptBarCodeByValMBOPeriode24Hrs"
                        Dim rptPO As New rptBarCodeByValMBOPeriode24Hrs
                        rptPO.Load("..\rptBarCodeByValMBOPeriode24Hrs.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByEntryDateAndCustomer"
                        Dim rptPO As New rptFinishPartsInvListOrderByEntryDateAndCustomer
                        rptPO.Load("..\rptFinishPartsInvListOrderByEntryDateAndCustomer.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptProdMachLoad"
                        Dim rptPO As New rptProdMachLoad
                        rptPO.Load("..\rptProdMachLoad.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPrintPOReceivingByPeriode"
                        Dim rptPO As New rptPrintPOReceivingByPeriode
                        rptPO.Load("..\rptPrintPOReceivingByPeriode.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByEntryDate"
                        Dim rptPO As New rptFinishPartsInvListOrderByEntryDate
                        rptPO.Load("..\rptFinishPartsInvListOrderByEntryDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFPInventoryListGroupByPartNo"
                        Dim rptPO As New rptFPInventoryListGroupByPartNo
                        rptPO.Load("..\rptFPInventoryListGroupByPartNo.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByLocation"
                        Dim rptPO As New rptFinishPartsInvListOrderByLocation
                        rptPO.Load("..\rptFinishPartsInvListOrderByLocation.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptRawMatlToContractAllWIPProdandEng"
                        Dim rptPO As New rptRawMatlToContractAllWIPProdandEng
                        rptPO.Load("..\rptRawMatlToContractAllWIPProdandEng.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInventoryListWithCost"
                        Dim rptPO As New rptFinishPartsInventoryListWithCost
                        rptPO.Load("..\rptFinishPartsInventoryListWithCost.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptWIPDetailWithCost"
                        Dim rptPO As New rptWIPDetailWithCost
                        rptPO.Load("..\rptWIPDetailWithCost.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPrintPOPriceCorrection"
                        Dim rptPO As New rptPrintPOPriceCorrection
                        rptPO.Load("..\rptPrintPOPriceCorrection.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptCustOrderActiveForecastByMPODeliveryDate"
                        Dim rptPO As New rptCustOrderActiveForecastByMPODeliveryDate
                        rptPO.Load("..\rptCustOrderActiveForecastByMPODeliveryDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptShopArticleTotalCycle"
                        Dim rptPO As New rptShopArticleTotalCycle
                        rptPO.Load("..\rptShopArticleTotalCycle.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptSupplierCycleDelivery"
                        Dim rptPO As New rptSupplierCycleDelivery
                        rptPO.Load("..\rptSupplierCycleDelivery.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsRecvBlanksTranz"
                        Dim rptPO As New rptFinishPartsRecvBlanksTranz
                        rptPO.Load("..\rptFinishPartsRecvBlanksTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsReleaseBlanksTranz"
                        Dim rptPO As New rptFinishPartsReleaseBlanksTranz
                        rptPO.Load("..\rptFinishPartsReleaseBlanksTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsAdjBlanksTranz"
                        Dim rptPO As New rptFinishPartsAdjBlanksTranz
                        rptPO.Load("..\rptFinishPartsAdjBlanksTranz.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsBlanksInventoryList"
                        Dim rptPO As New rptFinishPartsBlanksInventoryList
                        rptPO.Load("..\rptFinishPartsBlanksInventoryList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptWIPDetailOrderByActualQty"
                        Dim rptPO As New rptWIPDetailOrderByActualQty
                        rptPO.Load("..\rptWIPDetailOrderByActualQty.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptWIPDetailOrderByValue"
                        Dim rptPO As New rptWIPDetailOrderByValue
                        rptPO.Load("..\rptWIPDetailOrderByValue.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByStockQty"
                        Dim rptPO As New rptFinishPartsInvListOrderByStockQty
                        rptPO.Load("..\rptFinishPartsInvListOrderByStockQty.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByStockValue"
                        Dim rptPO As New rptFinishPartsInvListOrderByStockValue
                        rptPO.Load("..\rptFinishPartsInvListOrderByStockValue.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvRawMaterialByStockQty"
                        Dim rptPO As New rptInvRawMaterialByStockQty
                        rptPO.Load("..\rptInvRawMaterialByStockQty.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvRawMaterialByStockValue"
                        Dim rptPO As New rptInvRawMaterialByStockValue
                        rptPO.Load("..\rptInvRawMaterialByStockValue.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvoiceByCustomerYD"
                        Dim rptPO As New rptInvoiceByCustomerYD
                        rptPO.Load("..\rptInvoiceByCustomerYD.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "CrptPOAnalyzeSubContracting"
                        Dim rptPO As New CrptPOAnalyzeSubContracting
                        rptPO.Load("..\CrptPOAnalyzeSubContracting.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.Show()

                    Case Is = "rptAccReceivedAndNotPaid"
                        Dim rptPO As New rptAccReceivedAndNotPaid
                        rptPO.Load("..\rptAccReceivedAndNotPaid.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.Show()

                    Case Is = "rptInvoiceListNotPosted"
                        Dim rptPO As New rptInvoiceListNotPosted
                        rptPO.Load("..\rptInvoiceListNotPosted.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvRawMaterialByDateandKSI"
                        Dim rptPO As New rptInvRawMaterialByDateandKSI
                        rptPO.Load("..\rptInvRawMaterialByDateandKSI.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.Show()

                    Case Is = "rptMPOCostMachiningTime"
                        Dim rptPO As New rptMPOCostMachiningTime
                        rptPO.Load("..\rptMPOCostMachiningTime.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.Show()

                    Case Is = "rptMpoActualQtyChg"
                        Dim rptPO As New rptMpoActualQtyChg
                        rptPO.Load("..\rptMpoActualQtyChg.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.Show()

                    Case Is = "rptInvoiceListWithCost"
                        Dim rptPO As New rptInvoiceListWithCost
                        rptPO.Load("..\rptInvoiceListWithCost.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()
                    Case Is = "rptWIPDetailOrderByMpoDateByCustomer"
                        Dim rptPO As New rptWIPDetailOrderByMpoDateByCustomer
                        rptPO.Load("..\rptWIPDetailOrderByMpoDateByCustomer.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByDeliveryDate"
                        Dim rptPO As New rptFinishPartsInvListOrderByDeliveryDate
                        rptPO.Load("..\rptFinishPartsInvListOrderByDeliveryDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInvListOrderByPartNumber"
                        Dim rptPO As New rptFinishPartsInvListOrderByPartNumber
                        rptPO.Load("..\rptFinishPartsInvListOrderByPartNumber.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptRawMatlBRFSummary"
                        Dim rptPO As New rptRawMatlBRFSummary
                        rptPO.Load("..\rptRawMatlBRFSummary.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptSuppApprovedListWithRating"
                        Dim rptPO As New rptSuppApprovedListWithRating
                        rptPO.Load("..\rptSuppApprovedListWithRating.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptSalesPlanningFPInventory"
                        Dim rptPO As New rptSalesPlanningFPInventory
                        rptPO.Load("..\rptSalesPlanningFPInventory.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPartFromBlanks"
                        Dim rptPO As New rptPartFromBlanks
                        rptPO.Load("..\rptPartFromBlanks.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptSalesPlanningFPInventoryByDeliveryDate"
                        Dim rptPO As New rptSalesPlanningFPInventoryByDeliveryDate
                        rptPO.Load("..\rptSalesPlanningFPInventoryByDeliveryDate.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvoiceListWithCostByCustandPeriod"
                        Dim rptPO As New rptInvoiceListWithCostByCustandPeriod
                        rptPO.Load("..\rptInvoiceListWithCostByCustandPeriod.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsRecvTranzAll"
                        Dim rptPO As New rptFinishPartsRecvTranzAll
                        rptPO.Load("..\rptFinishPartsRecvTranzAll.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsBlanksInventoryListAsMovex"
                        Dim rptPO As New rptFinishPartsBlanksInventoryListAsMovex
                        rptPO.Load("..\rptFinishPartsBlanksInventoryListAsMovex.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptInvRawMaterialAsMovex"
                        Dim rptPO As New rptInvRawMaterialAsMovex
                        rptPO.Load("..\rptInvRawMaterialAsMovex.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInventoryListWithCostAsMovex_2"
                        Dim rptPO As New rptFinishPartsInventoryListWithCostAsMovex_2
                        rptPO.Load("..\rptFinishPartsInventoryListWithCostAsMovex_2.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInventoryListWithCostAsMovexStdPrice"
                        Dim rptPO As New rptFinishPartsInventoryListWithCostAsMovexStdPrice
                        rptPO.Load("..\rptFinishPartsInventoryListWithCostAsMovexStdPrice.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment"
                        Dim rptPO As New rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment
                        rptPO.Load("..\rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment_Ver2"
                        Dim rptPO As New rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment_Ver2
                        rptPO.Load("..\rptFinishPartsInventoryListWithCostAsMovex_LNA_Shipment_Ver2.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptQuoteSuccessYD"
                        Dim rptPO As New rptQuoteSuccessYD
                        rptPO.Load("..\rptQuoteSuccessYD.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPerishableReceiving"
                        Dim rptPO As New rptPerishableReceiving
                        rptPO.Load("..\rptPerishableReceiving.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPerishableRelease"
                        Dim rptPO As New rptPerishableRelease
                        rptPO.Load("..\rptPerishableRelease.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                    Case Is = "rptPerishableInventoryList"
                        Dim rptPO As New rptPerishableInventoryList
                        rptPO.Load("..\rptPerishableInventoryList.rpt")
                        rptPO.ReportOptions.EnableSaveDataWithReport = False
                        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
                        frmPOPrintAll.CrystalReportViewer1.Zoom(1)
                        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
                        frmPOPrintAll.ShowDialog()

                End Select

            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        frmLogin.Hide()
        GC.Collect()
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()
        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        Dim tn As TreeNodeCollection
        tn = TreeView1.Nodes

        'Remove Parrents Nodes & Childs Nodes

        If RolePayRoll(wkDeptCode) = False Then
            tn.Item("Pay").Remove()
        End If

        If RolePerishable(wkDeptCode) = False Then
            tn.Item("Perishable").Remove()
        End If

        If RoleRMREQPO(wkDeptCode) = False And RoleRMREQAPPR(wkDeptCode) = False Then
            tn.Item("frmEngRequestForMaterial").Remove()
        End If

        If RoleSubAnalyze(wkDeptCode) = True Then
            tn.Item("Acc").Nodes.Item("frmAccUploadInvoicesintoM3").Remove()
            tn.Item("Acc").Nodes.Item("frmAccUploadCorpData").Remove()
        End If


        Select Case wkAccess
            Case 0      'general access                
            Case 1      'management

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()

                tn.Item("CustOrd").Nodes.Item("frmOrderEntryM3CODO").Remove()
                tn.Item("CustOrd").Nodes.Item("frmCustUpdateBudget").Remove()
                tn.Item("CustOrd").Nodes.Item("frmMPOGenfromOrder").Remove()
                tn.Item("CustOrd").Nodes.Item("frmOrderAssignDellivToMPO").Remove()
                tn.Item("CustOrd").Nodes.Item("OrdRep").Remove()

                tn.Item("Eng").Remove()

                If RoleReceivingMenu(wkDeptCode) = False Then
                    tn.Item("Exp").Remove()
                Else
                    tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                    tn.Item("Exp").Nodes.Item("frmSalesPSlip").Remove()
                End If


                If RoleMaint(wkDeptCode) = False Then
                    tn.Item("Maint").Remove()
                Else
                    tn.Item("Maint").Nodes.Item("MaintFrms").Remove()
                End If

                If RoleToolBox(wkDeptCode) = False Then
                    tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                End If

                If RoleSalesMng(wkDeptCode) = True Then     ' sales mng
                    tn.Item("MNG").Remove()
                    tn.Item("frmLisiQualityIndicators").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmMpoGenFromOrder").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmOrderAssignDellivToMPO").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()

                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("QC").Remove()
                    tn.Item("Sales").Remove()
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                    tn.Item("Pay").Remove()
                Else                                        ' other mng
                    If RoleMngMenu(wkDeptCode) = False Then
                        tn.Item("MNG").Remove()
                        tn.Item("RFQ").Remove()
                    End If
                    If RoleQA(wkDeptCode) = False Then
                        tn.Item("frmLisiQualityIndicators").Remove()
                    End If
                    tn.Item("CustOrd").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("QC").Remove()
                    tn.Item("Sales").Remove()
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                End If

            Case 2  'accounting
                tn.Item("Maint").Remove()
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("CustOrd").Nodes.Item("frmOrderEntryM3CODO").Remove()

                If RoleMngMenu(wkDeptCode) = True Then
                    tn.Item("Admin").Remove()
                    tn.Item("Eng").Remove()
                    If RoleAcc(wkDeptCode) = False Then
                        tn.Item("Acc").Remove()
                        tn.Item("CustOrd").Remove()
                    Else
                        tn.Item("Acc").Nodes.Item("frmAccPayable").Remove()
                        tn.Item("Acc").Nodes.Item("frmCloseMonth").Remove()
                        tn.Item("Acc").Nodes.Item("frmAccAddRMSPrice").Remove()
                        tn.Item("Acc").Nodes.Item("frmAccUploadInvoicesintoM3").Remove()

                        tn.Item("CustOrd").Nodes.Item("frmCustUpdateBudget").Remove()
                        tn.Item("CustOrd").Nodes.Item("frmOrderEntry").Remove()
                        tn.Item("CustOrd").Nodes.Item("frmMpoGenFromOrder").Remove()
                        tn.Item("CustOrd").Nodes.Item("frmOrderAssignDellivToMPO").Remove()
                        tn.Item("CustOrd").Nodes.Item("OrdRep").Remove()
                    End If

                    tn.Item("Exp").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("RFQ").Nodes.Item("frmQuote").Remove()
                    tn.Item("RFQ").Nodes.Item("frmQuoteEngEst").Remove()
                    tn.Item("RFQ").Nodes.Item("frmQuoteAnalyzeM3").Remove()
                    tn.Item("QC").Remove()
                    tn.Item("Sales").Remove()
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                    tn.Item("frmLisiQualityIndicators").Remove()
                Else
                    tn.Item("Acc").Nodes.Item("frmCloseMonth").Remove()

                    ' tn.Item("Acc").Nodes.Item("frmAccUploadInvoicesintoM3").Remove()
                    'tn.Item("Acc").Nodes.Item("frmAccUploadCorpData").Remove()

                    tn.Item("Admin").Remove()
                    tn.Item("Eng").Remove()
                    tn.Item("Mng").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmCustUpdateBudget").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmOrderEntry").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmMpoGenFromOrder").Remove()
                    tn.Item("CustOrd").Nodes.Item("frmOrderAssignDellivToMPO").Remove()
                    tn.Item("CustOrd").Nodes.Item("OrdRep").Remove()

                    tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                    tn.Item("Exp").Nodes.Item("frmSalesPSlip").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()

                    tn.Item("RFQ").Nodes.Item("frmQuote").Remove()
                    tn.Item("RFQ").Nodes.Item("frmQuoteEngEst").Remove()
                    tn.Item("RFQ").Nodes.Item("frmQuoteAnalyzeM3").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("QC").Remove()
                    tn.Item("Sales").Remove()
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                    tn.Item("frmLisiQualityIndicators").Remove()
                End If

            Case 3  'production, planning
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()
                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Exp").Remove()
                tn.Item("CustOrd").Remove()

                tn.Item("Mng").Remove()
                'tn.Item("Eng").Nodes.Item("frmReleaseRawMaterial").Remove()
                tn.Item("Eng").Nodes.Item("frmEngMatlType").Remove()
                'tn.Item("Eng").Nodes.Item("frmPartMaster").Remove()
                tn.Item("Eng").Nodes.Item("frmEngSpecList").Remove()
                tn.Item("Eng").Nodes.Item("frmCostEstimation").Remove()
                tn.Item("Eng").Nodes.Item("EngMaint").Remove()
                tn.Item("Eng").Nodes.Item("frmEngMPOPlanedSplit").Remove()
                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("Sales").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 4      'inspection
                tn.Item("Maint").Remove()
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("CustOrd").Nodes.Item("frmOrderEntryM3CODO").Remove()

                If RoleQCForms(wkDeptCode) = True Or RoleHSEForms(wkDeptCode) = True Then
                    tn.Item("Acc").Remove()
                    tn.Item("Admin").Remove()
                    tn.Item("CustOrd").Remove()
                    tn.Item("Eng").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                    tn.Item("Exp").Nodes.Item("frmSalesPSlip").Remove()
                    tn.Item("Mng").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("RFQ").Remove()
                    tn.Item("QC").Nodes.Item("DataMaint").Remove()
                    tn.Item("QC").Nodes.Item("frmRawMatlAdj").Remove()
                    tn.Item("QC").Nodes.Item("frmPoRecvInsp").Remove()
                    'tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    'tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                    tn.Item("Sales").Remove()
                    If RoleQA(wkDeptCode) = False Then
                        tn.Item("frmLisiQualityIndicators").Remove()
                    End If

                Else
                    tn.Item("Acc").Remove()
                    tn.Item("Admin").Remove()
                    tn.Item("CustOrd").Remove()
                    tn.Item("Eng").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                    tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                    tn.Item("Exp").Nodes.Item("frmSalesPSlip").Remove()
                    tn.Item("Mng").Remove()
                    tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                    tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                    tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                    tn.Item("RFQ").Remove()
                    tn.Item("QC").Nodes.Item("DataMaint").Remove()
                    tn.Item("QC").Nodes.Item("frmRawMatlAdj").Remove()
                    tn.Item("QC").Nodes.Item("frmPoRecvInsp").Remove()
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                    tn.Item("Sales").Remove()
                    If RoleQA(wkDeptCode) = False Then
                        tn.Item("frmLisiQualityIndicators").Remove()
                    End If
                End If

            Case 5      'tooling & maintenance

                tn.Item("Maint").Remove()
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Mng").Remove()
                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                tn.Item("Sales").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 6      'sales marketing

                If RoleDOCO(wkDeptCode) = False Then
                    tn.Item("CustOrd").Nodes.Item("frmOrderEntryM3CODO").Remove()
                End If

                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                tn.Item("Exp").Nodes.Item("frmPOReceiving").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("Mng").Remove()
                tn.Item("QC").Remove()
                tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 7      'Engeneering
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()

                If RoleMaint(wkDeptCode) = False Then
                    tn.Item("Maint").Remove()
                End If

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Exp").Remove()

                If RoleMngMenu(wkDeptCode) = False Then
                    tn.Item("MNG").Remove()
                End If

                tn.Item("CustOrd").Remove()
                tn.Item("RFQ").Nodes.Item("frmQuote").Remove()
                tn.Item("RFQ").Nodes.Item("frmQuoteAnalyzeM3").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("QC").Remove()
                tn.Item("Sales").Remove()
                'tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                If RoleQA(wkDeptCode) = False Then
                    tn.Item("frmLisiQualityIndicators").Remove()
                End If

                If RoleQCForms(wkDeptCode) = False Or RoleHSEForms(wkDeptCode) = False Then
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                End If

            Case 8     'Expedition / Reception
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                tn.Item("Mng").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                tn.Item("RFQ").Remove()
                tn.Item("QC").Nodes.Item("DataMaint").Remove()
                tn.Item("QC").Nodes.Item("frmRawMatlAdj").Remove()
                tn.Item("QC").Nodes.Item("frmPoRecvInsp").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("Sales").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 9     'Production Users Lisi Shop
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Cust").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Mng").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("Inv").Remove()
                tn.Item("Sales").Remove()
                tn.Item("PurCtl").Remove()
                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("Supp").Remove()
                tn.Item("ForecastSales").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

                If RoleMaint(wkDeptCode) = True Then
                    tn.Item("Maint").Nodes.Item("MaintFrms").Remove()
                End If

            Case 11      'inspection Chief and RM Chief
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Nodes.Item("frmEngMatlType").Remove()
                tn.Item("Eng").Nodes.Item("frmPartMaster").Remove()
                tn.Item("Eng").Nodes.Item("frmEngSpecList").Remove()
                tn.Item("Eng").Nodes.Item("frmCostEstimation").Remove()
                tn.Item("Eng").Nodes.Item("EngMaint").Remove()
                tn.Item("Eng").Nodes.Item("frmEngMPOPlanedSplit").Remove()

                tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()

                tn.Item("Mng").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("RFQ").Remove()
                'tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("Sales").Remove()

                If RoleQA(wkDeptCode) = False Then
                    tn.Item("frmLisiQualityIndicators").Remove()
                End If

                If RoleQCForms(wkDeptCode) = False Or RoleHSEForms(wkDeptCode) = False Then
                    tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                    tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                End If

            Case 10      'grcomm100  comercial group from lisi
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Cust").Remove()
                tn.Item("CustOrd").Nodes.Item("frmMPOGenfromOrder").Remove()
                tn.Item("CustOrd").Nodes.Item("frmCustUpdateBudget").Remove()
                tn.Item("CustOrd").Nodes.Item("frmOrderAssignDellivToMPO").Remove()
                tn.Item("CustOrd").Nodes.Item("OrdRep").Remove()
                tn.Item("CustOrd").Nodes.Item("frmAccHeadOfficeStatistics").Remove()
                tn.Item("CustOrd").Nodes.Item("frmBackLogAnalyze").Remove()
                tn.Item("CustOrd").Nodes.Item("frmOrderEntryM3CODO").Remove()

                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Mng").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("Prod").Nodes.Item("frmReleaseBlanks.xxx").Remove()
                tn.Item("Prod").Nodes.Item("frmReleaseRawMaterial").Remove()
                tn.Item("Prod").Nodes.Item("frmRawMaterialAnalyze").Remove()
                tn.Item("Prod").Nodes.Item("frmShopFloorControl").Remove()

                tn.Item("Inv").Nodes.Item("Prod").Remove()
                tn.Item("Inv").Nodes.Item("Shop").Remove()
                tn.Item("Inv").Nodes.Item("ForwardForecast").Nodes.Item("rptCustOrderActiveForecastByDelDateAndPartNo").Remove()
                tn.Item("Inv").Nodes.Item("ForwardForecast").Nodes.Item("rptCustOrderActiveForecastByPartNoMpoNo").Remove()
                tn.Item("Inv").Nodes.Item("rptPartFromBlanks").Remove()
                tn.Item("Inv").Nodes.Item("InvCheck").Remove()
                tn.Item("Inv").Nodes.Item("Billing").Remove()
                'tn.Item("Inv").Nodes.Item("INVFP").Nodes.Item("rptFinishPartsInvListOrderByLocation").Remove()
                'tn.Item("Inv").Nodes.Item("Raw").Nodes.Item("rptRawMatRecvTranz").Remove()
                'tn.Item("Inv").Nodes.Item("Raw").Nodes.Item("rptRawMatlRelTranz").Remove()
                'tn.Item("Inv").Nodes.Item("Raw").Nodes.Item("rptRawMatlAdjTranz").Remove()

                'tn.Item("Prod").Nodes.Item("frmReleaseRawMaterial").Remove()

                tn.Item("PurCtl").Nodes.Item("frmPOMaster").Remove()
                tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                tn.Item("PurCtl").Nodes.Item("PurCtlReports").Nodes.Item("rptPrintPOReceivingByPeriode").Remove()

                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("QD").Remove()
                tn.Item("HSE").Remove()
                tn.Item("Sales").Remove()

                tn.Item("ForecastSales").Nodes.Item("frmSalesForecast").Remove()
                tn.Item("ForecastSales").Nodes.Item("frmSalesPlanningFPInventory").Remove()

                tn.Item("Supp").Remove()
                tn.Item("frmLisiMemoApp").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 12      'remove memo for Francis
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Nodes.Item("frmFPAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmFPReleaseToMPO").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlLotAdj").Remove()
                tn.Item("Exp").Nodes.Item("frmMatlPriceDepreciation").Remove()
                tn.Item("Exp").Nodes.Item("frmSalesPSlip").Remove()
                tn.Item("Mng").Remove()
                tn.Item("Prod").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("Prod").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("PurCtl").Nodes.Item("frmEngRemarks").Remove()
                tn.Item("RFQ").Remove()
                tn.Item("QC").Nodes.Item("DataMaint").Remove()
                tn.Item("QC").Nodes.Item("frmRawMatlAdj").Remove()
                tn.Item("QC").Nodes.Item("frmPoRecvInsp").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Nodes.Item("HSEAD").Nodes.Item("frmHSEImportWordDoc").Remove()
                tn.Item("Sales").Remove()
                tn.Item("frmLisiMemoApp").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 13      'grcomm100  comercial group from lisi for quote system only
                tn.Item("Prod").Nodes.Item("frmPartToolBox").Remove()
                tn.Item("Maint").Remove()

                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Cust").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Mng").Remove()
                tn.Item("Prod").Remove()
                tn.Item("Inv").Remove()
                tn.Item("PurCtl").Remove()
                tn.Item("RFQ").Nodes.Item("frmQuoteAnalyze").Remove()
                tn.Item("RFQ").Nodes.Item("frmQuote").Remove()
                tn.Item("RFQ").Nodes.Item("frmQuoteEngEst").Remove()
                tn.Item("RFQ").Nodes.Item("Node0").Remove()
                tn.Item("QC").Remove()
                tn.Item("QD").Remove()
                tn.Item("HSE").Remove()
                tn.Item("Sales").Remove()
                tn.Item("ForecastSales").Remove()
                tn.Item("Supp").Remove()
                tn.Item("frmLisiMemoApp").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()

            Case 14      'sub-contracting access
                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("PurCtl").Remove()
                tn.Item("Prod").Remove()
                tn.Item("Maint").Remove()
                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Cust").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Inv").Remove()
                tn.Item("Mng").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Remove()
                tn.Item("Sales").Remove()
                tn.Item("ForecastSales").Remove()
                tn.Item("Supp").Remove()
                tn.Item("frmLisiMemoApp").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()
                tn.Item("frmEngRequestForMaterial").Remove()

            Case 15     'sub-contracting access
                tn.Item("RFQ").Remove()
                tn.Item("QC").Remove()
                tn.Item("PurCtl").Remove()
                tn.Item("PROD").Nodes.Item("frmReleaseRawMaterial").Remove()
                tn.Item("PROD").Nodes.Item("frmRawMaterialAnalyze").Remove()
                tn.Item("PROD").Nodes.Item("frmProductionAnalize").Remove()
                'tn.Item("PROD").Nodes.Item("frmBarCodeMBO").Remove()
                tn.Item("PROD").Nodes.Item("frmMatlLotStockNotes").Remove()
                tn.Item("PROD").Nodes.Item("frmPartMasterQuote").Remove()
                tn.Item("PROD").Nodes.Item("LNA").Remove()
                tn.Item("Maint").Remove()
                tn.Item("Acc").Remove()
                tn.Item("Admin").Remove()
                tn.Item("Cust").Remove()
                tn.Item("CustOrd").Remove()
                tn.Item("Eng").Remove()
                tn.Item("Exp").Remove()
                tn.Item("Inv").Remove()
                tn.Item("Mng").Remove()
                tn.Item("QD").Nodes.Item("DM").Nodes.Item("frmQAImportWordDoc").Remove()
                tn.Item("HSE").Remove()
                tn.Item("Sales").Remove()
                tn.Item("ForecastSales").Remove()
                tn.Item("Supp").Remove()
                'tn.Item("frmLisiMemoApp").Remove()
                tn.Item("frmLisiQualityIndicators").Remove()
                tn.Item("frmEngRequestForMaterial").Remove()

            Case Else
                MsgBox("Missing Access Rights. Action Denied.")
                Me.Dispose()

        End Select

    End Sub

    Function RolePerishable(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "PERISHABLE" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleQCForms(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "QCForms" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleHSEForms(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "HSEForms" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RolePayRoll(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "PAYROLL" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleSalesMng(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MNGSALES" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleToolBox(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "TOOLBOX" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleDOCO(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "DOCO" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleMngMenu(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MNGMENU" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleQA(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "QAIND" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleMaint(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MAINT" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleReceivingMenu(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MENURECV" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleAcc(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ACC" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleACCPAYABLE(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ACCPAYABLE" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RolePO(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "PO" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleRMREQPO(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RMREQPO" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleRMREQAPPR(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RMREQAPPR" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleSubAnalyze(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SUBAZ" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function


    'Private Function ParameterValues() As ParameterFields
    '    Throw New NotImplementedException
    'End Function

End Class


