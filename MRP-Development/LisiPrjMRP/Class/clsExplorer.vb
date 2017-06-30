'Option Strict On

'Imports System.Runtime.InteropServices
'Imports System.io
'Imports System.Management

'Namespace LisiExplorerClass
'    Public Class clsExplorer

'        Dim WithEvents lview As New clsfilelist
'        Dim WithEvents drlstbx As New clsdirlistbox
'        Dim WithEvents splt As New Splitter
'        Public Event FolderSelected(ByVal afolder As String)
'        Public Event FileSelected(ByVal aFileName As String)
'        Dim extensions As New ArrayList

'        Public Sub New(ByVal frm As Form, ByVal imglist As ImageList)

'            ' explorer takes all space from the form it resides in.
'            With drlstbx
'                ' Dock it at the left side of the form (its parent)
'                .Dock = DockStyle.Left
'                .Visible = True
'                .ImageList = imglist
'                .BringToFront()
'                .Open("", "")
'            End With

'            'put the splitter at the right of the dirlistbox,
'            ' i.e. at the left side of the form, which is already taken by the dirlistbox
'            ' the splitter has to stay with 1/3 and 2/3 of the available width
'            ' and its position is preset to the middle of the form
'            With splt
'                .Dock = DockStyle.Left
'                .Width = 4
'                .SplitPosition = frm.Width \ 2
'                .MinSize = frm.Width \ 3
'                .MinExtra = frm.Width \ 3
'            End With

'            With lview
'                .View = View.Details
'                .SmallImageList = imglist
'                .Dock = DockStyle.Fill
'                .AllowColumnReorder = True
'                .Visible = True
'            End With
'            ' add the controls to the form in the right sequence (right to left)
'            frm.Controls.Add(lview)
'            frm.Controls.Add(splt)
'            frm.Controls.Add(drlstbx)
'            ' do the formatting after the placement
'            With lview
'                .Columns.Add("name", .Width \ 2, HorizontalAlignment.Left)
'                .Columns.Add("size", .Width \ 4, HorizontalAlignment.Right)
'                .Columns.Add("modified", .Width \ 4, HorizontalAlignment.Left)
'                .AllowColumnReorder = True
'            End With
'        End Sub

'        Public Sub New(ByVal pnl As Panel, ByVal imglist As ImageList)
'            ' Here the explorer resides in a Panel!
'            ' explorer takes all space from the parent it resides in.
'            With lview
'                .View = View.Details
'                .SmallImageList = imglist
'                .Dock = DockStyle.Fill
'                .AllowColumnReorder = True
'                .Visible = True
'            End With

'            'put the splitter at the right of the dirlistbox,
'            ' i.e. at the left side of the form, which is already taken by the dirlistbox
'            ' the splitter has to stay with 1/3 and 2/3 of the available width
'            ' and its position is preset to the middle of the form 

'            With splt
'                .Dock = DockStyle.Left
'                .Width = 4
'                .SplitPosition = pnl.Width \ 2
'                .MinSize = pnl.Width \ 3
'                .MinExtra = pnl.Width \ 3
'            End With

'            With drlstbx
'                ' Dock it at the left side of its parent
'                .Dock = DockStyle.Left
'                .Visible = True
'                .ImageList = imglist
'                .BringToFront()
'                .Open("", "")
'            End With

'            pnl.Controls.Add(lview)
'            pnl.Controls.Add(splt)
'            pnl.Controls.Add(drlstbx)

'            ' add the controls to the panel in the right sequence (right to left)
'            ' do the formatting after the placement
'            With lview
'                .Columns.Add("name", .Width \ 2, HorizontalAlignment.Left)
'                .Columns.Add("size", .Width \ 4, HorizontalAlignment.Right)
'                .Columns.Add("modified", .Width \ 4, HorizontalAlignment.Left)
'                .AllowColumnReorder = True
'            End With
'        End Sub

'        Private Sub splt_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splt.SplitterMoved
'            Dim i As Integer = e.X
'            drlstbx.Width = e.X - 4
'            lview.Left = e.X + 4
'            Application.DoEvents()
'        End Sub

'        Private Sub dirlistbox_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles drlstbx.AfterSelect
'            Dim s As String = drlstbx.GetAbsoluteDirectory

'            lview.Items.Clear()
'            If s = "" Then Exit Sub
'            Dim ss As String = s
'            If Not ss.EndsWith(CChar("\")) Then ss = ss & "\"
'            Dim LVItem As ListViewItem
'            Dim flnfo As FileInfo
'            Dim FolderItems As String()
'            Dim i, j As Integer

'            Try
'                ' first get the sub folders
'                FolderItems = Directory.GetDirectories(s)
'                For i = 0 To FolderItems.GetLength(0) - 1
'                    FolderItems(i) = Path.GetFileName(FolderItems(i))
'                    LVItem = lview.Items.Add(FolderItems(i))
'                    LVItem.ImageIndex = 1
'                    LVItem.SubItems.Add(" ")
'                    flnfo = New FileInfo(ss & FolderItems(i))
'                    LVItem.SubItems.Add(Format(flnfo.LastWriteTime, "G"))
'                Next
'                ' next get the files
'                FolderItems = Directory.GetFiles(s)
'                For i = 0 To FolderItems.GetLength(0) - 1
'                    FolderItems(i) = Path.GetFileName(FolderItems(i))
'                    LVItem = lview.Items.Add(FolderItems(i))
'                    flnfo = New FileInfo(ss & FolderItems(i))
'                    j = CInt(flnfo.Length / 1024)
'                    If flnfo.Length > 0 And j = 0 Then j = 1
'                    LVItem.SubItems.Add(CStr(j) & " KB")
'                    LVItem.SubItems.Add(Format(flnfo.LastWriteTime, "G"))
'                    j = extensions.IndexOf(Path.GetExtension(FolderItems(i)))
'                    If j >= 0 Then
'                        LVItem.ImageIndex = 9 + j
'                    Else
'                        extensions.Add(Path.GetExtension(FolderItems(i)))
'                        lview.ImagelistAddFileIcon(FolderItems(i))
'                        LVItem.ImageIndex = lview.SmallImageList.Images.Count - 1
'                    End If
'                Next
'                RaiseEvent FolderSelected(ss)
'            Catch ex As Exception
'                MsgBox(ex.Message)
'            End Try
'        End Sub

'        Private Sub FileList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lview.DoubleClick

'            Dim s As String = lview.SelectedItems(0).Text
'            If s = "" Then Exit Sub
'            Dim i, j, k As Integer
'            Dim ss As String = drlstbx.GetAbsoluteDirectory

'            If Not ss.EndsWith("\") Then ss = ss & "\"
'            s = ss & s
'            ' check if this is a file or folder
'            If (File.GetAttributes(s) And FileAttributes.Directory) <> FileAttributes.Directory Then
'                RaiseEvent FileSelected(s)
'                Exit Sub
'            End If
'            ' search the node collections till you find the folder
'            Dim segment As String() = s.Split(CChar("\"))
'            Dim tnclx As TreeNodeCollection
'            Dim node As TreeNode
'            tnclx = drlstbx.Nodes
'            For i = 0 To segment.GetLength(0) - 1
'                k = -1
'                If segment(i).EndsWith(CChar(":")) Then segment(i) = segment(i) & "\"
'                For j = 0 To tnclx.Count - 1
'                    Debug.WriteLine(tnclx(j).Text)
'                    If tnclx(j).Text = segment(i) Then k = j : Exit For
'                Next
'                If j <> k Then Exit Sub
'                If i < segment.GetLength(0) - 1 Then
'                    node = tnclx(j)
'                    tnclx = tnclx(j).Nodes
'                    If tnclx(0).Text = "." Then
'                        node.Expand()
'                        tnclx = node.Nodes
'                    End If
'                Else
'                    tnclx(j).Expand()
'                    drlstbx.SelectedNode = tnclx.Item(j)
'                End If
'            Next
'        End Sub

'        Private Class clsfilelist
'            Inherits ListView
'            Dim sortColumn As Integer '( starts from 1!)
'            Const SHGFI_SMALLICON As Short = &H1S
'            Const SHGFI_LARGEICON As Short = &H0S

'            'Define the LVCOLUMN for use with Interop.
'            <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
'             Structure LVCOLUMN
'                Dim mask As Integer
'                Dim fmt As Integer
'                Dim cx As Integer
'                Dim pszText As IntPtr
'                Dim cchTextMax As Integer
'                Dim iSubItem As Integer
'                Dim iImage As Integer
'                Dim iOrder As Integer
'            End Structure
'            'Declare two overloaded SendMessage functions. The
'            'difference is in the last parameter.
'            <DllImport("User32.dll")> _
'            Public Overloads Shared Function SendMessage _
'                (ByVal hWnd As IntPtr, ByVal Msg As Integer, _
'                 ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
'            End Function
'            <DllImport("User32", CharSet:=CharSet.Auto)> _
'            Public Overloads Shared Function SendMessage _
'                (ByVal hWnd As IntPtr, ByVal msg As Integer, _
'                 ByVal wParam As Integer, ByRef lParam As LVCOLUMN) As IntPtr
'            End Function

'            <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure SHFILEINFO
'                Dim hIcon As IntPtr
'                Dim iIcon As Integer
'                Dim dwAttributes As Integer
'                <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
'                <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
'            End Structure

'            Private Declare Ansi Function SHGetFileInfo Lib "shell32.dll" Alias "SHGetFileInfoA" (ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As Integer

'            Private Sub ColumnHeaderClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles MyBase.ColumnClick

'                If e.Column = sortColumn - 1 Then
'                    ' Just change the Sort Order
'                    Select Case Sorting
'                        Case SortOrder.Ascending : Sorting = SortOrder.Descending
'                        Case SortOrder.Descending : Sorting = SortOrder.Ascending
'                    End Select
'                Else
'                    ' Change column, always start sorting Ascending
'                    Sorting = SortOrder.Ascending
'                    ' Remove the sorting icon from the current sorting column (if any)
'                    If sortColumn > 0 Then
'                        SetColumnImage(sortColumn - 1, SortOrder.None)
'                    End If
'                End If
'                sortColumn = e.Column + 1
'                SetColumnImage(e.Column, Sorting)
'                ' Set the ListViewItemSorter property to a new ListViewItemComparer object.
'                MyBase.ListViewItemSorter = New clsListViewItemComparer(e.Column, MyBase.Sorting)
'                ' Call the sort method to manually sort the column based on the ListViewItemComparer implementation.
'                MyBase.Sort()
'            End Sub
'            Private Sub SetColumnImage(ByVal clmn As Integer, ByVal value As SortOrder)
'                ' Set the icon in the header to denote the sorting Sequence
'                Dim hwnd As IntPtr
'                Dim lret As IntPtr

'                Const LVM_GETHEADER As Integer = 4127
'                Const HDM_SETIMAGELIST As Integer = 4616
'                Const LVM_SETCOLUMN As Integer = 4122
'                Const LVCF_FMT As Integer = 1
'                Const LVCF_IMAGE As Integer = 16
'                Const LVCFMT_IMAGE As Integer = 2048
'                Const LVCFMT_RIGHT As Integer = 1
'                Const LVCFMT_LEFT As Integer = 0
'                Const LVCFMT_CENTER As Integer = 2
'                'Assign the ImageList to the header control.
'                'The header control includes all columns.
'                'Get a handle to the header control.

'                hwnd = SendMessage(MyBase.Handle, LVM_GETHEADER, 0, 0)

'                'Add the ImageList to the header control.
'                lret = SendMessage(hwnd, HDM_SETIMAGELIST, 0, (MyBase.SmallImageList.Handle).ToInt32)
'                'This code uses LVCOLUMN to define alignment. By using LVCOLUMN here, you have to set the alignment too!

'                'Use the LVM_SETCOLUMN message to set the column's image index. 
'                Dim col As LVCOLUMN

'                col.mask = LVCF_FMT ' the fmt member is valid

'                Select Case Columns(clmn).TextAlign
'                    Case HorizontalAlignment.Left : col.fmt = LVCFMT_LEFT
'                    Case HorizontalAlignment.Right : col.fmt = LVCFMT_RIGHT
'                    Case HorizontalAlignment.Center : col.fmt = LVCFMT_CENTER
'                End Select

'                If value <> SortOrder.None Then
'                    col.mask = col.mask Or LVCF_IMAGE 'the iImage member is Valid
'                    col.fmt = col.fmt Or LVCFMT_IMAGE 'The item displays an image from an image list
'                End If
'                'The image to use from the Image List if col.FMT contains LVCF_IMAGE
'                If value = SortOrder.Ascending Then col.iImage = 7 Else col.iImage = 8
'                col.cchTextMax = 0
'                col.cx = 0
'                col.iOrder = 0
'                col.iSubItem = 0
'                col.pszText = IntPtr.op_Explicit(0)
'                'Send the LVM_SETCOLUMN message.
'                'The column to which you are assigning the image is defined in the third parameter.
'                lret = SendMessage(MyBase.Handle, LVM_SETCOLUMN, clmn, col)
'            End Sub
'            Public Sub ImagelistAddFileIcon(ByVal afile As String)
'                SmallImageList.Images.Add(getIcon(afile, SHGFI_SMALLICON))
'            End Sub
'            Private Function getIcon(ByVal FileName As String, ByVal IconOption As Integer) As System.Drawing.Icon
'                'Get the icon of the associated application (only small icons are implemented!)
'                ' valid Iconoptions are:
'                '0:
'                'SHGFI_SMALLICON
'                'SHGFI_LARGEICON
'                Dim shfi As SHFILEINFO
'                Const SHGFI_USEFILEATTRIBUTES As Short = &H10S
'                Const SHGFI_ICON As Short = &H100S
'                Const FILE_ATTRIBUTE_NORMAL As Short = &H80S
'                'Const SHGFI_TYPENAME As Short = &H400S
'                'Const SHGFI_DISPLAYNAME As Short = &H200S

'                IconOption = IconOption Or SHGFI_ICON Or SHGFI_USEFILEATTRIBUTES
'                SHGetFileInfo(FileName, FILE_ATTRIBUTE_NORMAL, shfi, Marshal.SizeOf(shfi), IconOption)
'                Dim myIcon As System.Drawing.Icon = System.Drawing.Icon.FromHandle(shfi.hIcon)
'                Return myIcon
'            End Function
'        End Class
'        Private Class clsdirlistbox
'            Inherits TreeView
'            Shared InstantiatedBy As String
'            Enum imageIndexEnum
'                ' This is the list of images in the Imagelist control
'                ClosedFolder = 1
'                Removable = 2
'                Fixed = 3
'                NetWork = 4
'                CDROM = 5
'                OpenFolder = 6
'            End Enum
'            Dim images As New imageIndexEnum
'            Dim drilled As New SortedList
'            Shared Function IsInstantiatedBy() As String
'                ' Allows for singleton use
'                Return InstantiatedBy
'            End Function
'            Public Sub New()
'                MyBase.New()
'            End Sub
'            Public Sub Open(ByVal instantiator As String, ByVal filepath As String)
'                ' Leave InstatiatedBy blank if not used as singleton
'                If InstantiatedBy <> "" Then Exit Sub
'                InstantiatedBy = instantiator
'                ' Clear the treeview and the sortedList
'                '      MyBase.Nodes.Clear()
'                Nodes.Clear()
'                drilled.Clear()
'                If filepath = "" Then
'                    ' If no filepath is given, get all logical drives
'                    Dim dirs As String()

'                    Dim i As Integer
'                    ' Prevent all input and show the hourglass
'                    Windows.Forms.Cursor.Current = Cursors.WaitCursor
'                    ' Prevent the Treeview from being repainted
'                    BeginUpdate()
'                    ' Get all logical drives on the machine and put them in the treeview

'                    dirs = Directory.GetDirectories("\\Srv115fs01\quality\QUALITY DOCUMENTS\")
'                    For i = 0 To dirs.Length - 1
'                        If dirs(i).EndsWith(":") Then dirs(i) = dirs(i) & "\"
'                        Dim driveNode As TreeNode = New TreeNode(dirs(i))
'                        'driveNode.ImageIndex = DriveImageIndex(dirs(i))
'                        driveNode.SelectedImageIndex = driveNode.ImageIndex

'                        Nodes.Add(driveNode)
'                        ' Check for any subdirs, if any exist, add a placeholder child node.
'                        ' Also build a list of nodes to be expanded.
'                        Addplaceholders(driveNode)
'                    Next

'                    Windows.Forms.Cursor.Current = Cursors.Default
'                    EndUpdate()
'                Else
'                    ' Trim any excess \ 
'                    If filepath.EndsWith("\") Then
'                        filepath = filepath.TrimEnd(System.Convert.ToChar("\"))
'                    End If
'                    ' Append \ if the path ends with ":"
'                    If filepath.EndsWith(":") Then
'                        filepath = filepath & "\"
'                    End If
'                    If (Directory.Exists(filepath)) Then
'                        ' Add the root node and set its imageindex
'                        Dim firstNode As TreeNode = New TreeNode(filepath)
'                        If filepath.EndsWith(":\") Then
'                            firstNode.ImageIndex = DriveImageIndex(filepath)
'                        Else
'                            firstNode.ImageIndex = imageIndexEnum.ClosedFolder
'                        End If
'                        firstNode.SelectedImageIndex = firstNode.ImageIndex
'                        Nodes.Add(firstNode)
'                        ' Check for any subdirs, if any exist, add a placeholder child node.
'                        ' Also build a list containing nodes at the extent of directory drilldown that can be expanded.
'                        Addplaceholders(firstNode)
'                    Else
'                        Throw New DirectoryNotFoundException("The path: " + filepath + " could not be found.")
'                    End If
'                End If
'                Me.Select()
'                If Nodes.Count > 0 Then
'                    SelectedNode = Nodes(0)
'                End If
'            End Sub
'            Public Sub Close(ByVal instantiator As String)
'                ' Optional, releases the exclusive use of the class
'                If instantiator <> InstantiatedBy Then Exit Sub
'                InstantiatedBy = ""
'            End Sub
'            Private Function DriveImageIndex(ByVal driveName As String) As Integer
'                ' Check the drive Type and return the appropriate imageIndex enumerated value 
'                Dim i As Integer
'                If driveName.EndsWith("\") Then
'                    driveName = driveName.Remove(driveName.Length - 1, 1)
'                End If
'                Dim disk As New ManagementObject("win32_logicaldisk.deviceid=""" & driveName & """")
'                disk.Get()
'                i = CInt(disk("drivetype").ToString())
'                Select Case i
'                    Case 2 : Return imageIndexEnum.Removable
'                    Case 3 : Return imageIndexEnum.Fixed
'                    Case 4 : Return imageIndexEnum.NetWork
'                    Case 5 : Return imageIndexEnum.CDROM
'                End Select
'                Return imageIndexEnum.Fixed
'            End Function
'            Private Sub Addplaceholders(ByVal aNode As TreeNode)

'                Dim dirs As String()

'                Try
'                    dirs = Directory.GetDirectories(aNode.FullPath)
'                Catch ex As System.UnauthorizedAccessException
'                    ' Eat the exception when a directory cannot be accessed.
'                Catch ex As System.IO.IOException
'                    ' Eat the exception when a resource cannot be accessed.
'                End Try

'                If Not IsNothing(dirs) AndAlso dirs.Length > 0 Then
'                    ' Add a placeholder child node
'                    aNode.Nodes.Add(New TreeNode("."))
'                    ' Add the Node to the list of expandable nodes
'                    drilled.Add(aNode.FullPath, Nothing)
'                End If
'            End Sub
'            Private Sub NodeBeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles MyBase.BeforeExpand
'                ' If the node hasn't been expanded before, some work has to be done
'                If (drilled.ContainsKey(e.Node.FullPath)) Then
'                    ' If the node is found in this list, it has not been expanded yet
'                    ' Clear the placeholder
'                    e.Node.Nodes.Clear()
'                    ' Change its image index (if applicable)
'                    If e.Node.ImageIndex = imageIndexEnum.ClosedFolder Then
'                        e.Node.ImageIndex = imageIndexEnum.OpenFolder
'                        e.Node.SelectedImageIndex = imageIndexEnum.OpenFolder
'                    End If
'                    ' Add the nodes of the subFolders.
'                    Dim dirs As String()
'                    Dim i As Integer
'                    dirs = Directory.GetDirectories(e.Node.FullPath)
'                    For i = 0 To dirs.Length - 1
'                        ' for each folder, add a node and any placeholders.
'                        Dim folderNode As TreeNode = New TreeNode(LastSegment(dirs(i)))
'                        folderNode.ImageIndex = imageIndexEnum.ClosedFolder
'                        folderNode.SelectedImageIndex = imageIndexEnum.ClosedFolder
'                        e.Node.Nodes.Add(folderNode)
'                        Addplaceholders(folderNode)
'                    Next
'                    ' Remove this node from the list.
'                    drilled.Remove(e.Node.FullPath)
'                End If
'            End Sub
'            Private Function LastSegment(ByVal directoryname As String) As String
'                ' The directory path is parsed and 
'                ' the most nested subfolder from within the path is returned.
'                Dim segments As String() = directoryname.Split(System.Convert.ToChar("\"))
'                Return segments(segments.Length - 1)
'            End Function
'            Public Function GetDirectory() As String
'                ' returns the relative path of the selected directory
'                If IsNothing(MyBase.SelectedNode) Then Return ""
'                Return CorrectFullPath(MyBase.SelectedNode.FullPath)
'            End Function
'            Public Function GetAbsoluteDirectory() As String
'                ' Returns the selected directory with no relative paths
'                If IsNothing(MyBase.SelectedNode) Then Return ""
'                Dim aPath As String = CorrectFullPath(MyBase.SelectedNode.FullPath)
'                If (Directory.Exists(aPath)) Then
'                    Dim d As DirectoryInfo = New DirectoryInfo(aPath)
'                    Return d.FullName
'                Else
'                    Return ""
'                End If
'            End Function
'            Public Sub RefreshNode()
'                Dim strPath As String
'                Dim thisKey As String
'                Dim i As Integer
'                If IsNothing(MyBase.SelectedNode) Then Exit Sub
'                ' remove all entries in the sortlist that depend on this node
'                strPath = MyBase.SelectedNode.FullPath
'                For i = drilled.Count - 1 To 0 Step -1
'                    thisKey = CType(drilled.GetKey(i), String)
'                    If thisKey.StartsWith(strPath) Then
'                        drilled.Remove(thisKey)
'                    End If
'                Next
'                MyBase.SelectedNode.Collapse()
'                MyBase.SelectedNode.Nodes.Clear()
'                Addplaceholders(MyBase.SelectedNode)
'                MyBase.Refresh()
'            End Sub
'            Private Function CorrectFullPath(ByVal aPath As String) As String
'                ' Remove double \\, due to the fact that a drive path ends with one \ and
'                ' that the pathseparator is a \ as well
'                aPath = Replace(aPath, ":\\", ":\", 1, -1, CompareMethod.Text)
'                ' Remove the \ at the end, except when it is a drive path
'                If Not aPath.EndsWith(":\") Then
'                    If aPath.EndsWith("\") Then
'                        aPath = aPath.Remove(aPath.Length - 1, 1)
'                    End If
'                End If
'                Return (aPath)
'            End Function
'            Private Sub clsDirListBoxBeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles MyBase.BeforeSelect
'                If e.Node.ImageIndex = imageIndexEnum.ClosedFolder Then
'                    e.Node.ImageIndex = imageIndexEnum.OpenFolder
'                    e.Node.SelectedImageIndex = imageIndexEnum.OpenFolder
'                End If
'            End Sub
'        End Class
'        Private Class clsListViewItemComparer
'            Implements IComparer
'            ' Implements the manual sorting of items by columns.

'            Private col As Integer
'            Private sorting As SortOrder

'            Public Sub New()
'                col = 0
'            End Sub

'            Public Sub New(ByVal column As Integer, ByVal value As SortOrder)
'                col = column
'                sorting = value
'            End Sub

'            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
'              Implements IComparer.Compare
'                Dim xs, ys As String
'                Dim bx, by As Boolean

'                Try
'                    If col = 0 Then
'                        ' check if this is a file or folder: they are sorted separately!
'                        ' use the imageindex to find out
'                        ' if it is a folder, put a space at the front of the name, this must ensure that all folders come
'                        ' before or after the files
'                        xs = CType(x, ListViewItem).Text
'                        If CType(x, ListViewItem).ImageIndex = 1 Then xs = " " & xs
'                        ys = CType(y, ListViewItem).Text
'                        If CType(y, ListViewItem).ImageIndex = 1 Then ys = " " & ys
'                        ' take the sortorder into account
'                        Select Case sorting
'                            Case SortOrder.Ascending
'                                Return [String].Compare(xs, ys)
'                            Case SortOrder.Descending
'                                Return [String].Compare(ys, xs)
'                            Case SortOrder.None
'                                Return 0
'                        End Select
'                    ElseIf col = 1 Then
'                        ' sort on size: if x and y are two folders, use their name
'                        '               if is a folder and a file use their size (folder size=-1)
'                        '               if x an y are both files use their sizes
'                        ' use the imagindex to find out if it is a folder
'                        If CType(x, ListViewItem).ImageIndex = 1 Then bx = True
'                        If CType(y, ListViewItem).ImageIndex = 1 Then by = True

'                        If (bx And by) = True Then
'                            ' both are folders: use their description for sorting
'                            xs = CType(x, ListViewItem).Text
'                            ys = CType(y, ListViewItem).Text
'                            Select Case sorting
'                                Case SortOrder.Ascending
'                                    Return [String].Compare(xs, ys)
'                                Case SortOrder.Descending
'                                    Return [String].Compare(ys, xs)
'                                Case SortOrder.None
'                                    Return 0
'                            End Select
'                        ElseIf (bx Or by) = False Then
'                            'both are files: remove " KB"
'                            xs = CType(x, ListViewItem).SubItems(col).Text
'                            ys = CType(y, ListViewItem).SubItems(col).Text
'                            xs = xs.Remove(xs.Length - 3, 3)
'                            ys = ys.Remove(ys.Length - 3, 3)
'                            Select Case sorting
'                                Case SortOrder.Ascending
'                                    Return Decimal.Compare(CDec(xs), CDec(ys))
'                                Case SortOrder.Descending
'                                    Return Decimal.Compare(CDec(ys), CDec(xs))
'                                Case SortOrder.None
'                                    Return 0
'                            End Select
'                        Else
'                            ' mixed
'                            If bx = True Then
'                                Select Case sorting
'                                    Case SortOrder.Ascending : Return -1
'                                    Case SortOrder.Descending : Return 1
'                                    Case SortOrder.None : Return 0
'                                End Select
'                            Else
'                                Select Case sorting
'                                    Case SortOrder.Ascending : Return 1
'                                    Case SortOrder.Descending : Return -1
'                                    Case SortOrder.None : Return 0
'                                End Select
'                            End If
'                        End If
'                    Else '(col=2)
'                        ' compare two dates (but keep the folder and files separate)

'                        If CType(x, ListViewItem).ImageIndex = 1 Then bx = True
'                        If CType(y, ListViewItem).ImageIndex = 1 Then by = True

'                        If (bx And by) = True Or (bx Or by) = False Then
'                            ' both are of the same type: compare
'                            xs = CType(x, ListViewItem).SubItems(col).Text
'                            ys = CType(y, ListViewItem).SubItems(col).Text
'                            Select Case sorting
'                                Case SortOrder.Ascending
'                                    Return [Date].Compare(CDate(xs), CDate(ys))
'                                Case SortOrder.Descending
'                                    Return [Date].Compare(CDate(ys), CDate(xs))
'                                Case SortOrder.None
'                                    Return 0
'                            End Select
'                        Else
'                            ' mixed
'                            If bx = True Then
'                                Select Case sorting
'                                    Case SortOrder.Ascending : Return -1
'                                    Case SortOrder.Descending : Return 1
'                                    Case SortOrder.None : Return 0
'                                End Select
'                            Else
'                                Select Case sorting
'                                    Case SortOrder.Ascending : Return 1
'                                    Case SortOrder.Descending : Return -1
'                                    Case SortOrder.None : Return 0
'                                End Select
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    ' the compare is called before the subitem(1) is actually added!
'                    ' this puts us in an akward position, so we swallow the exception.
'                    ' and pretend that both listviewitems are equal.
'                    Return 0
'                End Try
'            End Function
'        End Class

'    End Class
'End Namespace
