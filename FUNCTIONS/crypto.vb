Imports System.Security.Cryptography
Imports System.Security.Cryptography.CryptoStream
Imports System.Text
Imports System.IO

Public Module crypto
    Public Class encryption

        Public Function AES256Decrypt(ByVal prm_key As String, ByVal prm_iv As String, ByVal prm_text_to_decrypt As String)

            Dim sEncryptedString As String = prm_text_to_decrypt

            Dim myRijndael As New RijndaelManaged
            myRijndael.Padding = PaddingMode.Zeros
            myRijndael.Mode = CipherMode.CBC
            myRijndael.KeySize = 256
            myRijndael.BlockSize = 256

            Dim key() As Byte
            Dim IV() As Byte

            key = System.Text.Encoding.ASCII.GetBytes(prm_key)
            IV = System.Text.Encoding.ASCII.GetBytes(prm_iv)

            Dim decryptor As ICryptoTransform = myRijndael.CreateDecryptor(key, IV)

            Dim sEncrypted As Byte() = Convert.FromBase64String(sEncryptedString)

            Dim fromEncrypt() As Byte = New Byte(sEncrypted.Length) {}

            Dim msDecrypt As New MemoryStream(sEncrypted)
            Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

            Return (System.Text.Encoding.ASCII.GetString(fromEncrypt))

        End Function

        Public Function AES256Encrypt(ByVal prm_key As String, ByVal prm_iv As String, ByVal prm_text_to_encrypt As String)

            Dim sToEncrypt As String = prm_text_to_encrypt

            Dim myRijndael As New RijndaelManaged
            myRijndael.Padding = PaddingMode.Zeros
            myRijndael.Mode = CipherMode.CBC
            myRijndael.KeySize = 256
            myRijndael.BlockSize = 256

            Dim encrypted() As Byte
            Dim toEncrypt() As Byte
            Dim key() As Byte
            Dim IV() As Byte

            key = System.Text.Encoding.ASCII.GetBytes(prm_key)
            IV = System.Text.Encoding.ASCII.GetBytes(prm_iv)

            Dim encryptor As ICryptoTransform = myRijndael.CreateEncryptor(key, IV)

            Dim msEncrypt As New MemoryStream()
            Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

            toEncrypt = System.Text.Encoding.ASCII.GetBytes(sToEncrypt)

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length)
            csEncrypt.FlushFinalBlock()

            encrypted = msEncrypt.ToArray()

            Return (Convert.ToBase64String(encrypted))

        End Function

        Public Function help()
            Return "Encrypt: AES256Encrypt(key, iv, text)
Decrypt: AES256Decrypt(key, iv, encrypted_text)"
        End Function

    End Class

    Public Class hash

        Public Function md5(str)
            Using hasher As MD5 = md5.Create()    ' create hash object

                ' Convert to byte array and get hash
                Dim dbytes As Byte() =
                 hasher.ComputeHash(encoding.UTF8.GetBytes(str))

                ' sb to create string from bytes
                Dim sBuilder As New StringBuilder()

                ' convert byte data to hex string
                For n As Integer = 0 To dbytes.Length - 1
                    sBuilder.Append(dbytes(n).ToString("X2"))
                Next n

                Return sBuilder.ToString()
            End Using
        End Function

        Public Function sha1(str)
            Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(str)

            bytesToHash = sha1Obj.ComputeHash(bytesToHash)

            Dim strResult As String = ""

            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next

            Return strResult
        End Function

        Public Function sha256(ByVal inputString) As String
            Dim sha256hash As SHA256 = SHA256Managed.Create()
            Dim bytes As Byte() = encoding.UTF8.GetBytes(inputString)
            Dim hash As Byte() = sha256hash.ComputeHash(bytes)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            Return stringBuilder.ToString()
        End Function

        Public Function sha512(ByVal inputString) As String
            Dim sha512hash As SHA512 = SHA512Managed.Create()
            Dim bytes As Byte() = encoding.UTF8.GetBytes(inputString)
            Dim hash As Byte() = sha512hash.ComputeHash(bytes)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            Return stringBuilder.ToString()

        End Function


    End Class

    Public Class string_encoding

        Function base64_encode(str)
            Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str))
        End Function

        Function base64_decode(str)
            Dim base64Encoded As String = str
            Dim base64Decoded As String
            Dim data() As Byte
            data = System.Convert.FromBase64String(base64Encoded)
            base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data)
            Return base64Decoded
        End Function

    End Class

    Public Class crypto
        Public Property encryption As New encryption
        Public Property hash As New hash
        Public Property encoding As New string_encoding
    End Class

End Module

