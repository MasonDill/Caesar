'I used phrase to hold text and shift it left or right. 
'Overall I would have changed the way I worked with phrase if I were to do this again.
'It was easy and nice to work with when encoding a phrase
'However when deciphering it I was constantly re-declaring the object and I had to change the 
'shift before I was able to redeclare the object correcyly. 
'It works - but not in the easiest or best way.

Public Class Phrase
    Private m_phrase As String
    Private m_charFreq(25) As Integer 'keeps track of how  many of each type of letter there is
    Private m_phraseArray() As Char 'phrase as a String()
    Private m_shift As Integer = 0 'the shift of the encryption
    Dim alphabet = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

    Public Sub New(p As String, shift As Integer)

        m_phrase = p
        m_phraseArray = p.ToCharArray

        m_shift = shift

        For Each character In m_phraseArray 'fills m_charFreq k
            For alpha As Integer = 0 To 25
                If character = alphabet(alpha) Then
                    m_charFreq(alpha) += 1
                End If
            Next
        Next
    End Sub

    Public Function shiftPhraseRight() As String
        Dim phrase As String = ""

        For Each character In m_phraseArray
            For counter As Integer = 0 To 25
                If alphabet(counter) = (character) Then 'finds the position of character in alphabet
                    If counter + m_shift > 25 Then 'if it would exceed normal bounds
                        phrase = phrase & alphabet(counter + m_shift - 26)
                        Exit For
                    Else 'if it would not
                        phrase = phrase & alphabet(counter + m_shift)
                        Exit For
                    End If
                ElseIf counter = 25 Then
                    phrase = phrase & character
                End If
            Next
        Next
        Return phrase


    End Function

    Public Function shiftPhraseLeft() As String
        Dim phrase As String = ""

        For Each character In m_phraseArray
            For counter As Integer = 0 To 25
                If alphabet(counter) = (character) Then 'finds the position of character in alphabet
                    If counter - m_shift < 0 Then 'if it would exceed normal bounds
                        phrase = phrase & alphabet(counter - m_shift + 26)
                        Exit For
                    Else 'if it would not
                        phrase = phrase & alphabet(counter - m_shift)
                        Exit For
                    End If
                ElseIf counter = 25 Then
                    phrase = phrase & character
                End If
            Next
        Next
        Return phrase


    End Function

    Property shift As Integer
        Get
            Return m_shift
        End Get
        Set(value As Integer)
            m_shift = value
        End Set
    End Property

    Property charArray As Integer()
        Get
            Return m_charFreq
        End Get
        Set(value As Integer())

        End Set
    End Property

    Property phrase As String
        Get
            Return m_phrase
        End Get
        Set(value As String)

        End Set
    End Property

    Property alpha As String()
        Get
            Return alphabet
        End Get
        Set(value As String())

        End Set
    End Property


End Class
