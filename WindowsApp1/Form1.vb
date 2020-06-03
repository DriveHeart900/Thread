Public Class Form1

    Private Delegate Function NoteDelegate(ByVal obj As Object) As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '关闭主窗体
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim dialogClose As DialogResult
        dialogClose = MessageBox.Show("确认要关闭软件吗？ ", "警告提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialogClose = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
            Application.Exit()
        End If
    End Sub

    '打开notePad编辑器
    Private Function openNote()
        Shell("notepad.exe C:\Users\AzureTest\Desktop\WindowsApp1\USA.txt", AppWinStyle.MinimizedFocus)
    End Function
    '按钮
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '非阻塞式多线程
        Dim testCall As New NoteDelegate(AddressOf openNote)
        testCall.BeginInvoke(sender, Nothing, Nothing)

        Form1_FormClosed(Nothing, Nothing)
    End Sub
End Class
