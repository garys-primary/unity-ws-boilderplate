# unity-ws-boilderplate
Unity project with web socket control capabilities

NativeWebSocket
https://github.com/endel/NativeWebSocket/tree/575f41f0ec1325af385b0f08405dd1b2dc604764

Unity > Window > Package Manager
Click Add [+] > Package From Git URL
Enter URL: https://github.com/endel/NativeWebSocket.git#upm

Native WebSokets, author Endel Dreyer
Version 1.1.4

Using certificates
https://medium.com/@hacj/unity-webgl-and-websockets-a-guide-42f3e8f0db34

Realistic Flight physics
https://www.youtube.com/watch?v=7vAHo2B1zLc

Unity flight controller script 
https://github.com/Translab/Unity-Fly-Control/blob/master/Control/CollisionDetect.cs

Unity Basics
https://learn.unity.com/tutorial/setting-up-the-play-area?uv=2019.4&courseId=5c61706dedbc2a324a9b022d&projectId=5f158f1bedbc2a0020e51f0d#

Height Map
https://www.mapzen.com/blog/tangram-heightmapper/

Syntax Cheat Sheet
https://simplecheatsheet.com/tag/c-cheat-sheet-1/

Syntax Snippets
```
int discount = 50;
Console.WriteLine($"Discount: {discount}");

Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");

Random coin = new Random();
int flip = coin.Next(0, 2);

// Don't destroy on load
using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

```

C# Data Types
```
Signed integral types:
sbyte  : -128 to 127
short  : -32768 to 32767
int    : -2147483648 to 2147483647
long   : -9223372036854775808 to 9223372036854775807



```