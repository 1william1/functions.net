# functions.net
An .NET functions class library. featuring AES-256-CBC Encryption, SHA1, SHA256, SHA512, MD5. Also featuring UI elements (drag controls, drag labels, draggable pictures) Web request with custom user agents also hidden from programs such as Fiddler.

## Features

|                     | Description                                       |
|:-------------------:|---------------------------------------------------|
| AES-256-CBC ENCRYPT | Encrypts a string using the AES algorithm         |
| AES-256-CBC DECRYPT | Decrypts a string using the AES algorithm         |
| *Hash*              |                                                   |
| MD5                 | Hashs a string using MD5                          |
| SHA1                | Hashs a string using SHA1                         |
| SHA256              | Hashs a string using SHA256                       |
| SHA512              | Hashs a string using SHA512                       |
| *Encoding*          |                                                   |
| BASE64 ENCODE       | Encodes a string in base64                        |
| BASE64 DECODE       | Decodes a string in base64                        |
| *WEB*               |                                                   |
| GET                 | Makes an http get request with a custom useragent |
| POST                | Makes an http POST request with a custom useragent|

## Install
To use Functions.net in your project first add a refrence in the solution explorer to `FUNCTIONS.dll`
```net
Imports FUNCTIONS.crypto

Public class Form1
  
  Dim crypto As New crypto
  Dim web As New FUNCTIONS.net.web
  
End Class
```
To add the UI elements goto `Toolbox->choose itmes->browse` and add `FUNCTIONS.dll`

## Docs

Documentation on how to use these functions.

#### AES-256-CBC
Encrypt
```vb
Dim encrypted = crypto.encryption.AES256Encrypt("Encryption key *32 chars only", "IV *32 chars only", "my string to encrypt")
```
Decrypt
```vb
Dim decrypted = crypto.encryption.AES256Decrypt("Encryption key *32 chars only", "IV *32 chars only", "encrypted string")
```

#### Hash
MD5
```vb
Dim hash = crypto.hash.md5("my string")
```
SHA1
```vb
Dim hash = crypto.hash.sha1("my string")
```
SHA256
```vb
Dim hash = crypto.hash.sha256("my string")
```
SHA512
```vb
Dim hash = crypto.hash.sha512("my string")
```

#### Encoding
Base64 Encode
```vb
Dim encoded = crypto.encoding.base64_encode("my string")
```
Base64 Decode
```vb
Dim decoded = crypto.encoding.base64_decode("my string")
```

#### Web
settings
```
web.settings.useragent
web.settings.self_proxy 'hide from programs like fiddler
```

GET REQUEST
```vb
Dim data = web.http_get("https://example.com")
```
POST REQUEST
```vb
Dim post As New Specialized.NameValueCollection
post.Add("username", "myamazing_username")
post.Add("password", "100%secure")
Dim data = web.http_post("https://example.com", post)
```

## UI Elements

![UI](https://cdn.discordapp.com/attachments/341914782053695490/482910192414097426/unknown.png)
