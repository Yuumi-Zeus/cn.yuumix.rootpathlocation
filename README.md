# cn.yuumix.rootpathlocation

## 弃用 Package 管理 Odin Toolkits 

- 比较麻烦，而且 Sample 内容会很多，甚至超过了 Package 的其他部分。因此直接采用 Plugins 文件夹使用会更方便。

- 用 Git 拉取后的 Package 位于 Library 文件夹中，不能进行修改。场景不能打开。如果还想要使用 Package 进行管理，则必须把所有场景相关的，需要调试的内容全部放到 Sample 中（OdinToolkits 中包含非常多的可以调试的内容，也有运行时场景调试）。全部放到 Sample 中反而会显得整个包比较小。

- 通常使用 git 拉取的仓库应该是不需要进行修改调试的代码库。
