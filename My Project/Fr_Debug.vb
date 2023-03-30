﻿Public Class Fr_Debug

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, Button1.Click
        Lst.Items.Clear()
        Select Case ComboBox1.SelectedIndex
            Case 0
                Lst.Items.Add(isMouseDown)
            Case 1
                Lst.Items.Add(isVisualised)
            Case 2
                Lst.Items.Add(StartPoint.ToString)
            Case 3
                Lst.Items.Add(isBlockChosingShow)
            Case 4
                Lst.Items.Add(ArrToString(Blocks))
            Case 5
                Lst.Items.Add(BC)
            Case 6
                Lst.Items.Add(GBBC)
            Case 7
                Lst.Items.Add(ArrToString(MaxEvent))
            Case 8
                Lst.Items.Add(ArrToString(GBBCh))
            Case 9
                Lst.Items.Add(ArrToString(EventB))
            Case 10
                Lst.Items.Add(ArrToString(EventT))
            Case 11
                Lst.Items.Add(ArrToString(OutputB))
            Case 12
                Lst.Items.Add(ArrToString(OutputT))
            Case 13
                Lst.Items.Add(ArrToString(Conteiner))
            Case 14
                For Each i In BlockContent
                    Lst.Items.Add(i)
                Next
            Case 15
                Lst.Items.Add(ArrToString(BlockParants))
            Case 16
                Lst.Items.Add(viscont.Name)
            Case 17
                Lst.Items.Add(visblock.Name)
            Case 18
                Lst.Items.Add(ArrToString(VisConts))
            Case 19
                Lst.Items.Add(VisGB.Name)
            Case 20
                For Each i$ In Block(1)
                    Lst.Items.Add(ArrToString(FindBlockPropertes(i)))
                Next
        End Select
    End Sub

    Private Sub Lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lst.SelectedIndexChanged

    End Sub
End Class