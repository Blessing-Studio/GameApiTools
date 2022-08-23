# GameApiTools

 一个游戏Api封装库，集成了我能找到的所有api
 
 还没写完（目前只有部分我的世界以及米游社的api，未来将会支持更多！
 
 ## 基本使用（Minecraft）
 引用
 > 注意，所有的api都在ApiConstant这个常量表里，命名空间为GameApiTools.Module.Constants
 > 如因使用api常量表里没有的api导致爆炸，我概不负责（跑
``` c#
//取原版游戏列表的方法
GameListTools gameListTools = new GameListTools();//这个没啥好说的
var v11 = gameListTools.Send(ApiConstant.MinecraftListAPiM);//获取并序列化游戏列表
foreach (var i in v11.AllVersion)//循环遍历所有的版本并将版本号打印到控制台上
{
     Console.WriteLine(i.Id);
}
```
> 除了Send方法以外还有SendAsync方法获取完整的游戏列表
#### 如果你只想获取单一版本类型，可以使用一下方法
``` c#
OnlySendRelease() //只会接收正式版，参数和Send方法一样
OnlySendOld() //和正式版一样的道理，只不过接收的是远古版
OnlySendSnapshot() //如上，接收的是快照版
``` 

## 基本使用（米游社（原神））
> nnd，获取cookie请自行通过内嵌浏览器方式获取
 ``` c#
 //获取用户信息方法
 SignTools sign = new SignTools("cookie"）//此处参数填在浏览器登录后获取的cookie
 var refinfo = sign.GetUserGameRolesAsync(ApiConstant.MiHoYoSignApi);//接收用户信息方法
 ``` 

## 基本使用（Steam）
在制品
