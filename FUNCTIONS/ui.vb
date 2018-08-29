Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class A1_dragable_box
    Inherits Panel

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer
    Private _form = Me.FindForm()

    Public Sub New()

        AddHandler MouseDown, AddressOf Me.Mdown
        AddHandler MouseMove, AddressOf Me.MMove
        AddHandler MouseUp, AddressOf Me.Mup
    End Sub

    Public Sub Mdown(sender As Object, e As MouseEventArgs)
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
    End Sub


    Public Sub MMove(sender As Object, e As MouseEventArgs)
        If _isMoved Then


            Me.Location = New Point(Me.Location.X + (e.Location.X - _x), Me.Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Public Sub Mup(sender As Object, e As MouseEventArgs)
        _isMoved = False
    End Sub

End Class

Public Class A1_drag_control
    Inherits Panel

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer
    Private _form = Me.FindForm()

    Public Sub New()

        AddHandler MouseDown, AddressOf Me.Mdown
        AddHandler MouseMove, AddressOf Me.MMove
        AddHandler MouseUp, AddressOf Me.Mup
    End Sub

    Public Sub Mdown(sender As Object, e As MouseEventArgs)
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
    End Sub


    Public Sub MMove(sender As Object, e As MouseEventArgs)
        If _isMoved Then


            Me.FindForm().Location = New Point(Me.FindForm().Location.X + (e.Location.X - _x), Me.FindForm().Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Public Sub Mup(sender As Object, e As MouseEventArgs)
        _isMoved = False
    End Sub

End Class

Public Class A1_drag_control_lable
    Inherits Label

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer
    Private _form = Me.FindForm()

    Public Sub New()
        AddHandler MouseDown, AddressOf Me.Mdown
        AddHandler MouseMove, AddressOf Me.MMove
        AddHandler MouseUp, AddressOf Me.Mup
    End Sub

    Public Sub Mdown(sender As Object, e As MouseEventArgs)
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
    End Sub


    Public Sub MMove(sender As Object, e As MouseEventArgs)
        If _isMoved Then
            Me.FindForm().Location = New Point(Me.FindForm().Location.X + (e.Location.X - _x), Me.FindForm().Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Public Sub Mup(sender As Object, e As MouseEventArgs)
        _isMoved = False
    End Sub

End Class

Public Class A1_drag_control_picture
    Inherits PictureBox

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer
    Private _form = Me.FindForm()

    Public Sub New()
        AddHandler MouseDown, AddressOf Me.Mdown
        AddHandler MouseMove, AddressOf Me.MMove
        AddHandler MouseUp, AddressOf Me.Mup
    End Sub

    Public Sub Mdown(sender As Object, e As MouseEventArgs)
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
    End Sub


    Public Sub MMove(sender As Object, e As MouseEventArgs)
        If _isMoved Then
            Me.FindForm().Location = New Point(Me.FindForm().Location.X + (e.Location.X - _x), Me.FindForm().Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Public Sub Mup(sender As Object, e As MouseEventArgs)
        _isMoved = False
    End Sub

End Class


Public Class A1_CircularPictureBox
    Inherits PictureBox

    Sub New()

    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)

        Using gp = New Drawing2D.GraphicsPath
            gp.AddEllipse(0, 0, Width, Height)
            Region = New Region(gp)
        End Using

        MyBase.OnPaint(pe)

    End Sub

End Class


Public Class A1_Drag_control_CircularPictureBox
    Inherits PictureBox

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer
    Private _form = Me.FindForm()

    Public Sub New()
        AddHandler MouseDown, AddressOf Me.Mdown
        AddHandler MouseMove, AddressOf Me.MMove
        AddHandler MouseUp, AddressOf Me.Mup
    End Sub

    Public Sub Mdown(sender As Object, e As MouseEventArgs)
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
    End Sub


    Public Sub MMove(sender As Object, e As MouseEventArgs)
        If _isMoved Then
            Me.FindForm().Location = New Point(Me.FindForm().Location.X + (e.Location.X - _x), Me.FindForm().Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Public Sub Mup(sender As Object, e As MouseEventArgs)
        _isMoved = False
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)

        Using gp = New Drawing2D.GraphicsPath
            gp.AddEllipse(0, 0, Width, Height)
            Region = New Region(gp)
        End Using

        MyBase.OnPaint(pe)

    End Sub

End Class

Public Class A1_AlertBox
    Inherits Control

    Private exitLocation As Point
    Private overExit As Boolean

    Enum Style
        Simple
        Success
        Notice
        Warning
        Information
    End Enum

    Private _alertStyle As Style
    Public Property AlertStyle As Style
        Get
            Return _alertStyle
        End Get
        Set(ByVal value As Style)
            _alertStyle = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Font = New Font("Verdana", 8)
        Size = New Size(200, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim borderColor, innerColor, textColor As Color
        Select Case _alertStyle
            Case Style.Simple
                borderColor = Color.FromArgb(90, 90, 90)
                innerColor = Color.FromArgb(50, 50, 50)
                textColor = Color.FromArgb(150, 150, 150)
            Case Style.Success
                borderColor = Color.FromArgb(60, 98, 79)
                innerColor = Color.FromArgb(60, 85, 79)
                textColor = Color.FromArgb(35, 169, 110)
            Case Style.Notice
                borderColor = Color.FromArgb(70, 91, 107)
                innerColor = Color.FromArgb(70, 91, 94)
                textColor = Color.FromArgb(97, 185, 186)
            Case Style.Warning
                borderColor = Color.FromArgb(100, 71, 71)
                innerColor = Color.FromArgb(87, 71, 71)
                textColor = Color.FromArgb(254, 142, 122)
            Case Style.Information
                borderColor = Color.FromArgb(133, 133, 71)
                innerColor = Color.FromArgb(120, 120, 71)
                textColor = Color.FromArgb(254, 224, 122)
        End Select

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(innerColor), mainRect)
        G.DrawRectangle(New Pen(borderColor), mainRect)

        Dim styleText As String = Nothing

        Select Case _alertStyle

        End Select

        Dim styleFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(styleText, styleFont, New SolidBrush(textColor), New Point(10, textY))
        G.DrawString(Text, Font, New SolidBrush(textColor), New Point(10 + G.MeasureString(styleText, styleFont).Width + 4, textY))

        Dim exitFont As New Font("Marlett", 6)
        Dim exitY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString("r", exitFont).Height / 2) + 1
        exitLocation = New Point(Width - 26, exitY - 3)
        G.DrawString("r", exitFont, New SolidBrush(textColor), New Point(Width - 23, exitY))

    End Sub


    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.X >= Width - 26 AndAlso e.X <= Width - 12 AndAlso e.Y > exitLocation.Y AndAlso e.Y < exitLocation.Y + 12 Then
            If Cursor <> Cursors.Hand Then Cursor = Cursors.Hand
            overExit = True
        Else
            If Cursor <> Cursors.Arrow Then Cursor = Cursors.Arrow
            overExit = False
        End If

        Invalidate()

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        If overExit Then Me.Visible = False

    End Sub

End Class


Public Class A1_GroupBox
    Inherits ContainerControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(87, 87, 87)), mainRect)

    End Sub

End Class

Public Class A1_Button : Inherits Button
    Enum MouseState
        None
        Over
        Down
    End Enum
    Enum ColorSchemes
        Dark
    End Enum
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property

    Dim State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub

    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            OnAccentColorChanged()
        End Set
    End Property

    Event AccentColorChanged()

    Sub New()
        MyBase.New()
        Font = New Font("Segoe UI", 9.5)
        ForeColor = Color.White
        BackColor = Color.FromArgb(50, 50, 50)
        AccentColor = Color.FromArgb(70, 70, 70)
        ColorScheme = ColorSchemes.Dark
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        MyBase.OnPaint(e)
        Dim BGColor As Color
        Select Case ColorScheme
            Case ColorSchemes.Dark
                BGColor = Color.FromArgb(50, 50, 50)
        End Select

        Select Case State
            Case MouseState.None
                G.Clear(BGColor)
            Case MouseState.Over
                G.Clear(AccentColor)
            Case MouseState.Down
                G.Clear(AccentColor)
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Black)), New Rectangle(0, 0, Width - 1, Height - 1))
        End Select


        G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))

        Dim ButtonString As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        Select Case ColorScheme
            Case ColorSchemes.Dark
                G.DrawString(Text, Font, Brushes.White, New Rectangle(0, 0, Width - 1, Height - 1), ButtonString)
        End Select

        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
    Protected Sub OnAccentColorChanged() Handles Me.AccentColorChanged
        Invalidate()
    End Sub
End Class


Public Class BonfireAlertBox
    Inherits Control

    Private exitLocation As Point
    Private overExit As Boolean

    Enum Style
        _Error
        _Success
        _Warning
        _Notice
    End Enum

    Private _alertStyle As Style
    Public Property AlertStyle As Style
        Get
            Return _alertStyle
        End Get
        Set(ByVal value As Style)
            _alertStyle = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Font = New Font("Verdana", 8)
        Size = New Size(200, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim borderColor, innerColor, textColor As Color
        Select Case _alertStyle
            Case Style._Error
                borderColor = Color.FromArgb(250, 195, 195)
                innerColor = Color.FromArgb(255, 235, 235)
                textColor = Color.FromArgb(220, 90, 90)
            Case Style._Notice
                borderColor = Color.FromArgb(180, 215, 230)
                innerColor = Color.FromArgb(235, 245, 255)
                textColor = Color.FromArgb(80, 145, 180)
            Case Style._Success
                borderColor = Color.FromArgb(180, 220, 130)
                innerColor = Color.FromArgb(235, 245, 225)
                textColor = Color.FromArgb(95, 145, 45)
            Case Style._Warning
                borderColor = Color.FromArgb(220, 215, 140)
                innerColor = Color.FromArgb(250, 250, 220)
                textColor = Color.FromArgb(145, 135, 110)
        End Select

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(innerColor), mainRect)
        G.DrawRectangle(New Pen(borderColor), mainRect)

        Dim styleText As String = Nothing
        Select Case _alertStyle
            Case Style._Error
                styleText = "Error!"
            Case Style._Notice
                styleText = "Notice!"
            Case Style._Success
                styleText = "Success!"
            Case Style._Warning
                styleText = "Warning!"
        End Select

        Dim styleFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(styleText, styleFont, New SolidBrush(textColor), New Point(10, textY))
        G.DrawString(Text, Font, New SolidBrush(textColor), New Point(10 + G.MeasureString(styleText, styleFont).Width + 4, textY))

        Dim exitFont As New Font("Marlett", 6)
        Dim exitY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString("r", exitFont).Height / 2) + 1
        exitLocation = New Point(Width - 26, exitY - 3)
        G.DrawString("r", exitFont, New SolidBrush(textColor), New Point(Width - 23, exitY))

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.X >= Width - 26 AndAlso e.X <= Width - 12 AndAlso e.Y > exitLocation.Y AndAlso e.Y < exitLocation.Y + 12 Then
            If Cursor <> Cursors.Hand Then Cursor = Cursors.Hand
            overExit = True
        Else
            If Cursor <> Cursors.Arrow Then Cursor = Cursors.Arrow
            overExit = False
        End If

        Invalidate()

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        If overExit Then Me.Visible = False

    End Sub

End Class



Public Class BonfireTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or
                 ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        ItemSize = New Size(0, 30)
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Dim G As Graphics = e.Graphics

        Dim borderPen As New Pen(Color.FromArgb(225, 225, 225))

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim fillRect As New Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3)
        G.FillRectangle(Brushes.White, fillRect)
        G.DrawRectangle(borderPen, fillRect)

        Dim FontColor As New Color

        For i = 0 To TabCount - 1

            Dim mainRect As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then

                G.FillRectangle(New SolidBrush(Color.White), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(Color.FromArgb(20, 160, 230)), New Point(mainRect.X + 1, mainRect.Y), New Point(mainRect.X + mainRect.Width - 1, mainRect.Y))
                G.DrawLine(Pens.White, New Point(mainRect.X + 1, mainRect.Y + mainRect.Height), New Point(mainRect.X + mainRect.Width - 1, mainRect.Y + mainRect.Height))
                FontColor = Color.FromArgb(20, 160, 230)

            Else

                G.FillRectangle(New SolidBrush(Color.FromArgb(245, 245, 245)), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                FontColor = Color.FromArgb(160, 160, 160)

            End If

            Dim titleX As Integer = (mainRect.Location.X + mainRect.Width / 2) - (G.MeasureString(TabPages(i).Text, Font).Width / 2)
            Dim titleY As Integer = (mainRect.Location.Y + mainRect.Height / 2) - (G.MeasureString(TabPages(i).Text, Font).Height / 2)
            G.DrawString(TabPages(i).Text, Font, New SolidBrush(FontColor), New Point(titleX, titleY))

            Try : TabPages(i).BackColor = Color.White : Catch : End Try

        Next

    End Sub

End Class

Public Class BonfireGroupBox
    Inherits ContainerControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.FromArgb(250, 250, 250)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(225, 225, 225)), mainRect)

    End Sub

End Class

Public Class BonfireLabelHeader
    Inherits Label

    Sub New()
        Font = New Font("Verdana", 10, FontStyle.Bold)
    End Sub

End Class

Public Class BonfireLabel
    Inherits Label

    Sub New()
        Font = New Font("Verdana", 8)
        ForeColor = Color.FromArgb(135, 135, 135)
    End Sub

End Class

Public Class BonfireProgressBar
    Inherits Control

    Private _Maximum As Integer = 100
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            If v < 1 Then v = 1
            If v < _Value Then _Value = v
            _Maximum = v
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal v As Integer)
            If v > _Maximum Then v = Maximum
            _Value = v
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Size = New Size(100, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), mainRect)
        G.DrawLine(New Pen(Color.FromArgb(230, 230, 230)), New Point(mainRect.X, mainRect.Height), New Point(mainRect.Width, mainRect.Height))

        Dim barRect As New Rectangle(0, 0, CInt(((Width / _Maximum) * _Value) - 1), Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(20, 160, 230)), barRect)
        If _Value > 1 Then G.DrawLine(New Pen(Color.FromArgb(20, 140, 200)), New Point(barRect.X, barRect.Height), New Point(barRect.Width, barRect.Height))

        Dim textX As Integer = 12
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        Dim percent As Single = (_Value / _Maximum) * 100
        Dim txt As String = Text & " " & CStr(percent) & "%"
        G.DrawString(txt, Font, Brushes.White, New Point(textX, textY))

    End Sub

End Class
