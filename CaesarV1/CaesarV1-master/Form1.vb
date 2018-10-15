Imports System.IO

Public Class Form1
    Dim p As Phrase

    Dim regFreq = {8.1, 1.49, 2.7, 4.2, 12.7, 2.2, 2.0, 6.1, 7.0, 0.2, 0.8, 4.0, 2.4, 6.8, 7.5, 1.9, 0.1, 6.0, 6.3, 9.1, 2.7, 1.0, 2.4, 0.2, 2.0, 0.8}



    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        p = New Phrase(rtxtbxInput.Text.ToLower, nudShift.Value)

        rtxtbxInput.ResetText()

        p = New Phrase(p.shiftPhraseRight, nudShift.Value)

        rtxtbxInput.Text = p.phrase()

        writeToFile()

    End Sub

    Private Sub writeToFile()

        If IO.File.Exists("data.txt") = False Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("data.txt")
            writer.Close()
        End If

        Dim appender As IO.StreamWriter
        appender = IO.File.AppendText("data.txt")
        appender.WriteLine(p.phrase & "," & p.shift)
        appender.Close()
    End Sub

    Private Function readFromFile() As Boolean
        Dim reader As IO.StreamReader
        Dim line(2) As String

        If IO.File.Exists("data.txt") = False Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("data.txt")
            writer.Close()
        End If

        reader = IO.File.OpenText("data.txt")

        While reader.EndOfStream = False
            line = reader.ReadLine().Split(",")

            If line(0).Equals(rtxtbxInput.Text) Then
                p.shift = line(1)
                p = New Phrase(p.shiftPhraseLeft(), line(1))
                rtxtbxInput.Text = p.phrase()
                Return True
            End If

        End While

        reader.Close()

        Return False

    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rtxtbxInput.ResetText()
    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        If readFromFile() Then
            Exit Sub
        End If 'checks to see if this phrase has already been deciphered

        Dim differenceArray(25, 25) As Double 'is a 2d array that holds the differences between the normal and actual letter frequency. It is very useful data that could be used in multiple ways to solve the cipher
        p = New Phrase(rtxtbxInput.Text.ToLower, 0)
        Dim bestShift As Integer = 0 'holds the value of the shift - that when used outputs the 'most regular' letter frequency

        adjustRatio() 'properly adjusts regFreq for the size of phrase

        Dim temp As Phrase = p 'holds p's innitial value as it is constan tly being changed
        For x As Integer = 0 To 25 'this tries out every shift

            p = temp
            p.shift = x
            p = New Phrase(p.shiftPhraseLeft, x)

            For y As Integer = 0 To 25
                differenceArray(x, y) = regFreq(y) - p.charArray(y)

                If differenceArray(x, y) < 0 Then
                    differenceArray(x, y) *= -1 'makes all numbers positive so that having more than the regular ammount of letters would not be beneficial
                End If
            Next

            ' For z As Integer = 0 To 25
            '      ListBox1.Items.Add("shift " & x & ": letter " & p.alpha(z) & " - difference from reg " & differenceArray(z))
            'Next





        Next 'this for loop fills difference array

        '    For row As Integer = 0 To 25

        '        If differenceArray(row, 4) < differenceArray(bestShift, 4) Then
        '           bestShift = row
        '      End If
        'Next 'very primitive way of finding the best shift

        For row As Integer = 0 To 25
            Dim bestSum As Double = 0
            Dim sum As Double = 0
            For col As Integer = 0 To 25
                sum += differenceArray(row, col)
                bestSum += differenceArray(bestShift, col)
            Next

            If sum < bestSum Then
                bestShift = row
            End If
        Next




        p = temp 'resets p's text, but changes the shift
        p.shift = bestShift

        writeToFile()

        p = New Phrase(p.shiftPhraseLeft, bestShift)
        rtxtbxInput.Text = p.phrase

    End Sub

    Private Sub adjustRatio()
        Dim charCount As Integer = 0 'keeps track of how many letters are in the phrase
        For Each number In p.charArray
            charCount += number
        Next 'counts the letters and adds it to charCount
        For Each num In regFreq 'this will adjust the regFreq for the length of the phrase
            num = num / (100 / charCount)
        Next
    End Sub 'properly adjusts regFreq for the size of phrase

    'aaaaaaaa b ccc dddd eeeeeeeeeeeeee ff gg hhhhhh iiiiiii k llll m nnnnnnn oooooooo pp rrrrrr ssssss ttttttttt uuu v ww yy z - I used this to test my decipher. 
    'it has the perfect spread of letters
End Class
