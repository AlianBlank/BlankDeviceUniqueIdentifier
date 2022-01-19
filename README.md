# BlankDeviceUniqueIdentifier
用于在 Unity3D 中获取Android 和 iOS 平台上唯一机器码的插件


# Example 

```csharp
if (GUILayout.Button("GET DeviceUniqueIdentifier ", GUILayout.Width (200), GUILayout.Height (200))) 
{
    id = BlankDeviceUniqueIdentifier.DeviceUniqueIdentifier;
}
GUILayout.Label("DeviceUniqueIdentifier : "+ id);

```
