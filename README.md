# NRLT-PhiSim
NuanR_Mxi Lazy Team Phigros Simulator，Unity Phigros Sim的重写版本  
~~哎呀重写的和史一样~~  
还是一样，先特别鸣谢：  
他是我跌：不会特效の点缀星空  
感谢他为计算FloorPosition提供了思路  
他也是我跌： ChickenPige0n   
感谢他的PhiDot项目，参考了FloorPosition的计算方式   
## 现版本使用方式  
由于当前项目仍然处在开发阶段，但是它是跨平台的，你可以直接使用Unity6导入本项目并编译任何平台的版本（WebGL未经测试，我们不建议您使用它）。  
在主屏幕，您需要导入一个谱面，然后点击 `开始游玩` 就好了，当前对谱面支持如下：

|        谱面格式        | 支持状态 |
|:------------------:|:----:|
| Phigros_OfficialV3 |  ✅   |
| Phigros_OfficialV1 |  ❌   |
| RePhiEdit_V100~400 |  ❌   |
|    PhiEdit_V0      |  ❌   |

您导入的谱面中必须含有 `config.json`，否则程序无法识别到您提供的谱面  

|      参数      |              说明              |
|:------------:|:----------------------------:|
|    music     |    谱面对应歌曲，当前只能使用 `wav` 格式    |
| illustration |        谱面曲绘，但是它现在不会起效        |
|    chart     | 谱面文件，我们会自动识别谱面类型，只要他是合法的json |

如果导入的谱面有误，我们，，，我们不会怎么样，因为我没有做提示。  
祝你好运。

~~但是我仍然做了多语言兼容，现在它支持简体中文，繁体中文和英文~~




---
__「Writ deep into NuanR_▇▇ is a name you do not know」__